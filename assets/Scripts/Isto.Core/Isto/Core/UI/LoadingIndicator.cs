using System;
using Isto.Core.Game;
using UnityEngine;
using Zenject;

namespace Isto.Core.UI;

public class LoadingIndicator : MonoBehaviour
{
	private bool _callbacksRegistered;

	private GameState _gameState;

	[Inject]
	public void Inject(GameState gameState)
	{
		_gameState = gameState;
	}

	private void Awake()
	{
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
			Events.Subscribe("GameStartFadeIn", OnLoadComplete);
			_callbacksRegistered = true;
		}
	}

	private void UnregisterCallbacks()
	{
		if (_callbacksRegistered)
		{
			Events.UnSubscribe("GameStartFadeIn", OnLoadComplete);
			_callbacksRegistered = false;
		}
	}

	private void OnLoadComplete(object sender, EventArgs e)
	{
		OnLoadComplete();
	}

	private void OnLoadComplete()
	{
		if (!(this == null) && !(base.gameObject == null))
		{
			UnregisterCallbacks();
			base.gameObject.SetActive(value: false);
		}
	}
}
