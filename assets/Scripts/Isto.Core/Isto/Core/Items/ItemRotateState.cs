using System.Collections.Generic;
using Isto.Core.Inputs;
using Isto.Core.StateMachine;
using UnityEngine;

namespace Isto.Core.Items;

public class ItemRotateState : ItemPlaceState
{
	[Header("Direction Arrow")]
	public Transform arrowTransform;

	protected List<IDirectionalItem> _directionalScripts;

	protected override void Awake()
	{
		_directionalScripts = new List<IDirectionalItem>();
		_directionalScripts.AddRange(GetComponents<IDirectionalItem>());
		if (nextState == null)
		{
			Debug.LogError("No next state set in ItemRotateState component on:" + base.gameObject.name, base.gameObject);
		}
		base.Awake();
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		UpdateItemsUnderPosition();
		bool flag = AtValidDropPosition();
		if (_setMaterialState != null)
		{
			if (flag)
			{
				_setMaterialState.RestoreMaterialTint();
			}
			else
			{
				_setMaterialState.SetMaterialTint(_setMaterialState.invalidPlaceTint, _setMaterialState.invalidPlaceEmission);
			}
			_validPosition = flag;
		}
		ProcessInputsFromUser(flag);
		HandleRotationInput();
		return this;
	}

	protected void HandleRotationInput()
	{
		int num = 0;
		if (_controls.GetButtonDown(UserActions.ROTATELEFT))
		{
			num = -1;
		}
		else if (_controls.GetButtonDown(UserActions.ROTATERIGHT))
		{
			num = 1;
		}
		if (num != 0)
		{
			HandleRotation(num);
			_spamTimer = 0f;
		}
	}

	public virtual void HandleRotation(int direction)
	{
		if (_controller == null)
		{
			_controller = GetComponent<ItemPlacementController>();
		}
		if (arrowTransform != null)
		{
			arrowTransform.Rotate(Vector3.up, (float)direction * 90f, Space.World);
		}
		Vector3 snappedPosition = (Quaternion.AngleAxis((float)direction * 90f, Vector3.up) * _controller.Forward).GetSnappedPosition(1f);
		UpdateForwardInScripts(snappedPosition);
	}

	protected void UpdateForwardInScripts(Vector3 forward)
	{
		if (_directionalScripts == null)
		{
			_directionalScripts = new List<IDirectionalItem>();
			_directionalScripts.AddRange(GetComponents<IDirectionalItem>());
		}
		for (int i = 0; i < _directionalScripts.Count; i++)
		{
			_directionalScripts[i].SetForwardDirection(forward);
		}
	}
}
