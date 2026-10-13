namespace UnityEngine.UIElements;

internal interface IMouseEventInternal
{
	bool triggeredByOS { get; set; }

	IPointerEvent sourcePointerEvent { get; set; }
}
