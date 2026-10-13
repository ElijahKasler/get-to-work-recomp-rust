#define UNITY_ASSERTIONS
namespace UnityEngine.UIElements;

internal class ElementUnderPointer
{
	private VisualElement[] m_PendingTopElementUnderPointer = new VisualElement[PointerId.maxPointers];

	private VisualElement[] m_TopElementUnderPointer = new VisualElement[PointerId.maxPointers];

	private IPointerOrMouseEvent[] m_TriggerEvent = new IPointerOrMouseEvent[PointerId.maxPointers];

	private Vector2[] m_PickingPointerPositions = new Vector2[PointerId.maxPointers];

	private bool[] m_IsPickingPointerTemporaries = new bool[PointerId.maxPointers];

	internal VisualElement GetTopElementUnderPointer(int pointerId, out Vector2 pickPosition, out bool isTemporary)
	{
		pickPosition = m_PickingPointerPositions[pointerId];
		isTemporary = m_IsPickingPointerTemporaries[pointerId];
		return m_PendingTopElementUnderPointer[pointerId];
	}

	internal VisualElement GetTopElementUnderPointer(int pointerId)
	{
		return m_PendingTopElementUnderPointer[pointerId];
	}

	internal void SetElementUnderPointer(VisualElement newElementUnderPointer, int pointerId, Vector2 pointerPos)
	{
		Debug.Assert(pointerId >= 0, "SetElementUnderPointer expects pointerId >= 0");
		VisualElement visualElement = m_TopElementUnderPointer[pointerId];
		m_IsPickingPointerTemporaries[pointerId] = false;
		m_PickingPointerPositions[pointerId] = pointerPos;
		if (newElementUnderPointer != visualElement)
		{
			m_PendingTopElementUnderPointer[pointerId] = newElementUnderPointer;
			m_TriggerEvent[pointerId] = null;
		}
	}

	private Vector2 GetEventPointerPosition(EventBase triggerEvent)
	{
		if (triggerEvent is IPointerEvent pointerEvent)
		{
			return new Vector2(pointerEvent.position.x, pointerEvent.position.y);
		}
		if (!(triggerEvent is IMouseEvent { mousePosition: var mousePosition }))
		{
			return new Vector2(float.MinValue, float.MinValue);
		}
		return mousePosition;
	}

	internal void SetTemporaryElementUnderPointer(VisualElement newElementUnderPointer, int pointerId, EventBase triggerEvent)
	{
		SetElementUnderPointer(newElementUnderPointer, pointerId, triggerEvent, temporary: true);
	}

	internal void SetElementUnderPointer(VisualElement newElementUnderPointer, int pointerId, EventBase triggerEvent)
	{
		SetElementUnderPointer(newElementUnderPointer, pointerId, triggerEvent, temporary: false);
	}

	private void SetElementUnderPointer(VisualElement newElementUnderPointer, int pointerId, EventBase triggerEvent, bool temporary)
	{
		Debug.Assert(pointerId >= 0, "SetElementUnderPointer expects pointerId >= 0");
		m_IsPickingPointerTemporaries[pointerId] = temporary;
		m_PickingPointerPositions[pointerId] = GetEventPointerPosition(triggerEvent);
		m_PendingTopElementUnderPointer[pointerId] = newElementUnderPointer;
		VisualElement visualElement = m_TopElementUnderPointer[pointerId];
		if (newElementUnderPointer != visualElement && m_TriggerEvent[pointerId] == null && triggerEvent is IPointerOrMouseEvent pointerOrMouseEvent)
		{
			m_TriggerEvent[pointerId] = pointerOrMouseEvent;
		}
	}

	internal void CommitElementUnderPointers(EventDispatcher dispatcher, ContextType contextType)
	{
		for (int i = 0; i < PointerId.maxPointers; i++)
		{
			IPointerOrMouseEvent pointerOrMouseEvent = m_TriggerEvent[i];
			VisualElement visualElement = m_TopElementUnderPointer[i];
			VisualElement visualElement2 = m_PendingTopElementUnderPointer[i];
			if (visualElement2 == visualElement)
			{
				if (pointerOrMouseEvent != null)
				{
					m_PickingPointerPositions[i] = pointerOrMouseEvent.position;
				}
				continue;
			}
			m_TopElementUnderPointer[i] = visualElement2;
			if (pointerOrMouseEvent == null)
			{
				using (new EventDispatcherGate(dispatcher))
				{
					Vector2 pointerPosition = PointerDeviceState.GetPointerPosition(i, contextType);
					PointerEventsHelper.SendOverOut(visualElement, visualElement2, null, pointerPosition, i);
					PointerEventsHelper.SendEnterLeave<PointerLeaveEvent, PointerEnterEvent>(visualElement, visualElement2, null, pointerPosition, i);
					m_PickingPointerPositions[i] = pointerPosition;
					if (i == PointerId.mousePointerId)
					{
						MouseEventsHelper.SendMouseOverMouseOut(visualElement, visualElement2, null, pointerPosition);
						MouseEventsHelper.SendEnterLeave<MouseLeaveEvent, MouseEnterEvent>(visualElement, visualElement2, null, pointerPosition);
					}
				}
			}
			if (pointerOrMouseEvent != null)
			{
				Vector3 position = pointerOrMouseEvent.position;
				m_PickingPointerPositions[i] = position;
				if (pointerOrMouseEvent is EventBase eventBase)
				{
					if (eventBase.eventTypeId == EventBase<PointerMoveEvent>.TypeId() || eventBase.eventTypeId == EventBase<PointerDownEvent>.TypeId() || eventBase.eventTypeId == EventBase<PointerUpEvent>.TypeId() || eventBase.eventTypeId == EventBase<PointerCancelEvent>.TypeId())
					{
						using (new EventDispatcherGate(dispatcher))
						{
							PointerEventsHelper.SendOverOut(visualElement, visualElement2, (IPointerEvent)pointerOrMouseEvent, position, i);
							PointerEventsHelper.SendEnterLeave<PointerLeaveEvent, PointerEnterEvent>(visualElement, visualElement2, (IPointerEvent)pointerOrMouseEvent, position, i);
							if (pointerOrMouseEvent.pointerId == PointerId.mousePointerId)
							{
								IMouseEvent compatibilityMouseEvent = ((IPointerEventInternal)pointerOrMouseEvent).compatibilityMouseEvent;
								if (compatibilityMouseEvent != null)
								{
									MouseEventsHelper.SendMouseOverMouseOut(visualElement, visualElement2, compatibilityMouseEvent, position);
									MouseEventsHelper.SendEnterLeave<MouseLeaveEvent, MouseEnterEvent>(visualElement, visualElement2, compatibilityMouseEvent, position);
								}
							}
						}
					}
					else if (eventBase.eventTypeId == EventBase<WheelEvent>.TypeId())
					{
						using (new EventDispatcherGate(dispatcher))
						{
							MouseEventsHelper.SendMouseOverMouseOut(visualElement, visualElement2, (IMouseEvent)pointerOrMouseEvent, position);
							MouseEventsHelper.SendEnterLeave<MouseLeaveEvent, MouseEnterEvent>(visualElement, visualElement2, (IMouseEvent)pointerOrMouseEvent, position);
						}
					}
					else if (eventBase.eventTypeId == EventBase<MouseEnterWindowEvent>.TypeId() || eventBase.eventTypeId == EventBase<MouseLeaveWindowEvent>.TypeId())
					{
						using (new EventDispatcherGate(dispatcher))
						{
							PointerEventsHelper.SendOverOut(visualElement, visualElement2, null, position, i);
							PointerEventsHelper.SendEnterLeave<PointerLeaveEvent, PointerEnterEvent>(visualElement, visualElement2, null, position, i);
							if (i == PointerId.mousePointerId)
							{
								MouseEventsHelper.SendMouseOverMouseOut(visualElement, visualElement2, (IMouseEvent)pointerOrMouseEvent, position);
								MouseEventsHelper.SendEnterLeave<MouseLeaveEvent, MouseEnterEvent>(visualElement, visualElement2, (IMouseEvent)pointerOrMouseEvent, position);
							}
						}
					}
				}
			}
			m_TriggerEvent[i] = null;
		}
	}
}
