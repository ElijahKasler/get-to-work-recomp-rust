using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New CheatSettings", menuName = "Scriptables/New Cheat Settings")]
public class CheatSettings : ScriptableObject
{
	[Header("Global Setting - For Build Process")]
	[SerializeField]
	private bool _cheatsEnabled = true;

	[Header("Startup Commands")]
	public List<CheatAction> startUpActions;

	[Header("Possible Commands")]
	public List<CheatAction> playerCommands;

	[Header("Possible Debug-Only Commands")]
	public List<CheatAction> debugCommands;

	[Header("Possible KeyCode Commands")]
	public bool disableAllKeyCodeCommands = true;

	public List<CheatAction> keyCodeCommands;

	[Header("Garbage Collect Inducer")]
	public bool showForceGCTool;

	public bool CheatsEnabled
	{
		get
		{
			return _cheatsEnabled;
		}
		set
		{
			_cheatsEnabled = value;
		}
	}

	[Inject]
	private void Inject(DiContainer container)
	{
		foreach (CheatAction item in new List<CheatAction>().Union(startUpActions).Union(playerCommands).Union(debugCommands)
			.Union(keyCodeCommands)
			.ToList())
		{
			container.Inject(item);
		}
	}
}
