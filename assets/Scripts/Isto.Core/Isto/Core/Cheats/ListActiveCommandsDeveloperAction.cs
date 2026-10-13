using Isto.Core.UI;
using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New List Active Commands Action", menuName = "Scriptables/Dev Mode Actions/List Active Commands Action")]
public class ListActiveCommandsDeveloperAction : CheatAction
{
	public override void Activate(params object[] args)
	{
		Object.FindObjectOfType<CheatMenuState>().ShowAllActiveCommands();
	}

	public override void Deactivate()
	{
	}

	public override void OnUpdate()
	{
	}
}
