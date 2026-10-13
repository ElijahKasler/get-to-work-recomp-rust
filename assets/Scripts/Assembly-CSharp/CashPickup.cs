using UnityEngine;

public class CashPickup : MonoBehaviour
{
	[SerializeField]
	private GameObject ParticleSystem;

	[SerializeField]
	private GameObject SFX;

	private void OnTriggerEnter(Collider other)
	{
		ParticleSystem.SetActive(value: true);
		SFX.SetActive(value: true);
	}
}
