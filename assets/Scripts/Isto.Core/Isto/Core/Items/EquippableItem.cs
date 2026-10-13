using UnityEngine;

namespace Isto.Core.Items;

[CreateAssetMenu(fileName = "New Equippable Item", menuName = "Scriptables/Item/EquippableItem")]
public class EquippableItem : CoreItem
{
	public Sprite horIcon;

	public Sprite backIcon;

	public Sprite frontIcon;
}
