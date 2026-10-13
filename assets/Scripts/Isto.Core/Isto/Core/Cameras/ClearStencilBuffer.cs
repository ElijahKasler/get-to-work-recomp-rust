using UnityEngine;

namespace Isto.Core.Cameras;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class ClearStencilBuffer : MonoBehaviour
{
	private void OnEnable()
	{
		GetComponent<Camera>().clearStencilAfterLightingPass = false;
	}
}
