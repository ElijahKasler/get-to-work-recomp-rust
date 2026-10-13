using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal struct StructIntPtrObjectDynamicArray
{
	public MyIntPtrObject[] field;
}
