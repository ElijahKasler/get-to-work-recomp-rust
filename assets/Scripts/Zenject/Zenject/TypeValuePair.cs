using System;
using System.Diagnostics;

namespace Zenject;

[DebuggerStepThrough]
public class TypeValuePair
{
	public Type Type;

	public object Value;

	public TypeValuePair(Type type, object value)
	{
		Type = type;
		Value = value;
	}
}
