using UnityEngine;

namespace Isto.Core.Skins;

[CreateAssetMenu(fileName = "New Theme Skin Set Definition", menuName = "Scriptables/Skins/Theme Skin Set Definition")]
public class ThemeSkinSet : ScriptableObject
{
	public string themeSetInternalName;

	public PlayerSkinSet player;

	public CreatureSkinSet miniDeer;

	public CreatureSkinSet pushback;

	public ItemSkinGroup itemGroup;
}
