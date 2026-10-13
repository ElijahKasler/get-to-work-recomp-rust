using System;
using UnityEngine;

namespace Isto.Core.UI.ButtonStyles;

[Serializable]
[CreateAssetMenu(fileName = "Vector2StyleValue", menuName = "Scriptables/Core Button/Vector 2 Style Value")]
public class Vector2StyleValue : Vector2Style
{
	public Vector2StateDataValue stateData = new Vector2StateDataValue();

	public override IStateData GetStateData()
	{
		return stateData;
	}

	private void OnValidate()
	{
		stateData.UpdateAnimLength();
	}
}
