using System;
using System.Collections.Generic;
using Isto.Core.Items;

namespace Isto.Core.Automation;

public interface IInventory
{
	List<ItemPile> Items { get; }

	int PileCount { get; }

	int PileSize { get; }

	event EventHandler<ItemEventArgs> InventoryChanged;

	bool AcceptsItem(CoreItem item);

	bool AcceptsItem(ItemPile pile);

	int Add(CoreItem item, int count = 1, bool sendUpdateEvent = true);

	int Add(ItemPile pile);

	int AddAt(ItemPile pile, int index);

	float GetContainerPercentUsed();

	int GetCountAt(int index);

	int GetCountOfItem(CoreItem item);

	int GetCountOfItem(string itemID);

	int GetFirstIndexOfItem(CoreItem item);

	int GetHalfCountAt(int index);

	ItemPile GetItemAt(int index);

	int GetNumberOfPiles();

	int GetNumOpenSlots();

	int GetSpaceAvailable(CoreItem item);

	int GetTotalNumberOfItems();

	void SetPileCount(int amount);

	bool HasIngredients(CoreItem item);

	bool HasSpaceFor(List<ItemPile> outputs);

	void InitializeList();

	int Remove(CoreItem item, int count = 1, bool sendUpdateEvent = true);

	List<ItemPile> RemoveAll(bool triggerEvent = true);

	List<ItemPile> RemoveAllBut(List<Item> invalidItems, bool triggerEvent = true);

	ItemPile RemoveAt(int index);

	ItemPile RemoveAt(int index, int count);

	ItemPile RemoveHalfAt(int index);

	void SortAlphabetically();
}
