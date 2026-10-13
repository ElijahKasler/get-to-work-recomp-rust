using UnityEngine;

namespace Isto.GTW.Player;

public class SunLight : MonoBehaviour
{
	private Light _light;

	public Light Light
	{
		get
		{
			if (_light == null)
			{
				_light = GetComponent<Light>();
			}
			return _light;
		}
	}
}
