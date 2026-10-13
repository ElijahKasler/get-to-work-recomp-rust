using Isto.Core.Inputs;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class UIButtonHoldDisplay : MonoBehaviour
{
	public UserActions action;

	public float holdTime = 2f;

	public Image radialDial;

	public UIControlDisplayElement controlDisplay;

	public UnityEvent OnHoldComplete;

	private IControls _controls;

	[Inject]
	public void Inject(IControls controls)
	{
		_controls = controls;
	}

	private void Update()
	{
		if (_controls.GetButton(action))
		{
			radialDial.fillAmount += Time.deltaTime / holdTime;
		}
		else
		{
			radialDial.fillAmount -= Time.deltaTime / holdTime;
		}
		if (radialDial.fillAmount >= 1f)
		{
			OnHoldComplete.Invoke();
		}
	}
}
