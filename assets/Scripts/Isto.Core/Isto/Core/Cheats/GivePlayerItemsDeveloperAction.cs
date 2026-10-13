using Isto.Core.Beings;
using Isto.Core.Items;
using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New Give Items to Player Action", menuName = "Scriptables/Dev Mode Actions/Give Items to Player Action")]
public class GivePlayerItemsDeveloperAction : CheatAction
{
	public ItemPileList itemsToAdd;

	public override void Activate(params object[] args)
	{
		PlayerInventory playerInventory = Object.FindObjectOfType<PlayerInventory>();
		if (playerInventory != null)
		{
			for (int i = 0; i < itemsToAdd.itemPiles.Count; i++)
			{
				playerInventory.Add(itemsToAdd.itemPiles[i]);
			}
		}
	}

	public override void Deactivate()
	{
	}

	public override void OnUpdate()
	{
	}
}
