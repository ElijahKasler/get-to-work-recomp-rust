using System;

namespace Isto.Core.UI;

[Serializable]
public class MaterialStateData : IStateData
{
	public virtual IData GetState(CoreButton.CoreButtonSelectionState state)
	{
		return null;
	}
}
