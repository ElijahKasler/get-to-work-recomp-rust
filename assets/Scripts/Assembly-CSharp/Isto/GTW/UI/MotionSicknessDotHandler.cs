using UnityEngine;

namespace Isto.GTW.UI;

public class MotionSicknessDotHandler : MonoBehaviour
{
	[SerializeField]
	private GameObject _motionSicknessDot;

	private void Update()
	{
		bool flag = PlayerPrefs.GetInt(GTWUISettingsGameplaySubState.MOTION_SICKNESS_DOT_PREFS_KEY, GTWUISettingsGameplaySubState.DEFAULT_MOTION_SICKNESS_DOT_BUTTON) == 1;
		if (flag != _motionSicknessDot.activeSelf)
		{
			_motionSicknessDot.SetActive(flag);
		}
	}
}
