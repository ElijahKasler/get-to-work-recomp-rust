using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Isto.Core.Audio;
using Isto.Core.Beings;
using Isto.Core.Items;
using UnityEngine;

namespace Isto.Core;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Scriptables/Item/Recipe")]
public class Recipe : ScriptableObject
{
	public List<ItemPile> inputs;

	public List<ItemPile> outputs;

	[Tooltip("Time it takes to drop the outputs once the recipe ingredients are available")]
	public float cookTime = 1f;

	public Recipe()
	{
		inputs = new List<ItemPile>();
		inputs.Add(new ItemPile(null, 1));
		inputs.Add(new ItemPile(null, 1));
		outputs = new List<ItemPile>();
		outputs.Add(new ItemPile(null, 1));
	}

	public bool IsIngredient(CoreItem item)
	{
		for (int i = 0; i < inputs.Count; i++)
		{
			if (inputs[i].item == item)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsIngredient(string itemID)
	{
		for (int i = 0; i < inputs.Count; i++)
		{
			if (inputs[i].item.itemID == itemID)
			{
				return true;
			}
		}
		return false;
	}

	public static Recipe FindValidRecipe(ItemPile input, List<Recipe> recipes)
	{
		for (int i = 0; i < recipes.Count; i++)
		{
			Recipe recipe = recipes[i];
			if (recipe.inputs.Count == 1)
			{
				ItemPile itemPile = recipe.inputs[0];
				if (itemPile.item == input.item && itemPile.count == input.count)
				{
					return recipe;
				}
			}
		}
		return null;
	}

	public static Recipe FindValidRecipe(CoreItem input, List<Recipe> recipes)
	{
		for (int i = 0; i < recipes.Count; i++)
		{
			Recipe recipe = recipes[i];
			if (recipe.inputs.Count == 1)
			{
				ItemPile itemPile = recipe.inputs[0];
				if (itemPile.item == input && itemPile.count == 1)
				{
					return recipe;
				}
			}
		}
		return null;
	}

	public static Recipe FindValidRecipe(List<ItemPile> inputs, List<Recipe> recipes)
	{
		for (int i = 0; i < recipes.Count; i++)
		{
			Recipe recipe = recipes[i];
			bool flag = true;
			for (int j = 0; j < recipe.inputs.Count; j++)
			{
				ItemPile itemPile = recipe.inputs[j];
				bool flag2 = false;
				for (int k = 0; k < inputs.Count; k++)
				{
					flag2 |= inputs[k].item == itemPile.item && inputs[k].count >= itemPile.count;
				}
				flag &= flag2;
			}
			if (flag)
			{
				return recipe;
			}
		}
		return null;
	}

	public static IEnumerator CookRecipeAndDropItems(Recipe recipe, Transform cookTransform, IGameSounds sounds, float randomSpacing, float delayBetweenItems = 0.2f)
	{
		yield return new WaitForSeconds(recipe.cookTime);
		WaitForSeconds delayBetweenItemDrops = new WaitForSeconds(delayBetweenItems);
		for (int i = 0; i < recipe.outputs.Count; i++)
		{
			ItemPile itemPile = recipe.outputs[i];
			for (int j = 0; j < itemPile.count; j++)
			{
				Vector3 position = cookTransform.position + UnityEngine.Random.insideUnitSphere * randomSpacing;
				position.y = 0f;
				itemPile.item.DropItem(position);
				yield return delayBetweenItemDrops;
			}
		}
	}

	public static bool CanMakeRecipe(Recipe recipe, ItemContainer container)
	{
		if (recipe == null)
		{
			return false;
		}
		for (int i = 0; i < recipe.inputs.Count; i++)
		{
			int countOfItem = container.GetCountOfItem(recipe.inputs[i].item);
			int count = recipe.inputs[i].count;
			if (countOfItem < count)
			{
				return false;
			}
		}
		return true;
	}

	public static bool CanMakeRecipe(Recipe recipe, List<ItemPile> items)
	{
		for (int i = 0; i < recipe.inputs.Count; i++)
		{
			int num = 0;
			for (int j = 0; j < items.Count; j++)
			{
				if (items[i].item == recipe.inputs[i].item)
				{
					num += items[i].count;
				}
			}
			int count = recipe.inputs[i].count;
			if (num < count)
			{
				return false;
			}
		}
		return true;
	}

	public static void RemoveRecipeIngredients(Recipe recipe, PlayerInventory container)
	{
		container.DisableEventFiring();
		if (!CanMakeRecipe(recipe, container))
		{
			Debug.LogError("Trying to remove recipe inputs from container on:" + container.gameObject.name + " but there isn't all items in container.  This shouldn't happen.  Recipe:" + recipe.name);
			return;
		}
		for (int i = 0; i < recipe.inputs.Count; i++)
		{
			int num = recipe.inputs[i].count;
			while (num > 0)
			{
				int smallestStackIndexForItem = GetSmallestStackIndexForItem(recipe.inputs[i].item, container);
				int count = container.RemoveAt(smallestStackIndexForItem, recipe.inputs[i].count).count;
				num -= count;
				if (count == 0 && num > 0 && count != recipe.inputs[i].count)
				{
					Debug.LogError("unable to remove expected amount from inventory for recipe, recipe.canmakerecipe should've caught this");
				}
			}
		}
		container.EnableEventFiring();
	}

	private static int GetSmallestStackIndexForItem(CoreItem item, PlayerInventory container)
	{
		int result = -1;
		int num = int.MaxValue;
		for (int i = 0; i < container.Items.Count; i++)
		{
			if (container.Items[i].item == item && container.Items[i].count <= num)
			{
				result = i;
				num = container.Items[i].count;
			}
		}
		return result;
	}

	public static void AddRecipeIngredients(Recipe recipe, PlayerInventory container)
	{
		container.DisableEventFiring();
		for (int i = 0; i < recipe.inputs.Count; i++)
		{
			if (container.Add(recipe.inputs[i].item, recipe.inputs[i].count) != recipe.inputs[i].count)
			{
				Debug.LogError("Unable to add expected amount to inventory for recipe, This should only be called to put items back into inventory if queuing fails");
			}
		}
		container.EnableEventFiring();
	}

	public static bool operator ==(Recipe a, Recipe b)
	{
		if ((object)a == null && (object)b == null)
		{
			return true;
		}
		if ((object)a == null || (object)b == null)
		{
			return false;
		}
		return a.Equals(b);
	}

	public static bool operator !=(Recipe a, Recipe b)
	{
		return !(a == b);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object other)
	{
		if (other == null)
		{
			return false;
		}
		if (other is Recipe recipe)
		{
			for (int i = 0; i < recipe.inputs.Count; i++)
			{
				if (i >= inputs.Count)
				{
					return false;
				}
				if (!recipe.inputs[i].item.itemID.Equals(inputs[i].item.itemID, StringComparison.CurrentCultureIgnoreCase))
				{
					return false;
				}
			}
			for (int j = 0; j < recipe.outputs.Count; j++)
			{
				if (j >= outputs.Count)
				{
					return false;
				}
				if (!recipe.outputs[j].item.itemID.Equals(outputs[j].item.itemID, StringComparison.CurrentCultureIgnoreCase))
				{
					return false;
				}
			}
			return true;
		}
		return base.Equals(other);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("Recipe" + base.name + " takes in ");
		foreach (ItemPile input in inputs)
		{
			stringBuilder.Append(input.count + " " + input.item.itemID);
		}
		stringBuilder.Append(" and produces ");
		foreach (ItemPile output in outputs)
		{
			stringBuilder.Append(output.count + " " + output.item.itemID);
		}
		stringBuilder.Append(" in " + cookTime + " seconds.");
		return stringBuilder.ToString();
	}
}
