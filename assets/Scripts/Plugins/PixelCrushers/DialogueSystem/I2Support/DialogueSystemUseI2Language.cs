using I2.Loc;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.I2Support;

[AddComponentMenu("Pixel Crushers/Dialogue System/Third Party/I2 Localization Support/Dialogue System Use I2 Language")]
public class DialogueSystemUseI2Language : MonoBehaviour
{
	[Tooltip("Specifies whether fields in the Dialogue System are named by language code or language name.")]
	public I2LanguageIdentifierType specifyLanguageBy = I2LanguageIdentifierType.LanguageCode;

	[Tooltip("On start, set the Dialogue System's current language to match I2 Localization's current language.")]
	public bool useI2LanguageOnStart = true;

	[Tooltip("")]
	public bool useI2LanguageAtRuntime;

	private void Start()
	{
		UseCurrentI2Language();
	}

	public void UseCurrentI2Language()
	{
		DialogueManager.SetLanguage((specifyLanguageBy == I2LanguageIdentifierType.LanguageCode) ? LocalizationManager.CurrentLanguageCode : LocalizationManager.CurrentLanguage);
	}

	protected void OnConversationLine(Subtitle subtitle)
	{
		if (!useI2LanguageAtRuntime || subtitle == null)
		{
			return;
		}
		DialogueEntry dialogueEntry = subtitle.dialogueEntry;
		string text = "Dialogue System/Conversation/" + dialogueEntry.conversationID + "/Entry/" + dialogueEntry.id;
		if (!string.IsNullOrEmpty(dialogueEntry.DialogueText))
		{
			text += "/Dialogue Text";
		}
		else
		{
			if (string.IsNullOrEmpty(dialogueEntry.MenuText))
			{
				return;
			}
			text += "/Menu Text";
		}
		text = I2Utils.RemoveNonASCII(text, allowCategory: true);
		string termTranslation = LocalizationManager.GetTermTranslation(text, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters: false, null, LocalizationManager.CurrentLanguage);
		if (!string.IsNullOrEmpty(termTranslation) && !string.Equals(termTranslation, "Null"))
		{
			subtitle.formattedText = FormattedText.Parse(termTranslation);
		}
	}

	protected void OnConversationResponseMenu(Response[] responses)
	{
		if (!useI2LanguageAtRuntime || responses == null)
		{
			return;
		}
		foreach (Response response in responses)
		{
			DialogueEntry destinationEntry = response.destinationEntry;
			string text = "Dialogue System/Conversation/" + destinationEntry.conversationID + "/Entry/" + destinationEntry.id;
			if (!string.IsNullOrEmpty(destinationEntry.MenuText))
			{
				text += "/Menu Text";
			}
			else
			{
				if (string.IsNullOrEmpty(destinationEntry.DialogueText))
				{
					continue;
				}
				text += "/Dialogue Text";
			}
			text = I2Utils.RemoveNonASCII(text, allowCategory: true);
			string termTranslation = LocalizationManager.GetTermTranslation(text, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters: false, null, LocalizationManager.CurrentLanguage);
			if (!string.IsNullOrEmpty(termTranslation) && !string.Equals(termTranslation, "Null"))
			{
				response.formattedText = FormattedText.Parse(termTranslation);
			}
		}
	}
}
