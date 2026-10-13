using System;
using I2.Loc;
using Isto.Core.Skins;

namespace Isto.Core.Themes;

[Serializable]
public class ThemeDefinition
{
	public string internalName;

	public LocalizedString themeNameKey;

	public ThemeSkinSet skinSet;
}
