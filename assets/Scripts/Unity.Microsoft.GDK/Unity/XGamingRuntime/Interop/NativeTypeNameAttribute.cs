using System;
using System.Diagnostics;

namespace Unity.XGamingRuntime.Interop;

[Conditional("DEBUG")]
[AttributeUsage(AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = false, Inherited = true)]
internal sealed class NativeTypeNameAttribute : Attribute
{
	public string Name { get; private set; }

	public NativeTypeNameAttribute(string name)
	{
		Name = name;
	}
}
