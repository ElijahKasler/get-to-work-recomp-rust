using System.Collections.Generic;
using UnityEngine;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class ActivateRendererEvent : LevelEvent
{
	[SerializeField]
	private List<Renderer> _renderersToActivate = new List<Renderer>();

	[SerializeField]
	private List<Renderer> _renderersToDeactivate = new List<Renderer>();

	[Space]
	[SerializeField]
	private bool _initializeOnAwake = true;

	protected override void Awake()
	{
		base.Awake();
		if (_initializeOnAwake)
		{
			SetRendererActivation(isActive: false);
		}
	}

	private void SetRendererActivation(bool isActive)
	{
		foreach (Renderer item in _renderersToActivate)
		{
			if (item.enabled != isActive)
			{
				item.enabled = isActive;
			}
		}
		foreach (Renderer item2 in _renderersToDeactivate)
		{
			if (item2.enabled == isActive)
			{
				item2.enabled = !isActive;
			}
		}
	}

	public override void TriggerEvent(bool initialization = false)
	{
		SetRendererActivation(isActive: true);
	}
}
