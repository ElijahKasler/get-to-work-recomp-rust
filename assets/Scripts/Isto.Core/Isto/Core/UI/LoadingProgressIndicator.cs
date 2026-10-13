using Isto.Core.Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class LoadingProgressIndicator : MonoBehaviour
{
	[SerializeField]
	private Image _progressFilling;

	[SerializeField]
	private Image _progressCompleteIcon;

	[SerializeField]
	private TextMeshProUGUI _progressStepInfo;

	private bool _callbacksRegistered;

	private GameState _gameState;

	[Inject]
	public void Inject(GameState gameState)
	{
		_gameState = gameState;
	}

	private void Awake()
	{
		if (_progressFilling != null)
		{
			_progressFilling.fillAmount = 0f;
		}
		if (_progressCompleteIcon != null && _progressCompleteIcon.gameObject.activeSelf)
		{
			_progressCompleteIcon.gameObject.SetActive(value: false);
		}
		if (_progressStepInfo != null)
		{
			_progressStepInfo.text = "";
		}
		RegisterCallbacks();
	}

	private void OnDestroy()
	{
		UnregisterCallbacks();
	}

	private void Update()
	{
		if (_progressFilling != null)
		{
			_progressFilling.fillAmount = GameState.LoadProgress;
		}
		if (_progressCompleteIcon != null && !_progressCompleteIcon.gameObject.activeSelf && GameState.LoadProgress >= 1f)
		{
			_progressCompleteIcon.gameObject.SetActive(value: true);
		}
		if (_progressStepInfo != null && _progressStepInfo.text != GameState.LoadingStep)
		{
			_progressStepInfo.text = GameState.LoadingStep;
		}
	}

	private void RegisterCallbacks()
	{
		if (!_callbacksRegistered)
		{
			Events.Subscribe("GameStartFadeIn", OnLoadComplete);
			_callbacksRegistered = true;
		}
	}

	private void UnregisterCallbacks()
	{
		if (_callbacksRegistered)
		{
			Events.UnSubscribe("GameStartFadeIn", OnLoadComplete);
			_callbacksRegistered = false;
		}
	}

	private void OnLoadComplete()
	{
		if (!(this == null) && !(base.gameObject == null))
		{
			UnregisterCallbacks();
		}
	}
}
