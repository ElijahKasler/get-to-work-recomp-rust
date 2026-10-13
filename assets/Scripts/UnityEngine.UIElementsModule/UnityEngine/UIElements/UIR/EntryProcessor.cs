#define UNITY_ASSERTIONS
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace UnityEngine.UIElements.UIR;

internal class EntryProcessor
{
	private struct MaskMesh
	{
		public NativeSlice<Vertex> vertices;

		public NativeSlice<ushort> indices;

		public int indexOffset;
	}

	private EntryPreProcessor m_PreProcessor = new EntryPreProcessor();

	private RenderChain m_RenderChain;

	private VisualElement m_CurrentElement;

	private int m_MaskDepth;

	private int m_MaskDepthPopped;

	private int m_MaskDepthPushed;

	private int m_StencilRef;

	private int m_StencilRefPopped;

	private int m_StencilRefPushed;

	private BMPAlloc m_ClipRectId;

	private BMPAlloc m_ClipRectIdPopped;

	private BMPAlloc m_ClipRectIdPushed;

	private bool m_IsDrawingMask;

	private Stack<MaskMesh> m_MaskMeshes = new Stack<MaskMesh>(1);

	private bool m_VertexDataComputed;

	private Matrix4x4 m_Transform;

	private Color32 m_TransformData;

	private Color32 m_OpacityData;

	private Color32 m_TextCoreSettingsPage;

	private MeshHandle m_Mesh;

	private NativeSlice<Vertex> m_Verts;

	private NativeSlice<ushort> m_Indices;

	private ushort m_IndexOffset;

	private int m_AllocVertexCount;

	private int m_AllocIndex;

	private int m_VertsFilled;

	private int m_IndicesFilled;

	private VertexFlags m_RenderType;

	private bool m_RemapUVs;

	private Rect m_AtlasRect;

	private int m_GradientSettingIndexOffset;

	private bool m_IsTail;

	private RenderChainCommand m_FirstCommand;

	private RenderChainCommand m_LastCommand;

	private static Material s_blitMaterial_LinearToGamma;

	private static Material s_blitMaterial_GammaToLinear;

	private static Material s_blitMaterial_NoChange;

	private static Shader s_blitShader;

	public RenderChainCommand firstHeadCommand { get; private set; }

	public RenderChainCommand lastHeadCommand { get; private set; }

	public RenderChainCommand firstTailCommand { get; private set; }

	public RenderChainCommand lastTailCommand { get; private set; }

	public void Init(Entry root, RenderChain renderChain, VisualElement ve)
	{
		UIRenderDevice device = renderChain.device;
		m_RenderChain = renderChain;
		m_CurrentElement = ve;
		m_PreProcessor.PreProcess(root);
		if (m_PreProcessor.headAllocs.Count == 0 && ve.renderChainData.headMesh != null)
		{
			device.Free(ve.renderChainData.headMesh);
			ve.renderChainData.headMesh = null;
		}
		if (m_PreProcessor.tailAllocs.Count == 0 && ve.renderChainData.tailMesh != null)
		{
			device.Free(ve.renderChainData.tailMesh);
			ve.renderChainData.tailMesh = null;
		}
		if (ve.renderChainData.hasExtraMeshes)
		{
			renderChain.FreeExtraMeshes(ve);
		}
		renderChain.ResetTextures(ve);
		VisualElement parent = m_CurrentElement.hierarchy.parent;
		bool isGroupTransform = m_CurrentElement.renderChainData.isGroupTransform;
		if (parent != null)
		{
			m_MaskDepthPopped = parent.renderChainData.childrenMaskDepth;
			m_StencilRefPopped = parent.renderChainData.childrenStencilRef;
			m_ClipRectIdPopped = (isGroupTransform ? UIRVEShaderInfoAllocator.infiniteClipRect : parent.renderChainData.clipRectID);
		}
		else
		{
			m_MaskDepthPopped = 0;
			m_StencilRefPopped = 0;
			m_ClipRectIdPopped = UIRVEShaderInfoAllocator.infiniteClipRect;
		}
		m_MaskDepthPushed = m_MaskDepthPopped + 1;
		m_StencilRefPushed = m_MaskDepthPopped;
		m_ClipRectIdPushed = m_CurrentElement.renderChainData.clipRectID;
		m_MaskDepth = m_MaskDepthPopped;
		m_StencilRef = m_StencilRefPopped;
		m_ClipRectId = m_ClipRectIdPopped;
		m_VertexDataComputed = false;
		m_Transform = Matrix4x4.identity;
		m_TextCoreSettingsPage = new Color32(0, 0, 0, 0);
		m_MaskMeshes.Clear();
		m_IsDrawingMask = false;
	}

	public void ClearReferences()
	{
		m_PreProcessor.ClearReferences();
		m_RenderChain = null;
		m_CurrentElement = null;
		m_Mesh = null;
		m_FirstCommand = null;
		m_LastCommand = null;
		firstHeadCommand = null;
		lastHeadCommand = null;
		firstTailCommand = null;
		lastTailCommand = null;
	}

	public void ProcessHead()
	{
		m_IsTail = false;
		ProcessFirstAlloc(m_PreProcessor.headAllocs, ref m_CurrentElement.renderChainData.headMesh);
		m_FirstCommand = null;
		m_LastCommand = null;
		ProcessRange(0, m_PreProcessor.childrenIndex - 1);
		firstHeadCommand = m_FirstCommand;
		lastHeadCommand = m_LastCommand;
	}

	public void ProcessTail()
	{
		m_IsTail = true;
		ProcessFirstAlloc(m_PreProcessor.tailAllocs, ref m_CurrentElement.renderChainData.tailMesh);
		m_FirstCommand = null;
		m_LastCommand = null;
		ProcessRange(m_PreProcessor.childrenIndex + 1, m_PreProcessor.flattenedEntries.Count - 1);
		firstTailCommand = m_FirstCommand;
		lastTailCommand = m_LastCommand;
		Debug.Assert(m_MaskDepth == m_MaskDepthPopped);
		Debug.Assert(m_MaskMeshes.Count == 0);
		Debug.Assert(!m_IsDrawingMask);
	}

	private void ProcessRange(int first, int last)
	{
		List<Entry> flattenedEntries = m_PreProcessor.flattenedEntries;
		for (int i = first; i <= last; i++)
		{
			Entry entry = flattenedEntries[i];
			switch (entry.type)
			{
			case EntryType.DrawSolidMesh:
				m_RenderType = VertexFlags.IsSolid;
				ProcessMeshEntry(entry, TextureId.invalid);
				break;
			case EntryType.DrawTexturedMesh:
			{
				Texture texture = entry.texture;
				TextureId atlas = TextureId.invalid;
				if (texture != null)
				{
					if (m_RenderChain.atlas != null && m_RenderChain.atlas.TryGetAtlas(m_CurrentElement, texture as Texture2D, out atlas, out var atlasRect))
					{
						m_RenderType = VertexFlags.IsDynamic;
						m_AtlasRect = new Rect(atlasRect.x, atlasRect.y, atlasRect.width, atlasRect.height);
						m_RemapUVs = true;
						m_RenderChain.InsertTexture(m_CurrentElement, texture, atlas, isAtlas: true);
					}
					else
					{
						m_RenderType = VertexFlags.IsTextured;
						atlas = TextureRegistry.instance.Acquire(texture);
						m_RenderChain.InsertTexture(m_CurrentElement, texture, atlas, isAtlas: false);
					}
				}
				else
				{
					m_RenderType = VertexFlags.IsSolid;
				}
				ProcessMeshEntry(entry, atlas);
				m_RemapUVs = false;
				break;
			}
			case EntryType.DrawTexturedMeshSkipAtlas:
			{
				m_RenderType = VertexFlags.IsTextured;
				TextureId textureId2 = TextureRegistry.instance.Acquire(entry.texture);
				m_RenderChain.InsertTexture(m_CurrentElement, entry.texture, textureId2, isAtlas: false);
				ProcessMeshEntry(entry, textureId2);
				break;
			}
			case EntryType.DrawTextMesh:
			{
				m_RenderType = VertexFlags.IsText;
				TextureId textureId3 = TextureRegistry.instance.Acquire(entry.texture);
				m_RenderChain.InsertTexture(m_CurrentElement, entry.texture, textureId3, isAtlas: false);
				ProcessMeshEntry(entry, textureId3);
				break;
			}
			case EntryType.DrawGradients:
			{
				m_RenderType = VertexFlags.IsSvgGradients;
				GradientRemap gradientRemap = m_RenderChain.vectorImageManager.AddUser(entry.gradientsOwner, m_CurrentElement);
				m_GradientSettingIndexOffset = gradientRemap.destIndex;
				TextureId textureId;
				if (gradientRemap.atlas != TextureId.invalid)
				{
					textureId = gradientRemap.atlas;
				}
				else
				{
					textureId = TextureRegistry.instance.Acquire(entry.gradientsOwner.atlas);
					m_RenderChain.InsertTexture(m_CurrentElement, entry.gradientsOwner.atlas, textureId, isAtlas: false);
				}
				ProcessMeshEntry(entry, textureId);
				m_GradientSettingIndexOffset = -1;
				break;
			}
			case EntryType.DrawImmediate:
			{
				RenderChainCommand renderChainCommand12 = m_RenderChain.AllocCommand();
				renderChainCommand12.type = CommandType.Immediate;
				renderChainCommand12.owner = m_CurrentElement;
				renderChainCommand12.isTail = m_IsTail;
				renderChainCommand12.callback = entry.immediateCallback;
				AppendCommand(renderChainCommand12);
				break;
			}
			case EntryType.DrawImmediateCull:
			{
				RenderChainCommand renderChainCommand11 = m_RenderChain.AllocCommand();
				renderChainCommand11.type = CommandType.ImmediateCull;
				renderChainCommand11.owner = m_CurrentElement;
				renderChainCommand11.isTail = m_IsTail;
				renderChainCommand11.callback = entry.immediateCallback;
				AppendCommand(renderChainCommand11);
				break;
			}
			case EntryType.DrawChildren:
			case EntryType.DedicatedPlaceholder:
				Debug.Assert(condition: false);
				break;
			case EntryType.BeginStencilMask:
				Debug.Assert(m_MaskDepth == m_MaskDepthPopped);
				Debug.Assert(!m_IsDrawingMask);
				m_IsDrawingMask = true;
				m_StencilRef = m_StencilRefPushed;
				Debug.Assert(m_MaskDepth == m_StencilRef);
				break;
			case EntryType.EndStencilMask:
				Debug.Assert(m_IsDrawingMask);
				m_IsDrawingMask = false;
				m_MaskDepth = m_MaskDepthPushed;
				break;
			case EntryType.PopStencilMask:
				Debug.Assert(m_MaskDepth == m_StencilRef + 1);
				DrawReverseMask();
				m_MaskDepth = m_MaskDepthPopped;
				m_StencilRef = m_StencilRefPopped;
				break;
			case EntryType.PushClippingRect:
				m_ClipRectId = m_ClipRectIdPushed;
				break;
			case EntryType.PopClippingRect:
				m_ClipRectId = m_ClipRectIdPopped;
				break;
			case EntryType.PushScissors:
			{
				RenderChainCommand renderChainCommand10 = m_RenderChain.AllocCommand();
				renderChainCommand10.type = CommandType.PushScissor;
				renderChainCommand10.owner = m_CurrentElement;
				renderChainCommand10.isTail = m_IsTail;
				AppendCommand(renderChainCommand10);
				break;
			}
			case EntryType.PopScissors:
			{
				RenderChainCommand renderChainCommand9 = m_RenderChain.AllocCommand();
				renderChainCommand9.type = CommandType.PopScissor;
				renderChainCommand9.owner = m_CurrentElement;
				renderChainCommand9.isTail = m_IsTail;
				AppendCommand(renderChainCommand9);
				break;
			}
			case EntryType.PushGroupMatrix:
			{
				RenderChainCommand renderChainCommand8 = m_RenderChain.AllocCommand();
				renderChainCommand8.type = CommandType.PushView;
				renderChainCommand8.owner = m_CurrentElement;
				renderChainCommand8.isTail = m_IsTail;
				AppendCommand(renderChainCommand8);
				break;
			}
			case EntryType.PopGroupMatrix:
			{
				RenderChainCommand renderChainCommand7 = m_RenderChain.AllocCommand();
				renderChainCommand7.type = CommandType.PopView;
				renderChainCommand7.owner = m_CurrentElement;
				renderChainCommand7.isTail = m_IsTail;
				AppendCommand(renderChainCommand7);
				break;
			}
			case EntryType.PushRenderTexture:
			{
				Debug.Assert(m_MaskDepth == 0, "The RenderTargetMode feature must not be used within a stencil mask.");
				RenderChainCommand renderChainCommand6 = m_RenderChain.AllocCommand();
				renderChainCommand6.type = CommandType.PushRenderTexture;
				renderChainCommand6.owner = m_CurrentElement;
				renderChainCommand6.isTail = m_IsTail;
				AppendCommand(renderChainCommand6);
				break;
			}
			case EntryType.BlitAndPopRenderTexture:
			{
				RenderChainCommand renderChainCommand4 = m_RenderChain.AllocCommand();
				renderChainCommand4.type = CommandType.BlitToPreviousRT;
				renderChainCommand4.owner = m_CurrentElement;
				renderChainCommand4.isTail = m_IsTail;
				renderChainCommand4.state.material = GetBlitMaterial(m_CurrentElement.subRenderTargetMode);
				Debug.Assert(renderChainCommand4.state.material != null);
				AppendCommand(renderChainCommand4);
				RenderChainCommand renderChainCommand5 = m_RenderChain.AllocCommand();
				renderChainCommand5.type = CommandType.PopRenderTexture;
				renderChainCommand5.owner = m_CurrentElement;
				renderChainCommand5.isTail = m_IsTail;
				AppendCommand(renderChainCommand5);
				break;
			}
			case EntryType.PushDefaultMaterial:
			{
				RenderChainCommand renderChainCommand3 = m_RenderChain.AllocCommand();
				renderChainCommand3.type = CommandType.PushDefaultMaterial;
				renderChainCommand3.owner = m_CurrentElement;
				renderChainCommand3.isTail = m_IsTail;
				renderChainCommand3.state.material = entry.material;
				AppendCommand(renderChainCommand3);
				break;
			}
			case EntryType.PopDefaultMaterial:
			{
				RenderChainCommand renderChainCommand2 = m_RenderChain.AllocCommand();
				renderChainCommand2.type = CommandType.PopDefaultMaterial;
				renderChainCommand2.owner = m_CurrentElement;
				renderChainCommand2.isTail = m_IsTail;
				AppendCommand(renderChainCommand2);
				break;
			}
			case EntryType.CutRenderChain:
			{
				RenderChainCommand renderChainCommand = m_RenderChain.AllocCommand();
				renderChainCommand.type = CommandType.CutRenderChain;
				renderChainCommand.owner = m_CurrentElement;
				renderChainCommand.isTail = m_IsTail;
				AppendCommand(renderChainCommand);
				break;
			}
			default:
				throw new NotImplementedException();
			}
		}
	}

	private unsafe void ProcessMeshEntry(Entry entry, TextureId textureId)
	{
		int length = entry.vertices.Length;
		int length2 = entry.indices.Length;
		Debug.Assert(length > 0 == length2 > 0);
		if (length > 0 && length2 > 0)
		{
			if (m_VertsFilled + length > m_AllocVertexCount)
			{
				ProcessNextAlloc();
				Debug.Assert(m_VertsFilled + length <= m_AllocVertexCount);
			}
			if (!m_VertexDataComputed)
			{
				UIRUtility.GetVerticesTransformInfo(m_CurrentElement, out m_Transform);
				m_CurrentElement.renderChainData.verticesSpace = m_Transform;
				m_TransformData = m_RenderChain.shaderInfoAllocator.TransformAllocToVertexData(m_CurrentElement.renderChainData.transformID);
				m_OpacityData = m_RenderChain.shaderInfoAllocator.OpacityAllocToVertexData(m_CurrentElement.renderChainData.opacityID);
				m_VertexDataComputed = true;
			}
			Color32 opacityPage = new Color32(m_OpacityData.r, m_OpacityData.g, 0, 0);
			Color32 color = m_RenderChain.shaderInfoAllocator.ClipRectAllocToVertexData(m_ClipRectId);
			Color32 ids = new Color32(m_TransformData.b, color.b, m_OpacityData.b, 0);
			Color32 xformClipPages = new Color32(m_TransformData.r, m_TransformData.g, color.r, color.g);
			Color32 addFlags = new Color32((byte)m_RenderType, 0, 0, 0);
			if ((entry.flags & EntryFlags.UsesTextCoreSettings) != 0)
			{
				Color32 color2 = m_RenderChain.shaderInfoAllocator.TextCoreSettingsToVertexData(m_CurrentElement.renderChainData.textCoreSettingsID);
				m_TextCoreSettingsPage.r = color2.r;
				m_TextCoreSettingsPage.g = color2.g;
				ids.a = color2.b;
			}
			NativeSlice<Vertex> nativeSlice = m_Verts.Slice(m_VertsFilled, length);
			int indexOffset = m_VertsFilled + m_IndexOffset;
			NativeSlice<ushort> nativeSlice2 = m_Indices.Slice(m_IndicesFilled, length2);
			bool flag = UIRUtility.ShapeWindingIsClockwise(m_MaskDepth, m_StencilRef);
			bool worldFlipsWinding = m_CurrentElement.renderChainData.worldFlipsWinding;
			ConvertMeshJobData job = new ConvertMeshJobData
			{
				vertSrc = (IntPtr)entry.vertices.GetUnsafePtr(),
				vertDst = (IntPtr)nativeSlice.GetUnsafePtr(),
				vertCount = length,
				transform = m_Transform,
				xformClipPages = xformClipPages,
				ids = ids,
				addFlags = addFlags,
				opacityPage = opacityPage,
				textCoreSettingsPage = m_TextCoreSettingsPage,
				usesTextCoreSettings = (((entry.flags & EntryFlags.UsesTextCoreSettings) != 0) ? 1 : 0),
				textureId = textureId.ConvertToGpu(),
				gradientSettingsIndexOffset = m_GradientSettingIndexOffset,
				indexSrc = (IntPtr)entry.indices.GetUnsafePtr(),
				indexDst = (IntPtr)nativeSlice2.GetUnsafePtr(),
				indexCount = nativeSlice2.Length,
				indexOffset = indexOffset,
				flipIndices = ((flag == worldFlipsWinding) ? 1 : 0),
				forceZ = (m_RenderChain.isFlat ? 1 : 0),
				positionZ = (m_IsDrawingMask ? 1f : 0f),
				remapUVs = (m_RemapUVs ? 1 : 0),
				atlasRect = m_AtlasRect
			};
			m_RenderChain.jobManager.Add(ref job);
			if (m_IsDrawingMask)
			{
				m_MaskMeshes.Push(new MaskMesh
				{
					vertices = nativeSlice,
					indices = nativeSlice2,
					indexOffset = indexOffset
				});
			}
			RenderChainCommand renderChainCommand = CreateMeshDrawCommand(m_Mesh, length2, m_IndicesFilled, entry.material, textureId);
			AppendCommand(renderChainCommand);
			if (entry.type == EntryType.DrawTextMesh)
			{
				renderChainCommand.state.sdfScale = entry.textScale;
				renderChainCommand.state.sharpness = entry.fontSharpness;
			}
			m_VertsFilled += length;
			m_IndicesFilled += length2;
		}
	}

	private unsafe void DrawReverseMask()
	{
		MaskMesh result;
		while (m_MaskMeshes.TryPop(out result))
		{
			Debug.Assert(result.indices.Length > 0 == result.vertices.Length > 0);
			if (result.indices.Length > 0 && result.vertices.Length > 0)
			{
				RenderChainCommand next = CreateMeshDrawCommand(m_Mesh, result.indices.Length, m_IndicesFilled, null, TextureId.invalid);
				AppendCommand(next);
				NativeSlice<Vertex> nativeSlice = m_Verts.Slice(m_VertsFilled, result.vertices.Length);
				NativeSlice<ushort> nativeSlice2 = m_Indices.Slice(m_IndicesFilled, result.indices.Length);
				CopyMeshJobData job = new CopyMeshJobData
				{
					vertSrc = (IntPtr)result.vertices.GetUnsafePtr(),
					vertDst = (IntPtr)nativeSlice.GetUnsafePtr(),
					vertCount = result.vertices.Length,
					indexSrc = (IntPtr)result.indices.GetUnsafePtr(),
					indexDst = (IntPtr)nativeSlice2.GetUnsafePtr(),
					indexCount = result.indices.Length,
					indexOffset = m_IndexOffset + m_VertsFilled - result.indexOffset
				};
				m_RenderChain.jobManager.Add(ref job);
				m_IndicesFilled += result.indices.Length;
				m_VertsFilled += result.vertices.Length;
			}
		}
	}

	private RenderChainCommand CreateMeshDrawCommand(MeshHandle mesh, int indexCount, int indexOffset, Material material, TextureId texture)
	{
		RenderChainCommand renderChainCommand = m_RenderChain.AllocCommand();
		renderChainCommand.type = CommandType.Draw;
		renderChainCommand.state = new State
		{
			material = material,
			texture = texture,
			stencilRef = m_StencilRef
		};
		renderChainCommand.mesh = mesh;
		renderChainCommand.indexOffset = indexOffset;
		renderChainCommand.indexCount = indexCount;
		renderChainCommand.owner = m_CurrentElement;
		renderChainCommand.isTail = m_IsTail;
		return renderChainCommand;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void AppendCommand(RenderChainCommand next)
	{
		if (m_FirstCommand == null)
		{
			m_FirstCommand = next;
			m_LastCommand = next;
		}
		else
		{
			next.prev = m_LastCommand;
			m_LastCommand.next = next;
			m_LastCommand = next;
		}
	}

	private void ProcessFirstAlloc(List<EntryPreProcessor.AllocSize> allocList, ref MeshHandle mesh)
	{
		if (allocList.Count > 0)
		{
			EntryPreProcessor.AllocSize allocSize = allocList[0];
			UpdateOrAllocate(ref mesh, allocSize.vertexCount, allocSize.indexCount, m_RenderChain.device, out m_Verts, out m_Indices, out m_IndexOffset, ref m_RenderChain.statsByRef);
			m_AllocVertexCount = (int)mesh.allocVerts.size;
		}
		else
		{
			Debug.Assert(mesh == null);
			m_Verts = default;
			m_Indices = default;
			m_IndexOffset = 0;
			m_AllocVertexCount = 0;
		}
		m_Mesh = mesh;
		m_VertsFilled = 0;
		m_IndicesFilled = 0;
		m_AllocIndex = 0;
	}

	private void ProcessNextAlloc()
	{
		List<EntryPreProcessor.AllocSize> list = (m_IsTail ? m_PreProcessor.tailAllocs : m_PreProcessor.headAllocs);
		Debug.Assert(m_AllocIndex < list.Count - 1);
		EntryPreProcessor.AllocSize allocSize = list[++m_AllocIndex];
		m_Mesh = null;
		UpdateOrAllocate(ref m_Mesh, allocSize.vertexCount, allocSize.indexCount, m_RenderChain.device, out m_Verts, out m_Indices, out m_IndexOffset, ref m_RenderChain.statsByRef);
		m_AllocVertexCount = (int)m_Mesh.allocVerts.size;
		m_RenderChain.InsertExtraMesh(m_CurrentElement, m_Mesh);
		m_VertsFilled = 0;
		m_IndicesFilled = 0;
	}

	private static void UpdateOrAllocate(ref MeshHandle data, int vertexCount, int indexCount, UIRenderDevice device, out NativeSlice<Vertex> verts, out NativeSlice<ushort> indices, out ushort indexOffset, ref ChainBuilderStats stats)
	{
		if (data != null)
		{
			if (data.allocVerts.size >= vertexCount && data.allocIndices.size >= indexCount)
			{
				device.Update(data, (uint)vertexCount, (uint)indexCount, out verts, out indices, out indexOffset);
				stats.updatedMeshAllocations++;
			}
			else
			{
				device.Free(data);
				data = device.Allocate((uint)vertexCount, (uint)indexCount, out verts, out indices, out indexOffset);
				stats.newMeshAllocations++;
			}
		}
		else
		{
			data = device.Allocate((uint)vertexCount, (uint)indexCount, out verts, out indices, out indexOffset);
			stats.newMeshAllocations++;
		}
	}

	private static Material CreateBlitShader(float colorConversion)
	{
		if (s_blitShader == null)
		{
			s_blitShader = Shader.Find(Shaders.k_ColorConversionBlit);
		}
		Debug.Assert(s_blitShader != null, "UI Tollkit Render Event: Shader Not found");
		Material material = new Material(s_blitShader);
		material.hideFlags |= HideFlags.DontSaveInEditor;
		material.SetFloat("_ColorConversion", colorConversion);
		return material;
	}

	private static Material GetBlitMaterial(VisualElement.RenderTargetMode mode)
	{
		switch (mode)
		{
		case VisualElement.RenderTargetMode.GammaToLinear:
			if (s_blitMaterial_GammaToLinear == null)
			{
				s_blitMaterial_GammaToLinear = CreateBlitShader(-1f);
			}
			return s_blitMaterial_GammaToLinear;
		case VisualElement.RenderTargetMode.LinearToGamma:
			if (s_blitMaterial_LinearToGamma == null)
			{
				s_blitMaterial_LinearToGamma = CreateBlitShader(1f);
			}
			return s_blitMaterial_LinearToGamma;
		case VisualElement.RenderTargetMode.NoColorConversion:
			if (s_blitMaterial_NoChange == null)
			{
				s_blitMaterial_NoChange = CreateBlitShader(0f);
			}
			return s_blitMaterial_NoChange;
		default:
			Debug.LogError($"No Shader for Unsupported RenderTargetMode: {mode}");
			return null;
		}
	}
}
