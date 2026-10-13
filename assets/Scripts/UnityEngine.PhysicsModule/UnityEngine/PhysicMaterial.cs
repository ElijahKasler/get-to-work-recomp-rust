using System;
using System.ComponentModel;

namespace UnityEngine;

[NativeClass(null)]
[Obsolete("PhysicMaterial has been renamed to PhysicsMaterial. Please use PhysicsMaterial instead. (UnityUpgradable) -> PhysicsMaterial", true)]
public class PhysicMaterial : Object
{
	public float bounciness { get; set; }

	public float dynamicFriction { get; set; }

	public float staticFriction { get; set; }

	public PhysicMaterialCombine frictionCombine { get; set; }

	public PhysicMaterialCombine bounceCombine { get; set; }

	[Obsolete("Use PhysicMaterial.bounciness instead (UnityUpgradable) -> bounciness")]
	public float bouncyness { get; set; }

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Anisotropic friction is no longer supported since Unity 5.0.", true)]
	public Vector3 frictionDirection2 { get; set; }

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Anisotropic friction is no longer supported since Unity 5.0.", true)]
	public float dynamicFriction2 { get; set; }

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Anisotropic friction is no longer supported since Unity 5.0.", true)]
	public float staticFriction2 { get; set; }

	[Obsolete("Anisotropic friction is no longer supported since Unity 5.0.", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Vector3 frictionDirection { get; set; }

	public PhysicMaterial()
	{
	}

	public PhysicMaterial(string name)
	{
	}
}
