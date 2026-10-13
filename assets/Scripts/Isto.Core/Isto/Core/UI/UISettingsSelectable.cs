using System;
using Isto.Core.Audio;
using Isto.Core.Inputs;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public abstract class UISettingsSelectable : Selectable
{
	[Header("UI Component Hookups")]
	[SerializeField]
	protected TextMeshProUGUI _titleText;

	[SerializeField]
	protected GameObject _optionDirtyFlag;

	[Header("Selection Highlighting")]
	[SerializeField]
	protected ColorDataObject _selectedColorDataObject;

	[SerializeField]
	protected ColorDataObject _normalColorDataObject;

	[Header("Enable Hover Sound")]
	[SerializeField]
	private bool _playSoundOnHover = true;

	[Header("Xbox Specific")]
	[SerializeField]
	private bool _removeFromXboxBuild;

	protected bool _isSelected;

	private bool _isDirty;

	private bool _isHorizontalAxisInUse;

	private bool _isPointerOnUI;

	protected Action OnDirectionLeft;

	protected Action OnDirectionRight;

	protected IGameSounds _gameSounds;

	public bool RemoveFromXboxBuild => _removeFromXboxBuild;

	public bool IsDirty => _isDirty;

	[Inject]
	public void Inject(IGameSounds gameSounds)
	{
		_gameSounds = gameSounds;
	}

	public override void OnSelect(BaseEventData eventData)
	{
		base.OnSelect(eventData);
		SetSelection(isSelected: true);
		if (_playSoundOnHover)
		{
			_gameSounds.PlayOneShot(UISoundEnum.BUTTON_HOVER, base.transform.position);
		}
	}

	public override void OnDeselect(BaseEventData eventData)
	{
		if (!_isPointerOnUI || Controls.UsingController)
		{
			base.OnDeselect(eventData);
			SetSelection(isSelected: false);
		}
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);
		Select();
		_isPointerOnUI = true;
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		base.OnPointerExit(eventData);
		_isPointerOnUI = false;
		Deselect();
	}

	private void Deselect()
	{
		if (EventSystem.current.currentSelectedGameObject == base.gameObject)
		{
			EventSystem.current.SetSelectedGameObject(null);
		}
		else if (_isSelected)
		{
			base.OnDeselect(null);
			SetSelection(isSelected: false);
		}
	}

	public void HandleRightInput()
	{
		OnDirectionRight?.Invoke();
	}

	public void HandleLeftInput()
	{
		OnDirectionLeft?.Invoke();
	}

	public void SetDirtyFlag(bool isDirty)
	{
		_isDirty = isDirty;
		_optionDirtyFlag.SetActive(_isDirty);
	}

	public void SetSelection(bool isSelected)
	{
		IData data = (isSelected ? _selectedColorDataObject.GetData() : _normalColorDataObject.GetData());
		_titleText.color = ((ColorData)data).Evaluate(0f);
		_isSelected = isSelected;
	}
}
