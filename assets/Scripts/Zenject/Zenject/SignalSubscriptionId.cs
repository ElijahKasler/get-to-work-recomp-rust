using System;
using System.Diagnostics;

namespace Zenject;

[DebuggerStepThrough]
public struct SignalSubscriptionId(Type signalType, object callback) : IEquatable<SignalSubscriptionId>
{
	private Type _signalType = signalType;

	private object _callback = callback;

	public Type SignalType => _signalType;

	public object Callback => _callback;

	public override int GetHashCode()
	{
		return (17 * 29 + _signalType.GetHashCode()) * 29 + _callback.GetHashCode();
	}

	public override bool Equals(object that)
	{
		if (that is SignalSubscriptionId)
		{
			return Equals((SignalSubscriptionId)that);
		}
		return false;
	}

	public bool Equals(SignalSubscriptionId that)
	{
		if (object.Equals(SignalType, that.SignalType))
		{
			return object.Equals(Callback, that.Callback);
		}
		return false;
	}

	public static bool operator ==(SignalSubscriptionId left, SignalSubscriptionId right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(SignalSubscriptionId left, SignalSubscriptionId right)
	{
		return !left.Equals(right);
	}
}
