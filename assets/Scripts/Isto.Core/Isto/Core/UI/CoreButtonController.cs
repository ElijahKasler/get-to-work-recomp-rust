using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Isto.Core.UI;

public class CoreButtonController : MonoBehaviour
{
	[SerializeField]
	private bool _autoReassignNavigation = true;

	private CoreButton _coreButton;

	private Animator _coreButtonAnimator;

	private TextMeshProUGUI _mainText;

	private CoreButtonStyleController _styleController;

	private Navigation _defaultNavigation;

	protected IDynamicSelectableProvider _upwardNavigationTargetProvider;

	protected IDynamicSelectableProvider _downwardNavigationTargetProvider;

	protected IDynamicSelectableProvider _leftwardNavigationTargetProvider;

	protected IDynamicSelectableProvider _rightwardNavigationTargetProvider;

	public virtual bool Active => Button.Active;

	public virtual bool Interactable => Button.Interactable;

	public virtual bool IsSelected => Button.IsSelected;

	private CoreButton Button
	{
		get
		{
			if (_coreButton == null)
			{
				_coreButton = GetComponent<CoreButton>();
			}
			return _coreButton;
		}
	}

	protected virtual void Awake()
	{
		_coreButtonAnimator = GetComponent<Animator>();
		_mainText = GetComponentInChildren<TextMeshProUGUI>();
		_styleController = GetComponent<CoreButtonStyleController>();
		if (Button != null)
		{
			_defaultNavigation = Button.navigation;
			Button.OnSelectEvent += CoreButton_OnSelectedEvent;
		}
	}

	protected virtual void OnDestroy()
	{
		if (!(_coreButton == null))
		{
			_coreButton.OnSelectEvent -= CoreButton_OnSelectedEvent;
		}
	}

	private void CoreButton_OnSelectedEvent(BaseEventData eventData)
	{
		if (_autoReassignNavigation)
		{
			UpdateNavigation();
		}
	}

	public virtual Selectable GetSelectable()
	{
		return Button;
	}

	public CoreButton GetButton()
	{
		return Button;
	}

	public virtual void Select()
	{
		Button.Select();
	}

	public virtual void Selected()
	{
	}

	public virtual void DeSelected()
	{
	}

	public virtual void SetEnabled()
	{
		if (Button != null && !Button.interactable)
		{
			Button.interactable = true;
		}
	}

	public virtual void SetDisabled()
	{
		if (Button != null && Button.interactable)
		{
			Button.interactable = false;
		}
	}

	public virtual void SetText(string localizedText)
	{
		if (_mainText != null)
		{
			_mainText.text = localizedText;
		}
	}

	public virtual void SetButtonStyle(int id)
	{
		if (_styleController != null)
		{
			_styleController.SetButtonStyle(id);
		}
	}

	public virtual void SetButtonStyle(string name)
	{
		if (_styleController != null)
		{
			_styleController.SetButtonStyle(name);
		}
	}

	public virtual void ResetAnimatorState()
	{
	}

	protected virtual void UpdateNavigation()
	{
		if (!(_coreButton == null))
		{
			Navigation navigation = _coreButton.navigation;
			if (navigation.mode == Navigation.Mode.Explicit)
			{
				navigation.Copy(_defaultNavigation, copyOnlyIfNull: true);
				_defaultNavigation = navigation;
				navigation.RemoveUninteractableDestinations();
				navigation.SetUp(_upwardNavigationTargetProvider);
				navigation.SetDown(_downwardNavigationTargetProvider);
				navigation.SetLeft(_leftwardNavigationTargetProvider);
				navigation.SetRight(_rightwardNavigationTargetProvider);
				_coreButton.navigation = navigation;
			}
		}
	}

	public virtual void SetUpwardNavigationTargetProvider(IDynamicSelectableProvider provider)
	{
		_upwardNavigationTargetProvider = provider;
	}

	public virtual void SetDownwardNavigationTargetProvider(IDynamicSelectableProvider provider)
	{
		_downwardNavigationTargetProvider = provider;
	}

	public virtual void SetLeftwardNavigationTargetProvider(IDynamicSelectableProvider provider)
	{
		_leftwardNavigationTargetProvider = provider;
	}

	public virtual void SetRightwardNavigationTargetProvider(IDynamicSelectableProvider provider)
	{
		_rightwardNavigationTargetProvider = provider;
	}
}
