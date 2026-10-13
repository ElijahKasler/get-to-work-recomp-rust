using System.Collections.Generic;
using Isto.Core.Beings;
using UnityEngine;

namespace Isto.Core.Items;

public class Flammable : MonoBehaviour
{
	public List<ItemPile> itemDrops;

	public float dropSpread;

	public GameObject flamesPrefab;

	public float damagePerSecond = 1000f;

	private bool _onFire;

	private Health _health;

	private void Awake()
	{
		_health = GetComponent<Health>();
	}

	private void Update()
	{
		if (_onFire && _health != null)
		{
			_health.TakeDamage(damagePerSecond * Time.deltaTime, Health.DamageTypeEnum.FIRE, Health.DamageSourceEnum.PLAYER);
		}
	}

	public void HealthChanged(Health.DamageTypeEnum type)
	{
		if (type == Health.DamageTypeEnum.FIRE && !_onFire)
		{
			_onFire = true;
			StartOnFire();
		}
	}

	public void HealthGone(Health.DamageTypeEnum type)
	{
		if (type == Health.DamageTypeEnum.FIRE)
		{
			for (int i = 0; i < itemDrops.Count; i++)
			{
				Vector3 vector = UnityUtils.RandomXZVector(dropSpread);
				itemDrops[i].item.DropItem(base.transform.position + vector, null, itemDrops[i].count);
			}
			Object.Destroy(base.gameObject);
		}
	}

	private void StartOnFire()
	{
		if (flamesPrefab != null)
		{
			Object.Instantiate(flamesPrefab, base.transform.position, Quaternion.identity, base.transform);
		}
	}
}
