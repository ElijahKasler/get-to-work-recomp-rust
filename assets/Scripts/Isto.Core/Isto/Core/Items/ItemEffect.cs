using UnityEngine;

namespace Isto.Core.Items;

public abstract class ItemEffect : ScriptableObject
{
	public abstract void UseItem(GameObject consumer);
}
