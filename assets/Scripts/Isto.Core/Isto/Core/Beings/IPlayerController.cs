using Isto.Core.StateMachine;
using UnityEngine;

namespace Isto.Core.Beings;

public interface IPlayerController
{
	bool IsMoving { get; }

	void SetPlayerColliderState(bool state);

	void DisableAllPlayerControls(float time);

	void EnablePlayerControls();

	void SetPlayerPauseState(bool paused, float resetTime = 0f);

	void SetMovementEnabled(bool active);

	void ChangeToMoveState();

	void ChangeToCustomState(State state);

	void Respawn();

	Vector3 GetPlayerPosition();

	void SetPlayerPosition(Vector3 pos);
}
