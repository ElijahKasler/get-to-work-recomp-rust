using UnityEngine;

namespace Isto.Core.Cameras;

public class LookAtCamera : MonoBehaviour
{
	public bool DoOnUpdate;

	private void OnEnable()
	{
		Vector3 forward = Camera.main.transform.forward;
		forward.y = 0f;
		base.transform.LookAt(base.transform.position + forward);
	}

	private void Update()
	{
		if (DoOnUpdate)
		{
			base.transform.LookAt(base.transform.position + Camera.main.transform.forward);
		}
	}
}
