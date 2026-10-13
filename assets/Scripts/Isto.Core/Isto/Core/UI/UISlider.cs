using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Isto.Core.UI;

[RequireComponent(typeof(Slider))]
public class UISlider : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, ISubmitHandler
{
	public enum UISliderColorScheme
	{
		Normal = 0,
		Highlighted = 1,
		Engaged = 2
	}

	public enum UISliderColorSet
	{
		TitleMenu = 0,
		Game = 1
	}

	[SerializeField]
	private Image _handle;

	[SerializeField]
	private Image _handleOutline;

	[SerializeField]
	private Image _fill;

	[SerializeField]
	private Image _background;

	[SerializeField]
	private TextMeshProUGUI _quantityLabel;

	[SerializeField]
	private Slider _slider;

	[SerializeField]
	private bool _setSliderColors;

	[SerializeField]
	private UISliderColorSet _sliderColorSet;

	[SerializeField]
	private bool _toggleHandleOutline;

	public static float backgroundAlphaSliderHandle = 0.15f;

	private bool _engaged;

	private bool _hovered;

	private bool _selected;

	private bool _snapButtonBack;

	private float _timer;

	public Slider Slider => _slider;

	public event Action OnPointerExit;

	public event Action OnPointerUp;

	private void Update()
	{
		if (!_snapButtonBack || !(Time.unscaledTime - _timer > 0.1f))
		{
			return;
		}
		if (!_engaged)
		{
			if (_hovered || _selected)
			{
				SetHighlighted();
			}
			else
			{
				SetNormal();
			}
		}
		_snapButtonBack = false;
	}

	private void OnEnable()
	{
		SetNormal();
		RefreshLabel();
		RegisterEvents();
	}

	private void OnDisable()
	{
		UnregisterEvents();
	}

	private void RegisterEvents()
	{
		_slider.onValueChanged.AddListener(Slider_OnValueChanged);
	}

	private void UnregisterEvents()
	{
		_slider.onValueChanged.RemoveListener(Slider_OnValueChanged);
	}

	public void OnSubmit(BaseEventData eventData)
	{
		SetEngaged();
		_snapButtonBack = true;
		_timer = Time.unscaledTime;
	}

	private void Slider_OnValueChanged(float value)
	{
		_quantityLabel.text = value.ToString();
	}

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		_hovered = true;
		if (!_engaged)
		{
			SetHighlighted();
		}
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		_hovered = false;
		if (!_engaged)
		{
			SetNormal();
		}
	}

	void ISelectHandler.OnSelect(BaseEventData eventData)
	{
		_selected = true;
		if (!_engaged)
		{
			SetHighlighted();
		}
	}

	void IDeselectHandler.OnDeselect(BaseEventData eventData)
	{
		_selected = false;
		if (!_engaged && !_hovered)
		{
			SetNormal();
		}
	}

	void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
	{
		_engaged = true;
		SetEngaged();
	}

	void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
	{
		_engaged = false;
		if (_hovered)
		{
			SetHighlighted();
		}
		else
		{
			SetNormal();
		}
		OnPointerUp?.Invoke();
	}

	public Selectable GetSelectable()
	{
		return Slider;
	}

	private void SetColor(UISliderColorScheme colorScheme)
	{
		switch (colorScheme)
		{
		default:
			SetHandleColor(Constants.ATRIO_LIGHT_GREY_TEXT);
			SetHandleOutlineColor(Constants.ATRIO_LIGHT_GREY_TEXT);
			SetFillColor(Constants.ATRIO_LIGHT_GREY_TEXT);
			SetBackgroundColor(Color.black);
			SetQuantityLabelColor(Constants.ATRIO_LIGHT_GREY_TEXT);
			break;
		case UISliderColorScheme.Highlighted:
			if (_sliderColorSet == UISliderColorSet.TitleMenu)
			{
				SetHandleColor(Constants.ATRIO_TITLESCREEN_YELLOW);
				SetHandleOutlineColor(Constants.ATRIO_TITLESCREEN_YELLOW);
				SetFillColor(Constants.ATRIO_TITLESCREEN_YELLOW);
				SetBackgroundColor(Color.black);
				SetQuantityLabelColor(Constants.ATRIO_TITLESCREEN_YELLOW);
			}
			else
			{
				SetHandleColor(Constants.ATRIO_SELECTED_YELLOW);
				SetHandleOutlineColor(Constants.ATRIO_SELECTED_YELLOW);
				SetFillColor(Constants.ATRIO_SELECTED_YELLOW);
				SetBackgroundColor(Color.black);
				SetQuantityLabelColor(Constants.ATRIO_LIGHT_GREY_TEXT);
			}
			break;
		case UISliderColorScheme.Engaged:
			if (_sliderColorSet == UISliderColorSet.TitleMenu)
			{
				SetHandleColor(Constants.ATRIO_TITLESCREEN_YELLOW);
				SetHandleOutlineColor(Constants.ATRIO_TITLESCREEN_YELLOW.WithAlpha(backgroundAlphaSliderHandle));
				SetFillColor(Constants.ATRIO_TITLESCREEN_YELLOW);
				SetBackgroundColor(Color.black);
				SetQuantityLabelColor(Constants.ATRIO_TITLESCREEN_YELLOW);
			}
			else
			{
				SetHandleColor(Constants.ATRIO_SELECTED_YELLOW);
				SetHandleOutlineColor(Constants.ATRIO_SELECTED_YELLOW.WithAlpha(backgroundAlphaSliderHandle));
				SetFillColor(Constants.ATRIO_SELECTED_YELLOW);
				SetBackgroundColor(Color.black);
				SetQuantityLabelColor(Constants.ATRIO_LIGHT_GREY_TEXT);
			}
			break;
		}
	}

	private void SetHandleColor(Color c)
	{
		if (_handle != null)
		{
			_handle.color = c;
		}
	}

	private void SetHandleOutlineColor(Color c)
	{
		if (_handleOutline != null)
		{
			_handleOutline.color = c;
		}
	}

	private void SetFillColor(Color c)
	{
		if (_fill != null)
		{
			_fill.color = c;
		}
	}

	private void SetBackgroundColor(Color c)
	{
		if (_background != null)
		{
			_background.color = c;
		}
	}

	private void SetQuantityLabelColor(Color c)
	{
		if (_quantityLabel != null)
		{
			_quantityLabel.color = c;
		}
	}

	private void RefreshLabel()
	{
		_quantityLabel.text = Slider.value.ToString();
	}

	public void DecreaseValue()
	{
		Slider.value--;
	}

	public void IncreaseValue()
	{
		Slider.value++;
	}

	public void ChangeHighlightedLabel(TextMeshProUGUI newLabel)
	{
		if (!(_quantityLabel == newLabel))
		{
			if (_quantityLabel != null)
			{
				newLabel.color = _quantityLabel.color;
				_quantityLabel.color = Constants.ATRIO_LIGHT_GREY_TEXT;
			}
			_quantityLabel = newLabel;
		}
	}

	private void SetNormal()
	{
		if (_setSliderColors)
		{
			SetColor(UISliderColorScheme.Normal);
		}
		if (_toggleHandleOutline)
		{
			_handleOutline.enabled = false;
		}
		OnPointerExit?.Invoke();
	}

	private void SetHighlighted()
	{
		if (_setSliderColors)
		{
			SetColor(UISliderColorScheme.Highlighted);
		}
		if (_toggleHandleOutline)
		{
			_handleOutline.enabled = false;
		}
	}

	private void SetEngaged()
	{
		if (_setSliderColors)
		{
			SetColor(UISliderColorScheme.Engaged);
		}
		if (_toggleHandleOutline)
		{
			_handleOutline.enabled = true;
		}
	}

	[ContextMenu("Select this")]
	public void Select()
	{
		Slider.Select();
	}
}
