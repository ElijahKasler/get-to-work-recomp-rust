using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem;

[Serializable]
public class StandardUIDialogueControls : AbstractDialogueUIControls
{
	[Tooltip("Main panel for conversation UI (optional).")]
	public UIPanel mainPanel;

	[Tooltip("Never deactivate Main Panel. Will still play show & hide animations if specified.")]
	public bool dontDeactivateMainPanel;

	public StandardUISubtitlePanel[] subtitlePanels;

	[Tooltip("Default panel for NPC subtitles.")]
	public StandardUISubtitlePanel defaultNPCSubtitlePanel;

	[Tooltip("Default panel for PC subtitles.")]
	public StandardUISubtitlePanel defaultPCSubtitlePanel;

	[Tooltip("Check for subtitle panels that are configured to immediately open when conversation starts. Untick to bypass check.")]
	public bool allowOpenSubtitlePanelsOnStartConversation = true;

	public StandardUIMenuPanel[] menuPanels;

	[Tooltip("Default panel for response menus.")]
	public StandardUIMenuPanel defaultMenuPanel;

	[Tooltip("When showing response menu, use portrait info of player actor assigned to first response.")]
	public bool useFirstResponseForMenuPortrait;

	private StandardUISubtitleControls m_standardSubtitleControls = new StandardUISubtitleControls();

	private StandardUIResponseMenuControls m_standardMenuControls = new StandardUIResponseMenuControls();

	private bool m_initializedAnimator;

	public StandardUISubtitleControls standardSubtitleControls => m_standardSubtitleControls;

	public override AbstractUISubtitleControls npcSubtitleControls => m_standardSubtitleControls;

	public override AbstractUISubtitleControls pcSubtitleControls => m_standardSubtitleControls;

	public StandardUIResponseMenuControls standardMenuControls => m_standardMenuControls;

	public override AbstractUIResponseMenuControls responseMenuControls => m_standardMenuControls;

	public void Initialize()
	{
		m_standardSubtitleControls.Initialize(subtitlePanels, defaultNPCSubtitlePanel, defaultPCSubtitlePanel);
		m_standardMenuControls.Initialize(menuPanels, defaultMenuPanel, useFirstResponseForMenuPortrait);
	}

	public override void SetActive(bool value)
	{
		if (value)
		{
			ShowPanel();
		}
		else
		{
			HidePanel();
		}
	}

	public override void ShowPanel()
	{
		m_initializedAnimator = true;
		if (mainPanel != null)
		{
			mainPanel.Open();
		}
		standardSubtitleControls.ApplyQueuedActorPanelCache();
	}

	private void HidePanel()
	{
		if (!m_initializedAnimator || (mainPanel != null && !mainPanel.gameObject.activeSelf))
		{
			HideImmediate();
			m_initializedAnimator = true;
			return;
		}
		standardSubtitleControls.Close();
		standardMenuControls.Close();
		if (mainPanel != null && !dontDeactivateMainPanel)
		{
			mainPanel.Close();
		}
	}

	public void HideImmediate()
	{
		HideSubtitlePanelsImmediate();
		HideMenuPanelsImmediate();
		if (mainPanel != null && !dontDeactivateMainPanel)
		{
			mainPanel.gameObject.SetActive(value: false);
			mainPanel.panelState = UIPanel.PanelState.Closed;
		}
	}

	private void HideSubtitlePanelsImmediate()
	{
		for (int i = 0; i < subtitlePanels.Length; i++)
		{
			StandardUISubtitlePanel standardUISubtitlePanel = subtitlePanels[i];
			if (standardUISubtitlePanel != null)
			{
				standardUISubtitlePanel.HideImmediate();
			}
		}
	}

	private void HideMenuPanelsImmediate()
	{
		for (int i = 0; i < menuPanels.Length; i++)
		{
			StandardUIMenuPanel standardUIMenuPanel = menuPanels[i];
			if (standardUIMenuPanel != null)
			{
				standardUIMenuPanel.HideImmediate();
			}
		}
	}

	public void OpenSubtitlePanelsOnStart()
	{
		if (allowOpenSubtitlePanelsOnStartConversation)
		{
			standardSubtitleControls.OpenSubtitlePanelsOnStartConversation();
		}
	}
}
