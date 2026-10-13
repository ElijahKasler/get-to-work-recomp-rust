using Isto.Core.Cameras;
using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New Set Player Hidden Action", menuName = "Scriptables/Dev Mode Actions/Set Player Hidden Action")]
public class SetPlayerHiddenDeveloperAction : CheatAction
{
	private CameraController _camera;

	public override void Activate(params object[] args)
	{
		bool? flag = ArgToBool(args[0]);
		if (!flag.HasValue)
		{
			throw new UnityException("Argument error. Useage: SetPlayerHidden True");
		}
		_camera = Object.FindObjectOfType<CameraController>();
		_camera.HideLayers(flag.Value);
	}

	public override void Deactivate()
	{
	}

	public override void OnUpdate()
	{
	}

	public override bool TryAutoCompleteParameters(string[] inputs, out string output)
	{
		return TryAutoCompleteBoolean(inputs, out output);
	}
}
