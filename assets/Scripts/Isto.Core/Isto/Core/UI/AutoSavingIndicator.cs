using Isto.Core.Game;
using UnityEngine;
using Zenject;

namespace Isto.Core.UI;

public class AutoSavingIndicator : MonoBehaviour
{
	[SerializeField]
	private GameObject _visualsRoot;

	private bool _callbacksRegistered;

	private GameState _gameState;

	[Inject]
	public void Inject(GameState gameState)
	{
		_gameState = gameState;
	}

	private void Awake()
	{
		_visualsRoot.SetActive(value: false);
		RegisterCallbacks();
	}

	private void OnDestroy()
	{
		UnregisterCallbacks();
	}

	private void RegisterCallbacks()
	{
		if (!_callbacksRegistered)
		{
			Events.Subscribe("GameAutoSaving", OnAutoSaveBegin);
			Events.Subscribe("GameSaved", OnSaveComplete);
			_callbacksRegistered = true;
		}
	}

	private void UnregisterCallbacks()
	{
		if (_callbacksRegistered)
		{
			Events.UnSubscribe("GameAutoSaving", OnAutoSaveBegin);
			Events.UnSubscribe("GameSaved", OnSaveComplete);
			_callbacksRegistered = false;
		}
	}

	private void OnAutoSaveBegin()
	{
		ShowIcon();
	}

	private void OnSaveComplete()
	{
		HideIcon();
	}

	private void ShowIcon()
	{
		_visualsRoot.SetActive(value: true);
	}

	private void HideIcon()
	{
		_visualsRoot.SetActive(value: false);
	}
}
