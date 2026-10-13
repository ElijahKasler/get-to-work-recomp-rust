using System.Collections.Generic;
using Isto.Core.Beings;
using Isto.Core.Inputs;
using Isto.Core.Pooling;
using Isto.Core.StateMachine;
using UnityEngine;

namespace Isto.Core.Items;

public class EraserPositionState : ItemPlaceState, IActionOnRecycle
{
	private Eraser _eraser;

	private bool _firstFrame = true;

	public override void Enter(MonoStateMachine controller)
	{
		_firstFrame = true;
		base.Enter(controller);
		_eraser = base.gameObject.GetComponent<Eraser>();
		Run(controller);
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		_itemsAtOurPosition = GetPhysicsItemsAtOurPosition();
		UpdateOverlappedItem();
		InteractableItem interactableItem = FindValidEraseTarget();
		bool flag = interactableItem != null;
		if (flag != _validPosition && _setMaterialState != null)
		{
			if (flag)
			{
				_setMaterialState.RestoreMaterialTint();
			}
			else
			{
				_setMaterialState.SetMaterialTint(_setMaterialState.invalidPlaceTint, _setMaterialState.invalidPlaceEmission);
			}
			_validPosition = flag;
		}
		UserActions dismantleInput = PlayerDismantleState.DismantleInput;
		UserActions cANCELDISMANTLING = UserActions.CANCELDISMANTLING;
		if (_controls.GetButton(cANCELDISMANTLING))
		{
			_playerController.SetDismantleCancelled();
		}
		else if (_controls.GetButton(dismantleInput) || _firstFrame)
		{
			_firstFrame = false;
			if (flag)
			{
				_eraser.EraseTarget = interactableItem;
				Eraser.ReadyObjectForDismantling(_eraser.EraseTarget.gameObject);
				base.gameObject.SetColliderState(enabled: true);
				_controller.ChangeState(nextState);
			}
			else if (!_controls.UsingJoystick() && _existingItemsAtOurPosition.Count > 0)
			{
				for (int i = 0; i < _existingItemsAtOurPosition.Count; i++)
				{
					ItemPlacementController component = _existingItemsAtOurPosition[i].GetComponent<ItemPlacementController>();
					_playerController.DismantleState.TryPartialDismantleRollback(component);
				}
			}
		}
		else
		{
			_playerController.SetDismantleComplete(stopDropping: true);
			_controller.CancelDrop(exitFromPlacement: false);
		}
		return this;
	}

	public override void Exit(MonoStateMachine controller)
	{
		base.Exit(controller);
	}

	private void UpdateOverlappedItem()
	{
		if (OverEraser(_itemsAtOurPosition, out var sameItem))
		{
			if (_existingItemsAtOurPosition.Count > 0)
			{
				UnhideItems(_existingItemsAtOurPosition);
			}
			HideItems(sameItem);
			_existingItemsAtOurPosition = sameItem;
		}
		else
		{
			if (_existingItemsAtOurPosition.Count > 0)
			{
				UnhideItems(_existingItemsAtOurPosition);
			}
			_existingItemsAtOurPosition.Clear();
		}
	}

	private bool OverEraser(Collider[] hits, out List<InteractableItem> sameItem)
	{
		_controller.SetIsNotOverSwappableItem();
		sameItem = new List<InteractableItem>();
		for (int i = 0; i < hits.Length; i++)
		{
			InteractableItem componentInParent = hits[i].GetComponentInParent<InteractableItem>();
			if (componentInParent != null && componentInParent.itemPile.item == _itemComponent.itemPile.item)
			{
				sameItem.Add(componentInParent);
				return true;
			}
		}
		sameItem = null;
		return false;
	}

	private InteractableItem FindValidEraseTarget()
	{
		if (_itemsAtOurPosition.Length != 0)
		{
			if (_itemsAtOurPosition.Length == 1 && _itemsAtOurPosition[0].GetComponentInParent<ItemPlaceState>() == this)
			{
				Debug.LogWarning("Eraser item should never hit itself");
				return null;
			}
			if (_existingItemsAtOurPosition.Count > 0)
			{
				return null;
			}
		}
		if (_itemComponent.itemPile.item as AdvancedItem != null)
		{
			Vector3 center = FindItemCenter(_itemComponent);
			LayerMask invalidLayers = placementConditions.invalidLayers;
			if (!_controls.UsingJoystick())
			{
				invalidLayers.value &= ~Layers.PLAYER_MASK;
			}
			Collider[] array = Physics.OverlapBox(center, _halfExtends * 0.9f, Quaternion.identity, invalidLayers, QueryTriggerInteraction.Collide);
			if (array.Length != 0)
			{
				for (int i = 0; i < array.Length; i++)
				{
					InteractableItem componentInParent = array[i].GetComponentInParent<InteractableItem>();
					if (componentInParent != null && componentInParent.GetValidActions().Contains(PlayerDismantleState.DismantleInput))
					{
						return componentInParent;
					}
				}
				if (array.Length == 1 && array[0].GetComponentInParent<ItemPlaceState>() == this)
				{
					Debug.LogWarning("Eraser item should never hit itself");
					return null;
				}
				return null;
			}
			return null;
		}
		Debug.LogWarning("Eraser positioning hit unexpected flow");
		return null;
	}

	public void OnRecycle()
	{
		if (_eraser != null)
		{
			_eraser.EraseTarget = null;
		}
		base.gameObject.SetColliderState(enabled: false);
		_firstFrame = true;
	}
}
