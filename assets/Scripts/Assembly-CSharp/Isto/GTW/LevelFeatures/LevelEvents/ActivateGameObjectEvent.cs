using System.Collections.Generic;
using UnityEngine;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class ActivateGameObjectEvent : LevelEvent
{
	[SerializeField]
	private List<GameObject> _gameObjectsToActivate = new List<GameObject>();

	[SerializeField]
	private List<GameObject> _gameObjectsToDeactivate = new List<GameObject>();

	[Space]
	[SerializeField]
	private bool _initializeOnAwake = true;

	protected override void Awake()
	{
		base.Awake();
		if (_initializeOnAwake)
		{
			SetGameObjectActivation(isActive: false);
		}
	}

	private void SetGameObjectActivation(bool isActive)
	{
		foreach (GameObject item in _gameObjectsToActivate)
		{
			if (item.activeSelf != isActive)
			{
				item.SetActive(isActive);
			}
		}
		foreach (GameObject item2 in _gameObjectsToDeactivate)
		{
			if (item2.activeSelf == isActive)
			{
				item2.SetActive(!isActive);
			}
		}
	}

	public override void TriggerEvent(bool initialization = false)
	{
		SetGameObjectActivation(isActive: true);
	}
}
