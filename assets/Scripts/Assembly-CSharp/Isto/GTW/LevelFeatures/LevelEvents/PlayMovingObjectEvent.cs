using UnityEngine;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class PlayMovingObjectEvent : LevelEvent
{
	[SerializeField]
	private MovingObject _movingObject;

	[SerializeField]
	private bool _play = true;

	public override void TriggerEvent(bool initialization = false)
	{
		if (_play)
		{
			_movingObject.Play();
		}
		else
		{
			_movingObject.Stop();
		}
	}
}
