using Rewired;
using Rewired.Interfaces;
using Rewired.Platforms.Custom;
using UnityEngine;

internal class xzxZfgrWdxPfQfTLTIdNMADfgGuR : tLXHXtPkzoCxWTdhCCBPKJGccMByA, IUnifiedMouseSource
{
	Vector2 IUnifiedMouseSource.mousePosition => ((CustomPlatformUnifiedMouseSource)oGRItHPlzGEUEGrPQvSxGRRVzixMA).mousePosition;

	public xzxZfgrWdxPfQfTLTIdNMADfgGuR(CustomPlatformUnifiedMouseSource P_0)
		: base(P_0, UnityUnifiedMouseSource.CreateHardwareMap())
	{
	}
}
