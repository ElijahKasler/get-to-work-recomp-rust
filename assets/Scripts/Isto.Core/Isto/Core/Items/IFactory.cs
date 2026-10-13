using Isto.Core.Automation;
using UnityEngine;

namespace Isto.Core.Items;

public interface IFactory
{
	Recipe Recipe { get; }

	float CookProgress { get; }

	IInventory Inventory { get; }

	string FactoryName { get; }

	Color FactoryPanelTopHeader { get; }

	Color FactoryPanelTopHeaderHighlighted { get; }

	Color FactoryPanelTopTitle { get; }

	Color FactoryPanelTopTitleHighlighted { get; }

	Color FactoryPanelBackground { get; }

	Color FactoryPanelRecipeSelection { get; }

	void SetRecipe(Recipe recipe);

	CategoryList GetCategoryList();
}
