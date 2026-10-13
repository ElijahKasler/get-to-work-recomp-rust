using UnityEngine;

namespace Isto.Core.Automation;

public struct CoreItemMoveEventArgs
{
	public Vector3 targetPosition;

	public float moveTime;

	public IItemMoveType mover;
}
