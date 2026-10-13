using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem;

[AddComponentMenu("")]
public class StandardUISubtitlePanel : UIPanel
{
	public GameObject singleMessageprefab;

	public Transform messageParentObj;

	[Tooltip("(Optional) Main panel for subtitle.")]
	public RectTransform panel;

	[Tooltip("(Optional) Image for actor's portrait.")]
	public Image portraitImage;

	[Tooltip("(Optional) Text element for actor's name.")]
	public UITextField portraitName;

	[Tooltip("Subtitle text.")]
	public UITextField subtitleText;

	[Tooltip("Add speaker's name to subtitle text.")]
	public bool addSpeakerName;

	[Tooltip("Format to add speaker name, where {0} is name and {1} is subtitle text.")]
	public string addSpeakerNameFormat = "{0}: {1}";

	[Tooltip("Each subtitle adds to Subtitle Text instead of replacing it.")]
	public bool accumulateText;

	[Tooltip("If panel has a typewriter effect, don't start typing until panel's Show animation has completed.")]
	public bool delayTypewriterUntilOpen;

	[Tooltip("(Optional) Continue button. Only shown if Dialogue Manager's Continue Button mode uses continue button.")]
	public Button continueButton;

	[Tooltip("When the subtitle UI elements should be visible.")]
	public UIVisibility visibility;

	[Tooltip("When focusing panel, set this animator trigger.")]
	public string focusAnimationTrigger = string.Empty;

	[Tooltip("When unfocusing panel, set this animator trigger.")]
	public string unfocusAnimationTrigger = string.Empty;

	[Tooltip("Check Dialogue Actors for portrait animator controllers. Portrait image must have an Animator.")]
	public bool useAnimatedPortraits;

	[Tooltip("If a player actor uses this panel, don't show player portrait name & image; keep previous NPC portrait visible instead.")]
	public bool onlyShowNPCPortraits;

	[Tooltip("Clear text when closing panel, including when hiding using SetDialoguePanel().")]
	public bool clearTextOnClose = true;

	public bool TEST123;

	public UnityEvent onFocus = new UnityEvent();

	public UnityEvent onUnfocus = new UnityEvent();

	[SerializeField]
	[Tooltip("Panel is currently in focused state.")]
	private bool m_hasFocus = true;

	private Subtitle m_currentSubtitle;

	private bool m_haveSavedOriginalColor;

	protected string m_accumulatedText = string.Empty;

	private Animator m_animator;

	private bool m_isDefaultNPCPanel;

	private bool m_isDefaultPCPanel;

	private int m_panelNumber = -1;

	public Transform m_actorOverridingPanel;

	private Coroutine m_focusWhenOpenCoroutine;

	public bool hasFocus
	{
		get
		{
			return m_hasFocus;
		}
		set
		{
			m_hasFocus = value;
		}
	}

	public override bool waitForShowAnimation => true;

	public virtual Subtitle currentSubtitle
	{
		get
		{
			return m_currentSubtitle;
		}
		protected set
		{
			m_currentSubtitle = value;
		}
	}

	public string portraitActorName { get; protected set; }

	protected bool haveSavedOriginalColor
	{
		get
		{
			return m_haveSavedOriginalColor;
		}
		set
		{
			m_haveSavedOriginalColor = value;
		}
	}

	protected Color originalColor { get; set; }

	public string accumulatedText
	{
		get
		{
			return m_accumulatedText;
		}
		set
		{
			m_accumulatedText = value;
		}
	}

	private Animator animator
	{
		get
		{
			if (m_animator == null && portraitImage != null)
			{
				m_animator = portraitImage.GetComponent<Animator>();
			}
			return m_animator;
		}
	}

	public bool isDefaultNPCPanel
	{
		get
		{
			return m_isDefaultNPCPanel;
		}
		set
		{
			m_isDefaultNPCPanel = value;
		}
	}

	public bool isDefaultPCPanel
	{
		get
		{
			return m_isDefaultPCPanel;
		}
		set
		{
			m_isDefaultPCPanel = value;
		}
	}

	public int panelNumber
	{
		get
		{
			return m_panelNumber;
		}
		set
		{
			m_panelNumber = value;
		}
	}

	public Transform actorOverridingPanel
	{
		get
		{
			return m_actorOverridingPanel;
		}
		set
		{
			m_actorOverridingPanel = value;
		}
	}

	public AbstractTypewriterEffect GetTypewriter()
	{
		return TypewriterUtility.GetTypewriter(subtitleText);
	}

	public bool HasTypewriter()
	{
		return GetTypewriter() != null;
	}

	public float GetTypewriterSpeed()
	{
		return TypewriterUtility.GetTypewriterSpeed(subtitleText);
	}

	public void SetTypewriterSpeed(float charactersPerSecond)
	{
		TypewriterUtility.SetTypewriterSpeed(subtitleText, charactersPerSecond);
	}

	public virtual void OpenOnStartConversation(Sprite portraitSprite, string portraitName, DialogueActor dialogueActor)
	{
		Open();
		SetUIElementsActive(value: true);
		Tools.SetGameObjectActive(portraitImage, portraitSprite != null);
		if (portraitImage != null)
		{
			portraitImage.sprite = portraitSprite;
		}
		if (this.portraitName != null)
		{
			this.portraitName.text = portraitName;
		}
		if (subtitleText.text != null)
		{
			subtitleText.text = string.Empty;
		}
		portraitActorName = ((dialogueActor != null) ? dialogueActor.actor : portraitName);
		CheckDialogueActorAnimator(dialogueActor);
	}

	[Obsolete("Use OpenOnStartConversation(Sprite,string,DialogueActor) instead.")]
	public virtual void OpenOnStartConversation(Texture2D portraitTexture, string portraitName, DialogueActor dialogueActor)
	{
		OpenOnStartConversation(UITools.CreateSprite(portraitTexture), portraitName, dialogueActor);
	}

	public virtual void OnConversationEnd(Transform actor)
	{
		ClearText();
	}

	public virtual void ShowSubtitle(Subtitle subtitle)
	{
		SetUIElementsActive(value: true);
		if (!base.isOpen)
		{
			hasFocus = false;
		}
		Open();
		Focus();
		SetContent(subtitle);
		actorOverridingPanel = null;
	}

	public virtual void HideSubtitle(Subtitle subtitle)
	{
		if (base.panelState != PanelState.Closed)
		{
			Unfocus();
		}
		Close();
	}

	public virtual void HideImmediate()
	{
		DeactivateUIElements();
	}

	protected override void OnHidden()
	{
		base.OnHidden();
		DeactivateUIElements();
	}

	public override void Open()
	{
		base.Open();
	}

	public override void Close()
	{
		if (base.isOpen)
		{
			base.Close();
		}
		if (clearTextOnClose)
		{
			ClearText();
		}
		hasFocus = false;
	}

	public virtual void Focus()
	{
		if (base.panelState == PanelState.Opening && base.enabled && base.gameObject.activeInHierarchy)
		{
			if (m_focusWhenOpenCoroutine != null)
			{
				StopCoroutine(m_focusWhenOpenCoroutine);
			}
			m_focusWhenOpenCoroutine = StartCoroutine(FocusWhenOpen());
		}
		else
		{
			FocusNow();
		}
	}

	protected IEnumerator FocusWhenOpen()
	{
		float timeout = Time.realtimeSinceStartup + 5f;
		while (base.panelState != PanelState.Open && Time.realtimeSinceStartup < timeout)
		{
			yield return null;
		}
		m_focusWhenOpenCoroutine = null;
		FocusNow();
	}

	protected virtual void FocusNow()
	{
		base.panelState = PanelState.Open;
		if (!hasFocus)
		{
			if (string.IsNullOrEmpty(focusAnimationTrigger))
			{
				OnFocused();
			}
			else
			{
				base.animatorMonitor.SetTrigger(focusAnimationTrigger, OnFocused);
			}
			onFocus.Invoke();
		}
	}

	private void OnFocused()
	{
		hasFocus = true;
	}

	public virtual void Unfocus()
	{
		if (m_focusWhenOpenCoroutine != null)
		{
			StopCoroutine(m_focusWhenOpenCoroutine);
			m_focusWhenOpenCoroutine = null;
		}
		if (!string.IsNullOrEmpty(focusAnimationTrigger) && base.animatorMonitor.currentTrigger == focusAnimationTrigger)
		{
			base.animatorMonitor.CancelCurrentAnimation();
		}
		else if (!hasFocus)
		{
			return;
		}
		if (base.panelState == PanelState.Opening)
		{
			base.panelState = PanelState.Open;
		}
		hasFocus = false;
		base.animatorMonitor.SetTrigger(unfocusAnimationTrigger, null, wait: false);
		onUnfocus.Invoke();
	}

	protected void ActivateUIElements()
	{
		SetUIElementsActive(value: true);
	}

	protected void DeactivateUIElements()
	{
		SetUIElementsActive(value: false);
		ClearText();
	}

	protected virtual void SetUIElementsActive(bool value)
	{
		Tools.SetGameObjectActive(panel, value);
		Tools.SetGameObjectActive(portraitImage, value && portraitImage != null && portraitImage.sprite != null);
		portraitName.SetActive(value);
		subtitleText.SetActive(value);
		Tools.SetGameObjectActive(continueButton, value: false);
	}

	public virtual void ClearText()
	{
		m_accumulatedText = string.Empty;
		subtitleText.text = string.Empty;
	}

	public virtual void ShowContinueButton()
	{
		Tools.SetGameObjectActive(continueButton, value: true);
		if (InputDeviceManager.autoFocus)
		{
			Select();
		}
		if (continueButton != null && continueButton.onClick.GetPersistentEventCount() == 0)
		{
			continueButton.onClick.RemoveAllListeners();
			StandardUIContinueButtonFastForward component = continueButton.GetComponent<StandardUIContinueButtonFastForward>();
			if (component != null)
			{
				continueButton.onClick.AddListener(component.OnFastForward);
			}
			else
			{
				continueButton.onClick.AddListener(OnContinue);
			}
		}
	}

	public virtual void HideContinueButton()
	{
		Tools.SetGameObjectActive(continueButton, value: false);
	}

	public virtual void FinishSubtitle()
	{
		HideContinueButton();
		AbstractTypewriterEffect typewriter = GetTypewriter();
		if (typewriter != null && typewriter.isPlaying)
		{
			typewriter.Stop();
		}
	}

	public virtual void Select(bool allowStealFocus = true)
	{
		UITools.Select(continueButton, allowStealFocus);
	}

	public virtual void OnContinue()
	{
		AbstractDialogueUI abstractDialogueUI = GetComponentInParent<AbstractDialogueUI>();
		if (abstractDialogueUI == null)
		{
			abstractDialogueUI = DialogueManager.dialogueUI as AbstractDialogueUI;
		}
		if (abstractDialogueUI != null)
		{
			abstractDialogueUI.OnContinueConversation();
		}
	}

	public virtual void SetContent(Subtitle subtitle)
	{
		if (subtitle == null)
		{
			return;
		}
		currentSubtitle = subtitle;
		CheckSubtitleAnimator(subtitle);
		if (!onlyShowNPCPortraits || subtitle.speakerInfo.isNPC)
		{
			if (portraitImage != null)
			{
				Sprite speakerPortrait = subtitle.GetSpeakerPortrait();
				portraitImage.sprite = speakerPortrait;
				Tools.SetGameObjectActive(portraitImage, speakerPortrait != null);
			}
			portraitActorName = subtitle.speakerInfo.nameInDatabase;
			portraitName.text = subtitle.speakerInfo.Name;
			UITools.SendTextChangeMessage(portraitName);
		}
		TypewriterUtility.StopTyping(subtitleText);
		string text = (accumulateText ? m_accumulatedText : string.Empty);
		int fromIndex = (accumulateText ? UITools.StripRPGMakerCodes(Tools.StripTextMeshProTags(Tools.StripRichTextCodes(text))).Length : 0);
		SetFormattedText(subtitleText, text, subtitle.formattedText);
		string text2 = "\n \n C:" + subtitle.speakerInfo.Name.ToUpper() + ">";
		if (accumulateText)
		{
			m_accumulatedText = subtitleText.text + text2;
		}
		if (delayTypewriterUntilOpen && !hasFocus)
		{
			StartCoroutine(StartTypingWhenFocused(subtitleText, subtitleText.text, fromIndex));
		}
		else
		{
			TypewriterUtility.StartTyping(subtitleText, subtitleText.text, fromIndex);
		}
	}

	protected virtual IEnumerator StartTypingWhenFocused(UITextField subtitleText, string text, int fromIndex)
	{
		subtitleText.text = string.Empty;
		float timeout = Time.realtimeSinceStartup + 5f;
		while (!hasFocus && base.panelState != PanelState.Open && Time.realtimeSinceStartup < timeout)
		{
			yield return null;
		}
		subtitleText.text = text;
		TypewriterUtility.StartTyping(subtitleText, text, fromIndex);
	}

	protected virtual void SetFormattedText(UITextField textField, string previousText, FormattedText formattedText)
	{
		textField.text = previousText + UITools.GetUIFormattedText(formattedText);
		UITools.SendTextChangeMessage(textField);
		if (!haveSavedOriginalColor)
		{
			originalColor = textField.color;
			haveSavedOriginalColor = true;
		}
		textField.color = ((formattedText.emphases != null && formattedText.emphases.Length != 0) ? formattedText.emphases[0].color : originalColor);
	}

	public virtual void SetActorPortraitSprite(string actorName, Sprite portraitSprite)
	{
		if (!(portraitImage == null))
		{
			Sprite validPortraitSprite = AbstractDialogueUI.GetValidPortraitSprite(actorName, portraitSprite);
			portraitImage.sprite = validPortraitSprite;
			Tools.SetGameObjectActive(portraitImage, validPortraitSprite != null);
		}
	}

	public void CheckSubtitleAnimator(Subtitle subtitle)
	{
		if (subtitle == null || !useAnimatedPortraits || !(animator != null))
		{
			return;
		}
		DialogueActor dialogueActorComponent = DialogueActor.GetDialogueActorComponent(subtitle.speakerInfo.transform);
		if (dialogueActorComponent != null)
		{
			SubtitlePanelNumber subtitlePanelNumber = dialogueActorComponent.GetSubtitlePanelNumber();
			if (actorOverridingPanel == subtitle.speakerInfo.transform || PanelNumberUtility.GetSubtitlePanelIndex(subtitlePanelNumber) == panelNumber || (subtitlePanelNumber == SubtitlePanelNumber.Default && subtitle.speakerInfo.isNPC && isDefaultNPCPanel) || (subtitlePanelNumber == SubtitlePanelNumber.Default && subtitle.speakerInfo.isPlayer && isDefaultPCPanel) || (subtitlePanelNumber == SubtitlePanelNumber.Custom && dialogueActorComponent.standardDialogueUISettings.customSubtitlePanel == this))
			{
				StartCoroutine(SetAnimatorAtEndOfFrame(dialogueActorComponent.standardDialogueUISettings.portraitAnimatorController));
			}
		}
		else
		{
			StartCoroutine(SetAnimatorAtEndOfFrame(null));
		}
	}

	protected void CheckDialogueActorAnimator(DialogueActor dialogueActor)
	{
		if (dialogueActor != null && useAnimatedPortraits && animator != null && dialogueActor.standardDialogueUISettings.portraitAnimatorController != null)
		{
			StartCoroutine(SetAnimatorAtEndOfFrame(dialogueActor.standardDialogueUISettings.portraitAnimatorController));
		}
	}

	private IEnumerator SetAnimatorAtEndOfFrame(RuntimeAnimatorController animatorController)
	{
		if (animator.runtimeAnimatorController != animatorController)
		{
			animator.runtimeAnimatorController = animatorController;
		}
		yield return new WaitForEndOfFrame();
		if (animator.runtimeAnimatorController != animatorController)
		{
			animator.runtimeAnimatorController = animatorController;
		}
	}
}
