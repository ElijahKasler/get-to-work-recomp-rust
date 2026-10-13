using Isto.Core.Configuration;
using Isto.Core.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class CoreUIGameModeDisplay : MonoBehaviour
{
	[SerializeField]
	private GameModeDefinition _gameMode;

	[SerializeField]
	private CoreUISetGameModeSubState _parentMenu;

	[SerializeField]
	private Button _modeButton;

	[SerializeField]
	private RectTransform _disabledOverlay;

	[SerializeField]
	protected TextMeshProUGUI modeNameLabel;

	[SerializeField]
	protected TextMeshProUGUI modeDescriptionLabel;

	[SerializeField]
	protected HorizontalLayoutGroup statusLayoutGroup;

	[SerializeField]
	protected TextMeshProUGUI dateLabel;

	protected ILocalizationProvider _localization;

	protected LocTerm.Factory _localizedStringFactory;

	[Inject]
	public void Inject(ILocalizationProvider localization, LocTerm.Factory localizedFactory)
	{
		_localization = localization;
		_localizedStringFactory = localizedFactory;
	}

	protected virtual void OnEnable()
	{
		CreateLocExpressionForGameMode(_gameMode.NameLoc.mTerm, _gameMode.internalName).LocalizeInto(modeNameLabel);
		CreateLocExpressionForGameMode(_gameMode.DescriptionLoc.mTerm, _gameMode.internalName).LocalizeInto(modeDescriptionLabel);
		if (statusLayoutGroup != null)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(statusLayoutGroup.transform as RectTransform);
		}
		bool flag = _gameMode != null && _gameMode.Allowed;
		if (_disabledOverlay != null)
		{
			_disabledOverlay.gameObject.SetActive(!flag);
		}
		if (_modeButton != null)
		{
			_modeButton.interactable = flag;
		}
	}

	public void SelectModeButtonClicked()
	{
		_parentMenu.ModeButton_OnSubmitted(_gameMode);
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
