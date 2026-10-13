namespace Isto.Core.Localization;

public interface ILocalizationProvider
{
	string GetLocalizedText(string locKey);

	void SetLanguage(LanguageChanger.LanguageEnum language);

	LanguageChanger.LanguageEnum GetCurrentLanguage();

	string GetCurrentLanguageName();

	string GetCurrentDeviceLanguage();
}
