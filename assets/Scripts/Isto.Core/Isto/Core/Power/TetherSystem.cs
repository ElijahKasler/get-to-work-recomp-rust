using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Isto.Core.Power;

public class TetherSystem : MonoBehaviour
{
	private int _gridResolution = 2;

	private int _gridSize = 1000;

	private SpatialGrid<PowerTethered> _grid;

	private List<PowerTethered> _inRangeBuffer = new List<PowerTethered>();

	public event EventHandler<TetherEventArgs> TetherAdded;

	public event EventHandler<TetherEventArgs> TetherRemoved;

	public event EventHandler<TetherEventArgs> PostTetherSystemUpdate;

	private void Awake()
	{
		_grid = new SpatialGrid<PowerTethered>(_gridSize, _gridResolution);
	}

	public void Add(PowerTethered tethered)
	{
		_grid.AddItem(tethered, tethered.transform.position);
		TetherAdded?.Invoke(this, new TetherEventArgs(tethered));
		PostTetherSystemUpdate?.Invoke(this, new TetherEventArgs(tethered));
	}

	public void Remove(PowerTethered tethered)
	{
		_grid.RemoveItem(tethered, tethered.transform.position);
		TetherRemoved?.Invoke(this, new TetherEventArgs(tethered));
		PostTetherSystemUpdate?.Invoke(this, new TetherEventArgs(tethered));
	}

	public bool TryToFindNearest(Vector3 position, float radius, out PowerTethered tethered)
	{
		tethered = _grid.GetNearestInRange(position, radius);
		if (tethered != null)
		{
			return true;
		}
		return false;
	}

	public List<PowerTethered> GetAllInRange(PowerTethered tethered)
	{
		_grid.GetAllInRange(tethered.transform.position, tethered.maxRange, ref _inRangeBuffer);
		_inRangeBuffer.Remove(tethered);
		Vector3 sourcePosition = tethered.transform.position;
		List<PowerTethered> list = (from x in _inRangeBuffer
			orderby Vector3.Distance(x.transform.position, sourcePosition)
			where !x.IsBeingDestroyed
			select x).ToList();
		for (int num = 0; num < list.Count; num++)
		{
			PowerTethered powerTethered = list[num];
			for (int num2 = list.Count - 1; num2 > num; num2--)
			{
				PowerTethered incomingConnection = list[num2];
				if (powerTethered.IsPartOfSameTree(incomingConnection))
				{
					list.RemoveAt(num2);
				}
			}
		}
		return list;
	}
}
