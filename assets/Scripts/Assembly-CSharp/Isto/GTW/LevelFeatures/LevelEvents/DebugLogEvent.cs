using UnityEngine;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class DebugLogEvent : LevelEvent
{
	private enum LogType
	{
		Log = 0,
		Warning = 1,
		Error = 2
	}

	[SerializeField]
	private string _message = "";

	[SerializeField]
	private LogType _logType;

	public override void TriggerEvent(bool initialization = false)
	{
		switch (_logType)
		{
		case LogType.Log:
			Debug.Log(_message);
			break;
		case LogType.Warning:
			Debug.LogWarning(_message);
			break;
		case LogType.Error:
			Debug.LogError(_message);
			break;
		}
	}
}
