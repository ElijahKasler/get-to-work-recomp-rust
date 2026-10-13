using System.Collections.Generic;
using Isto.Core.Automation;
using Isto.Core.Data;
using Isto.Core.Tiles;
using UnityEngine;
using Zenject;

namespace Isto.Core.Items;

public abstract class Spawner : MonoBehaviour, IDataLoadCompleteHandler
{
	public Color gizmoColor = Color.blue;

	public float width;

	public float length;

	public SpawningConditions spawningConditions;

	public TileSpriteSpawnRules spriteSpawnRules;

	protected DiContainer _container;

	protected AutomationSystem _autoSystem;

	protected Collider[] _hitBuffer = new Collider[3];

	protected Bounds spawnArea;

	protected bool _complete;

	private static HashSet<Vector3> _recordedPositionsBuffer = new HashSet<Vector3>();

	[Inject]
	public void Inject(DiContainer container, AutomationSystem automationSystem)
	{
		_container = container;
		_autoSystem = automationSystem;
	}

	protected virtual void Awake()
	{
		_complete = false;
		spawnArea = new Bounds(base.transform.position, new Vector3(width, 0f, length));
	}

	public void OnDataLoadComplete()
	{
		if (base.gameObject.activeInHierarchy)
		{
			SpawnItems();
		}
	}

	public abstract void SpawnItems();

	public abstract bool SpawnsComplete();

	public static Vector3 GetRandomPosition(Bounds bounds)
	{
		Vector3 zero = Vector3.zero;
		zero.x = Random.Range(0f - bounds.extents.x, bounds.extents.x);
		zero.z = Random.Range(0f - bounds.extents.z, bounds.extents.z);
		return zero + bounds.center;
	}

	public static List<Vector3> GetAllPositionsInBounds(Bounds bounds)
	{
		List<Vector3> list = new List<Vector3>();
		int num = Mathf.RoundToInt(bounds.extents.x);
		int num2 = Mathf.RoundToInt(bounds.extents.z);
		for (int i = -num; i < num; i++)
		{
			for (int j = -num2; j < num2; j++)
			{
				list.Add(new Vector3(i, 0f, j) + bounds.center);
			}
		}
		return list;
	}

	public static List<Vector3> GetAllPositionsInBounds(Bounds bounds, ref List<Vector3> positionBuffer)
	{
		positionBuffer.Clear();
		int num = Mathf.RoundToInt(bounds.extents.x);
		int num2 = Mathf.RoundToInt(bounds.extents.z);
		for (int i = -num; i < num; i++)
		{
			for (int j = -num2; j < num2; j++)
			{
				positionBuffer.Add(new Vector3(i, 0f, j) + bounds.center);
			}
		}
		return positionBuffer;
	}

	public static int GetCountOfResourceInBounds(List<Vector3> positionsInBounds, string resourceID, AutomationSystem automationSystem)
	{
		int num = 0;
		for (int i = 0; i < positionsInBounds.Count; i++)
		{
			Vector3 position = positionsInBounds[i];
			if (automationSystem.TryGetExistingGridSpace(position, out var space) && space.Resource != null && space.Resource.ID.Equals(resourceID))
			{
				num++;
			}
		}
		return num;
	}

	public static bool IsPositionValid(Vector3 position, Collider[] hitbuffer, LayerMask invalidLayers, float searchRadius = 0.5f)
	{
		return Physics.OverlapSphereNonAlloc(position, searchRadius, hitbuffer, invalidLayers, QueryTriggerInteraction.Collide) == 0;
	}

	public static Dictionary<Sprite, List<Vector3>> GetAllPostionsForSpawning(TilemapCullingSettings tilemapSettings, Bounds bounds, TileSpriteSpawnRules spriteSpawnRules, GroundRuleTile defaultGroundTile = null)
	{
		HashSet<Vector3> recordedPositionsBuffer = _recordedPositionsBuffer;
		recordedPositionsBuffer.Clear();
		Dictionary<Sprite, List<Vector3>> dictionary = new Dictionary<Sprite, List<Vector3>>();
		foreach (TileValues tile in tilemapSettings.tiles)
		{
			bool flag = bounds.Contains(tile.tileWorldPosition);
			if (recordedPositionsBuffer.Contains(tile.tileWorldPosition))
			{
				continue;
			}
			if (flag && spriteSpawnRules.IsValidSpriteToSpawnOn(tile.tileSprite))
			{
				if (dictionary.ContainsKey(tile.tileSprite))
				{
					dictionary[tile.tileSprite].Add(tile.tileWorldPosition + Vector3.right);
				}
				else
				{
					dictionary.Add(tile.tileSprite, new List<Vector3> { tile.tileWorldPosition + Vector3.right });
				}
			}
			if (flag)
			{
				recordedPositionsBuffer.Add(tile.tileWorldPosition);
			}
		}
		if (defaultGroundTile != null)
		{
			foreach (Vector3 allPositionsInBound in GetAllPositionsInBounds(bounds))
			{
				if (recordedPositionsBuffer.Contains(allPositionsInBound))
				{
					continue;
				}
				recordedPositionsBuffer.Add(allPositionsInBound);
				if (spriteSpawnRules.IsValidSpriteToSpawnOn(defaultGroundTile.m_DefaultSprite))
				{
					if (dictionary.ContainsKey(defaultGroundTile.m_DefaultSprite))
					{
						dictionary[defaultGroundTile.m_DefaultSprite].Add(allPositionsInBound);
						continue;
					}
					dictionary.Add(defaultGroundTile.m_DefaultSprite, new List<Vector3> { allPositionsInBound });
				}
			}
		}
		return dictionary;
	}

	public void OnDrawGizmosSelected()
	{
		Color fillColor = gizmoColor * new Color(1f, 1f, 1f, 0.25f);
		Vector3 position = base.transform.position;
		position.y = 0.1f;
		spawnArea = new Bounds(position, new Vector3(width, 0f, length));
		UnityUtils.DrawBox(spawnArea, gizmoColor, fillColor, gizmoColor, base.gameObject.name);
	}
}
