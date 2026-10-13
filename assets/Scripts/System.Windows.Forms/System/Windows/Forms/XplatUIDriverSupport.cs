using System.Runtime.InteropServices;
using System.Threading;

namespace System.Windows.Forms;

internal static class XplatUIDriverSupport
{
	internal static void ExecutionCallback(AsyncMethodData data)
	{
		AsyncMethodResult result = data.Result;
		object result2;
		try
		{
			result2 = data.Method.DynamicInvoke(data.Args);
		}
		catch (Exception ex)
		{
			if (result != null)
			{
				result.CompleteWithException(ex);
				return;
			}
			throw;
		}
		result?.Complete(result2);
	}

	private static void ExecutionCallbackInContext(object state)
	{
		AsyncMethodData asyncMethodData = (AsyncMethodData)state;
		if (asyncMethodData.SyncContext == null)
		{
			ExecutionCallback(asyncMethodData);
			return;
		}
		SynchronizationContext current = SynchronizationContext.Current;
		SynchronizationContext.SetSynchronizationContext(asyncMethodData.SyncContext);
		try
		{
			ExecutionCallback(asyncMethodData);
		}
		finally
		{
			SynchronizationContext.SetSynchronizationContext(current);
		}
	}

	internal static void ExecuteClientMessage(GCHandle gchandle)
	{
		AsyncMethodData asyncMethodData = (AsyncMethodData)gchandle.Target;
		try
		{
			if (asyncMethodData.Context == null)
			{
				ExecutionCallback(asyncMethodData);
				return;
			}
			asyncMethodData.SyncContext = SynchronizationContext.Current;
			ExecutionContext.Run(asyncMethodData.Context, ExecutionCallbackInContext, asyncMethodData);
		}
		finally
		{
			gchandle.Free();
		}
	}
}
