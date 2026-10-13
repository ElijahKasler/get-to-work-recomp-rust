using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Isto.GTW.Player;

public class PlayerShadow : MonoBehaviour
{
	[SerializeField]
	private PlayerController _playerController;

	[SerializeField]
	private DecalProjector _projector;

	[SerializeField]
	[Range(0.01f, 3f)]
	private float _shadowActivationDuration = 0.05f;

	[SerializeField]
	[Range(0.01f, 3f)]
	private float _shadowDeactivationDuration = 0.2f;

	private Renderer[] _modelRenderers;

	private SunLight _sunLight;

	private bool _playerShadowActive;

	private Coroutine _playerShadowCoroutine;

	private float _playerShadowOrientation_t = 1f;

	protected SunLight SunLight
	{
		get
		{
			if (_sunLight == null)
			{
				_sunLight = Object.FindObjectOfType<SunLight>();
			}
			return _sunLight;
		}
	}

	private void Awake()
	{
		_modelRenderers = _playerController.GetComponentsInChildren<Renderer>();
		Renderer[] modelRenderers = _modelRenderers;
		for (int i = 0; i < modelRenderers.Length; i++)
		{
			modelRenderers[i].shadowCastingMode = ShadowCastingMode.Off;
		}
	}

	private void Start()
	{
		_ = SunLight;
		SetPlayerShadow(projectorShadowActive: true);
	}

	private void LateUpdate()
	{
		UpdatePlayerShadowPosition();
	}

	private void SetPlayerShadow(bool projectorShadowActive)
	{
		if (projectorShadowActive && !_playerShadowActive)
		{
			_playerShadowActive = true;
			_playerShadowCoroutine = StartCoroutine(ActivatePlayerShadow());
		}
		else if (!projectorShadowActive && _playerShadowActive)
		{
			_playerShadowActive = false;
			_playerShadowCoroutine = StartCoroutine(DeactivatePlayerShadow());
		}
	}

	private IEnumerator ActivatePlayerShadow()
	{
		if (_playerShadowCoroutine != null)
		{
			StopCoroutine(_playerShadowCoroutine);
			_playerShadowCoroutine = null;
		}
		Renderer[] modelRenderers = _modelRenderers;
		for (int i = 0; i < modelRenderers.Length; i++)
		{
			modelRenderers[i].shadowCastingMode = ShadowCastingMode.Off;
		}
		_projector.enabled = true;
		do
		{
			_playerShadowOrientation_t = Mathf.MoveTowards(_playerShadowOrientation_t, 0f, Time.deltaTime / _shadowActivationDuration);
			SetPlayerShadowRotation(_playerShadowOrientation_t);
			yield return null;
		}
		while (_playerShadowOrientation_t > 0f);
		_playerShadowCoroutine = null;
	}

	private IEnumerator DeactivatePlayerShadow()
	{
		if (_playerShadowCoroutine != null)
		{
			StopCoroutine(_playerShadowCoroutine);
			_playerShadowCoroutine = null;
		}
		do
		{
			_playerShadowOrientation_t = Mathf.MoveTowards(_playerShadowOrientation_t, 1f, Time.deltaTime / _shadowDeactivationDuration);
			SetPlayerShadowRotation(_playerShadowOrientation_t);
			yield return null;
		}
		while (_playerShadowOrientation_t < 1f);
		Renderer[] modelRenderers = _modelRenderers;
		for (int i = 0; i < modelRenderers.Length; i++)
		{
			modelRenderers[i].shadowCastingMode = ShadowCastingMode.On;
		}
		_projector.enabled = false;
		_playerShadowCoroutine = null;
	}

	private void UpdatePlayerShadowPosition()
	{
		if (_playerController.IsMoveState)
		{
			base.transform.position = _playerController.PlayerPosition;
		}
		else
		{
			base.transform.position = _playerController.PlayerModelController.PlayerIkController.PelvisBone.position;
		}
	}

	private void SetPlayerShadowRotation(float t)
	{
		SunLight sunLight = SunLight;
		Quaternion b = Quaternion.LookRotation(Vector3.down);
		if (sunLight != null)
		{
			b = sunLight.transform.rotation;
		}
		base.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(Vector3.down), b, t);
	}
}
