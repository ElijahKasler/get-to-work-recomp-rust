using Isto.Core;
using UnityEngine;

namespace Isto.GTW;

public class GTWInitialization : CoreInitialization
{
	protected override void InitializePlayerPrefs()
	{
		Debug.Log("PlayerPrefs initialized.");
	}
}
