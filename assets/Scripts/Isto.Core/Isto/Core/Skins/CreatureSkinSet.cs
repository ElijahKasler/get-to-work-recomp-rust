using I2.Loc;
using UnityEngine;

namespace Isto.Core.Skins;

[CreateAssetMenu(fileName = "New Creature Skin Set Definition", menuName = "Scriptables/Skins/Creature Skin Set Definition")]
public class CreatureSkinSet : ScriptableObject
{
	public string skinSetInternalName;

	public LocalizedString skinSetNameKey;

	public string skinSetSpineName;

	public Identifier.IdentifierFlags type;
}
