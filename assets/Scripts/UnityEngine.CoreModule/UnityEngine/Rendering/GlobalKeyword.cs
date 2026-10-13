using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering;

[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
[NativeHeader("Runtime/Shaders/Keywords/KeywordSpaceScriptBindings.h")]
[UsedByNativeCode]
public readonly struct GlobalKeyword
{
	internal readonly string m_Name;

	internal readonly uint m_Index;

	public string name => m_Name;

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("ShaderScripting::GetGlobalKeywordCount")]
	private static extern uint GetGlobalKeywordCount();

	[FreeFunction("ShaderScripting::GetGlobalKeywordIndex")]
	private unsafe static uint GetGlobalKeywordIndex(string keyword)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(keyword, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = keyword;
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return GetGlobalKeywordIndex_Injected(ref managedSpanWrapper);
				}
			}
			return GetGlobalKeywordIndex_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[FreeFunction("ShaderScripting::CreateGlobalKeyword")]
	private unsafe static void CreateGlobalKeyword(string keyword)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(keyword, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = keyword;
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					CreateGlobalKeyword_Injected(ref managedSpanWrapper);
					return;
				}
			}
			CreateGlobalKeyword_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	public static GlobalKeyword Create(string name)
	{
		CreateGlobalKeyword(name);
		return new GlobalKeyword(name);
	}

	public GlobalKeyword(string name)
	{
		m_Name = name;
		m_Index = GetGlobalKeywordIndex(name);
		if (m_Index >= GetGlobalKeywordCount())
		{
			Debug.LogErrorFormat("Global keyword {0} doesn't exist.", name);
		}
	}

	public override string ToString()
	{
		return m_Name;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern uint GetGlobalKeywordIndex_Injected(ref ManagedSpanWrapper keyword);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CreateGlobalKeyword_Injected(ref ManagedSpanWrapper keyword);
}
