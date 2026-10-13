using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using Isto.Core.Analytics;
using Isto.Core.Automation;
using Isto.Core.Configuration;
using Isto.Core.Data;
using Isto.Core.Localization;
using Isto.Core.Platforms;
using Isto.Core.Scenes;
using Isto.Core.Themes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Isto.Core.Game;

public class GameState : MonoBehaviour
{
	public TimeStepSetup timeStepSetup;

	public SceneSettingMappings settingsMapping;

	public VersionInfo version;

	public LocalizedString defaultSlotNameKey;

	[Header("Loading steps loc")]
	[SerializeField]
	[SearchableLocalizedString]
	protected LocalizedString _loadingLoadingScreenLoc;

	[SerializeField]
	[SearchableLocalizedString]
	protected LocalizedString _warningIncomingGameLoc;

	[SerializeField]
	[SearchableLocalizedString]
	protected LocalizedString _ConfiguringGameLoc;

	[SerializeField]
	[SearchableLocalizedString]
	protected LocalizedString _LoadingEssentialStuffLoc;

	[SerializeField]
	[SearchableLocalizedString]
	protected LocalizedString _LoadingStartingAreaLoc;

	[SerializeField]
	[SearchableLocalizedString]
	protected LocalizedString _LoadingLevelSectionsAndCoolingDownIkLoc;

	[SerializeField]
	[SearchableLocalizedString]
	protected LocalizedString _UnloadingLoadingScreenLoc;

	[SerializeField]
	[SearchableLocalizedString]
	protected LocalizedString _BeginHappyFunTimeLoc;

	protected int _saveSlot;

	protected string _currentEssentialScene;

	protected string _currentStartingAreaScene;

	protected List<GameObject> _rootObjectsBuffer = new List<GameObject>();

	protected List<IDataLoadCompleteHandler> _loadCompleteListenersBuffer = new List<IDataLoadCompleteHandler>();

	protected GameStateSaveData _selectedSaveSlotMetaData;

	private int _loadedGameSlotNumber;

	private GameStateDataManager _gameStateDataManager;

	private GameModeDefinition _currentGameMode;

	private bool _mainSceneLoaded;

	private bool _essentialSceneActive;

	private IGameData _gameData;

	private IAnalyticsHandler _analytics;

	protected ThemeManager _themeManager;

	protected GameScenesReference _coreGameScenesReference;

	public static bool CurrentlyLoading { get; private set; }

	public static float LoadProgress { get; private set; }

	public static string LoadingStep { get; private set; }

	public static bool LoadingFromSave { get; private set; }

	public static bool WaitingForSaveFileLoad { get; set; }

	public static bool PoolsInitialized { get; set; } = true;

	public static bool AutomationSystemCanStart { get; set; }

	public static bool GameDataLoaded { get; set; }

	public static bool StoryAnimationActive { get; set; }

	public static bool GameModeLoadedFromGameState { get; private set; }

	public GameStateSaveData CurrentSaveMetaData => _selectedSaveSlotMetaData;

	public GameModeDefinition CurrentGameMode
	{
		get
		{
			return _currentGameMode;
		}
		set
		{
			_currentGameMode = value;
			if (value != null)
			{
				_analytics?.RegisterGameModeSelected(value);
			}
		}
	}

	public IGameProgressProvider GameProgressProvider { get; set; }

	public event EventHandler LoadComplete;

	[Inject]
	public void Inject(IGameData gameData, IAnalyticsHandler analytics, GameScenesReference gameScenesReference, ThemeManager themeManager)
	{
		_gameData = gameData;
		_analytics = analytics;
		_coreGameScenesReference = gameScenesReference;
		_themeManager = themeManager;
	}

	public virtual void Awake()
	{
		_currentEssentialScene = _coreGameScenesReference.EssentialsScene;
		_currentStartingAreaScene = _coreGameScenesReference.StartingAreaScene;
		_gameStateDataManager = GetComponent<GameStateDataManager>();
		TimeStepSetup.PlatformSpecificSettings platformSpecificSettings = timeStepSetup.settings.Where((TimeStepSetup.PlatformSpecificSettings x) => x.platform == Application.platform).FirstOrDefault();
		if (platformSpecificSettings != null)
		{
			Time.fixedDeltaTime = platformSpecificSettings.fixedTimeStep;
		}
	}

	public void OnEnable()
	{
		RegisterEvents();
	}

	public void OnDisable()
	{
		UnregisterEvents();
	}

	private void RegisterEvents()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
		SceneManager.activeSceneChanged += OnSceneChanged;
	}

	private void UnregisterEvents()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
		SceneManager.activeSceneChanged -= OnSceneChanged;
	}

	private void OnSceneLoaded(Scene newScene, LoadSceneMode arg1)
	{
		_ = SceneManager.sceneCount;
		if (IsStartingAreaSceneLoaded(newScene))
		{
			_mainSceneLoaded = true;
			if (_essentialSceneActive)
			{
				LoadData();
			}
		}
	}

	private void OnSceneChanged(Scene oldScene, Scene newScene)
	{
		if (IsEssentialScene(newScene))
		{
			_essentialSceneActive = true;
			if (_mainSceneLoaded)
			{
				LoadData();
			}
		}
	}

	private bool IsStartingAreaSceneLoaded(Scene newScene)
	{
		if (!newScene.isLoaded)
		{
			return false;
		}
		return SceneHasParentContract(newScene);
	}

	protected virtual bool IsEssentialScene(Scene newScene)
	{
		return newScene.name == _coreGameScenesReference.EssentialsScene;
	}

	private bool SceneHasParentContract(Scene scene)
	{
		scene.GetRootGameObjects(_rootObjectsBuffer);
		for (int i = 0; i < _rootObjectsBuffer.Count; i++)
		{
			if (_rootObjectsBuffer[i].TryGetComponent<SceneContext>(out var component) && component.ParentContractNames.Count() > 0)
			{
				return true;
			}
		}
		return false;
	}

	private void LoadData()
	{
		_mainSceneLoaded = false;
		_essentialSceneActive = false;
		if (LoadingFromSave)
		{
			_gameData.LoadGameData(_saveSlot, (bool success) =>
			{
				WaitingForSaveFileLoad = false;
				if (!success)
				{
					Debug.LogError("LoadGameData failed");
				}
			});
		}
		else
		{
			WaitingForSaveFileLoad = false;
		}
		StartCoroutine(WaitForInitializationAndSendEvents());
	}

	private IEnumerator WaitForInitializationAndSendEvents()
	{
		AutomationSystemCanStart = false;
		bool gameSystemsInitialized;
		do
		{
			gameSystemsInitialized = PoolsInitialized && !CurrentlyLoading;
			yield return new WaitForSeconds(0.1f);
		}
		while (!gameSystemsInitialized);
		SendLoadCompleteEvent();
		LoadComplete?.Invoke(this, EventArgs.Empty);
		yield return new WaitForSeconds(1f);
		GameDataLoaded = true;
		yield return null;
		AutomationSystemCanStart = true;
	}

	private void SendLoadCompleteEvent()
	{
		int sceneCount = SceneManager.sceneCount;
		for (int i = 0; i < sceneCount; i++)
		{
			SceneManager.GetSceneAt(i).GetRootGameObjects(_rootObjectsBuffer);
			int count = _rootObjectsBuffer.Count;
			for (int j = 0; j < count; j++)
			{
				_rootObjectsBuffer[j].GetComponentsInChildren(includeInactive: true, _loadCompleteListenersBuffer);
				int count2 = _loadCompleteListenersBuffer.Count;
				for (int k = 0; k < count2; k++)
				{
					_loadCompleteListenersBuffer[k].OnDataLoadComplete();
				}
			}
		}
		((IDataLoadCompleteHandler)UnityEngine.Object.FindAnyObjectByType<PCGameData>())?.OnDataLoadComplete();
		UnityEngine.Object.FindObjectOfType<AutomationSystemDisplay>()?.RefreshVisibleItems();
	}

	public void LoadTitleScene()
	{
		SceneManager.LoadScene(_coreGameScenesReference.TitleScreen);
	}

	public bool IsInTitleScene()
	{
		return SceneManager.GetActiveScene().name == _coreGameScenesReference.TitleScreen;
	}

	public bool IsGameModeSceneActiveOrLoading(string sceneName)
	{
		return _currentStartingAreaScene == sceneName;
	}

	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public void ReloadGame()
	{
		if (!CurrentlyLoading)
		{
			CurrentlyLoading = true;
			LoadProgress = 0f;
			_gameData.HasAnySaveData((bool hasData) =>
			{
				StartCoroutine(StartGameRoutine(_coreGameScenesReference.EssentialsScene, _coreGameScenesReference.StartingAreaScene, hasData));
			});
		}
	}

	public virtual void RestartGame()
	{
		if (!CurrentlyLoading)
		{
			StartCoroutine(StartGameRoutine(_currentEssentialScene, _currentStartingAreaScene, loadFromSaveData: false));
		}
	}

	public void ExitIntro()
	{
		if (!CurrentlyLoading)
		{
			StartCoroutine(StartGameRoutine(_coreGameScenesReference.EssentialsScene, _coreGameScenesReference.StartingAreaScene, loadFromSaveData: false));
		}
	}

	public void SelectSaveGame(int saveSlot)
	{
		if (!CurrentlyLoading)
		{
			_saveSlot = saveSlot;
		}
	}

	public void LoadSaveGame(int saveSlot)
	{
		if (!CurrentlyLoading)
		{
			Time.timeScale = 1f;
			_saveSlot = saveSlot;
			CurrentlyLoading = true;
			LoadProgress = 0f;
			_gameData.HasSaveData(saveSlot, (bool has) =>
			{
				StartCoroutine(StartGameRoutine(_coreGameScenesReference.EssentialsScene, _coreGameScenesReference.StartingAreaScene, has));
			});
		}
	}

	public void StartGameMode(GameModeDefinition gameMode)
	{
		if (CurrentlyLoading)
		{
			return;
		}
		CurrentGameMode = gameMode;
		Time.timeScale = 1f;
		if (!CurrentGameMode.ShowIntroCutscene || !StartIntroScene())
		{
			if (!settingsMapping.TryGetScene(CurrentGameMode, out var sceneSettings))
			{
				Debug.LogWarning("Game Mode " + CurrentGameMode.InternalName + " not mapped to a scene... defaulting to scene \"" + sceneSettings.sceneName + "\".");
			}
			StartCoroutine(StartGameRoutine(sceneSettings.parentSceneName, sceneSettings.sceneName, loadFromSaveData: false));
		}
	}

	public virtual bool StartIntroScene()
	{
		return false;
	}

	public void LoadSaveSlotMetaData(int saveSlot, Action<bool> onLoaded)
	{
		_gameStateDataManager.PreLoad(saveSlot, (GameStateSaveData gameStateData) =>
		{
			LoadGameStateData(gameStateData, saveSlot);
			onLoaded?.Invoke(gameStateData != null);
		});
	}

	public void UpdateSaveSlotMetaData(int saveSlot, GameStateSaveData updatedData, Action<bool> onSaved)
	{
		_gameStateDataManager.PreSave(saveSlot, updatedData, onSaved);
	}

	public IEnumerator StartGameRoutine(string essentialSceneName, string startingAreaSceneName, bool loadFromSaveData)
	{
		GameModeLoadedFromGameState = true;
		GameDataLoaded = false;
		CurrentlyLoading = true;
		LoadProgress = 0.05f;
		LoadingStep = "1." + (string.IsNullOrEmpty(_loadingLoadingScreenLoc.mTerm) ? "Loading Loading Scene" : Loc.Get(_loadingLoadingScreenLoc));
		WaitingForSaveFileLoad = true;
		_mainSceneLoaded = false;
		_essentialSceneActive = false;
		_currentEssentialScene = essentialSceneName;
		_currentStartingAreaScene = startingAreaSceneName;
		LoadingFromSave = loadFromSaveData;
		AsyncOperation loadingSceneOp = SceneManager.LoadSceneAsync(_coreGameScenesReference.LoadingScreen);
		while (!loadingSceneOp.isDone)
		{
			LoadProgress = 0.05f + loadingSceneOp.progress * 0.05f;
			yield return null;
		}
		LoadProgress = 0.1f;
		LoadingStep = "2." + (string.IsNullOrEmpty(_warningIncomingGameLoc.mTerm) ? "Warning: Incoming Game" : Loc.Get(_warningIncomingGameLoc));
		for (float timer = 5f; timer > 0f; timer -= Time.deltaTime)
		{
			float num = (5f - timer) * 0.2f;
			LoadProgress = 0.1f + num * 0.3f;
			yield return null;
		}
		LoadProgress = 0.4f;
		LoadingStep = "3." + (string.IsNullOrEmpty(_ConfiguringGameLoc.mTerm) ? "Configuring Game" : Loc.Get(_ConfiguringGameLoc));
		if (LoadingFromSave)
		{
			if (_selectedSaveSlotMetaData == null || string.IsNullOrEmpty(_selectedSaveSlotMetaData.gameModeName) || _selectedSaveSlotMetaData.gameModeName == "---")
			{
				Debug.LogError("Loading Game State: no game mode name found in GameStateSaveData");
			}
			else
			{
				IEnumerable<SceneSettingMappings.Mappping> source = settingsMapping.settingsMappings.Where((SceneSettingMappings.Mappping x) => x.gameMode.InternalName == _selectedSaveSlotMetaData.gameModeName && !x.sandboxUseOnly);
				if (source.Count() == 1)
				{
					CurrentGameMode = source.First().gameMode;
				}
				else
				{
					Debug.LogError($"Loading Game State: Could not setup game mode {_selectedSaveSlotMetaData.gameModeName} ({source.Count()} matching items found in settingsMapping), Setting First Found Mode");
					CurrentGameMode = source.First().gameMode;
				}
			}
			if (!settingsMapping.TryGetScene(CurrentGameMode, out var sceneSettings))
			{
				Debug.LogWarning("Game Mode " + (CurrentGameMode?.InternalName ?? "(null)") + " not mapped to a scene... defaulting to scene \"" + sceneSettings.sceneName + "\".");
			}
			_currentStartingAreaScene = sceneSettings.sceneName;
			_currentEssentialScene = sceneSettings.parentSceneName;
		}
		for (float timer = 0.5f; timer > 0f; timer -= Time.deltaTime)
		{
			float num2 = (0.5f - timer) * 2f;
			LoadProgress = 0.4f + num2 * 0.1f;
			yield return null;
		}
		LoadProgress = 0.5f;
		LoadingStep = "4." + (string.IsNullOrEmpty(_LoadingEssentialStuffLoc.mTerm) ? "Loading Essential Stuff" : Loc.Get(_LoadingEssentialStuffLoc));
		AsyncOperation loadBlockOp = SceneManager.LoadSceneAsync(_currentEssentialScene, LoadSceneMode.Additive);
		loadBlockOp.allowSceneActivation = false;
		while (loadBlockOp.progress < 0.9f)
		{
			LoadProgress = 0.5f + loadBlockOp.progress * 0.1f;
			yield return null;
		}
		LoadProgress = 0.6f;
		LoadingStep = "5." + (string.IsNullOrEmpty(_LoadingStartingAreaLoc.mTerm) ? "Loading Starting Area" : Loc.Get(_LoadingStartingAreaLoc));
		AsyncOperation loadMainOp = SceneManager.LoadSceneAsync(_currentStartingAreaScene, LoadSceneMode.Additive);
		loadMainOp.allowSceneActivation = false;
		while (loadMainOp.progress < 0.9f)
		{
			LoadProgress = 0.6f + loadMainOp.progress * 0.15f;
			yield return null;
		}
		loadBlockOp.allowSceneActivation = true;
		loadMainOp.allowSceneActivation = true;
		while (!loadMainOp.isDone)
		{
			LoadProgress = 0.6f + loadMainOp.progress * 0.15f;
			yield return null;
		}
		LoadProgress = 0.75f;
		LoadingStep = "6." + (string.IsNullOrEmpty(_LoadingLevelSectionsAndCoolingDownIkLoc.mTerm) ? "Loading Level Sections and Cooling Down IK" : Loc.Get(_LoadingLevelSectionsAndCoolingDownIkLoc));
		SceneManager.SetActiveScene(SceneManager.GetSceneByName(_currentEssentialScene));
		StartCoroutine(FinalizeLoading());
		float finalizeLoadingOperationProgress;
		do
		{
			finalizeLoadingOperationProgress = GetFinalizeProgress();
			LoadProgress = 0.75f + finalizeLoadingOperationProgress * 0.15f;
			yield return null;
		}
		while (finalizeLoadingOperationProgress <= 0.99f);
		LoadProgress = 0.9f;
		LoadingStep = "7." + (string.IsNullOrEmpty(_UnloadingLoadingScreenLoc.mTerm) ? "Unloading Loading Screen" : Loc.Get(_UnloadingLoadingScreenLoc));
		AsyncOperation unloadOp = SceneManager.UnloadSceneAsync(_coreGameScenesReference.LoadingScreen);
		while (unloadOp.progress < 0.9f)
		{
			LoadProgress = 0.9f + unloadOp.progress * 0.1f;
			yield return null;
		}
		CurrentlyLoading = false;
		LoadProgress = 1f;
		LoadingStep = "8." + (string.IsNullOrEmpty(_BeginHappyFunTimeLoc.mTerm) ? "Begin Happy Fun Time" : Loc.Get(_BeginHappyFunTimeLoc));
	}

	protected virtual IEnumerator FinalizeLoading()
	{
		yield return null;
	}

	protected virtual float GetFinalizeProgress()
	{
		return 1f;
	}

	public void LoadGameStateData(GameStateSaveData data, int saveSlot)
	{
		_selectedSaveSlotMetaData = data;
		_loadedGameSlotNumber = saveSlot;
	}

	public virtual GameStateSaveData SaveGameStateData()
	{
		GameStateSaveData gameStateSaveData = new GameStateSaveData();
		gameStateSaveData.isAutoSave = false;
		gameStateSaveData.saveSlotName = $"{Loc.Get(defaultSlotNameKey)}{_saveSlot}";
		if (_selectedSaveSlotMetaData != null)
		{
			gameStateSaveData.saveSlotName = _selectedSaveSlotMetaData.saveSlotName;
		}
		if (CurrentGameMode != null)
		{
			gameStateSaveData.gameModeName = CurrentGameMode.InternalName;
		}
		else
		{
			Debug.LogWarning("Saving Game State: no game mode configured, it will be missing in the save file.");
		}
		gameStateSaveData.gameVersion = version.ActiveVersion.VersionText;
		gameStateSaveData.internalBuildVersion = version.ActiveVersion.shortDate;
		IGameProgressProvider gameProgressProvider = GameProgressProvider;
		if (gameProgressProvider != null)
		{
			gameStateSaveData.totalGameTimeSeconds = gameProgressProvider.GetTotalGameSecondsElapsedInPlaythrough();
		}
		else
		{
			gameStateSaveData.totalGameTimeSeconds = 0f;
		}
		gameStateSaveData.saveDate = DateTime.Now;
		gameStateSaveData.autoSaveDates = new List<DateTime>();
		gameStateSaveData.themeData = _themeManager.GetData();
		return gameStateSaveData;
	}

	public bool IsCurrentlyLoadedSaveGame(GameStateSaveData data, int saveSlot)
	{
		if (_selectedSaveSlotMetaData == null)
		{
			return false;
		}
		if (_loadedGameSlotNumber == saveSlot && data.saveSlotName == _selectedSaveSlotMetaData.saveSlotName)
		{
			return true;
		}
		return false;
	}
}
