using System.Collections.Generic;
using System.Linq;
using UnityEngine.TextCore.Text;

namespace UnityEngine;

internal class IMGUITextHandle : TextHandle
{
	internal class TextHandleTuple
	{
		public float lastTimeUsed;

		public int hashCode;

		public TextHandleTuple(float lastTimeUsed, int hashCode)
		{
			this.hashCode = hashCode;
			this.lastTimeUsed = lastTimeUsed;
		}
	}

	internal LinkedListNode<TextHandleTuple> tuple;

	private const float sFallbackFontSize = 13f;

	private const float sTimeToFlush = 5f;

	private const float sTimeBetweenCleanupRuns = 30f;

	private const int sNewHandlesBetweenCleanupRuns = 500;

	private static Dictionary<int, IMGUITextHandle> textHandles = new Dictionary<int, IMGUITextHandle>();

	private static LinkedList<TextHandleTuple> textHandlesTuple = new LinkedList<TextHandleTuple>();

	private static float lastCleanupTime;

	private static int newHandlesSinceCleanup = 0;

	internal bool isCachedOnNative = false;

	internal static void EmptyCache()
	{
		GUIStyle.Internal_CleanupAllTextGenerator();
		textHandles.Clear();
		textHandlesTuple.Clear();
	}

	internal static void EmptyManagedCache()
	{
		textHandles.Clear();
		textHandlesTuple.Clear();
	}

	internal static IMGUITextHandle GetTextHandle(GUIStyle style, Rect position, string content, Color32 textColor)
	{
		bool isCached = false;
		ConvertGUIStyleToGenerationSettings(TextHandle.settings, style, textColor, content, position);
		return GetTextHandle(TextHandle.settings, isCalledFromNative: false, ref isCached);
	}

	internal static IMGUITextHandle GetTextHandle(GUIStyle style, Rect position, string content, Color32 textColor, ref bool isCached)
	{
		ConvertGUIStyleToGenerationSettings(TextHandle.settings, style, textColor, content, position);
		return GetTextHandle(TextHandle.settings, isCalledFromNative: true, ref isCached);
	}

	private static bool ShouldCleanup(float currentTime, float lastTime, float cleanupThreshold)
	{
		float num = currentTime - lastTime;
		return num > cleanupThreshold || num < 0f;
	}

	private static void ClearUnusedTextHandles()
	{
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		while (textHandlesTuple.Count > 0)
		{
			TextHandleTuple textHandleTuple = textHandlesTuple.First();
			if (ShouldCleanup(realtimeSinceStartup, textHandleTuple.lastTimeUsed, 5f))
			{
				GUIStyle.Internal_DestroyTextGenerator(textHandleTuple.hashCode);
				if (textHandles.TryGetValue(textHandleTuple.hashCode, out var value))
				{
					value.RemoveTextInfoFromPermanentCache();
				}
				textHandles.Remove(textHandleTuple.hashCode);
				textHandlesTuple.RemoveFirst();
				continue;
			}
			break;
		}
	}

	private static IMGUITextHandle GetTextHandle(UnityEngine.TextCore.Text.TextGenerationSettings settings, bool isCalledFromNative, ref bool isCached)
	{
		isCached = false;
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		if (ShouldCleanup(realtimeSinceStartup, lastCleanupTime, 30f) || newHandlesSinceCleanup > 500)
		{
			ClearUnusedTextHandles();
			lastCleanupTime = realtimeSinceStartup;
			newHandlesSinceCleanup = 0;
		}
		int hashCode = settings.GetHashCode();
		if (textHandles.TryGetValue(hashCode, out var value))
		{
			textHandlesTuple.Remove(value.tuple);
			textHandlesTuple.AddLast(value.tuple);
			isCached = !isCalledFromNative || value.isCachedOnNative;
			if (!value.isCachedOnNative & isCalledFromNative)
			{
				value.UpdateWithHash(hashCode);
				value.UpdatePreferredSize();
				value.isCachedOnNative = true;
			}
			return value;
		}
		IMGUITextHandle iMGUITextHandle = new IMGUITextHandle();
		TextHandleTuple value2 = new TextHandleTuple(realtimeSinceStartup, hashCode);
		LinkedListNode<TextHandleTuple> node = (iMGUITextHandle.tuple = new LinkedListNode<TextHandleTuple>(value2));
		textHandles[hashCode] = iMGUITextHandle;
		iMGUITextHandle.UpdateWithHash(hashCode);
		iMGUITextHandle.UpdatePreferredSize();
		textHandlesTuple.AddLast(node);
		iMGUITextHandle.isCachedOnNative = isCalledFromNative;
		newHandlesSinceCleanup++;
		return iMGUITextHandle;
	}

	internal static float GetLineHeight(GUIStyle style)
	{
		ConvertGUIStyleToGenerationSettings(TextHandle.settings, style, Color.white, "", Rect.zero);
		return TextHandle.GetLineHeightDefault(TextHandle.settings);
	}

	internal Vector2 GetPreferredSize()
	{
		return base.preferredSize;
	}

	internal int GetNumCharactersThatFitWithinWidth(float width)
	{
		AddTextInfoToPermanentCache();
		int num = base.textInfo.lineInfo[0].characterCount;
		float num2 = 0f;
		int i;
		for (i = 0; i < num; i++)
		{
			num2 += base.textInfo.textElementInfo[i].xAdvance - base.textInfo.textElementInfo[i].origin;
			if (num2 > width)
			{
				break;
			}
		}
		return i;
	}

	public Rect[] GetHyperlinkRects(Rect content)
	{
		AddTextInfoToPermanentCache();
		List<Rect> list = new List<Rect>();
		for (int i = 0; i < base.textInfo.linkCount; i++)
		{
			Vector2 vector = GetCursorPositionFromStringIndexUsingLineHeight(base.textInfo.linkInfo[i].linkTextfirstCharacterIndex) + new Vector2(content.x, content.y);
			Vector2 vector2 = GetCursorPositionFromStringIndexUsingLineHeight(base.textInfo.linkInfo[i].linkTextLength + base.textInfo.linkInfo[i].linkTextfirstCharacterIndex) + new Vector2(content.x, content.y);
			float lineHeight = base.textInfo.lineInfo[0].lineHeight;
			if (vector.y == vector2.y)
			{
				list.Add(new Rect(vector.x, vector.y - lineHeight, vector2.x - vector.x, lineHeight));
				continue;
			}
			list.Add(new Rect(vector.x, vector.y - lineHeight, base.textInfo.lineInfo[0].width - vector.x, lineHeight));
			list.Add(new Rect(content.x, vector.y, base.textInfo.lineInfo[0].width, vector2.y - vector.y - lineHeight));
			if (vector2.x != 0f)
			{
				list.Add(new Rect(content.x, vector2.y - lineHeight, vector2.x, lineHeight));
			}
		}
		return list.ToArray();
	}

	private static void ConvertGUIStyleToGenerationSettings(UnityEngine.TextCore.Text.TextGenerationSettings settings, GUIStyle style, Color textColor, string text, Rect rect)
	{
		settings.textSettings = RuntimeTextSettings.defaultTextSettings;
		if (settings.textSettings == null)
		{
			return;
		}
		Font font = style.font;
		if (!font)
		{
			font = GUIStyle.GetDefaultFont();
		}
		if (style.fontSize > 0)
		{
			settings.fontSize = style.fontSize;
		}
		else if ((bool)font)
		{
			settings.fontSize = font.fontSize;
		}
		else
		{
			settings.fontSize = 13f;
		}
		settings.fontStyle = TextGeneratorUtilities.LegacyStyleToNewStyle(style.fontStyle);
		settings.fontAsset = settings.textSettings.GetCachedFontAsset(font);
		if (settings.fontAsset == null)
		{
			return;
		}
		settings.fontAsset.material.SetFloat("_Sharpness", 0.5f);
		settings.screenRect = new Rect(0f, 0f, rect.width, rect.height);
		settings.text = text;
		TextAnchor anchor = style.alignment;
		if (style.imagePosition == ImagePosition.ImageAbove)
		{
			switch (style.alignment)
			{
			case TextAnchor.MiddleRight:
			case TextAnchor.LowerRight:
				anchor = TextAnchor.UpperRight;
				break;
			case TextAnchor.MiddleCenter:
			case TextAnchor.LowerCenter:
				anchor = TextAnchor.UpperCenter;
				break;
			case TextAnchor.MiddleLeft:
			case TextAnchor.LowerLeft:
				anchor = TextAnchor.UpperLeft;
				break;
			}
		}
		settings.textAlignment = TextGeneratorUtilities.LegacyAlignmentToNewAlignment(anchor);
		settings.overflowMode = LegacyClippingToNewOverflow(style.clipping);
		if (rect.width > 0f && style.wordWrap)
		{
			settings.textWrappingMode = TextWrappingMode.PreserveWhitespace;
		}
		else
		{
			settings.textWrappingMode = TextWrappingMode.PreserveWhitespaceNoWrap;
		}
		settings.richText = style.richText;
		settings.parseControlCharacters = false;
		settings.isPlaceholder = false;
		settings.isRightToLeft = false;
		settings.characterSpacing = 0f;
		settings.wordSpacing = 0f;
		settings.paragraphSpacing = 0f;
		settings.color = textColor;
		settings.isIMGUI = true;
		settings.shouldConvertToLinearSpace = QualitySettings.activeColorSpace == ColorSpace.Linear;
	}

	private static TextOverflowMode LegacyClippingToNewOverflow(TextClipping clipping)
	{
		return clipping switch
		{
			TextClipping.Clip => TextOverflowMode.Masking, 
			TextClipping.Ellipsis => TextOverflowMode.Ellipsis, 
			_ => TextOverflowMode.Overflow, 
		};
	}
}
