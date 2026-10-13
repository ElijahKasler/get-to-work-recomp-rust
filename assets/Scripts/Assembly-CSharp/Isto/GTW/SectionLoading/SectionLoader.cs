using System;
using System.Collections.Generic;
using System.IO;
using Isto.Core.Scenes;
using Isto.GTW.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Isto.GTW.SectionLoading;

public class SectionLoader : MonoBehaviour
{
	[SerializeField]
	private SectionData _sectionData;

	[SerializeField]
	private float _loadDistance = 30f;

	[Tooltip("Scene holding lighting and occlusion culling data for the level.")]
	[SerializeField]
	[SceneReference(true)]
	private string _lightingScene;

	[Space]
	public bool showDebug;

	private List<LoadedSectionScene> _loadedSectionScenes = new List<LoadedSectionScene>();

	public static readonly string LOADING_DISABLED_EDITOR_PREF_KEY = "LoadingDisabled";

	public static readonly string BUILD_SETTINGS_LOAD_STRATEGY_EDITOR_PREF_KEY = "BuildSettingsLoadStrategy";

	private PlayerController _playerController;

	private int _prevLoadingSectionCount;

	public static bool IsBusy { get; private set; }

	public static float SectionLoadingProgress { get; private set; }

	public bool LoadingEnabled => base.isActiveAndEnabled;

	public SectionData SectionData => _sectionData;

	public string LightingScenePath
	{
		get
		{
			return _lightingScene;
		}
		set
		{
			_lightingScene = value;
		}
	}

	public string LightingScene => Path.GetFileNameWithoutExtension(LightingScenePath);

	[Inject]
	public void Inject(PlayerController playerController)
	{
		_playerController = playerController;
	}

	private void Awake()
	{
		foreach (SectionData.LevelSectionData levelSection in _sectionData.levelSections)
		{
			LoadedSectionScene item = new LoadedSectionScene
			{
				sectionData = levelSection,
				loadStrategy = CreateLoadStrategy(levelSection.sceneName)
			};
			_loadedSectionScenes.Add(item);
		}
		IsBusy = true;
		SectionLoadingProgress = 0f;
	}

	private void Start()
	{
		PlayerController playerController = _playerController;
		playerController.OnPlayerTeleport = (Action)Delegate.Combine(playerController.OnPlayerTeleport, new Action(PlayerController_OnPlayerTeleport));
		UpdateLoadRequirement();
		if (!string.IsNullOrEmpty(LightingScene))
		{
			SceneManager.LoadScene(LightingScene, LoadSceneMode.Additive);
			SceneManager.sceneLoaded += CheckForLightingScene;
		}
	}

	private void OnDestroy()
	{
		PlayerController playerController = _playerController;
		playerController.OnPlayerTeleport = (Action)Delegate.Remove(playerController.OnPlayerTeleport, new Action(PlayerController_OnPlayerTeleport));
		SceneManager.sceneLoaded -= CheckForLightingScene;
		IsBusy = false;
		SectionLoadingProgress = 1f;
	}

	private void Update()
	{
		UpdateLoadRequirement();
	}

	private void PlayerController_OnPlayerTeleport()
	{
		UpdateLoadRequirement();
	}

	private void UpdateLoadRequirement()
	{
		if (!LoadingEnabled)
		{
			return;
		}
		Vector3 playerPosition = _playerController.PlayerPosition;
		float sqrLoadDistance = Mathf.Max(0.01f, _loadDistance * _loadDistance);
		if (_playerController.IsRagdollState)
		{
			playerPosition = _playerController.PlayerIkController.PelvisBone.position;
		}
		IsBusy = false;
		int num = 0;
		float num2 = 0f;
		foreach (LoadedSectionScene loadedSectionScene in _loadedSectionScenes)
		{
			if (!_playerController.SceneNameCollidersToIgnore.Contains(loadedSectionScene.sectionData.sceneName))
			{
				loadedSectionScene.UpdateLoadRequirement(playerPosition, sqrLoadDistance);
				loadedSectionScene.Update();
				IsBusy |= loadedSectionScene.IsBusy;
				if (loadedSectionScene.IsBusy)
				{
					num++;
					num2 += loadedSectionScene.Progress;
				}
			}
		}
		if (IsBusy)
		{
			if (_prevLoadingSectionCount < num)
			{
				_prevLoadingSectionCount = num;
			}
		}
		else
		{
			_prevLoadingSectionCount = 0;
		}
		if (_prevLoadingSectionCount > 0)
		{
			SectionLoadingProgress = num2 / (float)_prevLoadingSectionCount;
		}
		else
		{
			SectionLoadingProgress = 1f;
		}
	}

	private ISectionLoadStrategy CreateLoadStrategy(string sceneName)
	{
		return new AddressableSectionLoadStrategy(sceneName, showDebug);
	}

	private void CheckForLightingScene(Scene scene, LoadSceneMode mode)
	{
		if (scene.name == LightingScene)
		{
			SceneManager.SetActiveScene(scene);
		}
	}

	private void OnDrawGizmosSelected()
	{
		LevelSection[] array = UnityEngine.Object.FindObjectsOfType<LevelSection>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].DrawBounds();
		}
	}
}
