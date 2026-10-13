using Isto.Core;
using Isto.Core.Localization;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Isto.GTW;

public class WorldTextToSubtitle : MonoBehaviour
{
	[SerializeField]
	private string _locKey;

	[FormerlySerializedAs("_spawningOffset")]
	[SerializeField]
	private float _verticalSpawningOffset;

	[SerializeField]
	private float _horizontalSpawningOffset;

	[SerializeField]
	private float _forwardSpawningOffset;

	[SerializeField]
	private int _fontSize = 12;

	private bool _subSpawned;

	private ILocalizationProvider _locProvider;

	[Inject]
	public void Inject(ILocalizationProvider locProvider)
	{
		_locProvider = locProvider;
	}

	private void Start()
	{
		SpawnWorldSubtitle();
		RegisterEvents();
	}

	private void OnDestroy()
	{
		UnregisterEvents();
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
		SpawnWorldSubtitle();
	}

	public string GetTextLocKey()
	{
		return _locKey;
	}

	public Vector3 GetTextPosition()
	{
		RectTransform rectTransform = base.transform as RectTransform;
		Vector3 position = rectTransform.position;
		Vector3 vector = rectTransform.rotation * (Vector3.up * _verticalSpawningOffset);
		vector += rectTransform.rotation * (Vector3.left * _horizontalSpawningOffset);
		vector += rectTransform.rotation * (Vector3.forward * _forwardSpawningOffset);
		return position + vector;
	}

	public Quaternion GetTextRotation()
	{
		return base.transform.rotation;
	}

	public int GetFontSize()
	{
		return _fontSize;
	}

	public void SpawnWorldSubtitle(bool force = false)
	{
		if (!force)
		{
			if (_locProvider != null && _locProvider.GetCurrentLanguageName() == LanguageChanger.LanguageEnum.ENGLISH.Name)
			{
				_subSpawned = false;
				return;
			}
			if (_subSpawned)
			{
				return;
			}
		}
		WorldSubtitlesManager worldSubtitlesManager = Object.FindFirstObjectByType<WorldSubtitlesManager>();
		if (worldSubtitlesManager != null)
		{
			worldSubtitlesManager.SpawnSubtitles(this);
			_subSpawned = true;
		}
		else
		{
			Debug.LogError("Cannot find WorldSubtitlesManager in scene");
		}
	}
}
