using I2.Loc;
using TMPro;
using UnityEngine;

namespace Isto.Core.Localization;

public static class Loc
{
	public static string Get(LocalizedString source)
	{
		if ((string)source == null)
		{
			return Constants.LOCALIZATION_KEY_NOT_FOUND;
		}
		return source.ToString();
	}

	public static string GetString(string key)
	{
		return GetTranslation(key);
	}

	public static string GetItemName(CoreItem item)
	{
		return GetTranslation("items/" + item.itemName.ToString());
	}

	public static void SetTMPro(TextMeshProUGUI tmpro, string key)
	{
		SetTMProLocalized(tmpro, GetString(key));
	}

	public static void SetTMPro(TextMeshProUGUI tmpro, LocalizedString source)
	{
		SetTMProLocalized(tmpro, Get(source));
	}

	public static void SetTMProLocalized(TextMeshProUGUI tmpro, string text)
	{
		TMP_FontAsset translatedObjectByTermName = LocalizationManager.GetTranslatedObjectByTermName<TMP_FontAsset>(Constants.MAIN_FONT);
		if (tmpro.font != translatedObjectByTermName)
		{
			tmpro.font = translatedObjectByTermName;
		}
		tmpro.text = text;
	}

	public static void SetTMProLocalized(TextMeshPro tmpro, string text)
	{
		TMP_FontAsset translatedObjectByTermName = LocalizationManager.GetTranslatedObjectByTermName<TMP_FontAsset>(Constants.MAIN_FONT);
		if (tmpro.font != translatedObjectByTermName)
		{
			tmpro.font = translatedObjectByTermName;
		}
		tmpro.text = text;
	}

	public static void SetLocalize(Localize localizer, LocalizedString source)
	{
		localizer.Term = source.mTerm;
		localizer.OnLocalize(Force: true);
	}

	public static void SetTMProFont(TMP_InputField tmpro)
	{
		TMP_FontAsset translatedObjectByTermName = LocalizationManager.GetTranslatedObjectByTermName<TMP_FontAsset>(Constants.MAIN_FONT);
		if (tmpro.textComponent.font != translatedObjectByTermName)
		{
			tmpro.textComponent.font = translatedObjectByTermName;
		}
	}

	public static string GetTimeLocalizedAndFormated(float totalGameTimeSeconds)
	{
		int num = Mathf.FloorToInt(totalGameTimeSeconds / 60f);
		int num2 = (int)totalGameTimeSeconds % 60;
		return $"{GetString(Constants.MINUTES_PREFIX)}{num}{GetString(Constants.MINUTES_SUFFIX)} {GetString(Constants.SECONDS_PREFIX)}{num2}{GetString(Constants.SECONDS_SUFFIX)}";
	}

	public static string GetFileSizeLocalizedAndFormated(long totalBytes)
	{
		long num = ((totalBytes < 0) ? (-totalBytes) : totalBytes);
		string text;
		double num2;
		if (num >= 1152921504606846976L)
		{
			text = "EB";
			num2 = totalBytes >> 50;
		}
		else if (num >= 1125899906842624L)
		{
			text = "PB";
			num2 = totalBytes >> 40;
		}
		else if (num >= 1099511627776L)
		{
			text = "TB";
			num2 = totalBytes >> 30;
		}
		else if (num >= 1073741824)
		{
			text = "GB";
			num2 = totalBytes >> 20;
		}
		else if (num >= 1048576)
		{
			text = "MB";
			num2 = totalBytes >> 10;
		}
		else
		{
			if (num < 1024)
			{
				return totalBytes.ToString("0 B");
			}
			text = "KB";
			num2 = totalBytes;
		}
		return (num2 / 1024.0).ToString("0.### ") + text;
	}

	private static string GetTranslation(string key)
	{
		string text = LocalizationManager.GetTranslation(key);
		if (text == null)
		{
			Debug.LogWarning("Unable to find term using key: " + key);
			text = Constants.LOCALIZATION_KEY_NOT_FOUND;
		}
		return text;
	}
}
