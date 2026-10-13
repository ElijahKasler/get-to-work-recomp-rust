using System;
using UnityEngine;

namespace Isto.Core.Items;

[Serializable]
public class AdvItemDropParameters
{
	public float height;

	public float dropTime;

	public AnimationCurve curve;

	public GameObject dropParticleObject;

	public Color invalidPositionColorTint = new Color(1f, 0f, 0f, 0.35f);

	[ColorUsage(true, true)]
	public Color invalidPositionColorEmission = new Color(1f, 0f, 0f, 0.35f);
}
