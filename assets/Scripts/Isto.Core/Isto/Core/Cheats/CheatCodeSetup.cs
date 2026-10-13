using System;
using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "Scriptables/New Cheats Data", menuName = "Scriptables/New Cheats Data")]
public class CheatCodeSetup : ScriptableObject
{
	public enum CheatEffect
	{
		DoNothing = 0,
		ToggleCatrioTheme = 1
	}

	[Serializable]
	public class KeyboardCheatData
	{
		public string internalName;

		public CheatEffect effect;

		public List<KeyCode> buttonPresses;
	}

	[Multiline]
	public string comment = "This is for defining cheat codes a user can enter during the title screen.";

	public List<KeyboardCheatData> keyboardCheats;
}
