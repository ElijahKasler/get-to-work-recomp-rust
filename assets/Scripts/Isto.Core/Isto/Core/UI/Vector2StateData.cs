using System;

namespace Isto.Core.UI;

[Serializable]
public class Vector2StateData : IStateData, IAnimatedStateData
{
	public virtual IData GetState(CoreButton.CoreButtonSelectionState state)
	{
		return null;
	}

	public virtual void UpdateAnimLength()
	{
	}
}
