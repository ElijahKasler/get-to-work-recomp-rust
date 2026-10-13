using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Internal;

[NativeHeader("Runtime/GfxDevice/HDROutputSettings.h")]
[ExcludeFromDocs]
internal static class InternalHDROutputFaking
{
	[MethodImpl(MethodImplOptions.InternalCall)]
	[ExcludeFromDocs]
	[FreeFunction("HDROutputSettingsBindings::SetFakeHDROutputEnabled")]
	internal static extern void SetEnabled(bool enabled);
}
