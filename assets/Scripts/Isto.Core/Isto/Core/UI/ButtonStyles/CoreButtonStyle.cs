using UnityEngine;

namespace Isto.Core.UI.ButtonStyles;

public abstract class CoreButtonStyle : ScriptableObject, IStyle
{
	public abstract IStateData GetStateData();
}
