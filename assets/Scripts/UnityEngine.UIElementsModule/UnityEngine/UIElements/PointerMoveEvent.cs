namespace UnityEngine.UIElements;

[EventCategory(EventCategory.PointerMove)]
public sealed class PointerMoveEvent : PointerEventBase<PointerMoveEvent>
{
	internal bool isHandledByDraggable { get; set; }

	internal bool isPointerUpDown => base.button >= 0;

	internal bool isPointerDown => base.button >= 0 && (base.pressedButtons & (1 << base.button)) != 0;

	internal bool isPointerUp => base.button >= 0 && (base.pressedButtons & (1 << base.button)) == 0;

	static PointerMoveEvent()
	{
		EventBase<PointerMoveEvent>.SetCreateFunction(() => new PointerMoveEvent());
	}

	protected override void Init()
	{
		base.Init();
		LocalInit();
	}

	private void LocalInit()
	{
		base.propagation = EventPropagation.BubblesOrTricklesDown;
		((IPointerEventInternal)this).triggeredByOS = true;
		isHandledByDraggable = false;
	}

	public PointerMoveEvent()
	{
		LocalInit();
	}

	protected internal override void PreDispatch(IPanel panel)
	{
		base.PreDispatch(panel);
		if (panel.ShouldSendCompatibilityMouseEvents(this))
		{
			if (base.imguiEvent != null && base.imguiEvent.rawType == EventType.MouseDown)
			{
				((IPointerEventInternal)this).compatibilityMouseEvent = MouseDownEvent.GetPooled(this);
			}
			else if (base.imguiEvent != null && base.imguiEvent.rawType == EventType.MouseUp)
			{
				((IPointerEventInternal)this).compatibilityMouseEvent = MouseUpEvent.GetPooled(this);
			}
			else
			{
				((IPointerEventInternal)this).compatibilityMouseEvent = MouseMoveEvent.GetPooled(this);
			}
		}
	}

	protected internal override void PostDispatch(IPanel panel)
	{
		panel.dispatcher.m_ClickDetector.ProcessEvent(this);
		base.PostDispatch(panel);
	}
}
