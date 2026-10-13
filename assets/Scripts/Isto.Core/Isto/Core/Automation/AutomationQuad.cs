using System;
using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Automation;

public class AutomationQuad
{
	public QuadTreeNode node;

	public AutomationQuad topLeftTree;

	public AutomationQuad topRightTree;

	public AutomationQuad botLeftTree;

	public AutomationQuad botRightTree;

	public int topLeftX;

	public int topLeftZ;

	public int botRightX;

	public int botRightZ;

	public AutomationQuad(Vector3Int topLeft, Vector3Int bottomRight)
	{
		topLeftX = topLeft.x;
		topLeftZ = topLeft.z;
		botRightX = bottomRight.x;
		botRightZ = bottomRight.z;
		topLeftTree = null;
		topRightTree = null;
		botLeftTree = null;
		botRightTree = null;
	}

	public void Insert(QuadTreeNode node, int maxDepth = 12)
	{
		if (node == null)
		{
			return;
		}
		if (maxDepth <= 0)
		{
			Debug.LogError("Reached max depth in Quad Tree");
		}
		else
		{
			if (!IsInboundry(node.position))
			{
				return;
			}
			if (Mathf.Abs(botRightX - topLeftX) <= 1 && Mathf.Abs(topLeftZ - botRightZ) <= 1)
			{
				if (this.node == null)
				{
					this.node = node;
				}
			}
			else if ((botRightX + topLeftX) / 2 <= node.position.x)
			{
				if ((topLeftZ + botRightZ) / 2 <= node.position.z)
				{
					if (topRightTree == null)
					{
						topRightTree = new AutomationQuad(new Vector3Int((botRightX + topLeftX) / 2, 0, topLeftZ), new Vector3Int(botRightX, 0, (topLeftZ + botRightZ) / 2));
					}
					topRightTree.Insert(node, maxDepth - 1);
				}
				else
				{
					if (botRightTree == null)
					{
						botRightTree = new AutomationQuad(new Vector3Int((botRightX + topLeftX) / 2, 0, (topLeftZ + botRightZ) / 2), new Vector3Int(botRightX, 0, botRightZ));
					}
					botRightTree.Insert(node, maxDepth - 1);
				}
			}
			else if ((topLeftZ + botRightZ) / 2 <= node.position.z)
			{
				if (topLeftTree == null)
				{
					topLeftTree = new AutomationQuad(new Vector3Int(topLeftX, 0, topLeftZ), new Vector3Int((botRightX + topLeftX) / 2, 0, (topLeftZ + botRightZ) / 2));
				}
				topLeftTree.Insert(node, maxDepth - 1);
			}
			else
			{
				if (botLeftTree == null)
				{
					botLeftTree = new AutomationQuad(new Vector3Int(topLeftX, 0, (topLeftZ + botRightZ) / 2), new Vector3Int((botRightX + topLeftX) / 2, 0, botRightZ));
				}
				botLeftTree.Insert(node, maxDepth - 1);
			}
		}
	}

	public void Remove(Vector3Int p, int maxDepth = 12)
	{
		if (maxDepth <= 0)
		{
			Debug.LogError("Reached max depth in Quad Tree");
		}
		else
		{
			if (!IsInboundry(p))
			{
				return;
			}
			if (Mathf.Abs(botRightX - topLeftX) <= 1 && Mathf.Abs(topLeftZ - botRightZ) <= 1)
			{
				if (node != null && node.position == p)
				{
					node = null;
				}
			}
			else if ((botRightX + topLeftX) / 2 <= p.x)
			{
				if ((topLeftZ + botRightZ) / 2 <= p.z)
				{
					if (topRightTree != null)
					{
						topRightTree.Remove(p, maxDepth - 1);
						if (topRightTree.IsEmpty())
						{
							topRightTree = null;
						}
					}
				}
				else if (botRightTree != null)
				{
					botRightTree.Remove(p, maxDepth - 1);
					if (botRightTree.IsEmpty())
					{
						botRightTree = null;
					}
				}
			}
			else if ((topLeftZ + botRightZ) / 2 <= p.z)
			{
				if (topLeftTree != null)
				{
					topLeftTree.Remove(p, maxDepth - 1);
					if (topLeftTree.IsEmpty())
					{
						topLeftTree = null;
					}
				}
			}
			else if (botLeftTree != null)
			{
				botLeftTree.Remove(p, maxDepth - 1);
				if (botLeftTree.IsEmpty())
				{
					botLeftTree = null;
				}
			}
		}
	}

	public List<QuadTreeNode> Search(Vector3Int topLeft, Vector3Int botRight)
	{
		List<QuadTreeNode> results = new List<QuadTreeNode>();
		SearchInternal(topLeft.x, topLeft.z, botRight.x, botRight.z, ref results);
		return results;
	}

	protected void SearchInternal(int topLeftX, int topLeftZ, int botRightX, int botRightZ, ref List<QuadTreeNode> results)
	{
		if (!IsOverlapping(topLeftX, topLeftZ, botRightX, botRightZ))
		{
			return;
		}
		if (node != null)
		{
			results.Add(node);
			return;
		}
		if (topLeftTree != null)
		{
			topLeftTree.SearchInternal(topLeftX, topLeftZ, botRightX, botRightZ, ref results);
		}
		if (topRightTree != null)
		{
			topRightTree.SearchInternal(topLeftX, topLeftZ, botRightX, botRightZ, ref results);
		}
		if (botLeftTree != null)
		{
			botLeftTree.SearchInternal(topLeftX, topLeftZ, botRightX, botRightZ, ref results);
		}
		if (botRightTree != null)
		{
			botRightTree.SearchInternal(topLeftX, topLeftZ, botRightX, botRightZ, ref results);
		}
	}

	public void SearchForSpaces(Vector3Int topLeft, Vector3Int botRight, Func<AutomationGridSpace, bool> predicate, ref List<Vector3> spacePositions)
	{
		spacePositions.Clear();
		SearchInternal(topLeft.x, topLeft.z, botRight.x, botRight.z, predicate, ref spacePositions);
	}

	protected void SearchInternal(int leftX, int leftZ, int rightX, int rightZ, Func<AutomationGridSpace, bool> predicate, ref List<Vector3> spacePositions)
	{
		if (!IsOverlapping(leftX, leftZ, rightX, rightZ))
		{
			return;
		}
		if (node != null && node.space != null && predicate(node.space))
		{
			spacePositions.Add(node.space.position);
			return;
		}
		if (topLeftTree != null)
		{
			topLeftTree.SearchInternal(leftX, leftZ, rightX, rightZ, predicate, ref spacePositions);
		}
		if (topRightTree != null)
		{
			topRightTree.SearchInternal(leftX, leftZ, rightX, rightZ, predicate, ref spacePositions);
		}
		if (botLeftTree != null)
		{
			botLeftTree.SearchInternal(leftX, leftZ, rightX, rightZ, predicate, ref spacePositions);
		}
		if (botRightTree != null)
		{
			botRightTree.SearchInternal(leftX, leftZ, rightX, rightZ, predicate, ref spacePositions);
		}
	}

	private bool IsInboundry(Vector3Int p)
	{
		if (p.x >= topLeftX && p.x <= botRightX && p.z <= topLeftZ)
		{
			return p.z >= botRightZ;
		}
		return false;
	}

	private bool IsOverlapping(int leftX, int leftZ, int rightX, int rightZ)
	{
		if (leftX == rightX || leftZ == rightZ || botRightX == topLeftX || topLeftZ == botRightZ)
		{
			return false;
		}
		if (leftX > botRightX || topLeftX > rightX)
		{
			return false;
		}
		if (rightZ > topLeftZ || botRightZ > leftZ)
		{
			return false;
		}
		return true;
	}

	private bool IsEmpty()
	{
		if (node == null && topLeftTree == null && topRightTree == null && botLeftTree == null)
		{
			return botRightTree == null;
		}
		return false;
	}
}
