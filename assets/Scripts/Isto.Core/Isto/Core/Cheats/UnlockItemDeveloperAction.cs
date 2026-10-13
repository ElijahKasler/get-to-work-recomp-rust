using System;
using Isto.Core.Beings;
using Isto.Core.Items;
using UnityEngine;
using Zenject;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New Unlock Item Action", menuName = "Scriptables/Dev Mode Actions/Player Unlock Item Action")]
public class UnlockItemDeveloperAction : CheatAction
{
	[Inject]
	private MasterItemList _masterList;

	private PlayerProgress _unlocks;

	public override void Activate(params object[] args)
	{
		string text = args[0].ToString();
		_unlocks = UnityEngine.Object.FindObjectOfType<PlayerProgress>();
		CoreItem coreItem = _masterList.GetItemByID<CoreItem>(text);
		if (coreItem == null)
		{
			coreItem = _masterList.GetItemByName<CoreItem>(text);
		}
		if (coreItem != null)
		{
			_unlocks.UnlockItem(coreItem);
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
		for (int i = 0; i < _masterList.items.Count; i++)
		{
			Item item = _masterList.items[i];
			if (item.itemID.Equals(inputs[0], StringComparison.CurrentCultureIgnoreCase) && i + 1 < _masterList.items.Count)
			{
				output = _masterList.items[i + 1].itemID;
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
