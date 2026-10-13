using UnityEngine;

namespace Isto.Core.Items;

public class ItemRotateObjectsState : ItemRotateState
{
	[Header("Rotation Children")]
	public Transform dropTransform;

	[Header("Rotate Body")]
	public bool rotateObject;

	public Transform bodyTransform;

	public override void HandleRotation(int direction)
	{
		base.HandleRotation(direction);
		if (dropTransform != null)
		{
			Vector3 localPosition = dropTransform.localPosition;
			Vector3 localPosition2 = Quaternion.AngleAxis((float)direction * 90f, Vector3.up) * localPosition;
			dropTransform.localPosition = localPosition2;
		}
		if (rotateObject)
		{
			CoreItem item = _itemComponent.itemPile.item;
			float num;
			if (item.GetType() == typeof(AdvancedItem))
			{
				AdvancedItem advancedItem = item as AdvancedItem;
				num = Mathf.Max(advancedItem.width, advancedItem.depth);
			}
			else
			{
				num = 1f;
			}
			Vector3 point = base.transform.position + new Vector3((0f - num) / 2f, 0f, num / 2f);
			bodyTransform.RotateAround(point, Vector3.up, (float)direction * 90f);
		}
	}
}
