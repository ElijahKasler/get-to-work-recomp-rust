using System;
using System.Xml.Serialization;
using Isto.Core.Automation;
using UnityEngine;

namespace Isto.Core.Data;

[Serializable]
[XmlInclude(typeof(AutomationHarvesterData))]
[XmlInclude(typeof(AutomationItemMoverData))]
[XmlInclude(typeof(AutomationItemSinglePullerData))]
[XmlInclude(typeof(AutomationItemPusherData))]
[XmlInclude(typeof(AutomationFactoryData))]
[XmlInclude(typeof(AutomationResearchBoosterData))]
[XmlInclude(typeof(ResearchBoosts))]
[XmlInclude(typeof(AutomationItemContainerData))]
[XmlInclude(typeof(AutomationPlanterData))]
[XmlInclude(typeof(AutomationItemPullerData))]
[XmlInclude(typeof(AutomationCreatureHiveData))]
[XmlInclude(typeof(AutomationItemDispenserData))]
public class AutomationProcessorData
{
	public string typeId;

	public Vector3 direction;

	public Vector3 position;

	public bool visible = true;

	public override bool Equals(object obj)
	{
		if (!(obj is AutomationProcessorData automationProcessorData))
		{
			return false;
		}
		if (!typeId.IsEqualWithNullsAsEmpty(automationProcessorData.typeId))
		{
			return false;
		}
		if (direction != automationProcessorData.direction)
		{
			return false;
		}
		if (position != automationProcessorData.position)
		{
			return false;
		}
		return visible == automationProcessorData.visible;
	}

	public override int GetHashCode()
	{
		return (typeId, direction, position, visible).GetHashCode();
	}
}
