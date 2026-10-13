using System;
using System.Runtime.InteropServices;

namespace Rewired;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal struct LowLevelInputEvent
{
	private const int YRtJqruRSQsQmUYRCVOhZMWJFanS = 4;

	private const int gbwFtYEPcXuyUgymOyrTvgiFkFTib = 8;

	private const int iqJyYQtjKKBdYxbrYqjhRISPYzlu = 12;

	public const int buttonsPerPage = 32;

	public const int bytesPerButtonPage = 4;

	private const int UnnqCikmpcEaoIzWnDDnDXvomfoP = 4;

	private const int UZDNRwPAwOVSzXtGIZGMcUXNdDxf = 4;

	public const int byteIndex_id = 0;

	public const int byteIndex_timestamp = 4;

	public const int byteIndex_elementsStart = 12;

	public IntPtr _buffer;

	private int ucAWxWxVLXNzfTrOrsfCvWHWDXpv;

	private int mmenMrONnmCxjgNECfqwSzuGrVnU;

	private int QUjepnZOivLiUmmRtkcGgHwYLlQm;

	private int ezTDgQPaIzBGoADZuvgYUUrKpjgfA;

	private int mriZDOGrNDWGLAkDydhDYUbWgMPgA;

	private int FtqvMFpvZwbONVdSRvblsqbdeGnN;

	public bool isValid => _buffer != IntPtr.Zero;

	public int buttonCount => mmenMrONnmCxjgNECfqwSzuGrVnU;

	public int axisCount => QUjepnZOivLiUmmRtkcGgHwYLlQm;

	public int byteIndex_axesStart => ezTDgQPaIzBGoADZuvgYUUrKpjgfA;

	public int byteIndex_buttonsStart => mriZDOGrNDWGLAkDydhDYUbWgMPgA;

	public int byteIndex_hatsStart => FtqvMFpvZwbONVdSRvblsqbdeGnN;

	public LowLevelInputEvent(IntPtr P_0, int P_1, int P_2, int P_3)
	{
		if (P_1 == 0 && P_2 == 0)
		{
			throw new ArgumentOutOfRangeException("No elements defined in event.");
		}
		_buffer = P_0;
		mmenMrONnmCxjgNECfqwSzuGrVnU = P_1;
		QUjepnZOivLiUmmRtkcGgHwYLlQm = P_2;
		mriZDOGrNDWGLAkDydhDYUbWgMPgA = 12;
		ezTDgQPaIzBGoADZuvgYUUrKpjgfA = mriZDOGrNDWGLAkDydhDYUbWgMPgA + ((P_1 > 0) ? (((P_1 - 1) / 32 + 1) * 4) : 0);
		FtqvMFpvZwbONVdSRvblsqbdeGnN = ezTDgQPaIzBGoADZuvgYUUrKpjgfA + P_2 * 4;
		ucAWxWxVLXNzfTrOrsfCvWHWDXpv = GetReportSize(P_1, P_2, P_3);
	}

	public void SetButtonsBitMask(int bitMask, int startButtonIndex)
	{
		if (ucAWxWxVLXNzfTrOrsfCvWHWDXpv > 0)
		{
			if (startButtonIndex % 32 != 0)
			{
				throw new Exception("startIndex must be divisible by 32.");
			}
			Marshal.WriteInt32(_buffer, mriZDOGrNDWGLAkDydhDYUbWgMPgA + startButtonIndex / 4, bitMask);
		}
	}

	public void SetAxisValue(int index, float value)
	{
		if (ucAWxWxVLXNzfTrOrsfCvWHWDXpv > 0)
		{
			Marshal.WriteInt32(_buffer, ezTDgQPaIzBGoADZuvgYUUrKpjgfA + index * 4, new IPeHgerMcJtOaatuZexOKgMGoFjb(value).jALnUeNueqUmWnwklAMZrntZzAyT);
		}
	}

	public void SetId(uint id)
	{
		if (ucAWxWxVLXNzfTrOrsfCvWHWDXpv > 0)
		{
			Marshal.WriteInt32(_buffer, 0, (int)id);
		}
	}

	public void SetTimestamp(double value)
	{
		if (ucAWxWxVLXNzfTrOrsfCvWHWDXpv > 0)
		{
			Marshal.WriteInt64(_buffer, 4, new BYTnaLCMufIiiBgUeKylbetoCpmy(value).hXHIZSCmFXocKqDRgnXQuHRDaAYX);
		}
	}

	public bool GetButtonValue(int index)
	{
		if (ucAWxWxVLXNzfTrOrsfCvWHWDXpv <= 0)
		{
			return false;
		}
		if (buttonCount == 0)
		{
			return false;
		}
		int num = index / 32;
		int num2 = (index - num * 32) / 8;
		int num3 = index % 8;
		return (Marshal.ReadByte(_buffer, mriZDOGrNDWGLAkDydhDYUbWgMPgA + num * 4 + num2) & (1 << num3)) != 0;
	}

	public int GetButtonsBitMask(int startButtonIndex)
	{
		if (ucAWxWxVLXNzfTrOrsfCvWHWDXpv <= 0)
		{
			return 0;
		}
		if (startButtonIndex % 32 != 0)
		{
			throw new Exception("startIndex must be divisible by 32.");
		}
		return Marshal.ReadInt32(_buffer, mriZDOGrNDWGLAkDydhDYUbWgMPgA + startButtonIndex / 4);
	}

	public float GetAxisValue(int index)
	{
		if (ucAWxWxVLXNzfTrOrsfCvWHWDXpv <= 0)
		{
			return 0f;
		}
		return new IPeHgerMcJtOaatuZexOKgMGoFjb(Marshal.ReadInt32(_buffer, ezTDgQPaIzBGoADZuvgYUUrKpjgfA + index * 4)).PfZEnyAjjUfALwYclfmfYcpOzmxT;
	}

	public uint GetId()
	{
		if (ucAWxWxVLXNzfTrOrsfCvWHWDXpv <= 0)
		{
			return 0u;
		}
		return (uint)Marshal.ReadInt32(_buffer, 0);
	}

	public double GetTimestamp()
	{
		if (ucAWxWxVLXNzfTrOrsfCvWHWDXpv <= 0)
		{
			return 0.0;
		}
		return new BYTnaLCMufIiiBgUeKylbetoCpmy(Marshal.ReadInt64(_buffer, 4)).sweSebioXhCQktozRldvlapwsyLG;
	}

	public static int GetReportSize(int buttonCount, int axisCount, int hatCount)
	{
		return 12 + ((buttonCount > 0) ? (((buttonCount - 1) / 32 + 1) * 4) : 0) + axisCount * 4 + hatCount * 4;
	}
}
