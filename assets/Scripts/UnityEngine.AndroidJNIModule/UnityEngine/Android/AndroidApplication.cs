using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Android;

[StaticAccessor("AndroidApplication", StaticAccessorType.DoubleColon)]
[NativeHeader("Modules/AndroidJNI/Public/AndroidApplication.bindings.h")]
public static class AndroidApplication
{
	private static SynchronizationContext m_MainThreadSynchronizationContext;

	private static AndroidJavaObjectUnityOwned m_Context;

	private static AndroidJavaObjectUnityOwned m_Activity;

	private static AndroidJavaObjectUnityOwned m_UnityPlayer;

	private static AndroidConfiguration m_CurrentConfiguration;

	internal static extern IntPtr UnityPlayerRaw
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[ThreadSafe]
		get;
	}

	private static extern IntPtr CurrentContextRaw
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[ThreadSafe]
		get;
	}

	private static extern IntPtr CurrentActivityRaw
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[ThreadSafe]
		get;
	}

	public static AndroidJavaObject currentContext
	{
		get
		{
			if (m_Context != null)
			{
				return m_Context;
			}
			m_Context = new AndroidJavaObjectUnityOwned(CurrentContextRaw);
			return m_Context;
		}
	}

	public static AndroidJavaObject currentActivity
	{
		get
		{
			if (m_Activity != null)
			{
				return m_Activity;
			}
			m_Activity = new AndroidJavaObjectUnityOwned(CurrentActivityRaw);
			return m_Activity;
		}
	}

	public static AndroidJavaObject unityPlayer
	{
		get
		{
			if (m_UnityPlayer != null)
			{
				return m_UnityPlayer;
			}
			m_UnityPlayer = new AndroidJavaObjectUnityOwned(UnityPlayerRaw);
			return m_UnityPlayer;
		}
	}

	public static AndroidConfiguration currentConfiguration => m_CurrentConfiguration;

	public static event Action<AndroidConfiguration> onConfigurationChanged;

	[RequiredByNativeCode(GenerateProxy = true)]
	private static void AcquireMainThreadSynchronizationContext()
	{
		m_MainThreadSynchronizationContext = SynchronizationContext.Current;
		if (m_MainThreadSynchronizationContext == null)
		{
			throw new Exception("Failed to acquire main thread synchronization context");
		}
	}

	[RequiredByNativeCode(GenerateProxy = true)]
	private static void SetCurrentConfiguration(AndroidConfiguration config)
	{
		m_CurrentConfiguration = config;
	}

	[RequiredByNativeCode(GenerateProxy = true)]
	private static AndroidConfiguration GetCurrentConfiguration()
	{
		return m_CurrentConfiguration;
	}

	[RequiredByNativeCode(GenerateProxy = true)]
	private static void DispatchConfigurationChanged(bool notifySubscribers)
	{
		if (notifySubscribers)
		{
			onConfigurationChanged?.Invoke(m_CurrentConfiguration);
		}
	}

	public static void InvokeOnUIThread(Action action)
	{
		AndroidJNI.InvokeAttached(() =>
		{
			unityPlayer.Call("runOnUiThread", new AndroidJavaRunnable(action.Invoke));
		});
	}

	public static void InvokeOnUnityMainThread(Action action)
	{
		m_MainThreadSynchronizationContext.Send((object o) =>
		{
			action();
		}, null);
	}
}
