using Isto.Core.Items;
using UnityEngine;

namespace Isto.Core.Research;

public class ResearchBoosterValidPositions : MonoBehaviour
{
	public int xRadius = 5;

	public int zRadius = 5;

	public bool showOnEnable;

	[SerializeField]
	private AdvancedItem _boosterItem;

	[SerializeField]
	private LineRenderer _borderLine;

	public Color validPlaceColor = Color.black;

	public void OnEnable()
	{
		RecalculatePoints();
		if (showOnEnable)
		{
			ShowBorder();
		}
	}

	public void OnDisable()
	{
		if (showOnEnable)
		{
			HideBorder();
		}
	}

	public void RecalculatePoints()
	{
		Vector3[] positions = new Vector3[4]
		{
			new Vector3(-xRadius, 0f, -zRadius),
			new Vector3(-xRadius, 0f, zRadius),
			new Vector3(xRadius, 0f, zRadius),
			new Vector3(xRadius, 0f, -zRadius)
		};
		_borderLine.positionCount = 4;
		_borderLine.SetPositions(positions);
	}

	public bool IsValidPosition(Vector3 position)
	{
		Vector3 snappedPosition = base.transform.position.GetSnappedPosition(1f);
		if (position.x <= snappedPosition.x + (float)xRadius && position.x > snappedPosition.x - (float)xRadius + 2f && position.z < snappedPosition.z + (float)zRadius - 1f && position.z >= snappedPosition.z - (float)zRadius)
		{
			return true;
		}
		return false;
	}

	public void ShowBorder()
	{
		_borderLine.enabled = true;
	}

	public void HideBorder()
	{
		_borderLine.enabled = false;
	}

	public void OnDrawGizmosSelected()
	{
		Vector3 center = base.transform.position.GetSnappedPosition(1f) + Vector3.up * 0.05f;
		Vector3 vector = new Vector3(xRadius, 0f, zRadius);
		Gizmos.color = validPlaceColor;
		Gizmos.DrawCube(center, vector * 2f);
	}
}
