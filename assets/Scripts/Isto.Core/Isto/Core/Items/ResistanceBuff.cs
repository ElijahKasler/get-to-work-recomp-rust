using System.Collections.Generic;
using Isto.Core.Beings;
using Isto.Core.Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Isto.Core.Items;

[CreateAssetMenu(fileName = "Buff_Resistance_", menuName = "Scriptables/ItemEffect/Buff-Resistance")]
public class ResistanceBuff : Buff
{
	[Header("--------- Resistance")]
	[SerializeField]
	[FormerlySerializedAs("damageType")]
	[EnumDropdown(typeof(Health.DamageTypeEnum))]
	private int _damageType;

	[Tooltip("0 = no resistance, 1 = full resistance")]
	public float resistanceAmount;

	public Health.DamageTypeEnum DamageType => Int32Enum<Health.DamageTypeEnum>.GetByValue(_damageType);

	public override void ActivateBuff(GameObject consumer)
	{
		if (consumer.TryGetComponent<PlayerHealth>(out var component))
		{
			int num = FindBuffIndex(component.activeResistances);
			if (num != -1)
			{
				Debug.LogError("Trying to add a duplicate resistance. You can only have one resistance per damage type. Removing the old resistance.");
				component.activeResistances.RemoveAt(num);
			}
			else
			{
				component.activeResistances.Add(this);
			}
		}
	}

	public override void DeactivateBuff(GameObject consumer)
	{
		if (consumer.TryGetComponent<PlayerHealth>(out var component))
		{
			int num = FindBuffIndex(component.activeResistances);
			if (num != -1)
			{
				component.activeResistances.RemoveAt(num);
			}
		}
	}

	public int FindBuffIndex(List<ResistanceBuff> buffList)
	{
		for (int i = 0; i < buffList.Count; i++)
		{
			if (buffList[i]._damageType == _damageType)
			{
				return i;
			}
		}
		return -1;
	}

	public float ModifyDamage(Health.DamageTypeEnum type, float damage)
	{
		if (resistanceAmount < 0f || resistanceAmount > 1f)
		{
			Debug.LogWarning("Buff " + base.BuffName + ": Resistance Must be between 0 and 1");
			resistanceAmount = Mathf.Clamp01(resistanceAmount);
		}
		if (_damageType == type.Value)
		{
			return damage - damage * resistanceAmount;
		}
		return damage;
	}
}
