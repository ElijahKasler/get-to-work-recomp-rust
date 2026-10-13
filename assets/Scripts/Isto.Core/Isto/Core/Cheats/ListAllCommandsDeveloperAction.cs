using Isto.Core.UI;
using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New List All Commands Action", menuName = "Scriptables/Dev Mode Actions/List All Commands Action")]
public class ListAllCommandsDeveloperAction : CheatAction
{
	public override void Activate(params object[] args)
	{
		Object.FindObjectOfType<UIConsole>().ShowAllAvailableCommands();
	}

	public override void Deactivate()
	{
	}

	public override void OnUpdate()
	{
	}
}
