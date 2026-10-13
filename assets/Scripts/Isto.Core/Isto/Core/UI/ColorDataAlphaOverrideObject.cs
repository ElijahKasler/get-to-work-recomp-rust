using System;
using UnityEngine;

namespace Isto.Core.UI;

[Serializable]
[CreateAssetMenu(fileName = "ColorDataAlphaOverride", menuName = "Scriptables/Core Button/State Data/Color Data Alpha Override")]
public class ColorDataAlphaOverrideObject : ColorDataObjectBase
{
	public ColorDataObject colorData;

	public float alpha = 1f;

	private ColorDataAlphaOverride _colorAlphaOverride;

	public override IData GetData()
	{
		if (_colorAlphaOverride == null || _colorAlphaOverride.colorData == null)
		{
			_colorAlphaOverride = new ColorDataAlphaOverride
			{
				colorData = colorData.data
			};
		}
		_colorAlphaOverride.alpha = alpha;
		return _colorAlphaOverride;
	}
}
