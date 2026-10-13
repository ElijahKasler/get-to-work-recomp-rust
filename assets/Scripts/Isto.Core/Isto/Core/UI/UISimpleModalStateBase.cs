using System;
using System.Collections.Generic;
using Isto.Core.Audio;
using Isto.Core.Inputs;
using Isto.Core.StateMachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class UISimpleModalStateBase : MonoState, IStateExitResult
{
	public bool CancelAllowed;

	protected MonoPushdownStateMachine _controller;

	private Action _submitCallback;

	private Action _cancelCallback;

	private float _cooldownAtSateEnter;

	protected List<Selectable> _containedSelectablesCache = new List<Selectable>();

	protected IControls _controls;

	protected UISounds _uiSounds;

	public IStateExitResult.ResultType Result { get; private set; }

	[Inject]
	public void Inject(IControls controls, UISounds uISounds)
	{
		_controls = controls;
		_uiSounds = uISounds;
	}

	private void Awake()
	{
		CacheNavigationElements();
	}

	public override void Enter(MonoStateMachine controller)
	{
		_controller = controller as MonoPushdownStateMachine;
		_cooldownAtSateEnter = Constants.BUTTON_SPAM_DELAY;
		base.gameObject.SetActive(value: true);
	}

	protected virtual void CacheNavigationElements()
	{
		_containedSelectablesCache.Clear();
		_containedSelectablesCache.AddRange(base.gameObject.GetComponentsInChildren<Selectable>(includeInactive: true));
	}

	public override void Exit(MonoStateMachine controller)
	{
		base.gameObject.SetActive(value: false);
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
		base.ReturnFromSubState(controller, previousState);
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		_cooldownAtSateEnter -= Time.unscaledDeltaTime;
		if (_cooldownAtSateEnter > 0f)
		{
			return this;
		}
		EnforceFocus();
		if (CancelAllowed && _controls.GetButtonDown(UserActions.UICANCEL))
		{
			_uiSounds.PlayButtonClickSound();
			CancelClicked();
		}
		return this;
	}

	private void EnforceFocus()
	{
		GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
		bool flag = false;
		if (_containedSelectablesCache.Count == 0 && currentSelectedGameObject != null)
		{
			EventSystem.current.SetSelectedGameObject(null);
		}
		for (int i = 0; i < _containedSelectablesCache.Count; i++)
		{
			if (_containedSelectablesCache[i].gameObject == currentSelectedGameObject)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			SetDefaultSelection();
		}
	}

	public void Show(bool cancelAllowed = false)
	{
		CancelAllowed = cancelAllowed;
	}

	public void Hide()
	{
		Result = IStateExitResult.ResultType.Cancelled;
		Close();
	}

	private void Close()
	{
		if (_controller != null && _controller.GetCurrentState() == this)
		{
			_controller.ExitSubState();
		}
		base.gameObject.SetActive(value: false);
	}

	public void SetCallbacks(Action submit, Action cancel)
	{
		_submitCallback = submit;
		_cancelCallback = cancel;
	}

	public void CancelClicked()
	{
		Result = IStateExitResult.ResultType.Cancelled;
		Close();
		if (_cancelCallback != null)
		{
			_cancelCallback();
		}
	}

	public void SubmitClicked()
	{
		Result = IStateExitResult.ResultType.Submit;
		Close();
		if (_submitCallback != null)
		{
			_submitCallback();
		}
	}

	public virtual void SetDefaultSelection()
	{
	}
}
