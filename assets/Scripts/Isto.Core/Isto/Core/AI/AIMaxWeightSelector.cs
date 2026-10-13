using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.AI;

public class AIMaxWeightSelector : AIActionSelector
{
	private List<AIActionUtility> _evaulationResults = new List<AIActionUtility>();

	private List<AIActionUtility> _filterBuffer = new List<AIActionUtility>();

	public override AIAction SelectNextAction(List<AIAction> behaviours, AIAction activeAction, AIAction previousAction, GameObject mob)
	{
		_evaulationResults.Clear();
		int count = behaviours.Count;
		for (int i = 0; i < count; i++)
		{
			AIActionUtility highestConsiderationResultForAction = GetHighestConsiderationResultForAction(behaviours[i], activeAction, previousAction, mob);
			_evaulationResults.Add(highestConsiderationResultForAction);
		}
		List<AIActionUtility> list = FilterResultsList(_evaulationResults, 0.8f);
		if (list.Count == 0)
		{
			throw new UnityException("No possible action for AI, something is wrong");
		}
		return ChooseRandomAction(list);
	}

	private AIAction ChooseRandomAction(List<AIActionUtility> actions)
	{
		float num = 0f;
		for (int i = 0; i < actions.Count; i++)
		{
			num += actions[i].weight * actions[i].multiplier;
		}
		float num2 = Random.value * num;
		AIAction aIAction = null;
		for (int j = 0; j < actions.Count; j++)
		{
			float num3 = actions[j].weight * actions[j].multiplier;
			if (num2 < num3)
			{
				aIAction = actions[j].action;
				break;
			}
			num2 -= num3;
		}
		if (aIAction == null)
		{
			aIAction = actions[actions.Count - 1].action;
		}
		return aIAction;
	}

	public AIActionUtility GetHighestConsiderationResultForAction(AIAction actionToEvaluate, AIAction current, AIAction previous, GameObject mob)
	{
		float num = 0f;
		float num2 = 1f;
		for (int i = 0; i < actionToEvaluate.considerations.Count; i++)
		{
			AIConsiderationResult aIConsiderationResult = actionToEvaluate.considerations[i].Evaluate(mob, actionToEvaluate);
			if (num < aIConsiderationResult.weight)
			{
				num = aIConsiderationResult.weight;
			}
			num2 *= aIConsiderationResult.multiplier;
			if (num2 == 0f)
			{
				break;
			}
		}
		if (actionToEvaluate == current)
		{
			num += actionToEvaluate.interia;
		}
		return new AIActionUtility
		{
			action = actionToEvaluate,
			weight = num,
			multiplier = num2
		};
	}

	public List<AIActionUtility> FilterResultsList(List<AIActionUtility> results, float minPercent)
	{
		float num = 0f;
		for (int i = 0; i < results.Count; i++)
		{
			float num2 = results[i].weight * results[i].multiplier;
			if (num2 > num)
			{
				num = num2;
			}
		}
		float num3 = num * minPercent;
		_filterBuffer.Clear();
		for (int j = 0; j < results.Count; j++)
		{
			AIActionUtility item = results[j];
			if (item.multiplier != 0f && item.weight * item.multiplier > num3)
			{
				_filterBuffer.Add(item);
			}
		}
		return _filterBuffer;
	}
}
