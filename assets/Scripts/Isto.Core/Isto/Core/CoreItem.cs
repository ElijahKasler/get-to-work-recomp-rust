using System.Collections.Generic;
using Isto.Core.Configuration;
using Isto.Core.Items;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Isto.Core;

[CreateAssetMenu(fileName = "New Core Item", menuName = "Scriptables/Item/CoreItem")]
public class CoreItem : Item
{
	[Header("--------------  Core Item")]
	public Sprite gameplaySprite;

	[SerializeField]
	[Tooltip("Recipe required to craft the item, if possible")]
	private Recipe _craftingRecipe;

	[Tooltip("If set, is used when the item is made via a factory instead of by the player")]
	[SerializeField]
	private Recipe _factoryCraftingRecipe;

	[Header("Emission")]
	public Texture emissionSprite;

	public float emissionFactor;

	public Color emissionTint;

	[Header("Harvesting")]
	public HarvestableItem harvestableSource;

	public bool fromHarvestableItem;

	[Header("Systems Interactions")]
	public bool flammable;

	public List<ItemPile> flammableItemDrops;

	public float fireDropSpread;

	[Header("For Internal Use")]
	[Tooltip("Used in DevMode Scene to calculate base resource amounts")]
	public bool baseLevelItem;

	public bool hasSeedItem;

	[Header("Display Override")]
	public AssetReference coreItemAssetOverride;

	[Header("Special Unlock Conditions")]
	[Tooltip("The item will always be considered locked in these game modes")]
	public GameModeDefinition[] forbiddenGameModes;

	public void Consumed()
	{
	}

	protected virtual GameObject DropItem(Vector3 position, Transform parent, int count = 1)
	{
		GameObject gameObject = CreateItemFromPrefab(prefab, position, count);
		gameObject.name = base.itemName;
		gameObject.transform.SetParent(parent);
		InstallSystems(gameObject);
		IActivatable[] components = gameObject.GetComponents<IActivatable>();
		for (int i = 0; i < components.Length; i++)
		{
			components[i].Activate();
		}
		return gameObject;
	}

	public virtual GameObject DropItem(Vector3 position, Transform parent = null, int count = 1, bool autoCollect = false)
	{
		GameObject gameObject = DropItem(position, parent, count);
		if (gameObject.TryGetComponent<ItemSpawnBehaviour>(out var component))
		{
			component.StartItemBounce(playerCollectAfterBounce: true);
		}
		return gameObject;
	}

	protected GameObject CreateItemFromPrefab(GameObject itemPrefab, Vector3 position, int count = 1)
	{
		GameObject gameObject = Object.Instantiate(itemPrefab, position, Quaternion.identity, null);
		ItemController component = gameObject.GetComponent<ItemController>();
		if (component != null)
		{
			component.SetItem(this, count);
			component.SetPropertyBlockSet(emissionSprite, emissionFactor, emissionTint);
		}
		return gameObject;
	}

	public void SetRecipe(Recipe recipe)
	{
		_craftingRecipe = recipe;
	}

	public bool ForbiddenForCurrentGameMode(GameModeDefinition mode)
	{
		if (forbiddenGameModes == null)
		{
			return false;
		}
		if (forbiddenGameModes.Length == 0)
		{
			return false;
		}
		for (int i = 0; i < forbiddenGameModes.Length; i++)
		{
			if (mode == null)
			{
				Debug.LogError("game mode is missing for this particular scene. Make sure to assign this scene a game mode in scene settings mapping");
				return false;
			}
			if (forbiddenGameModes[i].InternalName == mode.InternalName)
			{
				return true;
			}
		}
		return false;
	}

	public Recipe GetRecipe(bool isMiniDeerFactory = false)
	{
		if (isMiniDeerFactory && _factoryCraftingRecipe != null)
		{
			return _factoryCraftingRecipe;
		}
		return _craftingRecipe;
	}

	private void InstallSystems(GameObject newItem)
	{
		if (flammable)
		{
			Flammable obj = newItem.AddComponent<Flammable>();
			obj.itemDrops = flammableItemDrops;
			obj.dropSpread = fireDropSpread;
		}
	}

	public static bool AreEqual(CoreItem itemA, CoreItem itemB)
	{
		if (itemA == null && itemB == null)
		{
			return true;
		}
		if (itemA == null || itemB == null)
		{
			return false;
		}
		return itemA.itemID.Equals(itemB.itemID);
	}
}
