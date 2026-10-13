using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine;

[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Runtime/Export/Math/Gradient.bindings.h")]
[RequiredByNativeCode]
public class Gradient : IEquatable<Gradient>
{
	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(Gradient graident)
		{
			return graident.m_Ptr;
		}

		public static Gradient ConvertToManaged(IntPtr ptr)
		{
			return new Gradient(ptr);
		}
	}

	[VisibleToOtherModules(new string[] { "UnityEngine.ParticleSystemModule" })]
	internal IntPtr m_Ptr;

	private bool m_RequiresNativeCleanup;

	public unsafe GradientColorKey[] colorKeys
	{
		[FreeFunction("Gradient_Bindings::GetColorKeys", IsThreadSafe = true, HasExplicitThis = true)]
		get
		{
			BlittableArrayWrapper ret = default;
			GradientColorKey[] result;
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_colorKeys_Injected(intPtr, out ret);
			}
			finally
			{
				GradientColorKey[] array = default;
				ret.Unmarshal(ref array);
				result = array;
			}
			return result;
		}
		[FreeFunction("Gradient_Bindings::SetColorKeys", IsThreadSafe = true, HasExplicitThis = true)]
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<GradientColorKey> span = new Span<GradientColorKey>(value);
			fixed (GradientColorKey* begin = span)
			{
				ManagedSpanWrapper value2 = new ManagedSpanWrapper(begin, span.Length);
				set_colorKeys_Injected(intPtr, ref value2);
			}
		}
	}

	public unsafe GradientAlphaKey[] alphaKeys
	{
		[FreeFunction("Gradient_Bindings::GetAlphaKeys", IsThreadSafe = true, HasExplicitThis = true)]
		get
		{
			BlittableArrayWrapper ret = default;
			GradientAlphaKey[] result;
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_alphaKeys_Injected(intPtr, out ret);
			}
			finally
			{
				GradientAlphaKey[] array = default;
				ret.Unmarshal(ref array);
				result = array;
			}
			return result;
		}
		[FreeFunction("Gradient_Bindings::SetAlphaKeys", IsThreadSafe = true, HasExplicitThis = true)]
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<GradientAlphaKey> span = new Span<GradientAlphaKey>(value);
			fixed (GradientAlphaKey* begin = span)
			{
				ManagedSpanWrapper value2 = new ManagedSpanWrapper(begin, span.Length);
				set_alphaKeys_Injected(intPtr, ref value2);
			}
		}
	}

	[NativeProperty(IsThreadSafe = true)]
	public GradientMode mode
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_mode_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_mode_Injected(intPtr, value);
		}
	}

	[NativeProperty(IsThreadSafe = true)]
	public ColorSpace colorSpace
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_colorSpace_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_colorSpace_Injected(intPtr, value);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction(Name = "Gradient_Bindings::Init", IsThreadSafe = true)]
	private static extern IntPtr Init();

	[FreeFunction(Name = "Gradient_Bindings::Cleanup", IsThreadSafe = true, HasExplicitThis = true)]
	private void Cleanup()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Cleanup_Injected(intPtr);
	}

	[FreeFunction("Gradient_Bindings::Internal_Equals", IsThreadSafe = true, HasExplicitThis = true)]
	private bool Internal_Equals(IntPtr other)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Internal_Equals_Injected(intPtr, other);
	}

	[RequiredByNativeCode]
	public Gradient()
	{
		m_Ptr = Init();
		m_RequiresNativeCleanup = true;
	}

	[VisibleToOtherModules(new string[] { "UnityEngine.ParticleSystemModule" })]
	internal Gradient(IntPtr ptr)
	{
		m_Ptr = ptr;
		m_RequiresNativeCleanup = false;
	}

	~Gradient()
	{
		if (m_RequiresNativeCleanup)
		{
			Cleanup();
		}
	}

	[FreeFunction(Name = "Gradient_Bindings::Evaluate", IsThreadSafe = true, HasExplicitThis = true)]
	public Color Evaluate(float time)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Evaluate_Injected(intPtr, time, out var ret);
		return ret;
	}

	[FreeFunction(Name = "Gradient_Bindings::SetKeys", IsThreadSafe = true, HasExplicitThis = true)]
	public unsafe void SetKeys(GradientColorKey[] colorKeys, GradientAlphaKey[] alphaKeys)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Span<GradientColorKey> span = new Span<GradientColorKey>(colorKeys);
		fixed (GradientColorKey* begin = span)
		{
			ManagedSpanWrapper managedSpanWrapper = new ManagedSpanWrapper(begin, span.Length);
			Span<GradientAlphaKey> span2 = new Span<GradientAlphaKey>(alphaKeys);
			fixed (GradientAlphaKey* begin2 = span2)
			{
				ManagedSpanWrapper managedSpanWrapper2 = new ManagedSpanWrapper(begin2, span2.Length);
				SetKeys_Injected(intPtr, ref managedSpanWrapper, ref managedSpanWrapper2);
			}
		}
	}

	public override bool Equals(object o)
	{
		if (o == null)
		{
			return false;
		}
		if (this == o)
		{
			return true;
		}
		if (o.GetType() != GetType())
		{
			return false;
		}
		return Equals((Gradient)o);
	}

	public bool Equals(Gradient other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (m_Ptr.Equals(other.m_Ptr))
		{
			return true;
		}
		return Internal_Equals(other.m_Ptr);
	}

	public override int GetHashCode()
	{
		return m_Ptr.GetHashCode();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Cleanup_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool Internal_Equals_Injected(IntPtr _unity_self, IntPtr other);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Evaluate_Injected(IntPtr _unity_self, float time, out Color ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_colorKeys_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_colorKeys_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_alphaKeys_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_alphaKeys_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern GradientMode get_mode_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_mode_Injected(IntPtr _unity_self, GradientMode value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern ColorSpace get_colorSpace_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_colorSpace_Injected(IntPtr _unity_self, ColorSpace value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetKeys_Injected(IntPtr _unity_self, ref ManagedSpanWrapper colorKeys, ref ManagedSpanWrapper alphaKeys);
}
