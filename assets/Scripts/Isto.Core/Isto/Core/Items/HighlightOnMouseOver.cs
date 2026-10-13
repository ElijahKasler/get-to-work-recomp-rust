using Isto.Core.Inputs;
using Isto.Core.Pooling;
using UnityEngine;
using Zenject;

namespace Isto.Core.Items;

public class HighlightOnMouseOver : MonoBehaviour, IActionOnRecycle
{
	public float scaleFactor = 1.1f;

	public float emissionFactor = 0.5f;

	public SpriteRenderer sprite;

	private bool _active;

	private Vector3 _startScale;

	private float _startEmission;

	private string _emissionProperty = "_EmissionFactor";

	private IControls _controls;

	[Inject]
	public void Inject(IControls controls)
	{
		_controls = controls;
	}

	private void Awake()
	{
		_startScale = sprite.transform.localScale;
	}

	private void OnMouseOver()
	{
		if (!_controls.GetPointerOverUI() && !_active)
		{
			_active = true;
			if (sprite.material.HasProperty(_emissionProperty))
			{
				_startEmission = sprite.material.GetFloat(_emissionProperty);
				sprite.material.SetFloat(_emissionProperty, _startEmission + emissionFactor);
			}
			sprite.transform.localScale = _startScale * scaleFactor;
		}
	}

	private void OnMouseExit()
	{
		_active = false;
		sprite.transform.localScale = _startScale;
		if (sprite.material.HasProperty(_emissionProperty))
		{
			sprite.material.SetFloat(_emissionProperty, _startEmission);
		}
	}

	public void OnRecycle()
	{
		OnMouseExit();
	}
}
