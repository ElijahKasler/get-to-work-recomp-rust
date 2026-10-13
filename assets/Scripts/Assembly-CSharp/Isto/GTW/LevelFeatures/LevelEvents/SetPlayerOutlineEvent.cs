using Isto.GTW.Player;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class SetPlayerOutlineEvent : LevelEvent
{
	[SerializeField]
	private bool _outlineActive = true;

	private PlayerController _playerController;

	[Inject]
	public void Inject(PlayerController playerController)
	{
		_playerController = playerController;
	}

	public override void TriggerEvent(bool initialization = false)
	{
		if (_outlineActive != _playerController.PlayerModelController.OutlineShader.enabled)
		{
			_playerController.PlayerModelController.OutlineShader.enabled = _outlineActive;
		}
	}
}
