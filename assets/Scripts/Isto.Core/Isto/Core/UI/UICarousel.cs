using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using Isto.Core.Audio;
using Isto.Core.Localization;
using ModestTree;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class UICarousel : MonoBehaviour
{
	[Header("UI Component Hookups")]
	[SerializeField]
	private TextMeshProUGUI _carouselValueLabel;

	[SerializeField]
	private CoreButton _leftButton;

	[SerializeField]
	private CoreButton _rightButton;

	[SerializeField]
	private Transform _carouselTickContainer;

	[Header("Prefabs")]
	[SerializeField]
	private UICarouselTick _carouselTick;

	[SerializeField]
	private int _currentSelection;

	[Header("Carousel List")]
	[Tooltip("A list of Localized Strings that define the default values for the Carousel List via the Editor. NOTE: These can be overridden in the code.")]
	[SerializeField]
	private List<LocalizedString> _defaultValues = new List<LocalizedString>();

	private readonly List<UICarouselTick> _carouselTicks = new List<UICarouselTick>();

	private List<LocExpression> _internalCarouselValues = new List<LocExpression>();

	private LocExpression _currentValueExpression;

	private HorizontalLayoutGroup _horizontalLayoutGroup;

	private UISounds _uiSounds;

	private LocTerm.Factory _localizedStringFactory;

	public List<LocExpression> CarouselValues => _internalCarouselValues;

	public event Action<int> OnSelectionChanged;

	[Inject]
	public void Inject(UISounds uISounds, LocTerm.Factory localizedStringFactory)
	{
		_uiSounds = uISounds;
		_localizedStringFactory = localizedStringFactory;
	}

	private void Awake()
	{
		_horizontalLayoutGroup = _carouselTickContainer.GetComponent<HorizontalLayoutGroup>();
		if (!_defaultValues.IsEmpty())
		{
			_internalCarouselValues = new List<LocExpression>();
			foreach (LocalizedString defaultValue in _defaultValues)
			{
				LocTerm locTerm = _localizedStringFactory.Create(LocTerm.LocalizationType.Localized, defaultValue.mTerm);
				_internalCarouselValues.Add(new SingleTermLocExpression(locTerm));
			}
		}
		StartCoroutine(DisableHorizontalLayout());
	}

	private void OnEnable()
	{
		RegisterEvents();
		UpdateCarouselValue();
	}

	private void OnDisable()
	{
		UnregisterEvents();
	}

	private void RegisterEvents()
	{
		Events.Subscribe("LanguageChanged", LocalizationManager_OnLocalize);
		_leftButton.OnPointerDownEvent += LeftButton_OnPointerDown;
		_rightButton.OnPointerDownEvent += RightButton_OnPointerDown;
	}

	private void UnregisterEvents()
	{
		Events.UnSubscribe("LanguageChanged", LocalizationManager_OnLocalize);
		_leftButton.OnPointerDownEvent -= LeftButton_OnPointerDown;
		_rightButton.OnPointerDownEvent -= RightButton_OnPointerDown;
	}

	private void LocalizationManager_OnLocalize()
	{
		UpdateCarouselValue();
	}

	private void LeftButton_OnPointerDown(BaseEventData baseEventData)
	{
		MoveSelectionLeft();
	}

	private void RightButton_OnPointerDown(BaseEventData baseEventData)
	{
		MoveSelectionRight();
	}

	public void SetCarouselList(List<LocExpression> optionsList, int currentSelection = 0)
	{
		_internalCarouselValues = optionsList;
		SetCarouselSelection(currentSelection, sendEventMessage: false);
	}

	public void SetCarouselSelection(int selectedIndex, bool sendEventMessage = true)
	{
		SetSelectedValueFromCarousel(selectedIndex);
		_currentSelection = selectedIndex;
		if (sendEventMessage)
		{
			OnSelectionChanged?.Invoke(_currentSelection);
		}
		UpdateTickVisuals();
	}

	private void SetSelectedValueFromCarousel(int selectedIndex)
	{
		if (_internalCarouselValues != null && _internalCarouselValues.Count > selectedIndex && selectedIndex >= 0)
		{
			_currentValueExpression = _internalCarouselValues[selectedIndex];
			UpdateCarouselValue();
		}
	}

	private void UpdateCarouselValue()
	{
		_currentValueExpression?.LocalizeInto(_carouselValueLabel);
	}

	public void MoveSelectionLeft()
	{
		int num = _currentSelection - 1;
		if (num < 0)
		{
			num = CarouselValues.Count - 1;
		}
		_uiSounds.PlayButtonClickSound();
		SetCarouselSelection(num);
	}

	public void MoveSelectionRight()
	{
		int num = _currentSelection + 1;
		if (num > CarouselValues.Count - 1)
		{
			num = 0;
		}
		_uiSounds.PlayButtonClickSound();
		SetCarouselSelection(num);
	}

	private IEnumerator DisableHorizontalLayout()
	{
		yield return new WaitForEndOfFrame();
		if ((bool)_horizontalLayoutGroup)
		{
			_horizontalLayoutGroup.enabled = false;
		}
	}

	private void UpdateTickVisuals()
	{
		if (_carouselTicks.Count != CarouselValues.Count)
		{
			if ((bool)_horizontalLayoutGroup)
			{
				_horizontalLayoutGroup.enabled = true;
			}
			foreach (UICarouselTick carouselTick in _carouselTicks)
			{
				UnityEngine.Object.DestroyImmediate(carouselTick.gameObject);
			}
			_carouselTicks.Clear();
			for (int i = 0; i < CarouselValues.Count; i++)
			{
				_carouselTicks.Add(UnityEngine.Object.Instantiate(_carouselTick, _carouselTickContainer));
			}
			if (base.gameObject.activeInHierarchy)
			{
				StartCoroutine(DisableHorizontalLayout());
			}
		}
		for (int j = 0; j < _carouselTicks.Count; j++)
		{
			_carouselTicks[j].SetHighlight(j == _currentSelection);
		}
	}
}
