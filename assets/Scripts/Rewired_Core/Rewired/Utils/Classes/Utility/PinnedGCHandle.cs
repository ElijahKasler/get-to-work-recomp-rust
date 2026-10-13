using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils.Classes.Utility;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal struct PinnedGCHandle(object P_0) : IDisposable
{
	private readonly GCHandle sollEPsCUKsrqmUrRUXlFiUgyISf = GCHandle.Alloc(P_0, GCHandleType.Pinned);

	public IntPtr Pointer
	{
		get
		{
			if (!sollEPsCUKsrqmUrRUXlFiUgyISf.IsAllocated)
			{
				return IntPtr.Zero;
			}
			return sollEPsCUKsrqmUrRUXlFiUgyISf.AddrOfPinnedObject();
		}
	}

	public void Dispose()
	{
		if (sollEPsCUKsrqmUrRUXlFiUgyISf.IsAllocated)
		{
			sollEPsCUKsrqmUrRUXlFiUgyISf.Free();
		}
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	public static implicit operator IntPtr(PinnedGCHandle handle)
	{
		return handle.Pointer;
	}
}
