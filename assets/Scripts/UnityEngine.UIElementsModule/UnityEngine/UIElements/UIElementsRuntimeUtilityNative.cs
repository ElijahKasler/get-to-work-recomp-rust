using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.UIElements;

[VisibleToOtherModules(new string[] { "Unity.UIElements" })]
[NativeHeader("Modules/UIElements/Core/Native/UIElementsRuntimeUtilityNative.h")]
internal static class UIElementsRuntimeUtilityNative
{
	internal static Action UpdatePanelsCallback;

	internal static Action<bool> RepaintPanelsCallback;

	internal static Action RenderOffscreenPanelsCallback;

	[RequiredByNativeCode]
	public static void UpdatePanels()
	{
		UpdatePanelsCallback?.Invoke();
	}

	[RequiredByNativeCode]
	public static void RepaintPanels(bool onlyOffscreen)
	{
		RepaintPanelsCallback?.Invoke(onlyOffscreen);
	}

	[RequiredByNativeCode]
	public static void RenderOffscreenPanels()
	{
		RenderOffscreenPanelsCallback?.Invoke();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void RegisterPlayerloopCallback();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void UnregisterPlayerloopCallback();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void VisualElementCreation();
}
