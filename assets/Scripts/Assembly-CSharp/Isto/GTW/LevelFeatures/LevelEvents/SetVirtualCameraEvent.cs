using Isto.GTW.Camera;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class SetVirtualCameraEvent : LevelEvent
{
	[SerializeField]
	private FixedVirtualCamera _virtualCamera;

	[Space]
	[SerializeField]
	private bool _activate = true;

	protected FixedVirtualCameraController _fixedVirtualCameraController;

	[Inject]
	private void Inject(FixedVirtualCameraController fixedVirtualCameraController)
	{
		_fixedVirtualCameraController = fixedVirtualCameraController;
	}

	public override void TriggerEvent(bool initialization = false)
	{
		if (!initialization)
		{
			if (_activate)
			{
				_fixedVirtualCameraController.ActivateVirtualCamera(_virtualCamera);
			}
			else
			{
				_fixedVirtualCameraController.DeactivateVirtualCamera(_virtualCamera);
			}
		}
	}
}
