using System;

namespace UnityEngine.Bindings;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
[VisibleToOtherModules]
internal class UnmarshalledAttribute : Attribute, IBindingsAttribute
{
}
