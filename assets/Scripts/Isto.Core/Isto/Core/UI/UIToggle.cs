using Isto.Core.Audio;
using Isto.Core.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

[RequireComponent(typeof(Toggle))]
public class UIToggle : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, ISubmitHandler
{
	public enum UIToggleColorScheme
	{
		Normal = 0,
		Highlighted = 1,
		Engaged = 2,
		Disabled = 3
	}

	[Header("UI Hookup")]
	[SerializeField]
	protected Image background;

	[SerializeField]
	protected Image checkmark;

	[SerializeField]
	protected TextMeshProUGUI label;

	[SerializeField]
	protected bool disabled;

	[SerializeField]
	protected bool setToggleColors = true;

	[SerializeField]
	protected bool fixPositionForDropdown;

	[Header("Animation")]
	[SerializeField]
	private bool _animate = true;

	[SerializeField]
	private string _selectedTrigger = "selected";

	[SerializeField]
	private string _deselectedTrigger = "deselected";

	[SerializeField]
	private string _pressedFlag = "down";

	private bool _fixPositionForDropdownApplied;

	private bool _lastChildCorrectionApplied;

	protected Toggle _toggle;

	protected Animator _anim;

	private Navigation _nav;

	protected UISounds _uiSounds;

	public RectTransform RectTransform => base.transform as RectTransform;

	private Toggle Toggle
	{
		get
		{
			if (_toggle == null)
			{
				_toggle = GetComponent<Toggle>();
			}
			return _toggle;
		}
	}

	[Inject]
	public void Inject(UISounds uiSounds)
	{
		_uiSounds = uiSounds;
	}

	private void OnEnable()
	{
		_anim = GetComponent<Animator>();
		_nav = Toggle.navigation;
		if (fixPositionForDropdown && !_fixPositionForDropdownApplied)
		{
			Vector2 anchoredPosition = RectTransform.anchoredPosition;
			anchoredPosition.y -= 12f;
			RectTransform.anchoredPosition = anchoredPosition;
			_fixPositionForDropdownApplied = true;
		}
		if (disabled)
		{
			SetDisabled();
		}
		else
		{
			SetEnabled();
		}
	}

	private void Start()
	{
		if (fixPositionForDropdown && !_lastChildCorrectionApplied && base.transform.GetSiblingIndex() == base.transform.parent.childCount - 1)
		{
			Vector2 anchoredPosition = RectTransform.anchoredPosition;
			anchoredPosition.y -= 6f;
			RectTransform.anchoredPosition = anchoredPosition;
			Vector2 sizeDelta = RectTransform.sizeDelta;
			sizeDelta.y += 10f;
			RectTransform.sizeDelta = sizeDelta;
			Vector3 position = label.transform.position;
			position.y += 4f;
			label.transform.position = position;
			_lastChildCorrectionApplied = true;
		}
	}

	private void OnDisable()
	{
	}

	public void SetLabelText(string localizedText)
	{
		if (localizedText != "")
		{
			Loc.SetTMProLocalized(label, localizedText);
		}
	}

	public virtual void Selected()
	{
		if (!disabled)
		{
			if (_animate && _anim != null)
			{
				_anim.SetTrigger(_selectedTrigger);
			}
			if (setToggleColors)
			{
				SetColor(UIToggleColorScheme.Highlighted);
			}
		}
	}

	public virtual void DeSelected()
	{
		if (_animate && _anim != null)
		{
			_anim.SetTrigger(_deselectedTrigger);
		}
		if (setToggleColors)
		{
			SetColor(UIToggleColorScheme.Normal);
		}
	}

	public virtual void SetDisabled()
	{
		if (setToggleColors)
		{
			SetColor(UIToggleColorScheme.Disabled);
		}
		disabled = true;
		Toggle.interactable = false;
	}

	public virtual void SetEnabled()
	{
		if (setToggleColors)
		{
			SetColor(UIToggleColorScheme.Normal);
		}
		disabled = false;
		Toggle.interactable = true;
	}

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		if (!disabled)
		{
			Selected();
		}
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		if (!disabled)
		{
			DeSelected();
		}
	}

	void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
	{
		if (!disabled && _animate && _anim != null)
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
			Selected();
		}
	}

	void IDeselectHandler.OnDeselect(BaseEventData eventData)
	{
		if (!disabled)
		{
			DeSelected();
		}
	}

	void ISubmitHandler.OnSubmit(BaseEventData eventData)
	{
		if (!disabled)
		{
			OnInteracted();
		}
	}

	private void OnInteracted()
	{
		if (_animate && _anim != null)
		{
			_anim.SetBool(_pressedFlag, value: false);
		}
	}

	protected void SetColor(UIToggleColorScheme colorScheme)
	{
		switch (colorScheme)
		{
		case UIToggleColorScheme.Normal:
			SetBackgroundColor(Constants.ATRIO_UI_BACKGROUND_GRAY);
			SetLabelColor(Constants.ATRIO_LIGHT_GREY_TEXT);
			break;
		case UIToggleColorScheme.Highlighted:
			SetBackgroundColor(Constants.ATRIO_TITLESCREEN_YELLOW);
			SetLabelColor(Constants.ATRIO_UI_BACKGROUND_GRAY);
			break;
		case UIToggleColorScheme.Engaged:
			SetBackgroundColor(Constants.ATRIO_TITLESCREEN_YELLOW);
			SetLabelColor(Constants.ATRIO_UI_BACKGROUND_GRAY);
			break;
		default:
			SetBackgroundColor(Constants.ATRIO_DISABLED_GREY2.WithAlpha(Constants.BACKGROUND_ALPHA_NORMAL));
			SetLabelColor(Constants.ATRIO_GREY_TEXT);
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

	private void SetCheckmarkColor(Color c)
	{
		if (checkmark != null)
		{
			checkmark.color = c;
		}
	}

	private void SetLabelColor(Color c)
	{
		if (label != null)
		{
			label.color = c;
		}
	}

	[ContextMenu("Select this")]
	public void Select()
	{
		Toggle.Select();
	}
}
