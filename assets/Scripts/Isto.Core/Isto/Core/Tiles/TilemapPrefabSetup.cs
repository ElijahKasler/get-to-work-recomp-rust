using System;
using UnityEngine;

namespace Isto.Core.Tiles;

[Serializable]
public class TilemapPrefabSetup
{
	public GameObject prefab;

	public Vector3Int tilemapCornerPosition;

	public int layer;

	public TilemapPrefabSetup(GameObject prefab, Vector3Int tilemapCornerPosition, int layer)
	{
		this.prefab = prefab;
		this.tilemapCornerPosition = tilemapCornerPosition;
		this.layer = layer;
	}
}
