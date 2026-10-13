using I2.Loc;
using Isto.Core.Localization;
using Isto.Core.UI;
using TMPro;
using UnityEngine;
using Zenject;

namespace Isto.GTW;

public class UIQuitConfirmModalState : UISimpleConfirmModalState
{
	[SerializeField]
	private TextMeshProUGUI _label;

	[SearchableLocalizedString]
	[SerializeField]
	private LocalizedString _saveProgressAutomaticallyMessageLocKey;

	[SearchableLocalizedString]
	[SerializeField]
	private LocalizedString _progressSinceLastSaveMessageLocKey;

	[SearchableLocalizedString]
	[SerializeField]
	private LocalizedString _doinklerPortfolioMessageLocKey;

	[SearchableLocalizedString]
	[SerializeField]
	private LocalizedString _doinklerSpecialMessageLocKey;

	private string _saveProgressAutomaticallyMessageLocalized;

	private string _progressSinceLastSaveMessageLocalized;

	private string _doinklerPortfolioMessageLocalized;

	private string _doinklerSpecialMessageLocalized;

	private ILocalizationProvider _locProvider;

	private GTWGameState _gameState;

	[Inject]
	private void Inject(ILocalizationProvider loc, GTWGameState gameState)
	{
		_locProvider = loc;
		_gameState = gameState;
	}

	private void OnEnable()
	{
		UpdateLoc();
	}

	private void Start()
	{
		RegisterEvents();
	}

	private void OnDestroy()
	{
		UnregisterEvents();
	}

	private void Update()
	{
		UpdateLabel();
	}

	private void RegisterEvents()
	{
		LocalizationManager.OnLocalizeEvent += LocalizationManager_OnLocalizeEvent;
	}

	private void UnregisterEvents()
	{
		LocalizationManager.OnLocalizeEvent -= LocalizationManager_OnLocalizeEvent;
	}

	private void LocalizationManager_OnLocalizeEvent()
	{
		UpdateLoc();
	}

	private void UpdateLoc()
	{
		_saveProgressAutomaticallyMessageLocalized = _locProvider.GetLocalizedText(_saveProgressAutomaticallyMessageLocKey.mTerm);
		_progressSinceLastSaveMessageLocalized = _locProvider.GetLocalizedText(_progressSinceLastSaveMessageLocKey.mTerm);
		_doinklerPortfolioMessageLocalized = _locProvider.GetLocalizedText(_doinklerPortfolioMessageLocKey.mTerm);
		_doinklerSpecialMessageLocalized = _locProvider.GetLocalizedText(_doinklerSpecialMessageLocKey.mTerm);
	}

	private void UpdateLabel()
	{
		if (_gameState.IsDoinklerPortfolio)
		{
			SetMainText(_doinklerPortfolioMessageLocalized);
			return;
		}
		if (_gameState.IsDoinklerSpecial)
		{
			SetMainText(_doinklerSpecialMessageLocalized);
			return;
		}
		SetMainText(_saveProgressAutomaticallyMessageLocalized + " \n \n" + _label.text + " \n \n" + _progressSinceLastSaveMessageLocalized);
	}
}
