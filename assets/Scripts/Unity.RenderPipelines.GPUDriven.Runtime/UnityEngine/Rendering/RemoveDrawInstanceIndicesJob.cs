using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace UnityEngine.Rendering;

[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
internal struct RemoveDrawInstanceIndicesJob : IJob
{
	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	[ReadOnly]
	public NativeArray<int> drawInstanceIndices;

	public NativeList<DrawInstance> drawInstances;

	public NativeParallelHashMap<RangeKey, int> rangeHash;

	public NativeParallelHashMap<DrawKey, int> batchHash;

	public NativeList<DrawRange> drawRanges;

	public NativeList<DrawBatch> drawBatches;

	public void RemoveDrawRange(in RangeKey key)
	{
		int num = rangeHash[key];
		ref DrawRange reference = ref drawRanges.ElementAt(drawRanges.Length - 1);
		rangeHash[reference.key] = num;
		rangeHash.Remove(key);
		drawRanges.RemoveAtSwapBack(num);
	}

	public void RemoveDrawBatch(in DrawKey key)
	{
		int num = batchHash[key];
		drawBatches.ElementAt(num);
		int index = rangeHash[key.range];
		ref DrawRange reference = ref drawRanges.ElementAt(index);
		if (--reference.drawCount == 0)
		{
			RemoveDrawRange(in reference.key);
		}
		ref DrawBatch reference2 = ref drawBatches.ElementAt(drawBatches.Length - 1);
		batchHash[reference2.key] = num;
		batchHash.Remove(key);
		drawBatches.RemoveAtSwapBack(num);
	}

	public unsafe void Execute()
	{
		DrawInstance* unsafePtr = drawInstances.GetUnsafePtr();
		int num = drawInstances.Length - 1;
		for (int num2 = drawInstanceIndices.Length - 1; num2 >= 0; num2--)
		{
			int num3 = drawInstanceIndices[num2];
			DrawInstance* ptr = unsafePtr + num3;
			int index = batchHash[ptr->key];
			ref DrawBatch reference = ref drawBatches.ElementAt(index);
			if (--reference.instanceCount == 0)
			{
				RemoveDrawBatch(in reference.key);
			}
			UnsafeUtility.MemCpy(ptr, unsafePtr + num--, sizeof(DrawInstance));
		}
		drawInstances.ResizeUninitialized(num + 1);
	}
}
