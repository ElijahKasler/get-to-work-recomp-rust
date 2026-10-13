using System;
using UnityEngine;

namespace Isto.Core.UI.ButtonStyles;

[Serializable]
[CreateAssetMenu(fileName = "Vector3StyleRef", menuName = "Scriptables/Core Button/Vector 3 Style Ref")]
public class Vector3StyleRef : Vector3Style
{
	public Vector3StateDataRef stateData = new Vector3StateDataRef();

	public override IStateData GetStateData()
	{
		return stateData;
	}

	private void OnValidate()
	{
		stateData.UpdateAnimLength();
	}
}
