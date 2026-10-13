using Isto.Core.Items;
using UnityEngine;

namespace Isto.Core.Research;

public class BuildingLevel : MonoBehaviour
{
	[SerializeField]
	private Recipe[] _upgradeRecipes;

	public int Level { get; private set; }

	public Recipe[] UpgradeRecipies => _upgradeRecipes;

	private void Awake()
	{
		Level = 1;
	}

	public void SetStartLevel(int level)
	{
		Level = ((level <= 0) ? 1 : level);
	}

	public void IncreaseLevel()
	{
		Level++;
	}

	public bool TryGetUpgradeRecipe(out Recipe recipe)
	{
		if (Level <= _upgradeRecipes.Length)
		{
			recipe = _upgradeRecipes[Level - 1];
			return true;
		}
		recipe = null;
		return false;
	}

	public bool CanUpgrade(ItemContainer inventory)
	{
		if (TryGetUpgradeRecipe(out var recipe))
		{
			return Recipe.CanMakeRecipe(recipe, inventory);
		}
		return false;
	}
}
