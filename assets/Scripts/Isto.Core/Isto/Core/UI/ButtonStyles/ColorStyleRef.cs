using System;
using UnityEngine;

namespace Isto.Core.UI.ButtonStyles;

[Serializable]
[CreateAssetMenu(fileName = "ColorStyleRef", menuName = "Scriptables/Core Button/Color Style Ref")]
public class ColorStyleRef : ColorStyle
{
	public ColorStateDataRef stateData = new ColorStateDataRef();

	public override IStateData GetStateData()
	{
		return stateData;
	}
}
