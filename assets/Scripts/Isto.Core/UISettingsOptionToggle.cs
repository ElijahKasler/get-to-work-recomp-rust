using System;
using Isto.Core.UI;
using UnityEngine;
using UnityEngine.Serialization;

public class UISettingsOptionToggle : UISettingsSelectable
{
	[FormerlySerializedAs("_coreCarousel")]
	[Header("Settings Hookup")]
	[SerializeField]
	protected UICarousel _uiCarousel;

	public event Action<bool> OnValueChanged;

	protected override void OnEnable()
	{
		base.OnEnable();
		RegisterEvents();
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		UnregisterEvents();
	}

	private void RegisterEvents()
	{
		_uiCarousel.OnSelectionChanged += UICarousel_OnSelectionChanged;
		OnDirectionRight = (Action)Delegate.Combine(OnDirectionRight, new Action(UISettingsSelectable_MoveRight));
		OnDirectionLeft = (Action)Delegate.Combine(OnDirectionLeft, new Action(UISettingsSelectable_MoveLeft));
	}

	private void UnregisterEvents()
	{
		_uiCarousel.OnSelectionChanged -= UICarousel_OnSelectionChanged;
		OnDirectionRight = (Action)Delegate.Remove(OnDirectionRight, new Action(UISettingsSelectable_MoveRight));
		OnDirectionLeft = (Action)Delegate.Remove(OnDirectionLeft, new Action(UISettingsSelectable_MoveLeft));
	}

	private void UISettingsSelectable_MoveLeft()
	{
		_uiCarousel.MoveSelectionLeft();
	}

	private void UISettingsSelectable_MoveRight()
	{
		_uiCarousel.MoveSelectionRight();
	}

	private void UICarousel_OnSelectionChanged(int currentSelection)
	{
		if (currentSelection > 1 || currentSelection < 0)
		{
			throw new IndexOutOfRangeException();
		}
		bool obj = currentSelection == 1;
		OnValueChanged?.Invoke(obj);
	}

	public void SetToggleValue(bool isEnabled)
	{
		int selectedIndex = (isEnabled ? 1 : 0);
		_uiCarousel.SetCarouselSelection(selectedIndex);
	}

	public void SetToggleValueNoNotify(bool isEnabled)
	{
		int selectedIndex = (isEnabled ? 1 : 0);
		_uiCarousel.SetCarouselSelection(selectedIndex, sendEventMessage: false);
	}
}
