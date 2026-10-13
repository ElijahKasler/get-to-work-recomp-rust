using UnityEngine;

namespace PixelCrushers;

public static class GameTime
{
	private static GameTimeMode s_mode;

	private static float s_manualTime;

	private static float s_manualDeltaTime;

	private static bool s_manualPaused;

	public static GameTimeMode mode
	{
		get
		{
			return s_mode;
		}
		set
		{
			s_mode = value;
		}
	}

	public static float time
	{
		get
		{
			return mode switch
			{
				GameTimeMode.Realtime => Time.realtimeSinceStartup, 
				GameTimeMode.Manual => s_manualTime, 
				_ => Time.time, 
			};
		}
		set
		{
			s_manualTime = value;
		}
	}

	public static float deltaTime
	{
		get
		{
			GameTimeMode gameTimeMode = mode;
			if ((uint)gameTimeMode <= 1u || gameTimeMode != GameTimeMode.Manual)
			{
				return Time.deltaTime;
			}
			return s_manualDeltaTime;
		}
		set
		{
			s_manualDeltaTime = value;
		}
	}

	public static float timeScale => Time.timeScale;

	public static bool isPaused
	{
		get
		{
			return mode switch
			{
				GameTimeMode.Realtime => false, 
				GameTimeMode.Manual => s_manualPaused, 
				_ => Mathf.Approximately(0f, Time.timeScale), 
			};
		}
		set
		{
			switch (mode)
			{
			default:
				Time.timeScale = ((!value) ? 1 : 0);
				break;
			case GameTimeMode.Manual:
				s_manualPaused = value;
				break;
			case GameTimeMode.Realtime:
				break;
			}
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void InitStaticVariables()
	{
		s_mode = GameTimeMode.UnityStandard;
		s_manualTime = 0f;
		s_manualDeltaTime = 0f;
		s_manualPaused = false;
	}
}
