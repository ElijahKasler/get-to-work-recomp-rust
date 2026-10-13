using UnityEngine;
using Zenject;

namespace Isto.Core.Cameras;

[RequireComponent(typeof(Canvas))]
public class InjectCanvasCamera : MonoBehaviour
{
	private Camera _worldCamera;

	[Inject]
	public void Inject(CameraController cameraController)
	{
		_worldCamera = cameraController.MainCamera;
	}

	private void Awake()
	{
		GetComponent<Canvas>().worldCamera = _worldCamera;
	}
}
