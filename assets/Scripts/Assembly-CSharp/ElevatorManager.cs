using UnityEngine;
using UnityEngine.Events;

public class ElevatorManager : MonoBehaviour
{
	private int elevatorsCount;

	public bool RandomStartFloor = true;

	public int InitialFloor = 1;

	public UnityAction WasStarted;

	[HideInInspector]
	public int _floor;

	private Transform[] elevators;

	private void Awake()
	{
		if (RandomStartFloor)
		{
			elevatorsCount = base.transform.childCount;
			InitialFloor = Random.Range(1, elevatorsCount + 1);
			WasStarted();
		}
	}
}
