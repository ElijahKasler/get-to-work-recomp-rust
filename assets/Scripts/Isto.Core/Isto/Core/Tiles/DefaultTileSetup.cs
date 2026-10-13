using System;
using UnityEngine;

namespace Isto.Core.Tiles;

[Serializable]
public class DefaultTileSetup
{
	public Bounds bounds;

	public GroundRuleTile defaultTile;

	public Color gizmoColor;

	public DefaultTileSetup()
	{
		bounds = new Bounds(Vector3.zero, Vector3.left * 10f + Vector3.forward * 10f);
		gizmoColor = Color.white;
	}
}
