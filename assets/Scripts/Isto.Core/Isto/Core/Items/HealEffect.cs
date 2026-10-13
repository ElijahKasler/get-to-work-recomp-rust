using FMODUnity;
using Isto.Core.Audio;
using Isto.Core.Beings;
using UnityEngine;
using Zenject;

namespace Isto.Core.Items;

[CreateAssetMenu(fileName = "New Heal Effect", menuName = "Scriptables/ItemEffect/Heal")]
public class HealEffect : ItemEffect
{
	public float amount;

	[EventRef]
	[SerializeField]
	private string _refillAudio;

	private IGameSounds _sounds;

	[Inject]
	public void Inject(IGameSounds sounds)
	{
		_sounds = sounds;
	}

	public override void UseItem(GameObject consumer)
	{
		PlayerHealth component = consumer.GetComponent<PlayerHealth>();
		if (component != null)
		{
			component.Heal(amount);
			_sounds.PlayOneShot(_refillAudio, Vector3.zero);
		}
	}
}
