using System;
using UnityEngine;

namespace Isto.Core.UI;

[Serializable]
public class Vector2Data : IData
{
	public bool animated;

	public AnimationCurve x = AnimationCurve.Constant(0f, 0.1f, 0f);

	public AnimationCurve y = AnimationCurve.Constant(0f, 0.1f, 0f);

	public float instantX;

	public float instantY;

	[SerializeField]
	private float animationTimeLength = -1f;

	public Vector3 InstantValue
	{
		get
		{
			return new Vector3(instantX, instantY);
		}
		set
		{
			instantX = value.x;
			instantY = value.y;
		}
	}

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
		animationTimeLength = Mathf.Max(new float[2]
		{
			x.keys[x.length - 1].time,
			y.keys[y.length - 1].time
		});
	}

	public Vector2 Evaluate(float time)
	{
		if (animated)
		{
			return new Vector2(x.Evaluate(time), y.Evaluate(time));
		}
		return new Vector2(instantX, instantY);
	}
}
