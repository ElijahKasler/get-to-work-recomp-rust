namespace UnityEngine.UIElements;

internal interface IPointerEventInternal
{
	bool triggeredByOS { get; set; }

	IMouseEvent compatibilityMouseEvent { get; set; }

	int displayIndex { get; set; }
}
