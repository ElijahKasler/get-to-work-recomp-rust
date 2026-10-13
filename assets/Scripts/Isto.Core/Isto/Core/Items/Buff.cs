using I2.Loc;
using Isto.Core.Localization;
using UnityEngine;

namespace Isto.Core.Items;

public abstract class Buff : ScriptableObject
{
	[Header("--------- Standard Fields")]
	[SerializeField]
	private LocalizedString buffnameLoc;

	public Sprite icon;

	protected bool _isActive;

	public string BuffName => Loc.Get(buffnameLoc);

	public bool IsActive => _isActive;

	public abstract void ActivateBuff(GameObject consumer);

	public abstract void DeactivateBuff(GameObject consumer);

	public virtual void UpdateBuff(GameObject consumer)
	{
	}
}
