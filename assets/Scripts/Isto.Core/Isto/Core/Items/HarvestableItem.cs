using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

namespace Isto.Core.Items;

[CreateAssetMenu(fileName = "New Harvestable Item", menuName = "Scriptables/Item/HarvestableItem")]
public class HarvestableItem : Item
{
	[Header("Harvest Tool Tips")]
	public string missingRequiredItemTip;

	[Space(10f)]
	[Header("Harvest Settings")]
	[Tooltip("After you harvest, which items get dropped")]
	public List<ItemPile> droppedItems;

	[Space(10f)]
	[Header("Growing Params")]
	public float growingTime;

	[Tooltip("If harvested while growing, these items are dropped")]
	public List<ItemPile> droppedItemsWhileGrowing;

	[Tooltip("If set, resource will have infinite health so will never expire")]
	public bool infiniteResrouce;

	public float harvestHP = 50f;

	[Tooltip("The amount of health loss required to cause item to drop.  If set to zero, nothing will drop until all health is gone.")]
	public float harvestAmountPerItemDrop;

	public List<float> harvestHPVisualThresholds;

	public List<Sprite> visualStates;

	[Header("Audio")]
	[Tooltip("Sound played while item is being harvested")]
	[EventRef]
	public string harvestingSoundRef;

	[Tooltip("Does the audio loop? If not it'll just be played once everything item takes damage")]
	public bool harvestSoundIsLooping;

	[Tooltip("Sound played when Item is dropped.")]
	[EventRef]
	public string harvestDropItemSoundRef;

	[Tooltip("Sound played when Item is dropped.")]
	[EventRef]
	public string planterGrownSound;

	public override string GetToolTip(bool canHarvest)
	{
		if (canHarvest)
		{
			return base.GetToolTip(canHarvest);
		}
		return missingRequiredItemTip;
	}
}
