using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Rendering;

[NativeHeader("Runtime/Graphics/DrawSplashScreenAndWatermarks.h")]
public class Watermark
{
	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("IsAnyWatermarkVisible")]
	public static extern bool IsVisible();
}
