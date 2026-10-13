using Isto.Core;
using Isto.GTW.Dialogues;
using PixelCrushers.DialogueSystem.I2Support;
using UnityEngine;

public class DialogueSystemUpdateLanguage : MonoBehaviour
{
	private DialogueSystemUseI2Language _i2ToDialogueSystem;

	private void Awake()
	{
		_i2ToDialogueSystem = GetComponent<DialogueSystemUseI2Language>();
		RegisterEvents();
	}

	private void OnDestroy()
	{
		UnregisterEvents();
	}

	private void RegisterEvents()
	{
		Events.Subscribe("LanguageChanged", Events_OnLanguageChanged);
	}

	private void UnregisterEvents()
	{
		Events.UnSubscribe("LanguageChanged", Events_OnLanguageChanged);
	}

	private void Events_OnLanguageChanged()
	{
		UpdateSubtitlesLanguage();
	}

	[ContextMenu("UpdateSubtitlesLanguage")]
	private void UpdateSubtitlesLanguage()
	{
		_i2ToDialogueSystem.UseCurrentI2Language();
		ConversationQueueManager.instance.RestartConversation();
	}
}
