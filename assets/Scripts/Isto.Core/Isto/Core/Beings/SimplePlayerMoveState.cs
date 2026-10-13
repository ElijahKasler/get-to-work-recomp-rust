using Isto.Core.StateMachine;
using UnityEngine;

namespace Isto.Core.Beings;

[CreateAssetMenu(fileName = "SimpleCorePlayerState", menuName = "Scriptables/State/Simple Core Player State")]
public class SimplePlayerMoveState : State
{
	private SimplePlayerController _playerController;

	public override void Enter(ScriptableStateMachine controller)
	{
		_playerController = controller as SimplePlayerController;
	}

	public override IState Run(ScriptableStateMachine controller)
	{
		Vector2 inputs = _playerController.GetInputs();
		Vector3 vector = new Vector3(inputs.x, inputs.y, 0f) * Time.deltaTime * 20f;
		Vector3 playerPosition = _playerController.GetPlayerPosition() + vector;
		playerPosition.x = Mathf.Clamp(playerPosition.x, -20f, 20f);
		playerPosition.y = Mathf.Clamp(playerPosition.y, -20f, 20f);
		_playerController.SetPlayerPosition(playerPosition);
		return this;
	}

	public override void Exit(ScriptableStateMachine controller)
	{
	}
}
