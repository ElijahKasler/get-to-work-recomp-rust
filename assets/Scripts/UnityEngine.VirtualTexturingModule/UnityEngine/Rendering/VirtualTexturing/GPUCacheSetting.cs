using System;
using UnityEngine.Bindings;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering.VirtualTexturing;

[Serializable]
[NativeHeader("Modules/VirtualTexturing/Public/VirtualTexturingSettings.h")]
[UsedByNativeCode]
public struct GPUCacheSetting
{
	public GraphicsFormat format;

	public uint sizeInMegaBytes;
}
