using Isto.Core.Game;
using Isto.Core.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Isto.Core.Automation;

public class AutomationSystemController : MonoBehaviour
{
	[SerializeField]
	private float _timePerTick = 0.1f;

	[Tooltip("Scales the time per tick by this amount to make game time run faster or slower")]
	[SerializeField]
	private float _timeFactor = 1f;

	private float _tickTimer;

	private AutomationSystem _system;

	private GameScenesReference _gameScenesReference;

	public AutomationSystem System => _system;

	public bool SystemPaused { get; private set; }

	[Inject]
	public void Inject(AutomationSystem automationSystem, GameScenesReference gameScenesReference)
	{
		_system = automationSystem;
		_gameScenesReference = gameScenesReference;
	}

	private void OnEnable()
	{
		RegisterEvents();
	}

	private void OnDisable()
	{
		UnregisterEvents();
	}

	public void Update()
	{
		if (GameState.GameDataLoaded && !SystemPaused && GameState.AutomationSystemCanStart)
		{
			_tickTimer += Time.deltaTime;
			if (_tickTimer >= _timePerTick)
			{
				float num = ((_timePerTick > 0f) ? _timePerTick : Time.deltaTime);
				_system.TickSystem(num * _timeFactor);
				_tickTimer -= _timePerTick;
			}
		}
	}

	private void RegisterEvents()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
		SceneManager.sceneUnloaded += OnSceneUnloaded;
	}

	private void UnregisterEvents()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
		SceneManager.sceneUnloaded -= OnSceneUnloaded;
	}

	private void OnSceneLoaded(Scene newScene, LoadSceneMode sceneMode)
	{
		if (_gameScenesReference.IsDialogueScene(newScene.name))
		{
			SystemPaused = true;
		}
	}

	private void OnSceneUnloaded(Scene unloadedScene)
	{
		if (_gameScenesReference.IsDialogueScene(unloadedScene.name))
		{
			SystemPaused = false;
		}
	}

	public void SetTickFactor(float factor)
	{
		_timeFactor = factor;
	}

	public void PauseSystem()
	{
		SystemPaused = true;
	}

	public void UnPauseSystem()
	{
		SystemPaused = false;
	}
}
