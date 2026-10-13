using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(BakeryVolume))]
[DefaultExecutionOrder(-1000)]
public class BakeryVolumeRegistry : MonoBehaviour
{
	[SerializeField]
	private BakeryVolume volume;

	public static List<BakeryVolume> avaibleVolumes = new List<BakeryVolume>(16);

	private void Reset()
	{
		volume = GetComponent<BakeryVolume>();
	}

	private void OnEnable()
	{
		if (volume == null)
		{
			volume = GetComponent<BakeryVolume>();
		}
		if (!avaibleVolumes.Contains(volume))
		{
			avaibleVolumes.Add(volume);
		}
		avaibleVolumes.RemoveAll((BakeryVolume item) => item == null);
	}

	private void OnDisable()
	{
		if (avaibleVolumes.Contains(volume))
		{
			avaibleVolumes.Remove(volume);
		}
	}
}
