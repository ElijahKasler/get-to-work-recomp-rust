using System;
using System.Runtime.InteropServices;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblContextHandle : EquatableHandle
{
	internal GCHandle m_gCHandle;

	internal SDK.XBL.XblMultiplayerSessionChangedHandler sessionChangedCallback;

	internal XblFunctionContext sessionChangedHandlerId;

	internal SDK.XBL.XblMultiplayerSessionSubscriptionLostHandler sessionSubscriptionLostCallback;

	internal XblFunctionContext sessionSubscriptionLostId;

	internal SDK.XBL.XblMultiplayerConnectionIdChangedHandler connectionIdChangedCallback;

	internal XblFunctionContext connectionIdChangedId;

	internal SDK.XBL.XblUserStatisticsStatisticChangedHandler statisticChangedCallback;

	internal XblFunctionContext statisiticsAddChangeId;

	public override bool IsInvalid => base.Handle == IntPtr.Zero;

	public event SDK.XBL.XblMultiplayerSessionChangedHandler XblMultiplayerSessionChanged
	{
		add
		{
			if (sessionChangedCallback == null)
			{
				sessionChangedHandlerId = XblInterop.XblMultiplayerAddSessionChangedHandler(base.Handle, XblMultiplayerSessionChangedCallback, GCHandle.ToIntPtr(m_gCHandle));
			}
			sessionChangedCallback = (SDK.XBL.XblMultiplayerSessionChangedHandler)Delegate.Combine(sessionChangedCallback, value);
		}
		remove
		{
			sessionChangedCallback = (SDK.XBL.XblMultiplayerSessionChangedHandler)Delegate.Remove(sessionChangedCallback, value);
			if (sessionChangedCallback == null)
			{
				XblInterop.XblMultiplayerRemoveSessionChangedHandler(base.Handle, sessionChangedHandlerId);
				sessionChangedHandlerId = default;
			}
		}
	}

	public event SDK.XBL.XblMultiplayerSessionSubscriptionLostHandler XblMultiplayerSessionSubscriptionLost
	{
		add
		{
			if (sessionSubscriptionLostCallback == null)
			{
				sessionSubscriptionLostId = XblInterop.XblMultiplayerAddSubscriptionLostHandler(base.Handle, XblMultiplayerSessionSubscriptionLostCallback, GCHandle.ToIntPtr(m_gCHandle));
			}
			sessionSubscriptionLostCallback = (SDK.XBL.XblMultiplayerSessionSubscriptionLostHandler)Delegate.Combine(sessionSubscriptionLostCallback, value);
		}
		remove
		{
			sessionSubscriptionLostCallback = (SDK.XBL.XblMultiplayerSessionSubscriptionLostHandler)Delegate.Remove(sessionSubscriptionLostCallback, value);
			if (sessionSubscriptionLostCallback == null)
			{
				XblInterop.XblMultiplayerRemoveSubscriptionLostHandler(base.Handle, sessionSubscriptionLostId);
				sessionSubscriptionLostId = default;
			}
		}
	}

	public event SDK.XBL.XblMultiplayerConnectionIdChangedHandler XblMultiplayerConnectionIdChanged
	{
		add
		{
			if (connectionIdChangedCallback == null)
			{
				connectionIdChangedId = XblInterop.XblMultiplayerAddConnectionIdChangedHandler(base.Handle, XblMultiplayerConnectionIdChangedCallback, GCHandle.ToIntPtr(m_gCHandle));
			}
			connectionIdChangedCallback = (SDK.XBL.XblMultiplayerConnectionIdChangedHandler)Delegate.Combine(connectionIdChangedCallback, value);
		}
		remove
		{
			connectionIdChangedCallback = (SDK.XBL.XblMultiplayerConnectionIdChangedHandler)Delegate.Remove(connectionIdChangedCallback, value);
			if (connectionIdChangedCallback == null)
			{
				XblInterop.XblMultiplayerRemoveConnectionIdChangedHandler(base.Handle, connectionIdChangedId);
				connectionIdChangedId = default;
			}
		}
	}

	public event SDK.XBL.XblUserStatisticsStatisticChangedHandler XblUserStatisticsStatisticChanged
	{
		add
		{
			if (statisticChangedCallback == null)
			{
				statisiticsAddChangeId = XblInterop.XblUserStatisticsAddStatisticChangedHandler(base.Handle, XblUserStatisticsAddChangedCallback, GCHandle.ToIntPtr(m_gCHandle));
			}
			statisticChangedCallback = (SDK.XBL.XblUserStatisticsStatisticChangedHandler)Delegate.Combine(statisticChangedCallback, value);
		}
		remove
		{
			statisticChangedCallback = (SDK.XBL.XblUserStatisticsStatisticChangedHandler)Delegate.Remove(statisticChangedCallback, value);
			if (statisticChangedCallback == null)
			{
				XblInterop.XblUserStatisticsRemoveStatisticChangedHandler(base.Handle, GCHandle.ToIntPtr(m_gCHandle));
				statisiticsAddChangeId = default;
			}
		}
	}

	[MonoPInvokeCallback]
	private static void XblMultiplayerSessionChangedCallback(IntPtr context, Unity.XGamingRuntime.Interop.XblMultiplayerSessionChangeEventArgs args)
	{
		((XblContextHandle)GCHandle.FromIntPtr(context).Target).sessionChangedCallback?.Invoke(new XblMultiplayerSessionChangeEventArgs(args));
	}

	[MonoPInvokeCallback]
	private static void XblMultiplayerSessionSubscriptionLostCallback(IntPtr context)
	{
		((XblContextHandle)GCHandle.FromIntPtr(context).Target).sessionSubscriptionLostCallback?.Invoke();
	}

	[MonoPInvokeCallback]
	private static void XblMultiplayerConnectionIdChangedCallback(IntPtr context)
	{
		((XblContextHandle)GCHandle.FromIntPtr(context).Target).connectionIdChangedCallback?.Invoke();
	}

	[MonoPInvokeCallback]
	private static void XblUserStatisticsAddChangedCallback(Unity.XGamingRuntime.Interop.XblStatisticChangeEventArgs args, IntPtr context)
	{
		((XblContextHandle)GCHandle.FromIntPtr(context).Target).statisticChangedCallback?.Invoke(new XblStatisticChangeEventArgs(args));
	}

	internal XblContextHandle(Unity.XGamingRuntime.Interop.XblContextHandle interopHandle)
		: base(IntPtr.Zero, ownsHandle: true, interopHandle.handle)
	{
	}

	protected override bool ReleaseHandle()
	{
		if (sessionChangedCallback != null)
		{
			Delegate[] invocationList = sessionChangedCallback.GetInvocationList();
			foreach (Delegate obj in invocationList)
			{
				sessionChangedCallback = (SDK.XBL.XblMultiplayerSessionChangedHandler)Delegate.Remove(sessionChangedCallback, (SDK.XBL.XblMultiplayerSessionChangedHandler)obj);
			}
		}
		if (sessionSubscriptionLostCallback != null)
		{
			Delegate[] invocationList = sessionSubscriptionLostCallback.GetInvocationList();
			foreach (Delegate obj2 in invocationList)
			{
				sessionSubscriptionLostCallback = (SDK.XBL.XblMultiplayerSessionSubscriptionLostHandler)Delegate.Remove(sessionSubscriptionLostCallback, (SDK.XBL.XblMultiplayerSessionSubscriptionLostHandler)obj2);
			}
		}
		if (connectionIdChangedCallback != null)
		{
			Delegate[] invocationList = connectionIdChangedCallback.GetInvocationList();
			foreach (Delegate obj3 in invocationList)
			{
				connectionIdChangedCallback = (SDK.XBL.XblMultiplayerConnectionIdChangedHandler)Delegate.Remove(connectionIdChangedCallback, (SDK.XBL.XblMultiplayerConnectionIdChangedHandler)obj3);
			}
		}
		if (statisticChangedCallback != null)
		{
			Delegate[] invocationList = statisticChangedCallback.GetInvocationList();
			foreach (Delegate obj4 in invocationList)
			{
				statisticChangedCallback = (SDK.XBL.XblUserStatisticsStatisticChangedHandler)Delegate.Remove(statisticChangedCallback, (SDK.XBL.XblUserStatisticsStatisticChangedHandler)obj4);
			}
		}
		_ = m_gCHandle;
		m_gCHandle.Free();
		if (SDK.XBL.IsXblInitialized)
		{
			XblInterop.XblContextCloseHandle(base.Handle);
		}
		return true;
	}
}
