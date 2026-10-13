using Isto.GTW.Audio;
using Isto.GTW.LevelFeatures;
using UnityEngine;

namespace Isto.GTW.LevelEvents.LevelEvents;

public class PickupAudioEvent : LevelEvent
{
	[Space]
	[Header("Sound Effect")]
	[SerializeField]
	private ObstacleAudioOneShot _obstacleAudioOneShot;

	public override void TriggerEvent(bool initialization = false)
	{
		_obstacleAudioOneShot.PlaySound();
	}
}
