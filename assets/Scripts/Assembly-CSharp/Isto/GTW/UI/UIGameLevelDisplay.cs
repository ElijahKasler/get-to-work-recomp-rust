using Isto.Core.Localization;
using Isto.Core.UI;
using Isto.GTW.Configuration;
using TMPro;
using UnityEngine;
using Zenject;

namespace Isto.GTW.UI;

public class UIGameLevelDisplay : MonoBehaviour
{
	[SerializeField]
	private CoreButton _levelButton;

	[SerializeField]
	protected TextMeshProUGUI levelNumberLabel;

	[SerializeField]
	protected TextMeshProUGUI levelNameLabel;

	[SerializeField]
	protected TextMeshProUGUI attemptsLabel;

	[SerializeField]
	protected TextMeshProUGUI totalTimeLabel;

	[SerializeField]
	protected TextMeshProUGUI bestTimeLabel;

	[SerializeField]
	protected GameObject completedCheckMark;

	[SerializeField]
	protected GameObject isSelectedImage;

	[SerializeField]
	private ColorData _greyedOutTextColor;

	private GTWGameLevelDefinition _gameLevel;

	private UIDoinklerPortfolio _parentMenu;

	protected ILocalizationProvider _localization;

	protected LocTerm.Factory _localizedStringFactory;

	public GTWGameLevelDefinition GameLevel => _gameLevel;

	[Inject]
	public void Inject(ILocalizationProvider localization, LocTerm.Factory localizedFactory)
	{
		_localization = localization;
		_localizedStringFactory = localizedFactory;
	}

	public void Button_OnClick()
	{
		_parentMenu.LevelDisplayButton_OnPressed(_gameLevel);
	}

	public void NewButtonActive(GTWGameLevelDefinition gameLevel)
	{
		bool flag = gameLevel == _gameLevel;
		if (isSelectedImage.activeSelf != flag)
		{
			isSelectedImage.SetActive(flag);
		}
	}

	public void Setup(GTWGameLevelDefinition _gameLvl, UIDoinklerPortfolio _parentMenu)
	{
		_gameLevel = _gameLvl;
		this._parentMenu = _parentMenu;
		CreateLocExpressionForGameMode(_gameLevel.LevelName.mTerm, _gameLevel.fallbackLevelName).LocalizeInto(levelNameLabel);
		levelNumberLabel.text = _gameLevel.LevelNumber.ToString("D2");
		attemptsLabel.text = ((_gameLevel.Attempts > 0) ? _gameLevel.Attempts.ToString() : "-");
		attemptsLabel.color = ((_gameLevel.Attempts > 0) ? Color.black : new Color(0.75f, 0.75f, 0.75f));
		totalTimeLabel.text = GTWUtils.GetFormattedTimeOrDefaultString(_gameLevel.TotalTimeInLevel, Color.black);
		bestTimeLabel.text = GTWUtils.GetFormattedTimeOrDefaultString(_gameLevel.FastestCompletedTime, Color.black);
		completedCheckMark.SetActive(_gameLevel.IsCompleted);
		bool interactable = (_gameLevel != null && _gameLevel.IsUnlocked) || _parentMenu.AllLevelsUnlocked;
		if (_levelButton != null)
		{
			_levelButton.interactable = interactable;
		}
	}

	private LocExpression CreateLocExpressionForGameMode(string localizedTerm, string fallbackTerm)
	{
		LocTerm.LocalizationType param = LocTerm.LocalizationType.Localized;
		string param2 = localizedTerm;
		if (string.IsNullOrEmpty(localizedTerm))
		{
			param = LocTerm.LocalizationType.NonLocalized;
			param2 = fallbackTerm;
		}
		return new SingleTermLocExpression(_localizedStringFactory.Create(param, param2));
	}
}
