using System;

namespace Isto.Core.UI;

[Serializable]
public class ColorStateData : IStateData, IAnimatedStateData
{
	public virtual IData GetState(CoreButton.CoreButtonSelectionState state)
	{
		return null;
	}

	public virtual void UpdateAnimLength()
	{
	}
}
