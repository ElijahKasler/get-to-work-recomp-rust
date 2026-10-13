using System.Collections.Generic;
using UnityEngine;

namespace Isto.GTW.Configuration;

[CreateAssetMenu(fileName = "Scriptables/New GTW Doinkler Portfolio Definition", menuName = "Scriptables/New GTW Doinkler Portfolio Definition")]
public class GTWDoinklerPortfolioDefinition : ScriptableObject
{
	public List<GTWGameWorldDefinition> GTWGameWorldDefinitions;
}
