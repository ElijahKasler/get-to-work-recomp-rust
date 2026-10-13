using System;
using UnityEngine;

namespace Isto.Core.UI;

[Serializable]
public class ColorData : IData, IColorData
{
	public bool animated;

	public Gradient gradient = new Gradient();

	public float animLength = 0.1f;

	public Color instantColor = Color.white;

	public float AnimationTimeLength
	{
		get
		{
			if (!animated)
			{
				return 0f;
			}
			return animLength;
		}
	}

	public Color Evaluate(float time)
	{
		if (animated)
		{
			time = Mathf.Clamp(time, 0f, animLength);
			float time2 = ((time > 0f) ? (time / animLength) : 0f);
			return gradient.Evaluate(time2);
		}
		return instantColor;
	}
}
