using UnityEngine;
using UnityEngine.Rendering;

public class GPUDecalUtils : MonoBehaviour
{
	public struct ReadableVertex
	{
		public float posX;

		public float posY;

		public float posZ;

		public float normalX;

		public float normalY;

		public float normalZ;

		public float fade;

		public float uvX;

		public float uvY;

		public float uv2X;

		public float uv2Y;

		public float pad;
	}

	public struct ReadableVertexTangents
	{
		public float posX;

		public float posY;

		public float posZ;

		public float normalX;

		public float normalY;

		public float normalZ;

		public float tangentX;

		public float tangentY;

		public float tangentZ;

		public float tangentW;

		public float fade;

		public float uvX;

		public float uvY;

		public float uv2X;

		public float uv2Y;

		public float pad;
	}

	private struct Triangle2
	{
		public float worldPosAx;

		public float worldPosAy;

		public float worldPosAz;

		public float worldNormalAx;

		public float worldNormalAy;

		public float worldNormalAz;

		public float fadeA;

		public float uvAx;

		public float uvAy;

		public float uvA2x;

		public float uvA2y;

		public float pad1;

		public float worldPosBx;

		public float worldPosBy;

		public float worldPosBz;

		public float worldNormalBx;

		public float worldNormalBy;

		public float worldNormalBz;

		public float pad2;

		public float uvBx;

		public float uvBy;

		public float uvB2x;

		public float uvB2y;

		public float fadeB;

		public float worldPosCx;

		public float worldPosCy;

		public float worldPosCz;

		public float worldNormalCx;

		public float worldNormalCy;

		public float worldNormalCz;

		public float fadeC;

		public float uvCx;

		public float uvCy;

		public float uvC2x;

		public float uvC2y;

		public float decalID;
	}

	private struct Triangle2Tangents
	{
		public float worldPosAx;

		public float worldPosAy;

		public float worldPosAz;

		public float worldNormalAx;

		public float worldNormalAy;

		public float worldNormalAz;

		public float tangentAx;

		public float tangentAy;

		public float tangentAz;

		public float tangentAw;

		public float fadeA;

		public float uvAx;

		public float uvAy;

		public float uvA2x;

		public float uvA2y;

		public float pad1;

		public float worldPosBx;

		public float worldPosBy;

		public float worldPosBz;

		public float worldNormalBx;

		public float worldNormalBy;

		public float worldNormalBz;

		public float tangentBx;

		public float tangentBy;

		public float tangentBz;

		public float tangentBw;

		public float pad2;

		public float uvBx;

		public float uvBy;

		public float uvB2x;

		public float uvB2y;

		public float fadeB;

		public float worldPosCx;

		public float worldPosCy;

		public float worldPosCz;

		public float worldNormalCx;

		public float worldNormalCy;

		public float worldNormalCz;

		public float tangentCx;

		public float tangentCy;

		public float tangentCz;

		public float tangentCw;

		public float fadeC;

		public float uvCx;

		public float uvCy;

		public float uvC2x;

		public float uvC2y;

		public float decalID;
	}

	private static Material writeMat;

	private static RenderTexture tempRT;

	private static ComputeBuffer tempVBuffer;

	private static ComputeBuffer tempArgBuffer;

	private const int PASS_WRITEFIRST = 0;

	private const int PASS_WRITESECOND = 1;

	private const int PASS_WRITESECOND_TRAIL = 2;

	private const int PASS_WRITESECOND_NORMAL = 3;

	private const int PASS_WRITESECOND_TRAIL_NORMAL = 4;

	private const int PASS_CLEAR = 5;

	private const int PASS_CLEAR_NORMAL = 6;

	private static uint[] emptyArgs;

	private static uint[] emptyCount;

	private static Vector3 curDecalEdgeA;

	private static Vector3 curDecalEdgeB;

	private static Vector3 matrixRight;

	private static Vector3 matrixUp;

	private static Vector3 matrixForward;

	private static Vector4 curDecalEdgePlane;

	private static int pGPUDecalVBuffer;

	private static int pLightmap;

	private static int pLightmapInd;

	private static int pShadowmask;

	private static int pDecalParentMatrix;

	private static int pDecalBufferSize;

	private static int pDecalID;

	private static int pDecalMatrix;

	private static int pDecalPlane0;

	private static int pDecalPlane1;

	private static int pDecalAngleClip;

	private static int pDecalLightmapST;

	private static int pTempVertexBuffer;

	private static int pDecalTrailFP0;

	private static int pDecalTrailFP1;

	private static int pDecalTrailFP2;

	private static int pDecalTrailFT0;

	private static int pDecalTrailFT1;

	private static int pDecalTrailFT2;

	private static int pDecalTrailSP0;

	private static int pDecalTrailSP1;

	private static int pDecalTrailSP2;

	private static int pDecalTrailST0;

	private static int pDecalTrailST1;

	private static int pDecalTrailST2;

	private static int pDecalOpacity;

	private static bool initialized;

	private static VertexAttributeDescriptor[] layout;

	private static VertexAttributeDescriptor[] layoutTangents;

	public static void PrewarmStaticData()
	{
		if (!initialized)
		{
			writeMat = new Material(Shader.Find("Hidden/fGPUDecalWriteShader"));
			tempRT = new RenderTexture(1, 1, 0, RenderTextureFormat.ARGBFloat, RenderTextureReadWrite.Linear);
			tempRT.Create();
			emptyArgs = new uint[4];
			emptyArgs[0] = 0u;
			emptyArgs[1] = 1u;
			emptyArgs[2] = 0u;
			emptyArgs[3] = 0u;
			emptyCount = new uint[4];
			emptyCount[0] = 0u;
			emptyCount[1] = 0u;
			emptyCount[2] = 0u;
			emptyCount[3] = 0u;
			pGPUDecalVBuffer = Shader.PropertyToID("fGPUDecalVBuffer");
			pLightmap = Shader.PropertyToID("_Lightmap");
			pLightmapInd = Shader.PropertyToID("_LightmapInd");
			pShadowmask = Shader.PropertyToID("_ShadowMask");
			pDecalParentMatrix = Shader.PropertyToID("_DecalParentMatrix");
			pDecalBufferSize = Shader.PropertyToID("_DecalBufferSize");
			pDecalID = Shader.PropertyToID("_DecalID");
			pDecalMatrix = Shader.PropertyToID("_DecalMatrix");
			pDecalPlane0 = Shader.PropertyToID("_DecalPlane0");
			pDecalPlane1 = Shader.PropertyToID("_DecalPlane1");
			pDecalAngleClip = Shader.PropertyToID("_DecalAngleClip");
			pDecalLightmapST = Shader.PropertyToID("_DecalLightmapST");
			pTempVertexBuffer = Shader.PropertyToID("_TempVertexBuffer");
			pDecalTrailFP0 = Shader.PropertyToID("_DecalTrailFP0");
			pDecalTrailFP1 = Shader.PropertyToID("_DecalTrailFP1");
			pDecalTrailFP2 = Shader.PropertyToID("_DecalTrailFP2");
			pDecalTrailFT0 = Shader.PropertyToID("_DecalTrailFT0");
			pDecalTrailFT1 = Shader.PropertyToID("_DecalTrailFT1");
			pDecalTrailFT2 = Shader.PropertyToID("_DecalTrailFT2");
			pDecalTrailSP0 = Shader.PropertyToID("_DecalTrailSP0");
			pDecalTrailSP1 = Shader.PropertyToID("_DecalTrailSP1");
			pDecalTrailSP2 = Shader.PropertyToID("_DecalTrailSP2");
			pDecalTrailST0 = Shader.PropertyToID("_DecalTrailST0");
			pDecalTrailST1 = Shader.PropertyToID("_DecalTrailST1");
			pDecalTrailST2 = Shader.PropertyToID("_DecalTrailST2");
			pDecalOpacity = Shader.PropertyToID("_DecalOpacity");
			layout = new VertexAttributeDescriptor[6]
			{
				new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0),
				new VertexAttributeDescriptor(VertexAttribute.Normal),
				new VertexAttributeDescriptor(VertexAttribute.Color, VertexAttributeFormat.Float32, 1),
				new VertexAttributeDescriptor(VertexAttribute.TexCoord0, VertexAttributeFormat.Float32, 2),
				new VertexAttributeDescriptor(VertexAttribute.TexCoord1, VertexAttributeFormat.Float32, 2),
				new VertexAttributeDescriptor(VertexAttribute.TexCoord2, VertexAttributeFormat.Float32, 1)
			};
			layoutTangents = new VertexAttributeDescriptor[7]
			{
				new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0),
				new VertexAttributeDescriptor(VertexAttribute.Normal),
				new VertexAttributeDescriptor(VertexAttribute.Tangent, VertexAttributeFormat.Float32, 4),
				new VertexAttributeDescriptor(VertexAttribute.Color, VertexAttributeFormat.Float32, 1),
				new VertexAttributeDescriptor(VertexAttribute.TexCoord0, VertexAttributeFormat.Float32, 2),
				new VertexAttributeDescriptor(VertexAttribute.TexCoord1, VertexAttributeFormat.Float32, 2),
				new VertexAttributeDescriptor(VertexAttribute.TexCoord2, VertexAttributeFormat.Float32, 1)
			};
			initialized = true;
		}
	}

	private static void SetTris(Mesh mesh, int count)
	{
		int[] array = new int[count * 3];
		for (int i = 0; i < count; i++)
		{
			array[i * 3] = i * 3;
			array[i * 3 + 1] = i * 3 + 1;
			array[i * 3 + 2] = i * 3 + 2;
		}
		mesh.triangles = array;
	}

	public static DecalUtils.Group CreateGroup(DecalUtils.GroupDesc desc)
	{
		int maxTrisTotal = desc.maxTrisTotal;
		ComputeBuffer computeBuffer = new ComputeBuffer(maxTrisTotal, desc.tangents ? 192 : 144);
		if (desc.tangents)
		{
			computeBuffer.SetData(new Triangle2Tangents[maxTrisTotal]);
		}
		else
		{
			computeBuffer.SetData(new Triangle2[maxTrisTotal]);
		}
		if (tempVBuffer == null || tempVBuffer.count < desc.maxTrisInDecal)
		{
			if (tempVBuffer != null)
			{
				tempVBuffer.Release();
			}
			tempVBuffer = new ComputeBuffer(desc.maxTrisInDecal, 100);
		}
		PrewarmStaticData();
		int num = 4;
		ComputeBuffer computeBuffer2 = new ComputeBuffer(1, num * 4, ComputeBufferType.DrawIndirect);
		computeBuffer2.SetData(emptyArgs);
		ComputeBuffer computeBuffer3 = new ComputeBuffer(1, num * 4, ComputeBufferType.DrawIndirect);
		computeBuffer3.SetData(emptyCount);
		if (tempArgBuffer == null)
		{
			tempArgBuffer = new ComputeBuffer(1, num * 4, ComputeBufferType.DrawIndirect);
			tempArgBuffer.SetData(emptyArgs);
		}
		Transform transform = ((desc.parent != null) ? desc.parent.transform : null);
		GameObject gameObject = null;
		Mesh mesh = null;
		if (!desc.indirectDraw)
		{
			gameObject = new GameObject();
			gameObject.name = "Decals";
			Transform obj = gameObject.transform;
			obj.parent = transform;
			obj.localPosition = Vector3.zero;
			obj.localRotation = Quaternion.identity;
			obj.localScale = Vector3.one;
			mesh = new Mesh();
			mesh.SetVertexBufferParams(maxTrisTotal * 3, desc.tangents ? layoutTangents : layout);
			SetTris(mesh, maxTrisTotal);
			if (desc.parent != null)
			{
				MeshFilter component = desc.parent.GetComponent<MeshFilter>();
				if (component != null)
				{
					Mesh sharedMesh = component.sharedMesh;
					if (sharedMesh != null)
					{
						mesh.bounds = sharedMesh.bounds;
					}
				}
			}
			gameObject.AddComponent<MeshFilter>().sharedMesh = mesh;
			MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
			meshRenderer.sharedMaterial = desc.material;
			meshRenderer.lightmapIndex = desc.lightmapID;
			meshRenderer.realtimeLightmapIndex = desc.realtimeLightmapID;
			meshRenderer.realtimeLightmapScaleOffset = desc.realtimeLightmapScaleOffset;
			if (desc.materialPropertyBlock != null)
			{
				meshRenderer.SetPropertyBlock(desc.materialPropertyBlock);
			}
		}
		DecalUtils.Group obj2 = new DecalUtils.Group();
		obj2.mode = DecalUtils.Mode.GPU;
		obj2.material = desc.material;
		obj2.vbuffer = computeBuffer;
		obj2.totalTris = maxTrisTotal;
		obj2.maxTrisInDecal = desc.maxTrisInDecal;
		obj2.argBuffer = computeBuffer2;
		obj2.countBuffer = computeBuffer3;
		obj2.parent = desc.parent;
		obj2.parentTform = transform;
		obj2.go = gameObject;
		obj2.mesh = mesh;
		obj2.lightmapID = ((desc.lightmapID >= 65534) ? (-1) : desc.lightmapID);
		obj2.bounds = (obj2.nextBounds = new Bounds(new Vector3(-99999f, -99999f, -99999f), Vector3.zero));
		obj2.indirectDraw = desc.indirectDraw;
		obj2.isTrail = desc.isTrail;
		obj2.trailVScale = desc.trailVScale;
		obj2.tangents = desc.tangents;
		obj2.materialPropertyBlock = desc.materialPropertyBlock;
		if (desc.tangents)
		{
			obj2.buffWithTangents = new ReadableVertexTangents[obj2.totalTris * 3];
		}
		else
		{
			obj2.buff = new ReadableVertex[obj2.totalTris * 3];
		}
		return obj2;
	}

	public static CommandBuffer CreateDrawIndirectCommandBuffer(DecalUtils.Group group, int pass)
	{
		if (group.mode != DecalUtils.Mode.GPU)
		{
			Debug.LogError("Decal mode is not GPU.");
			return null;
		}
		CommandBuffer commandBuffer = new CommandBuffer();
		commandBuffer.name = "DrawDecals_" + ((group.parentTform != null) ? group.parentTform.name : "") + "_" + group.lightmapID;
		group.drawCmd = commandBuffer;
		UpdateDrawIndirectCommandBuffer(group, Matrix4x4.identity, pass);
		return commandBuffer;
	}

	public static void UpdateDrawIndirectCommandBuffer(DecalUtils.Group group, Matrix4x4 mtx, int pass)
	{
		if (group.material == null || group.material.shader == null)
		{
			return;
		}
		if (group.mode != DecalUtils.Mode.GPU)
		{
			Debug.LogError("Decal mode is not GPU.");
			return;
		}
		int passCount = group.material.passCount;
		if (pass >= passCount)
		{
			pass = passCount - 1;
		}
		CommandBuffer drawCmd = group.drawCmd;
		drawCmd.Clear();
		int shaderPass = pass;
		drawCmd.SetGlobalBuffer(pGPUDecalVBuffer, group.vbuffer);
		if (group.lightmapID >= 0)
		{
			drawCmd.EnableShaderKeyword("LIGHTMAP_ON");
			LightmapData lightmapData = LightmapSettings.lightmaps[group.lightmapID];
			drawCmd.SetGlobalTexture(pLightmap, lightmapData.lightmapColor);
			if (lightmapData.lightmapDir != null)
			{
				drawCmd.EnableShaderKeyword("DIRLIGHTMAP_COMBINED");
				drawCmd.SetGlobalTexture(pLightmapInd, lightmapData.lightmapDir);
			}
			else
			{
				drawCmd.DisableShaderKeyword("DIRLIGHTMAP_COMBINED");
			}
			if (lightmapData.shadowMask != null)
			{
				drawCmd.EnableShaderKeyword("SHADOWS_SHADOWMASK");
				drawCmd.SetGlobalTexture(pShadowmask, lightmapData.shadowMask);
			}
			else
			{
				drawCmd.DisableShaderKeyword("SHADOWS_SHADOWMASK");
			}
		}
		else
		{
			drawCmd.DisableShaderKeyword("LIGHTMAP_ON");
		}
		if (group.materialPropertyBlock == null)
		{
			drawCmd.DrawProceduralIndirect(mtx, group.material, shaderPass, MeshTopology.Triangles, group.argBuffer);
		}
		else
		{
			drawCmd.DrawProceduralIndirect(mtx, group.material, shaderPass, MeshTopology.Triangles, group.argBuffer, 0, group.materialPropertyBlock);
		}
	}

	private static Vector4 GetPlane(ref Matrix4x4 mtx, int a, int b, float sign)
	{
		Vector4 vector = mtx.GetRow(a) + mtx.GetRow(b) * sign;
		float num = -1f / new Vector3(vector.x, vector.y, vector.z).magnitude;
		return vector * num;
	}

	public static void AddDecal(DecalUtils.Group group, DecalUtils.DecalDesc desc, GameObject receiver)
	{
		if (group.mode != DecalUtils.Mode.GPU)
		{
			Debug.LogError("Decal mode is not GPU.");
			return;
		}
		Matrix4x4 decalMatrix = Matrix4x4.TRS(desc.position, desc.rotation, new Vector3(desc.sizeX, desc.sizeY, desc.distance));
		_ = group.numDecals;
		if (group.parentTform == null)
		{
			DecalUtils.ExpandBounds(group, decalMatrix, desc);
		}
		decalMatrix.SetColumn(3, decalMatrix.GetColumn(3) + decalMatrix.GetColumn(2) * desc.distance * 0.5f);
		decalMatrix = decalMatrix.inverse;
		if (group.isTrail)
		{
			matrixRight = decalMatrix.GetRow(0);
			matrixUp = decalMatrix.GetRow(1);
			matrixForward = decalMatrix.GetRow(2);
			matrixRight = matrixRight.normalized;
			matrixUp = matrixUp.normalized;
			matrixForward = matrixForward.normalized;
			Vector3 vector = desc.position + matrixUp * desc.sizeY;
			Vector3 vector2 = matrixRight * desc.sizeX;
			curDecalEdgeA = vector - vector2;
			curDecalEdgeB = vector + vector2;
			curDecalEdgePlane = new Vector4(matrixUp.x, matrixUp.y, matrixUp.z, 0f - Vector3.Dot(curDecalEdgeA, matrixUp));
		}
		CommandBuffer commandBuffer = new CommandBuffer();
		commandBuffer.name = "UpdateDecal";
		commandBuffer.ClearRandomWriteTargets();
		commandBuffer.SetRenderTarget(tempRT);
		commandBuffer.SetRandomWriteTarget(1, tempVBuffer);
		commandBuffer.SetRandomWriteTarget(2, tempArgBuffer);
		commandBuffer.SetGlobalMatrix(pDecalParentMatrix, (group.parentTform == null) ? Matrix4x4.identity : group.parentTform.worldToLocalMatrix);
		commandBuffer.SetGlobalFloat(pDecalBufferSize, group.totalTris);
		commandBuffer.SetGlobalFloat(pDecalID, group.decalIDCounter + 1);
		float trailV = group.trailV;
		if (group.isTrail && group.numDecals > 0)
		{
			float num = Mathf.Max(Vector3.Distance(curDecalEdgeA, group.prevDecalEdgeA), Vector3.Distance(curDecalEdgeB, group.prevDecalEdgeB));
			float num2 = Mathf.Min(desc.sizeX, desc.sizeY) * num;
			decalMatrix.SetRow(0, decalMatrix.GetRow(0) * num2);
			decalMatrix.SetRow(1, decalMatrix.GetRow(1) * num2);
			decalMatrix.SetRow(2, decalMatrix.GetRow(2) * num2);
			commandBuffer.SetGlobalMatrix(pDecalMatrix, decalMatrix);
			Vector3 lhs = -Vector3.Cross((curDecalEdgeA - group.prevDecalEdgeA).normalized, matrixForward).normalized;
			Vector3 normalized = Vector3.Cross((curDecalEdgeB - group.prevDecalEdgeB).normalized, matrixForward).normalized;
			commandBuffer.SetGlobalVector(pDecalPlane0, new Vector4(lhs.x, lhs.y, lhs.z, 0f - Vector3.Dot(lhs, curDecalEdgeA)));
			commandBuffer.SetGlobalVector(pDecalPlane1, new Vector4(normalized.x, normalized.y, normalized.z, 0f - Vector3.Dot(normalized, curDecalEdgeB)));
			group.trailV += num * group.trailVScale;
		}
		else
		{
			commandBuffer.SetGlobalMatrix(pDecalMatrix, decalMatrix);
			commandBuffer.SetGlobalVector(pDecalPlane0, GetPlane(ref decalMatrix, 3, 0, -1f));
			commandBuffer.SetGlobalVector(pDecalPlane1, GetPlane(ref decalMatrix, 3, 0, 1f));
		}
		commandBuffer.SetGlobalFloat(pDecalAngleClip, desc.angleClip);
		commandBuffer.SetGlobalVector(pDecalLightmapST, desc.lightmapScaleOffset);
		group.decalIDCounter++;
		if (desc.mesh == null)
		{
			Terrain component = receiver.GetComponent<Terrain>();
			if (component != null)
			{
				Vector3 position = receiver.transform.position;
				TerrainData terrainData = component.terrainData;
				if (!DecalUtils.cachedTerrains.TryGetValue(terrainData, out var value))
				{
					value = DecalUtils.PrepareTerrain(terrainData, position, useBurst: false, createMesh: true);
				}
				desc.mesh = value.tempMesh;
				desc.worldMatrix = Matrix4x4.identity;
			}
		}
		int subMeshCount = desc.mesh.subMeshCount;
		for (int i = 0; i < subMeshCount; i++)
		{
			commandBuffer.DrawMesh(desc.mesh, desc.worldMatrix, writeMat, i, 0);
		}
		commandBuffer.SetRandomWriteTarget(1, group.vbuffer);
		commandBuffer.SetRandomWriteTarget(2, group.countBuffer);
		commandBuffer.SetGlobalBuffer(pTempVertexBuffer, tempVBuffer);
		commandBuffer.SetRandomWriteTarget(3, tempArgBuffer);
		if (group.isTrail && group.numDecals > 0)
		{
			commandBuffer.SetGlobalVector(pDecalPlane0, curDecalEdgePlane);
			commandBuffer.SetGlobalVector(pDecalPlane1, new Vector4(0f - group.prevDecalEdgePlane.x, 0f - group.prevDecalEdgePlane.y, 0f - group.prevDecalEdgePlane.z, 0f - group.prevDecalEdgePlane.w));
			commandBuffer.SetGlobalVector(pDecalTrailFP0, group.prevDecalEdgeA);
			commandBuffer.SetGlobalVector(pDecalTrailFP1, curDecalEdgeA);
			commandBuffer.SetGlobalVector(pDecalTrailFP2, curDecalEdgeB);
			commandBuffer.SetGlobalVector(pDecalTrailFT0, new Vector2(0f, trailV));
			commandBuffer.SetGlobalVector(pDecalTrailFT1, new Vector2(0f, group.trailV));
			commandBuffer.SetGlobalVector(pDecalTrailFT2, new Vector2(1f, group.trailV));
			commandBuffer.SetGlobalVector(pDecalTrailSP0, curDecalEdgeB);
			commandBuffer.SetGlobalVector(pDecalTrailSP1, group.prevDecalEdgeB);
			commandBuffer.SetGlobalVector(pDecalTrailSP2, group.prevDecalEdgeA);
			commandBuffer.SetGlobalVector(pDecalTrailST0, new Vector2(1f, group.trailV));
			commandBuffer.SetGlobalVector(pDecalTrailST1, new Vector2(1f, trailV));
			commandBuffer.SetGlobalVector(pDecalTrailST2, new Vector2(0f, trailV));
		}
		else
		{
			commandBuffer.SetGlobalVector(pDecalPlane0, GetPlane(ref decalMatrix, 3, 1, -1f));
			commandBuffer.SetGlobalVector(pDecalPlane1, GetPlane(ref decalMatrix, 3, 1, 1f));
		}
		commandBuffer.SetGlobalFloat(pDecalOpacity, desc.opacity);
		if (group.isTrail && group.numDecals > 0)
		{
			commandBuffer.DrawProceduralIndirect(Matrix4x4.identity, writeMat, group.tangents ? 4 : 2, MeshTopology.Triangles, tempArgBuffer);
		}
		else
		{
			commandBuffer.DrawProceduralIndirect(Matrix4x4.identity, writeMat, (!group.tangents) ? 1 : 3, MeshTopology.Triangles, tempArgBuffer);
		}
		commandBuffer.SetRandomWriteTarget(4, group.argBuffer);
		commandBuffer.DrawProcedural(Matrix4x4.identity, writeMat, group.tangents ? 6 : 5, MeshTopology.Triangles, 3 * group.maxTrisInDecal);
		commandBuffer.ClearRandomWriteTargets();
		Graphics.ExecuteCommandBuffer(commandBuffer);
		if (!group.indirectDraw)
		{
			if (group.tangents)
			{
				group.vbuffer.GetData(group.buffWithTangents);
				group.mesh.SetVertexBufferData(group.buffWithTangents, 0, 0, group.totalTris * 3, 0, MeshUpdateFlags.DontRecalculateBounds);
			}
			else
			{
				group.vbuffer.GetData(group.buff);
				group.mesh.SetVertexBufferData(group.buff, 0, 0, group.totalTris * 3, 0, MeshUpdateFlags.DontRecalculateBounds);
			}
			if (group.parentTform == null)
			{
				group.mesh.bounds = group.bounds;
			}
		}
		if (group.isTrail)
		{
			group.prevDecalEdgeA = curDecalEdgeA;
			group.prevDecalEdgeB = curDecalEdgeB;
			group.prevDecalEdgePlane = curDecalEdgePlane;
		}
		group.numDecals++;
	}

	public static void ClearDecals(DecalUtils.Group group)
	{
		if (group.mode != DecalUtils.Mode.GPU)
		{
			Debug.LogError("Decal mode is not GPU.");
			return;
		}
		group.argBuffer.SetData(emptyArgs);
		group.countBuffer.SetData(emptyCount);
		group.bounds = (group.nextBounds = new Bounds(new Vector3(-99999f, -99999f, -99999f), Vector3.zero));
		group.numDecals = (group.boundsCounter = (group.boundsMinDecalCounter = 0));
		if (group.mesh != null)
		{
			group.mesh.bounds = group.bounds;
			if (group.tangents)
			{
				group.vbuffer.SetData(new Triangle2Tangents[group.totalTris]);
			}
			else
			{
				group.vbuffer.SetData(new Triangle2[group.totalTris]);
			}
		}
	}

	public static void Cleanup()
	{
		initialized = false;
	}
}
