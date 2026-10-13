using Isto.Core.Audio;
using Isto.Core.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

[RequireComponent(typeof(TMP_Dropdown))]
public class UIDropdown : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, ISubmitHandler
{
	public enum UIDropdownColorScheme
	{
		Normal = 0,
		Highlighted = 1,
		Engaged = 2,
		Disabled = 3
	}

	[Header("Status")]
	[SerializeField]
	protected bool disabled;

	[Header("UI Hookup")]
	[SerializeField]
	protected bool setLabelColors = true;

	[SerializeField]
	protected bool setDropdownColors = true;

	[SerializeField]
	protected TextMeshProUGUI label;

	[SerializeField]
	protected TextMeshProUGUI setting;

	[SerializeField]
	protected UIDropdownContent contentTemplateRoot;

	[SerializeField]
	protected TextMeshProUGUI itemTemplateText;

	[SerializeField]
	protected Toggle itemTemplateToggle;

	[SerializeField]
	protected UIToggle selectableItemTemplateToggle;

	[SerializeField]
	protected Image arrow;

	[SerializeField]
	protected Image background;

	[SerializeField]
	protected Image outline;

	[Header("Animation")]
	[SerializeField]
	private bool _animate = true;

	[SerializeField]
	private string _selectedTrigger = "selected";

	[SerializeField]
	private string _deselectedTrigger = "deselected";

	[SerializeField]
	private string _pressedFlag = "down";

	public UnityEvent DropdownHighlighted;

	public UnityEvent DropdownOpened;

	public UnityEvent DropdownClosed;

	public UnityEvent DropdownPointerEnter;

	public UnityEvent DropdownPointerExit;

	public UnityEvent DropdownSelected;

	public UnityEvent DropdownDeselected;

	private bool _hovered;

	private bool _engaged;

	private Animator _anim;

	private Navigation _nav;

	private TMP_Dropdown _dropdown;

	private UISounds _uiSounds;

	public TMP_Dropdown Dropdown
	{
		get
		{
			if (_dropdown == null)
			{
				_dropdown = GetComponent<TMP_Dropdown>();
			}
			return _dropdown;
		}
	}

	private bool IsAnimated
	{
		get
		{
			if (_animate)
			{
				return _anim != null;
			}
			return false;
		}
	}

	[Inject]
	public void Inject(UISounds uISounds)
	{
		_uiSounds = uISounds;
	}

	private void Awake()
	{
		_anim = GetComponent<Animator>();
		_nav = Dropdown.navigation;
		if (disabled)
		{
			SetDisabled();
		}
		else
		{
			SetEnabled();
		}
	}

	private void OnEnable()
	{
		Dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
	}

	private void OnDisable()
	{
		Dropdown.onValueChanged.RemoveListener(OnDropdownValueChanged);
	}

	public void SetLabelText(string localizedText)
	{
		if (localizedText != "")
		{
			Loc.SetTMProLocalized(label, localizedText);
		}
	}

	public Selectable GetSelectable()
	{
		return Dropdown;
	}

	[ContextMenu("Select this")]
	public void Select()
	{
		Dropdown.Select();
	}

	public void SetSelected()
	{
		if (!disabled)
		{
			DropdownHighlighted?.Invoke();
			if (IsAnimated)
			{
				_anim.SetTrigger(_selectedTrigger);
			}
			SetColor(UIDropdownColorScheme.Highlighted);
		}
	}

	public void SetDeselected()
	{
		if (IsAnimated)
		{
			_anim.SetTrigger(_deselectedTrigger);
		}
		SetColor(UIDropdownColorScheme.Normal);
	}

	public void SetDisabled()
	{
		SetColor(UIDropdownColorScheme.Disabled);
		disabled = true;
		Dropdown.interactable = false;
	}

	public void SetEnabled()
	{
		SetColor(UIDropdownColorScheme.Normal);
		disabled = false;
		Dropdown.interactable = true;
	}

	private void OnDropdownValueChanged(int value)
	{
		if (Dropdown.IsExpanded)
		{
			DropdownClosed?.Invoke();
		}
	}

	public void OnDropdownContentDisabled(UIDropdownContent disabledContent)
	{
		if (disabledContent.name != contentTemplateRoot.name)
		{
			DropdownClosed?.Invoke();
		}
	}

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		_hovered = true;
		if (!disabled)
		{
			if (!_engaged)
			{
				SetSelected();
			}
			DropdownPointerEnter?.Invoke();
		}
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		_hovered = false;
		if (!disabled)
		{
			if (!_engaged)
			{
				SetDeselected();
			}
			DropdownPointerExit?.Invoke();
		}
	}

	void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
	{
		if (!disabled && IsAnimated)
		{
			_anim.SetBool(_pressedFlag, value: true);
		}
	}

	void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
	{
		if (!disabled)
		{
			OnInteracted();
		}
	}

	void ISelectHandler.OnSelect(BaseEventData eventData)
	{
		if (!disabled)
		{
			if (!_engaged)
			{
				SetSelected();
			}
			DropdownSelected?.Invoke();
		}
	}

	void IDeselectHandler.OnDeselect(BaseEventData eventData)
	{
		if (!disabled)
		{
			if (!_engaged && !_hovered)
			{
				SetDeselected();
			}
			DropdownDeselected?.Invoke();
		}
	}

	void ISubmitHandler.OnSubmit(BaseEventData eventData)
	{
		if (!disabled)
		{
			OnInteracted();
			SetColor(UIDropdownColorScheme.Normal);
		}
	}

	private void OnInteracted()
	{
		if (IsAnimated)
		{
			_anim.SetBool(_pressedFlag, value: false);
		}
		_uiSounds.PlayButtonClickSound();
		if (Dropdown.IsExpanded)
		{
			DropdownClosed?.Invoke();
		}
		else
		{
			DropdownOpened?.Invoke();
		}
	}

	private void SetColor(UIDropdownColorScheme colorScheme)
	{
		switch (colorScheme)
		{
		case UIDropdownColorScheme.Normal:
			SetArrowColor(Constants.ATRIO_LIGHT_GREY_TEXT);
			SetOutlineColor(Constants.ATRIO_TITLESCREEN_YELLOW);
			SetBackgroundColor(Constants.ATRIO_UI_BACKGROUND_GRAY.WithAlpha(1f));
			SetCurrentSettingLabelColor(Constants.ATRIO_LIGHT_GREY_TEXT);
			SetDropdownLabelColor(Constants.ATRIO_LIGHT_GREY_TEXT);
			break;
		case UIDropdownColorScheme.Highlighted:
			SetArrowColor(Constants.ATRIO_UI_BACKGROUND_GRAY);
			SetOutlineColor(Constants.ATRIO_TITLESCREEN_YELLOW);
			SetBackgroundColor(Constants.ATRIO_TITLESCREEN_YELLOW.WithAlpha(1f));
			SetCurrentSettingLabelColor(Constants.ATRIO_UI_BACKGROUND_GRAY);
			SetDropdownLabelColor(Constants.ATRIO_TITLESCREEN_YELLOW);
			break;
		case UIDropdownColorScheme.Engaged:
			SetArrowColor(Constants.ATRIO_UI_BACKGROUND_GRAY);
			SetOutlineColor(Constants.ATRIO_TITLESCREEN_YELLOW);
			SetBackgroundColor(Constants.ATRIO_TITLESCREEN_YELLOW.WithAlpha(1f));
			SetCurrentSettingLabelColor(Constants.ATRIO_UI_BACKGROUND_GRAY);
			SetDropdownLabelColor(Constants.ATRIO_TITLESCREEN_YELLOW);
			break;
		default:
			SetArrowColor(Constants.ATRIO_GREY_TEXT.WithAlpha(Constants.BACKGROUND_ALPHA_PRESSED));
			SetOutlineColor(Constants.ATRIO_DISABLED_GREY1);
			SetBackgroundColor(Constants.ATRIO_DISABLED_GREY2.WithAlpha(Constants.BACKGROUND_ALPHA_NORMAL));
			SetCurrentSettingLabelColor(Constants.ATRIO_GREY_TEXT);
			SetDropdownLabelColor(Constants.ATRIO_GREY_TEXT);
			break;
		}
	}

	private void SetBackgroundColor(Color c)
	{
		if (background != null)
		{
			background.color = c;
		}
	}

	private void SetDropdownLabelColor(Color c)
	{
		if (setLabelColors && label != null)
		{
			label.color = c;
		}
	}

	private void SetCurrentSettingLabelColor(Color c)
	{
		if (setting != null)
		{
			setting.color = c;
		}
	}

	private void SetArrowColor(Color c)
	{
		if (arrow != null)
		{
			arrow.color = c;
		}
	}

	private void SetOutlineColor(Color c)
	{
		if (outline != null)
		{
			outline.color = c;
		}
	}
}
