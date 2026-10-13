using I2.Loc;
using Isto.Core;
using Isto.Core.Localization;
using TMPro;
using UnityEngine;
using Zenject;

namespace Isto.GTW.Localization;

public class CanvasTooltipLocalization : MonoBehaviour
{
	[SerializeField]
	private LocalizedString _mainLevelTips;

	[SerializeField]
	private TextMeshProUGUI _tooltipText;

	private LocTerm.Factory _locTermFactory;

	[Inject]
	public void Inject(LocTerm.Factory locTermFactory)
	{
		_locTermFactory = locTermFactory;
	}

	private void Start()
	{
		LocalizeTerm();
	}

	private void OnEnable()
	{
		Events.Subscribe("LanguageChanged", SettingsChanged_HandleLocalization);
		Events.Subscribe("ControlsChanged", SettingsChanged_HandleLocalization);
	}

	private void OnDisable()
	{
		Events.UnSubscribe("LanguageChanged", SettingsChanged_HandleLocalization);
		Events.UnSubscribe("ControlsChanged", SettingsChanged_HandleLocalization);
	}

	private void SettingsChanged_HandleLocalization()
	{
		LocalizeTerm();
	}

	private void LocalizeTerm()
	{
		string translation = _locTermFactory.Create(LocTerm.LocalizationType.Localized, _mainLevelTips.mTerm).Localize();
		LocalizationManager.ApplyLocalizationParams(ref translation);
		_tooltipText.text = translation;
	}
}
