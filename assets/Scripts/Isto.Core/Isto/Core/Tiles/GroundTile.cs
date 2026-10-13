using UnityEngine;
using UnityEngine.Tilemaps;

namespace Isto.Core.Tiles;

[CreateAssetMenu(fileName = "New Ground Tile", menuName = "Scriptables/Tilemap/GroundTile")]
public class GroundTile : Tile
{
	public Environment.GroundType groundType;
}
