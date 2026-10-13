using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XAsyncProviderData
{
	internal Unity.XGamingRuntime.Interop.XAsyncProviderData interop;

	internal XAsyncBlock _async;

	public XAsyncBlock Async
	{
		get
		{
			return _async;
		}
		set
		{
			_async = value;
		}
	}

	public ulong BufferSize
	{
		get
		{
			return interop.bufferSize;
		}
		set
		{
			interop.bufferSize = value;
		}
	}

	public IntPtr Buffer
	{
		get
		{
			return interop.buffer;
		}
		set
		{
			interop.buffer = value;
		}
	}

	public IntPtr Context
	{
		get
		{
			return interop.context;
		}
		set
		{
			interop.context = value;
		}
	}

	internal XAsyncProviderData(Unity.XGamingRuntime.Interop.XAsyncProviderData interop, XAsyncBlock block)
	{
		_async = block;
		this.interop = interop;
	}
}
