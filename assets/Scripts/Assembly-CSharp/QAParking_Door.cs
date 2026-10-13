using UnityEngine;

public class QAParking_Door : MonoBehaviour
{
	private Animation anim;

	public float AnimSpeed = 1f;

	private string _animName;

	private void Start()
	{
		anim = GetComponent<Animation>();
		_animName = anim.clip.name;
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Collider>().tag == "Player")
		{
			anim[_animName].speed = 1f * AnimSpeed;
			anim[_animName].normalizedTime = 0f;
			anim.Play();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<Collider>().tag == "Player")
		{
			anim[_animName].speed = -1f * AnimSpeed;
			if (anim[_animName].normalizedTime > 0f)
			{
				anim[_animName].normalizedTime = anim[_animName].normalizedTime;
			}
			else
			{
				anim[_animName].normalizedTime = 1f;
			}
			anim.Play();
		}
	}
}
