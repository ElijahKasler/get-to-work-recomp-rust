using System;

namespace Isto.Core.Beings;

public class AnimationChangedEventArgs : EventArgs
{
	public AnimationController.CharacterDirections previousDirection;

	public AnimationController.CharacterDirections newDirection;
}
