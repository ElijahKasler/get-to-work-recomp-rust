using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime;

public struct XGameRuntimeOptions
{
	public XGameRuntimeGameConfigSource gameConfigSource;

	[MarshalAs(UnmanagedType.LPStr)]
	public string gameConfig;
}
