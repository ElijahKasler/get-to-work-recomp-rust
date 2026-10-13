using UnityEngine;
using Zenject;

namespace Isto.Core.Inputs;

public class ControlEventOnEnable : MonoBehaviour
{
	public UserActions action;

	public bool setPosition;

	[Tooltip("If set, will disable the component after a couple of frames")]
	public bool autoDisable;

	private ScriptedControls _controls;

	private int _frameCounter;

	[Inject]
	public void Inject(IControls controls)
	{
		_controls = controls as ScriptedControls;
	}

	public void OnEnable()
	{
		_controls.SetNextAction(action);
		if (setPosition)
		{
			_controls.mouseGroundPosition = base.transform.position;
		}
		_frameCounter = 0;
	}

	public void Update()
	{
		if (autoDisable)
		{
			_frameCounter++;
			if (_frameCounter > 2)
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}

	public void OnDisable()
	{
		_controls.SetNextAction(UserActions.NONE);
	}
}
