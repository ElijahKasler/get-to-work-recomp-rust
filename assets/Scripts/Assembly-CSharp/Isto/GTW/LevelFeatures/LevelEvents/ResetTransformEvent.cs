using Unity.Mathematics;
using UnityEngine;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class ResetTransformEvent : LevelEvent
{
	[SerializeField]
	private Transform _transformToReset;

	[SerializeField]
	private bool _resetPosition = true;

	[SerializeField]
	private bool _resetRotation = true;

	[SerializeField]
	private bool _resetScale = true;

	private Vector3 _originalPosition = Vector3.zero;

	private Quaternion _originalRotation = quaternion.identity;

	private Vector3 _originalScale = Vector3.zero;

	protected override void Awake()
	{
		base.Awake();
		SetOriginalValues();
	}

	public override void TriggerEvent(bool initialization = false)
	{
		if (!(_transformToReset == null))
		{
			if (_resetPosition)
			{
				_transformToReset.position = _originalPosition;
			}
			if (_resetRotation)
			{
				_transformToReset.rotation = _originalRotation;
			}
			if (_resetScale)
			{
				_transformToReset.localScale = _originalScale;
			}
		}
	}

	public void SetOriginalValues()
	{
		if (!(_transformToReset == null))
		{
			_originalPosition = _transformToReset.position;
			_originalRotation = _transformToReset.rotation;
			_originalScale = _transformToReset.localScale;
		}
	}
}
