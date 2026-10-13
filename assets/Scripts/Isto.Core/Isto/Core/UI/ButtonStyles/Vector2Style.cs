using System;

namespace Isto.Core.UI.ButtonStyles;

[Serializable]
public abstract class Vector2Style : CoreButtonStyle
{
	public override IStateData GetStateData()
	{
		return null;
	}
}
