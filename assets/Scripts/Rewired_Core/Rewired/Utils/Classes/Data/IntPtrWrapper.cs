using System;

namespace Rewired.Utils.Classes.Data;

[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal class IntPtrWrapper
{
	private IntPtr XAplvkWNljZVfWVjBBBTXEakWxff;

	public bool IsValid => XAplvkWNljZVfWVjBBBTXEakWxff != IntPtr.Zero;

	public IntPtrWrapper(IntPtr P_0)
	{
		XAplvkWNljZVfWVjBBBTXEakWxff = P_0;
	}

	public void Clear()
	{
		XAplvkWNljZVfWVjBBBTXEakWxff = IntPtr.Zero;
	}

	public static implicit operator IntPtr(IntPtrWrapper obj)
	{
		return obj?.XAplvkWNljZVfWVjBBBTXEakWxff ?? IntPtr.Zero;
	}
}
