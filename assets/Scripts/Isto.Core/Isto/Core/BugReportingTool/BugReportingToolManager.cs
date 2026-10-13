using System;
using System.Collections;
using System.IO;
using Isto.Core.Data;
using Isto.Core.Inputs;
using Isto.Core.Screenshot;
using TMPro;
using UnityEngine;
using Zenject;

namespace Isto.Core.BugReportingTool;

public class BugReportingToolManager : MonoBehaviour
{
	[SerializeField]
	private JiraUser _currentJiraUser;

	[SerializeField]
	private BugReportPanel _gamePanel;

	[SerializeField]
	private TMP_Text _jiraSubmissionResult;

	private JiraConnection _jiraConnection;

	private bool _isTakingScreenshot;

	private IControls _controls;

	[Inject]
	public void Inject(IControls controls)
	{
		_controls = controls;
	}

	private void Awake()
	{
		_jiraConnection = new JiraConnection(_currentJiraUser);
	}

	private void Update()
	{
		if (_controls != null && _controls.GetControlMode() != Controls.Mode.BugReportingTool && !_isTakingScreenshot && _controls.GetButtonDown(UserActions.TOGGLEBUGREPORTER))
		{
			_controls.SetControlMode(Controls.Mode.BugReportingTool);
			StartCoroutine(ScreenshotRoutine());
		}
	}

	private void OnEnable()
	{
		RegisterEvents();
	}

	private void OnDisable()
	{
		UnregisterEvents();
	}

	private void RegisterEvents()
	{
		BugReportPanel gamePanel = _gamePanel;
		gamePanel.OnBugSubmitted = (Action<JiraBugDataArgs>)Delegate.Combine(gamePanel.OnBugSubmitted, new Action<JiraBugDataArgs>(BugReportPanel_SubmitBugs));
		_jiraConnection.SubmissionResult += JiraConnection_UpdatePanelResult;
	}

	private void UnregisterEvents()
	{
		BugReportPanel gamePanel = _gamePanel;
		gamePanel.OnBugSubmitted = (Action<JiraBugDataArgs>)Delegate.Remove(gamePanel.OnBugSubmitted, new Action<JiraBugDataArgs>(BugReportPanel_SubmitBugs));
		_jiraConnection.SubmissionResult -= JiraConnection_UpdatePanelResult;
	}

	private void BugReportPanel_SubmitBugs(JiraBugDataArgs jiraBugDataArgs)
	{
		StartCoroutine(_jiraConnection.ProcessRequest(jiraBugDataArgs.JiraBugData));
	}

	private void JiraConnection_UpdatePanelResult(object sender, string result)
	{
		_jiraSubmissionResult.text = result;
	}

	private IEnumerator ScreenshotRoutine()
	{
		if (!_isTakingScreenshot)
		{
			_isTakingScreenshot = true;
			yield return new WaitForEndOfFrame();
			ScreenshotFile screenshotFile = ScreenshotUtil.TakeDebugScreenshot();
			while (!File.Exists(screenshotFile.FilePath))
			{
				yield return null;
			}
			_isTakingScreenshot = false;
			_gamePanel.gameObject.SetActive(value: true);
		}
	}
}
