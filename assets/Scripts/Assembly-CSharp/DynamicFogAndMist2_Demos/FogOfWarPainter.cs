using DynamicFogAndMist2;
using UnityEngine;

namespace DynamicFogAndMist2_Demos;

public class FogOfWarPainter : MonoBehaviour
{
	public float clearRadius = 5f;

	public float clearDuration;

	public float restoreDelay = 10f;

	public float restoreDuration = 2f;

	[Range(0f, 1f)]
	public float borderSmoothness = 0.2f;

	private DynamicFog fog;

	private void Start()
	{
		fog = GetComponent<DynamicFog>();
	}

	private void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Vector3 mousePosition = Input.mousePosition;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(mousePosition), out var hitInfo))
			{
				fog.SetFogOfWarAlpha(hitInfo.point, clearRadius, 0f, blendAlpha: false, clearDuration, borderSmoothness, restoreDelay, restoreDuration);
			}
		}
	}

	public void RestoreFog()
	{
		fog.ResetFogOfWar();
	}
}
