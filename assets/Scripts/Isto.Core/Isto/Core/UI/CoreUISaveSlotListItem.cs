using System.Collections.Generic;
using System.Linq;
using Isto.Core.Configuration;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.Core.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class CoreUISaveSlotListItem : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI slotNameLabel;

	[SerializeField]
	private TextMeshProUGUI gameModeLabel;

	private CoreUISaveSlotList _parentMenu;

	private int _slotNumber;

	private GameStateSaveData _metaData;

	private GameState _gameState;

	public int SlotNumber => _slotNumber;

	public GameStateSaveData MetaData => _metaData;

	public RectTransform RectTransform => base.transform as RectTransform;

	[Inject]
	public void Inject(GameState gameState)
	{
		_gameState = gameState;
	}

	[ContextMenu("Select this")]
	public void Select()
	{
		Button component = GetComponent<Button>();
		if (component != null)
		{
			component.Select();
		}
	}

	public void SetupSaveSlot(int slotnumber, GameStateSaveData metaData)
	{
		_slotNumber = slotnumber;
		_metaData = metaData;
		_parentMenu = base.transform.parent.GetComponent<CoreUISaveSlotList>();
		Loc.SetTMProLocalized(slotNameLabel, metaData.saveSlotName);
		IEnumerable<GameModeDefinition> source = from x in _gameState.settingsMapping.GetGameModes()
			where x.InternalName == metaData.gameModeName
			select x;
		string versionToUpgradeTo;
		if (source.Count() < 1)
		{
			Debug.LogWarning("Trying to display a save slot that is registered to unknown game mode: " + metaData.gameModeName);
			Loc.SetTMPro(gameModeLabel, Constants.GAMEMODE_ERROR);
		}
		else if (IsSaveOutOfDate(metaData, out versionToUpgradeTo))
		{
			Loc.SetTMProLocalized(gameModeLabel, Loc.Get(source.First().NameLoc) + Loc.Get(Constants.SAVE_OUT_OF_DATE_SUFFIX));
		}
		else
		{
			Loc.SetTMPro(gameModeLabel, source.First().NameLoc);
		}
	}

	protected virtual bool IsSaveOutOfDate(GameStateSaveData gameStateData, out string versionToUpgradeTo)
	{
		versionToUpgradeTo = "";
		return false;
	}

	public void SlotButtonClicked()
	{
		_parentMenu.SlotButtonClicked(this);
	}
}
