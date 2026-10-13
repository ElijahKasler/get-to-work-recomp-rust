using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

[UnmanagedFunctionPointer(CallingConvention.StdCall)]
internal delegate int XAsyncProviderInterop(XAsyncOp op, XAsyncProviderData data);
