using Isto.Core.StateMachine;

namespace Isto.Core.Beings;

public abstract class PlayerAbilityState : State
{
	public abstract bool IsReadyToActivate();

	public abstract void OnEquipped();

	public abstract void OnUnequipped();
}
