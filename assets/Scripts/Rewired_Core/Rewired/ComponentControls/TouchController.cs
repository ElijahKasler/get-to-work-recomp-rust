using System;
using UnityEngine;

namespace Rewired.ComponentControls;

[Serializable]
[RequireComponent(typeof(RectTransform))]
[DisallowMultipleComponent]
[AddComponentMenu("Rewired/Touch Controls/Touch Controller")]
public sealed class TouchController : CustomController
{
	[Tooltip("If true, disables mouse input when the Touch Controller script is enabled or GameObject is activated and re-enables mouse input when the script is disabled or GameObject is deactivated. This is useful for disabling Mouse Look controls when using touch controls in an FPS for example.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private bool _disableMouseInputWhenEnabled = true;

	[Tooltip("If true, a Custom Controller will be populated with the data from this controller.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private bool _useCustomController = true;

	[NonSerialized]
	private bool CFwiziCQlQfRxMWqTPOoTHjzlrTLA;

	public bool disableMouseInputWhenEnabled
	{
		get
		{
			return _disableMouseInputWhenEnabled;
		}
		set
		{
			if (_disableMouseInputWhenEnabled != value)
			{
				_disableMouseInputWhenEnabled = value;
				LXXqtrzpUZDSjkRyClurrSAolbGBb();
			}
		}
	}

	public bool useCustomController
	{
		get
		{
			return _useCustomController;
		}
		set
		{
			if (_useCustomController != value)
			{
				_useCustomController = value;
				LXXqtrzpUZDSjkRyClurrSAolbGBb();
				if (value)
				{
					hkxvpcXtsPpBLXfjJwaSIlgjbUHw();
				}
			}
		}
	}

	[CustomObfuscation(rename = false)]
	private TouchController()
	{
	}

	[CustomObfuscation(rename = false)]
	internal override void OnDisable()
	{
		base.OnDisable();
		if (qDgftULavQAHtDpDqbEZBWFeELMo() && ReInput.isReady)
		{
			FjKrJSenmvbrNGHfEKGMAVAnlZJBA(true);
		}
	}

	internal bool PvgjMFoCyILaWjbtZpHrYMCwDrtC()
	{
		if (!OnInitialize())
		{
			return false;
		}
		if (ReInput.isReady)
		{
			CFwiziCQlQfRxMWqTPOoTHjzlrTLA = ReInput.controllers.Mouse.enabled;
			FjKrJSenmvbrNGHfEKGMAVAnlZJBA(false);
		}
		return true;
	}

	[CustomObfuscation(rename = false)]
	internal override bool GetUseCustomController()
	{
		return _useCustomController;
	}

	[CustomObfuscation(rename = false)]
	internal override void SetUseCustomController(bool value)
	{
		_useCustomController = value;
	}

	private void FjKrJSenmvbrNGHfEKGMAVAnlZJBA(bool P_0)
	{
		if (_disableMouseInputWhenEnabled)
		{
			if (P_0)
			{
				ReInput.controllers.Mouse.enabled = CFwiziCQlQfRxMWqTPOoTHjzlrTLA;
			}
			else
			{
				ReInput.controllers.Mouse.enabled = false;
			}
		}
	}

	private void LXXqtrzpUZDSjkRyClurrSAolbGBb()
	{
	}

	private bool hkxvpcXtsPpBLXfjJwaSIlgjbUHw()
	{
		if (ReInput.isReady)
		{
			return true;
		}
		Logger.LogError("Rewired is not initialized. You must have an enabled Rewired Input Manager in the scene if using a Touch Controller. Custom Controller support will be disabled on this Touch Controller.");
		SetUseCustomController(value: false);
		return false;
	}
}
