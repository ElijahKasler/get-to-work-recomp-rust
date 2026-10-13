namespace UnityEngine.UIElements;

[EventCategory(EventCategory.PointerDown)]
public sealed class PointerDownEvent : PointerEventBase<PointerDownEvent>
{
	static PointerDownEvent()
	{
		EventBase<PointerDownEvent>.SetCreateFunction(() => new PointerDownEvent());
	}

	protected override void Init()
	{
		base.Init();
		LocalInit();
	}

	private void LocalInit()
	{
		base.propagation = EventPropagation.BubblesOrTricklesDown | EventPropagation.SkipDisabledElements;
		((IPointerEventInternal)this).triggeredByOS = true;
	}

	public PointerDownEvent()
	{
		LocalInit();
	}

	protected internal override void PreDispatch(IPanel panel)
	{
		base.PreDispatch(panel);
		if (panel.ShouldSendCompatibilityMouseEvents(this))
		{
			((IPointerEventInternal)this).compatibilityMouseEvent = MouseDownEvent.GetPooled(this);
		}
	}

	protected internal override void PostDispatch(IPanel panel)
	{
		panel.focusController.SwitchFocusOnEvent(panel.focusController.GetLeafFocusedElement(), this);
		panel.dispatcher.m_ClickDetector.ProcessEvent(this);
		base.PostDispatch(panel);
	}
}
