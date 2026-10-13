using System;
using System.Text;
using Isto.Core;
using Isto.Core.Game;
using Isto.Core.Localization;
using Isto.Core.UI;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class ChoicePopupEvent : LevelEvent
{
	[Header("Mandatory popup config")]
	[Tooltip("Loc key or raw text OK")]
	[SerializeField]
	private string _question = "";

	[SerializeField]
	private UIModalChoicePopup.ChoicePopupType _popupType;

	[Header("Optional popup config")]
	[Tooltip("This is optional. If empty it will have a valid default text. Loc key or raw text")]
	[SerializeField]
	private string _title = "";

	[Tooltip("This is optional. If enabled, it will override the extra description with in game stats.")]
	[SerializeField]
	public bool _showGameStats;

	[Tooltip("This is optional. If empty it will not exist. Loc key or raw text")]
	[SerializeField]
	private string _extraDescription = "";

	[Tooltip("This is optional. If empty it will have a valid default text. Loc key or raw text")]
	[SerializeField]
	private string _confirm = "";

	[Tooltip("This is optional. If empty it will have a valid default text. Loc key or raw text")]
	[SerializeField]
	private string _cancel = "";

	[SerializeField]
	private UnityEvent _onConfirm;

	[SerializeField]
	private UnityEvent _onCancel;

	private GameState _gameState;

	private UIModalChoicePopup _choicePopup;

	private GTWGameStats _gameStats;

	[Inject]
	public void Inject(GameState gameState, UIModalChoicePopup choicePopup, GTWGameStats gameStats)
	{
		_gameState = gameState;
		_choicePopup = choicePopup;
		_gameStats = gameStats;
	}

	private void OnModalChoicePopup_Yes()
	{
		_onConfirm.Invoke();
	}

	private void OnModalChoicePopup_No()
	{
		_onCancel.Invoke();
	}

	public override void TriggerEvent(bool initialization = false)
	{
		string questionText = Loc.GetString(_question);
		string titleOverride = ((!string.IsNullOrEmpty(_title)) ? Loc.GetString(_title) : null);
		string optionalExtraDescription = ((!string.IsNullOrEmpty(_extraDescription)) ? Loc.GetString(_extraDescription) : null);
		if (_showGameStats)
		{
			optionalExtraDescription = GetStatsDescription();
		}
		string confirmButtonOverride = ((!string.IsNullOrEmpty(_confirm)) ? Loc.GetString(_confirm) : null);
		string cancelButtonOverride = ((!string.IsNullOrEmpty(_cancel)) ? Loc.GetString(_cancel) : null);
		_choicePopup.DisplayChoice(_popupType, questionText, OnModalChoicePopup_Yes, OnModalChoicePopup_No, optionalExtraDescription, titleOverride, confirmButtonOverride, cancelButtonOverride);
	}

	public void ReturnToTitleScreen()
	{
		_gameState.LoadTitleScene();
	}

	private string GetStatsDescription()
	{
		StringBuilder stringBuilder = new StringBuilder();
		string text = UnityUtils.ConvertTimespanToTotalHoursMinutesSeconds(TimeSpan.FromSeconds(_gameStats.GameEndTime));
		stringBuilder.AppendLine();
		stringBuilder.AppendLine(Loc.GetString(GTWConstants.GAME_STATS_TIME_CLIMBING) + " " + text);
		stringBuilder.AppendLine($"{Loc.GetString(GTWConstants.GAME_STATS_TOTAL_HEIGHT_GAINED)} {_gameStats.TotalHeightGained:0.00} m");
		stringBuilder.AppendLine($"{Loc.GetString(GTWConstants.GAME_STATS_TOTAL_HEIGHT_LOST)} {_gameStats.TotalDistanceFallen:0.00} m");
		stringBuilder.AppendLine($"{Loc.GetString(GTWConstants.GAME_STATS_BIG_CRASHES)} {_gameStats.TotalBigCrashes}");
		stringBuilder.AppendLine($"{Loc.GetString(GTWConstants.GAME_STATS_PODCASTS_DISCOVERED)} {_gameStats.GetPodcastCount()}");
		if (_gameStats.DunceHatsCollected > 0)
		{
			stringBuilder.AppendLine($"{Loc.GetString(GTWConstants.GAME_STATS_HATS_COLLECTED)} {_gameStats.DunceHatsCollected}");
		}
		return stringBuilder.ToString();
	}
}
