using System;

namespace Isto.Core.UI.ButtonStyles;

[Serializable]
public abstract class Vector3Style : CoreButtonStyle
{
	public override IStateData GetStateData()
	{
		return null;
	}
}
