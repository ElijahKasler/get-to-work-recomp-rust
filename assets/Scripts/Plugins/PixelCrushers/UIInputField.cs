using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers;

[Serializable]
public class UIInputField
{
	[SerializeField]
	private InputField m_uiInputField;

	public InputField uiInputField
	{
		get
		{
			return m_uiInputField;
		}
		set
		{
			m_uiInputField = value;
		}
	}

	public string text
	{
		get
		{
			if (uiInputField != null)
			{
				return uiInputField.text;
			}
			return string.Empty;
		}
		set
		{
			if (uiInputField != null)
			{
				uiInputField.text = value;
			}
		}
	}

	public int characterLimit
	{
		get
		{
			if (uiInputField != null)
			{
				return uiInputField.characterLimit;
			}
			return 0;
		}
		set
		{
			if (uiInputField != null)
			{
				uiInputField.characterLimit = value;
			}
		}
	}

	public bool enabled
	{
		get
		{
			if (uiInputField != null)
			{
				return uiInputField.enabled;
			}
			return false;
		}
		set
		{
			if (uiInputField != null)
			{
				uiInputField.enabled = value;
			}
		}
	}

	public GameObject gameObject
	{
		get
		{
			if (!(uiInputField != null))
			{
				return null;
			}
			return uiInputField.gameObject;
		}
	}

	public bool isActiveSelf
	{
		get
		{
			if (!(gameObject != null))
			{
				return false;
			}
			return gameObject.activeSelf;
		}
	}

	public bool activeInHierarchy
	{
		get
		{
			if (!(gameObject != null))
			{
				return false;
			}
			return gameObject.activeInHierarchy;
		}
	}

	public UIInputField()
	{
		uiInputField = null;
	}

	public UIInputField(InputField uiInputField)
	{
		this.uiInputField = uiInputField;
	}

	public void SetActive(bool value)
	{
		if (uiInputField != null)
		{
			uiInputField.gameObject.SetActive(value);
		}
	}

	public void ActivateInputField()
	{
		if (uiInputField != null)
		{
			uiInputField.ActivateInputField();
		}
	}

	public static bool IsNull(UITextField uiTextField)
	{
		if (uiTextField == null)
		{
			return true;
		}
		if (uiTextField.uiText != null)
		{
			return false;
		}
		return true;
	}
}
