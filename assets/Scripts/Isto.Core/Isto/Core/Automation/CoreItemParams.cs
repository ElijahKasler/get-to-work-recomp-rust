using UnityEngine;

namespace Isto.Core.Automation;

public struct CoreItemParams(string itemID, int count, Vector3 position)
{
	public string itemID = itemID;

	public int count = count;

	public Vector3 position = position;
}
