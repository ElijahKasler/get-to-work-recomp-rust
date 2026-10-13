using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class DecalUtils
{
	public struct GroupDesc
	{
		public Material material;

		public int maxTrisTotal;

		public int maxTrisInDecal;

		public Renderer parent;

		public int lightmapID;

		public int realtimeLightmapID;

		public bool indirectDraw;

		public bool isTrail;

		public float trailVScale;

		public bool tangents;

		public Vector4 realtimeLightmapScaleOffset;

		public MaterialPropertyBlock materialPropertyBlock;

		public void SetDefaults()
		{
			lightmapID = -1;
			trailVScale = 1f;
		}
	}

	public struct DecalDesc
	{
		public Vector3 position;

		public Quaternion rotation;

		public float sizeX;

		public float sizeY;

		public float distance;

		public float angleClip;

		public float opacity;

		public Mesh mesh;

		public Matrix4x4 worldMatrix;

		public Vector4 lightmapScaleOffset;

		public void SetDefaults()
		{
			opacity = 1f;
		}
	}

	public class Group
	{
		public Mode mode;

		public ComputeBuffer vbuffer;

		public ComputeBuffer countBuffer;

		public ComputeBuffer argBuffer;

		public Material material;

		public Renderer parent;

		public Transform parentTform;

		public GameObject go;

		public DecalGroup decalGroup;

		public Mesh mesh;

		public CommandBuffer drawCmd;

		public Bounds bounds;

		public Bounds nextBounds;

		public Vector3 prevDecalEdgeA;

		public Vector3 prevDecalEdgeB;

		public Vector4 prevDecalEdgePlane;

		public int numDecals;

		public int maxTrisInDecal;

		public int totalTris;

		public int boundsCounter;

		public int boundsMinDecalCounter;

		public int lightmapID;

		public int decalIDCounter;

		public bool indirectDraw;

		public bool isTrail;

		public float trailV;

		public float trailVScale;

		public bool tangents;

		public bool isSkinned;

		public MaterialPropertyBlock materialPropertyBlock;

		public int fixedOffset;

		public Vector3[] vPos;

		public Vector3[] vNormal;

		public Vector2[] vUV;

		public Vector2[] vUV2;

		public Color[] vColor;

		public BoneWeight[] vSkin;

		public Vector4[] vTangents;

		public byte[] vDecalID;

		public NativeArray<Vector3> nvPos;

		public NativeArray<Vector3> nvNormal;

		public NativeArray<Color> nvColor;

		public NativeArray<Vector2> nvUV2;

		public NativeArray<Vector2> nvUV;

		public NativeArray<BoneWeight> nvSkin;

		public NativeArray<byte> nvDecalID;

		public NativeArray<Vector4> nvTangents;

		public GPUDecalUtils.ReadableVertex[] buff;

		public GPUDecalUtils.ReadableVertexTangents[] buffWithTangents;
	}

	public enum Mode
	{
		CPU = 0,
		GPU = 1,
		CPUBurst = 2
	}

	public class CachedTerrain
	{
		public Vector3[] pos;

		public Vector3[] norm;

		public Vector2[] uv;

		public int[] indices;

		public NativeArray<float3> nStaticPos;

		public NativeArray<float3> nStaticNorm;

		public NativeArray<float2> nStaticUV2;

		public NativeArray<int> nStaticTris;

		public Mesh tempMesh;
	}

	public static Dictionary<TerrainData, CachedTerrain> cachedTerrains = new Dictionary<TerrainData, CachedTerrain>();

	public static Group CreateGroup(GroupDesc desc, Mode mode)
	{
		return mode switch
		{
			Mode.GPU => GPUDecalUtils.CreateGroup(desc), 
			Mode.CPUBurst => CPUBurstDecalUtils.CreateGroup(desc), 
			_ => CPUDecalUtils.CreateGroup(desc), 
		};
	}

	public static void AddDecal(Group group, DecalDesc desc, GameObject receiver, Mode mode)
	{
		switch (mode)
		{
		case Mode.GPU:
			GPUDecalUtils.AddDecal(group, desc, receiver);
			break;
		case Mode.CPUBurst:
			CPUBurstDecalUtils.AddDecal(group, desc, receiver);
			break;
		default:
			CPUDecalUtils.AddDecal(group, desc, receiver);
			break;
		}
	}

	public static void ClearDecals(Group group, Mode mode)
	{
		switch (mode)
		{
		case Mode.GPU:
			GPUDecalUtils.ClearDecals(group);
			break;
		case Mode.CPUBurst:
			CPUBurstDecalUtils.ClearDecals(group);
			break;
		default:
			CPUDecalUtils.ClearDecals(group);
			break;
		}
	}

	private static Vector3 Vector3Abs(Vector3 v)
	{
		return new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
	}

	internal static void ExpandBounds(Group group, Matrix4x4 decalMatrix, DecalDesc desc)
	{
		Vector3 v = decalMatrix.GetColumn(0);
		Vector3 v2 = decalMatrix.GetColumn(1);
		Vector3 vector = decalMatrix.GetColumn(2);
		Vector3 vector2 = desc.position + vector * desc.distance * 0.5f;
		v = Vector3Abs(v);
		v2 = Vector3Abs(v2);
		vector = Vector3Abs(vector);
		Vector3 min = vector2 - v - v2 - vector;
		Vector3 max = vector2 + v + v2 + vector;
		Bounds bounds = group.bounds;
		bounds.SetMinMax(min, max);
		if (group.numDecals == 0)
		{
			group.bounds = bounds;
		}
		else
		{
			group.bounds.Encapsulate(bounds);
		}
		if (group.boundsMinDecalCounter > group.totalTris)
		{
			if (group.boundsCounter == 0)
			{
				group.nextBounds = bounds;
				group.boundsCounter++;
			}
			else
			{
				group.nextBounds.Encapsulate(bounds);
			}
			if (group.boundsMinDecalCounter > group.totalTris * 2)
			{
				group.bounds = group.nextBounds;
				group.boundsCounter = 0;
				group.boundsMinDecalCounter = 0;
			}
		}
		group.boundsMinDecalCounter++;
	}

	public static void ReleaseDecals(Group group, bool affectScene = true)
	{
		if (group == null)
		{
			return;
		}
		if (group.vbuffer != null)
		{
			group.vbuffer.Release();
			group.vbuffer = null;
		}
		group.totalTris = 0;
		group.maxTrisInDecal = 0;
		if (group.argBuffer != null)
		{
			group.argBuffer.Release();
			group.argBuffer = null;
		}
		if (group.countBuffer != null)
		{
			group.countBuffer.Release();
			group.countBuffer = null;
		}
		group.parent = null;
		group.parentTform = null;
		if (affectScene)
		{
			if (group.go != null)
			{
				Object.Destroy(group.go);
				group.go = null;
			}
			if (group.mesh != null)
			{
				Object.Destroy(group.mesh);
				group.mesh = null;
			}
		}
		group.lightmapID = -1;
		if (group.nvPos.IsCreated)
		{
			group.nvPos.Dispose();
		}
		if (group.nvNormal.IsCreated)
		{
			group.nvNormal.Dispose();
		}
		if (group.nvColor.IsCreated)
		{
			group.nvColor.Dispose();
		}
		if (group.nvUV2.IsCreated)
		{
			group.nvUV2.Dispose();
		}
		if (group.nvUV.IsCreated)
		{
			group.nvUV.Dispose();
		}
		if (group.nvSkin.IsCreated)
		{
			group.nvSkin.Dispose();
		}
		if (group.nvDecalID.IsCreated)
		{
			group.nvDecalID.Dispose();
		}
		if (group.nvTangents.IsCreated)
		{
			group.nvTangents.Dispose();
		}
	}

	public static CachedTerrain PrepareTerrain(TerrainData terrainData, Vector3 posOffset, bool useBurst = false, bool createMesh = false)
	{
		CachedTerrain cachedTerrain = new CachedTerrain();
		int heightmapResolution = terrainData.heightmapResolution;
		float[,] heights = terrainData.GetHeights(0, 0, heightmapResolution, heightmapResolution);
		float num = terrainData.size.x / (float)(heightmapResolution - 1);
		float y = terrainData.size.y;
		float num2 = terrainData.size.z / (float)(heightmapResolution - 1);
		Vector2 vector = new Vector2(1f, 1f) / (heightmapResolution - 1);
		int num3 = 0;
		int num4 = 0;
		Vector3[] array = new Vector3[heightmapResolution * heightmapResolution];
		Vector3[] array2 = new Vector3[heightmapResolution * heightmapResolution];
		Vector2[] array3 = new Vector2[heightmapResolution * heightmapResolution];
		int[] array4 = new int[(heightmapResolution - 1) * (heightmapResolution - 1) * 2 * 3];
		for (int i = 0; i < heightmapResolution; i++)
		{
			for (int j = 0; j < heightmapResolution; j++)
			{
				int num5 = i * heightmapResolution + j;
				float num6 = heights[i, j];
				array[num5] = new Vector3((float)j * num, num6 * y, (float)i * num2) + posOffset;
				array3[num5] = new Vector2((float)j * vector.x, (float)i * vector.y);
				array2[num5] = terrainData.GetInterpolatedNormal((float)j / (float)heightmapResolution, (float)i / (float)heightmapResolution);
				if (j < heightmapResolution - 1 && i < heightmapResolution - 1)
				{
					array4[num4] = num3;
					array4[num4 + 1] = num3 + heightmapResolution;
					array4[num4 + 2] = num3 + heightmapResolution + 1;
					array4[num4 + 3] = num3;
					array4[num4 + 4] = num3 + heightmapResolution + 1;
					array4[num4 + 5] = num3 + 1;
					num4 += 6;
				}
				num3++;
			}
		}
		cachedTerrain.pos = array;
		cachedTerrain.norm = array2;
		cachedTerrain.uv = array3;
		cachedTerrain.indices = array4;
		if (useBurst)
		{
			int num7 = array.Length;
			NativeArray<Vector3> dst = new NativeArray<Vector3>(num7 * 2, Allocator.Persistent);
			NativeArray<Vector3> dst2 = new NativeArray<Vector3>(num7 * 2, Allocator.Persistent);
			NativeArray<Vector2> dst3 = new NativeArray<Vector2>(num7 * 2, Allocator.Persistent);
			NativeArray<Vector3>.Copy(array, 0, dst, num7, num7);
			NativeArray<Vector3>.Copy(array2, 0, dst2, num7, num7);
			NativeArray<Vector2>.Copy(array3, 0, dst3, num7, num7);
			cachedTerrain.nStaticPos = dst.Reinterpret<float3>();
			cachedTerrain.nStaticNorm = dst2.Reinterpret<float3>();
			cachedTerrain.nStaticUV2 = dst3.Reinterpret<float2>();
			int num8 = array4.Length;
			cachedTerrain.nStaticTris = new NativeArray<int>(num8 * 2, Allocator.Persistent);
			NativeArray<int>.Copy(array4, cachedTerrain.nStaticTris, num8);
		}
		if (createMesh)
		{
			Mesh mesh = new Mesh();
			mesh.indexFormat = IndexFormat.UInt32;
			mesh.vertices = array;
			mesh.triangles = array4;
			mesh.normals = array2;
			mesh.uv = array3;
			mesh.uv2 = array3;
			cachedTerrain.tempMesh = mesh;
		}
		cachedTerrains[terrainData] = cachedTerrain;
		return cachedTerrain;
	}

	public static Mesh GetSharedMesh(GameObject obj, out Terrain terrain)
	{
		terrain = null;
		MeshFilter component = obj.GetComponent<MeshFilter>();
		if (component != null)
		{
			return component.sharedMesh;
		}
		SkinnedMeshRenderer component2 = obj.GetComponent<SkinnedMeshRenderer>();
		if (component2 != null)
		{
			return component2.sharedMesh;
		}
		terrain = obj.GetComponent<Terrain>();
		return null;
	}
}
