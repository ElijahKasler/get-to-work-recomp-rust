namespace Isto.Core.StateMachine;

public interface IStateExitResult
{
	public enum ResultType
	{
		Submit = 0,
		Cancelled = 1,
		Error = 2
	}

	ResultType Result { get; }
}
