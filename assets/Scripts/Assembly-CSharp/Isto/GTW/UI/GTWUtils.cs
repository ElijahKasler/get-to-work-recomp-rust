using System;
using UnityEngine;

namespace Isto.GTW.UI;

public static class GTWUtils
{
	public static string GetFormattedTimeOrDefaultString(string inputTime, Color baseColor, bool greyOutZeros = true)
	{
		string text = "C3C3C3";
		if (!greyOutZeros)
		{
			text = ColorUtility.ToHtmlStringRGB(baseColor);
		}
		string text2 = ColorUtility.ToHtmlStringRGB(baseColor);
		string text3 = ColorUtility.ToHtmlStringRGB(baseColor);
		if (float.TryParse(inputTime, out var result))
		{
			TimeSpan timeSpan = TimeSpan.FromSeconds(result);
			if ((int)timeSpan.TotalHours == 0)
			{
				text2 = text;
			}
			if ((int)timeSpan.TotalMinutes == 0)
			{
				text3 = text;
			}
			return $"<color=#{text2}>{(int)timeSpan.TotalHours:D2}:</color><color=#{text3}>{timeSpan.Minutes:D2}:</color>{timeSpan.Seconds:D2}.<size=70%>{timeSpan.Milliseconds / 10:D2}</size>";
		}
		return $"<color=#{text}>--</color>";
	}

	public static string GetFormattedTimeOrDefaultString(float inputTime, bool greyOutZeros)
	{
		return GetFormattedTimeOrDefaultString(inputTime.ToString(), Color.black, greyOutZeros);
	}

	public static string GetFormattedTimeOrDefaultString(float inputTime)
	{
		return GetFormattedTimeOrDefaultString(inputTime.ToString(), Color.black);
	}

	public static Texture2D FlipTextureVertically(Texture2D original)
	{
		Texture2D texture2D = new Texture2D(original.width, original.height, original.format, mipChain: false);
		int width = original.width;
		int height = original.height;
		for (int i = 0; i < height; i++)
		{
			Color[] pixels = original.GetPixels(0, i, width, 1);
			texture2D.SetPixels(0, height - i - 1, width, 1, pixels);
		}
		texture2D.Apply();
		return texture2D;
	}

	public static string GetFormattedTimeOrDefaultStringSeconds(string inputTime, Color baseColor, bool greyOutZeros = true)
	{
		string text = "C3C3C3";
		if (!greyOutZeros)
		{
			text = ColorUtility.ToHtmlStringRGB(baseColor);
		}
		string text2 = ColorUtility.ToHtmlStringRGB(baseColor);
		string text3 = ColorUtility.ToHtmlStringRGB(baseColor);
		if (float.TryParse(inputTime, out var result))
		{
			TimeSpan timeSpan = TimeSpan.FromSeconds(result);
			if ((int)timeSpan.TotalHours == 0)
			{
				text2 = text;
			}
			if ((int)timeSpan.TotalMinutes == 0)
			{
				text3 = text;
			}
			return $"<color=#{text2}>{(int)timeSpan.TotalHours:D2}:</color><color=#{text3}>{timeSpan.Minutes:D2}:</color>{timeSpan.Seconds:D2}";
		}
		return $"<color=#{text}>--</color>";
	}
}
