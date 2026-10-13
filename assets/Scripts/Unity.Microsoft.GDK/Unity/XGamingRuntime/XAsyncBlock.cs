using System;
using System.Runtime.InteropServices;
using AOT;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XAsyncBlock : IDisposable
{
	public struct XAsyncBlockInterop
	{
		public IntPtr queue;

		public IntPtr context;

		public IntPtr callback;

		public unsafe fixed byte reserved[32];
	}

	public XTaskQueueHandle Queue;

	public IntPtr Context;

	public XAsyncCompletionRoutine Callback;

	public XAsyncBlockInterop Interop;

	private GCHandle callbackObjHandle;

	private GCHandle interopHandle;

	private static XAsyncCompletionRoutineInterop InteropCallback = OnXAsyncBlockCompletion;

	private bool disposedValue;

	public bool IsCompleted { get; private set; }

	public IntPtr InteropPtr => interopHandle.AddrOfPinnedObject();

	[AOT.MonoPInvokeCallback(typeof(XAsyncCompletionRoutineInterop))]
	private static void OnXAsyncBlockCompletion(IntPtr asyncBlock)
	{
		(GCHandle.FromIntPtr(((XAsyncBlockInterop)Marshal.PtrToStructure(asyncBlock, typeof(XAsyncBlockInterop))).context).Target as XAsyncBlock).DoCompletionCallback();
	}

	public XAsyncBlock(XTaskQueueHandle queue, XAsyncCompletionRoutine callback, IntPtr context)
	{
		Queue = queue;
		Context = context;
		Callback = callback;
		Interop = new XAsyncBlockInterop
		{
			queue = ((queue != null) ? queue.Handle : IntPtr.Zero)
		};
		if (callback != null)
		{
			callbackObjHandle = GCHandle.Alloc(this);
			Interop.context = GCHandle.ToIntPtr(callbackObjHandle);
			Interop.callback = Marshal.GetFunctionPointerForDelegate(InteropCallback);
		}
		interopHandle = GCHandle.Alloc(Interop, GCHandleType.Pinned);
	}

	private void DoCompletionCallback()
	{
		Callback(this);
		IsCompleted = true;
		if (callbackObjHandle.IsAllocated)
		{
			callbackObjHandle.Free();
		}
		if (interopHandle.IsAllocated)
		{
			interopHandle.Free();
		}
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (callbackObjHandle.IsAllocated)
			{
				callbackObjHandle.Free();
			}
			if (interopHandle.IsAllocated)
			{
				interopHandle.Free();
			}
			disposedValue = true;
		}
	}

	~XAsyncBlock()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
