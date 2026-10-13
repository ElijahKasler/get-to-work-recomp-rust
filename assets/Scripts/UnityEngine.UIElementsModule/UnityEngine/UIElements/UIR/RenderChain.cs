#define UNITY_ASSERTIONS
using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Profiling;

namespace UnityEngine.UIElements.UIR;

internal class RenderChain : IDisposable
{
	private struct DepthOrderedDirtyTracking
	{
		public List<VisualElement> heads;

		public List<VisualElement> tails;

		public int[] minDepths;

		public int[] maxDepths;

		public uint dirtyID;

		public void EnsureFits(int maxDepth)
		{
			while (heads.Count <= maxDepth)
			{
				heads.Add(null);
				tails.Add(null);
			}
		}

		public void RegisterDirty(VisualElement ve, RenderDataDirtyTypes dirtyTypes, RenderDataDirtyTypeClasses dirtyTypeClass)
		{
			Debug.Assert(dirtyTypes != RenderDataDirtyTypes.None);
			int hierarchyDepth = ve.renderChainData.hierarchyDepth;
			minDepths[(int)dirtyTypeClass] = ((hierarchyDepth < minDepths[(int)dirtyTypeClass]) ? hierarchyDepth : minDepths[(int)dirtyTypeClass]);
			maxDepths[(int)dirtyTypeClass] = ((hierarchyDepth > maxDepths[(int)dirtyTypeClass]) ? hierarchyDepth : maxDepths[(int)dirtyTypeClass]);
			if (ve.renderChainData.dirtiedValues != RenderDataDirtyTypes.None)
			{
				ve.renderChainData.dirtiedValues |= dirtyTypes;
				return;
			}
			ve.renderChainData.dirtiedValues = dirtyTypes;
			if (tails[hierarchyDepth] != null)
			{
				tails[hierarchyDepth].renderChainData.nextDirty = ve;
				ve.renderChainData.prevDirty = tails[hierarchyDepth];
				tails[hierarchyDepth] = ve;
			}
			else
			{
				List<VisualElement> list = heads;
				VisualElement value = (tails[hierarchyDepth] = ve);
				list[hierarchyDepth] = value;
			}
		}

		public void ClearDirty(VisualElement ve, RenderDataDirtyTypes dirtyTypesInverse)
		{
			Debug.Assert(ve.renderChainData.dirtiedValues != RenderDataDirtyTypes.None);
			ve.renderChainData.dirtiedValues &= dirtyTypesInverse;
			if (ve.renderChainData.dirtiedValues == RenderDataDirtyTypes.None)
			{
				if (ve.renderChainData.prevDirty != null)
				{
					ve.renderChainData.prevDirty.renderChainData.nextDirty = ve.renderChainData.nextDirty;
				}
				if (ve.renderChainData.nextDirty != null)
				{
					ve.renderChainData.nextDirty.renderChainData.prevDirty = ve.renderChainData.prevDirty;
				}
				if (tails[ve.renderChainData.hierarchyDepth] == ve)
				{
					Debug.Assert(ve.renderChainData.nextDirty == null);
					tails[ve.renderChainData.hierarchyDepth] = ve.renderChainData.prevDirty;
				}
				if (heads[ve.renderChainData.hierarchyDepth] == ve)
				{
					Debug.Assert(ve.renderChainData.prevDirty == null);
					heads[ve.renderChainData.hierarchyDepth] = ve.renderChainData.nextDirty;
				}
				ve.renderChainData.prevDirty = (ve.renderChainData.nextDirty = null);
			}
		}

		public void Reset()
		{
			for (int i = 0; i < minDepths.Length; i++)
			{
				minDepths[i] = int.MaxValue;
				maxDepths[i] = int.MinValue;
			}
		}
	}

	private class VisualChangesProcessor : IDisposable
	{
		private enum VisualsProcessingType
		{
			Head = 0,
			Tail = 1
		}

		private struct EntryProcessingInfo
		{
			public VisualElement visualElement;

			public VisualsProcessingType type;

			public Entry rootEntry;
		}

		private static readonly ProfilerMarker k_GenerateEntriesMarker = new ProfilerMarker("UIR.GenerateEntries");

		private static readonly ProfilerMarker k_ConvertEntriesToCommandsMarker = new ProfilerMarker("UIR.ConvertEntriesToCommands");

		private static readonly ProfilerMarker k_UpdateOpacityIdMarker = new ProfilerMarker("UIR.UpdateOpacityId");

		private RenderChain m_RenderChain;

		private MeshGenerationContext m_MeshGenerationContext;

		private BaseElementBuilder m_ElementBuilder;

		private List<EntryProcessingInfo> m_EntryProcessingList;

		private List<EntryProcessor> m_Processors;

		public BaseElementBuilder elementBuilder => m_ElementBuilder;

		public MeshGenerationContext meshGenerationContext => m_MeshGenerationContext;

		protected bool disposed { get; private set; }

		public VisualChangesProcessor(RenderChain renderChain)
		{
			m_RenderChain = renderChain;
			m_MeshGenerationContext = new MeshGenerationContext(m_RenderChain.meshWriteDataPool, m_RenderChain.entryRecorder, m_RenderChain.tempMeshAllocator, m_RenderChain.meshGenerationDeferrer, m_RenderChain.meshGenerationNodeManager);
			m_ElementBuilder = new DefaultElementBuilder(m_RenderChain);
			m_EntryProcessingList = new List<EntryProcessingInfo>();
			m_Processors = new List<EntryProcessor>(4);
		}

		public void ScheduleMeshGenerationJobs()
		{
			m_ElementBuilder.ScheduleMeshGenerationJobs(m_MeshGenerationContext);
		}

		public void ProcessOnVisualsChanged(VisualElement ve, uint dirtyID, ref ChainBuilderStats stats)
		{
			bool flag = ve.renderChainData.pendingHierarchicalRepaint || (ve.renderChainData.dirtiedValues & RenderDataDirtyTypes.VisualsHierarchy) != 0;
			if (flag)
			{
				stats.recursiveVisualUpdates++;
			}
			else
			{
				stats.nonRecursiveVisualUpdates++;
			}
			DepthFirstOnVisualsChanged(ve, dirtyID, flag, ref stats);
		}

		private void DepthFirstOnVisualsChanged(VisualElement ve, uint dirtyID, bool hierarchical, ref ChainBuilderStats stats)
		{
			if (dirtyID == ve.renderChainData.dirtyID)
			{
				return;
			}
			ve.renderChainData.dirtyID = dirtyID;
			if (hierarchical)
			{
				stats.recursiveVisualUpdatesExpanded++;
			}
			if (!ve.areAncestorsAndSelfDisplayed)
			{
				if (hierarchical)
				{
					ve.renderChainData.pendingHierarchicalRepaint = true;
				}
				else
				{
					ve.renderChainData.pendingRepaint = true;
				}
				return;
			}
			ve.renderChainData.pendingHierarchicalRepaint = false;
			ve.renderChainData.pendingRepaint = false;
			if (!hierarchical && (ve.renderChainData.dirtiedValues & RenderDataDirtyTypes.AllVisuals) == RenderDataDirtyTypes.VisualsOpacityId)
			{
				stats.opacityIdUpdates++;
				UpdateOpacityId(ve, m_RenderChain);
				return;
			}
			UpdateWorldFlipsWinding(ve);
			Debug.Assert(ve.renderChainData.clipMethod != ClipMethod.Undetermined);
			Debug.Assert(RenderChainVEData.AllocatesID(ve.renderChainData.transformID) || ve.hierarchy.parent == null || ve.renderChainData.transformID.Equals(ve.hierarchy.parent.renderChainData.transformID) || ve.renderChainData.isGroupTransform);
			if (ve is TextElement)
			{
				RenderEvents.UpdateTextCoreSettings(m_RenderChain, ve);
			}
			if ((ve.renderHints & RenderHints.DynamicColor) == RenderHints.DynamicColor)
			{
				RenderEvents.SetColorValues(m_RenderChain, ve);
			}
			Entry entry = m_RenderChain.entryPool.Get();
			entry.type = EntryType.DedicatedPlaceholder;
			m_EntryProcessingList.Add(new EntryProcessingInfo
			{
				type = VisualsProcessingType.Head,
				visualElement = ve,
				rootEntry = entry
			});
			m_MeshGenerationContext.Begin(entry, ve);
			m_ElementBuilder.Build(m_MeshGenerationContext);
			m_MeshGenerationContext.End();
			if (hierarchical)
			{
				int childCount = ve.hierarchy.childCount;
				for (int i = 0; i < childCount; i++)
				{
					DepthFirstOnVisualsChanged(ve.hierarchy[i], dirtyID, hierarchical: true, ref stats);
				}
			}
			m_EntryProcessingList.Add(new EntryProcessingInfo
			{
				type = VisualsProcessingType.Tail,
				visualElement = ve,
				rootEntry = entry
			});
		}

		private static void UpdateWorldFlipsWinding(VisualElement ve)
		{
			bool localFlipsWinding = ve.renderChainData.localFlipsWinding;
			bool flag = false;
			VisualElement parent = ve.hierarchy.parent;
			if (parent != null)
			{
				flag = parent.renderChainData.worldFlipsWinding;
			}
			ve.renderChainData.worldFlipsWinding = flag ^ localFlipsWinding;
		}

		public void ConvertEntriesToCommands(ref ChainBuilderStats stats)
		{
			int num = 0;
			for (int i = 0; i < m_EntryProcessingList.Count; i++)
			{
				EntryProcessingInfo entryProcessingInfo = m_EntryProcessingList[i];
				if (entryProcessingInfo.type == VisualsProcessingType.Head)
				{
					EntryProcessor entryProcessor;
					if (num < m_Processors.Count)
					{
						entryProcessor = m_Processors[num];
					}
					else
					{
						entryProcessor = new EntryProcessor();
						m_Processors.Add(entryProcessor);
					}
					num++;
					entryProcessor.Init(entryProcessingInfo.rootEntry, m_RenderChain, entryProcessingInfo.visualElement);
					entryProcessor.ProcessHead();
				}
				else
				{
					num--;
					EntryProcessor entryProcessor2 = m_Processors[num];
					entryProcessor2.ProcessTail();
					if (entryProcessor2.firstHeadCommand != null || entryProcessor2.firstTailCommand != null)
					{
					}
					CommandManipulator.ReplaceCommands(m_RenderChain, entryProcessingInfo.visualElement, entryProcessor2);
				}
			}
			m_EntryProcessingList.Clear();
			for (int j = 0; j < m_Processors.Count; j++)
			{
				m_Processors[j].ClearReferences();
			}
		}

		public static void UpdateOpacityId(VisualElement ve, RenderChain renderChain)
		{
			if (ve.renderChainData.headMesh != null)
			{
				DoUpdateOpacityId(ve, renderChain, ve.renderChainData.headMesh);
			}
			if (ve.renderChainData.tailMesh != null)
			{
				DoUpdateOpacityId(ve, renderChain, ve.renderChainData.tailMesh);
			}
			if (ve.renderChainData.hasExtraMeshes)
			{
				ExtraRenderChainVEData orAddExtraData = renderChain.GetOrAddExtraData(ve);
				for (BasicNode<MeshHandle> basicNode = orAddExtraData.extraMesh; basicNode != null; basicNode = basicNode.next)
				{
					DoUpdateOpacityId(ve, renderChain, basicNode.data);
				}
			}
		}

		private static void DoUpdateOpacityId(VisualElement ve, RenderChain renderChain, MeshHandle mesh)
		{
			int size = (int)mesh.allocVerts.size;
			NativeSlice<Vertex> oldVerts = mesh.allocPage.vertices.cpuData.Slice((int)mesh.allocVerts.start, size);
			renderChain.device.Update(mesh, (uint)size, out var vertexData);
			Color32 opacityData = renderChain.shaderInfoAllocator.OpacityAllocToVertexData(ve.renderChainData.opacityID);
			renderChain.opacityIdAccelerator.CreateJob(oldVerts, vertexData, opacityData, size);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					m_MeshGenerationContext.Dispose();
					m_MeshGenerationContext = null;
				}
				disposed = true;
			}
		}
	}

	private RenderChainCommand m_FirstCommand;

	private DepthOrderedDirtyTracking m_DirtyTracker;

	private VisualChangesProcessor m_VisualChangesProcessor;

	private LinkedPool<RenderChainCommand> m_CommandPool = new LinkedPool<RenderChainCommand>(() => new RenderChainCommand(), (RenderChainCommand r) =>
	{
		r.Reset();
	});

	private LinkedPool<ExtraRenderChainVEData> m_ExtraDataPool = new LinkedPool<ExtraRenderChainVEData>(() => new ExtraRenderChainVEData(), (ExtraRenderChainVEData e) =>
	{
		e.Reset();
	});

	private BasicNodePool<MeshHandle> m_MeshHandleNodePool = new BasicNodePool<MeshHandle>();

	private BasicNodePool<TextureEntry> m_TexturePool = new BasicNodePool<TextureEntry>();

	private Dictionary<VisualElement, ExtraRenderChainVEData> m_ExtraData = new Dictionary<VisualElement, ExtraRenderChainVEData>();

	private MeshGenerationDeferrer m_MeshGenerationDeferrer = new MeshGenerationDeferrer();

	private Material m_DefaultMat;

	private bool m_BlockDirtyRegistration;

	private ChainBuilderStats m_Stats;

	private uint m_StatsElementsAdded;

	private uint m_StatsElementsRemoved;

	private TextureRegistry m_TextureRegistry = TextureRegistry.instance;

	private static EntryPool s_SharedEntryPool = new EntryPool(10000);

	private static readonly ProfilerMarker k_MarkerProcess = new ProfilerMarker("RenderChain.Process");

	private static readonly ProfilerMarker k_MarkerClipProcessing = new ProfilerMarker("RenderChain.UpdateClips");

	private static readonly ProfilerMarker k_MarkerOpacityProcessing = new ProfilerMarker("RenderChain.UpdateOpacity");

	private static readonly ProfilerMarker k_MarkerColorsProcessing = new ProfilerMarker("RenderChain.UpdateColors");

	private static readonly ProfilerMarker k_MarkerTransformProcessing = new ProfilerMarker("RenderChain.UpdateTransforms");

	private static readonly ProfilerMarker k_MarkerVisualsProcessing = new ProfilerMarker("RenderChain.UpdateVisuals");

	private static readonly ProfilerMarker k_MarkerSerialize = new ProfilerMarker("RenderChain.Serialize");

	public EntryRecorder entryRecorder = new EntryRecorder(s_SharedEntryPool);

	internal UIRVEShaderInfoAllocator shaderInfoAllocator;

	internal RenderChainCommand firstCommand => m_FirstCommand;

	public OpacityIdAccelerator opacityIdAccelerator { get; private set; }

	protected bool disposed { get; private set; }

	internal ChainBuilderStats stats => m_Stats;

	internal ref ChainBuilderStats statsByRef => ref m_Stats;

	internal BaseVisualElementPanel panel { get; private set; }

	internal UIRenderDevice device { get; private set; }

	public BaseElementBuilder elementBuilder => m_VisualChangesProcessor.elementBuilder;

	internal AtlasBase atlas { get; private set; }

	internal VectorImageManager vectorImageManager { get; private set; }

	internal TempMeshAllocatorImpl tempMeshAllocator { get; private set; }

	internal MeshWriteDataPool meshWriteDataPool { get; } = new MeshWriteDataPool();

	internal EntryPool entryPool => s_SharedEntryPool;

	public MeshGenerationDeferrer meshGenerationDeferrer => m_MeshGenerationDeferrer;

	public MeshGenerationNodeManager meshGenerationNodeManager { get; private set; }

	internal JobManager jobManager { get; private set; }

	internal bool drawStats { get; set; }

	internal bool drawInCameras { get; }

	internal bool isFlat { get; }

	public bool forceGammaRendering { get; }

	public RenderChain(BaseVisualElementPanel panel)
		: this(panel, new UIRenderDevice(panel.panelRenderer.vertexBudget), panel.atlas, new VectorImageManager(panel.atlas))
	{
	}

	protected RenderChain(BaseVisualElementPanel panel, UIRenderDevice device, AtlasBase atlas, VectorImageManager vectorImageManager)
	{
		m_DirtyTracker.heads = new List<VisualElement>(8);
		m_DirtyTracker.tails = new List<VisualElement>(8);
		m_DirtyTracker.minDepths = new int[5];
		m_DirtyTracker.maxDepths = new int[5];
		m_DirtyTracker.Reset();
		this.panel = panel;
		this.device = device;
		this.atlas = atlas;
		this.vectorImageManager = vectorImageManager;
		tempMeshAllocator = new TempMeshAllocatorImpl();
		jobManager = new JobManager();
		opacityIdAccelerator = new OpacityIdAccelerator();
		meshGenerationNodeManager = new MeshGenerationNodeManager(entryRecorder);
		m_VisualChangesProcessor = new VisualChangesProcessor(this);
		ColorSpace activeColorSpace = QualitySettings.activeColorSpace;
		if (panel.contextType == ContextType.Player)
		{
			BaseRuntimePanel baseRuntimePanel = (BaseRuntimePanel)panel;
			device.drawsInCameras = (drawInCameras = baseRuntimePanel.drawsInCameras);
			if (drawInCameras)
			{
				m_DefaultMat = Shaders.runtimeWorldMaterial;
			}
			else
			{
				m_DefaultMat = Shaders.runtimeMaterial;
				if (activeColorSpace == ColorSpace.Linear)
				{
					forceGammaRendering = panel.panelRenderer.forceGammaRendering;
				}
			}
		}
		else
		{
			if (activeColorSpace == ColorSpace.Linear)
			{
				forceGammaRendering = true;
			}
			m_DefaultMat = Shaders.editorMaterial;
		}
		Shaders.Acquire();
		shaderInfoAllocator = new UIRVEShaderInfoAllocator((!forceGammaRendering) ? activeColorSpace : ColorSpace.Gamma);
		device.isFlat = (isFlat = panel.isFlat);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected void Dispose(bool disposing)
	{
		if (disposed)
		{
			return;
		}
		if (disposing)
		{
			Shaders.Release();
			for (VisualElement visualElement = GetFirstElementInPanel(m_FirstCommand?.owner); visualElement != null; visualElement = visualElement.renderChainData.next)
			{
				ResetTextures(visualElement);
			}
			tempMeshAllocator.Dispose();
			tempMeshAllocator = null;
			jobManager.Dispose();
			jobManager = null;
			vectorImageManager?.Dispose();
			vectorImageManager = null;
			shaderInfoAllocator.Dispose();
			shaderInfoAllocator = null;
			device?.Dispose();
			device = null;
			opacityIdAccelerator?.Dispose();
			opacityIdAccelerator = null;
			m_VisualChangesProcessor?.Dispose();
			m_VisualChangesProcessor = null;
			m_MeshGenerationDeferrer?.Dispose();
			m_MeshGenerationDeferrer = null;
			meshGenerationNodeManager.Dispose();
			meshGenerationNodeManager = null;
			atlas = null;
		}
		disposed = true;
	}

	public void ProcessChanges()
	{
		m_Stats = default;
		m_Stats.elementsAdded += m_StatsElementsAdded;
		m_Stats.elementsRemoved += m_StatsElementsRemoved;
		m_StatsElementsAdded = (m_StatsElementsRemoved = 0u);
		m_DirtyTracker.dirtyID++;
		int num = 0;
		RenderDataDirtyTypes renderDataDirtyTypes = RenderDataDirtyTypes.Clipping | RenderDataDirtyTypes.ClippingHierarchy;
		RenderDataDirtyTypes dirtyTypesInverse = ~renderDataDirtyTypes;
		for (int i = m_DirtyTracker.minDepths[num]; i <= m_DirtyTracker.maxDepths[num]; i++)
		{
			VisualElement visualElement = m_DirtyTracker.heads[i];
			while (visualElement != null)
			{
				VisualElement nextDirty = visualElement.renderChainData.nextDirty;
				if ((visualElement.renderChainData.dirtiedValues & renderDataDirtyTypes) != RenderDataDirtyTypes.None)
				{
					if (visualElement.renderChainData.isInChain && visualElement.renderChainData.dirtyID != m_DirtyTracker.dirtyID)
					{
						RenderEvents.ProcessOnClippingChanged(this, visualElement, m_DirtyTracker.dirtyID, ref m_Stats);
					}
					m_DirtyTracker.ClearDirty(visualElement, dirtyTypesInverse);
				}
				visualElement = nextDirty;
				m_Stats.dirtyProcessed++;
			}
		}
		m_DirtyTracker.dirtyID++;
		num = 1;
		renderDataDirtyTypes = RenderDataDirtyTypes.Opacity | RenderDataDirtyTypes.OpacityHierarchy;
		dirtyTypesInverse = ~renderDataDirtyTypes;
		for (int j = m_DirtyTracker.minDepths[num]; j <= m_DirtyTracker.maxDepths[num]; j++)
		{
			VisualElement visualElement2 = m_DirtyTracker.heads[j];
			while (visualElement2 != null)
			{
				VisualElement nextDirty2 = visualElement2.renderChainData.nextDirty;
				if ((visualElement2.renderChainData.dirtiedValues & renderDataDirtyTypes) != RenderDataDirtyTypes.None)
				{
					if (visualElement2.renderChainData.isInChain && visualElement2.renderChainData.dirtyID != m_DirtyTracker.dirtyID)
					{
						RenderEvents.ProcessOnOpacityChanged(this, visualElement2, m_DirtyTracker.dirtyID, ref m_Stats);
					}
					m_DirtyTracker.ClearDirty(visualElement2, dirtyTypesInverse);
				}
				visualElement2 = nextDirty2;
				m_Stats.dirtyProcessed++;
			}
		}
		m_DirtyTracker.dirtyID++;
		num = 2;
		renderDataDirtyTypes = RenderDataDirtyTypes.Color;
		dirtyTypesInverse = ~renderDataDirtyTypes;
		for (int k = m_DirtyTracker.minDepths[num]; k <= m_DirtyTracker.maxDepths[num]; k++)
		{
			VisualElement visualElement3 = m_DirtyTracker.heads[k];
			while (visualElement3 != null)
			{
				VisualElement nextDirty3 = visualElement3.renderChainData.nextDirty;
				if ((visualElement3.renderChainData.dirtiedValues & renderDataDirtyTypes) != RenderDataDirtyTypes.None)
				{
					if (visualElement3.renderChainData.isInChain && visualElement3.renderChainData.dirtyID != m_DirtyTracker.dirtyID)
					{
						RenderEvents.ProcessOnColorChanged(this, visualElement3, m_DirtyTracker.dirtyID, ref m_Stats);
					}
					m_DirtyTracker.ClearDirty(visualElement3, dirtyTypesInverse);
				}
				visualElement3 = nextDirty3;
				m_Stats.dirtyProcessed++;
			}
		}
		m_DirtyTracker.dirtyID++;
		num = 3;
		renderDataDirtyTypes = RenderDataDirtyTypes.Transform | RenderDataDirtyTypes.ClipRectSize;
		dirtyTypesInverse = ~renderDataDirtyTypes;
		for (int l = m_DirtyTracker.minDepths[num]; l <= m_DirtyTracker.maxDepths[num]; l++)
		{
			VisualElement visualElement4 = m_DirtyTracker.heads[l];
			while (visualElement4 != null)
			{
				VisualElement nextDirty4 = visualElement4.renderChainData.nextDirty;
				if ((visualElement4.renderChainData.dirtiedValues & renderDataDirtyTypes) != RenderDataDirtyTypes.None)
				{
					if (visualElement4.renderChainData.isInChain && visualElement4.renderChainData.dirtyID != m_DirtyTracker.dirtyID)
					{
						RenderEvents.ProcessOnTransformOrSizeChanged(this, visualElement4, m_DirtyTracker.dirtyID, ref m_Stats);
					}
					m_DirtyTracker.ClearDirty(visualElement4, dirtyTypesInverse);
				}
				visualElement4 = nextDirty4;
				m_Stats.dirtyProcessed++;
			}
		}
		jobManager.CompleteNudgeJobs();
		m_BlockDirtyRegistration = true;
		m_DirtyTracker.dirtyID++;
		num = 4;
		renderDataDirtyTypes = RenderDataDirtyTypes.AllVisuals;
		dirtyTypesInverse = ~renderDataDirtyTypes;
		for (int m = m_DirtyTracker.minDepths[num]; m <= m_DirtyTracker.maxDepths[num]; m++)
		{
			VisualElement visualElement5 = m_DirtyTracker.heads[m];
			while (visualElement5 != null)
			{
				VisualElement nextDirty5 = visualElement5.renderChainData.nextDirty;
				if ((visualElement5.renderChainData.dirtiedValues & renderDataDirtyTypes) != RenderDataDirtyTypes.None)
				{
					if (visualElement5.renderChainData.isInChain && visualElement5.renderChainData.dirtyID != m_DirtyTracker.dirtyID)
					{
						m_VisualChangesProcessor.ProcessOnVisualsChanged(visualElement5, m_DirtyTracker.dirtyID, ref m_Stats);
					}
					m_DirtyTracker.ClearDirty(visualElement5, dirtyTypesInverse);
				}
				visualElement5 = nextDirty5;
				m_Stats.dirtyProcessed++;
			}
		}
		m_MeshGenerationDeferrer.ProcessDeferredWork(m_VisualChangesProcessor.meshGenerationContext);
		m_VisualChangesProcessor.ScheduleMeshGenerationJobs();
		m_MeshGenerationDeferrer.ProcessDeferredWork(m_VisualChangesProcessor.meshGenerationContext);
		m_VisualChangesProcessor.ConvertEntriesToCommands(ref m_Stats);
		jobManager.CompleteConvertMeshJobs();
		jobManager.CompleteCopyMeshJobs();
		opacityIdAccelerator.CompleteJobs();
		m_BlockDirtyRegistration = false;
		meshGenerationNodeManager.ResetAll();
		tempMeshAllocator.Clear();
		meshWriteDataPool.ReturnAll();
		entryPool.ReturnAll();
		m_DirtyTracker.Reset();
		atlas?.InvokeUpdateDynamicTextures(panel);
		vectorImageManager?.Commit();
		shaderInfoAllocator.IssuePendingStorageChanges();
		device?.OnFrameRenderingBegin();
		if (drawInCameras)
		{
			SerializeCommandsForCameras();
		}
	}

	private void SerializeCommandsForCameras()
	{
		using (k_MarkerSerialize.Auto())
		{
			if (m_FirstCommand == null)
			{
				return;
			}
			Exception immediateException = null;
			device.EvaluateChain(m_FirstCommand, m_DefaultMat, m_DefaultMat, vectorImageManager?.atlas, shaderInfoAllocator.atlas, panel.scaledPixelsPerPoint, ref immediateException);
			List<CommandList> list = device?.currentFrameCommandLists;
			if (drawInCameras && list != null)
			{
				for (int i = 0; i < device.currentFrameCommandListCount; i++)
				{
					CommandList commandList = list[i];
					UIRenderer uIRenderer = commandList.m_Owner?.uiRenderer;
					if (uIRenderer != null)
					{
						List<CommandList>[] array = (uIRenderer.commandLists = device.commandLists);
						int safeFrameIndex = (int)device.frameIndex % array.Length;
						uIRenderer.SetNativeData(safeFrameIndex, i, m_DefaultMat);
					}
				}
			}
			Debug.Assert(immediateException == null);
		}
	}

	public void Render()
	{
		Debug.Assert(!drawInCameras);
		PanelClearSettings clearSettings = panel.clearSettings;
		if (clearSettings.clearColor || clearSettings.clearDepthStencil)
		{
			Color color = clearSettings.color;
			color = color.RGBMultiplied(color.a);
			GL.Clear(clearSettings.clearDepthStencil, clearSettings.clearColor, color, 0.99f);
		}
		Exception immediateException = null;
		if (m_FirstCommand != null)
		{
			Rect layout = panel.visualTree.layout;
			if (forceGammaRendering)
			{
				m_DefaultMat.EnableKeyword(Shaders.k_ForceGammaKeyword);
			}
			else
			{
				m_DefaultMat.DisableKeyword(Shaders.k_ForceGammaKeyword);
			}
			m_DefaultMat.SetPass(0);
			Matrix4x4 mat = ProjectionUtils.Ortho(layout.xMin, layout.xMax, layout.yMax, layout.yMin, -0.001f, 1.001f);
			GL.LoadProjectionMatrix(mat);
			GL.modelview = Matrix4x4.identity;
			device.EvaluateChain(m_FirstCommand, m_DefaultMat, m_DefaultMat, vectorImageManager?.atlas, shaderInfoAllocator.atlas, panel.scaledPixelsPerPoint, ref immediateException);
		}
		if (immediateException != null)
		{
			if (GUIUtility.IsExitGUIException(immediateException))
			{
				throw immediateException;
			}
			throw new ImmediateModeException(immediateException);
		}
		if (drawStats)
		{
			DrawStats();
		}
	}

	public void UIEOnChildAdded(VisualElement ve)
	{
		VisualElement parent = ve.hierarchy.parent;
		int index = parent?.hierarchy.IndexOf(ve) ?? 0;
		if (m_BlockDirtyRegistration)
		{
			throw new InvalidOperationException("VisualElements cannot be added to an active visual tree during generateVisualContent callback execution nor during visual tree rendering");
		}
		if (parent == null || parent.renderChainData.isInChain)
		{
			uint num = RenderEvents.DepthFirstOnChildAdded(this, parent, ve, index, resetState: true);
			Debug.Assert(ve.renderChainData.isInChain);
			Debug.Assert(ve.panel == panel);
			UIEOnClippingChanged(ve, hierarchical: true);
			UIEOnOpacityChanged(ve);
			UIEOnVisualsChanged(ve, hierarchical: true);
			m_StatsElementsAdded += num;
		}
	}

	public void UIEOnChildrenReordered(VisualElement ve)
	{
		if (m_BlockDirtyRegistration)
		{
			throw new InvalidOperationException("VisualElements cannot be moved under an active visual tree during generateVisualContent callback execution nor during visual tree rendering");
		}
		int childCount = ve.hierarchy.childCount;
		for (int i = 0; i < childCount; i++)
		{
			RenderEvents.DepthFirstOnChildRemoving(this, ve.hierarchy[i]);
		}
		for (int j = 0; j < childCount; j++)
		{
			RenderEvents.DepthFirstOnChildAdded(this, ve, ve.hierarchy[j], j, resetState: false);
		}
		UIEOnClippingChanged(ve, hierarchical: true);
		UIEOnOpacityChanged(ve, hierarchical: true);
		UIEOnVisualsChanged(ve, hierarchical: true);
	}

	public void UIEOnChildRemoving(VisualElement ve)
	{
		if (m_BlockDirtyRegistration)
		{
			throw new InvalidOperationException("VisualElements cannot be removed from an active visual tree during generateVisualContent callback execution nor during visual tree rendering");
		}
		m_StatsElementsRemoved += RenderEvents.DepthFirstOnChildRemoving(this, ve);
		Debug.Assert(!ve.renderChainData.isInChain);
	}

	public void UIEOnRenderHintsChanged(VisualElement ve)
	{
		if (ve.renderChainData.isInChain)
		{
			if (m_BlockDirtyRegistration)
			{
				throw new InvalidOperationException("Render Hints cannot change under an active visual tree during generateVisualContent callback execution nor during visual tree rendering");
			}
			if ((ve.renderHints & RenderHints.DirtyAll) == RenderHints.DirtyDynamicColor)
			{
				UIEOnVisualsChanged(ve, hierarchical: false);
			}
			else
			{
				UIEOnChildRemoving(ve);
				UIEOnChildAdded(ve);
			}
			ve.MarkRenderHintsClean();
		}
	}

	public void UIEOnClippingChanged(VisualElement ve, bool hierarchical)
	{
		if (ve.renderChainData.isInChain)
		{
			if (m_BlockDirtyRegistration)
			{
				throw new InvalidOperationException("VisualElements cannot change clipping state under an active visual tree during generateVisualContent callback execution nor during visual tree rendering");
			}
			m_DirtyTracker.RegisterDirty(ve, (RenderDataDirtyTypes)(4 | (hierarchical ? 8 : 0)), RenderDataDirtyTypeClasses.Clipping);
		}
	}

	public void UIEOnOpacityChanged(VisualElement ve, bool hierarchical = false)
	{
		if (ve.renderChainData.isInChain)
		{
			if (m_BlockDirtyRegistration)
			{
				throw new InvalidOperationException("VisualElements cannot change opacity under an active visual tree during generateVisualContent callback execution nor during visual tree rendering");
			}
			m_DirtyTracker.RegisterDirty(ve, (RenderDataDirtyTypes)(0x80 | (hierarchical ? 256 : 0)), RenderDataDirtyTypeClasses.Opacity);
		}
	}

	public void UIEOnColorChanged(VisualElement ve)
	{
		if (ve.renderChainData.isInChain)
		{
			if (m_BlockDirtyRegistration)
			{
				throw new InvalidOperationException("VisualElements cannot change background color under an active visual tree during generateVisualContent callback execution nor during visual tree rendering");
			}
			m_DirtyTracker.RegisterDirty(ve, RenderDataDirtyTypes.Color, RenderDataDirtyTypeClasses.Color);
		}
	}

	public void UIEOnTransformOrSizeChanged(VisualElement ve, bool transformChanged, bool clipRectSizeChanged)
	{
		if (ve.renderChainData.isInChain)
		{
			if (m_BlockDirtyRegistration)
			{
				throw new InvalidOperationException("VisualElements cannot change size or transform under an active visual tree during generateVisualContent callback execution nor during visual tree rendering");
			}
			RenderDataDirtyTypes dirtyTypes = (RenderDataDirtyTypes)((transformChanged ? 1 : 0) | (clipRectSizeChanged ? 2 : 0));
			m_DirtyTracker.RegisterDirty(ve, dirtyTypes, RenderDataDirtyTypeClasses.TransformSize);
		}
	}

	public void UIEOnVisualsChanged(VisualElement ve, bool hierarchical)
	{
		if (ve.renderChainData.isInChain)
		{
			if (m_BlockDirtyRegistration)
			{
				throw new InvalidOperationException("VisualElements cannot be marked for dirty repaint under an active visual tree during generateVisualContent callback execution nor during visual tree rendering");
			}
			m_DirtyTracker.RegisterDirty(ve, (RenderDataDirtyTypes)(0x10 | (hierarchical ? 32 : 0)), RenderDataDirtyTypeClasses.Visuals);
		}
	}

	public void UIEOnOpacityIdChanged(VisualElement ve)
	{
		if (ve.renderChainData.isInChain)
		{
			if (m_BlockDirtyRegistration)
			{
				throw new InvalidOperationException("VisualElements cannot for opacity id change under an active visual tree during generateVisualContent callback execution nor during visual tree rendering");
			}
			m_DirtyTracker.RegisterDirty(ve, RenderDataDirtyTypes.VisualsOpacityId, RenderDataDirtyTypeClasses.Visuals);
		}
	}

	public void UIEOnDisableRenderingChanged(VisualElement ve)
	{
		if (ve.renderChainData.isInChain)
		{
			if (m_BlockDirtyRegistration)
			{
				throw new InvalidOperationException("VisualElements cannot change their display style during generateVisualContent callback execution nor during visual tree rendering");
			}
			CommandManipulator.DisableElementRendering(this, ve, ve.disableRendering);
		}
	}

	internal void EnsureFitsDepth(int depth)
	{
		m_DirtyTracker.EnsureFits(depth);
	}

	internal void ChildWillBeRemoved(VisualElement ve)
	{
		if (ve.renderChainData.dirtiedValues != RenderDataDirtyTypes.None)
		{
			m_DirtyTracker.ClearDirty(ve, ~ve.renderChainData.dirtiedValues);
		}
		Debug.Assert(ve.renderChainData.dirtiedValues == RenderDataDirtyTypes.None);
		Debug.Assert(ve.renderChainData.prevDirty == null);
		Debug.Assert(ve.renderChainData.nextDirty == null);
	}

	internal RenderChainCommand AllocCommand()
	{
		return m_CommandPool.Get();
	}

	internal void FreeCommand(RenderChainCommand cmd)
	{
		cmd.Reset();
		m_CommandPool.Return(cmd);
	}

	internal void OnRenderCommandAdded(RenderChainCommand command)
	{
		if (command.prev == null)
		{
			m_FirstCommand = command;
		}
	}

	internal void OnRenderCommandsRemoved(RenderChainCommand firstCommand, RenderChainCommand lastCommand)
	{
		if (firstCommand.prev == null)
		{
			m_FirstCommand = lastCommand.next;
		}
	}

	internal void RepaintTexturedElements()
	{
		for (VisualElement visualElement = GetFirstElementInPanel(m_FirstCommand?.owner); visualElement != null; visualElement = visualElement.renderChainData.next)
		{
			if (visualElement.renderChainData.textures != null)
			{
				UIEOnVisualsChanged(visualElement, hierarchical: false);
			}
		}
		UIEOnOpacityChanged(panel.visualTree);
	}

	public ExtraRenderChainVEData GetOrAddExtraData(VisualElement ve)
	{
		if (!m_ExtraData.TryGetValue(ve, out var value))
		{
			value = m_ExtraDataPool.Get();
			m_ExtraData.Add(ve, value);
			ve.renderChainData.flags |= RenderDataFlags.HasExtraData;
		}
		return value;
	}

	public void FreeExtraData(VisualElement ve)
	{
		Debug.Assert(ve.renderChainData.hasExtraData);
		Debug.Assert(!ve.renderChainData.hasExtraMeshes);
		m_ExtraData.Remove(ve, out var value);
		m_ExtraDataPool.Return(value);
		ve.renderChainData.flags &= ~RenderDataFlags.HasExtraData;
	}

	public void InsertExtraMesh(VisualElement ve, MeshHandle mesh)
	{
		ExtraRenderChainVEData orAddExtraData = GetOrAddExtraData(ve);
		BasicNode<MeshHandle> basicNode = m_MeshHandleNodePool.Get();
		basicNode.data = mesh;
		basicNode.InsertFirst(ref orAddExtraData.extraMesh);
		ve.renderChainData.flags |= RenderDataFlags.HasExtraMeshes;
	}

	public void FreeExtraMeshes(VisualElement ve)
	{
		if (ve.renderChainData.hasExtraMeshes)
		{
			ExtraRenderChainVEData extraRenderChainVEData = m_ExtraData[ve];
			BasicNode<MeshHandle> basicNode = extraRenderChainVEData.extraMesh;
			extraRenderChainVEData.extraMesh = null;
			while (basicNode != null)
			{
				device.Free(basicNode.data);
				BasicNode<MeshHandle> next = basicNode.next;
				basicNode.data = null;
				basicNode.next = null;
				m_MeshHandleNodePool.Return(basicNode);
				basicNode = next;
			}
			ve.renderChainData.flags &= ~RenderDataFlags.HasExtraMeshes;
		}
	}

	public void InsertTexture(VisualElement ve, Texture src, TextureId id, bool isAtlas)
	{
		BasicNode<TextureEntry> basicNode = m_TexturePool.Get();
		basicNode.data.source = src;
		basicNode.data.actual = id;
		basicNode.data.replaced = isAtlas;
		basicNode.InsertFirst(ref ve.renderChainData.textures);
	}

	public void ResetTextures(VisualElement ve)
	{
		AtlasBase atlasBase = atlas;
		TextureRegistry textureRegistry = m_TextureRegistry;
		BasicNodePool<TextureEntry> texturePool = m_TexturePool;
		BasicNode<TextureEntry> basicNode = ve.renderChainData.textures;
		ve.renderChainData.textures = null;
		while (basicNode != null)
		{
			BasicNode<TextureEntry> next = basicNode.next;
			if (basicNode.data.replaced)
			{
				atlasBase.ReturnAtlas(ve, basicNode.data.source as Texture2D, basicNode.data.actual);
			}
			else
			{
				textureRegistry.Release(basicNode.data.actual);
			}
			texturePool.Return(basicNode);
			basicNode = next;
		}
	}

	private void DrawStats()
	{
		bool flag = device != null;
		float num = 12f;
		Rect position = new Rect(30f, 60f, 1000f, 100f);
		GUI.Box(new Rect(20f, 40f, 200f, flag ? 380 : 256), "UI Toolkit Draw Stats");
		GUI.Label(position, "Elements added\t: " + m_Stats.elementsAdded);
		position.y += num;
		GUI.Label(position, "Elements removed\t: " + m_Stats.elementsRemoved);
		position.y += num;
		GUI.Label(position, "Mesh allocs allocated\t: " + m_Stats.newMeshAllocations);
		position.y += num;
		GUI.Label(position, "Mesh allocs updated\t: " + m_Stats.updatedMeshAllocations);
		position.y += num;
		GUI.Label(position, "Clip update roots\t: " + m_Stats.recursiveClipUpdates);
		position.y += num;
		GUI.Label(position, "Clip update total\t: " + m_Stats.recursiveClipUpdatesExpanded);
		position.y += num;
		GUI.Label(position, "Opacity update roots\t: " + m_Stats.recursiveOpacityUpdates);
		position.y += num;
		GUI.Label(position, "Opacity update total\t: " + m_Stats.recursiveOpacityUpdatesExpanded);
		position.y += num;
		GUI.Label(position, "Opacity ID update\t: " + m_Stats.opacityIdUpdates);
		position.y += num;
		GUI.Label(position, "Xform update roots\t: " + m_Stats.recursiveTransformUpdates);
		position.y += num;
		GUI.Label(position, "Xform update total\t: " + m_Stats.recursiveTransformUpdatesExpanded);
		position.y += num;
		GUI.Label(position, "Xformed by bone\t: " + m_Stats.boneTransformed);
		position.y += num;
		GUI.Label(position, "Xformed by skipping\t: " + m_Stats.skipTransformed);
		position.y += num;
		GUI.Label(position, "Xformed by nudging\t: " + m_Stats.nudgeTransformed);
		position.y += num;
		GUI.Label(position, "Xformed by repaint\t: " + m_Stats.visualUpdateTransformed);
		position.y += num;
		GUI.Label(position, "Visual update roots\t: " + m_Stats.recursiveVisualUpdates);
		position.y += num;
		GUI.Label(position, "Visual update total\t: " + m_Stats.recursiveVisualUpdatesExpanded);
		position.y += num;
		GUI.Label(position, "Visual update flats\t: " + m_Stats.nonRecursiveVisualUpdates);
		position.y += num;
		GUI.Label(position, "Dirty processed\t: " + m_Stats.dirtyProcessed);
		position.y += num;
		GUI.Label(position, "Group-xform updates\t: " + m_Stats.groupTransformElementsChanged);
		position.y += num;
		if (flag)
		{
			position.y += num;
			UIRenderDevice.DrawStatistics drawStatistics = device.GatherDrawStatistics();
			GUI.Label(position, "Frame index\t: " + drawStatistics.currentFrameIndex);
			position.y += num;
			GUI.Label(position, "Command count\t: " + drawStatistics.commandCount);
			position.y += num;
			GUI.Label(position, "Skip cmd counts\t: " + drawStatistics.skippedCommandCount);
			position.y += num;
			GUI.Label(position, "Draw commands\t: " + drawStatistics.drawCommandCount);
			position.y += num;
			GUI.Label(position, "Disable commands\t: " + drawStatistics.disableCommandCount);
			position.y += num;
			GUI.Label(position, "Draw ranges\t: " + drawStatistics.drawRangeCount);
			position.y += num;
			GUI.Label(position, "Draw range calls\t: " + drawStatistics.drawRangeCallCount);
			position.y += num;
			GUI.Label(position, "Material sets\t: " + drawStatistics.materialSetCount);
			position.y += num;
			GUI.Label(position, "Stencil changes\t: " + drawStatistics.stencilRefChanges);
			position.y += num;
			GUI.Label(position, "Immediate draws\t: " + drawStatistics.immediateDraws);
			position.y += num;
			GUI.Label(position, "Total triangles\t: " + drawStatistics.totalIndices / 3);
			position.y += num;
		}
	}

	private static VisualElement GetFirstElementInPanel(VisualElement ve)
	{
		while (ve != null)
		{
			VisualElement prev = ve.renderChainData.prev;
			if (prev == null || !prev.renderChainData.isInChain)
			{
				break;
			}
			ve = ve.renderChainData.prev;
		}
		return ve;
	}
}
