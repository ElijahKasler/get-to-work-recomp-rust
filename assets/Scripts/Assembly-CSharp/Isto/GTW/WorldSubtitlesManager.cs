using UnityEngine;
using Zenject;

namespace Isto.GTW;

public class WorldSubtitlesManager : MonoBehaviour
{
	[SerializeField]
	private WorldSubtitle _subtitlePrefab;

	[SerializeField]
	private bool _unlocalizedSourceTextSupport;

	private DiContainer _zenject;

	[Inject]
	public void Inject(DiContainer container)
	{
		_zenject = container;
	}

	public void SpawnSubtitles(WorldTextToSubtitle worldText)
	{
		if (_subtitlePrefab == null)
		{
			Debug.LogError("WorldTextToSubtitle needs a reference to a WorldSubtitle prefab");
			return;
		}
		GameObject gameObject = null;
		gameObject = ((_zenject == null) ? Object.Instantiate(_subtitlePrefab, base.transform).gameObject : _zenject.InstantiatePrefab(_subtitlePrefab, base.transform));
		gameObject.GetComponent<WorldSubtitle>().Initialize(worldText, _unlocalizedSourceTextSupport);
	}
}
