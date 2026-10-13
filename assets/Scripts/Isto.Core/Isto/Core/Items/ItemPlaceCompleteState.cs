using System.Collections;
using FMODUnity;
using Isto.Core.Audio;
using Isto.Core.Beings;
using Isto.Core.StateMachine;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Isto.Core.Items;

public class ItemPlaceCompleteState : MonoState
{
	public static int PlacementsPending;

	[EventRef]
	public string placementSoundRef = "event:/SFX/Atrio SFX_Automation Place-St";

	[Header("Disable After Placement")]
	[Tooltip("Array of objects to be disabled after placement is complete.  If GameObject it will be set inactive, if monobehavior it will be disabled.")]
	public Object[] objectsToDisablePreDrop;

	[Tooltip("Array of objects to be disabled after placement is complete.  If GameObject it will be set inactive, if monobehavior it will be disabled.")]
	[FormerlySerializedAs("objectsToDisable")]
	public Object[] objectsToDisablePostDrop;

	private ItemPlacementController _controller;

	private PlayerItemInteraction _interaction;

	private PlayerInventory _playerInventory;

	private AutomationPlayerController _playerController;

	private IGameSounds _gameSounds;

	private ItemPlaceState _placementState;

	private InteractableItem _itemComponent;

	private AdvItemDropParameters _dropParameters;

	private bool _animationComplete = true;

	public bool PlaceAnimationComplete => _animationComplete;

	public bool Active { get; private set; }

	[Inject]
	public void Inject(PlayerInventory playerInventory, PlayerItemInteraction playerItemInteraction, AutomationPlayerController playerController, AdvItemDropParameters dropParam, IGameSounds gameSounds)
	{
		_playerInventory = playerInventory;
		_interaction = playerItemInteraction;
		_playerController = playerController;
		_dropParameters = dropParam;
		_gameSounds = gameSounds;
	}

	public override void Enter(MonoStateMachine controller)
	{
		Active = true;
		PlacementsPending++;
		_controller = controller as ItemPlacementController;
		_placementState = base.gameObject.GetComponent<ItemPlaceState>();
		_itemComponent = GetComponent<InteractableItem>();
		_interaction.DelayInteraction(_dropParameters.dropTime);
		_playerInventory.Remove(_controller.CurrentItem.item);
		StartCoroutine(AnimateDrop());
		_playerController.SetDropComplete(_controller.singlePlacement);
		_animationComplete = false;
	}

	public override void Exit(MonoStateMachine controller)
	{
		_animationComplete = true;
		Active = false;
		PlacementsPending--;
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previous)
	{
		throw new UnityException("No handler for ReturnFromSubState in ItemPlaceCompleteState.  This state should not be pushing into sub states.");
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		if (_animationComplete)
		{
			ActivateComponents();
			DisablePostDropObjects();
			_controller.ExitSubState();
		}
		return this;
	}

	private void ActivateComponents()
	{
		IActivatable[] componentsInChildren = base.gameObject.GetComponentsInChildren<IActivatable>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].Activate();
		}
	}

	private void DisablePreDropObjects()
	{
		for (int i = 0; i < objectsToDisablePreDrop.Length; i++)
		{
			if (objectsToDisablePreDrop[i] is GameObject)
			{
				((GameObject)objectsToDisablePreDrop[i]).SetActive(value: false);
			}
			else if (objectsToDisablePreDrop[i] is MonoBehaviour)
			{
				((MonoBehaviour)objectsToDisablePreDrop[i]).enabled = false;
			}
		}
	}

	private void DisablePostDropObjects()
	{
		for (int i = 0; i < objectsToDisablePostDrop.Length; i++)
		{
			if (objectsToDisablePostDrop[i] is GameObject)
			{
				((GameObject)objectsToDisablePostDrop[i]).SetActive(value: false);
			}
			else if (objectsToDisablePostDrop[i] is MonoBehaviour)
			{
				((MonoBehaviour)objectsToDisablePostDrop[i]).enabled = false;
			}
		}
	}

	private IEnumerator AnimateDrop()
	{
		DisablePreDropObjects();
		_controller.RemoveToolTip();
		LineRenderer lineRend = GetComponent<LineRenderer>();
		if (lineRend != null)
		{
			lineRend.enabled = false;
		}
		GameObject placeHolder = CreatePlaceHolderItem();
		Vector3 endPosition = base.transform.position;
		Vector3 startPosition = endPosition + Vector3.up * _dropParameters.height;
		float timer = 0f;
		while (timer < _dropParameters.dropTime)
		{
			Vector3 position = Vector3.Lerp(startPosition, endPosition, _dropParameters.curve.Evaluate(timer / _dropParameters.dropTime));
			base.transform.position = position;
			timer += Time.deltaTime;
			yield return null;
		}
		base.transform.position = endPosition;
		_gameSounds.PlayOneShot(placementSoundRef, base.transform.position);
		Object.Instantiate(_dropParameters.dropParticleObject, base.transform.position, Quaternion.identity);
		if (lineRend != null)
		{
			lineRend.enabled = true;
		}
		yield return null;
		Object.Destroy(placeHolder);
		_animationComplete = true;
	}

	private GameObject CreatePlaceHolderItem()
	{
		GameObject obj = new GameObject("PlaceHolder")
		{
			layer = Layers.BUILDING
		};
		Vector3 position = base.transform.position + Constants.GRID_CENTERING_OFFSET;
		if ((bool)_placementState)
		{
			position = _placementState.FindItemCenter(_itemComponent);
		}
		obj.transform.position = position;
		SphereCollider sphereCollider = obj.AddComponent<SphereCollider>();
		sphereCollider.isTrigger = true;
		float radius = 0.25f;
		if (_itemComponent != null && _itemComponent.itemPile != null && _itemComponent.itemPile.item is AdvancedItem advancedItem)
		{
			radius = Mathf.Max(advancedItem.depth, advancedItem.width) * 0.4f;
		}
		sphereCollider.radius = radius;
		return obj;
	}
}
