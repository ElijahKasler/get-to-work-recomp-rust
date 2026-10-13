using Isto.Core.Beings;
using UnityEngine;

namespace Isto.Core.Items;

[CreateAssetMenu(fileName = "Buff_HealOverTime_", menuName = "Scriptables/ItemEffect/Buff-HealOverTime")]
public class HealOverTimeBuff : Buff
{
	[Header("--------- Heal Over Time")]
	public float healthPerSecond;

	private Health _healthComponent;

	public override void ActivateBuff(GameObject consumer)
	{
		_isActive = true;
		if (consumer.TryGetComponent<Health>(out var component))
		{
			_healthComponent = component;
		}
	}

	public override void DeactivateBuff(GameObject consumer)
	{
		_isActive = false;
	}

	public override void UpdateBuff(GameObject consumer)
	{
		if (_isActive && _healthComponent != null)
		{
			_healthComponent.Heal(healthPerSecond * Time.deltaTime);
		}
	}
}
