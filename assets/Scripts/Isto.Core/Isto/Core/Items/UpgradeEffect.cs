using Isto.Core.Beings;
using UnityEngine;

namespace Isto.Core.Items;

public abstract class UpgradeEffect : ScriptableObject
{
	public abstract void ActivateEffect(AutomationPlayerController player);

	public abstract void DeactivateEffect(AutomationPlayerController player);
}
