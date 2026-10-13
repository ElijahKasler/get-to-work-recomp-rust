using Cinemachine;
using UnityEngine;

namespace Isto.GTW.Camera;

public class FixedVirtualCamera : MonoBehaviour
{
	[SerializeField]
	private float _horizontalLimits = 45f;

	[SerializeField]
	private float _verticalLimits = 45f;

	private CinemachineVirtualCamera _virtualCamera;

	private Vector3 _defaultRotation = Vector3.zero;

	public CinemachineVirtualCamera VirtualCamera => _virtualCamera;

	public Vector3 DefaultRotation => _defaultRotation;

	public float HorizontalLimits => Mathf.Abs(_horizontalLimits);

	public float VerticalLimits => Mathf.Abs(_verticalLimits);

	private void Awake()
	{
		_virtualCamera = GetComponent<CinemachineVirtualCamera>();
		_defaultRotation = base.transform.localRotation.eulerAngles;
	}

	public void ResetCameraRotation()
	{
		base.transform.localRotation = Quaternion.Euler(_defaultRotation);
	}
}
