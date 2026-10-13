using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections;

namespace UnityEngine.Rendering;

[BurstCompile]
internal static class InstanceCullerBurst
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal unsafe delegate void SetupCullingJobInput_00000142_0024PostfixBurstDelegate(float lodBias, BatchCullingContext* context, ReceiverPlanes* receiverPlanes, ReceiverSphereCuller* receiverSphereCuller, FrustumPlaneCuller* frustumPlaneCuller, float* screenRelativeMetric);

	internal static class SetupCullingJobInput_00000142_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<SetupCullingJobInput_00000142_0024PostfixBurstDelegate>(SetupCullingJobInput).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(float lodBias, BatchCullingContext* context, ReceiverPlanes* receiverPlanes, ReceiverSphereCuller* receiverSphereCuller, FrustumPlaneCuller* frustumPlaneCuller, float* screenRelativeMetric)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<float, BatchCullingContext*, ReceiverPlanes*, ReceiverSphereCuller*, FrustumPlaneCuller*, float*, void>)functionPointer)(lodBias, context, receiverPlanes, receiverSphereCuller, frustumPlaneCuller, screenRelativeMetric);
					return;
				}
			}
			SetupCullingJobInput_0024BurstManaged(lodBias, context, receiverPlanes, receiverSphereCuller, frustumPlaneCuller, screenRelativeMetric);
		}
	}

	[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
	[MonoPInvokeCallback(typeof(UnityEngine_002ERendering_002ESetupCullingJobInput_00000142_0024PostfixBurstDelegate))]
	public unsafe static void SetupCullingJobInput(float lodBias, BatchCullingContext* context, ReceiverPlanes* receiverPlanes, ReceiverSphereCuller* receiverSphereCuller, FrustumPlaneCuller* frustumPlaneCuller, float* screenRelativeMetric)
	{
		SetupCullingJobInput_00000142_0024BurstDirectCall.Invoke(lodBias, context, receiverPlanes, receiverSphereCuller, frustumPlaneCuller, screenRelativeMetric);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
	internal unsafe static void SetupCullingJobInput_0024BurstManaged(float lodBias, BatchCullingContext* context, ReceiverPlanes* receiverPlanes, ReceiverSphereCuller* receiverSphereCuller, FrustumPlaneCuller* frustumPlaneCuller, float* screenRelativeMetric)
	{
		*receiverPlanes = ReceiverPlanes.Create(in *context, Allocator.TempJob);
		*receiverSphereCuller = ReceiverSphereCuller.Create(in *context, Allocator.TempJob);
		*frustumPlaneCuller = FrustumPlaneCuller.Create(in *context, receiverPlanes->planes.AsArray(), in *receiverSphereCuller, Allocator.TempJob);
		*screenRelativeMetric = LODGroupRenderingUtils.CalculateScreenRelativeMetric(context->lodParameters, lodBias);
	}
}
