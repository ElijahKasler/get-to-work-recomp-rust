using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Tiles;

[CreateAssetMenu(fileName = "New Prefab Spawn Rule", menuName = "Scriptables/Tilemap/PrefabSpawnRule")]
public class PrefabTileSpawnRule : ScriptableObject
{
	public GameObject[] prefabs;

	public List<GroundRuleTile> tilesItCanSpawnIn;

	public bool snapToGrid = true;

	public GameObject GetRandomPrefab()
	{
		return prefabs[Random.Range(0, prefabs.Length - 1)];
	}
}
