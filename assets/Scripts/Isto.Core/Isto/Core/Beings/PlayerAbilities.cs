using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Beings;

public class PlayerAbilities : MonoBehaviour
{
	private List<PlayerAbilityState> _activeAbilities = new List<PlayerAbilityState>();

	private PlayerAbilityState _priorityAbility;

	private bool _abilitiesDisabled;

	public PlayerAbilityState GetReadyAbility()
	{
		if (_abilitiesDisabled)
		{
			return null;
		}
		if (_priorityAbility != null && _priorityAbility.IsReadyToActivate())
		{
			return _priorityAbility;
		}
		for (int i = 0; i < _activeAbilities.Count; i++)
		{
			if (_activeAbilities[i].IsReadyToActivate())
			{
				return _activeAbilities[i];
			}
		}
		return null;
	}

	public void AddAbility(PlayerAbilityState abilityState)
	{
		if (!_activeAbilities.Contains(abilityState))
		{
			_activeAbilities.Add(abilityState);
			abilityState.OnEquipped();
		}
	}

	public void RemoveAbility(PlayerAbilityState abilityState)
	{
		if (_priorityAbility == abilityState)
		{
			_priorityAbility = null;
		}
		else if (_activeAbilities.Remove(abilityState))
		{
			abilityState.OnUnequipped();
		}
	}

	public void SetPriorityAbility(PlayerAbilityState priorityState)
	{
		_priorityAbility = priorityState;
	}

	public bool IsAbilityActive(PlayerAbilityState abilityState)
	{
		return _activeAbilities.Contains(abilityState);
	}

	public void DisableAbilities(float time)
	{
		_abilitiesDisabled = true;
		CancelInvoke();
		Invoke("EnableAbilities", time);
	}

	public void EnableAbilities()
	{
		_abilitiesDisabled = false;
	}
}
