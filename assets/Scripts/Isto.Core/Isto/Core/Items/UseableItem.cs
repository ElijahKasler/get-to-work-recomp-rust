using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Items;

[CreateAssetMenu(fileName = "New Useable Item", menuName = "Scriptables/Item/UseableItem")]
public class UseableItem : CoreItem
{
	public List<ItemEffect> effects;

	public void UseItem(GameObject consumer)
	{
		foreach (ItemEffect effect in effects)
		{
			effect.UseItem(consumer);
		}
	}
}
