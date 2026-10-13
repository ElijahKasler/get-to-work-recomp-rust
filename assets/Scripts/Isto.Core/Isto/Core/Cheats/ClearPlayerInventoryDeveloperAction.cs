using Isto.Core.Beings;
using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "Dev Mode - Clear Inventory", menuName = "Scriptables/Dev Mode Actions/Clear Player Inventory Action")]
public class ClearPlayerInventoryDeveloperAction : CheatAction
{
	private PlayerInventory _player;

	public override void Activate(params object[] args)
	{
		_player = Object.FindObjectOfType<PlayerInventory>();
		_player.RemoveAll();
	}

	public override void Deactivate()
	{
	}

	public override void OnUpdate()
	{
	}
}
