using Isto.Core;
using Isto.GTW.Managers;
using Isto.GTW.Player;
using Isto.GTW.Tools;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures;

public class LevelFallDialogueSystem : MonoBehaviour
{
	[SerializeField]
	private LevelEvent _triggerEvent;

	[Space]
	[SerializeField]
	[Range(0f, 100f)]
	private int _minFloorFall = 2;

	[Space]
	[SerializeField]
	protected string _id = "UNIQUE_ID";

	private static int FALLS_BEFORE_GIVE_UP_EXPERIENCE = 7;

	private int _currentFloor;

	private int _previousFloor;

	private LevelVariables _levelVariables;

	private PlayerController _pcontrol;

	private string PreviousFloorId => _id + "_PreviousFloor";

	private string CurrentFloorId => _id + "_CurrentFloor";

	[Inject]
	public void Inject(LevelVariables levelVariables, PlayerController pcontrol)
	{
		_levelVariables = levelVariables;
		_pcontrol = pcontrol;
	}

	protected virtual void Reset()
	{
		_id = GTWExtensions.RandomString(10);
		SetDirty();
	}

	private void Start()
	{
		_previousFloor = _levelVariables.GetInt(PreviousFloorId);
		_currentFloor = _levelVariables.GetInt(CurrentFloorId);
	}

	public void SetCurrentFloor(int floor)
	{
		if (SetFloor(floor))
		{
			TryPlayTrigger();
		}
	}

	public void SetCurrentFloorSilent(int floor)
	{
		SetFloor(floor);
	}

	protected void SetDirty()
	{
	}

	private bool SetFloor(int floor)
	{
		if (_currentFloor == floor)
		{
			return false;
		}
		Debug.Log("Setting current floor: " + floor);
		_previousFloor = _levelVariables.GetInt(PreviousFloorId);
		_currentFloor = _levelVariables.GetInt(CurrentFloorId);
		_previousFloor = _currentFloor;
		_currentFloor = floor;
		_levelVariables.SetInt(PreviousFloorId, _previousFloor);
		_levelVariables.SetInt(CurrentFloorId, _currentFloor);
		return true;
	}

	private void TryPlayTrigger()
	{
		if (_previousFloor - _currentFloor >= Mathf.Abs(_minFloorFall))
		{
			string id = "asdfghjkl";
			int num = _levelVariables.GetInt(id);
			num++;
			if (num < FALLS_BEFORE_GIVE_UP_EXPERIENCE || _pcontrol.ragDollAbilityAvailable)
			{
				_triggerEvent.TriggerEvent();
				_triggerEvent.SetTriggered(triggered: true);
			}
			else
			{
				StarGiveUpExperience();
			}
			_levelVariables.SetInt(id, num);
		}
	}

	[ContextMenu("TestGiveUpExperienceNow")]
	private void StarGiveUpExperience()
	{
		Events.RaiseEvent(GTWEvents.GIVE_UP_DIALOGUE_START);
		Invoke("GiveUpButtonExperienceOver", 25f);
	}

	private void GiveUpButtonExperienceOver()
	{
		Events.RaiseEvent(GTWEvents.GIVE_UP_ALLOWED);
	}
}
