using System;
using Isto.Core.Beings;
using UnityEngine;

namespace Isto.Core;

public class HealthEventArgs : EventArgs
{
	public float damage;

	public Health.DamageTypeEnum type;

	public Health.DamageSourceEnum source;

	public float stunTime;

	public Transform sourceTransform;

	public HealthEventArgs(float damage, Health.DamageTypeEnum type, Health.DamageSourceEnum source, Transform damageSourceTransform = null, float stunTime = 0f)
	{
		this.damage = damage;
		this.type = type;
		this.stunTime = stunTime;
		this.source = source;
		sourceTransform = damageSourceTransform;
	}
}
