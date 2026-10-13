using Unity.Jobs;

namespace UnityEngine.Rendering;

internal struct IndirectBufferContext(JobHandle cullingJobHandle)
{
	public enum BufferState
	{
		Pending = 0,
		Zeroed = 1,
		NoOcclusionTest = 2,
		AllInstancesOcclusionTested = 3,
		OccludedInstancesReTested = 4
	}

	public JobHandle cullingJobHandle = cullingJobHandle;

	public BufferState bufferState = BufferState.Pending;

	public int occluderVersion = 0;

	public int subviewMask = 0;

	public bool Matches(BufferState bufferState, int occluderVersion, int subviewMask)
	{
		if (this.bufferState == bufferState && this.occluderVersion == occluderVersion)
		{
			return this.subviewMask == subviewMask;
		}
		return false;
	}
}
