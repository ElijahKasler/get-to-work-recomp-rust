using System;
using System.Runtime.CompilerServices;

internal struct rKYyUcUfCJwFJGpvQNEGlDDQhiDv
{
	private int QAsWJHyuGKhwVwaucWOWMOsmoxFR;

	private long ZBXegMecrFZGmKKukRjlAXemcpyV;

	private static readonly bool wPYcnRmcmJIVKhKrwuTtAefLGKnBb;

	public static readonly int qZzmLRqNhGrHMrGgASeKxmcddckkA;

	static rKYyUcUfCJwFJGpvQNEGlDDQhiDv()
	{
		wPYcnRmcmJIVKhKrwuTtAefLGKnBb = IntPtr.Size == 8;
		qZzmLRqNhGrHMrGgASeKxmcddckkA = (wPYcnRmcmJIVKhKrwuTtAefLGKnBb ? 8 : 4);
	}

	public static rKYyUcUfCJwFJGpvQNEGlDDQhiDv AJQfZFhmdjQdkuKagPuhAxvElCjBB(byte[] P_0, int P_1)
	{
		rKYyUcUfCJwFJGpvQNEGlDDQhiDv result = default;
		if (wPYcnRmcmJIVKhKrwuTtAefLGKnBb)
		{
			result.ZBXegMecrFZGmKKukRjlAXemcpyV = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.QAsWJHyuGKhwVwaucWOWMOsmoxFR = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static int VubxowtLIliwuFIskLFErhNNHHgGA(rKYyUcUfCJwFJGpvQNEGlDDQhiDv P_0)
	{
		if (wPYcnRmcmJIVKhKrwuTtAefLGKnBb)
		{
			return (int)P_0.ZBXegMecrFZGmKKukRjlAXemcpyV;
		}
		return P_0.QAsWJHyuGKhwVwaucWOWMOsmoxFR;
	}

	[SpecialName]
	public static long VubxowtLIliwuFIskLFErhNNHHgGA(rKYyUcUfCJwFJGpvQNEGlDDQhiDv P_0)
	{
		if (wPYcnRmcmJIVKhKrwuTtAefLGKnBb)
		{
			return P_0.ZBXegMecrFZGmKKukRjlAXemcpyV;
		}
		return P_0.QAsWJHyuGKhwVwaucWOWMOsmoxFR;
	}

	public string DToieRHIefllTEcmVddUOUsgWIoX()
	{
		if (wPYcnRmcmJIVKhKrwuTtAefLGKnBb)
		{
			return ZBXegMecrFZGmKKukRjlAXemcpyV.ToString();
		}
		return QAsWJHyuGKhwVwaucWOWMOsmoxFR.ToString();
	}
}
