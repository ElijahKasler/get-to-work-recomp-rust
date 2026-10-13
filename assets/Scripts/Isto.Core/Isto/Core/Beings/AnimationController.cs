using System;
using System.Collections.Generic;
using Isto.Core.Cameras;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Isto.Core.Beings;

public class AnimationController : MonoBehaviour
{
	public enum AnimationType
	{
		idle = 0,
		run = 1,
		dodge = 2,
		walk = 3,
		scan = 4,
		drag = 5,
		shield = 6,
		showOffPick = 7,
		disabled = 8,
		stab = 9,
		backup = 10,
		eat = 11,
		poop = 12,
		runSprite = 13,
		stumble = 14,
		pre_attack = 15,
		attack = 16,
		post_attack = 17,
		genericDeath1 = 18,
		deathFromBattery = 19,
		springboarded = 20,
		genericDeath2 = 21,
		deathFromPushBack = 22,
		deathFromWater = 23,
		deathFromCorrosion = 24
	}

	public enum SubAnimationType
	{
		headLookBack = 0,
		headLookForward = 1,
		headLookRight = 2,
		headLookLeft = 3,
		torchOff = 4,
		torchOn = 5
	}

	public enum CharacterDirections
	{
		front = 0,
		back = 1,
		left = 2,
		right = 3,
		up_right = 4,
		up_left = 5,
		down_left = 6,
		down_right = 7,
		not_set = 8
	}

	public List<GameObject> animators;

	[Tooltip("The nav agent speed that matches the speed of the animation, used to scale the speed if moving faster or slower")]
	public float baseWalkSpeed = 5.5f;

	public float baseRunSpeed = 5.5f;

	public bool player;

	public List<GameObject> torches;

	public CameraController _cameraControl;

	private NavMeshAgent _agent;

	private CharacterDirections _previousDirection;

	private AnimationType _previousAnimation;

	private HashSet<AnimatorControllerParameter> _animParameters = new HashSet<AnimatorControllerParameter>();

	private AnimationChangedEventArgs _animationEventArgs;

	public AnimationType CurrentAnimation => _previousAnimation;

	public event EventHandler<AnimationChangedEventArgs> DirectionChanged;

	[Inject]
	public void Inject(CameraController cameraController)
	{
		_cameraControl = cameraController;
	}

	private void Awake()
	{
		_agent = GetComponent<NavMeshAgent>();
		_animationEventArgs = new AnimationChangedEventArgs();
		if (animators.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < animators.Count; i++)
		{
			if (!animators[i].activeInHierarchy)
			{
				continue;
			}
			Animator component = animators[i].GetComponent<Animator>();
			if (component.enabled)
			{
				AnimatorControllerParameter[] parameters = component.parameters;
				for (int j = 0; j < parameters.Length; j++)
				{
					_animParameters.Add(parameters[j]);
				}
			}
		}
	}

	private void Start()
	{
		_previousDirection = CharacterDirections.down_right;
		DisableAnimationEventFiring();
	}

	public void SetCharacterAnimation(AnimationType animType, CharacterDirections direction)
	{
		foreach (GameObject animator in animators)
		{
			if (!animator.activeInHierarchy)
			{
				continue;
			}
			Animator component = animator.GetComponent<Animator>();
			component.ClearTriggers(_animParameters);
			string text = "";
			text += animType;
			text += "_";
			if (player && animType == AnimationType.run && ((_previousDirection == CharacterDirections.left && direction == CharacterDirections.right) || (_previousDirection == CharacterDirections.right && direction == CharacterDirections.left)) && _previousAnimation == AnimationType.run)
			{
				text = "quickturn_";
			}
			switch (animType)
			{
			case AnimationType.scan:
				text += "h";
				SetCharacterDirection(direction);
				break;
			case AnimationType.deathFromBattery:
				text += "h";
				break;
			case AnimationType.eat:
				text += "down";
				break;
			default:
				switch (direction)
				{
				case CharacterDirections.front:
					text += "f";
					break;
				case CharacterDirections.back:
					text += "b";
					break;
				case CharacterDirections.left:
					text += "h";
					break;
				case CharacterDirections.right:
					text += "h";
					break;
				case CharacterDirections.down_left:
				case CharacterDirections.down_right:
					text += "down";
					break;
				case CharacterDirections.up_right:
				case CharacterDirections.up_left:
					text += "up";
					break;
				}
				break;
			case AnimationType.stab:
				break;
			}
			component.SetTrigger(text);
			if (player)
			{
				Events.RaiseEvent("PlayerAnimationTrigger", text);
			}
			_previousAnimation = animType;
			_previousDirection = direction;
		}
	}

	public void SetCharacterDirectionAndAnimation(Vector3 forward, AnimationType type)
	{
		float angleFromForward = GetAngleFromForward(forward);
		float characterHorizontalDirection = GetCharacterHorizontalDirection(forward);
		SetCharacterAnimation(type, GetCharacterDirection(angleFromForward, characterHorizontalDirection));
	}

	public void SetCharacterDirection(CharacterDirections direction)
	{
		_animationEventArgs.previousDirection = _previousDirection;
		_animationEventArgs.newDirection = direction;
		DirectionChanged?.Invoke(this, _animationEventArgs);
		int num = 1;
		if (direction == CharacterDirections.left || direction == CharacterDirections.down_left || direction == CharacterDirections.up_left)
		{
			num = -1;
		}
		foreach (GameObject animator in animators)
		{
			if ((num == -1 && animator.transform.localScale.x > 0f) || (num == 1 && animator.transform.localScale.x < 0f))
			{
				animator.transform.localScale = animator.transform.localScale.FlipAlongX();
			}
		}
	}

	public void SetCharacterSubAnimation(SubAnimationType animType)
	{
		foreach (GameObject animator in animators)
		{
			Animator component = animator.GetComponent<Animator>();
			switch (animType)
			{
			case SubAnimationType.torchOn:
			{
				for (int j = 0; j < torches.Count; j++)
				{
					torches[j].SetActive(value: true);
				}
				break;
			}
			case SubAnimationType.torchOff:
			{
				for (int i = 0; i < torches.Count; i++)
				{
					torches[i].SetActive(value: false);
				}
				break;
			}
			}
			if (animType == SubAnimationType.headLookBack)
			{
				component.SetTrigger("head_lookBack");
			}
			if (animType == SubAnimationType.headLookForward)
			{
				component.SetTrigger("head_lookForward");
			}
			if (animType == SubAnimationType.headLookRight)
			{
				component.SetTrigger("head_lookRight");
			}
			if (animType == SubAnimationType.headLookLeft)
			{
				component.SetTrigger("head_lookLeft");
			}
		}
	}

	public void SetAnimationSpeed(AnimationType animType)
	{
		foreach (GameObject animator in animators)
		{
			Animator component = animator.GetComponent<Animator>();
			if (component.HasParameter("run_speed", AnimatorControllerParameterType.Float, _animParameters))
			{
				float value = _agent.speed / baseRunSpeed;
				component.SetFloat("run_speed", value);
			}
		}
	}

	private void DisableAnimationEventFiring()
	{
		if (animators.Count > 1)
		{
			for (int i = 1; i < animators.Count; i++)
			{
				animators[i].GetComponent<Animator>().fireEvents = false;
			}
		}
	}

	public CharacterDirections GetCharacterDirection(float moveAngle, float horizontalDirection)
	{
		if (player)
		{
			if (moveAngle > 360f)
			{
				moveAngle %= 360f;
			}
			if (moveAngle >= 0f && moveAngle < 25f)
			{
				return CharacterDirections.back;
			}
			if (moveAngle >= 25f && moveAngle < 155f)
			{
				if (horizontalDirection == -1f)
				{
					return CharacterDirections.left;
				}
				return CharacterDirections.right;
			}
			if (moveAngle >= 155f)
			{
				_ = 180f;
				return CharacterDirections.front;
			}
			return CharacterDirections.front;
		}
		if (moveAngle > 360f)
		{
			moveAngle %= 360f;
		}
		if (moveAngle >= 0f && moveAngle < 90f)
		{
			if (horizontalDirection == -1f)
			{
				return CharacterDirections.up_left;
			}
			return CharacterDirections.up_right;
		}
		if (moveAngle >= 90f && moveAngle <= 180f)
		{
			if (horizontalDirection == -1f)
			{
				return CharacterDirections.down_left;
			}
			return CharacterDirections.down_right;
		}
		Debug.LogError("In Animation Controller - you got an angle above 180, which shouldn't be possible");
		return CharacterDirections.down_right;
	}

	public float GetCharacterHorizontalDirection(Vector3 moveDirection)
	{
		return Mathf.Sign(Vector3.Dot(Constants.UP, Vector3.Cross(Constants.FORWARD, moveDirection)));
	}

	public float GetAngleFromForward(Vector3 moveDirection)
	{
		return Vector3.Angle(moveDirection, Constants.FORWARD);
	}
}
