using System;

namespace Isto.Core.AI;

[Serializable]
public class AIConsiderationResult
{
	public float multiplier = 1f;

	public float weight = 1f;

	public AIConsiderationResult()
	{
		weight = 0f;
		multiplier = 0f;
	}

	public AIConsiderationResult(float weight, float multiplier)
	{
		this.weight = weight;
		this.multiplier = multiplier;
	}

	public void Clear()
	{
		multiplier = 1f;
		weight = 0f;
	}
}
