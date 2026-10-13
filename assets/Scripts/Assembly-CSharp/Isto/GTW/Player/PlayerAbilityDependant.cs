using UnityEngine;
using Zenject;

namespace Isto.GTW.Player;

public class PlayerAbilityDependant : MonoBehaviour
{
	[SerializeField]
	private GameObject _ragdollButtonPrompt;

	[SerializeField]
	private GameObject _restartButtonPrompt;

	private PlayerController _player;

	[Inject]
	public void Inject(PlayerController player)
	{
		_player = player;
	}

	private void Update()
	{
		UpdatePrompt(_ragdollButtonPrompt, _player.ragDollAbilityAvailable);
		UpdatePrompt(_restartButtonPrompt, _player.restartAbilityAvailable);
	}

	private void UpdatePrompt(GameObject prompt, bool isActive)
	{
		if (!(prompt == null) && prompt.activeSelf != isActive)
		{
			prompt.SetActive(isActive);
		}
	}
}
