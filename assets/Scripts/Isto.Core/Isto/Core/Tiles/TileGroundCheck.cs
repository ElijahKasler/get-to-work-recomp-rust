using UnityEngine;
using Zenject;

namespace Isto.Core.Tiles;

public class TileGroundCheck : MonoBehaviour
{
	public bool hittingTile;

	private TilemapGlobalController _tilemapController;

	public Environment.GroundType CurrentGround { get; private set; }

	[Inject]
	public void Inject(TilemapGlobalController tilemapGlobalController)
	{
		_tilemapController = tilemapGlobalController;
	}

	private void Update()
	{
		Environment.GroundType groundTypeForPosition = _tilemapController.GetGroundTypeForPosition(base.transform.position);
		if (groundTypeForPosition != Environment.GroundType.NotSet)
		{
			CurrentGround = groundTypeForPosition;
		}
		else
		{
			CurrentGround = Environment.GroundType.Grass;
		}
	}
}
