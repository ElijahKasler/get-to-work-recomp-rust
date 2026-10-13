using FMODUnity;
using Isto.Core.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Isto.GTW.Audio;

public class CoreButtonSFX : MonoBehaviour
{
	[SerializeField]
	private EventReference _onSubmitRef;

	[SerializeField]
	private EventReference _onSelectRef;

	[SerializeField]
	private EventReference _onDeselectRef;

	private CoreButton _coreButton;

	private void Awake()
	{
		_coreButton = GetComponent<CoreButton>();
		_coreButton.OnSubmitEvent += OnSubmit;
		_coreButton.OnSelectEvent += OnSelect;
		_coreButton.OnDeselectEvent += OnDeselect;
	}

	private void OnDestroy()
	{
		_coreButton.OnSubmitEvent -= OnSubmit;
		_coreButton.OnSelectEvent -= OnSelect;
		_coreButton.OnDeselectEvent -= OnDeselect;
	}

	private void OnSubmit()
	{
		if (!_onSubmitRef.IsNull)
		{
			RuntimeManager.PlayOneShot(_onSubmitRef);
		}
	}

	private void OnSelect(BaseEventData baseEventData)
	{
		if (!_onSelectRef.IsNull)
		{
			RuntimeManager.PlayOneShot(_onSelectRef);
		}
	}

	private void OnDeselect(BaseEventData baseEventData)
	{
		if (!_onDeselectRef.IsNull)
		{
			RuntimeManager.PlayOneShot(_onDeselectRef);
		}
	}
}
