namespace UnityEngine.UIElements;

public sealed class PointerCancelEvent : PointerEventBase<PointerCancelEvent>
{
	static PointerCancelEvent()
	{
		EventBase<PointerCancelEvent>.SetCreateFunction(() => new PointerCancelEvent());
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

	public PointerCancelEvent()
	{
		LocalInit();
	}

	protected internal override void PreDispatch(IPanel panel)
	{
		base.PreDispatch(panel);
		if (panel.ShouldSendCompatibilityMouseEvents(this))
		{
			((IPointerEventInternal)this).compatibilityMouseEvent = MouseUpEvent.GetPooled(this);
		}
	}

	protected internal override void PostDispatch(IPanel panel)
	{
		panel.dispatcher.m_ClickDetector.ProcessEvent(this);
		if (PointerType.IsDirectManipulationDevice(base.pointerType))
		{
			panel.ReleasePointer(base.pointerId);
			if (panel is BaseVisualElementPanel baseVisualElementPanel)
			{
				baseVisualElementPanel.ClearCachedElementUnderPointer(base.pointerId, this);
			}
		}
		base.PostDispatch(panel);
		panel.ActivateCompatibilityMouseEvents(base.pointerId);
	}
}
