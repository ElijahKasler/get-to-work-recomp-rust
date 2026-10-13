using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New Clear Player Prefs Action", menuName = "Scriptables/Dev Mode Actions/Clear Player Prefs Action")]
public class ClearPlayerPrefsDeveloperAction : CheatAction
{
	public override void Activate(params object[] args)
	{
		PlayerPrefs.DeleteAll();
	}

	public override void Deactivate()
	{
	}

	public override void OnUpdate()
	{
	}
}
