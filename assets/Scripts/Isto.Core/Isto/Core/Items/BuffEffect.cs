using System.Collections.Generic;
using Isto.Core.Beings;
using UnityEngine;

namespace Isto.Core.Items;

[CreateAssetMenu(fileName = "New Buff Effect", menuName = "Scriptables/ItemEffect/BuffEffect")]
public class BuffEffect : ItemEffect
{
	public string ID;

	public float effectDuration;

	public List<Buff> buffs;

	public override void UseItem(GameObject consumer)
	{
		if (consumer.TryGetComponent<PlayerHealth>(out var component))
		{
			component.SetNewBuff(this);
		}
	}

	public void ActivateBuff(GameObject consumer)
	{
		for (int i = 0; i < buffs.Count; i++)
		{
			buffs[i].ActivateBuff(consumer);
		}
	}

	public void UpdateBuf(GameObject consumer)
	{
		for (int i = 0; i < buffs.Count; i++)
		{
			buffs[i].UpdateBuff(consumer);
		}
	}

	public void ExpireBuff(GameObject consumer)
	{
		for (int i = 0; i < buffs.Count; i++)
		{
			buffs[i].DeactivateBuff(consumer);
		}
	}
}
