using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Power;

public class SpatialGrid<T>
{
	private T[,] _grid;

	private Vector3 _gridOffset;

	private int _resolution;

	public SpatialGrid(int size, int resolution)
	{
		_grid = new T[size * resolution, size * resolution];
		_gridOffset = new Vector3(size / 2, 0f, size / 2);
		_resolution = resolution;
	}

	public Vector3 GetGridPositionFromWorld(Vector3 worldPosition)
	{
		Vector3 snappedPosition = worldPosition.GetSnappedPosition(1f / (float)_resolution);
		return (_gridOffset + snappedPosition) * _resolution;
	}

	public Vector3 GetWorldPositionFromGrid(int x, int y)
	{
		return new Vector3(x, 0f, y) / _resolution - _gridOffset;
	}

	public void AddItem(T item, Vector3 position)
	{
		Vector3 gridPositionFromWorld = GetGridPositionFromWorld(position);
		_grid[(int)gridPositionFromWorld.x, (int)gridPositionFromWorld.z] = item;
	}

	public void RemoveItem(T item, Vector3 position)
	{
		Vector3 gridPositionFromWorld = GetGridPositionFromWorld(position);
		_grid[(int)gridPositionFromWorld.x, (int)gridPositionFromWorld.z] = default;
	}

	public T GetNearestInRange(Vector3 fromPosition, float range, bool ignoreFromPosition = true)
	{
		float num = range * range;
		Vector3 gridPositionFromWorld = GetGridPositionFromWorld(fromPosition);
		float num2 = float.PositiveInfinity;
		T result = default;
		for (int i = (int)(gridPositionFromWorld.x - range); (float)i < gridPositionFromWorld.x + range; i++)
		{
			for (int j = (int)(gridPositionFromWorld.z - range); (float)j < gridPositionFromWorld.z + range; j++)
			{
				if ((!ignoreFromPosition || gridPositionFromWorld.x != (float)i || gridPositionFromWorld.z != (float)j) && _grid[i, j] != null)
				{
					float num3 = Mathf.Pow(gridPositionFromWorld.x - (float)i, 2f);
					float num4 = Mathf.Pow(gridPositionFromWorld.z - (float)j, 2f);
					float num5 = (num3 + num4) / (float)_resolution;
					if (num5 < num && num5 < num2)
					{
						num2 = num5;
						result = _grid[i, j];
					}
				}
			}
		}
		return result;
	}

	public void GetAllInRange(Vector3 fromPosition, float range, ref List<T> results)
	{
		results.Clear();
		float num = range * range;
		float num2 = range * (float)_resolution;
		Vector3 gridPositionFromWorld = GetGridPositionFromWorld(fromPosition);
		for (int i = (int)(gridPositionFromWorld.x - num2); (float)i < gridPositionFromWorld.x + num2; i++)
		{
			for (int j = (int)(gridPositionFromWorld.z - num2); (float)j < gridPositionFromWorld.z + num2; j++)
			{
				if (_grid[i, j] != null)
				{
					float num3 = Mathf.Pow(gridPositionFromWorld.x - (float)i, 2f);
					float num4 = Mathf.Pow(gridPositionFromWorld.z - (float)j, 2f);
					if ((num3 + num4) / (float)(_resolution * _resolution) < num)
					{
						results.Add(_grid[i, j]);
					}
				}
			}
		}
	}

	public void DrawGrid(Camera sceneCamera)
	{
		Ray ray = sceneCamera.ScreenPointToRay(new Vector3(sceneCamera.pixelWidth / 2, sceneCamera.pixelHeight / 2, 0f));
		if (!new Plane(Vector3.up, Vector3.zero).Raycast(ray, out var enter))
		{
			return;
		}
		Vector3 point = ray.GetPoint(enter);
		Vector3 gridPositionFromWorld = GetGridPositionFromWorld(point);
		int num = 100 * _resolution;
		int num2 = (int)Mathf.Clamp(gridPositionFromWorld.x - (float)(num / 2), 0f, _grid.GetLength(0) - num - 2);
		int num3 = (int)Mathf.Clamp(gridPositionFromWorld.z - (float)(num / 2), 0f, _grid.GetLength(1) - num - 2);
		for (int i = num2; i < num2 + num; i++)
		{
			for (int j = num3; j < num3 + num; j++)
			{
				Vector3 worldPositionFromGrid = GetWorldPositionFromGrid(i, j);
				if (_grid[i, j] != null)
				{
					Gizmos.color = Color.green - Color.black * 0.25f;
					Gizmos.DrawCube(worldPositionFromGrid, Vector3.one / _resolution);
				}
			}
		}
	}
}
