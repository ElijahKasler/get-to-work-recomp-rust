using UnityEngine;
using Zenject;

namespace Isto.Core.Inputs;

public class ControlSettingsChangedListener : MonoBehaviour
{
	public Behaviour[] enabledForController;

	public Behaviour[] enabledForKeyboard;

	public GameObject[] activeForController;

	public GameObject[] activeForKeyboard;

	private bool _eventRegistered;

	private IControls _controls;

	[Inject]
	public void Inject(IControls controls)
	{
		_controls = controls;
	}

	private void Start()
	{
		Events_OnSettingsChanged();
		RegisterEvents();
	}

	private void OnDestroy()
	{
		UnregisterEvents();
	}

	private void RegisterEvents()
	{
		if (!_eventRegistered)
		{
			Events.Subscribe("SettingsChanged", Events_OnSettingsChanged);
			_eventRegistered = true;
		}
	}

	private void UnregisterEvents()
	{
		if (_eventRegistered)
		{
			Events.UnSubscribe("SettingsChanged", Events_OnSettingsChanged);
			_eventRegistered = false;
		}
	}

	private void Events_OnSettingsChanged()
	{
		bool flag = _controls.UsingJoystick();
		for (int i = 0; i < enabledForController.Length; i++)
		{
			enabledForController[i].enabled = flag;
		}
		for (int j = 0; j < enabledForKeyboard.Length; j++)
		{
			enabledForKeyboard[j].enabled = !flag;
		}
		for (int k = 0; k < activeForController.Length; k++)
		{
			activeForController[k].SetActive(flag);
		}
		for (int l = 0; l < activeForKeyboard.Length; l++)
		{
			activeForKeyboard[l].SetActive(!flag);
		}
	}
}
