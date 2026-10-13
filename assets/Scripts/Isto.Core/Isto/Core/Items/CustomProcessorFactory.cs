using System.Collections.Generic;
using System.Linq;
using Isto.Core.Automation;
using Isto.Core.Data;
using Isto.Core.Research;
using UnityEngine;
using Zenject;

namespace Isto.Core.Items;

public class CustomProcessorFactory : IFactory<AutomationProcessorData, IItemProcessor>, Zenject.IFactory
{
	private DiContainer _container;

	public CustomProcessorFactory(DiContainer container)
	{
		_container = container;
	}

	public IItemProcessor Create(AutomationProcessorData param)
	{
		if (!(param is AutomationHarvesterData automationHarvesterData))
		{
			if (!(param is AutomationItemPusherData automationItemPusherData))
			{
				if (!(param is AutomationItemSinglePullerData automationItemSinglePullerData))
				{
					if (!(param is AutomationItemMoverData automationItemMoverData))
					{
						if (!(param is AutomationFactoryData automationFactoryData))
						{
							if (!(param is AutomationItemContainerData automationItemContainerData))
							{
								if (!(param is AutomationPlanterData data))
								{
									if (!(param is AutomationItemPullerData automationItemPullerData))
									{
										if (!(param is AutomationResearchBoosterData automationResearchBoosterData))
										{
											if (!(param is AutomationCreatureHiveData automationCreatureHiveData))
											{
												if (param is AutomationItemDispenserData automationItemDispenserData)
												{
													AutomationItemDispenser automationItemDispenser = _container.Resolve<AutomationItemDispenser.Factory>().Create(new AutomationItemDispenser.ItemDispenserParams(automationItemDispenserData.typeId, automationItemDispenserData.inventoryPileCount, automationItemDispenserData.inventoryPileSize, automationItemDispenserData.timePerDrop, automationItemDispenserData.timeToNextDrop, automationItemDispenserData.direction));
													automationItemDispenser.LoadData(automationItemDispenserData);
													return automationItemDispenser;
												}
												AutomationGenericProcessor automationGenericProcessor = _container.Resolve<AutomationGenericProcessor.Factory>().Create(param.typeId);
												automationGenericProcessor.LoadData(param);
												return automationGenericProcessor;
											}
											AutomationCreatureHive automationCreatureHive = _container.Resolve<AutomationCreatureHive.Factory>().Create(new AutomationCreatureHiveParams(automationCreatureHiveData.typeId, automationCreatureHiveData.creatureAssetGUID, automationCreatureHiveData.stockpiledItemID, automationCreatureHiveData.inventoryPileCount, automationCreatureHiveData.inventoryPileSize, automationCreatureHiveData.maxCreatureCount, automationCreatureHiveData.timePerSapwn, automationCreatureHiveData.creatureRange, automationCreatureHiveData.itemDroppingPosition, automationCreatureHiveData.direction));
											automationCreatureHive.LoadData(automationCreatureHiveData);
											automationCreatureHive.SpawnInitialCreatures(automationCreatureHiveData.currentCreaturesData);
											return automationCreatureHive;
										}
										AutomationResearchBooster automationResearchBooster = _container.Resolve<AutomationResearchBooster.Factory>().Create(new AutomationResearchBoosterParams(researcher: _container.Resolve<PlayerResearchModule>(), mappings: _container.Resolve<ResearchBoosterItemMappings>(), ID: automationResearchBoosterData.typeId));
										automationResearchBooster.LoadData(automationResearchBoosterData);
										return automationResearchBooster;
									}
									AutomationItemPuller automationItemPuller = _container.Resolve<AutomationItemPuller.Factory>().Create(new AutomationItemPullerParams
									{
										ID = automationItemPullerData.typeId,
										forward = automationItemPullerData.direction,
										validResources = automationItemPullerData.affectedHarvestableItemIDs.ToList()
									});
									automationItemPuller.LoadData(automationItemPullerData);
									return automationItemPuller;
								}
								AutomationPlanter automationPlanter = _container.Resolve<AutomationPlanter.Factory>().Create(AutomationPlanterData.GetParamsFromData(_container.Resolve<MasterItemList>(), data));
								automationPlanter.LoadData(data);
								return automationPlanter;
							}
							AutomationItemContainer automationItemContainer = _container.Resolve<AutomationItemContainer.Factory>().Create(new AutomationItemContainerParams(automationItemContainerData.inventoryPileCount, automationItemContainerData.inventoryPileSize, automationItemContainerData.typeId, automationItemContainerData.isRigidInventory, automationItemContainerData.pullsItemsFromNeighbors));
							automationItemContainer.LoadData(automationItemContainerData);
							return automationItemContainer;
						}
						List<Vector3> footprintForAutomationFactory = GetFootprintForAutomationFactory(automationFactoryData.typeId, automationFactoryData.direction);
						AutomationFactory automationFactory = _container.Resolve<AutomationFactory.Factory>().Create(new AutomationFactoryParams(recipe: _container.Resolve<MasterItemList>().GetItemByID<CoreItem>(automationFactoryData.recipeItemId).GetRecipe(), pileCount: AutomationFactory.FACTORY_PILE_COUNT, pileSize: AutomationFactory.FACTORY_PILE_SIZE, id: automationFactoryData.typeId, footPrint: footprintForAutomationFactory));
						automationFactory.LoadData(automationFactoryData);
						return automationFactory;
					}
					AutomationItemMover automationItemMover = _container.Resolve<AutomationItemMover.Factory>().Create(automationItemMoverData.distance, automationItemMoverData.moveType, automationItemMoverData.typeId);
					automationItemMover.LoadData(automationItemMoverData);
					return automationItemMover;
				}
				AutomationItemSinglePuller automationItemSinglePuller = _container.Resolve<AutomationItemSinglePuller.Factory>().Create(automationItemSinglePullerData.distance, automationItemSinglePullerData.moveType, automationItemSinglePullerData.typeId);
				automationItemSinglePuller.LoadData(automationItemSinglePullerData);
				return automationItemSinglePuller;
			}
			AutomationItemPusher automationItemPusher = _container.Resolve<AutomationItemPusher.Factory>().Create(new AutomationItemPusherParams(automationItemPusherData.distance, automationItemPusherData.pushInterval, automationItemPusherData.currentCount, automationItemPusherData.typeId));
			automationItemPusher.LoadData(automationItemPusherData);
			return automationItemPusher;
		}
		AutomationHarvester automationHarvester = _container.Resolve<AutomationHarvester.Factory>().Create(new AutomationHarvesterParams(automationHarvesterData.harvesterDPS, automationHarvesterData.typeId, automationHarvesterData.destroyOnHarvestComplete));
		automationHarvester.LoadData(automationHarvesterData);
		return automationHarvester;
	}

	public static List<Vector3> GetFootprintForAutomationFactory(string itemID, Vector3 direction)
	{
		List<Vector3> footprintTilePositions = new List<Vector3>();
		switch (itemID)
		{
		case "MiniDeerCaptured_v2":
			AutomationFactory.GetMiniDeerFootprint(direction, ref footprintTilePositions);
			break;
		case "Factory_v2":
		case "ElectronicsFactory_V2":
		case "Smelter_v2":
			AutomationFactory.GetFootprint(direction, ref footprintTilePositions);
			break;
		}
		return footprintTilePositions;
	}
}
