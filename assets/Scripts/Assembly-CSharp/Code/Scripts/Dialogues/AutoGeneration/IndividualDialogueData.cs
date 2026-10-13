using System;
using System.Collections.Generic;
using FMODUnity;
using I2.Loc;
using Isto.Core.Localization;
using Isto.GTW.Enums;
using PixelCrushers.DialogueSystem.Wrappers;
using UnityEngine;

namespace Code.Scripts.Dialogues.AutoGeneration;

[CreateAssetMenu(fileName = "New Individual Dialogue Data", menuName = "Scriptables/Dialogue/Individual Dialogue Data")]
public class IndividualDialogueData : ScriptableObject
{
	[Serializable]
	public class IndividualConversation
	{
		[Serializable]
		public class DialogueStep
		{
			public List<VoiceLine> voiceLines;

			public bool checkForMarkers;
		}

		[Serializable]
		public class VoiceLine
		{
			[SearchableLocalizedString]
			public LocalizedString _localizedStringKey;

			public string dialogueText;

			public EventReference fmodEvent;

			public GTWDialogueSpeakers dialogueSpeaker = GTWDialogueSpeakers.Narrator;

			public string GetFmodEventPath()
			{
				return "";
			}

			public string GetFmodEvent()
			{
				return GetFmodEventPath().Replace("event:/", "");
			}

			public string GetId()
			{
				string[] array = GetFmodEventPath().Split("/");
				if (array.Length == 0)
				{
					return "";
				}
				return array[^1];
			}
		}

		public List<DialogueStep> dialogueSteps;
	}

	[Space]
	public LanguageList languageList;

	[Space]
	public DialogueDatabase dialogueDatabase;

	[Space]
	public List<IndividualConversation> conversations = new List<IndividualConversation>();
}
