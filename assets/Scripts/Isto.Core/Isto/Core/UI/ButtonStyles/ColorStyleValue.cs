using System;
using UnityEngine;

namespace Isto.Core.UI.ButtonStyles;

[Serializable]
[CreateAssetMenu(fileName = "ColorStyleValue", menuName = "Scriptables/Core Button/Color Style Value")]
public class ColorStyleValue : ColorStyle
{
	public ColorStateDataValue stateData = new ColorStateDataValue();

	public override IStateData GetStateData()
	{
		return stateData;
	}
}
