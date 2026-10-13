using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.Rendering;

[MovedFrom("UnityEngine.Experimental.Rendering")]
public struct RayTracingMeshInstanceConfig
{
	public Mesh mesh;

	public uint subMeshIndex;

	public RayTracingSubMeshFlags subMeshFlags;

	public bool dynamicGeometry;

	public Material material;

	public MaterialPropertyBlock materialProperties;

	public bool enableTriangleCulling;

	public bool frontTriangleCounterClockwise;

	public int layer;

	public uint renderingLayerMask;

	public uint mask;

	public MotionVectorGenerationMode motionVectorMode;

	public LightProbeUsage lightProbeUsage;

	public LightProbeProxyVolume lightProbeProxyVolume;

	public RayTracingAccelerationStructureBuildFlags accelerationStructureBuildFlags { get; set; }

	public bool accelerationStructureBuildFlagsOverride { get; set; }

	public RayTracingMeshInstanceConfig()
	{
		mesh = null;
		subMeshIndex = 0u;
		material = null;
		subMeshFlags = RayTracingSubMeshFlags.Enabled | RayTracingSubMeshFlags.ClosestHitOnly;
		dynamicGeometry = false;
		materialProperties = null;
		enableTriangleCulling = true;
		frontTriangleCounterClockwise = false;
		layer = 0;
		renderingLayerMask = RenderingLayerMask.defaultRenderingLayerMask;
		mask = 255u;
		motionVectorMode = MotionVectorGenerationMode.Camera;
		lightProbeUsage = LightProbeUsage.Off;
		lightProbeProxyVolume = null;
		accelerationStructureBuildFlags = RayTracingAccelerationStructureBuildFlags.PreferFastTrace;
		accelerationStructureBuildFlagsOverride = false;
	}

	public RayTracingMeshInstanceConfig(Mesh mesh, uint subMeshIndex, Material material)
	{
		this.mesh = mesh;
		this.subMeshIndex = subMeshIndex;
		this.material = material;
		subMeshFlags = RayTracingSubMeshFlags.Enabled | RayTracingSubMeshFlags.ClosestHitOnly;
		dynamicGeometry = false;
		materialProperties = null;
		enableTriangleCulling = true;
		frontTriangleCounterClockwise = false;
		layer = 0;
		renderingLayerMask = RenderingLayerMask.defaultRenderingLayerMask;
		mask = 255u;
		motionVectorMode = MotionVectorGenerationMode.Camera;
		lightProbeUsage = LightProbeUsage.Off;
		lightProbeProxyVolume = null;
		accelerationStructureBuildFlags = RayTracingAccelerationStructureBuildFlags.PreferFastTrace;
		accelerationStructureBuildFlagsOverride = false;
	}
}
