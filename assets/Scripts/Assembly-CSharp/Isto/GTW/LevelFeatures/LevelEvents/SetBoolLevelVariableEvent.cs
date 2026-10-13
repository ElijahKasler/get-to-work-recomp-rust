using Isto.GTW.Managers;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class SetBoolLevelVariableEvent : LevelEvent
{
	[SerializeField]
	private string _id = "VARIABLE_ID";

	[SerializeField]
	private bool _value = true;

	[Space]
	[Tooltip("Ignore value field and toggle the current value of the level variable.")]
	[SerializeField]
	private bool _toggle;

	private LevelVariables _levelVariables;

	[Inject]
	public void Inject(LevelVariables levelVariables)
	{
		_levelVariables = levelVariables;
	}

	public override void TriggerEvent(bool initialization = false)
	{
		if (_toggle)
		{
			bool flag = _levelVariables.GetBool(_id);
			_levelVariables.SetBool(_id, !flag);
		}
		else
		{
			_levelVariables.SetBool(_id, _value);
		}
	}
}
