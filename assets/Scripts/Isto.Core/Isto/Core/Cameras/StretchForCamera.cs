using UnityEngine;

namespace Isto.Core.Cameras;

[ExecuteInEditMode]
public class StretchForCamera : MonoBehaviour
{
	public float scaleFactor = 1.193f;

	private void Start()
	{
		Vector3 localScale = base.transform.localScale;
		localScale.y = localScale.x * scaleFactor;
		base.transform.localScale = localScale;
	}
}
