using System.ComponentModel;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.Internal;

[AddComponentMenu("")]
[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public class GUIText : MonoBehaviour
{
	private string bKggoVYtivOgoWvbYtYOjlvKWJwA;

	private GUIStyle eQYpJRiUWVhslmGNSEuxqeMZTpxn;

	private TextAnchor DKvBUEYYjPeoBswWAQohZBKCrJcL;

	private TextAlignment ATNaFZNZZFKcAijrwbwxSqhhpcDp;

	private float oDUnVIDoWFDXiEgnjFUFPSUzABJT;

	private Font McvlFBFcwvpnhnUoltMewuHMokVk;

	private int dTjHygprbLbDxetpaMZWvWzEkVMe = -1;

	private FontStyle lfqXpqWMnjPHgqaYfBWWGqiFJZQcA;

	private Color oCgbpeixbKsCyVZvwNsvKQktsdSDA = Color.white;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Vector2 _pixelOffset;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private bool _useUnityUI;

	private bool cboukOxagHMsKbQOtPXVuFMWoimv;

	private bool UcJXUhSZwxPRDeLueEPfufLYJSiB;

	private bool sSpjrCsfOvjEmlhMkBSZdSHFVSqv;

	private bool zecmnnbVnCsUjeSVgSjCGLNUbSfB;

	private bool BPvkiMFEESDWhwqNtbumfCYrdXXB;

	private bool ZIAyjxtpTjqjwLERaTLrifzCaRxw;

	private bool YwrYejqMcyuTpgDVxCkRDawfPApiA;

	private Text lVosAbOdAFjgrbWUhpjmqeJtQvIcA;

	private bool bjIcvvkalYHKGXHEBFDkVEfcoRog;

	private bool RwnSbLGhMRoxlARJDrkOfpMiIUBd;

	public string text
	{
		get
		{
			return bKggoVYtivOgoWvbYtYOjlvKWJwA;
		}
		set
		{
			bKggoVYtivOgoWvbYtYOjlvKWJwA = value;
		}
	}

	public TextAnchor anchor
	{
		get
		{
			return DKvBUEYYjPeoBswWAQohZBKCrJcL;
		}
		set
		{
			DKvBUEYYjPeoBswWAQohZBKCrJcL = value;
			cboukOxagHMsKbQOtPXVuFMWoimv = true;
			if (eQYpJRiUWVhslmGNSEuxqeMZTpxn != null)
			{
				eQYpJRiUWVhslmGNSEuxqeMZTpxn.alignment = value;
			}
		}
	}

	public TextAlignment alignment
	{
		get
		{
			return ATNaFZNZZFKcAijrwbwxSqhhpcDp;
		}
		set
		{
			ATNaFZNZZFKcAijrwbwxSqhhpcDp = value;
			UcJXUhSZwxPRDeLueEPfufLYJSiB = true;
		}
	}

	public float lineSpacing
	{
		get
		{
			return oDUnVIDoWFDXiEgnjFUFPSUzABJT;
		}
		set
		{
			oDUnVIDoWFDXiEgnjFUFPSUzABJT = value;
			sSpjrCsfOvjEmlhMkBSZdSHFVSqv = true;
			_ = eQYpJRiUWVhslmGNSEuxqeMZTpxn;
		}
	}

	public Font font
	{
		get
		{
			return McvlFBFcwvpnhnUoltMewuHMokVk;
		}
		set
		{
			zecmnnbVnCsUjeSVgSjCGLNUbSfB = true;
			McvlFBFcwvpnhnUoltMewuHMokVk = value;
			if (eQYpJRiUWVhslmGNSEuxqeMZTpxn != null)
			{
				eQYpJRiUWVhslmGNSEuxqeMZTpxn.font = value;
			}
		}
	}

	public int fontSize
	{
		get
		{
			return dTjHygprbLbDxetpaMZWvWzEkVMe;
		}
		set
		{
			dTjHygprbLbDxetpaMZWvWzEkVMe = value;
			BPvkiMFEESDWhwqNtbumfCYrdXXB = true;
			if (eQYpJRiUWVhslmGNSEuxqeMZTpxn != null)
			{
				eQYpJRiUWVhslmGNSEuxqeMZTpxn.fontSize = value;
			}
		}
	}

	public FontStyle fontStyle
	{
		get
		{
			return lfqXpqWMnjPHgqaYfBWWGqiFJZQcA;
		}
		set
		{
			lfqXpqWMnjPHgqaYfBWWGqiFJZQcA = value;
			ZIAyjxtpTjqjwLERaTLrifzCaRxw = true;
			if (eQYpJRiUWVhslmGNSEuxqeMZTpxn != null)
			{
				eQYpJRiUWVhslmGNSEuxqeMZTpxn.fontStyle = value;
			}
		}
	}

	public Color color
	{
		get
		{
			return oCgbpeixbKsCyVZvwNsvKQktsdSDA;
		}
		set
		{
			oCgbpeixbKsCyVZvwNsvKQktsdSDA = value;
			YwrYejqMcyuTpgDVxCkRDawfPApiA = true;
			if (eQYpJRiUWVhslmGNSEuxqeMZTpxn != null)
			{
				eQYpJRiUWVhslmGNSEuxqeMZTpxn.normal.textColor = value;
			}
		}
	}

	public Vector2 pixelOffset
	{
		get
		{
			return _pixelOffset;
		}
		set
		{
			_pixelOffset = value;
		}
	}

	public bool useUnityUI
	{
		get
		{
			return _useUnityUI;
		}
		set
		{
			if (_useUnityUI != value)
			{
				_useUnityUI = value;
				bjIcvvkalYHKGXHEBFDkVEfcoRog = value;
				if (value)
				{
					BjKfxhdjEINwFFQUhloJnXNiQMYjB();
				}
				else
				{
					EhQfuDoMAXDtvxpMvwpxkXAspsWp();
				}
			}
		}
	}

	[CustomObfuscation(rename = false)]
	private void Awake()
	{
		RwnSbLGhMRoxlARJDrkOfpMiIUBd = true;
	}

	[CustomObfuscation(rename = false)]
	private void Start()
	{
		bjIcvvkalYHKGXHEBFDkVEfcoRog = _useUnityUI;
		if (_useUnityUI)
		{
			BjKfxhdjEINwFFQUhloJnXNiQMYjB();
		}
	}

	[CustomObfuscation(rename = false)]
	private void OnGUI()
	{
		if (!_useUnityUI)
		{
			if (eQYpJRiUWVhslmGNSEuxqeMZTpxn == null)
			{
				VgegdwPlMNwdnEwjknqMekBPwoNL();
			}
			if (!string.IsNullOrEmpty(bKggoVYtivOgoWvbYtYOjlvKWJwA))
			{
				Vector2 vector = base.transform.localPosition;
				GUI.Label(new Rect(vector.x * (float)Screen.width + _pixelOffset.x, vector.y * (float)Screen.height + _pixelOffset.y, MathTools.Clamp((float)Screen.width - vector.x * (float)Screen.width, 0f, float.MaxValue), MathTools.Clamp((float)Screen.height - vector.y * (float)Screen.height, 0f, float.MaxValue)), bKggoVYtivOgoWvbYtYOjlvKWJwA, eQYpJRiUWVhslmGNSEuxqeMZTpxn);
			}
		}
	}

	[CustomObfuscation(rename = false)]
	private void Update()
	{
		if (!_useUnityUI)
		{
			return;
		}
		if (lVosAbOdAFjgrbWUhpjmqeJtQvIcA == null)
		{
			Logger.LogError("Text component has been deleted.");
			return;
		}
		RectTransform component = lVosAbOdAFjgrbWUhpjmqeJtQvIcA.GetComponent<RectTransform>();
		if (component.anchoredPosition != _pixelOffset)
		{
			component.anchoredPosition = _pixelOffset;
		}
		lVosAbOdAFjgrbWUhpjmqeJtQvIcA.text = bKggoVYtivOgoWvbYtYOjlvKWJwA;
	}

	[CustomObfuscation(rename = false)]
	private void OnValidate()
	{
		if (RwnSbLGhMRoxlARJDrkOfpMiIUBd && _useUnityUI != bjIcvvkalYHKGXHEBFDkVEfcoRog)
		{
			bjIcvvkalYHKGXHEBFDkVEfcoRog = _useUnityUI;
			if (_useUnityUI)
			{
				BjKfxhdjEINwFFQUhloJnXNiQMYjB();
			}
			else
			{
				EhQfuDoMAXDtvxpMvwpxkXAspsWp();
			}
		}
	}

	private void BjKfxhdjEINwFFQUhloJnXNiQMYjB()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		if (UnityTools.GetComponentInSelfOrParents<Canvas>(base.transform) == null)
		{
			GameObject gameObject;
			if (base.transform.root == base.transform)
			{
				gameObject = new GameObject("Canvas");
				base.transform.SetParent(gameObject.transform, worldPositionStays: true);
			}
			else
			{
				gameObject = base.transform.root.gameObject;
			}
			gameObject.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
			if (!(gameObject.GetComponent<CanvasScaler>() != null))
			{
				gameObject.AddComponent<CanvasScaler>();
			}
			else
			{
				gameObject.GetComponent<CanvasScaler>();
			}
		}
		lVosAbOdAFjgrbWUhpjmqeJtQvIcA = GetComponent<Text>();
		if (!(lVosAbOdAFjgrbWUhpjmqeJtQvIcA == null))
		{
			return;
		}
		RectTransform rectTransform = base.gameObject.AddComponent<RectTransform>();
		rectTransform.anchorMax = new Vector2(1f, 1f);
		rectTransform.anchorMin = new Vector2(0f, 0f);
		rectTransform.localPosition = Vector2.zero;
		rectTransform.anchoredPosition = Vector2.zero;
		rectTransform.sizeDelta = Vector3.zero;
		lVosAbOdAFjgrbWUhpjmqeJtQvIcA = base.gameObject.AddComponent<Text>();
		lVosAbOdAFjgrbWUhpjmqeJtQvIcA.color = Color.white;
		if (_useUnityUI)
		{
			try
			{
				lVosAbOdAFjgrbWUhpjmqeJtQvIcA.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
			}
			catch
			{
				try
				{
					lVosAbOdAFjgrbWUhpjmqeJtQvIcA.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
				}
				catch
				{
					Logger.LogError("No default font found for GUIText.");
				}
			}
		}
		lVosAbOdAFjgrbWUhpjmqeJtQvIcA.fontSize = 13;
		if (cboukOxagHMsKbQOtPXVuFMWoimv)
		{
			lVosAbOdAFjgrbWUhpjmqeJtQvIcA.alignment = DKvBUEYYjPeoBswWAQohZBKCrJcL;
		}
		else
		{
			DKvBUEYYjPeoBswWAQohZBKCrJcL = lVosAbOdAFjgrbWUhpjmqeJtQvIcA.alignment;
		}
		if (zecmnnbVnCsUjeSVgSjCGLNUbSfB)
		{
			lVosAbOdAFjgrbWUhpjmqeJtQvIcA.font = McvlFBFcwvpnhnUoltMewuHMokVk;
		}
		else
		{
			McvlFBFcwvpnhnUoltMewuHMokVk = lVosAbOdAFjgrbWUhpjmqeJtQvIcA.font;
		}
		if (BPvkiMFEESDWhwqNtbumfCYrdXXB)
		{
			lVosAbOdAFjgrbWUhpjmqeJtQvIcA.fontSize = dTjHygprbLbDxetpaMZWvWzEkVMe;
		}
		else
		{
			dTjHygprbLbDxetpaMZWvWzEkVMe = lVosAbOdAFjgrbWUhpjmqeJtQvIcA.fontSize;
		}
		if (ZIAyjxtpTjqjwLERaTLrifzCaRxw)
		{
			lVosAbOdAFjgrbWUhpjmqeJtQvIcA.fontStyle = lfqXpqWMnjPHgqaYfBWWGqiFJZQcA;
		}
		else
		{
			lfqXpqWMnjPHgqaYfBWWGqiFJZQcA = lVosAbOdAFjgrbWUhpjmqeJtQvIcA.fontStyle;
		}
		if (YwrYejqMcyuTpgDVxCkRDawfPApiA)
		{
			lVosAbOdAFjgrbWUhpjmqeJtQvIcA.color = oCgbpeixbKsCyVZvwNsvKQktsdSDA;
		}
		else
		{
			oCgbpeixbKsCyVZvwNsvKQktsdSDA = lVosAbOdAFjgrbWUhpjmqeJtQvIcA.color;
		}
	}

	private void EhQfuDoMAXDtvxpMvwpxkXAspsWp()
	{
		if (Application.isPlaying)
		{
			if (lVosAbOdAFjgrbWUhpjmqeJtQvIcA != null)
			{
				lVosAbOdAFjgrbWUhpjmqeJtQvIcA.text = string.Empty;
			}
			lVosAbOdAFjgrbWUhpjmqeJtQvIcA = null;
		}
	}

	private void VgegdwPlMNwdnEwjknqMekBPwoNL()
	{
		eQYpJRiUWVhslmGNSEuxqeMZTpxn = new GUIStyle(GUI.skin.label);
		if (cboukOxagHMsKbQOtPXVuFMWoimv)
		{
			eQYpJRiUWVhslmGNSEuxqeMZTpxn.alignment = DKvBUEYYjPeoBswWAQohZBKCrJcL;
		}
		else
		{
			DKvBUEYYjPeoBswWAQohZBKCrJcL = eQYpJRiUWVhslmGNSEuxqeMZTpxn.alignment;
		}
		if (zecmnnbVnCsUjeSVgSjCGLNUbSfB)
		{
			eQYpJRiUWVhslmGNSEuxqeMZTpxn.font = McvlFBFcwvpnhnUoltMewuHMokVk;
		}
		else
		{
			McvlFBFcwvpnhnUoltMewuHMokVk = eQYpJRiUWVhslmGNSEuxqeMZTpxn.font;
		}
		if (BPvkiMFEESDWhwqNtbumfCYrdXXB)
		{
			eQYpJRiUWVhslmGNSEuxqeMZTpxn.fontSize = dTjHygprbLbDxetpaMZWvWzEkVMe;
		}
		else
		{
			dTjHygprbLbDxetpaMZWvWzEkVMe = eQYpJRiUWVhslmGNSEuxqeMZTpxn.fontSize;
		}
		if (ZIAyjxtpTjqjwLERaTLrifzCaRxw)
		{
			eQYpJRiUWVhslmGNSEuxqeMZTpxn.fontStyle = lfqXpqWMnjPHgqaYfBWWGqiFJZQcA;
		}
		else
		{
			lfqXpqWMnjPHgqaYfBWWGqiFJZQcA = eQYpJRiUWVhslmGNSEuxqeMZTpxn.fontStyle;
		}
		if (YwrYejqMcyuTpgDVxCkRDawfPApiA)
		{
			eQYpJRiUWVhslmGNSEuxqeMZTpxn.normal.textColor = oCgbpeixbKsCyVZvwNsvKQktsdSDA;
		}
		else
		{
			oCgbpeixbKsCyVZvwNsvKQktsdSDA = eQYpJRiUWVhslmGNSEuxqeMZTpxn.normal.textColor;
		}
	}

	[CustomObfuscation(rename = false)]
	internal static GUIText GetOrAddComponent(GameObject gameObject)
	{
		if (gameObject == null)
		{
			return null;
		}
		GUIText gUIText = gameObject.GetComponent<GUIText>();
		if (gUIText == null)
		{
			gUIText = gameObject.AddComponent<GUIText>();
		}
		return gUIText;
	}

	[CustomObfuscation(rename = false)]
	internal static GUIText CreateLogger(GameObject gameObject)
	{
		if (gameObject == null)
		{
			return null;
		}
		GUIText orAddComponent = GetOrAddComponent(gameObject);
		orAddComponent.anchor = TextAnchor.LowerLeft;
		return orAddComponent;
	}
}
