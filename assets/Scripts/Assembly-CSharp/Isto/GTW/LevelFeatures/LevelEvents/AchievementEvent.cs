using Isto.Core.Achievements;
using Isto.Core.Enums;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class AchievementEvent : LevelEvent
{
	[EnumDropdown(typeof(IGTWAchievements.GTWAchievementsEnum))]
	[SerializeField]
	private int _achievement;

	private BoxCollider _collider;

	private IAchievements _achievements;

	private BoxCollider Collider
	{
		get
		{
			if (_collider == null)
			{
				_collider = GetComponent<BoxCollider>();
			}
			return _collider;
		}
	}

	[Inject]
	public void Inject(IAchievements achievements)
	{
		_achievements = achievements;
	}

	protected override void Awake()
	{
		base.Awake();
	}

	private void Update()
	{
	}

	public override void TriggerEvent(bool initialization = false)
	{
		IGTWAchievements.GTWAchievementsEnum achievement = ExpandableEnum<Int32Enum<IAchievements.CoreAchievementsEnum>, int>.GetFromValue(_achievement) as IGTWAchievements.GTWAchievementsEnum;
		_achievements.TriggerAchievement(achievement);
	}
}
