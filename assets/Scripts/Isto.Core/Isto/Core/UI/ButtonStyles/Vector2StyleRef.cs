using System;
using UnityEngine;

namespace Isto.Core.UI.ButtonStyles;

[Serializable]
[CreateAssetMenu(fileName = "Vector2StyleRef", menuName = "Scriptables/Core Button/Vector 2 Style Ref")]
public class Vector2StyleRef : Vector2Style
{
	public Vector2StateDataRef stateData = new Vector2StateDataRef();

	public override IStateData GetStateData()
	{
		return stateData;
	}

	private void OnValidate()
	{
		stateData.UpdateAnimLength();
	}
}
