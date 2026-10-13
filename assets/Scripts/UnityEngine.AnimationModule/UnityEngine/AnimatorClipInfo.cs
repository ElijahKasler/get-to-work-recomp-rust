using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine;

[UsedByNativeCode]
[NativeHeader("Modules/Animation/ScriptBindings/Animation.bindings.h")]
[NativeHeader("Modules/Animation/AnimatorInfo.h")]
public struct AnimatorClipInfo
{
	private int m_ClipInstanceID;

	private float m_Weight;

	public AnimationClip clip => (m_ClipInstanceID != 0) ? InstanceIDToAnimationClipPPtr(m_ClipInstanceID) : null;

	public float weight => m_Weight;

	[FreeFunction("AnimationBindings::InstanceIDToAnimationClipPPtr")]
	private static AnimationClip InstanceIDToAnimationClipPPtr(int instanceID)
	{
		return Unmarshal.UnmarshalUnityObject<AnimationClip>(InstanceIDToAnimationClipPPtr_Injected(instanceID));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr InstanceIDToAnimationClipPPtr_Injected(int instanceID);
}
