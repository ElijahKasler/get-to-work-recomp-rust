using System;
using UnityEngine;

namespace Isto.Core.UI;

[Serializable]
public class Vector1Data : IData
{
	public bool animated;

	public AnimationCurve x = AnimationCurve.Constant(0f, 0.1f, 0f);

	public float instantX;

	[SerializeField]
	private float animationTimeLength = -1f;

	public float AnimationTimeLength
	{
		get
		{
			if (!animated)
			{
				return 0f;
			}
			return animationTimeLength;
		}
	}

	public void UpdateAnimLength()
	{
		animationTimeLength = x.keys[x.length - 1].time;
	}

	public float Evaluate(float time)
	{
		if (animated)
		{
			return x.Evaluate(time);
		}
		return instantX;
	}
}
