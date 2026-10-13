using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils.Classes.Data;

[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal class NativeMemoryBlock : IDisposable
{
	private int XElZCpTUQRUNuYTaVBtlfnFsihHHA;

	private uint raGrHXWmAFQeDJSheISsHaRRjcCt;

	private IntPtr RPepiYQtGtKcNNmzSjbGvFSccpCK;

	private bool XmcGAZhuDFndCWYMSxrxuovQWWFnA;

	public uint size => raGrHXWmAFQeDJSheISsHaRRjcCt;

	public NativeMemoryBlock(uint P_0)
	{
		if (P_0 == 0)
		{
			throw new Exception("size must be > 0!");
		}
		raGrHXWmAFQeDJSheISsHaRRjcCt = P_0;
		XElZCpTUQRUNuYTaVBtlfnFsihHHA = 0;
		try
		{
			RPepiYQtGtKcNNmzSjbGvFSccpCK = Marshal.AllocHGlobal((int)P_0);
			if (RPepiYQtGtKcNNmzSjbGvFSccpCK == IntPtr.Zero)
			{
				throw new Exception("Could not allocate native memory.");
			}
		}
		catch
		{
			throw;
		}
	}

	public IntPtr Allocate(uint bytes, IntPtr ptrToData)
	{
		if (XmcGAZhuDFndCWYMSxrxuovQWWFnA)
		{
			return IntPtr.Zero;
		}
		if (bytes == 0)
		{
			return IntPtr.Zero;
		}
		if (bytes > raGrHXWmAFQeDJSheISsHaRRjcCt)
		{
			return IntPtr.Zero;
		}
		if (XElZCpTUQRUNuYTaVBtlfnFsihHHA + bytes >= raGrHXWmAFQeDJSheISsHaRRjcCt)
		{
			XElZCpTUQRUNuYTaVBtlfnFsihHHA = 0;
		}
		IntPtr intPtr = new IntPtr(RPepiYQtGtKcNNmzSjbGvFSccpCK.ToInt64() + XElZCpTUQRUNuYTaVBtlfnFsihHHA);
		if (ptrToData != IntPtr.Zero)
		{
			NativeTools.CopyMemory(ptrToData, intPtr, 0, 0, (int)bytes);
		}
		XElZCpTUQRUNuYTaVBtlfnFsihHHA += (int)bytes;
		return intPtr;
	}

	public IntPtr Allocate(uint bytes)
	{
		return Allocate(bytes, IntPtr.Zero);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	~NativeMemoryBlock()
	{
		Dispose(disposing: false);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!XmcGAZhuDFndCWYMSxrxuovQWWFnA)
		{
			XmcGAZhuDFndCWYMSxrxuovQWWFnA = true;
			if (RPepiYQtGtKcNNmzSjbGvFSccpCK != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(RPepiYQtGtKcNNmzSjbGvFSccpCK);
				RPepiYQtGtKcNNmzSjbGvFSccpCK = IntPtr.Zero;
			}
		}
	}
}
