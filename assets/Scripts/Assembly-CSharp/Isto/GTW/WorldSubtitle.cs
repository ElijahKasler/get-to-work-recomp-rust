using Isto.Core;
using Isto.Core.Localization;
using TMPro;
using UnityEngine;
using Zenject;

namespace Isto.GTW;

public class WorldSubtitle : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _label;

	[SerializeField]
	private RectTransform _background;

	[SerializeField]
	private float _horizontalPadding = 10f;

	[SerializeField]
	private float _verticalPadding = 4f;

	private WorldTextToSubtitle _source;

	private bool _showLocKeyTextIfNotFound;

	private ILocalizationProvider _locProvider;

	[Inject]
	public void Inject(ILocalizationProvider locProvider)
	{
		_locProvider = locProvider;
	}

	private void Awake()
	{
		RegisterEvents();
	}

	private void OnDestroy()
	{
		UnregisterEvents();
	}

	private void Update()
	{
		if (_source == null)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void RegisterEvents()
	{
		Events.Subscribe("LanguageChanged", Events_OnLanguageChanged);
	}

	private void UnregisterEvents()
	{
		Events.UnSubscribe("LanguageChanged", Events_OnLanguageChanged);
	}

	private void Events_OnLanguageChanged()
	{
		if (_locProvider.GetCurrentLanguageName() == LanguageChanger.LanguageEnum.ENGLISH.Name)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Refresh();
		}
	}

	public void Initialize(WorldTextToSubtitle source, bool showLocKeyTextIfNotFound = false)
	{
		_source = source;
		_showLocKeyTextIfNotFound = showLocKeyTextIfNotFound;
		Refresh();
	}

	public void Refresh()
	{
		string textLocKey = _source.GetTextLocKey();
		Vector3 textPosition = _source.GetTextPosition();
		Quaternion textRotation = _source.GetTextRotation();
		(base.transform as RectTransform).SetPositionAndRotation(textPosition, textRotation);
		string text;
		if (_locProvider != null)
		{
			text = _locProvider.GetLocalizedText(textLocKey);
			if (_showLocKeyTextIfNotFound && text == "LOCALIZATION KEY NOT SET")
			{
				text = textLocKey;
			}
		}
		else
		{
			text = textLocKey;
		}
		_label.text = text;
		_label.fontSize = _source.GetFontSize();
		float size = _label.preferredWidth + _horizontalPadding;
		_background.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
		float size2 = _label.preferredHeight + _verticalPadding;
		_background.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size2);
	}
}
