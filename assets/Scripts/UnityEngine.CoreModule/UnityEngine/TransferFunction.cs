using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine;

[NativeHeader("Runtime/Graphics/ColorGamut.h")]
[UsedByNativeCode]
public enum TransferFunction
{
	Unknown = -1,
	sRGB = 0,
	BT1886 = 1,
	PQ = 2,
	Linear = 3,
	Gamma22 = 4
}
