namespace Isto.Core;

public class OrderedEvent
{
	public delegate void GameEvent();

	public int priority;

	public GameEvent callback;

	public OrderedEvent(GameEvent del, int order)
	{
		callback = del;
		priority = order;
	}
}
