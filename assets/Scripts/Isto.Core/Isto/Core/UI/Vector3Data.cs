using System;
using UnityEngine;

namespace Isto.Core.UI;

[Serializable]
public class Vector3Data : IData
{
	public bool animated;

	public AnimationCurve x = AnimationCurve.Constant(0f, 0.1f, 0f);

	public AnimationCurve y = AnimationCurve.Constant(0f, 0.1f, 0f);

	public AnimationCurve z = AnimationCurve.Constant(0f, 0.1f, 0f);

	public float instantX;

	public float instantY;

	public float instantZ;

	[SerializeField]
	private float animationTimeLength = -1f;

	public Vector3 InstantValue
	{
		get
		{
			return new Vector3(instantX, instantY, instantZ);
		}
		set
		{
			instantX = value.x;
			instantY = value.y;
			instantZ = value.z;
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
		animationTimeLength = Mathf.Max(x.keys[x.length - 1].time, y.keys[y.length - 1].time, z.keys[z.length - 1].time);
	}

	public Vector3 Evaluate(float time)
	{
		if (animated)
		{
			return new Vector3(x.Evaluate(time), y.Evaluate(time), z.Evaluate(time));
		}
		return new Vector3(instantX, instantY, instantZ);
	}
}
