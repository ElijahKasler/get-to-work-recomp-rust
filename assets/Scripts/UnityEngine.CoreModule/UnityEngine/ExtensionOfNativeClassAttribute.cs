using System;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine;

[RequiredByNativeCode]
[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, Inherited = true)]
internal sealed class ExtensionOfNativeClassAttribute : Attribute
{
}
