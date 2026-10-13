using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New Cheat Command", menuName = "Scriptables/Cheats/New Command")]
public class CheatCommand : ScriptableObject
{
	[SerializeField]
	private string _commandStr;

	[SerializeField]
	private bool _closeConsoleWhenUsed = true;

	[SerializeField]
	private List<CheatAction> _actions;
}
