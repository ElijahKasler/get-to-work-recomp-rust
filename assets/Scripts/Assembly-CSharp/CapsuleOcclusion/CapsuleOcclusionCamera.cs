using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace CapsuleOcclusion;

[ExecuteAlways]
[ImageEffectAllowedInSceneView]
[RequireComponent(typeof(Camera))]
public class CapsuleOcclusionCamera : MonoBehaviour
{
	[Serializable]
	public enum ClusteringMethod
	{
		Rasterizer = 0,
		Compute = 1
	}

	[Tooltip("The resolution of the 3D acceleration texture (clusters). It is recommended to use multiples of 8 for all dimensions.")]
	public Vector3Int clusterSize = new Vector3Int(64, 64, 32);

	[Range(4f, 32f)]
	[Tooltip("Size multiplier of the cluster linked list on the GPU. Setting this too low will result in visual bugs if many capsules overlap.")]
	public int clusterDataHeadroom = 16;

	[Min(0f)]
	[Tooltip("The maximum distance from the camera that occlusion will be applied. A shorter range makes clustering more effective.")]
	public float maxCameraRange = 50f;

	[Range(16f, 512f)]
	[Tooltip("The maximum number of active occlusion capsules for a single camera.")]
	public int maxCapsuleCount = 256;

	[Range(1f, 8f)]
	[Tooltip("The maximum range of occlusion influence of all capsules, scaled with their radii.")]
	public float capsuleRangeMultiplier = 4f;

	[Range(0f, 100f)]
	[Tooltip("The strength of the occlusion effect.")]
	public float intensity = 10f;

	[Space(10f)]
	[Tooltip("Frustum cull capsules. This ensures only visible capsules are processed.")]
	public bool cullCapsules = true;

	[Tooltip("Sort capsules by distance from camera. This ensures capsules closer to the camera are prioritized.")]
	public bool sortCapsules = true;

	[Space(10f)]
	[Tooltip("The method used when updating clusters. Rasterization is the preferred method as it is both faster and more accurate.")]
	public ClusteringMethod clusteringMethod;

	[Tooltip("Use (software) conservative rasterization. This improves clustering accuracy and should always be enabled.")]
	public bool conservativeRasterization = true;

	[Tooltip("Can be used to toggle cluster updates on/off for testing purposes.")]
	public bool updateClusters = true;

	[Space(10f)]
	public bool showCapsules;

	public bool debugBounds;

	public bool debugClusters;

	private Camera m_camera;

	private Vector4[] m_frustumRays = new Vector4[4];

	private CommandBuffer m_cmd;

	private ComputeShader m_compute;

	private RenderTexture m_rasterTarget;

	private RenderTexture m_clusterCount;

	private RenderTexture m_clusterPointer;

	private RenderTexture m_clusters;

	private ComputeBuffer m_clusterData;

	private ComputeBuffer m_counter;

	private uint[] m_counterData = new uint[1];

	private Material m_material;

	private Mesh m_clusterMesh;

	private const int CS_KERNEL_RESET = 0;

	private const int CS_KERNEL_UPDATE = 1;

	private const int CS_KERNEL_MERGE = 2;

	private void OnValidate()
	{
		clusterSize.x = Mathf.Clamp(clusterSize.x, 8, 128);
		clusterSize.y = Mathf.Clamp(clusterSize.y, 8, 128);
		clusterSize.z = Mathf.Clamp(clusterSize.z, 8, 128);
	}

	private void OnEnable()
	{
		RenderPipelineManager.beginCameraRendering += OnPreCamCullWithCam;
	}

	private void OnDisable()
	{
		RenderPipelineManager.beginCameraRendering -= OnPreCamCullWithCam;
		Release();
	}

	private void Release()
	{
		Utils.Release(ref m_rasterTarget);
		Utils.Release(ref m_clusterCount);
		Utils.Release(ref m_clusterPointer);
		Utils.Release(ref m_clusters);
		Utils.Release(ref m_clusterData);
		Utils.Release(ref m_counter);
	}

	private void LazyInitialize()
	{
		base.gameObject.LazyGetComponent(ref m_camera);
		Utils.LazyCreate(ref m_cmd, "Capsule Occlusion");
		Utils.LazyLoadResource(ref m_compute, "Shaders/CapsuleOcclusion");
		Utils.LazyLoadResource(ref m_material, "Materials/CapsuleOcclusion");
		Utils.LazyLoadResource(ref m_clusterMesh, "Meshes/CapsuleClusterMesh");
	}

	private void OnPreCamCullWithCam(ScriptableRenderContext context, Camera camera)
	{
		LazyInitialize();
		if (camera == m_camera)
		{
			OnPreRender();
		}
	}

	private void OnPreRender()
	{
		if (base.enabled)
		{
			LazyInitialize();
			OcclusionCapsule.UpdateCapsuleDataForCamera(m_camera, maxCapsuleCount, capsuleRangeMultiplier, cullCapsules, sortCapsules);
			if (updateClusters)
			{
				UpdateClusters(m_camera);
			}
		}
	}

	private void OnPostRender()
	{
		if (showCapsules)
		{
			m_cmd.Clear();
			m_cmd.ClearRenderTarget(clearDepth: true, clearColor: false, Color.clear);
			OcclusionCapsule.DrawCapsules(m_cmd, m_clusterMesh, 0, m_material, 1);
			Graphics.ExecuteCommandBuffer(m_cmd);
		}
	}

	private void UpdateClusters(Camera camera)
	{
		Utils.LazyCreate(ref m_rasterTarget, "Raster Target", clusterSize.x, clusterSize.y, 1, RenderTextureFormat.R8);
		Utils.LazyCreate(ref m_clusterCount, "Clusters (Count)", clusterSize.x, clusterSize.y, clusterSize.z, RenderTextureFormat.RInt);
		Utils.LazyCreate(ref m_clusterPointer, "Clusters (Pointer)", clusterSize.x, clusterSize.y, clusterSize.z, RenderTextureFormat.RInt);
		Utils.LazyCreate(ref m_clusters, "Clusters", clusterSize.x, clusterSize.y, clusterSize.z, RenderTextureFormat.RGInt);
		Utils.LazyCreate(ref m_clusterData, "Cluster Data", clusterSize.x * clusterSize.y * clusterSize.z * clusterDataHeadroom, 8);
		Utils.LazyCreate(ref m_counter, "Counter", 1, 4);
		m_counterData[0] = 0u;
		m_counter.SetData(m_counterData);
		m_cmd.Clear();
		Utils.GetFrustumRays(camera.worldToCameraMatrix, camera.projectionMatrix, m_frustumRays);
		m_cmd.SetGlobalVector(ShaderIDs.CameraPosition, camera.transform.position);
		m_cmd.SetGlobalVector(ShaderIDs.CameraForward, camera.transform.forward);
		m_cmd.SetGlobalFloat(ShaderIDs.Range, Mathf.Min(maxCameraRange, camera.farClipPlane));
		m_cmd.SetGlobalVectorArray(ShaderIDs.FrustumRays, m_frustumRays);
		m_cmd.SetGlobalVector(ShaderIDs.ClusterSize, (Vector3)clusterSize);
		m_cmd.SetComputeTextureParam(m_compute, 0, ShaderIDs.ClustersPointer, m_clusterPointer);
		m_cmd.SetComputeTextureParam(m_compute, 0, ShaderIDs.ClustersCount, m_clusterCount);
		m_cmd.DispatchCompute(m_compute, 0, Utils.GetThreadGroupCount(8, clusterSize));
		if (clusteringMethod == ClusteringMethod.Compute)
		{
			m_cmd.SetComputeBufferParam(m_compute, 1, ShaderIDs.ClusterData, m_clusterData);
			m_cmd.SetComputeBufferParam(m_compute, 1, ShaderIDs.Counter, m_counter);
			m_cmd.SetComputeTextureParam(m_compute, 1, ShaderIDs.ClustersPointer, m_clusterPointer);
			m_cmd.SetComputeTextureParam(m_compute, 1, ShaderIDs.ClustersCount, m_clusterCount);
			m_cmd.DispatchCompute(m_compute, 1, Utils.GetThreadGroupCount(8, clusterSize));
		}
		else
		{
			m_cmd.SetGlobalFloat(ShaderIDs.ConservativeRasterization, conservativeRasterization ? 1 : 0);
			m_cmd.SetRenderTarget(m_rasterTarget);
			m_cmd.SetViewProjectionMatrices(camera.worldToCameraMatrix, camera.projectionMatrix);
			m_cmd.SetRandomWriteTarget(1, m_clusterCount);
			m_cmd.SetRandomWriteTarget(2, m_clusterPointer);
			m_cmd.SetRandomWriteTarget(3, m_clusterData);
			m_cmd.SetRandomWriteTarget(4, m_counter);
			OcclusionCapsule.DrawCapsules(m_cmd, m_clusterMesh, 0, m_material, 0);
			m_cmd.ClearRandomWriteTargets();
		}
		m_cmd.SetComputeTextureParam(m_compute, 2, ShaderIDs.ClustersPointer, m_clusterPointer);
		m_cmd.SetComputeTextureParam(m_compute, 2, ShaderIDs.ClustersCount, m_clusterCount);
		m_cmd.SetComputeTextureParam(m_compute, 2, ShaderIDs.Clusters, m_clusters);
		m_cmd.DispatchCompute(m_compute, 2, Utils.GetThreadGroupCount(8, clusterSize));
		m_cmd.SetGlobalTexture(ShaderIDs.CapsuleClusters, m_clusters);
		m_cmd.SetGlobalTexture(ShaderIDs.CapsuleClustersPointer, m_clusterPointer);
		m_cmd.SetGlobalTexture(ShaderIDs.CapsuleClustersCount, m_clusterCount);
		m_cmd.SetGlobalBuffer(ShaderIDs.CapsuleClusterData, m_clusterData);
		m_cmd.SetGlobalFloat(ShaderIDs.CapsuleOcclusionIntensity, intensity);
		m_cmd.SetGlobalFloat(ShaderIDs.DebugClusters, debugClusters ? 1 : 0);
		m_cmd.SetGlobalFloat(ShaderIDs.DepthToRange, Mathf.Max(1f, camera.farClipPlane / maxCameraRange));
		Graphics.ExecuteCommandBuffer(m_cmd);
	}

	public int GetByteCount()
	{
		int num = clusterSize.x * clusterSize.y;
		int num2 = clusterSize.x * clusterSize.y * clusterSize.z;
		return 0 + num * 8 + num2 * 4 * 2 + num2 * 4 + num2 * 4 + num2 * clusterDataHeadroom * 4 * 2 + 4;
	}

	private void Update()
	{
	}

	private void OnDrawGizmos()
	{
		if (debugBounds)
		{
			for (int i = 0; i < OcclusionCapsule.instances.Count; i++)
			{
				OcclusionCapsule.instances[i].DrawBoundsGizmo();
			}
		}
	}
}
