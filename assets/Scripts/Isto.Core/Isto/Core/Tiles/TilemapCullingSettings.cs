using System.Collections.Generic;
using Isto.Core.Automation;
using UnityEngine;

namespace Isto.Core.Tiles;

[CreateAssetMenu(fileName = "New Tile Ground Type Map", menuName = "Scriptables/Tilemap/Tile Ground Type Map")]
public class TilemapCullingSettings : ScriptableObject
{
	public string sceneName;

	public List<TilemapPrefabSetup> tilemapPrefabs = new List<TilemapPrefabSetup>();

	[HideInInspector]
	public List<TileValues> tiles = new List<TileValues>();

	[Tooltip("The square side length of each slice of the tilemap.  If set to zero, the tilemaps will not be sliced at all")]
	public int sliceSize = 100;

	public Vector3Int bottomCornerPosition;

	public int tileMapLargestSide;

	private Dictionary<int, TileValues> groundTypesMap = new Dictionary<int, TileValues>();

	public bool SlicingActive => sliceSize > 0;

	public Environment.GroundType GetGroundForWorldPosition(Vector3 position)
	{
		if (TryGetTileValuesForPosition(position, out var tileValues))
		{
			return tileValues.groundType;
		}
		return Environment.GroundType.NotSet;
	}

	public bool IsPositionNavigatable(Vector3 position)
	{
		if (TryGetTileValuesForPosition(position, out var tileValues))
		{
			return tileValues.navigatable;
		}
		return true;
	}

	public bool DoesTileContainAnySprite(Vector3 position, List<Sprite> sprites)
	{
		if (tiles.Count > 0 && groundTypesMap.Count == 0)
		{
			InitializeMapDictionary();
		}
		Vector3Int vector3Int = Vector3Int.RoundToInt(position - Vector3.right);
		int key = AutomationGrid.HashCoordinate(vector3Int.x, vector3Int.z);
		if (groundTypesMap.TryGetValue(key, out var value))
		{
			for (int i = 0; i < sprites.Count; i++)
			{
				if (value.tileSprite == sprites[i])
				{
					return true;
				}
			}
		}
		return false;
	}

	private void InitializeMapDictionary()
	{
		Debug.Log("Initializing Tile Map Dictionary");
		for (int i = 0; i < tiles.Count; i++)
		{
			int num = AutomationGrid.HashCoordinate(tiles[i].tileWorldPosition.x, tiles[i].tileWorldPosition.z);
			if (groundTypesMap.ContainsKey(num))
			{
				Debug.LogError($"{tiles[i].tileWorldPosition} already exists in dictionary.  Hashed Coord:{num}.  Tile type:{tiles[i].groundType}.  THIS SHOULDN'T HAPPEN, IGNORING TILE FOR NOW");
			}
			else
			{
				groundTypesMap.Add(num, tiles[i]);
			}
		}
	}

	private bool TryGetTileValuesForPosition(Vector3 position, out TileValues tileValues)
	{
		if (tiles.Count > 0 && groundTypesMap.Count == 0)
		{
			InitializeMapDictionary();
		}
		Vector3Int vector3Int = Vector3Int.RoundToInt(position - Vector3.right);
		int key = AutomationGrid.HashCoordinate(vector3Int.x, vector3Int.z);
		return groundTypesMap.TryGetValue(key, out tileValues);
	}

	[ContextMenu("Get Number Of Unique Corners")]
	public void GetCornerCount()
	{
		HashSet<int> hashSet = new HashSet<int>();
		for (int i = 0; i < tilemapPrefabs.Count; i++)
		{
			Vector3Int tilemapCornerPosition = tilemapPrefabs[i].tilemapCornerPosition;
			int item = AutomationGrid.HashCoordinate(tilemapCornerPosition.x, tilemapCornerPosition.z);
			if (!hashSet.Contains(item))
			{
				hashSet.Add(item);
			}
		}
		Debug.Log($"{hashSet.Count} unique corners");
	}
}
