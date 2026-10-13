#define UNITY_ASSERTIONS
using System;
using System.Collections.Generic;
using UnityEngine.Bindings;
using UnityEngine.UIElements.Layout;

namespace UnityEngine.UIElements;

[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
internal abstract class BaseVisualElementPanel : IPanel, IDisposable, IGroupBox
{
	private UIElementsBridge m_UIElementsBridge;

	private float m_Scale = 1f;

	internal LayoutConfig layoutConfig;

	private float m_PixelsPerPoint = 1f;

	internal IPanelRenderer panelRenderer;

	internal ElementUnderPointer m_TopElementUnderPointers = new ElementUnderPointer();

	private bool m_IsFlat = true;

	public abstract EventInterests IMGUIEventInterests { get; set; }

	public abstract ScriptableObject ownerObject { get; protected set; }

	public abstract SavePersistentViewData saveViewData { get; set; }

	public abstract GetViewDataDictionary getViewDataDictionary { get; set; }

	public abstract int IMGUIContainersCount { get; set; }

	public abstract FocusController focusController { get; set; }

	public abstract IMGUIContainer rootIMGUIContainer { get; set; }

	internal UIElementsBridge uiElementsBridge
	{
		get
		{
			if (m_UIElementsBridge != null)
			{
				return m_UIElementsBridge;
			}
			throw new Exception("Panel has no UIElementsBridge.");
		}
		set
		{
			m_UIElementsBridge = value;
		}
	}

	internal float scale
	{
		get
		{
			return m_Scale;
		}
		set
		{
			if (!Mathf.Approximately(m_Scale, value))
			{
				m_Scale = value;
				visualTree.IncrementVersion(VersionChangeType.Layout);
				layoutConfig.PointScaleFactor = scaledPixelsPerPoint;
				visualTree.IncrementVersion(VersionChangeType.StyleSheet);
			}
		}
	}

	internal float pixelsPerPoint
	{
		get
		{
			return m_PixelsPerPoint;
		}
		set
		{
			if (!Mathf.Approximately(m_PixelsPerPoint, value))
			{
				m_PixelsPerPoint = value;
				visualTree.IncrementVersion(VersionChangeType.Layout);
				layoutConfig.PointScaleFactor = scaledPixelsPerPoint;
				visualTree.IncrementVersion(VersionChangeType.StyleSheet);
			}
		}
	}

	public float scaledPixelsPerPoint => m_PixelsPerPoint * m_Scale;

	public float referenceSpritePixelsPerUnit { get; set; } = 100f;

	internal PanelClearSettings clearSettings { get; set; } = new PanelClearSettings
	{
		clearDepthStencil = true,
		clearColor = true,
		color = Color.clear
	};

	internal bool duringLayoutPhase { get; set; }

	public bool isDirty => version != repaintVersion;

	internal abstract uint version { get; }

	internal abstract uint repaintVersion { get; }

	internal abstract uint hierarchyVersion { get; }

	internal virtual RepaintData repaintData { get; set; }

	internal virtual ICursorManager cursorManager { get; set; }

	public ContextualMenuManager contextualMenuManager { get; internal set; }

	internal virtual DataBindingManager dataBindingManager { get; set; }

	public abstract VisualElement visualTree { get; }

	public abstract EventDispatcher dispatcher { get; set; }

	internal abstract IScheduler scheduler { get; }

	internal abstract IStylePropertyAnimationSystem styleAnimationSystem
	{
		get;
		[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
		set;
	}

	public abstract ContextType contextType { get; }

	internal bool disposed { get; private set; }

	public bool isFlat
	{
		get
		{
			return m_IsFlat;
		}
		set
		{
			if (m_IsFlat != value)
			{
				m_IsFlat = value;
				SetSpecializedHierarchyFlagsUpdater();
				isFlatChanged?.Invoke();
			}
		}
	}

	public abstract AtlasBase atlas { get; set; }

	internal event Action<BaseVisualElementPanel> panelDisposed;

	internal event Action isFlatChanged;

	internal event Action atlasChanged;

	internal event HierarchyEvent hierarchyChanged;

	internal event Action<IPanel> beforeUpdate;

	protected BaseVisualElementPanel()
	{
		layoutConfig = LayoutManager.SharedManager.CreateConfig();
		m_UIElementsBridge = new RuntimeUIElementsBridge();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposed)
		{
			return;
		}
		if (disposing)
		{
			if (ownerObject != null)
			{
				UIElementsUtility.RemoveCachedPanel(ownerObject.GetInstanceID());
			}
			PointerDeviceState.RemovePanelData(this);
		}
		panelDisposed?.Invoke(this);
		LayoutManager.SharedManager.DestroyConfig(ref layoutConfig);
		disposed = true;
	}

	public abstract void Repaint(Event e);

	public abstract void ValidateFocus();

	public abstract void ValidateLayout();

	public abstract void UpdateAnimations();

	public abstract void UpdateBindings();

	public abstract void UpdateDataBinding();

	public abstract void ApplyStyles();

	internal abstract void OnVersionChanged(VisualElement ele, VersionChangeType changeTypeFlag);

	internal abstract void SetUpdater(IVisualTreeUpdater updater, VisualTreeUpdatePhase phase);

	internal void SendEvent(EventBase e, DispatchMode dispatchMode = DispatchMode.Default)
	{
		Debug.Assert(dispatcher != null, "dispatcher != null");
		dispatcher?.Dispatch(e, this, dispatchMode);
	}

	public abstract VisualElement Pick(Vector2 point);

	public abstract VisualElement PickAll(Vector2 point, List<VisualElement> picked);

	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal abstract IVisualTreeUpdater GetUpdater(VisualTreeUpdatePhase phase);

	internal VisualElement GetTopElementUnderPointer(int pointerId)
	{
		return m_TopElementUnderPointers.GetTopElementUnderPointer(pointerId);
	}

	internal VisualElement RecomputeTopElementUnderPointer(int pointerId, Vector2 pointerPos, EventBase triggerEvent)
	{
		VisualElement visualElement = null;
		if (PointerDeviceState.GetPanel(pointerId, contextType) == this && !PointerDeviceState.HasLocationFlag(pointerId, contextType, PointerDeviceState.LocationFlag.OutsidePanel))
		{
			visualElement = Pick(pointerPos);
		}
		m_TopElementUnderPointers.SetElementUnderPointer(visualElement, pointerId, triggerEvent);
		if (triggerEvent is IPointerEventInternal { compatibilityMouseEvent: not null } pointerEventInternal)
		{
			m_TopElementUnderPointers.SetElementUnderPointer(visualElement, PointerId.mousePointerId, (EventBase)pointerEventInternal.compatibilityMouseEvent);
		}
		return visualElement;
	}

	internal void ClearCachedElementUnderPointer(int pointerId, EventBase triggerEvent)
	{
		m_TopElementUnderPointers.SetTemporaryElementUnderPointer(null, pointerId, triggerEvent);
	}

	internal void CommitElementUnderPointers()
	{
		m_TopElementUnderPointers.CommitElementUnderPointers(dispatcher, contextType);
	}

	internal void SetSpecializedHierarchyFlagsUpdater()
	{
		IVisualTreeUpdater updater = GetUpdater(VisualTreeUpdatePhase.TransformClip);
		bool flag = updater is VisualTreeWorldSpaceHierarchyFlagsUpdater;
		if (isFlat)
		{
			if (flag)
			{
				SetUpdater(new VisualTreeHierarchyFlagsUpdater(), VisualTreeUpdatePhase.TransformClip);
			}
		}
		else if (!flag)
		{
			SetUpdater(new VisualTreeWorldSpaceHierarchyFlagsUpdater(), VisualTreeUpdatePhase.TransformClip);
		}
	}

	protected void InvokeAtlasChanged()
	{
		atlasChanged?.Invoke();
	}

	internal void InvokeHierarchyChanged(VisualElement ve, HierarchyChangeType changeType, IReadOnlyList<VisualElement> additionalContext = null)
	{
		if (hierarchyChanged != null)
		{
			hierarchyChanged(ve, changeType, additionalContext);
		}
	}

	internal void InvokeBeforeUpdate()
	{
		beforeUpdate?.Invoke(this);
	}

	internal void UpdateElementUnderPointers()
	{
		int[] hoveringPointers = PointerId.hoveringPointers;
		foreach (int pointerId in hoveringPointers)
		{
			if (PointerDeviceState.GetPanel(pointerId, contextType) != this || PointerDeviceState.HasLocationFlag(pointerId, contextType, PointerDeviceState.LocationFlag.OutsidePanel))
			{
				m_TopElementUnderPointers.SetElementUnderPointer(null, pointerId, new Vector2(-2.1474836E+09f, -2.1474836E+09f));
				continue;
			}
			Vector2 pointerPosition = PointerDeviceState.GetPointerPosition(pointerId, contextType);
			VisualElement newElementUnderPointer = PickAll(pointerPosition, null);
			m_TopElementUnderPointers.SetElementUnderPointer(newElementUnderPointer, pointerId, pointerPosition);
		}
		CommitElementUnderPointers();
	}

	void IGroupBox.OnOptionAdded(IGroupBoxOption option)
	{
	}

	void IGroupBox.OnOptionRemoved(IGroupBoxOption option)
	{
	}

	public virtual void Render()
	{
		panelRenderer.Render();
	}

	internal virtual IGenericMenu CreateMenu()
	{
		return new GenericDropdownMenu();
	}
}
