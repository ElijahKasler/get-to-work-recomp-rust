using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.UIElements.UIR;

namespace UnityEngine.UIElements;

[NativeType(Header = "Modules/UIElements/Core/Native/Renderer/UIRenderer.h")]
public sealed class UIRenderer : Renderer
{
	internal volatile List<CommandList>[] commandLists;

	internal volatile bool skipRendering;

	internal void SetNativeData(int safeFrameIndex, int cmdListIndex, Material mat)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetNativeData_Injected(intPtr, safeFrameIndex, cmdListIndex, MarshalledUnityObject.Marshal(mat));
	}

	[RequiredByNativeCode]
	private static void OnRenderNodeExecute(UIRenderer renderer, int safeFrameIndex, int cmdListIndex)
	{
		if (!renderer.skipRendering)
		{
			List<CommandList>[] array = renderer.commandLists;
			List<CommandList> list = ((array != null) ? array[safeFrameIndex] : null);
			if (list != null && cmdListIndex < list.Count)
			{
				list[cmdListIndex]?.Execute();
			}
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetNativeData_Injected(IntPtr _unity_self, int safeFrameIndex, int cmdListIndex, IntPtr mat);
}
