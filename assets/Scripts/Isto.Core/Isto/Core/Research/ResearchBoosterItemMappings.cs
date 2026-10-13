using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Research;

[CreateAssetMenu(fileName = "New Research Items Mappings", menuName = "Scriptables/Research/Research Item Mapping")]
public class ResearchBoosterItemMappings : ScriptableObject
{
	public List<BoosterItemRate> itemMappings;
}
