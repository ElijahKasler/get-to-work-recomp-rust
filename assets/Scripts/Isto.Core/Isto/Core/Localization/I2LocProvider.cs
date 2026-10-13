using I2.Loc;
using Isto.Core.Enums;
using UnityEngine;
using Zenject;

namespace Isto.Core.Localization;

public class I2LocProvider : ILocalizationProvider
{
	private LanguageList _supportedLanguages;

	[Inject]
	public void Inject([Inject(Id = "SupportedLanguages")] LanguageList supportedLanguages)
	{
		_supportedLanguages = supportedLanguages;
	}

	public string GetLocalizedText(string locKey)
	{
		string text = LocalizationManager.GetTranslation(locKey);
		if (text == null)
		{
			Debug.LogWarning("Unable to find term using key: " + locKey);
			text = Constants.LOCALIZATION_KEY_NOT_FOUND;
		}
		return text;
	}

	public void SetLanguage(LanguageChanger.LanguageEnum language)
	{
		Debug.Log("Setting language to " + language.Name);
		LocalizationManager.CurrentLanguage = language.Name;
		Events.RaiseEvent("LanguageChanged");
	}

	public LanguageChanger.LanguageEnum GetCurrentLanguage()
	{
		return ExpandableEnum<StringEnum<LanguageChanger.LanguageEnum>, string>.GetFromName(GetCurrentLanguageName()) as LanguageChanger.LanguageEnum;
	}

	public string GetCurrentLanguageName()
	{
		string text = LocalizationManager.CurrentLanguage;
		if (!_supportedLanguages.GetLanguageNames().Contains(text))
		{
			text = GetCurrentDeviceLanguage();
		}
		return text;
	}

	public string GetCurrentDeviceLanguage()
	{
		string text = LocalizationManager.GetCurrentDeviceLanguage();
		if (!_supportedLanguages.GetLanguageNames().Contains(text))
		{
			text = _supportedLanguages.defaultLanguage;
		}
		return text;
	}
}
