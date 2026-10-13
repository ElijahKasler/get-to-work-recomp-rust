using System;
using System.Collections.Generic;
using FMODUnity;
using I2.Loc;
using PixelCrushers.DialogueSystem.Wrappers;
using UnityEngine;

namespace Code.Scripts.Dialogues.AutoGeneration;

[CreateAssetMenu(fileName = "New MainPathDialogueData", menuName = "Scriptables/Dialogue/Main Path Dialogue Data")]
public class MainPathDialogueData : ScriptableObject
{
	[Serializable]
	public class MainPathConversation
	{
		[Serializable]
		public class VoiceLine
		{
			public LocalizedString _localizedStringKey;

			public string dialogueText;

			public EventReference fmodEvent;

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

		public List<VoiceLine> voiceLines;
	}

	[Space]
	public LanguageList languageList;

	[Space]
	public DialogueDatabase dialogueDatabase;

	[Space]
	public string progressionVariableName = "Progression";

	public List<MainPathConversation> conversations = new List<MainPathConversation>();
}
