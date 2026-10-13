using System;
using System.Diagnostics;

namespace Zenject;

[DebuggerStepThrough]
public class BindingId : IEquatable<BindingId>
{
	private Type _type;

	private object _identifier;

	public Type Type
	{
		get
		{
			return _type;
		}
		set
		{
			_type = value;
		}
	}

	public object Identifier
	{
		get
		{
			return _identifier;
		}
		set
		{
			_identifier = value;
		}
	}

	public BindingId()
	{
	}

	public BindingId(Type type, object identifier)
	{
		_type = type;
		_identifier = identifier;
	}

	public override int GetHashCode()
	{
		return (17 * 29 + _type.GetHashCode()) * 29 + ((_identifier != null) ? _identifier.GetHashCode() : 0);
	}

	public override bool Equals(object other)
	{
		if (other is BindingId)
		{
			return (BindingId)other == this;
		}
		return false;
	}

	public bool Equals(BindingId that)
	{
		return this == that;
	}

	public static bool operator ==(BindingId left, BindingId right)
	{
		if (left.Type == right.Type)
		{
			return object.Equals(left.Identifier, right.Identifier);
		}
		return false;
	}

	public static bool operator !=(BindingId left, BindingId right)
	{
		return !left.Equals(right);
	}
}
