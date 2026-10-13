using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine;

[NativeHeader("Modules/Physics2D/Public/CircleCollider2D.h")]
public sealed class CircleCollider2D : Collider2D
{
	public float radius
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_radius_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_radius_Injected(intPtr, value);
		}
	}

	[Obsolete("CircleCollider2D.center has been deprecated. Use CircleCollider2D.offset instead (UnityUpgradable) -> offset", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Vector2 center
	{
		get
		{
			return Vector2.zero;
		}
		set
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_radius_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_radius_Injected(IntPtr _unity_self, float value);
}
