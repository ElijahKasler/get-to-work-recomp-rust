using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Isto.Core.Automation;

public class AutomationCoreItem
{
	public class Factory : PlaceholderFactory<CoreItemParams, AutomationCoreItem>
	{
	}

	public string ID;

	public int count;

	public Vector3 position;

	private CoreItemMoveEventArgs _currentMoveArgs;

	public bool IsMoving { get; private set; }

	public bool IsConsumed { get; private set; }

	public bool IsReserved { get; set; }

	public Vector3 TargetPosition
	{
		get
		{
			if (_currentMoveArgs.mover == null)
			{
				return position;
			}
			return _currentMoveArgs.targetPosition;
		}
	}

	public float MoveTotalTime
	{
		get
		{
			if (_currentMoveArgs.mover == null)
			{
				return 0.01f;
			}
			return _currentMoveArgs.moveTime;
		}
	}

	public IItemMoveType MoveType { get; private set; }

	public AssetReference DisplayAssetOverride { get; private set; }

	public AutomationGridSpace GridSpace { get; private set; }

	public event EventHandler<CoreItemMoveEventArgs> MoveStart;

	public event EventHandler<CoreItemMoveEventArgs> MoveComplete;

	public event EventHandler<CoreItemMoveEventArgs> Launch;

	public event EventHandler Consumed;

	public AutomationCoreItem(CoreItemParams itemParams)
	{
		ID = itemParams.itemID;
		count = itemParams.count;
		position = itemParams.position;
	}

	public void StartItemMove(Vector3 destination, float moveTime, IItemMoveType moveType)
	{
		IsMoving = true;
		MoveType = moveType;
		_currentMoveArgs = new CoreItemMoveEventArgs
		{
			moveTime = moveTime,
			targetPosition = destination,
			mover = moveType
		};
		MoveStart?.Invoke(this, _currentMoveArgs);
	}

	public void EndItemMove()
	{
		IsMoving = false;
		MoveComplete?.Invoke(this, _currentMoveArgs);
	}

	public void LaunchItem()
	{
		Launch?.Invoke(this, default);
	}

	public IItemMoveType GetMovingType()
	{
		if (!IsMoving)
		{
			return null;
		}
		return MoveType;
	}

	public void ConsumeItem()
	{
		Consumed?.Invoke(this, EventArgs.Empty);
		IsConsumed = true;
	}

	public void SetDisplayAsset(AssetReference displayAsset)
	{
		DisplayAssetOverride = displayAsset;
	}

	public void SetGridSpace(AutomationGridSpace space)
	{
		GridSpace = space;
	}
}
