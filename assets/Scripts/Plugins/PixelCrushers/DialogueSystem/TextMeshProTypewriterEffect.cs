using UnityEngine;

namespace PixelCrushers.DialogueSystem;

[AddComponentMenu("")]
public class TextMeshProTypewriterEffect : AbstractTypewriterEffect
{
	public override bool isPlaying => false;

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public override void StartTyping(string text, int fromIndex = 0)
	{
	}

	public override void Stop()
	{
	}

	public override void StopTyping()
	{
	}
}
