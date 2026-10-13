using I2.Loc;
using Isto.Core.Enums;
using Isto.Core.Inputs;
using Isto.Core.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class UIControlDisplayElement : MonoBehaviour
{
	public bool hideForMouseInput;

	public bool hideForControllerInput;

	[EnumDropdown(typeof(UserActions))]
	[SerializeField]
	private string _userAction;

	[Space(20f)]
	public bool useModifier;

	public Image actionImage;

	public Image modifierImage;

	[Tooltip("This is optional. Do not assign it and the layout will be preserved when the element is hidden")]
	public LayoutElement layoutElement;

	[SerializeField]
	private LocalizedString _actionDescription;

	[EnumDropdown(typeof(UserActions))]
	[SerializeField]
	private string _modifierAction;

	private IControls _controls;

	private TextMeshProUGUI _descriptionText;

	[Inject]
	public void Inject(IControls controls)
	{
		_controls = controls;
	}

	private void Awake()
	{
		_descriptionText = GetComponentInChildren<TextMeshProUGUI>();
	}

	private void Start()
	{
		UpdateControlDisplay();
	}

	private void OnEnable()
	{
		UpdateControlDisplay();
		RegisterEvents();
	}

	private void OnDisable()
	{
		UnregisterEvents();
	}

	private void RegisterEvents()
	{
		Events.Subscribe("SettingsChanged", Events_OnSettingsChanged);
		Events.Subscribe("InputChanged", Events_OnSettingsChanged);
	}

	private void UnregisterEvents()
	{
		Events.UnSubscribe("SettingsChanged", Events_OnSettingsChanged);
		Events.UnSubscribe("InputChanged", Events_OnSettingsChanged);
	}

	private void Events_OnSettingsChanged()
	{
		UpdateControlDisplay();
	}

	public void SetAction(UserActions newAction)
	{
		_userAction = newAction.Name;
		UpdateControlDisplay();
	}

	public void SetActionDescription(LocalizedString description)
	{
		_actionDescription = description;
		UpdateControlDisplay();
	}

	private bool IsUserActionInvalid()
	{
		if (_userAction == null)
		{
			Debug.LogError("Action needs to be added to the Display Element for the GameObject " + base.gameObject.name);
			return true;
		}
		return false;
	}

	private void UpdateControlDisplay()
	{
		if (ShouldHideForInput() || IsUserActionInvalid())
		{
			DisableDisplay();
			return;
		}
		UserActions byValue = StringEnum<UserActions>.GetByValue(_userAction);
		Sprite iconForAction = _controls.GetIconForAction(byValue);
		if (iconForAction == null)
		{
			DisableDisplay();
			return;
		}
		if (actionImage != null && iconForAction != null)
		{
			if ((bool)layoutElement)
			{
				layoutElement.enabled = true;
			}
			actionImage.sprite = iconForAction;
			actionImage.enabled = true;
			if (modifierImage != null)
			{
				UserActions byValue2 = StringEnum<UserActions>.GetByValue(_modifierAction);
				modifierImage.sprite = _controls.GetIconForAction(byValue2);
				if (useModifier)
				{
					modifierImage.enabled = true;
				}
				else
				{
					modifierImage.enabled = false;
				}
			}
		}
		else
		{
			DisableDisplay();
		}
		if (_descriptionText != null)
		{
			_descriptionText.enabled = true;
			if (_descriptionText != null && (string)_actionDescription != null)
			{
				Loc.SetTMPro(_descriptionText, _actionDescription);
			}
		}
	}

	private bool ShouldHideForInput()
	{
		if (!Controls.UsingController || !hideForControllerInput)
		{
			if (!Controls.UsingController)
			{
				return hideForMouseInput;
			}
			return false;
		}
		return true;
	}

	private void DisableDisplay()
	{
		if ((bool)actionImage)
		{
			actionImage.enabled = false;
		}
		if ((bool)modifierImage)
		{
			modifierImage.enabled = false;
		}
		if ((bool)_descriptionText)
		{
			_descriptionText.enabled = false;
		}
		if ((bool)layoutElement)
		{
			layoutElement.enabled = false;
		}
	}
}
