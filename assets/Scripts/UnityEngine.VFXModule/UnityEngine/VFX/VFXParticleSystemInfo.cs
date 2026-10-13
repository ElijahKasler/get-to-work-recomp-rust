using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.VFX;

[UsedByNativeCode]
[NativeHeader("Modules/VFX/Public/Systems/VFXParticleSystem.h")]
public struct VFXParticleSystemInfo(uint aliveCount, uint capacity, bool sleeping, Bounds bounds)
{
	public uint aliveCount = aliveCount;

	public uint capacity = capacity;

	public bool sleeping = sleeping;

	public Bounds bounds = bounds;
}
