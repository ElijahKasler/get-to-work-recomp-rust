using System;
using Isto.Core.Beings;
using Isto.Core.Items;
using Isto.Core.UI;

namespace Isto.Core;

public static class GlobalGameplayEvents
{
	public static event EventHandler<ItemEventArgs> ItemCrafted;

	public static event EventHandler<ItemEventArgs> ItemEquipped;

	public static event EventHandler<ItemEventArgs> ItemAddedToPlayerInventory;

	public static event EventHandler<MenuInteractionEventArgs> MenuInteraction;

	public static void OnItemCrafted(object sender, CoreItem item, ItemContainer container)
	{
		ItemCrafted?.Invoke(sender, new ItemEventArgs(container, item));
	}

	public static void OnItemEquipped(object sender, CoreItem item)
	{
		ItemEquipped?.Invoke(sender, new ItemEventArgs(null, item));
	}

	public static void OnItemAddedToPlayerInventory(object sender, CoreItem item, int count, PlayerInventory playerInventory)
	{
		ItemAddedToPlayerInventory?.Invoke(sender, new ItemEventArgs(playerInventory, item, count));
	}

	public static void OnMenuInteraction(object sender, GameMenusEnum menu, MenuInteractionEventArgs.Action actionType)
	{
		MenuInteraction?.Invoke(sender, new MenuInteractionEventArgs(menu, actionType));
	}
}
