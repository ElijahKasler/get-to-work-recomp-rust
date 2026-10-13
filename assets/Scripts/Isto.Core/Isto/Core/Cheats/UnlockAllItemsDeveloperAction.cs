using Isto.Core.Beings;
using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New Unlock All Items Action", menuName = "Scriptables/Dev Mode Actions/Unlock All Items Action")]
public class UnlockAllItemsDeveloperAction : CheatAction
{
	public override void Activate(params object[] args)
	{
		PlayerProgress playerProgress = Object.FindObjectOfType<PlayerProgress>();
		if (playerProgress != null)
		{
			playerProgress.unlockAll = true;
		}
	}

	public override void Deactivate()
	{
		PlayerProgress playerProgress = Object.FindObjectOfType<PlayerProgress>();
		if (playerProgress != null)
		{
			playerProgress.unlockAll = false;
		}
	}

	public override void OnUpdate()
	{
	}
}
