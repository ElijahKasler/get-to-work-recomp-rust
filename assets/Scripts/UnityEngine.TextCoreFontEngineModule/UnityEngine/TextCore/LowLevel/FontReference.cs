using System.Diagnostics;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.TextCore.LowLevel;

[UsedByNativeCode]
[DebuggerDisplay("{familyName} - {styleName}")]
[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
internal struct FontReference
{
	public string familyName;

	public string styleName;

	public int faceIndex;

	public string filePath;
}
