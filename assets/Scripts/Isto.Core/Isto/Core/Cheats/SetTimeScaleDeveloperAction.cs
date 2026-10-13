using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New Set Time Scale Action", menuName = "Scriptables/Dev Mode Actions/Set Time Scale Action")]
public class SetTimeScaleDeveloperAction : CheatAction
{
	public override void Activate(params object[] args)
	{
		if (float.TryParse(args[0].ToString(), out var result))
		{
			Time.timeScale = result;
		}
	}

	public override void Deactivate()
	{
		Time.timeScale = 1f;
	}

	public override void OnUpdate()
	{
	}
}
