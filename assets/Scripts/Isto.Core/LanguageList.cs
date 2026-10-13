using System;
using System.Collections.Generic;
using Isto.Core.Enums;
using Isto.Core.Localization;
using UnityEngine;

[CreateAssetMenu(fileName = "New Language List", menuName = "Scriptables/Languages/LanguageList")]
public class LanguageList : ScriptableObject
{
	[Serializable]
	public class LanguageSelectionDropdownListItem
	{
		[EnumDropdown(typeof(LanguageChanger.LanguageEnum))]
		public string languageName;

		public bool editorOnly;
	}

	[EnumDropdown(typeof(LanguageChanger.LanguageEnum))]
	[Tooltip("This only will be used if user's device language is not supported")]
	public string defaultLanguage;

	public List<LanguageSelectionDropdownListItem> languages;

	public List<LanguageChanger.LanguageEnum> GetLanguages()
	{
		List<LanguageChanger.LanguageEnum> list = new List<LanguageChanger.LanguageEnum>();
		foreach (string languageName in GetLanguageNames())
		{
			LanguageChanger.LanguageEnum item = ExpandableEnum<StringEnum<LanguageChanger.LanguageEnum>, string>.GetFromName(languageName) as LanguageChanger.LanguageEnum;
			list.Add(item);
		}
		return list;
	}

	public List<string> GetLanguageNames()
	{
		List<string> list = new List<string>();
		foreach (LanguageSelectionDropdownListItem language in languages)
		{
			if (!language.editorOnly)
			{
				list.Add(language.languageName);
			}
		}
		return list;
	}
}
