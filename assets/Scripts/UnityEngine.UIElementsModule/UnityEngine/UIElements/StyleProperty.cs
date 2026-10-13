using System;
using UnityEngine.Bindings;

namespace UnityEngine.UIElements;

[Serializable]
[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
internal class StyleProperty
{
	[SerializeField]
	private string m_Name;

	[SerializeField]
	private int m_Line;

	[SerializeField]
	private StyleValueHandle[] m_Values;

	[NonSerialized]
	internal bool isCustomProperty;

	[NonSerialized]
	internal bool requireVariableResolve;

	public string name
	{
		get
		{
			return m_Name;
		}
		[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
		internal set
		{
			m_Name = value;
		}
	}

	public int line
	{
		get
		{
			return m_Line;
		}
		internal set
		{
			m_Line = value;
		}
	}

	public StyleValueHandle[] values
	{
		get
		{
			return m_Values;
		}
		[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
		internal set
		{
			m_Values = value;
		}
	}
}
