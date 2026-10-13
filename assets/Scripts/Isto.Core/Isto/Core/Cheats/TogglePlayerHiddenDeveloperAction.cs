using Isto.Core.Cameras;
using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New Toggle Player Hidden Action", menuName = "Scriptables/Dev Mode Actions/Toggle Player Hidden Action")]
public class TogglePlayerHiddenDeveloperAction : CheatAction
{
	private CameraController _camera;

	public override void Activate(params object[] args)
	{
		_camera = Object.FindObjectOfType<CameraController>();
		_camera.HideLayers(hide: true);
	}

	public override void Deactivate()
	{
		_camera.HideLayers(hide: false);
	}

	public override void OnUpdate()
	{
	}
}
