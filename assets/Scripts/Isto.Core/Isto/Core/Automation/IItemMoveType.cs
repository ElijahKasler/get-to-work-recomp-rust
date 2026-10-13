namespace Isto.Core.Automation;

public interface IItemMoveType
{
	bool Complete { get; }

	void Tick(float deltaTime);

	void Cancel();
}
