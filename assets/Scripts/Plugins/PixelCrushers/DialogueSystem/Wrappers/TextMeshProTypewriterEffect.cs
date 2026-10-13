using UnityEngine;

namespace PixelCrushers.DialogueSystem.Wrappers;

[HelpURL("https://pixelcrushers.com/dialogue_system/manual2x/html/dialogue_u_is.html#dialogueUITypewriterEffect")]
[AddComponentMenu("")]
public class TextMeshProTypewriterEffect : PixelCrushers.DialogueSystem.TextMeshProTypewriterEffect
{
	private void Reset()
	{
		Debug.LogWarning("Support for " + GetType().Name + " must be enabled using Tools > Pixel Crushers > Dialogue System > Welcome Window.", this);
	}
}
