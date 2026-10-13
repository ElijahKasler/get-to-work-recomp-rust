using System.Collections;
using FMODUnity;
using Isto.Core.Audio;
using Isto.Core.Beings;
using Isto.Core.Inputs;
using Isto.Core.Pooling;
using Isto.Core.StateMachine;
using UnityEngine;
using Zenject;

namespace Isto.Core.Items;

public class EraseCompleteState : MonoState
{
	[EventRef]
	public string eraseSoundRef = "event:/SFX/Atrio SFX_Automation Place-St";

	[Range(0f, 1f)]
	[Tooltip("How far the mouse can go before drag direction gets locked in")]
	public float minDragScreenHeightPercent = 0.05f;

	private bool _blockingPlacementFlow;

	private bool _animationComplete;

	private Vector2 _mouseOrigin;

	private Vector3 _playerOrigin;

	private ItemPlacementController _controller;

	private Eraser _eraser;

	private PlayerItemInteraction _interaction;

	private AutomationPlayerController _playerController;

	private AdvItemDropParameters _dropParameters;

	private IGameSounds _gameSounds;

	private IControls _controls;

	private PooledItemFactory _pooledItemFactory;

	[Inject]
	public void Inject(PlayerItemInteraction playerItemInteraction, AutomationPlayerController playerController, AdvItemDropParameters dropParam, IGameSounds gameSounds, IControls controls, PooledItemFactory pooledItemFactory)
	{
		_interaction = playerItemInteraction;
		_playerController = playerController;
		_dropParameters = dropParam;
		_gameSounds = gameSounds;
		_controls = controls;
		_pooledItemFactory = pooledItemFactory;
	}

	public override void Enter(MonoStateMachine controller)
	{
		StopAllCoroutines();
		_controller = controller as ItemPlacementController;
		_eraser = base.gameObject.GetComponent<Eraser>();
		_controller.RemoveToolTip();
		_blockingPlacementFlow = true;
		_animationComplete = false;
		_mouseOrigin = _controls.GetPointerPosition();
		_playerOrigin = _playerController.transform.position;
		_ = Screen.height;
		_ = minDragScreenHeightPercent;
		bool num = IsDragging();
		bool button = _controls.GetButton(PlayerDismantleState.DismantleInput);
		if (num || !_controller.IsFirstOfFastPlacement || !button)
		{
			_playerController.SetDismantleComplete();
			_blockingPlacementFlow = false;
		}
	}

	public override void Exit(MonoStateMachine controller)
	{
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previous)
	{
		throw new UnityException("No handler for ReturnFromSubState in ItemPlaceCompleteState.  This state should not be pushing into sub states.");
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		if (_blockingPlacementFlow)
		{
			bool num = IsDragging();
			bool button = _controls.GetButton(PlayerDismantleState.DismantleInput);
			if (num || !button)
			{
				_playerController.SetDismantleComplete();
				_blockingPlacementFlow = false;
			}
			else
			{
				UserActions cANCELDISMANTLING = UserActions.CANCELDISMANTLING;
				if (_controls.GetButton(cANCELDISMANTLING))
				{
					_playerController.SetDismantleCancelled();
				}
			}
		}
		if (_animationComplete)
		{
			_controller.ExitSubState();
			_pooledItemFactory.ReturnPooledAdvancedItem(_eraser);
		}
		return this;
	}

	public bool FinishRemoval(bool batched)
	{
		bool result = false;
		if (_playerController.InteractionState.HandlePickupItem(_eraser.EraseTarget))
		{
			StartCoroutine(AnimateRemoval(batched));
			result = true;
		}
		else
		{
			Eraser.UnreadyObjectForDismantling(_eraser.EraseTarget.gameObject);
			_pooledItemFactory.ReturnPooledAdvancedItem(_eraser);
		}
		return result;
	}

	private IEnumerator AnimateRemoval(bool batched)
	{
		if (!batched)
		{
			_gameSounds.PlayOneShot(eraseSoundRef, base.transform.position);
		}
		Object.Instantiate(_dropParameters.dropParticleObject, base.transform.position, Quaternion.identity).transform.localScale = Vector3.one * 0.25f;
		Vector3 endPosition = base.transform.position;
		Vector3 startPosition = endPosition + Vector3.up * _dropParameters.height * 0.5f;
		float timer = 0f;
		while (timer < _dropParameters.dropTime)
		{
			Vector3 position = Vector3.Lerp(endPosition, startPosition, _dropParameters.curve.Evaluate(timer / _dropParameters.dropTime));
			base.transform.position = position;
			timer += Time.deltaTime;
			yield return null;
		}
		base.transform.position = startPosition;
		yield return null;
		_animationComplete = true;
	}

	private bool IsDragging()
	{
		if (_controls.UsingJoystick())
		{
			return (_playerController.transform.position - _playerOrigin).sqrMagnitude > 0.25f;
		}
		float f = (float)Screen.height * minDragScreenHeightPercent;
		return (_controls.GetPointerPosition() - _mouseOrigin).sqrMagnitude > Mathf.Pow(f, 2f);
	}
}
