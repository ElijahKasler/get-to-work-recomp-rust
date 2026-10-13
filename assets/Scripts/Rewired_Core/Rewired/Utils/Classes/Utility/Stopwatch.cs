using System;
using System.Diagnostics;

namespace Rewired.Utils.Classes.Utility;

[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal sealed class Stopwatch : StopwatchBase
{
	private const long CMCdzXBIxSXFWwXJqKrYhZXaQgTs = 10000000L;

	public static readonly Stopwatch Global;

	private static long tzbyoOEufZDgTrGBnhCneWMkBdGTA;

	private System.Diagnostics.Stopwatch VNcEliQxviknvOHBczsauOVQIiDW;

	private long fhRbtDdDXxXHyYpsVbJEKCJRlAaA;

	public static long frequency => tzbyoOEufZDgTrGBnhCneWMkBdGTA;

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

	static Stopwatch()
	{
		tzbyoOEufZDgTrGBnhCneWMkBdGTA = System.Diagnostics.Stopwatch.Frequency;
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		Global = stopwatch;
	}

	public static Stopwatch StartNew()
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		return stopwatch;
	}

	public static long ConvertTo100NSTicks(long ticks)
	{
		if (tzbyoOEufZDgTrGBnhCneWMkBdGTA == 10000000)
		{
			return ticks;
		}
		return 10000000 / tzbyoOEufZDgTrGBnhCneWMkBdGTA;
	}

	public double get_offsetSeconds()
	{
		return (double)fhRbtDdDXxXHyYpsVbJEKCJRlAaA / (double)tzbyoOEufZDgTrGBnhCneWMkBdGTA;
	}

	public void set_offsetSeconds(double value)
	{
		fhRbtDdDXxXHyYpsVbJEKCJRlAaA = (long)(value * (double)tzbyoOEufZDgTrGBnhCneWMkBdGTA);
	}

	public long get_offsetTicks()
	{
		return fhRbtDdDXxXHyYpsVbJEKCJRlAaA;
	}

	public void set_offsetTicks(long value)
	{
		fhRbtDdDXxXHyYpsVbJEKCJRlAaA = value;
	}

	public double get_elapsedSeconds()
	{
		return (double)(VNcEliQxviknvOHBczsauOVQIiDW.ElapsedTicks + offsetTicks) / (double)tzbyoOEufZDgTrGBnhCneWMkBdGTA;
	}

	public double get_elapsedSecondsRaw()
	{
		return (double)VNcEliQxviknvOHBczsauOVQIiDW.ElapsedTicks / (double)tzbyoOEufZDgTrGBnhCneWMkBdGTA;
	}

	public long get_elapsedMilliseconds()
	{
		return (long)((double)(VNcEliQxviknvOHBczsauOVQIiDW.ElapsedTicks + offsetTicks) / (double)tzbyoOEufZDgTrGBnhCneWMkBdGTA * 1000.0);
	}

	public long get_elapsedMillisecondsRaw()
	{
		return VNcEliQxviknvOHBczsauOVQIiDW.ElapsedMilliseconds;
	}

	public long get_elapsedTicks()
	{
		return VNcEliQxviknvOHBczsauOVQIiDW.ElapsedTicks + fhRbtDdDXxXHyYpsVbJEKCJRlAaA;
	}

	public long get_elapsedTicksRaw()
	{
		return VNcEliQxviknvOHBczsauOVQIiDW.ElapsedTicks;
	}

	public bool get_isRunning()
	{
		return VNcEliQxviknvOHBczsauOVQIiDW.IsRunning;
	}

	public Stopwatch()
	{
		VNcEliQxviknvOHBczsauOVQIiDW = new System.Diagnostics.Stopwatch();
	}

	public override void Stop()
	{
		if (this == Global)
		{
			throw new Exception("The Global Stopwatch cannot be stopped.");
		}
		VNcEliQxviknvOHBczsauOVQIiDW.Stop();
	}

	public override void Start()
	{
		if (this != Global)
		{
			VNcEliQxviknvOHBczsauOVQIiDW.Start();
		}
	}

	public override void Reset()
	{
		if (this == Global)
		{
			throw new Exception("The Global Stopwatch cannot be reset.");
		}
		VNcEliQxviknvOHBczsauOVQIiDW.Reset();
	}
}
