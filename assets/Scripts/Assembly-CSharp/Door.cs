using UnityEngine;

public class Door : MonoBehaviour
{
	private Animation anim;

	public float OpenSpeed = 1f;

	public float CloseSpeed = 1f;

	public bool isAutomatic;

	public bool AutoClose;

	public bool DoubleSidesOpen;

	public string PlayerHeadTag = "MainCamera";

	public string OpenForwardAnimName = "Door_anim";

	public string OpenBackwardAnimName = "DoorBack_anim";

	private string _animName;

	private bool inTrigger;

	private bool isOpen;

	private Vector3 relativePos;

	private void Start()
	{
		anim = GetComponent<Animation>();
		_animName = anim.clip.name;
	}

	private void Update()
	{
		if (inTrigger && Input.GetKeyDown(KeyCode.E) && !isAutomatic)
		{
			if (!isOpen)
			{
				isOpen = true;
				OpenDoor();
			}
			else
			{
				isOpen = false;
				CloseDoor();
			}
		}
	}

	private void OpenDoor()
	{
		anim[_animName].speed = 1f * OpenSpeed;
		anim[_animName].normalizedTime = 0f;
		anim.Play(_animName);
	}

	private void CloseDoor()
	{
		anim[_animName].speed = -1f * CloseSpeed;
		if (anim[_animName].normalizedTime > 0f)
		{
			anim[_animName].normalizedTime = anim[_animName].normalizedTime;
		}
		else
		{
			anim[_animName].normalizedTime = 1f;
		}
		anim.Play(_animName);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!(other.GetComponent<Collider>().tag == PlayerHeadTag))
		{
			return;
		}
		if (DoubleSidesOpen)
		{
			relativePos = base.gameObject.transform.InverseTransformPoint(other.transform.position);
			if (relativePos.z > 0f)
			{
				_animName = OpenForwardAnimName;
			}
			else
			{
				_animName = OpenBackwardAnimName;
			}
		}
		if (isAutomatic)
		{
			OpenDoor();
		}
		inTrigger = true;
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<Collider>().tag == PlayerHeadTag)
		{
			if (isAutomatic)
			{
				CloseDoor();
			}
			else
			{
				inTrigger = false;
			}
			if (AutoClose && isOpen)
			{
				CloseDoor();
				inTrigger = false;
				isOpen = false;
			}
		}
	}
}
