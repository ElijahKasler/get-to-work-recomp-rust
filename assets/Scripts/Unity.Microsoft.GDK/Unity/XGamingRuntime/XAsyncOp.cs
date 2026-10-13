namespace Unity.XGamingRuntime;

public enum XAsyncOp : uint
{
	Begin = 0u,
	DoWork = 1u,
	GetResult = 2u,
	Cancel = 3u,
	Cleanup = 4u
}
