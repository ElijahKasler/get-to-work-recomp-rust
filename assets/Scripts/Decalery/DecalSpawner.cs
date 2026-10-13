using System;
using System.Collections.Generic;
using UnityEngine;

public class DecalSpawner
{
	[Serializable]
	public struct ShaderReplacement
	{
		public Shader src;

		public Shader dest;
	}

	[Serializable]
	public class InitData
	{
		public Material material;

		public bool isTrail;

		public float trailInterval = 0.1f;

		public float trailVScale = 1f;

		public bool tangents;

		public bool inheritMaterialPropertyBlock = true;

		public bool _forceBumped;

		public bool useShaderReplacement = true;

		public ShaderReplacement[] shaderReplacement;

		public bool inheritMaterialProperties;

		public string[] materialPropertyNamesVector;
	}

	private struct QueuedDecal(Vector3 _position, Quaternion _rotation, GameObject _hitObject, float _decalSizeX, float _decalSizeY, float _distance, float _opacity, float _angleClip, Transform _rootObject)
	{
		public Vector3 position = _position;

		public Quaternion rotation = _rotation;

		public GameObject hitObject = _hitObject;

		public float decalSizeX = _decalSizeX;

		public float decalSizeY = _decalSizeY;

		public float distance = _distance;

		public float opacity = _opacity;

		public float angleClip = _angleClip;

		public Transform rootObject = _rootObject;
	}

	private struct HashedShader
	{
		public Shader shader;

		public bool isSkinned;

		public bool isSH;

		public Material material;
	}

	public InitData initData;

	private int[] materialPropertyIDsVector;

	private DecalUtils.Mode mode;

	private bool indirectDraw;

	private int shaderPass;

	private Queue<QueuedDecal> queue;

	private Dictionary<Shader, Shader> shaderReplacementMap = new Dictionary<Shader, Shader>();

	private Dictionary<HashedShader, Material> shaderReplacementMapExt = new Dictionary<HashedShader, Material>();

	private HashedShader hashed;

	public Dictionary<int, DecalUtils.Group> staticGroups;

	public Dictionary<Transform, DecalUtils.Group> movableGroups;

	private DecalUtils.GroupDesc initDesc;

	private DecalUtils.DecalDesc desc;

	private Vector3 prevPos;

	private DecalUtils.Group lastGroup;

	public static List<DecalSpawner> All = new List<DecalSpawner>();

	private bool init;

	public void Init(int maxTrisTotal, int maxTrisInDecal, DecalUtils.Mode preferredMode, bool preferDrawIndirect, int preferredShaderPass)
	{
		if (init)
		{
			return;
		}
		All.Add(this);
		if (initData.shaderReplacement != null)
		{
			for (int i = 0; i < initData.shaderReplacement.Length; i++)
			{
				shaderReplacementMap[initData.shaderReplacement[i].src] = initData.shaderReplacement[i].dest;
			}
		}
		if (initData.inheritMaterialProperties)
		{
			int num = initData.materialPropertyNamesVector.Length;
			materialPropertyIDsVector = new int[num];
			for (int j = 0; j < num; j++)
			{
				materialPropertyIDsVector[j] = Shader.PropertyToID(initData.materialPropertyNamesVector[j]);
			}
		}
		initDesc.SetDefaults();
		initDesc.material = initData.material;
		initDesc.maxTrisInDecal = maxTrisTotal;
		initDesc.maxTrisTotal = maxTrisTotal;
		initDesc.indirectDraw = preferDrawIndirect;
		initDesc.isTrail = initData.isTrail;
		initDesc.trailVScale = initData.trailVScale;
		initDesc.tangents = initData.tangents;
		mode = preferredMode;
		indirectDraw = preferDrawIndirect;
		shaderPass = preferredShaderPass;
		desc.SetDefaults();
		if (staticGroups == null)
		{
			staticGroups = new Dictionary<int, DecalUtils.Group>();
		}
		if (movableGroups == null)
		{
			movableGroups = new Dictionary<Transform, DecalUtils.Group>();
		}
		init = true;
	}

	private Material GetMaterial(Material src, bool isSkinned, out bool isSH)
	{
		isSH = false;
		if (!initData.useShaderReplacement)
		{
			isSkinned = false;
			return initData.material;
		}
		hashed.shader = src.shader;
		hashed.isSkinned = isSkinned;
		hashed.material = (initData.inheritMaterialProperties ? src : null);
		hashed.isSH = (isSH = src.IsKeywordEnabled("BAKERY_SH"));
		if (shaderReplacementMapExt.TryGetValue(hashed, out var value))
		{
			return value;
		}
		value = UnityEngine.Object.Instantiate(initData.material);
		Shader value2 = null;
		if (shaderReplacementMap.TryGetValue(src.shader, out value2))
		{
			value.shader = value2;
		}
		if (hashed.isSkinned)
		{
			value.DisableKeyword("INDIRECT_DRAW");
		}
		else if (indirectDraw)
		{
			value.EnableKeyword("INDIRECT_DRAW");
		}
		else
		{
			value.DisableKeyword("INDIRECT_DRAW");
		}
		if (initData.inheritMaterialProperties)
		{
			int num = materialPropertyIDsVector.Length;
			for (int i = 0; i < num; i++)
			{
				value.SetVector(materialPropertyIDsVector[i], src.GetVector(materialPropertyIDsVector[i]));
				Debug.LogError(src.GetVector(materialPropertyIDsVector[i]));
			}
		}
		if (hashed.isSH)
		{
			value.EnableKeyword("BAKERY_SH");
		}
		else
		{
			value.DisableKeyword("BAKERY_SH");
		}
		shaderReplacementMapExt[hashed] = value;
		return value;
	}

	private MaterialPropertyBlock GetPropertyBlock(Renderer mr)
	{
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		mr.GetPropertyBlock(materialPropertyBlock);
		return materialPropertyBlock;
	}

	private DecalUtils.Group CreateNewGroup(Terrain terrain)
	{
		initDesc.lightmapID = terrain.lightmapIndex;
		initDesc.realtimeLightmapID = terrain.realtimeLightmapIndex;
		initDesc.realtimeLightmapScaleOffset = terrain.realtimeLightmapScaleOffset;
		initDesc.material = GetMaterial(terrain.materialTemplate, isSkinned: false, out var isSH);
		if (!isSH && initData._forceBumped)
		{
			initDesc.lightmapID = -1;
		}
		initDesc.materialPropertyBlock = null;
		DecalUtils.Group obj = DecalUtils.CreateGroup(initDesc, mode);
		if (indirectDraw)
		{
			GPUDecalUtils.CreateDrawIndirectCommandBuffer(obj, shaderPass);
		}
		return obj;
	}

	private DecalUtils.Group CreateNewGroup(Renderer mr, bool isSkinned = false)
	{
		initDesc.lightmapID = mr.lightmapIndex;
		initDesc.realtimeLightmapID = mr.realtimeLightmapIndex;
		initDesc.realtimeLightmapScaleOffset = mr.realtimeLightmapScaleOffset;
		initDesc.material = GetMaterial(mr.sharedMaterial, isSkinned, out var isSH);
		if (!isSH && initData._forceBumped)
		{
			initDesc.lightmapID = -1;
		}
		initDesc.materialPropertyBlock = null;
		if (initData.inheritMaterialPropertyBlock && mr.HasPropertyBlock())
		{
			initDesc.materialPropertyBlock = GetPropertyBlock(mr);
		}
		if (isSkinned)
		{
			initDesc.indirectDraw = false;
			DecalUtils.Group result = DecalUtils.CreateGroup(initDesc, DecalUtils.Mode.CPU);
			initDesc.indirectDraw = indirectDraw;
			return result;
		}
		DecalUtils.Group obj = DecalUtils.CreateGroup(initDesc, mode);
		if (indirectDraw)
		{
			GPUDecalUtils.CreateDrawIndirectCommandBuffer(obj, shaderPass);
		}
		return obj;
	}

	private void Process(Vector3 position, Quaternion rotation, float decalSizeX, float decalSizeY, float distance, float opacity, float angleClip, Renderer mr, Terrain terrain, GameObject hitObject, Transform rootObject, bool staticBatch)
	{
		Mesh mesh = null;
		SkinnedMeshRenderer skinnedMeshRenderer = null;
		bool flag = terrain != null;
		if (!flag)
		{
			skinnedMeshRenderer = mr as SkinnedMeshRenderer;
			if (skinnedMeshRenderer != null)
			{
				mesh = skinnedMeshRenderer.sharedMesh;
				rootObject = skinnedMeshRenderer.transform;
			}
			else
			{
				MeshFilter component = mr.GetComponent<MeshFilter>();
				if (component == null)
				{
					return;
				}
				mesh = component.sharedMesh;
			}
			if (mesh == null)
			{
				return;
			}
		}
		DecalUtils.Group value = null;
		if (rootObject != null)
		{
			if (!movableGroups.TryGetValue(rootObject, out value))
			{
				if (flag)
				{
					initDesc.parent = null;
					DecalUtils.Group obj = (movableGroups[rootObject] = CreateNewGroup(terrain));
					value = obj;
					if (indirectDraw)
					{
						GPUDecalUtils.UpdateDrawIndirectCommandBuffer(value, rootObject.localToWorldMatrix, shaderPass);
					}
				}
				else
				{
					initDesc.parent = mr;
					DecalUtils.Group obj = (movableGroups[rootObject] = CreateNewGroup(mr, skinnedMeshRenderer != null));
					value = obj;
					if (indirectDraw && skinnedMeshRenderer == null)
					{
						GPUDecalUtils.UpdateDrawIndirectCommandBuffer(value, rootObject.localToWorldMatrix, shaderPass);
					}
				}
			}
		}
		else
		{
			int key = ((!flag) ? mr.lightmapIndex : terrain.lightmapIndex);
			if (!staticGroups.TryGetValue(key, out value))
			{
				initDesc.parent = null;
				if (flag)
				{
					DecalUtils.Group obj = (staticGroups[key] = CreateNewGroup(terrain));
					value = obj;
				}
				else
				{
					DecalUtils.Group obj = (staticGroups[key] = CreateNewGroup(mr));
					value = obj;
				}
			}
		}
		desc.mesh = mesh;
		desc.worldMatrix = ((staticBatch | flag) ? Matrix4x4.identity : mr.transform.localToWorldMatrix);
		desc.lightmapScaleOffset = (staticBatch ? new Vector4(1f, 1f, 0f, 0f) : (flag ? terrain.lightmapScaleOffset : mr.lightmapScaleOffset));
		desc.position = position;
		desc.rotation = rotation;
		desc.sizeX = decalSizeX;
		desc.sizeY = decalSizeY;
		desc.distance = distance;
		desc.angleClip = angleClip;
		desc.opacity = opacity;
		if (initData.isTrail && lastGroup != value)
		{
			desc.opacity = 0f;
		}
		if (skinnedMeshRenderer != null)
		{
			Matrix4x4 matrix4x = Matrix4x4.TRS(position, rotation, Vector3.one);
			Transform transform = hitObject.transform;
			int num = Array.IndexOf(skinnedMeshRenderer.bones, transform);
			if (num >= 0)
			{
				Matrix4x4 localToWorldMatrix = skinnedMeshRenderer.transform.localToWorldMatrix;
				Matrix4x4 matrix4x2 = skinnedMeshRenderer.sharedMesh.bindposes[num];
				Matrix4x4 worldToLocalMatrix = transform.worldToLocalMatrix;
				Matrix4x4 matrix4x3 = localToWorldMatrix * (matrix4x2.inverse * worldToLocalMatrix) * matrix4x;
				desc.position = matrix4x3.GetColumn(3);
				desc.rotation = matrix4x3.rotation;
			}
		}
		if (flag)
		{
			DecalUtils.AddDecal(value, desc, terrain.gameObject, mode);
		}
		else
		{
			DecalUtils.AddDecal(value, desc, mr.gameObject, (!(skinnedMeshRenderer != null)) ? mode : DecalUtils.Mode.CPU);
		}
		lastGroup = value;
	}

	public void AddDecal(Vector3 position, Quaternion rotation, GameObject hitObject, float decalSizeX, float decalSizeY, float distance, float opacity, float angleClip, Transform rootObject)
	{
		if (initData.isTrail)
		{
			if ((prevPos - position).sqrMagnitude < initData.trailInterval * initData.trailInterval)
			{
				return;
			}
			Vector3 normalized = (position - prevPos).normalized;
			rotation = Quaternion.LookRotation(rotation * Vector3.forward, normalized);
			prevPos = position;
		}
		Renderer renderer = null;
		Terrain terrain = null;
		DecalMeshRef component = hitObject.GetComponent<DecalMeshRef>();
		if (component != null)
		{
			Renderer[] renderers = component.renderers;
			if (renderers == null)
			{
				return;
			}
			for (int i = 0; i < renderers.Length; i++)
			{
				renderer = renderers[i];
			}
		}
		else
		{
			renderer = hitObject.GetComponent<Renderer>();
			if (renderer == null)
			{
				terrain = hitObject.GetComponent<Terrain>();
				if (terrain == null)
				{
					return;
				}
			}
		}
		Process(position, rotation, decalSizeX, decalSizeY, distance, opacity, angleClip, renderer, terrain, hitObject, rootObject, renderer != null && renderer.isPartOfStaticBatch);
	}

	public void AddDecalToQueue(Vector3 position, Quaternion rotation, GameObject hitObject, float decalSizeX, float decalSizeY, float distance, float opacity, float angleClip, Transform rootObject)
	{
		if (queue == null)
		{
			queue = new Queue<QueuedDecal>();
		}
		queue.Enqueue(new QueuedDecal(position, rotation, hitObject, decalSizeX, decalSizeY, distance, opacity, angleClip, rootObject));
	}

	public void UpdateQueue(int maxDecalsPerFrame)
	{
		if (queue != null && queue.Count != 0)
		{
			int num = Math.Min(maxDecalsPerFrame, queue.Count);
			for (int i = 0; i < num; i++)
			{
				QueuedDecal queuedDecal = queue.Dequeue();
				AddDecal(queuedDecal.position, queuedDecal.rotation, queuedDecal.hitObject, queuedDecal.decalSizeX, queuedDecal.decalSizeY, queuedDecal.distance, queuedDecal.opacity, queuedDecal.angleClip, queuedDecal.rootObject);
			}
		}
	}

	private void OnDrawGizmosSelected()
	{
		if (staticGroups == null)
		{
			return;
		}
		Gizmos.color = Color.green;
		foreach (KeyValuePair<int, DecalUtils.Group> staticGroup in staticGroups)
		{
			Gizmos.DrawWireCube(staticGroup.Value.bounds.center, staticGroup.Value.bounds.size);
		}
		foreach (KeyValuePair<Transform, DecalUtils.Group> movableGroup in movableGroups)
		{
			Gizmos.DrawWireCube(movableGroup.Value.parent.bounds.center, movableGroup.Value.parent.bounds.size);
		}
		Gizmos.color = Color.red;
		foreach (KeyValuePair<int, DecalUtils.Group> staticGroup2 in staticGroups)
		{
			Gizmos.DrawLine(staticGroup2.Value.prevDecalEdgeA, staticGroup2.Value.prevDecalEdgeB);
		}
	}

	public void Release()
	{
		foreach (KeyValuePair<int, DecalUtils.Group> staticGroup in staticGroups)
		{
			DecalUtils.ReleaseDecals(staticGroup.Value);
		}
		foreach (KeyValuePair<Transform, DecalUtils.Group> movableGroup in movableGroups)
		{
			DecalUtils.ReleaseDecals(movableGroup.Value);
		}
	}

	public void Clear()
	{
		foreach (KeyValuePair<int, DecalUtils.Group> staticGroup in staticGroups)
		{
			DecalUtils.ClearDecals(staticGroup.Value, mode);
		}
		foreach (KeyValuePair<Transform, DecalUtils.Group> movableGroup in movableGroups)
		{
			DecalUtils.ClearDecals(movableGroup.Value, mode);
		}
	}

	public static void Cleanup()
	{
		foreach (DecalSpawner item in All)
		{
			item?.Release();
		}
		All = new List<DecalSpawner>();
	}
}
