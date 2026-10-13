using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem;

[AddComponentMenu("")]
public class StandardUIResponseButton : MonoBehaviour
{
	public Button button;

	[Tooltip("Text element to display response text.")]
	public UITextField label;

	[Tooltip("Apply emphasis tag colors to button text.")]
	public bool setLabelColor = true;

	[Tooltip("Set button's text to this color by default.")]
	public Color defaultColor = Color.white;

	public RectTransform lg;

	public ScrollRect scrollRect;

	[SerializeField]
	private RectTransform textRect;

	[SerializeField]
	private float minHeight;

	[SerializeField]
	private RectTransform buttonRect;

	public string text
	{
		get
		{
			return label.text;
		}
		set
		{
			label.text = UITools.StripRPGMakerCodes(value);
			UITools.SendTextChangeMessage(label);
		}
	}

	public bool isClickable
	{
		get
		{
			if (button != null)
			{
				return button.interactable;
			}
			return false;
		}
		set
		{
			if (button != null)
			{
				button.interactable = value;
			}
		}
	}

	public bool isVisible { get; set; }

	public Response response { get; set; }

	public Transform target { get; set; }

	public void Reset()
	{
		isClickable = false;
		isVisible = false;
		response = null;
		if (label != null)
		{
			label.text = string.Empty;
			SetColor(defaultColor);
		}
		Invoke("ScaleSizeAppropriately", 0.1f);
	}

	public virtual void Awake()
	{
		if (button == null)
		{
			button = GetComponent<Button>();
		}
		if (button == null)
		{
			Debug.LogWarning("Dialogue System: Response button '" + base.name + "' is missing a Unity UI Button component!", this);
		}
	}

	public virtual void Start()
	{
		if (button != null)
		{
			button.onClick.AddListener(OnClick);
		}
	}

	public virtual void SetFormattedText(FormattedText formattedText)
	{
		if (formattedText != null)
		{
			text = UITools.GetUIFormattedText(formattedText);
			SetColor((formattedText.emphases.Length != 0) ? formattedText.emphases[0].color : defaultColor);
			Invoke("ScaleSizeAppropriately", 0.1f);
		}
	}

	private void ScaleSizeAppropriately()
	{
		RectTransform obj = GetComponent(typeof(RectTransform)) as RectTransform;
		Vector2 sizeDelta = obj.sizeDelta;
		Vector2 sizeDelta2 = textRect.sizeDelta;
		if (sizeDelta2.y < minHeight)
		{
			sizeDelta.y = minHeight;
		}
		else
		{
			sizeDelta.y = sizeDelta2.y;
		}
		obj.sizeDelta = sizeDelta;
		buttonRect.sizeDelta = sizeDelta;
		lg.ForceUpdateRectTransforms();
		LayoutRebuilder.ForceRebuildLayoutImmediate(lg);
		scrollRect.normalizedPosition = new Vector2(0f, 0f);
	}

	public virtual void SetUnformattedText(string unformattedText)
	{
		text = unformattedText;
		SetColor(defaultColor);
		Invoke("ScaleSizeAppropriately", 0.1f);
	}

	protected virtual void SetColor(Color currentColor)
	{
		if (setLabelColor)
		{
			label.color = currentColor;
		}
	}

	public virtual void OnClick()
	{
		if (target != null)
		{
			target.SendMessage("OnClick", response, SendMessageOptions.RequireReceiver);
		}
	}
}
