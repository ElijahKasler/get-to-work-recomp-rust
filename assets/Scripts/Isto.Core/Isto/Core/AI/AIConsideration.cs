using UnityEngine;

namespace Isto.Core.AI;

public abstract class AIConsideration : ScriptableObject
{
	public abstract AIConsiderationResult Evaluate(GameObject mob, AIAction action);
}
