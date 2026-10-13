using System;
using UnityEngine;

namespace Isto.Core.UI.ButtonStyles;

[Serializable]
[CreateAssetMenu(fileName = "Vector3StyleValue", menuName = "Scriptables/Core Button/Vector 3 Style Value")]
public class Vector3StyleValue : Vector3Style
{
	public Vector3StateDataValue stateData = new Vector3StateDataValue();

	public override IStateData GetStateData()
	{
		return stateData;
	}

	private void OnValidate()
	{
		stateData.UpdateAnimLength();
	}
}
