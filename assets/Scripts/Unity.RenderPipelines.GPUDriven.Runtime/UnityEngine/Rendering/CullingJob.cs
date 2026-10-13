using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;

namespace UnityEngine.Rendering;

[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
internal struct CullingJob : IJobParallelFor
{
	private enum CrossFadeType
	{
		kDisabled = 0,
		kCrossFadeOut = 1,
		kCrossFadeIn = 2,
		kVisible = 3
	}

	public const int k_BatchSize = 32;

	private const uint k_LODFadeZeroPacked = 127u;

	private const float k_LODPercentInvisible = 0f;

	private const float k_LODPercentFullyVisible = 1f;

	private const float k_LODPercentSpeedTree = 2f;

	private const float k_SmallMeshTransitionWidth = 0.1f;

	[ReadOnly]
	public BinningConfig binningConfig;

	[ReadOnly]
	public BatchCullingViewType viewType;

	[ReadOnly]
	public float3 cameraPosition;

	[ReadOnly]
	public float sqrScreenRelativeMetric;

	[ReadOnly]
	public float minScreenRelativeHeight;

	[ReadOnly]
	public bool isOrtho;

	[ReadOnly]
	public bool cullLightmappedShadowCasters;

	[ReadOnly]
	public int maxLOD;

	[ReadOnly]
	public uint cullingLayerMask;

	[ReadOnly]
	public ulong sceneCullingMask;

	[ReadOnly]
	public NativeArray<FrustumPlaneCuller.PlanePacket4> frustumPlanePackets;

	[ReadOnly]
	public NativeArray<FrustumPlaneCuller.SplitInfo> frustumSplitInfos;

	[ReadOnly]
	public NativeArray<Plane> lightFacingFrustumPlanes;

	[ReadOnly]
	public NativeArray<ReceiverSphereCuller.SplitInfo> receiverSplitInfos;

	public float3x3 worldToLightSpaceRotation;

	[ReadOnly]
	public CPUInstanceData.ReadOnly instanceData;

	[ReadOnly]
	public CPUSharedInstanceData.ReadOnly sharedInstanceData;

	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	[ReadOnly]
	public NativeList<LODGroupCullingData> lodGroupCullingData;

	[NativeDisableUnsafePtrRestriction]
	[ReadOnly]
	public IntPtr occlusionBuffer;

	[NativeDisableParallelForRestriction]
	[WriteOnly]
	public NativeArray<byte> rendererVisibilityMasks;

	[NativeDisableParallelForRestriction]
	[WriteOnly]
	public NativeArray<byte> rendererCrossFadeValues;

	private static uint PackFloatToUint8(float percent)
	{
		uint valueToClamp = (uint)((1f + percent) * 127f + 0.5f);
		if (percent < 0f)
		{
			return math.clamp(valueToClamp, 0u, 126u);
		}
		return math.clamp(valueToClamp, 128u, 254u);
	}

	private unsafe float CalculateLODVisibility(int instanceIndex, int sharedInstanceIndex, InstanceFlags instanceFlags)
	{
		float num = 1f;
		uint num2 = sharedInstanceData.lodGroupAndMasks[sharedInstanceIndex];
		if (num2 != uint.MaxValue)
		{
			num = 0f;
			uint index = num2 >> 8;
			uint num3 = num2 & 0xFF;
			ref LODGroupCullingData reference = ref lodGroupCullingData.ElementAt((int)index);
			if (reference.forceLODMask != 0)
			{
				if ((reference.forceLODMask & num3) == 0)
				{
					return 0f;
				}
				return 1f;
			}
			float num4 = (isOrtho ? sqrScreenRelativeMetric : LODGroupRenderingUtils.CalculateSqrPerspectiveDistance(reference.worldSpaceReferencePoint, cameraPosition, sqrScreenRelativeMetric));
			uint num5 = (uint)(-1 << maxLOD);
			num3 &= num5;
			int num6 = math.max(math.tzcnt(num3) - 1, maxLOD);
			for (num3 >>= num6; num3 != 0; num3 >>= 1)
			{
				float num7 = ((num6 == maxLOD) ? 0f : reference.sqrDistances[num6 - 1]);
				float num8 = reference.sqrDistances[num6];
				if (num4 < num7)
				{
					break;
				}
				if (num4 < num8)
				{
					CrossFadeType crossFadeType = (CrossFadeType)(num3 & 3);
					switch (crossFadeType)
					{
					case CrossFadeType.kVisible:
						num = 1f;
						break;
					default:
					{
						float num9 = math.sqrt(num4);
						float num10 = math.sqrt(num8);
						if (reference.percentageFlags[num6])
						{
							switch (crossFadeType)
							{
							case CrossFadeType.kCrossFadeIn:
								num = 0f;
								break;
							case CrossFadeType.kCrossFadeOut:
							{
								float num11 = ((num6 > 0) ? math.sqrt(reference.sqrDistances[num6 - 1]) : reference.worldSpaceSize);
								num = 2f + math.max(num9 - num11, 0f) / (num10 - num11);
								break;
							}
							}
							break;
						}
						float num12 = reference.transitionDistances[num6];
						float num13 = num10 - num9;
						if (num13 < num12)
						{
							num = num13 / num12;
							if (crossFadeType == CrossFadeType.kCrossFadeIn)
							{
								num = 0f - num;
							}
						}
						else if (crossFadeType == CrossFadeType.kCrossFadeOut)
						{
							num = 1f;
						}
						break;
					}
					case CrossFadeType.kDisabled:
						break;
					}
					break;
				}
				num6++;
			}
		}
		else if (viewType < BatchCullingViewType.SelectionOutline && (instanceFlags & InstanceFlags.SmallMeshCulling) != InstanceFlags.None)
		{
			ref readonly AABB reference2 = ref instanceData.worldAABBs.UnsafeElementAt(instanceIndex);
			float num14 = math.sqrt(isOrtho ? sqrScreenRelativeMetric : LODGroupRenderingUtils.CalculateSqrPerspectiveDistance(reference2.center, cameraPosition, sqrScreenRelativeMetric));
			float3 float5 = reference2.extents * 2f;
			float size = math.max(math.max(float5.x, float5.y), float5.z);
			float num15 = LODGroupRenderingUtils.CalculateLODDistance(minScreenRelativeHeight, size);
			float relativeScreenHeight = minScreenRelativeHeight + 0.1f * minScreenRelativeHeight;
			float num16 = Mathf.Max(0f, num15 - LODGroupRenderingUtils.CalculateLODDistance(relativeScreenHeight, size));
			num = math.saturate((num15 - num14) / num16);
		}
		return num;
	}

	private uint CalculateVisibilityMask(int instanceIndex, int sharedInstanceIndex, InstanceFlags instanceFlags)
	{
		if (cullingLayerMask == 0)
		{
			return 0u;
		}
		if ((cullingLayerMask & (1 << sharedInstanceData.gameObjectLayers[sharedInstanceIndex])) == 0L)
		{
			return 0u;
		}
		if (cullLightmappedShadowCasters && (instanceFlags & InstanceFlags.AffectsLightmaps) != InstanceFlags.None)
		{
			return 0u;
		}
		if (viewType == BatchCullingViewType.Camera && (instanceFlags & InstanceFlags.IsShadowsOnly) != InstanceFlags.None)
		{
			return 0u;
		}
		if (viewType == BatchCullingViewType.Light && (instanceFlags & InstanceFlags.IsShadowsOff) != InstanceFlags.None)
		{
			return 0u;
		}
		ref readonly AABB reference = ref instanceData.worldAABBs.UnsafeElementAt(instanceIndex);
		uint num = FrustumPlaneCuller.ComputeSplitVisibilityMask(frustumPlanePackets, frustumSplitInfos, in reference);
		if (num != 0 && receiverSplitInfos.Length > 0)
		{
			num &= ReceiverSphereCuller.ComputeSplitVisibilityMask(lightFacingFrustumPlanes, receiverSplitInfos, worldToLightSpaceRotation, in reference);
		}
		if (num != 0 && occlusionBuffer != IntPtr.Zero)
		{
			num = (BatchRendererGroup.OcclusionTestAABB(occlusionBuffer, reference.ToBounds()) ? num : 0u);
		}
		return num;
	}

	public void Execute(int instanceIndex)
	{
		InstanceHandle instance = instanceData.instances[instanceIndex];
		int num = sharedInstanceData.InstanceToIndex(in instanceData, instance);
		InstanceFlags instanceFlags = sharedInstanceData.flags[num].instanceFlags;
		uint num2 = CalculateVisibilityMask(instanceIndex, num, instanceFlags);
		uint num3 = 127u;
		if (num2 != 0)
		{
			float num4 = CalculateLODVisibility(instanceIndex, num, instanceFlags);
			if (num4 != 0f)
			{
				if (binningConfig.supportsMotionCheck)
				{
					bool flag = instanceData.movedInPreviousFrameBits.Get(instanceIndex);
					num2 = (num2 << 1) | (uint)(flag ? 1 : 0);
				}
				if (binningConfig.supportsCrossFade)
				{
					bool flag2 = false;
					if (num4 != 1f)
					{
						if (num4 >= 2f)
						{
							num4 -= 2f;
						}
						else
						{
							flag2 = true;
						}
						num3 = PackFloatToUint8(num4);
					}
					num2 = (num2 << 1) | (uint)(flag2 ? 1 : 0);
				}
			}
			else
			{
				num2 = 0u;
			}
		}
		rendererVisibilityMasks[instance.index] = (byte)num2;
		rendererCrossFadeValues[instance.index] = (byte)num3;
	}
}
