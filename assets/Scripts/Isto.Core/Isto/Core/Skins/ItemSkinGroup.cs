using I2.Loc;
using UnityEngine;

namespace Isto.Core.Skins;

[CreateAssetMenu(fileName = "New Item Skin Group Definition", menuName = "Scriptables/Skins/Item Skin Group Definition")]
public class ItemSkinGroup : ScriptableObject
{
	public string skinGroupInternalName;

	public LocalizedString skinGroupNameKey;
}
