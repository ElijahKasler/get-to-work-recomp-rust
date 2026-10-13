namespace Isto.Core;

public class OrderedParamEvent
{
	public delegate void ParamGameEvent(params object[] args);

	public int priority;

	public ParamGameEvent callback;

	public OrderedParamEvent(ParamGameEvent del, int order)
	{
		callback = del;
		priority = order;
	}
}
