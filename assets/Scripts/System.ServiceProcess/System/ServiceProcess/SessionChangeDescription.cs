namespace System.ServiceProcess;

public struct SessionChangeDescription
{
	private SessionChangeReason reason;

	private int id;

	public SessionChangeReason Reason => reason;

	public int SessionId => id;

	internal SessionChangeDescription(SessionChangeReason reason, int id)
	{
		this.reason = reason;
		this.id = id;
	}

	public static bool operator ==(SessionChangeDescription a, SessionChangeDescription b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(SessionChangeDescription a, SessionChangeDescription b)
	{
		return !a.Equals(b);
	}

	public override bool Equals(object obj)
	{
		if (!(obj is SessionChangeDescription))
		{
			return false;
		}
		return Equals((SessionChangeDescription)obj);
	}

	public bool Equals(SessionChangeDescription changeDescription)
	{
		if (reason == changeDescription.reason)
		{
			return id == changeDescription.id;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ((int)(reason ^ SessionChangeReason.SessionLogon) << 16) + id;
	}
}
