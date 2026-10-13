using Isto.GTW.Managers;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class SetIntLevelVariableEvent : LevelEvent
{
	[SerializeField]
	private string _id = "VARIABLE_ID";

	[SerializeField]
	private int _value;

	[Space]
	[Tooltip("Add value field to the current variable value.")]
	[SerializeField]
	private bool _additive;

	[Tooltip("Prevent from setting variable to a new value lower value.")]
	[SerializeField]
	private bool _blockDecrement;

	[Tooltip("Prevent from setting variable to a new value higher value.")]
	[SerializeField]
	private bool _blockIncrement;

	private LevelVariables _levelVariables;

	[Inject]
	public void Inject(LevelVariables levelVariables)
	{
		_levelVariables = levelVariables;
	}

	public override void TriggerEvent(bool initialization = false)
	{
		if (_additive)
		{
			int num = _levelVariables.GetInt(_id);
			_levelVariables.SetInt(_id, num + _value);
			return;
		}
		if (_blockDecrement || _blockIncrement)
		{
			int num2 = _levelVariables.GetInt(_id);
			if ((_blockDecrement && _value < num2) || (_blockIncrement && _value > num2))
			{
				return;
			}
		}
		_levelVariables.SetInt(_id, _value);
	}
}
