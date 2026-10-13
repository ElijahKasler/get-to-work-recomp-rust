using System;
using System.Collections.Generic;
using System.Linq;
using Isto.Core.Localization;
using UnityEngine;
using UnityEngine.Serialization;

namespace Isto.Core.UI;

public class UISettingsOptionCarousel : UISettingsSelectable
{
	[FormerlySerializedAs("_coreCarousel")]
	[Header("Settings Hookup")]
	[SerializeField]
	protected UICarousel _uiCarousel;

	public event Action<LocExpression> OnValueChanged;

	protected override void OnEnable()
	{
		RegisterEvents();
	}

	protected override void OnDisable()
	{
		UnregisterEvents();
	}

	private void RegisterEvents()
	{
		_uiCarousel.OnSelectionChanged += UICarousel_OnSelectionChanged;
		OnDirectionRight = (Action)Delegate.Combine(OnDirectionRight, new Action(SettingsOptionCarousel_OnDirectionRightMethod));
		OnDirectionLeft = (Action)Delegate.Combine(OnDirectionLeft, new Action(SettingsOptionCarousel_OnDirectionLeftMethod));
	}

	private void UnregisterEvents()
	{
		_uiCarousel.OnSelectionChanged -= UICarousel_OnSelectionChanged;
		OnDirectionRight = (Action)Delegate.Remove(OnDirectionRight, new Action(SettingsOptionCarousel_OnDirectionRightMethod));
		OnDirectionLeft = (Action)Delegate.Remove(OnDirectionLeft, new Action(SettingsOptionCarousel_OnDirectionLeftMethod));
	}

	private void UICarousel_OnSelectionChanged(int index)
	{
		LocExpression obj = _uiCarousel.CarouselValues[index];
		OnValueChanged?.Invoke(obj);
	}

	private void SettingsOptionCarousel_OnDirectionRightMethod()
	{
		_uiCarousel.MoveSelectionRight();
	}

	private void SettingsOptionCarousel_OnDirectionLeftMethod()
	{
		_uiCarousel.MoveSelectionLeft();
	}

	public void SetCarouselList(List<LocExpression> optionsList, int currentSelection = 0)
	{
		if (base.isActiveAndEnabled)
		{
			_uiCarousel.SetCarouselList(optionsList, currentSelection);
		}
	}

	public void SetCarouselList(List<LocExpression> optionsList, LocExpression currentSelection)
	{
		if (base.isActiveAndEnabled)
		{
			int num = optionsList.IndexOf(currentSelection);
			if (num < 0)
			{
				Debug.LogError("carousel selection " + currentSelection.ToString() + " not found among carousel values on " + base.gameObject.name, base.gameObject);
			}
			_uiCarousel.SetCarouselList(optionsList, num);
		}
	}

	public void SetCarouselList(List<RepositionableLocExpression> optionsListRepositionable, RepositionableLocExpression currentSelectionRepositionable)
	{
		if (base.isActiveAndEnabled)
		{
			List<LocExpression> optionsList = optionsListRepositionable.Cast<LocExpression>().ToList();
			SetCarouselList(optionsList, currentSelectionRepositionable);
		}
	}

	public void SetCarouselList(List<MultiTermLocExpression> optionsListMultiTerm, MultiTermLocExpression currentSelectionMultiTerm)
	{
		if (base.isActiveAndEnabled)
		{
			List<LocExpression> optionsList = optionsListMultiTerm.Cast<LocExpression>().ToList();
			SetCarouselList(optionsList, currentSelectionMultiTerm);
		}
	}

	public void SetCarouselSelectionNoNotify(LocExpression carouselSelection)
	{
		if (base.isActiveAndEnabled)
		{
			int num = _uiCarousel.CarouselValues.IndexOf(carouselSelection);
			if (num < 0)
			{
				Debug.LogError("carousel selection " + carouselSelection.ToString() + " not found among carousel values on " + base.gameObject.name, base.gameObject);
			}
			_uiCarousel.SetCarouselSelection(num, sendEventMessage: false);
		}
	}

	public void SetCarouselSelectionNoNotify(int selectionIndex)
	{
		if (base.isActiveAndEnabled)
		{
			_uiCarousel.SetCarouselSelection(selectionIndex, sendEventMessage: false);
		}
	}
}
