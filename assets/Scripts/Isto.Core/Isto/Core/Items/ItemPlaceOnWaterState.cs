using UnityEngine;

namespace Isto.Core.Items;

public class ItemPlaceOnWaterState : ItemRotateByEnableChildState, IAnimatorProvider
{
	protected override bool AtValidDropPosition()
	{
		if (!base.AtValidDropPosition())
		{
			return false;
		}
		bool flag = true;
		if (_itemComponent.itemPile.item is AdvancedItem advancedItem)
		{
			int num = (int)advancedItem.depth;
			Vector3 position = base.transform.position + Constants.GRID_CENTERING_OFFSET;
			for (int i = 0; i < num; i++)
			{
				flag &= IsOverWater(position);
				position -= _controller.Forward;
			}
			if (flag)
			{
				return true;
			}
		}
		_setMaterialState.SetMaterialTint(_setMaterialState.invalidPlaceTint, _setMaterialState.invalidPlaceEmission);
		return false;
	}

	private bool IsOverWater(Vector3 position)
	{
		return _tilemapController.GetGroundTypeForPosition(base.transform.position) == Environment.GroundType.BloodWater;
	}

	public override void HandleRotation(int direction)
	{
		base.HandleRotation(direction);
	}

	public Animator GetAnimator()
	{
		GameObject gameObject = (directionOne.gameObject.activeInHierarchy ? directionOne.gameObject : (directionTwo.gameObject.activeInHierarchy ? directionTwo.gameObject : ((!directionThree.gameObject.activeInHierarchy) ? directionFour.gameObject : directionThree.gameObject)));
		return gameObject.GetComponentInChildren<Animator>();
	}
}
