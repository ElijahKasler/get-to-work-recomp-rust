using System;
using System.Collections.Generic;
using Isto.Core.Audio;
using Isto.Core.Inputs;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

[ExecuteAlways]
public class CoreButton : Button, IAnyInputButtonDown, IAdditionalInputEventSystemHandler, IEventSystemHandler, IAnyInputButtonUp
{
	public enum CoreButtonSelectionState
	{
		Normal = 0,
		Highlighted = 1,
		Pressed = 2,
		Selected = 3,
		Disabled = 4
	}

	[Tooltip("Time to double click.\nSet higher than zero and leave IsDoubleClickRequired unchecked for double click protection.")]
	public float doubleClickTime = 0.25f;

	[Tooltip("Set to true and set DoubleClickTime to higher than zero to require a double click to press the button.")]
	public bool isDoubleClickRequired;

	[Tooltip("Play sound effect on click. Error sound when inert.")]
	public bool playSound = true;

	[SerializeField]
	private List<CoreButtonTransitionBase> _coreButtonTransitions = new List<CoreButtonTransitionBase>();

	protected float _lastClickTime = -1f;

	protected float _lastDoubleClickStartTime = -1f;

	private CoreButtonSelectionState _previewSelectionState;

	protected UISounds _uiSounds;

	public List<CoreButtonTransitionBase> CoreButtonTransitions => _coreButtonTransitions;

	public CoreButtonSelectionState PreviewSelectionState => _previewSelectionState;

	public bool Active
	{
		get
		{
			if (base.gameObject.activeInHierarchy && base.enabled)
			{
				return base.interactable;
			}
			return false;
		}
	}

	public bool Interactable => base.interactable;

	public bool IsSelected => EventSystem.current.currentSelectedGameObject == base.gameObject;

	private bool CanClick
	{
		get
		{
			if (IsActive() && IsInteractable())
			{
				return !IsSpammed();
			}
			return false;
		}
	}

	public event Action OnSubmitEvent;

	public event Action<BaseEventData> OnSelectEvent;

	public event Action<BaseEventData> OnDeselectEvent;

	public event Action<BaseEventData> OnSubmitPressEvent;

	public event Action<PointerEventData> OnPointerDownEvent;

	public event Action<PointerEventData> OnPointerUpEvent;

	public event Action OnAdditionalInputButtonDown;

	public event Action OnAdditionalInputButtonUp;

	[Inject]
	public void Inject(UISounds uISounds)
	{
		_uiSounds = uISounds;
	}

	protected override void Awake()
	{
		base.Awake();
		base.onClick.AddListener(Button_OnClick);
		UpdateTransitionList();
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		base.onClick.RemoveListener(Button_OnClick);
	}

	public override void OnSelect(BaseEventData eventData)
	{
		base.OnSelect(eventData);
		OnSelectEvent?.Invoke(eventData);
	}

	public override void OnDeselect(BaseEventData eventData)
	{
		base.OnDeselect(eventData);
		OnDeselectEvent?.Invoke(eventData);
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);
		if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject != base.gameObject)
		{
			Select();
		}
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		base.OnPointerExit(eventData);
		if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject == base.gameObject)
		{
			EventSystem.current.SetSelectedGameObject(null);
		}
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (CanClick)
		{
			PlaySound();
			if (TryConfirmClick())
			{
				base.OnPointerClick(eventData);
			}
		}
	}

	public override void OnSubmit(BaseEventData eventData)
	{
		if (CanClick)
		{
			PlaySound();
			if (TryConfirmClick())
			{
				base.OnSubmit(eventData);
				OnSubmitPressEvent?.Invoke(eventData);
			}
		}
	}

	private void Button_OnClick()
	{
		OnSubmitEvent?.Invoke();
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
		base.OnPointerDown(eventData);
		OnPointerDownEvent?.Invoke(eventData);
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
		base.OnPointerUp(eventData);
		OnPointerUpEvent?.Invoke(eventData);
	}

	public void OnAnyInputButtonDown()
	{
		OnAdditionalInputButtonDown?.Invoke();
	}

	public void OnAnyInputButtonUp()
	{
		OnAdditionalInputButtonUp?.Invoke();
	}

	protected void SetDirtyIfNotPlaying()
	{
	}

	public void AddCoreButtonTransition(ICoreButtonTransition transition)
	{
		if (!_coreButtonTransitions.Contains(transition as CoreButtonTransitionBase))
		{
			_coreButtonTransitions.Add(transition as CoreButtonTransitionBase);
		}
		SetDirtyIfNotPlaying();
	}

	public void RemoveCoreButtonTransition(ICoreButtonTransition transition)
	{
		_coreButtonTransitions.Remove(transition as CoreButtonTransitionBase);
		_coreButtonTransitions.RemoveAll((CoreButtonTransitionBase item) => item == null);
		SetDirtyIfNotPlaying();
	}

	[ContextMenu("Update transition list")]
	public void UpdateTransitionListContextMenu()
	{
		UpdateTransitionList();
		Debug.Log(base.gameObject.name + " Transition count: " + _coreButtonTransitions.Count, base.gameObject);
		SetDirtyIfNotPlaying();
	}

	public void UpdateTransitionList()
	{
		_coreButtonTransitions.Clear();
		_coreButtonTransitions.AddRange(GetComponents<CoreButtonTransitionBase>());
	}

	protected void PlaySound()
	{
		if (playSound)
		{
			_uiSounds.PlayButtonClickSound();
		}
	}

	private bool IsSpammed()
	{
		if (Time.unscaledTime < _lastClickTime + doubleClickTime)
		{
			return true;
		}
		return false;
	}

	private bool TryConfirmClick()
	{
		if (IsDoubleClickGated())
		{
			_lastDoubleClickStartTime = Time.unscaledTime;
			return false;
		}
		_lastClickTime = Time.unscaledTime;
		return true;
	}

	private bool IsDoubleClickGated()
	{
		if (!isDoubleClickRequired)
		{
			return false;
		}
		bool result = false;
		if (Time.unscaledTime > _lastDoubleClickStartTime + doubleClickTime)
		{
			result = true;
		}
		return result;
	}

	protected override void DoStateTransition(SelectionState state, bool instant)
	{
		if (Controls.UsingController && state == SelectionState.Highlighted)
		{
			state = SelectionState.Normal;
		}
		CoreButtonSelectionState state2 = (CoreButtonSelectionState)state;
		base.DoStateTransition(state, instant);
		foreach (CoreButtonTransitionBase coreButtonTransition in _coreButtonTransitions)
		{
			((ICoreButtonTransition)coreButtonTransition)?.DoTransition(state2, instant);
		}
	}

	public void DoPreviewStateTransition(CoreButtonSelectionState state)
	{
		_previewSelectionState = state;
		DoStateTransition((SelectionState)state, instant: true);
		SetDirtyIfNotPlaying();
	}

	[ContextMenu("SetSelected")]
	private void SetSelected()
	{
		Select();
	}
}
