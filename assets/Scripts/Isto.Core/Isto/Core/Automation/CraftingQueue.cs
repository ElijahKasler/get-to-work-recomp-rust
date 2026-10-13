using System;
using System.Collections.Generic;
using FMODUnity;
using Isto.Core.Audio;
using Isto.Core.Beings;
using Isto.Core.Items;
using Isto.Core.UI;
using UnityEngine;
using Zenject;

namespace Isto.Core.Automation;

[RequireComponent(typeof(ItemContainer))]
public class CraftingQueue : MonoBehaviour
{
	public int maxQueueLength = 10;

	[EventRef]
	public string itemCraftedSoundRef;

	private IUIMessages _uiMessages;

	private IGameSounds _sounds;

	private List<Recipe> _queuedRecipes;

	private ItemContainer _inventory;

	private Recipe _currentRecipe;

	private float _cookTimer;

	public float CurrentProgress
	{
		get
		{
			if (!(_currentRecipe == null))
			{
				return _cookTimer / _currentRecipe.cookTime;
			}
			return 0f;
		}
	}

	public float CurrentCookTime
	{
		get
		{
			if (!(_currentRecipe == null))
			{
				return _currentRecipe.cookTime;
			}
			return 0f;
		}
	}

	public float CookSpeedMultiplier { get; set; } = 1f;

	public event EventHandler<ItemEventArgs> ItemCrafted;

	[Inject]
	public void Inject([Inject(Id = UIMessageHandlerType.ProgressMessage)] IUIMessages uIMessages, IGameSounds gameSounds)
	{
		_uiMessages = uIMessages;
		_sounds = gameSounds;
	}

	private void Awake()
	{
		_queuedRecipes = new List<Recipe>();
		_inventory = GetComponent<ItemContainer>();
	}

	private void Update()
	{
		if (_currentRecipe == null && _queuedRecipes.Count > 0)
		{
			StartNextRecipe();
		}
		if (_currentRecipe != null)
		{
			Cook();
		}
	}

	private void StartNextRecipe()
	{
		_currentRecipe = _queuedRecipes[0];
		_queuedRecipes.RemoveAt(0);
		_cookTimer = 0f;
		_ = _currentRecipe.outputs[0].item;
	}

	public bool EnqueueRecipe(Recipe recipe)
	{
		if (_queuedRecipes.Count >= maxQueueLength)
		{
			return false;
		}
		_queuedRecipes.Add(recipe);
		_uiMessages.CreateProgressMessage(recipe.outputs[0].item.itemName, this, recipe.outputs[0].item.icon);
		return true;
	}

	public bool HasRecipeInQueue(Recipe recipe)
	{
		if (_queuedRecipes.Contains(recipe) || _currentRecipe == recipe)
		{
			return true;
		}
		return false;
	}

	private void Cook()
	{
		_cookTimer += Time.deltaTime * CookSpeedMultiplier;
		if (!(_cookTimer > _currentRecipe.cookTime) || !_inventory.HasSpaceFor(_currentRecipe.outputs))
		{
			return;
		}
		for (int i = 0; i < _currentRecipe.outputs.Count; i++)
		{
			ItemPile itemPile = _currentRecipe.outputs[i];
			if (itemPile.item.GetType() != typeof(UpgradeItem))
			{
				_inventory.Add(itemPile);
			}
		}
		_sounds.PlayOneShot(itemCraftedSoundRef, base.transform.position);
		ItemCrafted?.Invoke(this, new ItemEventArgs(_inventory, _currentRecipe.outputs[0].item));
		_currentRecipe = null;
		_cookTimer = 0f;
	}

	public List<string> GetAllRecipesInQueue()
	{
		List<string> list = new List<string>();
		if (_currentRecipe != null)
		{
			list.Add(_currentRecipe.outputs[0].item.itemID);
		}
		foreach (Recipe queuedRecipe in _queuedRecipes)
		{
			list.Add(queuedRecipe.outputs[0].item.itemID);
		}
		return list;
	}

	public void ForceRecipeIntoCraftingQueue(Recipe recipe)
	{
		_queuedRecipes.Add(recipe);
		_uiMessages.CreateProgressMessage(recipe.outputs[0].item.itemName, this, recipe.outputs[0].item.icon);
	}

	public bool TryCancelQueueItem(int index)
	{
		Recipe recipe;
		if (index == 0)
		{
			if (_currentRecipe == null)
			{
				return false;
			}
			recipe = _currentRecipe;
		}
		else
		{
			int num = index - 1;
			if (num < 0 || num >= _queuedRecipes.Count)
			{
				Debug.LogWarning("Index out of range for trying to cancel item in Crafting Queue. Index: " + num);
				return false;
			}
			recipe = _queuedRecipes[num];
		}
		if (_inventory.HasSpaceFor(recipe.inputs))
		{
			for (int i = 0; i < recipe.inputs.Count; i++)
			{
				_inventory.Add(recipe.inputs[i]);
			}
			if (index == 0)
			{
				_currentRecipe = null;
				_cookTimer = 0f;
			}
			else
			{
				_queuedRecipes.RemoveAt(index - 1);
			}
			return true;
		}
		if (_inventory is PlayerInventory playerInventory)
		{
			_sounds.PlayOneShot(playerInventory.fullInventorySoundRef, playerInventory.transform.position);
		}
		return false;
	}
}
