using System;
using UnityEngine;

namespace Isto.Core.UI.ButtonStyles;

[Serializable]
[CreateAssetMenu(fileName = "Vector1StyleValue", menuName = "Scriptables/Core Button/Vector 1 Style Value")]
public class Vector1StyleValue : Vector1Style
{
	public Vector1StateDataValue stateData = new Vector1StateDataValue();

	public override IStateData GetStateData()
	{
		return stateData;
	}

	private void OnValidate()
	{
		stateData.UpdateAnimLength();
	}
}
