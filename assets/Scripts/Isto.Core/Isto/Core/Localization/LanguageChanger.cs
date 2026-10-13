using I2.Loc;
using Isto.Core.Enums;
using UnityEngine;

namespace Isto.Core.Localization;

public class LanguageChanger : MonoBehaviour
{
	public class LanguageEnum : StringEnum<LanguageEnum>
	{
		public static readonly LanguageEnum ENGLISH = new LanguageEnum(LANGUAGE_EN);

		public static readonly LanguageEnum FRENCH = new LanguageEnum(LANGUAGE_FR);

		public static readonly LanguageEnum RUSSIAN = new LanguageEnum(LANGUAGE_RU);

		public static readonly LanguageEnum TRADITIONAL_CHINESE = new LanguageEnum(LANGUAGE_TW);

		public static readonly LanguageEnum SIMPLIFIED_CHINESE = new LanguageEnum(LANGUAGE_CN);

		public static readonly LanguageEnum KOREAN = new LanguageEnum(LANGUAGE_KO);

		public static readonly LanguageEnum JAPANESE = new LanguageEnum(LANGUAGE_JA);

		public static readonly LanguageEnum UKRANIAN = new LanguageEnum(LANGUAGE_UK);

		public static readonly LanguageEnum GERMAN = new LanguageEnum(LANGUAGE_DE);

		public static readonly LanguageEnum HUNGARIAN = new LanguageEnum(LANGUAGE_HU);

		public static readonly LanguageEnum TURKISH = new LanguageEnum(LANGUAGE_TR);

		public static readonly LanguageEnum ITALIAN = new LanguageEnum(LANGUAGE_IT);

		public static readonly LanguageEnum SPANISH = new LanguageEnum(LANGUAGE_SP);

		public static readonly LanguageEnum BRAZILIAN_PORTUGUESE = new LanguageEnum(LANGUAGE_PT_BR);

		public LanguageEnum(string name)
			: base(name, name)
		{
		}
	}

	public const string MENU_PATH = "Isto/Localization/";

	public const int P_LANGUAGE_MENU = 111;

	public const int P_LANGUAGECHANGER = 101;

	private const string LANG_CHANGER_SUBMENU_PATH = "Isto/Localization/Language Changer/";

	private static readonly string LANGUAGE_WW = "Wharrgarbl";

	private static readonly string LANGUAGE_EN = "English";

	private static readonly string LANGUAGE_FR = "French";

	private static readonly string LANGUAGE_RU = "Russian";

	private static readonly string LANGUAGE_TW = "Traditional Chinese";

	private static readonly string LANGUAGE_CN = "Simplified Chinese";

	private static readonly string LANGUAGE_KO = "Korean";

	private static readonly string LANGUAGE_JA = "Japanese";

	private static readonly string LANGUAGE_UK = "Ukranian";

	private static readonly string LANGUAGE_DE = "German";

	private static readonly string LANGUAGE_HU = "Hungarian";

	private static readonly string LANGUAGE_TR = "Turkish";

	private static readonly string LANGUAGE_IT = "Italian";

	private static readonly string LANGUAGE_SP = "Spanish";

	private static readonly string LANGUAGE_PT_BR = "Brazilian Portuguese";

	[ContextMenu("SetEnglish")]
	public void SetEnglish()
	{
		SetLanguage(LANGUAGE_EN);
	}

	[ContextMenu("SetFrench")]
	public void SetFrench()
	{
		SetLanguage(LANGUAGE_FR);
	}

	[ContextMenu("SetWharrgarbl")]
	public void SetWharrgarbl()
	{
		SetLanguage(LANGUAGE_WW);
	}

	private static void SetLanguage(string langName)
	{
		Debug.Log("Setting language to " + langName);
		LocalizationManager.CurrentLanguage = langName;
	}

	public static void SetLanguage(LanguageEnum lang)
	{
		SetLanguage(lang.Name);
	}
}
