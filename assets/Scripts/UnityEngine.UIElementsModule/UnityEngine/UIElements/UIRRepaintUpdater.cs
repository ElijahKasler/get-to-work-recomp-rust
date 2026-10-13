#define UNITY_ASSERTIONS
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine.UIElements.UIR;

namespace UnityEngine.UIElements;

internal class UIRRepaintUpdater : BaseVisualTreeUpdater, IPanelRenderer
{
	private BaseVisualElementPanel attachedPanel;

	internal RenderChain renderChain;

	private static readonly string s_Description;

	private static readonly ProfilerMarker s_ProfilerMarker;

	private bool m_ForceGammaRendering;

	private uint m_VertexBudget;

	public override ProfilerMarker profilerMarker => s_ProfilerMarker;

	public bool forceGammaRendering
	{
		get
		{
			return m_ForceGammaRendering;
		}
		set
		{
			if (m_ForceGammaRendering != value)
			{
				m_ForceGammaRendering = value;
				DestroyRenderChain();
			}
		}
	}

	public uint vertexBudget
	{
		get
		{
			return m_VertexBudget;
		}
		set
		{
			if (m_VertexBudget != value)
			{
				m_VertexBudget = value;
				DestroyRenderChain();
			}
		}
	}

	public bool drawStats { get; set; }

	public bool breakBatches { get; set; }

	protected bool disposed { get; private set; }

	public UIRRepaintUpdater()
	{
		base.panelChanged += OnPanelChanged;
	}

	public override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType)
	{
		if (renderChain != null)
		{
			bool flag = (versionChangeType & VersionChangeType.Transform) != 0;
			bool flag2 = (versionChangeType & VersionChangeType.Size) != 0;
			bool flag3 = (versionChangeType & VersionChangeType.Overflow) != 0;
			bool flag4 = (versionChangeType & VersionChangeType.BorderRadius) != 0;
			bool flag5 = (versionChangeType & VersionChangeType.BorderWidth) != 0;
			bool flag6 = (versionChangeType & VersionChangeType.RenderHints) != 0;
			bool flag7 = (versionChangeType & VersionChangeType.DisableRendering) != 0;
			bool flag8 = (versionChangeType & VersionChangeType.Repaint) != 0;
			if (flag6)
			{
				renderChain.UIEOnRenderHintsChanged(ve);
			}
			if (flag | flag2 | flag5)
			{
				renderChain.UIEOnTransformOrSizeChanged(ve, flag, flag2 | flag5);
			}
			if (flag3 | flag4)
			{
				renderChain.UIEOnClippingChanged(ve, hierarchical: false);
			}
			if ((versionChangeType & VersionChangeType.Opacity) != 0)
			{
				renderChain.UIEOnOpacityChanged(ve);
			}
			if ((versionChangeType & VersionChangeType.Color) != 0)
			{
				renderChain.UIEOnColorChanged(ve);
			}
			if (flag8)
			{
				renderChain.UIEOnVisualsChanged(ve, hierarchical: false);
			}
			if (flag7 && !flag8)
			{
				renderChain.UIEOnDisableRenderingChanged(ve);
			}
		}
	}

	public override void Update()
	{
		if (renderChain == null)
		{
			InitRenderChain();
		}
		if (renderChain != null && renderChain.device != null)
		{
			renderChain.ProcessChanges();
			renderChain.drawStats = drawStats;
			renderChain.device.breakBatches = breakBatches;
		}
	}

	public void Render()
	{
		if (renderChain != null)
		{
			Debug.Assert(!renderChain.drawInCameras);
			renderChain.Render();
		}
	}

	protected virtual RenderChain CreateRenderChain()
	{
		return new RenderChain(base.panel);
	}

	static UIRRepaintUpdater()
	{
		s_Description = "Update Rendering";
		s_ProfilerMarker = new ProfilerMarker(s_Description);
		Utility.GraphicsResourcesRecreate += OnGraphicsResourcesRecreate;
	}

	private static void OnGraphicsResourcesRecreate(bool recreate)
	{
		if (!recreate)
		{
			UIRenderDevice.PrepareForGfxDeviceRecreate();
		}
		Dictionary<int, Panel>.Enumerator panelsIterator = UIElementsUtility.GetPanelsIterator();
		while (panelsIterator.MoveNext())
		{
			if (recreate)
			{
				panelsIterator.Current.Value.atlas?.Reset();
			}
			else
			{
				panelsIterator.Current.Value.panelRenderer.Reset();
			}
		}
		if (!recreate)
		{
			UIRenderDevice.FlushAllPendingDeviceDisposes();
		}
		else
		{
			UIRenderDevice.WrapUpGfxDeviceRecreate();
		}
	}

	private void OnPanelChanged(BaseVisualElementPanel obj)
	{
		DetachFromPanel();
		AttachToPanel();
	}

	private void AttachToPanel()
	{
		Debug.Assert(attachedPanel == null);
		if (base.panel != null)
		{
			attachedPanel = base.panel;
			attachedPanel.isFlatChanged += OnPanelIsFlatChanged;
			attachedPanel.atlasChanged += OnPanelAtlasChanged;
			attachedPanel.hierarchyChanged += OnPanelHierarchyChanged;
			Debug.Assert(attachedPanel.panelRenderer == null);
			attachedPanel.panelRenderer = this;
			if (base.panel is BaseRuntimePanel baseRuntimePanel)
			{
				baseRuntimePanel.drawsInCamerasChanged += OnPanelDrawsInCamerasChanged;
			}
		}
	}

	private void DetachFromPanel()
	{
		if (attachedPanel != null)
		{
			DestroyRenderChain();
			if (base.panel is BaseRuntimePanel baseRuntimePanel)
			{
				baseRuntimePanel.drawsInCamerasChanged -= OnPanelDrawsInCamerasChanged;
			}
			attachedPanel.isFlatChanged -= OnPanelIsFlatChanged;
			attachedPanel.atlasChanged -= OnPanelAtlasChanged;
			attachedPanel.hierarchyChanged -= OnPanelHierarchyChanged;
			Debug.Assert(attachedPanel.panelRenderer == this);
			attachedPanel.panelRenderer = null;
			attachedPanel = null;
		}
	}

	private void InitRenderChain()
	{
		Debug.Assert(attachedPanel != null);
		renderChain = CreateRenderChain();
		renderChain.UIEOnChildAdded(attachedPanel.visualTree);
	}

	public void Reset()
	{
		DestroyRenderChain();
	}

	private void DestroyRenderChain()
	{
		if (renderChain != null)
		{
			renderChain.Dispose();
			renderChain = null;
			ResetAllElementsDataRecursive(attachedPanel.visualTree);
		}
	}

	private void OnPanelIsFlatChanged()
	{
		DestroyRenderChain();
	}

	private void OnPanelAtlasChanged()
	{
		DestroyRenderChain();
	}

	private void OnPanelDrawsInCamerasChanged()
	{
		DestroyRenderChain();
	}

	private void OnPanelHierarchyChanged(VisualElement ve, HierarchyChangeType changeType, IReadOnlyList<VisualElement> additionalContext = null)
	{
		if (renderChain != null)
		{
			switch (changeType)
			{
			case HierarchyChangeType.AddedToParent:
				renderChain.UIEOnChildAdded(ve);
				break;
			case HierarchyChangeType.RemovedFromParent:
				renderChain.UIEOnChildRemoving(ve);
				break;
			case HierarchyChangeType.ChildrenReordered:
				renderChain.UIEOnChildrenReordered(ve);
				break;
			}
		}
	}

	private void ResetAllElementsDataRecursive(VisualElement ve)
	{
		ve.renderChainData = default;
		int num = ve.hierarchy.childCount - 1;
		while (num >= 0)
		{
			ResetAllElementsDataRecursive(ve.hierarchy[num--]);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposed)
		{
			if (disposing)
			{
				DetachFromPanel();
			}
			disposed = true;
		}
	}
}
