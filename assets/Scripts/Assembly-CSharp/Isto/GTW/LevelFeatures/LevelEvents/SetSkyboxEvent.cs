using Isto.GTW.Managers;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class SetSkyboxEvent : LevelEvent
{
	[SerializeField]
	private Material _newBox;

	[Tooltip("Expects to be different for each material")]
	[SerializeField]
	private int _serializationId;

	private static readonly string SKYBOX_PROGRESS_ID = "SkyboxEventProgress";

	private LevelVariables _levelVariables;

	[Inject]
	public void Inject(LevelVariables levelVariables)
	{
		_levelVariables = levelVariables;
	}

	private void Start()
	{
		int num = _levelVariables.GetInt(SKYBOX_PROGRESS_ID);
		if (_serializationId == num && RenderSettings.skybox != _newBox)
		{
			RenderSettings.skybox = _newBox;
		}
	}

	public override void TriggerEvent(bool initialization = false)
	{
		if (!(RenderSettings.skybox == _newBox))
		{
			RenderSettings.skybox = _newBox;
			_levelVariables.SetInt(SKYBOX_PROGRESS_ID, _serializationId);
		}
	}
}
