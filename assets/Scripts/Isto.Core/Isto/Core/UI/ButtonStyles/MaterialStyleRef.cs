using System;
using UnityEngine;

namespace Isto.Core.UI.ButtonStyles;

[Serializable]
[CreateAssetMenu(fileName = "MaterialStyleRef", menuName = "Scriptables/Core Button/Material Style Ref")]
public class MaterialStyleRef : MaterialStyle
{
	public MaterialStateDataRef stateData = new MaterialStateDataRef();

	public override IStateData GetStateData()
	{
		return stateData;
	}
}
