using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Isto.Core.UI;

public class UISettingsOptionRemap : UISettingsSelectable, ISubmitHandler, IEventSystemHandler
{
	private enum RemapStyleEnum
	{
		Primary = 0,
		Secondary = 1,
		Locked = 2
	}

	[Header("Settings Hookup")]
	[SerializeField]
	private UIControlRebindingBase _controlRebinding;

	[SerializeField]
	private Image _backgroundImage;

	[Header("Locked Settings")]
	[SerializeField]
	private TextMeshProUGUI _lockedText;

	[SerializeField]
	private ColorDataObject _lockedTextColor;

	[Header("New Settings")]
	[SerializeField]
	private RemapStyleEnum _remapStyleEnum;

	[SerializeField]
	private ColorDataObject _backgroundPrimaryColor;

	[SerializeField]
	private ColorDataObject _backgroundSecondaryColor;

	[SerializeField]
	private ColorDataObject _backgroundLockedColor;

	private static readonly float LOCKED_TEXT_SPACING = 42f;

	private Vector2 _currentLockedLocation = Vector2.zero;

	private RemapStyleEnum _previousRemapStyle;

	protected override void Awake()
	{
		base.Awake();
		UpdateLockedVisuals();
		if (_remapStyleEnum == RemapStyleEnum.Locked)
		{
			_normalColorDataObject = _lockedTextColor;
		}
	}

	private void Update()
	{
		if (_titleText.rectTransform.hasChanged)
		{
			UpdateLockedTextRectTransform();
			_titleText.rectTransform.hasChanged = false;
		}
	}

	public void OnSubmit(BaseEventData eventData)
	{
		RemapSelected();
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			RemapSelected();
		}
	}

	private void UpdateLockedTextRectTransform()
	{
		Rect rect = _titleText.rectTransform.rect;
		Vector2 vector = new Vector2(rect.x + rect.width + LOCKED_TEXT_SPACING, _lockedText.rectTransform.anchoredPosition.y);
		if (vector != _currentLockedLocation)
		{
			_lockedText.rectTransform.anchoredPosition = vector;
			_currentLockedLocation = vector;
		}
	}

	private void UpdateLockedVisuals()
	{
		IData data = ((_remapStyleEnum == RemapStyleEnum.Locked) ? _lockedTextColor.GetData() : _normalColorDataObject.GetData());
		bool active = _remapStyleEnum == RemapStyleEnum.Locked;
		ToggleVisuals(data, active);
	}

	private void ToggleVisuals(IData data, bool active)
	{
		UpdateBackgroundImageColor();
		_backgroundImage.enabled = true;
		ColorData colorData = (ColorData)data;
		_titleText.color = colorData.Evaluate(0f);
		_lockedText.gameObject.SetActive(active);
		base.interactable = !active;
	}

	private void UpdateBackgroundImageColor()
	{
		if (_remapStyleEnum == RemapStyleEnum.Primary)
		{
			_backgroundImage.color = _backgroundPrimaryColor.data.Evaluate(0f);
		}
		else if (_remapStyleEnum == RemapStyleEnum.Secondary)
		{
			_backgroundImage.color = _backgroundSecondaryColor.data.Evaluate(0f);
		}
		else if (_remapStyleEnum == RemapStyleEnum.Locked)
		{
			_backgroundImage.color = _backgroundLockedColor.data.Evaluate(0f);
		}
	}

	private void RemapSelected()
	{
		if (_isSelected && _remapStyleEnum != RemapStyleEnum.Locked)
		{
			_controlRebinding.BindingButtonClicked();
		}
	}
}
