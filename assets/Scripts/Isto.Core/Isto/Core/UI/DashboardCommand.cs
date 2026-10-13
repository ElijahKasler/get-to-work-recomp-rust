using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Isto.Core.UI;

public abstract class DashboardCommand : MonoBehaviour
{
	[Header("DashboardCommand Config")]
	[FormerlySerializedAs("Commands")]
	public List<UIConsole.DeveloperConsoleCommandEntry> ActivationCommands;

	public List<UIConsole.DeveloperConsoleCommandEntry> DeactivationCommands;

	protected CheatMenuState _console;

	protected virtual void Start()
	{
		_console = base.gameObject.GetComponentInParent<CheatMenuState>();
		if (_console == null)
		{
			Debug.LogError("DashboardCommand not setup properly in the DeveloperConsole prefab", this);
		}
	}

	protected virtual void OnEnable()
	{
	}

	protected virtual void OnDisable()
	{
	}

	protected virtual void OnDestroy()
	{
	}

	protected void ActivateCommand()
	{
		_console.Run(ActivationCommands);
	}

	protected void DeactivateCommand()
	{
		_console.Run(DeactivationCommands);
	}
}
