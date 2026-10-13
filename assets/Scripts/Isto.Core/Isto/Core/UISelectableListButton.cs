using System;
using System.Collections.Generic;
using Isto.Core.Audio;
using Isto.Core.Inputs;
using Isto.Core.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core;

public class UISelectableListButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, ISubmitHandler
{
	[Header("UI Hookup")]
	[SerializeField]
	protected Image background;

	[SerializeField]
	protected Image outline;

	[SerializeField]
	protected TextMeshProUGUI buttonDescription;

	[SerializeField]
	protected TextMeshProUGUI buttonMode;

	[SerializeField]
	protected bool disabled;

	private Color notSelectedBackgroundColor = Constants.ATRIO_DISABLED_GREY1;

	private Color highlightedBackgroundColor = Constants.ATRIO_PINK_LIGHT;

	private Color highlightedTextColor = Constants.ATRIO_DARK_PINK;

	private Color selectedBackgroundColor = Constants.ATRIO_TITLESCREEN_YELLOW;

	private Color selectedTextColor = Constants.ATRIO_DISABLED_GREY1;

	private Color pointerEnterSelectedTextColor = Color.black;

	private Color pointerEnterTextColor = Constants.ATRIO_TITLESCREEN_YELLOW;

	private Color pointerExitTextColor = Constants.ATRIO_LIGHT_GREY_TEXT;

	protected float selectedBackgroundAlpha = 1f;

	protected float notSelectedBackgroundAlpha;

	protected Animator _anim;

	protected UISounds _uiSounds;

	private bool _selected;

	private HashSet<string> _animatorParams = new HashSet<string>();

	public RectTransform RectTransform => base.transform as RectTransform;

	public Button Button => GetComponent<Button>();

	public bool IsSelected => _selected;

	public event Action<UISelectableListButton> OnSelected;

	[Inject]
	public void Inject(UISounds uISounds)
	{
		_uiSounds = uISounds;
	}

	public void Awake()
	{
		_anim = GetComponent<Animator>();
		if (_anim != null)
		{
			for (int i = 0; i < _anim.parameterCount; i++)
			{
				_animatorParams.Add(_anim.parameters[i].name);
			}
		}
	}

	public Color SetColorAlpha(Color inputColor, float alpha)
	{
		return new Color(inputColor.r, inputColor.g, inputColor.b, alpha);
	}

	public void SetText(string description, string mode)
	{
		if (description != "")
		{
			buttonDescription.text = description;
		}
		if (mode != "")
		{
			buttonMode.text = mode;
		}
	}

	public void Highlighted()
	{
		if (_anim != null && _animatorParams.Contains("highlighted"))
		{
			_anim.SetTrigger("highlighted");
		}
		if (buttonDescription != null)
		{
			buttonDescription.color = highlightedTextColor;
		}
		if (buttonMode != null)
		{
			buttonMode.color = highlightedTextColor;
		}
		if (background != null)
		{
			background.color = SetColorAlpha(highlightedBackgroundColor, selectedBackgroundAlpha);
		}
		GetComponentInParent<CoreUISaveSlotList>().RectTransform.EnsureChildIsVisibleVertically(RectTransform, UIScrollListSelectableItem.ScrollListAdjustmentDriver.SiblingIndexDriven);
	}

	public void NotHighlighted()
	{
		if (_selected)
		{
			Selected();
		}
		else
		{
			NotSelected();
		}
	}

	public virtual void Selected()
	{
		_selected = true;
		if (buttonDescription != null)
		{
			buttonDescription.color = selectedTextColor;
		}
		if (buttonMode != null)
		{
			buttonMode.color = selectedTextColor;
		}
		if (background != null)
		{
			background.color = SetColorAlpha(selectedBackgroundColor, selectedBackgroundAlpha);
		}
	}

	public virtual void NotSelected()
	{
		_selected = false;
		if (_anim != null)
		{
			_anim.SetBool("down", value: false);
			_anim.SetTrigger("deselected");
		}
		if (buttonDescription != null)
		{
			buttonDescription.color = pointerExitTextColor;
		}
		if (buttonMode != null)
		{
			buttonMode.color = pointerExitTextColor;
		}
		if (background != null)
		{
			background.color = SetColorAlpha(notSelectedBackgroundColor, notSelectedBackgroundAlpha);
		}
	}

	public void LinkForNavigation(UISelectableListButton nextElement)
	{
		Selectable button = Button;
		Selectable button2 = nextElement.Button;
		UIUtils.SetNavigation(button, UIUtils.NavigationDirection.Down, button2);
		UIUtils.SetNavigation(button2, UIUtils.NavigationDirection.Up, button);
	}

	void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
	{
		if (!disabled)
		{
			EngageButton();
		}
	}

	void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
	{
		if (!disabled)
		{
			ReleaseButton();
		}
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		if (disabled)
		{
			return;
		}
		if (_selected)
		{
			if (buttonDescription != null)
			{
				buttonDescription.color = selectedTextColor;
			}
			if (buttonMode != null)
			{
				buttonMode.color = selectedTextColor;
			}
		}
		else
		{
			if (buttonDescription != null)
			{
				buttonDescription.color = pointerExitTextColor;
			}
			if (buttonMode != null)
			{
				buttonMode.color = pointerExitTextColor;
			}
		}
	}

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		if (disabled)
		{
			return;
		}
		if (_selected)
		{
			if (buttonDescription != null)
			{
				buttonDescription.color = pointerEnterSelectedTextColor;
			}
			if (buttonMode != null)
			{
				buttonMode.color = pointerEnterSelectedTextColor;
			}
		}
		else
		{
			if (buttonDescription != null)
			{
				buttonDescription.color = pointerEnterTextColor;
			}
			if (buttonMode != null)
			{
				buttonMode.color = pointerEnterTextColor;
			}
		}
	}

	void ISelectHandler.OnSelect(BaseEventData eventData)
	{
		Highlighted();
	}

	void IDeselectHandler.OnDeselect(BaseEventData eventData)
	{
		NotHighlighted();
	}

	void ISubmitHandler.OnSubmit(BaseEventData eventData)
	{
		ReleaseButton();
	}

	public void ButtonClicked()
	{
		_uiSounds.PlayButtonClickSound();
		Selected();
		OnSelected(this);
	}

	private void EngageButton()
	{
		if (_anim != null)
		{
			_anim.SetBool("down", value: true);
		}
	}

	private void ReleaseButton()
	{
		if (!Controls.UsingController)
		{
			EventSystem.current.SetSelectedGameObject(null);
		}
		if (_anim != null)
		{
			_anim.SetBool("down", value: false);
		}
	}

	public void SelectableListButtonClicked(UISelectableListButton button)
	{
		if (button != this)
		{
			NotSelected();
		}
	}

	[ContextMenu("ForceSelect")]
	private void ForceSelection()
	{
		base.gameObject.GetComponent<Button>().Select();
	}
}
