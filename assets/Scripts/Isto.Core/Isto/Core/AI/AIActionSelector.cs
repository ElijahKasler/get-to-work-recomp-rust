using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.AI;

public abstract class AIActionSelector
{
	public abstract AIAction SelectNextAction(List<AIAction> behaviours, AIAction currentAction, AIAction previousAction, GameObject mob);
}
