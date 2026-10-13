using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelCrushers.DialogueSystem;

[AddComponentMenu("")]
public class StandardDialogueUI : CanvasDialogueUI, IStandardDialogueUI
{
	public StandardUIAlertControls alertUIElements;

	public StandardUIDialogueControls conversationUIElements;

	public StandardUIQTEControls QTEIndicatorElements;

	[Tooltip("Add an EventSystem if one isn't in the scene.")]
	public bool addEventSystemIfNeeded = true;

	private Queue<QueuedUIAlert> m_alertQueue = new Queue<QueuedUIAlert>();

	private StandardUIRoot m_uiRoot = new StandardUIRoot();

	public override AbstractUIRoot uiRootControls => m_uiRoot;

	public override AbstractUIAlertControls alertControls => alertUIElements;

	public override AbstractDialogueUIControls dialogueControls => conversationUIElements;

	public override AbstractUIQTEControls qteControls => QTEIndicatorElements;

	protected Queue<QueuedUIAlert> alertQueue => m_alertQueue;

	public override void Awake()
	{
		base.Awake();
		VerifyAssignments();
		conversationUIElements.Initialize();
		alertUIElements.HideImmediate();
		conversationUIElements.HideImmediate();
		QTEIndicatorElements.HideImmediate();
	}

	private void VerifyAssignments()
	{
		if (addEventSystemIfNeeded)
		{
			UITools.RequireEventSystem();
		}
		if (DialogueDebug.logWarnings)
		{
			if (alertUIElements.alertText.gameObject == null)
			{
				Debug.LogWarning("Dialogue System: No UI text element is assigned to Standard Dialogue UI's Alert UI Elements.", this);
			}
			if (conversationUIElements.subtitlePanels.Length == 0)
			{
				Debug.LogWarning("Dialogue System: No subtitle panels are assigned to Standard Dialogue UI.", this);
			}
			if (conversationUIElements.menuPanels.Length == 0)
			{
				Debug.LogWarning("Dialogue System: No response menu panels are assigned to Standard Dialogue UI.", this);
			}
		}
	}

	public virtual void OnEnable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	public virtual void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (addEventSystemIfNeeded)
		{
			UITools.RequireEventSystem();
		}
	}

	public override void Open()
	{
		base.Open();
		conversationUIElements.OpenSubtitlePanelsOnStart();
	}

	public override void Close()
	{
		base.Close();
		conversationUIElements.standardMenuControls.ClearCache();
	}

	public override void Update()
	{
		base.Update();
		UpdateAlertQueue();
	}

	public override void ShowAlert(string message, float duration)
	{
		if (string.IsNullOrEmpty(message))
		{
			return;
		}
		if (alertUIElements.dontQueueDuplicates)
		{
			if (alertUIElements.isVisible && string.Equals(alertUIElements.alertText.text, message))
			{
				return;
			}
			foreach (QueuedUIAlert item in alertQueue)
			{
				if (string.Equals(message, item.message))
				{
					return;
				}
			}
		}
		if (alertUIElements.allowForceImmediate && message.Contains("[f]"))
		{
			base.ShowAlert(message.Replace("[f]", string.Empty), duration);
		}
		else if (alertUIElements.queueAlerts)
		{
			m_alertQueue.Enqueue(new QueuedUIAlert(message, duration));
		}
		else
		{
			base.ShowAlert(message, duration);
		}
	}

	private void UpdateAlertQueue()
	{
		if (alertUIElements.queueAlerts && m_alertQueue.Count > 0 && !alertUIElements.isVisible && (!alertUIElements.waitForHideAnimation || !alertUIElements.isHiding))
		{
			ShowNextQueuedAlert();
		}
	}

	private void ShowNextQueuedAlert()
	{
		if (m_alertQueue.Count > 0)
		{
			QueuedUIAlert queuedUIAlert = m_alertQueue.Dequeue();
			base.ShowAlert(queuedUIAlert.message, queuedUIAlert.duration);
		}
	}

	public override void ShowSubtitle(Subtitle subtitle)
	{
		conversationUIElements.standardMenuControls.Close();
		conversationUIElements.standardSubtitleControls.ShowSubtitle(subtitle);
	}

	public override void HideSubtitle(Subtitle subtitle)
	{
		conversationUIElements.standardSubtitleControls.HideSubtitle(subtitle);
	}

	public virtual float GetTypewriterSpeed()
	{
		return conversationUIElements.standardSubtitleControls.GetTypewriterSpeed();
	}

	public virtual void SetTypewriterSpeed(float charactersPerSecond)
	{
		conversationUIElements.standardSubtitleControls.SetTypewriterSpeed(charactersPerSecond);
	}

	public virtual void SetActorSubtitlePanelNumber(DialogueActor dialogueActor, SubtitlePanelNumber subtitlePanelNumber)
	{
		conversationUIElements.standardSubtitleControls.SetActorSubtitlePanelNumber(dialogueActor, subtitlePanelNumber);
	}

	public virtual void SetActorMenuPanelNumber(DialogueActor dialogueActor, MenuPanelNumber menuPanelNumber)
	{
		conversationUIElements.standardMenuControls.SetActorMenuPanelNumber(dialogueActor, menuPanelNumber);
	}

	public virtual void OverrideActorPanel(Actor actor, SubtitlePanelNumber subtitlePanelNumber)
	{
		conversationUIElements.standardSubtitleControls.OverrideActorPanel(actor, subtitlePanelNumber);
	}

	public override void ShowResponses(Subtitle subtitle, Response[] responses, float timeout)
	{
		conversationUIElements.standardSubtitleControls.UnfocusAll();
		base.ShowResponses(subtitle, responses, timeout);
	}

	public override void OnClick(object data)
	{
		conversationUIElements.standardMenuControls.MakeButtonsNonclickable();
		base.OnClick(data);
	}

	public virtual void OverrideActorMenuPanel(Transform actorTransform, MenuPanelNumber menuPanelNumber, StandardUIMenuPanel customPanel)
	{
		conversationUIElements.standardMenuControls.OverrideActorMenuPanel(actorTransform, menuPanelNumber, customPanel ?? conversationUIElements.defaultMenuPanel);
	}

	public virtual void OverrideActorMenuPanel(Actor actor, MenuPanelNumber menuPanelNumber, StandardUIMenuPanel customPanel)
	{
		conversationUIElements.standardMenuControls.OverrideActorMenuPanel(actor, menuPanelNumber, customPanel ?? conversationUIElements.defaultMenuPanel);
	}
}
