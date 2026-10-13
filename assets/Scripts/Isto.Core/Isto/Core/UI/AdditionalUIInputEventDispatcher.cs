using Isto.Core.Inputs;
using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Isto.Core.UI;

public class AdditionalUIInputEventDispatcher : MonoBehaviour
{
	private Player _player;

	private int playerID = Controls.DEFAULT_REWIRED_PLAYER_ID;

	private void Awake()
	{
		_player = ReInput.players.GetPlayer(playerID);
	}

	private void Update()
	{
		if (_player.GetAnyButtonDown())
		{
			GetComponentOfType<IAnyInputButtonDown>()?.OnAnyInputButtonDown();
		}
		if (_player.GetAnyButtonUp())
		{
			GetComponentOfType<IAnyInputButtonUp>()?.OnAnyInputButtonUp();
		}
	}

	private T GetComponentOfType<T>() where T : class
	{
		if (EventSystem.current.currentSelectedGameObject != null)
		{
			return EventSystem.current.currentSelectedGameObject.GetComponent(typeof(T)) as T;
		}
		return null;
	}
}
