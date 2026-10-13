using System;
using UnityEngine;

namespace Isto.Core.Tiles;

[Serializable]
public class TileValues
{
	public Vector3Int tileWorldPosition;

	public Environment.GroundType groundType;

	public bool navigatable = true;

	public Sprite tileSprite;

	public TileValues(Vector3Int tileWorldPosition, Environment.GroundType groundType, bool navigatable, Sprite tileSprite)
	{
		this.tileWorldPosition = tileWorldPosition;
		this.groundType = groundType;
		this.navigatable = navigatable;
		this.tileSprite = tileSprite;
	}
}
