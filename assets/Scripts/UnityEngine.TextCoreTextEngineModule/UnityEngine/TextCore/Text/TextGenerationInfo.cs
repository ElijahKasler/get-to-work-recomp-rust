using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.TextCore.Text;

[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
internal static class TextGenerationInfo
{
	[MethodImpl(MethodImplOptions.InternalCall)]
	[ThreadSafe]
	public static extern IntPtr Create();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void Destroy(IntPtr ptr);
}
