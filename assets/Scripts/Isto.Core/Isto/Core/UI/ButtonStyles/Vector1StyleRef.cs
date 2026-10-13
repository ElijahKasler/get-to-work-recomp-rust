using System;
using UnityEngine;

namespace Isto.Core.UI.ButtonStyles;

[Serializable]
[CreateAssetMenu(fileName = "Vector1StyleRef", menuName = "Scriptables/Core Button/Vector 1 Style Ref")]
public class Vector1StyleRef : Vector1Style
{
	public Vector1StateDataRef stateData = new Vector1StateDataRef();

	public override IStateData GetStateData()
	{
		return stateData;
	}

	private void OnValidate()
	{
		stateData.UpdateAnimLength();
	}
}
