#define UNITY_ASSERTIONS
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Profiling;
using UnityEngine.Pool;
using UnityEngine.TextCore.LowLevel;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements.UIR;

namespace UnityEngine.UIElements;

internal class ATGTextJobSystem
{
	private class ManagedJobData
	{
		public TextElement textElement;

		public MeshGenerationNode node;

		public NativeTextInfo textInfo;

		public bool success;

		public void Release()
		{
			s_JobDataPool.Release(this);
		}
	}

	private struct GenerateTextJobData : IJobParallelFor
	{
		public GCHandle managedJobDataHandle;

		public void Execute(int index)
		{
			List<ManagedJobData> list = (List<ManagedJobData>)managedJobDataHandle.Target;
			ManagedJobData managedJobData = list[index];
			TextElement textElement = managedJobData.textElement;
			bool generateNativeSettings = textElement.computedStyle.unityFontDefinition.fontAsset != null;
			(managedJobData.textInfo, managedJobData.success) = textElement.uitkTextHandle.UpdateNative(generateNativeSettings);
		}
	}

	private GCHandle textJobDatasHandle;

	private List<ManagedJobData> textJobDatas = new List<ManagedJobData>();

	private bool hasPendingTextWork;

	private static UnityEngine.Pool.ObjectPool<ManagedJobData> s_JobDataPool = new UnityEngine.Pool.ObjectPool<ManagedJobData>(() => new ManagedJobData(), null, (ManagedJobData inst) =>
	{
		inst.textElement = null;
	}, null, collectionCheck: false);

	internal MeshGenerationCallback m_GenerateTextJobifiedCallback;

	internal MeshGenerationCallback m_AddDrawEntriesCallback;

	private static readonly ProfilerMarker k_GenerateTextMarker = new ProfilerMarker("ATGTextJob.GenerateText");

	private static readonly ProfilerMarker k_ATGTextJobMarker = new ProfilerMarker("ATGTextJob");

	private static readonly bool k_IsMultiThreaded = true;

	private List<Texture2D> atlases = new List<Texture2D>();

	private List<float> sdfScalesArray = new List<float>();

	private List<NativeSlice<Vertex>> verticesArray = new List<NativeSlice<Vertex>>();

	private List<NativeSlice<ushort>> indicesArray = new List<NativeSlice<ushort>>();

	private List<GlyphRenderMode> renderModes = new List<GlyphRenderMode>();

	public ATGTextJobSystem()
	{
		m_GenerateTextJobifiedCallback = GenerateTextJobified;
		m_AddDrawEntriesCallback = AddDrawEntries;
	}

	public void GenerateText(MeshGenerationContext mgc, TextElement textElement)
	{
		mgc.InsertMeshGenerationNode(out var node);
		ManagedJobData managedJobData = s_JobDataPool.Get();
		managedJobData.textElement = textElement;
		managedJobData.node = node;
		textJobDatas.Add(managedJobData);
		if (!hasPendingTextWork)
		{
			hasPendingTextWork = true;
			textJobDatasHandle = GCHandle.Alloc(textJobDatas);
			MeshGenerationCallbackType callbackType = ((!k_IsMultiThreaded) ? MeshGenerationCallbackType.Work : MeshGenerationCallbackType.Fork);
			mgc.AddMeshGenerationCallback(m_GenerateTextJobifiedCallback, null, callbackType, isJobDependent: false);
		}
	}

	private void GenerateTextJobified(MeshGenerationContext mgc, object _)
	{
		GenerateTextJobData jobData = new GenerateTextJobData
		{
			managedJobDataHandle = textJobDatasHandle
		};
		if (textJobDatas.Count > 0)
		{
			textJobDatas[0].textElement.uitkTextHandle.InitTextLib();
		}
		FontAsset.CreateHbFaceIfNeeded();
		for (int i = 0; i < textJobDatas.Count; i++)
		{
			ManagedJobData managedJobData = textJobDatas[i];
			TextElement textElement = managedJobData.textElement;
			FontAsset fontAsset = TextUtilities.GetFontAsset(textElement);
			TextUtilities.GetTextSettingsFrom(textElement).UpdateNativeTextSettings();
			fontAsset.EnsureNativeFontAssetIsCreated();
			if (textElement.computedStyle.unityFontDefinition.fontAsset == null)
			{
				textElement.uitkTextHandle.ConvertUssToNativeTextGenerationSettings();
			}
		}
		if (k_IsMultiThreaded)
		{
			JobHandle jobHandle = jobData.ScheduleOrRunJob(textJobDatas.Count, 1);
			mgc.AddMeshGenerationJob(jobHandle);
		}
		else
		{
			for (int j = 0; j < textJobDatas.Count; j++)
			{
				jobData.Execute(j);
			}
		}
		mgc.AddMeshGenerationCallback(m_AddDrawEntriesCallback, null, MeshGenerationCallbackType.Work, isJobDependent: true);
	}

	private void AddDrawEntries(MeshGenerationContext mgc, object _)
	{
		foreach (ManagedJobData textJobData in textJobDatas)
		{
			if (textJobData.success)
			{
				NativeTextInfo textInfo = textJobData.textInfo;
				textJobData.textElement.uitkTextHandle.ProcessMeshInfos(textInfo);
				textJobData.textElement.uitkTextHandle.UpdateATGTextEventHandler();
				FontAsset.UpdateFontAssetsInUpdateQueue();
				mgc.GetTempMeshAllocator(out var allocator);
				ConvertMeshInfoToUIRVertex(textInfo.meshInfos, allocator, textJobData.textElement, ref atlases, ref verticesArray, ref indicesArray, ref renderModes, ref sdfScalesArray);
				mgc.Begin(textJobData.node.GetParentEntry(), textJobData.textElement);
				mgc.meshGenerator.DrawText(verticesArray, indicesArray, atlases, renderModes, sdfScalesArray);
				textJobData.textElement.OnGenerateTextOverNative(mgc);
				atlases.Clear();
				verticesArray.Clear();
				indicesArray.Clear();
				renderModes.Clear();
				sdfScalesArray.Clear();
				mgc.End();
			}
			textJobData.Release();
		}
		hasPendingTextWork = false;
		textJobDatas.Clear();
		textJobDatasHandle.Free();
	}

	private static void ConvertMeshInfoToUIRVertex(ATGMeshInfo[] meshInfos, TempMeshAllocator alloc, TextElement visualElement, ref List<Texture2D> atlases, ref List<NativeSlice<Vertex>> verticesArray, ref List<NativeSlice<ushort>> indicesArray, ref List<GlyphRenderMode> renderModes, ref List<float> sdfScales)
	{
		float num = 1f / visualElement.scaledPixelsPerPoint;
		for (int i = 0; i < meshInfos.Length; i++)
		{
			ATGMeshInfo aTGMeshInfo = meshInfos[i];
			int b = (int)(UIRenderDevice.maxVerticesPerPage & -4);
			bool hasMultipleColors = aTGMeshInfo.hasMultipleColors;
			if (hasMultipleColors)
			{
				visualElement.renderChainData.flags |= RenderDataFlags.IsIgnoringDynamicColorHint;
			}
			else
			{
				visualElement.renderChainData.flags &= ~RenderDataFlags.IsIgnoringDynamicColorHint;
			}
			for (int j = 0; j < aTGMeshInfo.textElementInfoIndicesByAtlas.Count; j++)
			{
				List<int> list = aTGMeshInfo.textElementInfoIndicesByAtlas[j];
				int num2 = list.Count * 4;
				while (num2 > 0)
				{
					int num3 = Mathf.Min(num2, b);
					int num4 = num3 >> 2;
					int indexCount = num4 * 6;
					FontAsset fontAsset = aTGMeshInfo.fontAsset;
					atlases.Add(fontAsset.atlasTextures[j]);
					renderModes.Add(fontAsset.atlasRenderMode);
					float item = 0f;
					List<GlyphRenderMode> obj = renderModes;
					if (!TextGeneratorUtilities.IsBitmapRendering(obj[obj.Count - 1]))
					{
						List<Texture2D> obj2 = atlases;
						if (obj2[obj2.Count - 1].format == TextureFormat.Alpha8)
						{
							item = fontAsset.atlasPadding + 1;
						}
					}
					sdfScales.Add(item);
					bool flag = fontAsset.atlasRenderMode != GlyphRenderMode.SMOOTH && fontAsset.atlasRenderMode != GlyphRenderMode.COLOR;
					bool isDynamicColor = !hasMultipleColors && (RenderEvents.NeedsColorID(visualElement) || (flag && RenderEvents.NeedsTextCoreSettings(visualElement)));
					alloc.AllocateTempMesh(num3, indexCount, out var vertices, out var indices);
					Vector2 min = visualElement.contentRect.min;
					int num5 = 0;
					int num6 = 0;
					int num7 = 0;
					while (num5 < num3)
					{
						bool isColorGlyph = fontAsset.atlasRenderMode == GlyphRenderMode.COLOR || fontAsset.atlasRenderMode == GlyphRenderMode.COLOR_HINTED;
						NativeTextElementInfo nativeTextElementInfo = aTGMeshInfo.textElementInfos[list[num6]];
						vertices[num5] = MeshGenerator.ConvertTextVertexToUIRVertex(nativeTextElementInfo.bottomLeft, min, isDynamicColor, isColorGlyph);
						vertices[num5 + 1] = MeshGenerator.ConvertTextVertexToUIRVertex(nativeTextElementInfo.topLeft, min, isDynamicColor, isColorGlyph);
						vertices[num5 + 2] = MeshGenerator.ConvertTextVertexToUIRVertex(nativeTextElementInfo.topRight, min, isDynamicColor, isColorGlyph);
						vertices[num5 + 3] = MeshGenerator.ConvertTextVertexToUIRVertex(nativeTextElementInfo.bottomRight, min, isDynamicColor, isColorGlyph);
						indices[num7] = (ushort)num5;
						indices[num7 + 1] = (ushort)(num5 + 1);
						indices[num7 + 2] = (ushort)(num5 + 2);
						indices[num7 + 3] = (ushort)(num5 + 2);
						indices[num7 + 4] = (ushort)(num5 + 3);
						indices[num7 + 5] = (ushort)num5;
						num5 += 4;
						num6++;
						num7 += 6;
					}
					verticesArray.Add(vertices);
					indicesArray.Add(indices);
					num2 -= num3;
				}
				Debug.Assert(num2 == 0);
			}
		}
	}
}
