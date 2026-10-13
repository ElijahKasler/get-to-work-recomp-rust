using System;
using FMODUnity;
using UnityEngine;

namespace LevelFeatures.PhysicsProp;

public class PropImpactAudio : MonoBehaviour
{
	[Serializable]
	private struct ImpactAudioRef
	{
		public float impulse;

		[EventRef]
		public string _sfxRef;
	}

	[SerializeField]
	private ImpactAudioRef[] _impactAudio = new ImpactAudioRef[1];

	private void OnCollisionEnter(Collision other)
	{
		Impact(other.impulse.magnitude, other.contacts[0].point);
	}

	private void Impact(float hitImpulse, Vector3 position)
	{
		for (int num = _impactAudio.Length - 1; num >= 0; num--)
		{
			if (hitImpulse > _impactAudio[num].impulse)
			{
				RuntimeManager.PlayOneShot(_impactAudio[num]._sfxRef, position);
				break;
			}
		}
	}
}
