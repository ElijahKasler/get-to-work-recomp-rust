using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal struct StructNestedBlittable
{
	public StructInt field;
}
