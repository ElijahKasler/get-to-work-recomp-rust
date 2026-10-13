using System;
using System.Collections.Generic;

namespace Isto.Core.AI;

[Serializable]
public class AIActionMapping
{
	public AIAction action;

	public List<AIConsideration> considerations;
}
