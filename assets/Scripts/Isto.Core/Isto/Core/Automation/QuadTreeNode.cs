using UnityEngine;

namespace Isto.Core.Automation;

public class QuadTreeNode
{
	public Vector3Int position;

	public AutomationGridSpace space;

	public QuadTreeNode(Vector3Int position, AutomationGridSpace space)
	{
		this.position = position;
		this.space = space;
	}
}
