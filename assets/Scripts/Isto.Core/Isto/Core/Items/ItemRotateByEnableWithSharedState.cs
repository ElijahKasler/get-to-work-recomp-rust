using UnityEngine;

namespace Isto.Core.Items;

public class ItemRotateByEnableWithSharedState : ItemRotateState
{
	[Header("Child Objects for each direction")]
	[Tooltip("0,0,1 OR NE")]
	public Transform[] directionOne;

	[Tooltip("-1,0,0 OR NW")]
	public Transform[] directionTwo;

	[Tooltip("0,0,-1")]
	public Transform[] directionThree;

	[Tooltip("1,0,0")]
	public Transform[] directionFour;

	public override void HandleRotation(int direction)
	{
		base.HandleRotation(direction);
		if (_controller.Forward.z == 1f)
		{
			EnableDirection(1);
		}
		else if (_controller.Forward.x == -1f)
		{
			EnableDirection(2);
		}
		else if (_controller.Forward.z == -1f)
		{
			EnableDirection(3);
		}
		else if (_controller.Forward.x == 1f)
		{
			EnableDirection(4);
		}
		else
		{
			Debug.LogError("Unable to map forward vector to a direction, please check.  Forward: " + _controller.Forward.ToString());
		}
	}

	private void EnableDirection(int direction)
	{
		for (int i = 0; i < directionOne.Length; i++)
		{
			directionOne[i].gameObject.SetActive(value: false);
		}
		for (int j = 0; j < directionTwo.Length; j++)
		{
			directionTwo[j].gameObject.SetActive(value: false);
		}
		for (int k = 0; k < directionThree.Length; k++)
		{
			directionThree[k].gameObject.SetActive(value: false);
		}
		for (int l = 0; l < directionFour.Length; l++)
		{
			directionFour[l].gameObject.SetActive(value: false);
		}
		Transform[] array = direction switch
		{
			1 => directionOne, 
			2 => directionTwo, 
			3 => directionThree, 
			4 => directionFour, 
			_ => directionOne, 
		};
		for (int m = 0; m < array.Length; m++)
		{
			array[m].gameObject.SetActive(value: true);
		}
	}
}
