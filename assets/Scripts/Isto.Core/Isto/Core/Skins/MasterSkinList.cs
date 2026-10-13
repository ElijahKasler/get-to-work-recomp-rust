using System.Linq;
using UnityEngine;

namespace Isto.Core.Skins;

[CreateAssetMenu(fileName = "MasterSkinList", menuName = "Scriptables/Skins/Master Skin List")]
public class MasterSkinList : ScriptableObject
{
	public ThemeSkinSet[] themeSets;

	public PlayerSkinSet[] playerSets;

	public CreatureSkinSet[] creatureSets;

	public PlayerSkinPart[] playerParts;

	public ItemSkinGroup[] itemGroups;

	public PlayerSkinSet GetPlayerSkinSet(string internalName)
	{
		if (playerSets.Length == 0)
		{
			return null;
		}
		return playerSets.First((PlayerSkinSet x) => x.skinSetInternalName == internalName);
	}

	public PlayerSkinPart GetPlayerHatSkin(string internalName)
	{
		if (playerParts.Length == 0)
		{
			return null;
		}
		return playerParts.First((PlayerSkinPart x) => x.type == PlayerSkinPart.SkinPartType.Hat && x.skinPartInternalName == internalName);
	}

	public PlayerSkinPart GetPlayerBodySkin(string internalName)
	{
		if (playerParts.Length == 0)
		{
			return null;
		}
		return playerParts.First((PlayerSkinPart x) => x.type == PlayerSkinPart.SkinPartType.Body && x.skinPartInternalName == internalName);
	}

	public CreatureSkinSet GetMiniDeerSkin(string internalName)
	{
		if (creatureSets.Length == 0)
		{
			return null;
		}
		return creatureSets.First((CreatureSkinSet x) => x.type == Identifier.IdentifierFlags.MiniDeer && x.skinSetInternalName == internalName);
	}

	public CreatureSkinSet GetPushbackSkin(string internalName)
	{
		if (creatureSets.Length == 0)
		{
			return null;
		}
		return creatureSets.First((CreatureSkinSet x) => Identifier.IdentifierFlags.AllPushbacks.HasFlag(x.type) && x.skinSetInternalName == internalName);
	}

	public ItemSkinGroup GetItemSkinGroup(string internalName)
	{
		if (itemGroups.Length == 0)
		{
			return null;
		}
		return itemGroups.First((ItemSkinGroup x) => x.skinGroupInternalName == internalName);
	}

	[ContextMenu("LoadAllSkinsFromAssets")]
	public void LoadAllSkinsFromAssets()
	{
		ThemeSkinSet[] array = Resources.LoadAll<ThemeSkinSet>("Skins");
		themeSets = array;
		PlayerSkinSet[] array2 = Resources.LoadAll<PlayerSkinSet>("Skins");
		playerSets = array2;
		CreatureSkinSet[] array3 = Resources.LoadAll<CreatureSkinSet>("Skins");
		creatureSets = array3;
		PlayerSkinPart[] array4 = Resources.LoadAll<PlayerSkinPart>("Skins");
		playerParts = array4;
		ItemSkinGroup[] array5 = Resources.LoadAll<ItemSkinGroup>("Skins");
		itemGroups = array5;
	}
}
