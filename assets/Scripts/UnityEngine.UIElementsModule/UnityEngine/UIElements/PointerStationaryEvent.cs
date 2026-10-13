using System;

namespace UnityEngine.UIElements;

[Obsolete("Not sent by input backend.")]
public sealed class PointerStationaryEvent : PointerEventBase<PointerStationaryEvent>
{
	static PointerStationaryEvent()
	{
		EventBase<PointerStationaryEvent>.SetCreateFunction(() => new PointerStationaryEvent());
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
	}

	public PointerStationaryEvent()
	{
		LocalInit();
	}
}
