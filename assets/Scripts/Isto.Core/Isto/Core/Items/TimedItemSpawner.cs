using Isto.Core.Automation;
using UnityEngine;
using Zenject;

namespace Isto.Core.Items;

public class TimedItemSpawner : MonoBehaviour
{
	public CoreItem itemToDrop;

	public float timePerDrop = 1f;

	public int maxNumDrops = int.MaxValue;

	public bool paused;

	public Color gizmoColor = new Color(1f, 1f, 1f, 1f);

	private int _numTimesDropped;

	private AutomationSystem _system;

	private AutomationSystemController _controller;

	private float _dropTimer;

	[Inject]
	public void Inject(AutomationSystem automationSystem, AutomationSystemController automationSystemController)
	{
		_system = automationSystem;
		_controller = automationSystemController;
	}

	private void Update()
	{
		if (!paused && !_controller.SystemPaused)
		{
			_dropTimer -= Time.deltaTime;
			if (_dropTimer < 0f)
			{
				TryDropItem();
				_dropTimer = timePerDrop;
			}
		}
	}

	private void TryDropItem()
	{
		if (_system.GetOrCreateGridSpace(base.transform.position).ActiveItem == null && _numTimesDropped < maxNumDrops)
		{
			_system.TryAddCoreItem(base.transform.position, itemToDrop);
			_numTimesDropped++;
		}
	}

	public void OnDrawGizmos()
	{
		Gizmos.color = gizmoColor;
		Gizmos.DrawCube(base.transform.position + Constants.GRID_CENTERING_OFFSET, Vector3.one);
	}
}
