using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[Flags]
[MovedFrom("Unity.GameCore")]
public enum XStoreProductKind : uint
{
	None = 0u,
	Consumable = 1u,
	Durable = 2u,
	Game = 4u,
	Pass = 8u,
	UnmanagedConsumable = 0x10u
}
