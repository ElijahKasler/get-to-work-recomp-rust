using System.Collections;
using System.Collections.Generic;
using Isto.Core.AI;
using Isto.Core.Items;
using UnityEngine;

namespace Isto.Core.StateMachine;

[RequireComponent(typeof(ItemContainer))]
[RequireComponent(typeof(MobStateMachine))]
public class MobPlayerOverrideState : MobState, IInventoryListener
{
	public List<ItemPile> overrideTriggerItems;

	public AIPlayerAttemptOverrideAction overrideStartAction;

	private ItemContainer _inventory;

	private MobStateMachine _mobController;

	protected void Awake()
	{
		_inventory = GetComponent<ItemContainer>();
		_mobController = GetComponent<MobStateMachine>();
	}

	protected void Start()
	{
		for (int i = 0; i < overrideTriggerItems.Count; i++)
		{
			_inventory.validItems.Add(overrideTriggerItems[i].item);
		}
	}

	public override void Enter(MobStateMachine controller)
	{
		base.Enter(controller);
		_currentAction = overrideStartAction;
		_currentAction.StartAction(controller);
	}

	public void InventoryChanged()
	{
		for (int i = 0; i < overrideTriggerItems.Count; i++)
		{
			ItemPile itemPile = overrideTriggerItems[i];
			if (_inventory.GetCountOfItem(itemPile.item) >= itemPile.count)
			{
				_inventory.Remove(itemPile.item, itemPile.count);
				_mobController.ChangeState(_mobController.overrideState);
				break;
			}
		}
	}

	public void InventoryFull()
	{
		Debug.LogWarning("No logic for handling full inventory on MobPlayerOverrideState");
	}

	private IEnumerator ProccessOverride(MobStateMachine controller, float overrideTime)
	{
		controller.SetOverrideSliderActive(active: false);
		float progress = 0f;
		while (progress < overrideTime)
		{
			if (controller.CurrentState.CurrentAction is AIMobStunnedAction)
			{
				progress += Time.deltaTime;
				controller.SetOverrideSliderValue(progress / overrideTime);
				if (progress > overrideTime)
				{
					break;
				}
				yield return null;
				continue;
			}
			controller.SetOverrideSliderActive(active: false);
			break;
		}
	}
}
