using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers;

[Serializable]
public class UITextField
{
	[SerializeField]
	private Text m_uiText;

	public Text uiText
	{
		get
		{
			return m_uiText;
		}
		set
		{
			m_uiText = value;
		}
	}

	public string text
	{
		get
		{
			if (uiText != null)
			{
				return uiText.text;
			}
			return string.Empty;
		}
		set
		{
			if (uiText != null)
			{
				uiText.text = value;
			}
		}
	}

	public bool enabled
	{
		get
		{
			if (uiText != null)
			{
				return uiText.enabled;
			}
			return false;
		}
		set
		{
			if (uiText != null)
			{
				uiText.enabled = value;
			}
		}
	}

	public Color color
	{
		get
		{
			if (uiText != null)
			{
				return uiText.color;
			}
			return Color.black;
		}
		set
		{
			if (uiText != null)
			{
				uiText.color = value;
			}
		}
	}

	public GameObject gameObject
	{
		get
		{
			if (!(uiText != null))
			{
				return null;
			}
			return uiText.gameObject;
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

	public UITextField()
	{
		uiText = null;
	}

	public UITextField(Text uiText)
	{
		this.uiText = uiText;
	}

	public void SetActive(bool value)
	{
		if (uiText != null)
		{
			uiText.gameObject.SetActive(value);
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
