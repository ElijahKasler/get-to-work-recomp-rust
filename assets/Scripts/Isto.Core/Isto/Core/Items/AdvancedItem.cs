using UnityEngine;

namespace Isto.Core.Items;

[CreateAssetMenu(fileName = "New Advanced Item", menuName = "Scriptables/Item/AdvancedItem")]
public class AdvancedItem : CoreItem
{
	[Header("Advanced Properties")]
	public float width = 1f;

	public float depth = 1f;

	[Tooltip("The distance from the items origin to the bottom-right hand corner of the Items bounds.\nIf origin is bottom right, Offset is 0,0\nIf origin is left 3 and up 2, offset would be x=3, z=-2 ")]
	public float offsetToCornerX;

	public float offsetToCornerZ;

	[Tooltip("Used when dropped from automation system, prefab should be treated like a core item, not a placed advanced item when dropped.")]
	public GameObject coreItemPrefab;

	public float gridSnapSize = 1f;

	[Tooltip("If set, item will just be instantly dropped (like a core item) when dropping instead of using advanced item placement state.")]
	public bool simpleDrop;

	public bool equipToPlayer;

	public override GameObject DropItem(Vector3 position, Transform parent, int count, bool droppedByPlayer)
	{
		if (width == 0f || depth == 0f)
		{
			Debug.LogError("No item width or depth set for item: " + base.itemName);
			return null;
		}
		bool flag = true;
		GameObject gameObject;
		if (droppedByPlayer)
		{
			gameObject = CreateItemFromPrefab(prefab, position, count);
			flag = false;
		}
		else
		{
			if (coreItemPrefab == null)
			{
				Debug.LogError("Core Item Prefab is null for item: " + base.itemName);
				return null;
			}
			gameObject = CreateItemFromPrefab(coreItemPrefab, position, count);
		}
		gameObject.transform.SetParent(parent);
		InitializeNewItem(gameObject, simpleDrop | flag);
		return gameObject;
	}

	public static void InitializeNewItem(GameObject newItem, bool activateNow)
	{
		newItem.SetColliderState(enabled: false);
		IActionOnSpawn[] componentsInChildren = newItem.GetComponentsInChildren<IActionOnSpawn>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].DoSpawnAction();
		}
		if (activateNow)
		{
			IActivatable[] componentsInChildren2 = newItem.GetComponentsInChildren<IActivatable>();
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				componentsInChildren2[j].Activate();
			}
		}
	}
}
