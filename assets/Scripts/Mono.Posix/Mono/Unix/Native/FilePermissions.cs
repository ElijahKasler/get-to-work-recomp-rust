using System;

namespace Mono.Unix.Native;

[Flags]
[Map]
[CLSCompliant(false)]
public enum FilePermissions : uint
{
	S_ISUID = 0x800u,
	S_ISGID = 0x400u,
	S_ISVTX = 0x200u,
	S_IRUSR = 0x100u,
	S_IWUSR = 0x80u,
	S_IXUSR = 0x40u,
	S_IRGRP = 0x20u,
	S_IWGRP = 0x10u,
	S_IXGRP = 8u,
	S_IROTH = 4u,
	S_IWOTH = 2u,
	S_IXOTH = 1u,
	S_IRWXG = S_IRGRP | S_IWGRP | S_IXGRP,
	S_IRWXU = S_IRUSR | S_IWUSR | S_IXUSR,
	S_IRWXO = S_IROTH | S_IWOTH | S_IXOTH,
	ACCESSPERMS = S_IRWXG | S_IRWXU | S_IRWXO,
	ALLPERMS = ACCESSPERMS | S_ISUID | S_ISGID | S_ISVTX,
	DEFFILEMODE = 0x1B6u,
	S_IFMT = 0xF000u,
	[Map(SuppressFlags = "S_IFMT")]
	S_IFDIR = 0x4000u,
	[Map(SuppressFlags = "S_IFMT")]
	S_IFCHR = 0x2000u,
	[Map(SuppressFlags = "S_IFMT")]
	S_IFBLK = 0x6000u,
	[Map(SuppressFlags = "S_IFMT")]
	S_IFREG = 0x8000u,
	[Map(SuppressFlags = "S_IFMT")]
	S_IFIFO = 0x1000u,
	[Map(SuppressFlags = "S_IFMT")]
	S_IFLNK = 0xA000u,
	[Map(SuppressFlags = "S_IFMT")]
	S_IFSOCK = 0xC000u
}
