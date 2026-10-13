using System;
using System.IO;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.Core.Inputs;
using Isto.Core.Screenshot;
using Isto.Core.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.BugReportingTool;

public class BugReportPanel : MonoBehaviour
{
	[Header("Input Fields")]
	[SerializeField]
	private TMP_InputField _titleText;

	[SerializeField]
	private TMP_InputField _descriptionText;

	[SerializeField]
	private TMP_InputField _reproStepsText;

	[SerializeField]
	private TMP_InputField _usefulInformationText;

	[SerializeField]
	private TMP_Dropdown _userDropdown;

	[Header("Buttons")]
	[SerializeField]
	private CoreButton _submitButton;

	[SerializeField]
	private CoreButton _clearFieldsButton;

	[SerializeField]
	private CoreButton _closeButton;

	[Header("Output Response")]
	[SerializeField]
	private TMP_Text _outputDebug;

	[SerializeField]
	private Image _previewImage;

	[Header("Isto Developers")]
	[SerializeField]
	private IstoDevelopers _istoDevelopers;

	[Header("Mouse Input Blocker")]
	[SerializeField]
	private Image _mouseInputBlocker;

	public Action<JiraBugDataArgs> OnBugSubmitted;

	private JiraBugPersistenceManager _jiraBugPersistenceManager;

	private ScreenshotFile _currentScreenshotFile;

	private IControls _controls;

	private GameState _gameState;

	[Inject]
	public void Inject(IControls controls, GameState gameState)
	{
		_controls = controls;
		_gameState = gameState;
	}

	private void Awake()
	{
		_jiraBugPersistenceManager = new JiraBugPersistenceManager();
		InputFieldSetup();
		DropdownFieldSetup();
	}

	private void DropdownFieldSetup()
	{
		_userDropdown.AddOptions(_istoDevelopers.IstoFullNames);
	}

	private void OnEnable()
	{
		_reproStepsText.onSelect.AddListener(ReproductionStepsInputField_ValidateText);
		_submitButton.OnSubmitEvent += SubmissionButton_SubmitBug;
		_clearFieldsButton.OnSubmitEvent += ClearFieldsButton_ClearFields;
		_closeButton.onClick.AddListener(CloseButton_ClosePanel);
		_mouseInputBlocker.gameObject.SetActive(value: true);
		_outputDebug.text = "";
		LoadData();
	}

	private void OnDisable()
	{
		_reproStepsText.onSelect.RemoveListener(ReproductionStepsInputField_ValidateText);
		_submitButton.OnSubmitEvent -= SubmissionButton_SubmitBug;
		_clearFieldsButton.OnSubmitEvent -= ClearFieldsButton_ClearFields;
		_closeButton.onClick.RemoveListener(CloseButton_ClosePanel);
		if (IsInputFieldsClean())
		{
			_currentScreenshotFile = null;
		}
		else
		{
			SaveData();
		}
		_controls.SetControlMode(Controls.Mode.Gameplay);
		_mouseInputBlocker.gameObject.SetActive(value: false);
		_outputDebug.text = "";
	}

	private bool IsInputFieldsClean()
	{
		if (string.IsNullOrWhiteSpace(_titleText.text) && string.IsNullOrWhiteSpace(_descriptionText.text))
		{
			return string.IsNullOrWhiteSpace(_usefulInformationText.text);
		}
		return false;
	}

	private void ClearFields()
	{
		_jiraBugPersistenceManager.ClearJiraBugData();
		_titleText.text = "";
		_descriptionText.text = "";
		_reproStepsText.text = "";
		_usefulInformationText.text = "";
		_currentScreenshotFile = ScreenshotUtil.GetLatestDebugScreenshot();
		ScreenshotUtil.ClearDebugScreenshots();
		LoadPreviewImage();
	}

	private void SubmissionButton_SubmitBug()
	{
		OnBugSubmitted?.Invoke(new JiraBugDataArgs(GetJiraDataFromInputFields()));
		ClearFields();
	}

	private void ClearFieldsButton_ClearFields()
	{
		_outputDebug.text = "";
		ClearFields();
	}

	private void CloseButton_ClosePanel()
	{
		base.gameObject.SetActive(value: false);
	}

	private void InputFieldSetup()
	{
		_titleText.onFocusSelectAll = false;
		_descriptionText.onFocusSelectAll = false;
		_reproStepsText.onFocusSelectAll = false;
		_usefulInformationText.onFocusSelectAll = false;
	}

	private void ReproductionStepsInputField_ValidateText(string reproSteps)
	{
		if (string.IsNullOrWhiteSpace(reproSteps.Trim()))
		{
			_reproStepsText.text = GetReproStepsTemplate();
			_reproStepsText.caretPosition = 3;
		}
	}

	private string GetReproStepsTemplate()
	{
		return "1. \n2. \n3. \n";
	}

	private void LoadData()
	{
		JiraBugData jiraBugData = _jiraBugPersistenceManager.LoadJiraBugData();
		LoadJiraDataIntoInputFields(jiraBugData);
	}

	private void SaveData()
	{
		JiraBugData jiraDataFromInputFields = GetJiraDataFromInputFields();
		_jiraBugPersistenceManager.SaveJiraBugData(jiraDataFromInputFields);
	}

	private JiraBugData GetJiraDataFromInputFields()
	{
		return new JiraBugData
		{
			Title = _titleText.text,
			Description = _descriptionText.text,
			ReproductionSteps = _reproStepsText.text,
			UsefulInformation = _usefulInformationText.text,
			ReportedBy = _userDropdown.options[_userDropdown.value].text,
			ImageFilePath = _currentScreenshotFile.FilePath
		};
	}

	private void LoadJiraDataIntoInputFields(JiraBugData jiraBugData)
	{
		_titleText.text = jiraBugData.Title;
		_descriptionText.text = jiraBugData.Description;
		_reproStepsText.text = jiraBugData.ReproductionSteps;
		_usefulInformationText.text = jiraBugData.UsefulInformation;
		_userDropdown.value = _userDropdown.options.FindIndex((TMP_Dropdown.OptionData user) => user.text == jiraBugData.ReportedBy);
		HandlePreviewImage(jiraBugData);
	}

	private void HandlePreviewImage(JiraBugData jiraBugData)
	{
		if (_currentScreenshotFile == null)
		{
			_currentScreenshotFile = ScreenshotUtil.GetLatestDebugScreenshot();
		}
		if (File.Exists(jiraBugData.ImageFilePath))
		{
			_currentScreenshotFile = new ScreenshotFile(jiraBugData.ImageFilePath);
		}
		LoadPreviewImage();
	}

	private void LoadPreviewImage()
	{
		_previewImage.sprite = _currentScreenshotFile.GetScreenshotAsSprite();
	}
}
