using I2.Loc;
using UnityEngine;

namespace Isto.Core.Skins;

[CreateAssetMenu(fileName = "New Player Skin Set Definition", menuName = "Scriptables/Skins/Player Skin Set Definition")]
public class PlayerSkinSet : ScriptableObject
{
	public string skinSetInternalName;

	public LocalizedString skinSetNameKey;

	public PlayerSkinPart hat;

	public PlayerSkinPart head;

	public PlayerSkinPart body;
}
