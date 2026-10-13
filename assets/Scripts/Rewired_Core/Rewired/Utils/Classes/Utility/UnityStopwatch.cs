using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility;

[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal sealed class UnityStopwatch : StopwatchBase
{
	private class jfwgEajEZFldXcDSkgufNYTDevJeD
	{
		public const long EOqfTlunrWHKoufLOlColyefSfWq = 10000000L;

		private double XPvoTPROJkAYcatUxUrZRsBgcvDo;

		private bool HpCecdOfOPLuoeSVtOgskJxmXyHR;

		private double bpqzkcstEleuOfeUbmSvdvbvuNQc;

		private double dneAqwQIcqlXbEvYfSUxdjYJSiuA;

		public bool fCLRPEJSRDWlWuTioUxtynZJaqcn => leojtYdQzucmXZIYLBQmwIipdpHG();

		public double FijtxGWgWrtUmGpgPHGCFfHBVbzx => vnuaCzbEMeqPoGepPoolXnwNMAvsA();

		public bool leojtYdQzucmXZIYLBQmwIipdpHG()
		{
			return HpCecdOfOPLuoeSVtOgskJxmXyHR;
		}

		public double vnuaCzbEMeqPoGepPoolXnwNMAvsA()
		{
			if (!HpCecdOfOPLuoeSVtOgskJxmXyHR)
			{
				return dneAqwQIcqlXbEvYfSUxdjYJSiuA;
			}
			return (double)Time.realtimeSinceStartup - bpqzkcstEleuOfeUbmSvdvbvuNQc;
		}

		public void pbbGpEuLPlLziKtOVGPWUNPcxkpV()
		{
			XPvoTPROJkAYcatUxUrZRsBgcvDo = Time.realtimeSinceStartup;
		}

		public void eVbRiuNrLnpyjvOpgOldkRUEJVLo()
		{
			if (!HpCecdOfOPLuoeSVtOgskJxmXyHR)
			{
				HpCecdOfOPLuoeSVtOgskJxmXyHR = true;
				bpqzkcstEleuOfeUbmSvdvbvuNQc = XPvoTPROJkAYcatUxUrZRsBgcvDo;
			}
		}

		public void btWLgdncrboqDxeROYiZfqKtmjEw()
		{
			if (HpCecdOfOPLuoeSVtOgskJxmXyHR)
			{
				HpCecdOfOPLuoeSVtOgskJxmXyHR = false;
				dneAqwQIcqlXbEvYfSUxdjYJSiuA += XPvoTPROJkAYcatUxUrZRsBgcvDo - bpqzkcstEleuOfeUbmSvdvbvuNQc;
			}
		}

		public void QuFdJngKfTSXoatqTzYbPwOQRIutA()
		{
			bpqzkcstEleuOfeUbmSvdvbvuNQc = 0.0;
			dneAqwQIcqlXbEvYfSUxdjYJSiuA = 0.0;
			bool hpCecdOfOPLuoeSVtOgskJxmXyHR = HpCecdOfOPLuoeSVtOgskJxmXyHR;
			HpCecdOfOPLuoeSVtOgskJxmXyHR = false;
			if (hpCecdOfOPLuoeSVtOgskJxmXyHR)
			{
				eVbRiuNrLnpyjvOpgOldkRUEJVLo();
			}
		}
	}

	private const long ahecyEDZzQUBSplMNBopcGZOelCK = 10000000L;

	private static UnityStopwatch BGxAkKAHCfIrGMQQfcSKlDTeRqmGA;

	private readonly jfwgEajEZFldXcDSkgufNYTDevJeD dVJjSZnKVorkryZFyERcPSnQDvdy;

	private readonly bool QAvSVqBQwtndNoFRhiNhjeCgNPvu;

	private double zVeBgUeikSSsoFZUZhGRWQiHqksG;

	public static UnityStopwatch Global => BGxAkKAHCfIrGMQQfcSKlDTeRqmGA ?? (BGxAkKAHCfIrGMQQfcSKlDTeRqmGA = new UnityStopwatch(true));

	public static long frequency => 10000000L;

	double StopwatchBase.offsetSeconds
	{
		get
		{
			return get_offsetSeconds();
		}
		set
		{
			set_offsetSeconds(value);
		}
	}

	long StopwatchBase.offsetTicks
	{
		get
		{
			return get_offsetTicks();
		}
		set
		{
			set_offsetTicks(value);
		}
	}

	double StopwatchBase.elapsedSeconds => get_elapsedSeconds();

	double StopwatchBase.elapsedSecondsRaw => get_elapsedSecondsRaw();

	long StopwatchBase.elapsedMilliseconds => get_elapsedMilliseconds();

	long StopwatchBase.elapsedMillisecondsRaw => get_elapsedMillisecondsRaw();

	long StopwatchBase.elapsedTicks => get_elapsedTicks();

	long StopwatchBase.elapsedTicksRaw => get_elapsedTicksRaw();

	bool StopwatchBase.isRunning => get_isRunning();

	public static UnityStopwatch StartNew()
	{
		UnityStopwatch unityStopwatch = new UnityStopwatch(false);
		unityStopwatch.Start();
		return unityStopwatch;
	}

	public static long ConvertTo100NSTicks(long ticks)
	{
		return ticks;
	}

	public double get_offsetSeconds()
	{
		return zVeBgUeikSSsoFZUZhGRWQiHqksG;
	}

	public void set_offsetSeconds(double value)
	{
		zVeBgUeikSSsoFZUZhGRWQiHqksG = value;
	}

	public long get_offsetTicks()
	{
		return (long)(zVeBgUeikSSsoFZUZhGRWQiHqksG * 10000000.0);
	}

	public void set_offsetTicks(long value)
	{
		zVeBgUeikSSsoFZUZhGRWQiHqksG = (double)value / 10000000.0;
	}

	public double get_elapsedSeconds()
	{
		return dVJjSZnKVorkryZFyERcPSnQDvdy.vnuaCzbEMeqPoGepPoolXnwNMAvsA() + offsetSeconds;
	}

	public double get_elapsedSecondsRaw()
	{
		return dVJjSZnKVorkryZFyERcPSnQDvdy.vnuaCzbEMeqPoGepPoolXnwNMAvsA();
	}

	public long get_elapsedMilliseconds()
	{
		return (long)((dVJjSZnKVorkryZFyERcPSnQDvdy.vnuaCzbEMeqPoGepPoolXnwNMAvsA() + zVeBgUeikSSsoFZUZhGRWQiHqksG) * 1000.0);
	}

	public long get_elapsedMillisecondsRaw()
	{
		return (long)(dVJjSZnKVorkryZFyERcPSnQDvdy.vnuaCzbEMeqPoGepPoolXnwNMAvsA() * 1000.0);
	}

	public long get_elapsedTicks()
	{
		return (long)(elapsedSeconds * 10000000.0);
	}

	public long get_elapsedTicksRaw()
	{
		return (long)(elapsedSecondsRaw * 10000000.0);
	}

	public bool get_isRunning()
	{
		return dVJjSZnKVorkryZFyERcPSnQDvdy.leojtYdQzucmXZIYLBQmwIipdpHG();
	}

	public UnityStopwatch()
		: this(false)
	{
	}

	private UnityStopwatch(bool P_0)
	{
		dVJjSZnKVorkryZFyERcPSnQDvdy = new jfwgEajEZFldXcDSkgufNYTDevJeD();
		SKdbCltNYDNYAeIsgwKypUdBMAtl();
		if (P_0)
		{
			Start();
		}
		QAvSVqBQwtndNoFRhiNhjeCgNPvu = P_0;
	}

	~UnityStopwatch()
	{
		rEgenptxxuUMOMySFRpAfowIkBCb();
	}

	public override void Stop()
	{
		if (QAvSVqBQwtndNoFRhiNhjeCgNPvu)
		{
			throw new Exception("The Global Stopwatch cannot be stopped.");
		}
		dVJjSZnKVorkryZFyERcPSnQDvdy.btWLgdncrboqDxeROYiZfqKtmjEw();
	}

	public override void Start()
	{
		if (!QAvSVqBQwtndNoFRhiNhjeCgNPvu)
		{
			dVJjSZnKVorkryZFyERcPSnQDvdy.eVbRiuNrLnpyjvOpgOldkRUEJVLo();
		}
	}

	public override void Reset()
	{
		if (QAvSVqBQwtndNoFRhiNhjeCgNPvu)
		{
			throw new Exception("The Global Stopwatch cannot be reset.");
		}
		dVJjSZnKVorkryZFyERcPSnQDvdy.QuFdJngKfTSXoatqTzYbPwOQRIutA();
	}

	private void SKdbCltNYDNYAeIsgwKypUdBMAtl()
	{
		rEgenptxxuUMOMySFRpAfowIkBCb();
		ReInput.BeforeTimeManagerUpdateEvent += pcJusYVNGoZQIxInmJldZaBECTux;
	}

	private void rEgenptxxuUMOMySFRpAfowIkBCb()
	{
		ReInput.BeforeTimeManagerUpdateEvent -= pcJusYVNGoZQIxInmJldZaBECTux;
	}

	private void pcJusYVNGoZQIxInmJldZaBECTux(UpdateLoopType P_0)
	{
		dVJjSZnKVorkryZFyERcPSnQDvdy.pbbGpEuLPlLziKtOVGPWUNPcxkpV();
	}
}
