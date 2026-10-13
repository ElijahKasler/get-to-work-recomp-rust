using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime;

public class CallbackWrapper<T> : IDisposable where T : Delegate
{
	private GCHandle selfPtr;

	public T StaticCallback { get; private set; }

	public T Callback { get; private set; }

	public IntPtr Context { get; private set; }

	public IntPtr CallbackContext => GCHandle.ToIntPtr(selfPtr);

	public CallbackWrapper(T callback, IntPtr context, T staticCallback)
	{
		if (staticCallback.Target != null)
		{
			throw new InvalidOperationException("staticCallback must point to a static method");
		}
		Callback = callback;
		Context = context;
		selfPtr = GCHandle.Alloc(this);
		StaticCallback = staticCallback;
	}

	~CallbackWrapper()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		selfPtr.Free();
	}
}
