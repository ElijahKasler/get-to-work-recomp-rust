using UnityEngine;

namespace VolumetricLights;

[ExecuteInEditMode]
[AddComponentMenu("")]
[RequireComponent(typeof(VolumetricLight))]
public class VolumetricLightDirectionalSync : MonoBehaviour
{
	[Tooltip("The directional light that is synced with this volumetric area light.")]
	public Light directionalLight;

	[Tooltip("Makes this area light position follow the desired target. Usually this is the main camera.")]
	public Transform follow;

	[Tooltip("Move volumetric light to 'follow' gameobject position if distance is greater than this value. Updating the position of this volumetric light area every frame is not recommended.")]
	public float distanceUpdate = 1f;

	private VolumetricLight vl;

	private Light fakeLight;

	private Vector3 lastFollowPos;

	private void Start()
	{
		vl = GetComponent<VolumetricLight>();
		fakeLight = GetComponent<Light>();
		if (follow == null && Camera.main != null)
		{
			follow = Camera.main.transform;
		}
	}

	private void LateUpdate()
	{
		if (!(directionalLight != null))
		{
			return;
		}
		if (follow != null)
		{
			Vector3 position = follow.position;
			if (Vector3.Distance(lastFollowPos, position) > distanceUpdate)
			{
				lastFollowPos = position;
				base.transform.position = follow.position;
				base.transform.position -= directionalLight.transform.forward * vl.generatedRange * 0.5f;
			}
		}
		base.transform.forward = directionalLight.transform.forward;
		if (fakeLight != null)
		{
			fakeLight.enabled = false;
			fakeLight.color = directionalLight.color;
			fakeLight.intensity = directionalLight.intensity;
		}
	}
}
