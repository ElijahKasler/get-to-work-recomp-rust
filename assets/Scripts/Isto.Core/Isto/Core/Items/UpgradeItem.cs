using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Items;

[CreateAssetMenu(fileName = "New Upgrade Item", menuName = "Scriptables/Upgrades/Upgrade Item")]
public class UpgradeItem : CoreItem
{
	[Header("Upgrade Parameters")]
	public List<UpgradeEffect> effects;
}
