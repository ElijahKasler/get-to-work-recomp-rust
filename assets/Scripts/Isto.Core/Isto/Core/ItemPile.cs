using System;
using UnityEngine;

namespace Isto.Core;

[Serializable]
public class ItemPile
{
	public CoreItem item;

	public int count;

	[Range(0f, 1f)]
	public float dropPercentage = 1f;

	public ItemPile()
	{
	}

	public ItemPile(CoreItem item, int itemCount)
	{
		this.item = item;
		count = itemCount;
	}

	public ItemPile(ItemPile itemPile)
	{
		item = itemPile.item;
		count = itemPile.count;
	}

	public void Set(ItemPile pile)
	{
		item = pile.item;
		count = pile.count;
	}

	public void Set(CoreItem item, int count)
	{
		this.item = item;
		this.count = count;
	}

	public void Clear()
	{
		item = null;
		count = 0;
	}

	public bool HasItems()
	{
		if (item != null)
		{
			return count > 0;
		}
		return false;
	}

	public override string ToString()
	{
		return $"Item: {item.itemName}, Count: {count}";
	}
}
