using System;

namespace Mono.Unix.Native;

[Map]
[CLSCompliant(false)]
public enum SeekFlags : short
{
	SEEK_SET = 0,
	SEEK_CUR = 1,
	SEEK_END = 2,
	L_SET = SEEK_SET,
	L_INCR = SEEK_CUR,
	L_XTND = SEEK_END
}
