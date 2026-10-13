using UnityEngine;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class LevelFallDialogueEvent : LevelEvent
{
	[SerializeField]
	private LevelFallDialogueSystem _levelFallDialogueSystem;

	[SerializeField]
	private int _floorLevel;

	[Space]
	[SerializeField]
	private bool _silent;

	public override void TriggerEvent(bool initialization = false)
	{
		if (!initialization)
		{
			if (_silent)
			{
				_levelFallDialogueSystem.SetCurrentFloorSilent(_floorLevel);
			}
			else
			{
				_levelFallDialogueSystem.SetCurrentFloor(_floorLevel);
			}
		}
	}
}
