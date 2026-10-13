using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Animations;

[UsedByNativeCode]
[NativeType(CodegenOptions.Custom, "UnityEngine::Animation::MonoGenericBinding")]
public readonly struct GenericBinding
{
	private readonly uint m_Path;

	private readonly uint m_PropertyName;

	private readonly int m_ScriptInstanceID;

	private readonly int m_TypeID;

	private readonly byte m_CustomType;

	internal readonly Flags m_Flags;

	public bool isObjectReference => (m_Flags & Flags.kPPtr) == Flags.kPPtr;

	public bool isDiscrete => (m_Flags & (Flags)3) != 0;

	public bool isSerializeReference => (m_Flags & Flags.kSerializeReference) == Flags.kSerializeReference;

	public uint transformPathHash => m_Path;

	public uint propertyNameHash => m_PropertyName;

	public int scriptInstanceID => m_ScriptInstanceID;

	public int typeID => m_TypeID;

	public byte customTypeID => m_CustomType;
}
