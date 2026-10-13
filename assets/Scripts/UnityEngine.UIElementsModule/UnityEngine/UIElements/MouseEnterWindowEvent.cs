namespace UnityEngine.UIElements;

[EventCategory(EventCategory.EnterLeaveWindow)]
public class MouseEnterWindowEvent : MouseEventBase<MouseEnterWindowEvent>
{
	static MouseEnterWindowEvent()
	{
		EventBase<MouseEnterWindowEvent>.SetCreateFunction(() => new MouseEnterWindowEvent());
	}

	protected override void Init()
	{
		base.Init();
		LocalInit();
	}

	private void LocalInit()
	{
		base.propagation = EventPropagation.Bubbles;
	}

	public MouseEnterWindowEvent()
	{
		LocalInit();
	}

	protected internal override void PostDispatch(IPanel panel)
	{
		EventBase eventBase = ((IMouseEventInternal)this).sourcePointerEvent as EventBase;
		if (eventBase == null)
		{
			(panel as BaseVisualElementPanel)?.CommitElementUnderPointers();
		}
		base.PostDispatch(panel);
	}

	internal override void Dispatch(BaseVisualElementPanel panel)
	{
		EventDispatchUtilities.DispatchToElementUnderPointerOrPanelRoot(this, panel, PointerId.mousePointerId, base.mousePosition);
	}
}
