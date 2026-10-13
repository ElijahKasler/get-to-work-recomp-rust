using System.Collections.Generic;
using Isto.Core.Automation;
using Isto.Core.Items;
using UPool;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Isto.Core.ObjectCulling;

public class CullingStaticObjectsController
{
	private CullingGroup _cullingGroup;

	private BoundingSphere[] _spheres;

	private int _cullingSpheresRowLength;

	private Vector3 _bottomCorner;

	private int _cullingSpherePadding = 3;

	private Dictionary<int, List<GameObject>> _itemsInArea = new Dictionary<int, List<GameObject>>();

	public CullingGroup CullingGroup => _cullingGroup;

	public int CullingAreaGridDiameter { get; private set; }

	public BoundingSphere[] Spheres => _spheres;

	public CullingStaticObjectsController(int gridSpaceDiameterPerCullingArea, int cullingSpheresPerRow, Vector3 bottomRightCorner, Camera camera, CullingGroup.StateChanged onStateChangedCallback)
	{
		_cullingGroup = new CullingGroup();
		_cullingGroup.targetCamera = camera;
		_cullingSpheresRowLength = cullingSpheresPerRow;
		if (gridSpaceDiameterPerCullingArea % 2 != 0)
		{
			Debug.LogWarning("Culling Grid Space Diameter should be an even number for proper functionality.  Rounding value up");
			CullingAreaGridDiameter = gridSpaceDiameterPerCullingArea + 1;
		}
		else
		{
			CullingAreaGridDiameter = gridSpaceDiameterPerCullingArea;
		}
		_bottomCorner = bottomRightCorner;
		_spheres = new BoundingSphere[_cullingSpheresRowLength * _cullingSpheresRowLength];
		float radius = CullingAreaGridDiameter / 2 + _cullingSpherePadding;
		for (int i = 0; i < _cullingSpheresRowLength; i++)
		{
			for (int j = 0; j < _cullingSpheresRowLength; j++)
			{
				Vector3 position = _bottomCorner + (Vector3.right * i + Vector3.forward * j) * CullingAreaGridDiameter;
				int num = i * _cullingSpheresRowLength + j;
				_spheres[num].position = position;
				_spheres[num].radius = radius;
			}
		}
		_cullingGroup.SetBoundingSpheres(_spheres);
		_cullingGroup.SetBoundingSphereCount(_cullingSpheresRowLength * _cullingSpheresRowLength);
		_cullingGroup.onStateChanged = onStateChangedCallback;
	}

	public bool IsSpaceVisible(Vector3 worldPosition)
	{
		int indexForNearestBoundingSphere = GetIndexForNearestBoundingSphere(worldPosition);
		return _cullingGroup.IsVisible(indexForNearestBoundingSphere);
	}

	public int GetIndexForNearestBoundingSphere(Vector3 worldPosition)
	{
		int num = Mathf.RoundToInt((worldPosition.x + 0.1f) / (float)CullingAreaGridDiameter) * CullingAreaGridDiameter;
		int num2 = Mathf.RoundToInt((worldPosition.z + 0.1f) / (float)CullingAreaGridDiameter) * CullingAreaGridDiameter;
		float num3 = ((float)num - _bottomCorner.x) / (float)CullingAreaGridDiameter;
		float num4 = ((float)num2 - _bottomCorner.z) / (float)CullingAreaGridDiameter;
		return (int)(num3 * (float)_cullingSpheresRowLength + num4);
	}

	private Vector3 GetPosition(GameObject go)
	{
		return go.GetComponent<ISpecialPositioning>()?.GetAutomationPosition() ?? go.transform.position;
	}

	public void AddStaticDisplayObject(GameObject targetObject)
	{
		int indexForNearestBoundingSphere = GetIndexForNearestBoundingSphere(GetPosition(targetObject));
		if (_itemsInArea.ContainsKey(indexForNearestBoundingSphere))
		{
			_itemsInArea[indexForNearestBoundingSphere].Add(targetObject);
			return;
		}
		_itemsInArea.Add(indexForNearestBoundingSphere, new List<GameObject> { targetObject });
	}

	public void ReleaseStaticDisplayObject(GameObject targetObject)
	{
		int indexForNearestBoundingSphere = GetIndexForNearestBoundingSphere(GetPosition(targetObject));
		if (_itemsInArea.ContainsKey(indexForNearestBoundingSphere))
		{
			if (_itemsInArea[indexForNearestBoundingSphere].Remove(targetObject))
			{
				if (targetObject.GetComponent<PoolableObject>() != null)
				{
					targetObject.GetComponent<PooledInteractableItem>().DestroyGameObject();
				}
				else if (!Addressables.ReleaseInstance(targetObject))
				{
					Debug.LogError("CullingStaticObjectsController.ReleaseStaticDisplayObject called onto item " + targetObject.name + " but item is not an Addressable");
					Object.Destroy(targetObject);
				}
			}
			else
			{
				Debug.LogWarning("CullingStaticObjectsController.ReleaseStaticDisplayObject called onto item " + targetObject.name + " but item is not registered in the list");
			}
		}
		else
		{
			InteractableItem component = targetObject.GetComponent<InteractableItem>();
			string text = "Item: " + ((component != null && component.itemPile.item != null) ? component.itemPile.item.itemID : "");
			Debug.LogWarning($"CullingStaticObjectsController.ReleaseStaticDisplayObject called onto item {targetObject.name} but item's sphere index does not exist. Position: {targetObject.transform.position}. {text}, Index:{indexForNearestBoundingSphere}");
		}
	}

	public Vector3 GetPositionForBoundingSphereAtIndex(int index)
	{
		return _spheres[index].position;
	}

	public int GetGridPositionsInBoundingArea(int boundingSphereIndex, ref Vector3[] results)
	{
		int num = CullingAreaGridDiameter / 2;
		Vector3 vector = _spheres[boundingSphereIndex].position - Vector3.right * num - Vector3.forward * num;
		for (int i = 0; i < CullingAreaGridDiameter; i++)
		{
			for (int j = 0; j < CullingAreaGridDiameter; j++)
			{
				Vector3 vector2 = vector + (Vector3.right * i + Vector3.forward * j);
				results[i * CullingAreaGridDiameter + j] = vector2;
			}
		}
		return CullingAreaGridDiameter * CullingAreaGridDiameter;
	}

	public void ReleaseObjectsInBoundingArea(int boudingSphereIndex, AutomationSystem _automationSystem)
	{
		if (!_itemsInArea.ContainsKey(boudingSphereIndex))
		{
			return;
		}
		List<GameObject> list = _itemsInArea[boudingSphereIndex];
		for (int i = 0; i < list.Count; i++)
		{
			GameObject gameObject = list[i];
			if (gameObject != null)
			{
				if (_automationSystem.DoesSpaceExist(GetPosition(gameObject)))
				{
					AutomationGridSpace orCreateGridSpace = _automationSystem.GetOrCreateGridSpace(GetPosition(gameObject));
					orCreateGridSpace.ProcessorRendered = false;
					orCreateGridSpace.ResourceRendered = false;
				}
				PooledInteractableItem component = gameObject.GetComponent<PooledInteractableItem>();
				if (component != null)
				{
					component.DestroyGameObject();
				}
				else if (!Addressables.ReleaseInstance(gameObject))
				{
					Debug.LogWarning("CullingStaticObjectsController.ReleaseStaticDisplayObject called onto item " + gameObject.name + " but item is not an Addressable");
					Object.Destroy(gameObject);
				}
			}
		}
		_itemsInArea[boudingSphereIndex].Clear();
		_itemsInArea.Remove(boudingSphereIndex);
	}
}
