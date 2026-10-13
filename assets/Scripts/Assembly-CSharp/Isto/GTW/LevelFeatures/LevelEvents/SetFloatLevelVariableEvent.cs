using Isto.GTW.Managers;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class SetFloatLevelVariableEvent : LevelEvent
{
	[SerializeField]
	private string _id = "VARIABLE_ID";

	[SerializeField]
	private float _value;

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
			float num = _levelVariables.GetFloat(_id);
			_levelVariables.SetFloat(_id, num + _value);
			return;
		}
		if (_blockDecrement || _blockIncrement)
		{
			float num2 = _levelVariables.GetFloat(_id);
			if ((_blockDecrement && _value < num2) || (_blockIncrement && _value > num2))
			{
				return;
			}
		}
		_levelVariables.SetFloat(_id, _value);
	}
}
