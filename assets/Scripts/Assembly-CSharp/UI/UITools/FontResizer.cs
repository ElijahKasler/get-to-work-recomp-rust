using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UITools;

public class FontResizer : MonoBehaviour
{
	[SerializeField]
	private Text _text;

	[SerializeField]
	private TextMeshProUGUI _tmp;

	[Space]
	[SerializeField]
	private int _lowResolutionFontSize = 30;

	[SerializeField]
	private int _highResolutionFontSize = 20;

	[SerializeField]
	private Vector2Int _lowResolution = new Vector2Int(1280, 800);

	[SerializeField]
	private Vector2Int _highResolution = new Vector2Int(1920, 1080);

	[Tooltip("Set to 0 to calculate based on resolution width. Set to 1 to base on height.")]
	[SerializeField]
	[Range(0f, 1f)]
	private float _basedOnResolutionHeight = 1f;

	private Vector2Int _currentResolution = Vector2Int.zero;

	private void Start()
	{
		if (_highResolution.x < _lowResolution.x || _highResolution.y < _lowResolution.y)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (HasResolutionChanged())
		{
			float sizeRatio = GetSizeRatio();
			SetFontSize(Mathf.FloorToInt(Mathf.Lerp(_lowResolutionFontSize, _highResolutionFontSize, sizeRatio)));
		}
	}

	private bool HasResolutionChanged()
	{
		Vector2Int currentResolution = new Vector2Int(Screen.width, Screen.height);
		if (currentResolution.x != _currentResolution.x || currentResolution.y != _currentResolution.y)
		{
			_currentResolution = currentResolution;
			return true;
		}
		return false;
	}

	private float GetSizeRatio()
	{
		float a = Mathf.InverseLerp(_lowResolution.x, _highResolution.x, _currentResolution.x);
		float b = Mathf.InverseLerp(_lowResolution.y, _highResolution.y, _currentResolution.y);
		return Mathf.Lerp(a, b, _basedOnResolutionHeight);
	}

	public void SetFontSize(int fontSize)
	{
		if (_text != null)
		{
			_text.fontSize = fontSize;
		}
		if (_tmp != null)
		{
			_tmp.fontSize = fontSize;
		}
	}
}
