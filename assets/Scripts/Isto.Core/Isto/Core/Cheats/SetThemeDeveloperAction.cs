using System.Collections.Generic;
using System.Linq;
using Isto.Core.Skins;
using Isto.Core.Themes;
using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New Set Theme Action", menuName = "Scriptables/Dev Mode Actions/Set Theme Action")]
public class SetThemeDeveloperAction : CheatAction
{
	public ThemeSetup _themeSetup;

	public MasterSkinList _masterList;

	public override void Activate(params object[] args)
	{
		SetTheme((string)args[0]);
	}

	public override void Deactivate()
	{
	}

	public override void OnUpdate()
	{
	}

	public override bool TryAutoCompleteParameters(string[] inputs, out string output)
	{
		List<string> validOutputs = _themeSetup.themes.Select((ThemeDefinition x) => x.internalName).ToList();
		return TryAutoCompleteFromList(inputs, validOutputs, out output);
	}

	private void SetTheme(string themeName)
	{
		ThemeManager themeManager = Object.FindObjectOfType<ThemeManager>();
		if (themeManager == null)
		{
			throw new UnityException("SetThemeDeveloperAction could not find ThemeManager object in scene");
		}
		ThemeSetup themeSetup = Resources.Load<ThemeSetup>("Themes");
		if (themeSetup == null)
		{
			throw new UnityException("SetThemeDeveloperAction could not find ThemeSetup object at Resources/Themes");
		}
		ThemeDefinition theme = themeSetup.GetTheme(themeName);
		if (theme == null)
		{
			throw new UnityException("Argument error. No theme found with name \"" + themeName + "\". Useage example: SetTheme Normal");
		}
		themeManager.CurrentTheme = theme;
	}
}
