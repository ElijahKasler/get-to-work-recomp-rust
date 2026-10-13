using System;
using System.Collections.Generic;
using Isto.GTW.DebugTools;
using UnityEngine;

namespace Isto.GTW.Player;

[DefaultExecutionOrder(90)]
public class PlayerCollisionHandler : MonoBehaviour
{
	public struct GroundHitData
	{
		public float time;

		public RaycastHit hit;

		public Vector3 floorDirection;

		public float floorAngle;

		public Vector3 playerPosition;

		public Vector3 playerVelocity;

		public Vector3 playerAngularVelocity;

		public Vector3 FloorHitPosition => hit.point;

		public Vector3 FloorNormal => hit.normal;

		public bool IsValid()
		{
			return hit.collider != null;
		}
	}

	[SerializeField]
	private LayerMask _groundLayerMask;

	[SerializeField]
	private float _collisionRadiusOffset = 0.1f;

	private PlayerController _playerController;

	private bool _isGrounded;

	private GroundHitData _currentGroundHitData;

	private GroundHitData _previousGroundHitData;

	private bool _hasJustLeftGround;

	private float _groundedTime;

	private float _airTime;

	private bool _needGroundCollisionCheck;

	private List<Vector3> _collisionDirectionCheck = new List<Vector3>();

	private RaycastHit[] _hits = new RaycastHit[5];

	private List<RaycastHit> _hitsToCheck = new List<RaycastHit>();

	public const string StickyTag = "Sticky";

	public const string SlipperyTag = "Slippery";

	public Action<Collision> OnCollision;

	public LayerMask GroundLayerMask => _groundLayerMask;

	public bool IsGrounded
	{
		get
		{
			if (_isGrounded)
			{
				return _currentGroundHitData.hit.collider != null;
			}
			return false;
		}
	}

	public GroundHitData CurrentCurrentGroundHitData => _currentGroundHitData;

	public GroundHitData PreviousGroundHitData => _previousGroundHitData;

	public bool HasJustLeftGround => _hasJustLeftGround;

	public RaycastHit Hit => _currentGroundHitData.hit;

	public int GroundLayer
	{
		get
		{
			if (!(Hit.collider != null))
			{
				return 0;
			}
			return Hit.collider.gameObject.layer;
		}
	}

	public float GroundedTime => _groundedTime;

	public float AirTime => _airTime;

	public Vector3 FloorDirection => _currentGroundHitData.floorDirection;

	public Vector3 FloorNormal => _currentGroundHitData.FloorNormal;

	public float FloorAngle => _currentGroundHitData.floorAngle;

	public bool ShowDebug => _playerController.showDebug;

	private void Awake()
	{
		_playerController = GetComponentInParent<PlayerController>();
		PlayerController playerController = _playerController;
		playerController.OnResetVelocity = (Action)Delegate.Combine(playerController.OnResetVelocity, new Action(PlayerController_OnResetVelocity));
		_previousGroundHitData.playerPosition = _playerController.PlayerPosition;
		_previousGroundHitData.time = float.MaxValue;
	}

	private void OnDestroy()
	{
		PlayerController playerController = _playerController;
		playerController.OnResetVelocity = (Action)Delegate.Remove(playerController.OnResetVelocity, new Action(PlayerController_OnResetVelocity));
	}

	private void Update()
	{
		UpdateGroundHitData();
		DrawDebug();
	}

	private void OnCollisionEnter(Collision collision)
	{
		_playerController.PlayerModelController.PlayerIkController.PlayerRagdoll.CollisionHit(collision.impulse);
		ProcessCollision(collision);
		OnCollision?.Invoke(collision);
	}

	private void OnCollisionStay(Collision collision)
	{
		ProcessCollision(collision);
	}

	private void ProcessCollision(Collision collision)
	{
		_needGroundCollisionCheck = true;
		Vector3 point = collision.contacts[0].point;
		_collisionDirectionCheck.Add((point - _playerController.PlayerPosition).normalized);
	}

	private void PlayerController_OnResetVelocity()
	{
		_isGrounded = false;
		_collisionDirectionCheck = new List<Vector3>();
		_currentGroundHitData.floorDirection = Vector3.down;
		_currentGroundHitData.floorAngle = 0f;
	}

	private void UpdateGroundHitData()
	{
		if (_isGrounded)
		{
			_previousGroundHitData = _currentGroundHitData;
			_previousGroundHitData.time = 0f;
		}
		_hasJustLeftGround = false;
		if (_collisionDirectionCheck.Count > 0 || _isGrounded)
		{
			_hitsToCheck.Clear();
			if (_collisionDirectionCheck.Count == 0)
			{
				_collisionDirectionCheck.Add(_currentGroundHitData.floorDirection);
			}
			for (int i = 0; i < _collisionDirectionCheck.Count; i++)
			{
				Vector3 vector = _collisionDirectionCheck[i];
				int num = Physics.SphereCastNonAlloc(_playerController.PlayerPosition - vector * _collisionRadiusOffset, _playerController.BallRadius, vector, _hits, _collisionRadiusOffset * 2f, _groundLayerMask);
				if (num <= 0)
				{
					continue;
				}
				for (int j = 0; j < num; j++)
				{
					if (Vector3.Angle(_playerController.PlayerPosition - _hits[j].point, _hits[j].normal) > 90f)
					{
						_hits[j].normal = -_hits[j].normal;
					}
					_hitsToCheck.Add(_hits[j]);
				}
			}
			bool isGrounded = _isGrounded;
			if (_hitsToCheck.Count > 0)
			{
				_isGrounded = false;
				_currentGroundHitData.time = 0f;
				_currentGroundHitData.floorAngle = 0f;
				float num2 = float.MaxValue;
				for (int k = 0; k < _hitsToCheck.Count; k++)
				{
					float num3 = Vector3.Angle(Vector3.up, _hitsToCheck[k].normal);
					if (num3 < num2 && Vector3.Distance(_playerController.PlayerPosition, _hitsToCheck[k].point) < _playerController.BallRadius + _collisionRadiusOffset)
					{
						_isGrounded = true;
						num2 = num3;
						_currentGroundHitData.playerPosition = _playerController.PlayerPosition;
						_currentGroundHitData.playerVelocity = _playerController.Rigidbody.linearVelocity;
						_currentGroundHitData.playerAngularVelocity = _playerController.Rigidbody.angularVelocity;
						_currentGroundHitData.hit = _hitsToCheck[k];
						_currentGroundHitData.floorAngle = num3;
						_currentGroundHitData.floorDirection = (_currentGroundHitData.hit.point - _playerController.PlayerPosition).normalized;
					}
				}
			}
			else
			{
				_isGrounded = false;
				_currentGroundHitData.floorAngle = 0f;
			}
			if (isGrounded && !_isGrounded)
			{
				_hasJustLeftGround = true;
			}
		}
		_needGroundCollisionCheck = false;
		if (_isGrounded)
		{
			_groundedTime += Time.deltaTime;
			_airTime = 0f;
		}
		else
		{
			_groundedTime = 0f;
			_airTime += Time.deltaTime;
			_previousGroundHitData.time += Time.deltaTime;
		}
		if (ShowDebug && _isGrounded)
		{
			DebugExtensions.DrawLocator(_currentGroundHitData.FloorHitPosition, Color.blue);
			Debug.DrawLine(_playerController.PlayerPosition, _currentGroundHitData.FloorHitPosition, Color.blue);
		}
		_collisionDirectionCheck.Clear();
	}

	public void ClearGroundHit()
	{
		_previousGroundHitData.time = float.MaxValue;
		_hitsToCheck.Clear();
		_isGrounded = false;
	}

	public void Reground()
	{
		if (!_isGrounded && _previousGroundHitData.hit.collider != null)
		{
			_previousGroundHitData.time = 0f;
			_currentGroundHitData = _previousGroundHitData;
			_playerController.TeleportCharacter(_currentGroundHitData.playerPosition);
			_playerController.Rigidbody.linearVelocity = _currentGroundHitData.playerVelocity;
			_playerController.Rigidbody.angularVelocity = _currentGroundHitData.playerAngularVelocity;
			_isGrounded = true;
			UpdateGroundHitData();
		}
	}

	private void DrawDebug()
	{
		if (ShowDebug && _isGrounded)
		{
			DebugExtensions.DrawLocator(_currentGroundHitData.FloorHitPosition, Color.blue);
			Debug.DrawLine(_playerController.PlayerPosition, _currentGroundHitData.FloorHitPosition, Color.blue);
		}
	}
}
