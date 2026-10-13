using UnityEngine;

namespace Isto.Core.UI;

public interface IColorData
{
	float AnimationTimeLength { get; }

	Color Evaluate(float time);
}
