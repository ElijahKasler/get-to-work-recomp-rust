using System;

namespace UnityEngine.ProBuilder;

[Flags]
public enum MeshArrays
{
	Position = 1,
	Texture0 = 2,
	Texture1 = 4,
	Lightmap = Texture1,
	Texture2 = 8,
	Texture3 = 0x10,
	Color = 0x20,
	Normal = 0x40,
	Tangent = 0x80,
	All = Position | Texture0 | Texture1 | Texture2 | Texture3 | Color | Normal | Tangent
}
