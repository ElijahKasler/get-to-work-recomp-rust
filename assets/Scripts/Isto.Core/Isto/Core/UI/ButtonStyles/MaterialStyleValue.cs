using System;
using UnityEngine;

namespace Isto.Core.UI.ButtonStyles;

[Serializable]
[CreateAssetMenu(fileName = "MaterialStyleValue", menuName = "Scriptables/Core Button/Material Style Value")]
public class MaterialStyleValue : MaterialStyle
{
	public MaterialStateDataValue stateData = new MaterialStateDataValue();

	public override IStateData GetStateData()
	{
		return stateData;
	}
}
