using UnityEngine;

namespace Isto.Core.Items;

public class ItemRotateByEnableChildState : ItemRotateState
{
	[Header("Child Objects for each direction")]
	[Tooltip("0,0,1 OR NE")]
	public Transform directionOne;

	[Tooltip("-1,0,0 OR NW")]
	public Transform directionTwo;

	[Tooltip("0,0,-1")]
	public Transform directionThree;

	[Tooltip("1,0,0")]
	public Transform directionFour;

	public override void HandleRotation(int direction)
	{
		base.HandleRotation(direction);
		if (_controller.Forward.z == 1f)
		{
			EnableDirection(1);
			return;
		}
		if (_controller.Forward.x == -1f)
		{
			EnableDirection(2);
			return;
		}
		if (_controller.Forward.z == -1f)
		{
			EnableDirection(3);
			return;
		}
		if (_controller.Forward.x == 1f)
		{
			EnableDirection(4);
			return;
		}
		throw new UnityException("Unalbe to map forward vector to a direction, please check.  Forward: " + _controller.Forward.ToString());
	}

	protected virtual void EnableDirection(int direction)
	{
		directionOne.gameObject.SetActive(direction == 1);
		directionTwo.gameObject.SetActive(direction == 2);
		directionThree.gameObject.SetActive(direction == 3);
		directionFour.gameObject.SetActive(direction == 4);
	}
}
