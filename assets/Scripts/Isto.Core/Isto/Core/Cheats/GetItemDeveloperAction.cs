using System;
using System.Linq;
using Isto.Core.Beings;
using Isto.Core.Items;
using UnityEngine;
using Zenject;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New Get Item Action", menuName = "Scriptables/Dev Mode Actions/Player Get Item Action")]
public class GetItemDeveloperAction : CheatAction
{
	private MasterItemList _masterList;

	private IOrderedEnumerable<Item> _orderedMasterList;

	private PlayerInventory _inventory;

	[Inject]
	public void Inject(MasterItemList masterList)
	{
		_masterList = masterList;
		_orderedMasterList = _masterList.items.OrderBy((Item item) => item.itemID);
	}

	public override void Activate(params object[] args)
	{
		string text = args[0].ToString().ToLower();
		_inventory = UnityEngine.Object.FindObjectOfType<PlayerInventory>();
		CoreItem coreItem = _masterList.GetItemByID<CoreItem>(text);
		if (coreItem == null)
		{
			coreItem = _masterList.GetItemByName<CoreItem>(text);
		}
		if (coreItem != null)
		{
			if (int.TryParse(args[1].ToString(), out var result))
			{
				_inventory.Add(coreItem, result);
			}
			return;
		}
		throw new UnityException("Item " + text + " not found in master item list");
	}

	public override void Deactivate()
	{
	}

	public override void OnUpdate()
	{
	}

	public override bool TryAutoCompleteParameters(string[] inputs, out string output)
	{
		output = "";
		if (inputs.Length != 1)
		{
			return false;
		}
		for (int i = 0; i < _orderedMasterList.Count(); i++)
		{
			Item item = _orderedMasterList.ElementAt(i);
			if (item.itemID.Equals(inputs[0], StringComparison.CurrentCultureIgnoreCase) && i + 1 < _masterList.items.Count)
			{
				output = _orderedMasterList.ElementAt(i + 1).itemID;
				return true;
			}
			if (item.itemID.StartsWith(inputs[0], StringComparison.CurrentCultureIgnoreCase))
			{
				output = item.itemID;
				return true;
			}
		}
		return false;
	}
}
