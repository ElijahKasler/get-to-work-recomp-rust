using UnityEngine;

public class SmokeSensorAnim : MonoBehaviour
{
	private MeshRenderer Diode;

	public float EmissionIntensity = 4f;

	public float FlashingInterval = 1f;

	private void Start()
	{
		Diode = GetComponent<MeshRenderer>();
		InvokeRepeating("DiodeFlashing", FlashingInterval, FlashingInterval);
	}

	private void DiodeFlashing()
	{
		if (Diode.material.GetFloat("_EmissionIntensity") == 0f)
		{
			Diode.material.SetFloat("_EmissionIntensity", EmissionIntensity);
		}
		else
		{
			Diode.material.SetFloat("_EmissionIntensity", 0f);
		}
	}
}
