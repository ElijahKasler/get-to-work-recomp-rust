using System;

namespace Mono.Unix.Native;

[Flags]
[CLSCompliant(false)]
public enum MremapFlags : ulong
{
	MREMAP_MAYMOVE = 1uL
}
