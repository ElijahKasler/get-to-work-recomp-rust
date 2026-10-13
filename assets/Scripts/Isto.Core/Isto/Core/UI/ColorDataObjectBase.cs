using UnityEngine;

namespace Isto.Core.UI;

public abstract class ColorDataObjectBase : ScriptableObject
{
	public abstract IData GetData();
}
