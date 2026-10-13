using Isto.Core.Inputs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class UIControlDisplayFakeElement : MonoBehaviour
{
	public bool shownForMouseInput;

	public bool shownForControllerInput;

	public Image actionImage;

	public LayoutElement layoutElement;

	private IControls _controls;

	private TextMeshProUGUI _descriptionText;

	[Inject]
	public void Inject(IControls controls)
	{
		_controls = controls;
	}

	private void Awake()
	{
		_descriptionText = GetComponentInChildren<TextMeshProUGUI>();
	}

	private void OnEnable()
	{
		OnSettingsChanged();
		Events.Subscribe("SettingsChanged", OnSettingsChanged);
		Events.Subscribe("InputChanged", OnSettingsChanged);
	}

	private void OnDisable()
	{
		Events.UnSubscribe("SettingsChanged", OnSettingsChanged);
		Events.UnSubscribe("InputChanged", OnSettingsChanged);
	}

	private void Start()
	{
		OnSettingsChanged();
	}

	private void OnSettingsChanged()
	{
		UpdateControlDisplay(_controls);
	}

	public void UpdateControlDisplay(IControls controls)
	{
		if (Controls.UsingController)
		{
			if (shownForControllerInput)
			{
				EnableDisplay();
			}
			else
			{
				DisableDisplay();
			}
		}
		else if (shownForMouseInput)
		{
			EnableDisplay();
		}
		else
		{
			DisableDisplay();
		}
	}

	private void EnableDisplay()
	{
		if ((bool)actionImage)
		{
			actionImage.enabled = true;
		}
		if ((bool)_descriptionText)
		{
			_descriptionText.enabled = true;
		}
		if ((bool)layoutElement)
		{
			layoutElement.enabled = true;
		}
	}

	private void DisableDisplay()
	{
		if ((bool)actionImage)
		{
			actionImage.enabled = false;
		}
		if ((bool)_descriptionText)
		{
			_descriptionText.enabled = false;
		}
		if ((bool)layoutElement)
		{
			layoutElement.enabled = false;
		}
	}
}
