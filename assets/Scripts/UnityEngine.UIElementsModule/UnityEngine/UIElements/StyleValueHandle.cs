using System;
using UnityEngine.Bindings;

namespace UnityEngine.UIElements;

[Serializable]
[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
internal struct StyleValueHandle
{
	[SerializeField]
	private StyleValueType m_ValueType;

	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	[SerializeField]
	internal int valueIndex;

	public StyleValueType valueType
	{
		get
		{
			return m_ValueType;
		}
		internal set
		{
			m_ValueType = value;
		}
	}

	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal StyleValueHandle(int valueIndex, StyleValueType valueType)
	{
		this.valueIndex = valueIndex;
		m_ValueType = valueType;
	}
}
