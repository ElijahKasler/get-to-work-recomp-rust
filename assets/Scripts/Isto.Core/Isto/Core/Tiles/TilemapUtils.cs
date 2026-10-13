using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Isto.Core.Tiles;

public static class TilemapUtils
{
	public static readonly string BAKED_MAP_TILES_RELATIVE_FOLDER = "BakingTiles/";

	public static readonly string BAKED_MAP_TILES_ABSOLUTE_FOLDER = "Assets/Game Items/Environment/TileMap/" + BAKED_MAP_TILES_RELATIVE_FOLDER;

	public static readonly string BAKED_MAP_TILES_EXTENSION = ".asset";

	public static Environment.GroundType GetGroundTypeForPosition(Vector3 position, Tilemap[] tilemaps)
	{
		Vector3Int.RoundToInt(position - Vector3.right);
		foreach (Tilemap tilemap in tilemaps)
		{
			GroundRuleTile tile = tilemap.GetTile<GroundRuleTile>(tilemap.WorldToCell(position));
			if (tile != null)
			{
				return tile.groundType;
			}
			GroundTile tile2 = tilemap.GetTile<GroundTile>(tilemap.WorldToCell(position));
			if (tile2 != null)
			{
				return tile2.groundType;
			}
		}
		return Environment.GroundType.NotSet;
	}

	public static List<Tilemap> GetAllTilemapsInSceneDecendingSortOrder()
	{
		List<Tilemap> list = new List<Tilemap>();
		list = (from x in Object.FindObjectsOfType<Tilemap>()
			where x.gameObject.activeInHierarchy
			select x).ToList();
		for (int num = list.Count - 1; num >= 0; num--)
		{
			if (list[num].transform.localScale.x < 0.49f)
			{
				list.RemoveAt(num);
			}
		}
		list.Sort((Tilemap x, Tilemap y) => y.GetComponent<TilemapRenderer>().sortingOrder.CompareTo(x.GetComponent<TilemapRenderer>().sortingOrder));
		return list;
	}
}
