using System.Collections.Generic;
using Isto.Core.Automation;
using UnityEngine;
using Zenject;

namespace Isto.Core.Items;

[RequireComponent(typeof(ItemPlacementController))]
public class ConnectToNeighbours : MonoBehaviour
{
	[SerializeField]
	private PlacementConditions _connectableConditions;

	[SerializeField]
	private GameObject _upRightPanelRoot;

	[SerializeField]
	private GameObject _upLeftPanelRoot;

	[SerializeField]
	private GameObject _downLeftPanelRoot;

	[SerializeField]
	private GameObject _downRightPanelRoot;

	private ItemPlacementController _placementController;

	private GameObject _dropPosition;

	private GameObject _leftPanelRoot;

	private GameObject _rightPanelRoot;

	private GameObject _backPanelRoot;

	private bool _directionDirty;

	private Vector3Int _prevPos = Vector3Int.zero;

	private ConnectToNeighbours _prevOutputTarget;

	private readonly Dictionary<ItemPlacementController, bool> _leftPanelInfluenceSources = new Dictionary<ItemPlacementController, bool>();

	private readonly Dictionary<ItemPlacementController, bool> _rightPanelInfluenceSources = new Dictionary<ItemPlacementController, bool>();

	private readonly Dictionary<ItemPlacementController, bool> _backPanelInfluenceSources = new Dictionary<ItemPlacementController, bool>();

	private AutomationSystem _automation;

	[Inject]
	public void Inject(AutomationSystem automation)
	{
		_automation = automation;
	}

	private void Awake()
	{
		_placementController = base.gameObject.GetComponent<ItemPlacementController>();
	}

	public void UpdateNeighbourItemOverlaps(bool placementMode)
	{
		if (!(_connectableConditions == null))
		{
			Vector3Int vector3Int = (_prevPos = Vector3Int.RoundToInt(base.gameObject.transform.position));
			if (_directionDirty || _leftPanelRoot == null)
			{
				AssignPanelToRelativePositions();
				_directionDirty = false;
			}
			Vector3 direction = _placementController.GetDirection();
			Vector3 vector = Quaternion.AngleAxis(-90f, Vector3.up) * direction;
			Vector3 vector2 = Quaternion.AngleAxis(90f, Vector3.up) * direction;
			Vector3 vector3 = -direction;
			Vector3Int position2;
			if (_dropPosition != null)
			{
				Vector3 position = _dropPosition.transform.position;
				position2 = new Vector3Int((int)position.x, (int)position.y, (int)position.z);
			}
			else
			{
				position2 = vector3Int + Vector3Int.RoundToInt(direction);
			}
			Vector3Int position3 = vector3Int + Vector3Int.RoundToInt(vector);
			Vector3Int position4 = vector3Int + Vector3Int.RoundToInt(vector2);
			Vector3Int position5 = vector3Int + Vector3Int.RoundToInt(vector3);
			if (_upRightPanelRoot != null)
			{
				bool num = _automation.TryGetExistingGridSpace(position3, out var space);
				bool flag = _automation.TryGetExistingGridSpace(position4, out var space2);
				bool flag2 = _automation.TryGetExistingGridSpace(position5, out var space3);
				bool wantsToHide = num && IsConnectedToUs(vector, space);
				TryHideBorder(_placementController, _leftPanelInfluenceSources, _leftPanelRoot, wantsToHide);
				bool wantsToHide2 = flag && IsConnectedToUs(vector2, space2);
				TryHideBorder(_placementController, _rightPanelInfluenceSources, _rightPanelRoot, wantsToHide2);
				bool wantsToHide3 = flag2 && IsConnectedToUs(vector3, space3);
				TryHideBorder(_placementController, _backPanelInfluenceSources, _backPanelRoot, wantsToHide3);
			}
			CleanupPreviousOutputTile();
			if (_automation.TryGetExistingGridSpace(position2, out var space4))
			{
				CheckForNeighbourReceivingConnection(direction, space4, placementMode);
			}
		}
	}

	private bool IsConnectedToUs(Vector3 relativePosition, AutomationGridSpace space)
	{
		if (space != null && space.itemProcessor != null && space.itemProcessor is IDirectionalItem directionalItem && directionalItem.GetDirection() == -relativePosition)
		{
			return CanConnect(space.itemProcessor.ProcessorID);
		}
		return false;
	}

	private bool CanConnect(string id)
	{
		if (_connectableConditions == null)
		{
			return false;
		}
		for (int i = 0; i < _connectableConditions.validItemsToReplace.Count; i++)
		{
			if (_connectableConditions.validItemsToReplace[i].itemID == id)
			{
				return true;
			}
		}
		return false;
	}

	private void CheckForNeighbourReceivingConnection(Vector3 forwardDir, AutomationGridSpace forwardNeighbour, bool placementMode)
	{
		if (_connectableConditions == null)
		{
			return;
		}
		forwardDir = UnityUtils.GetNearestAxisDirection(forwardDir);
		if (placementMode)
		{
			if (forwardNeighbour.itemProcessor != null && !(forwardNeighbour.DisplayItem == null))
			{
				ConnectToNeighbours component = forwardNeighbour.DisplayItem.GetComponent<ConnectToNeighbours>();
				if (component != null)
				{
					component.UpdateNeighbourConnection(_placementController, forwardDir, wantsToHide: true);
					_prevOutputTarget = component;
				}
			}
			return;
		}
		Collider[] array = Physics.OverlapBox(forwardNeighbour.position + Constants.AUTOMATION_TO_WORLD_OFFSET, layerMask: _connectableConditions.invalidLayers, halfExtents: Vector3.one * 0.2f, orientation: Quaternion.identity, queryTriggerInteraction: QueryTriggerInteraction.Collide);
		for (int i = 0; i < array.Length; i++)
		{
			ConnectToNeighbours componentInParent = array[i].GetComponentInParent<ConnectToNeighbours>();
			if (componentInParent != null)
			{
				componentInParent.UpdateNeighbourConnection(_placementController, forwardDir, wantsToHide: true);
				_prevOutputTarget = componentInParent;
				break;
			}
		}
	}

	public void UpdateNeighbourConnection(ItemPlacementController source, Vector3 direction, bool wantsToHide)
	{
		Vector3 direction2 = _placementController.GetDirection();
		Vector3 direction3 = Quaternion.AngleAxis(-90f, Vector3.up) * direction2;
		Vector3 direction4 = Quaternion.AngleAxis(90f, Vector3.up) * direction2;
		Vector3 direction5 = -direction2;
		direction3 = UnityUtils.GetNearestAxisDirection(direction3);
		direction4 = UnityUtils.GetNearestAxisDirection(direction4);
		direction5 = UnityUtils.GetNearestAxisDirection(direction5);
		direction = -direction;
		if (direction == direction3)
		{
			TryHideBorder(source, _leftPanelInfluenceSources, _leftPanelRoot, wantsToHide);
		}
		else if (direction == direction4)
		{
			TryHideBorder(source, _rightPanelInfluenceSources, _rightPanelRoot, wantsToHide);
		}
		else if (direction == direction5)
		{
			TryHideBorder(source, _backPanelInfluenceSources, _backPanelRoot, wantsToHide);
		}
	}

	private void AssignPanelToRelativePositions()
	{
		Vector3 direction = _placementController.GetDirection();
		if (direction.z == 1f)
		{
			_leftPanelRoot = _upLeftPanelRoot;
			_backPanelRoot = _downLeftPanelRoot;
			_rightPanelRoot = _downRightPanelRoot;
		}
		else if (direction.x == -1f)
		{
			_leftPanelRoot = _downLeftPanelRoot;
			_backPanelRoot = _downRightPanelRoot;
			_rightPanelRoot = _upRightPanelRoot;
		}
		else if (direction.z == -1f)
		{
			_leftPanelRoot = _downRightPanelRoot;
			_backPanelRoot = _upRightPanelRoot;
			_rightPanelRoot = _upLeftPanelRoot;
		}
		else if (direction.x == 1f)
		{
			_leftPanelRoot = _upRightPanelRoot;
			_backPanelRoot = _upLeftPanelRoot;
			_rightPanelRoot = _downLeftPanelRoot;
		}
		else
		{
			Debug.LogError("ConnectToNeighbours.AssignPanelToRelativePositions: Forward direction didn't match any axis.");
			CleanupRelativePanelReferences();
		}
	}

	private void CleanupRelativePanelReferences()
	{
		_leftPanelRoot = null;
		_backPanelRoot = null;
		_rightPanelRoot = null;
	}

	public void ResetDirection()
	{
		CleanupBorderPanelHidingInfluences();
		_directionDirty = true;
	}

	private void CleanupBorderPanelHidingInfluences()
	{
		_prevPos = Vector3Int.zero;
		CleanupPreviousOutputTile();
		_leftPanelInfluenceSources.Clear();
		_rightPanelInfluenceSources.Clear();
		_backPanelInfluenceSources.Clear();
		HideBorder(_leftPanelRoot, haveToHide: false);
		HideBorder(_rightPanelRoot, haveToHide: false);
		HideBorder(_backPanelRoot, haveToHide: false);
		CleanupRelativePanelReferences();
	}

	private void CleanupPreviousOutputTile()
	{
		if (_prevOutputTarget != null)
		{
			_prevOutputTarget.UpdateNeighbourRemoved(_placementController);
			_prevOutputTarget = null;
		}
	}

	private void UpdateNeighbourRemoved(ItemPlacementController source)
	{
		if (_leftPanelInfluenceSources.ContainsKey(source))
		{
			TryHideBorder(source, _leftPanelInfluenceSources, _leftPanelRoot, wantsToHide: false);
			_leftPanelInfluenceSources.Remove(source);
		}
		if (_rightPanelInfluenceSources.ContainsKey(source))
		{
			TryHideBorder(source, _rightPanelInfluenceSources, _rightPanelRoot, wantsToHide: false);
			_rightPanelInfluenceSources.Remove(source);
		}
		if (_backPanelInfluenceSources.ContainsKey(source))
		{
			TryHideBorder(source, _backPanelInfluenceSources, _backPanelRoot, wantsToHide: false);
			_backPanelInfluenceSources.Remove(source);
		}
	}

	private static void TryHideBorder(ItemPlacementController hider, Dictionary<ItemPlacementController, bool> hiderTracker, GameObject borderWallObject, bool wantsToHide)
	{
		if (!hiderTracker.ContainsKey(hider))
		{
			hiderTracker.Add(hider, wantsToHide);
		}
		else
		{
			hiderTracker[hider] = wantsToHide;
		}
		bool haveToHide = NeedsToHide(hiderTracker);
		HideBorder(borderWallObject, haveToHide);
	}

	private static bool NeedsToHide(Dictionary<ItemPlacementController, bool> hiderTracker)
	{
		bool result = false;
		Dictionary<ItemPlacementController, bool>.KeyCollection.Enumerator enumerator = hiderTracker.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (hiderTracker[enumerator.Current])
			{
				result = true;
				break;
			}
		}
		return result;
	}

	private static void HideBorder(GameObject borderRoot, bool haveToHide)
	{
		if (!(borderRoot == null))
		{
			if (haveToHide && borderRoot.activeSelf)
			{
				borderRoot.SetActive(value: false);
			}
			else if (!haveToHide && !borderRoot.activeSelf)
			{
				borderRoot.SetActive(value: true);
			}
		}
	}
}
