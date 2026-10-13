using UnityEngine;

namespace Isto.Core.UI;

public class ColorDataAlphaOverride : IData, IColorData
{
	public ColorData colorData;

	public float alpha = 1f;

	public float AnimationTimeLength => colorData.AnimationTimeLength;

	public Color Evaluate(float time)
	{
		Color result = colorData.Evaluate(time);
		result.a = alpha;
		return result;
	}
}
