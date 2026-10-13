using System.Collections.Generic;
using Isto.Core.Game;
using UnityEngine;
using Zenject;

namespace Isto.Core.Configuration;

public class PlatformDependent : MonoBehaviour
{
	public List<RuntimePlatform> compatiblePlatforms;

	[Header("Testing utilities")]
	[Tooltip("Incompatible object will destroy itself at injection stage as if current game mode was not in compatible list")]
	public bool forceIncompatible;

	[Inject]
	public void Inject(GameState gameState)
	{
		if (!forceIncompatible && (compatiblePlatforms == null || compatiblePlatforms.Count == 0))
		{
			Debug.LogWarning("Platform Dependent object \"" + base.gameObject.name + "\" exists by default because compatiblePlatforms is empty", this);
		}
		else if (forceIncompatible || IsCompatibleWithCurrentPlatform())
		{
			if (forceIncompatible)
			{
				Debug.LogWarning("Platform Dependent object \"" + base.gameObject.name + "\" forced to not exist");
			}
			Object.Destroy(base.gameObject);
		}
	}

	private bool IsCompatibleWithCurrentPlatform()
	{
		bool result = true;
		if (forceIncompatible)
		{
			return result;
		}
		RuntimePlatform platform = Application.platform;
		for (int i = 0; i < compatiblePlatforms.Count; i++)
		{
			RuntimePlatform runtimePlatform = compatiblePlatforms[i];
			if (platform == runtimePlatform)
			{
				result = false;
				break;
			}
		}
		return result;
	}
}
