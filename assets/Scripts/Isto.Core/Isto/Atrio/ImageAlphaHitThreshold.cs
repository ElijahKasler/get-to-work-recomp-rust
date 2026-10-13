using UnityEngine;
using UnityEngine.UI;

namespace Isto.Atrio;

[RequireComponent(typeof(Image))]
public class ImageAlphaHitThreshold : MonoBehaviour
{
	[Tooltip("Minimum alpha a pixel must have for click event to register.")]
	[Range(0f, 1f)]
	public float alphaHitTestMinimumThreshold = 1f;

	private void OnValidate()
	{
		UpdateAlphaHitThreshold();
	}

	private void Awake()
	{
		UpdateAlphaHitThreshold();
	}

	private void UpdateAlphaHitThreshold()
	{
		Image component = GetComponent<Image>();
		if (component != null)
		{
			if (alphaHitTestMinimumThreshold > 0f && component.mainTexture != null && !component.mainTexture.isReadable)
			{
				Debug.LogError("To set alphaHitTestMinimumTreshold higher than 0f, the image texture needs to be readable. Check \"Read/Write Enabled\" in the Texture Import Settings. Also make sure to disable sprite packing for this sprite.", base.gameObject);
			}
			component.alphaHitTestMinimumThreshold = alphaHitTestMinimumThreshold;
		}
	}
}
