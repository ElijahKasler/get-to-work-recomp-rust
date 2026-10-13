using System;
using I2.Loc;
using Isto.Core.Localization;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Isto.Core.Items;

public abstract class Item : ScriptableObject
{
	public GameObject prefab;

	public AssetReference addressableAsset;

	[Header("-------------- Standard Fields")]
	public string itemID = "NO ID SET " + Guid.NewGuid().ToString();

	public LocalizedString itemNameLoc;

	public LocalizedString flavorTextLoc;

	[Tooltip("When you're hovering over it to pick it up")]
	public LocalizedString interactToolTipTextLoc;

	[Tooltip("If set, only drops one item when dropping from inventory to the ground.  Still drops full pile when moving to other containers.")]
	public bool dropSingle;

	[Header("Icon")]
	public Sprite icon;

	[Header("Build Settings")]
	public bool ignoreInBuild;

	public string itemName => Loc.Get(itemNameLoc);

	public string interactToolTipText => Loc.Get(interactToolTipTextLoc);

	public string flavorText => Loc.Get(flavorTextLoc);

	public virtual string GetToolTip(bool playerCanInteract = true)
	{
		return interactToolTipText;
	}

	public static bool operator ==(Item a, Item b)
	{
		if ((object)a == null && (object)b == null)
		{
			return true;
		}
		if ((object)a == null || (object)b == null)
		{
			return false;
		}
		if (string.IsNullOrEmpty(a.itemID) && string.IsNullOrEmpty(b.itemID))
		{
			return true;
		}
		if (string.IsNullOrEmpty(a.itemID) || string.IsNullOrEmpty(b.itemID))
		{
			return false;
		}
		return a.itemID.Equals(b.itemID);
	}

	public static bool operator !=(Item a, Item b)
	{
		return !(a == b);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object other)
	{
		if (other == null)
		{
			return false;
		}
		if (other is Item item)
		{
			return item.itemID.Equals(itemID);
		}
		return base.Equals(other);
	}
}
