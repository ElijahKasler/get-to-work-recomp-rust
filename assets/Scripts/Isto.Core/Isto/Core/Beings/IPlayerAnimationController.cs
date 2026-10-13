using System;

namespace Isto.Core.Beings;

public interface IPlayerAnimationController
{
	event Action<string> AnimationComplete;

	AnimationController.CharacterDirections GetFacing();

	string GetHarvestWarmupAnimationName();

	void StopHarvestAnimation();

	void StartHarvestAnimation();
}
