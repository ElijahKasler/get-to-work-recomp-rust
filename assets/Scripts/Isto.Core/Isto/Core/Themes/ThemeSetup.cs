using System;
using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Themes;

[CreateAssetMenu(fileName = "Scriptables/New Themes Data", menuName = "Scriptables/New Themes Data")]
public class ThemeSetup : ScriptableObject
{
	public List<ThemeDefinition> themes;

	public ThemeDefinition GetTheme(string targetName)
	{
		ThemeDefinition result = null;
		foreach (ThemeDefinition theme in themes)
		{
			if (theme.internalName.Equals(targetName, StringComparison.OrdinalIgnoreCase))
			{
				result = theme;
				break;
			}
		}
		return result;
	}
}
