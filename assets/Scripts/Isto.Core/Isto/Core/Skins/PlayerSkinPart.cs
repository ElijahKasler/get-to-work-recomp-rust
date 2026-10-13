using I2.Loc;
using UnityEngine;

namespace Isto.Core.Skins;

[CreateAssetMenu(fileName = "New Player Skin Part Definition", menuName = "Scriptables/Skins/Player Skin Part Definition")]
public class PlayerSkinPart : ScriptableObject
{
	public enum SkinPartType
	{
		Body = 0,
		Hat = 1
	}

	public string skinPartInternalName;

	public LocalizedString skinPartNameKey;

	public string skinSpineName;

	public SkinPartType type;
}
