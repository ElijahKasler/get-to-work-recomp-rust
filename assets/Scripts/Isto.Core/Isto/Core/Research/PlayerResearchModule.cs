using System;
using System.Collections.Generic;
using System.Linq;
using FMODUnity;
using I2.Loc;
using Isto.Core.Analytics;
using Isto.Core.Audio;
using Isto.Core.Automation;
using Isto.Core.Beings;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.Core.Inputs;
using Isto.Core.Items;
using Isto.Core.Localization;
using Isto.Core.Power;
using Isto.Core.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.Research;

public class PlayerResearchModule : InteractableBuilding, IResearcher, IPoweredBuilding
{
	[FormerlySerializedAs("itemPlacementPrefab")]
	[SerializeField]
	private GameObject _itemPlacementPrefab;

	[FormerlySerializedAs("itemPlacementPosition")]
	[SerializeField]
	private Transform _itemPlacementPosition;

	[SerializeField]
	private List<ResearchItem> _startingResearchItems = new List<ResearchItem>();

	[SerializeField]
	private Animator _animator;

	[SerializeField]
	private Transform _interactionTarget;

	[SerializeField]
	private BuildingLevel _buildingLevel;

	[SerializeField]
	[EventRef]
	private string _researchCompleteSFX = "";

	[SerializeField]
	[EventRef]
	private string _researchRunningSFXLoop = "";

	[SerializeField]
	[EventRef]
	private string _noPowerOnInteractionSFX = "";

	[Header("Power")]
	[SerializeField]
	private TetheredBuilding _buildingPower;

	[Header("Info Messages")]
	[SerializeField]
	private LocalizedString _researchCompleteMessageKey;

	[SerializeField]
	private float _researchCompleteTimeBetweenMessages = 30f;

	[Header("Boosters")]
	[SerializeField]
	private TextMeshProUGUI _boosterFactorTextbox;

	[Header("Progress")]
	[SerializeField]
	private Image _progressSlider;

	[FormerlySerializedAs("progressContainer")]
	[SerializeField]
	private GameObject _progressContainer;

	[SerializeField]
	private Canvas _progressCanvas;

	[SerializeField]
	private float _additionalInteractionRange = 1f;

	private bool _buildingOpened;

	private List<ResearchItem> _researchedItems = new List<ResearchItem>();

	private GameObject _itemPlacementObject;

	private List<AutomationResearchBooster> _boosters = new List<AutomationResearchBooster>();

	private float _previousBoost;

	private float _researchTimer;

	private bool _researchCompleteMessageDisplayed;

	private ResearchItem _currentResearch;

	private float _currentBoostFactor;

	private IUIGameMenu _mainMenu;

	private IGameSounds _sounds;

	private IAnalyticsHandler _analytics;

	private IUIMessages _uIMessages;

	private PlayerUpgrades _playerUpgrades;

	private PlayerProgress _playerProgress;

	public BuildingLevel BuildingLevel => _buildingLevel;

	public float CurrentBoostFactor => _currentBoostFactor;

	public bool IsResearching => CurrentResearch != null;

	public bool ResearchComplete
	{
		get
		{
			if (CurrentResearch != null)
			{
				return _researchTimer >= CurrentResearchResearchTime;
			}
			return false;
		}
	}

	public ResearchItem CurrentResearch => _currentResearch;

	public float CurrentResearchResearchTime
	{
		get
		{
			if (!ResearchTimeOverride.HasValue)
			{
				return CurrentResearch.researchTime;
			}
			return ResearchTimeOverride.Value;
		}
	}

	public float? ResearchTimeOverride { private get; set; }

	public event Action<ResearchItem> OnResearchComplete;

	public event Action OnBuildingUpgraded;

	[Inject]
	public void Inject(IUIGameMenu mainMenu, IGameSounds gameSounds, IAnalyticsHandler analytics, [Inject(Id = UIMessageHandlerType.HighPriorityMessage)] IUIMessages uIMessages, PlayerUpgrades playerUpgrades, PlayerProgress playerProgress)
	{
		_mainMenu = mainMenu;
		_sounds = gameSounds;
		_analytics = analytics;
		_uIMessages = uIMessages;
		_playerUpgrades = playerUpgrades;
		_playerProgress = playerProgress;
	}

	protected override void Awake()
	{
		_actionList.Clear();
		_actionList.Add(UserActions.INTERACT);
		base.Awake();
	}

	private void Start()
	{
		if (GameState.LoadingFromSave)
		{
			return;
		}
		foreach (UpgradeItem upgrade in _playerUpgrades.GetActiveUpgrades())
		{
			ResearchItem researchItem = _masterItemList.researchItems.Where((ResearchItem x) => x.upgradeUnlocks.Any((UpgradeItem y) => y.itemID == upgrade.itemID)).FirstOrDefault();
			if (researchItem != null)
			{
				_researchedItems.Add(researchItem);
			}
		}
	}

	protected override void Update()
	{
		_previousBoost = CurrentBoostFactor;
		_currentBoostFactor = GetBoostFactor();
		if (_previousBoost != CurrentBoostFactor)
		{
			UpdateBoostFactorText();
		}
		if (!(CurrentResearch == null) && _buildingPower.powered)
		{
			_researchTimer += Time.deltaTime * CurrentBoostFactor;
			_progressSlider.fillAmount = GetCurrentResearchPercent();
			if (ResearchComplete && !_researchCompleteMessageDisplayed)
			{
				_researchCompleteMessageDisplayed = true;
				InvokeRepeating("ShowResearchCompleteMessageRepeating", 0.1f, _researchCompleteTimeBetweenMessages);
				_sounds.PlayOneShot(_researchCompleteSFX, base.transform.position);
				_buildingDialogue.ShowAlertMessage(Loc.Get(_researchCompleteMessageKey));
				HideProgressVisuals();
			}
		}
	}

	public override void OnDataLoadComplete()
	{
		if (!GameState.LoadingFromSave)
		{
			foreach (UpgradeItem upgrade in _playerUpgrades.GetActiveUpgrades())
			{
				ResearchItem researchItem = _masterItemList.researchItems.Where((ResearchItem x) => x.upgradeUnlocks.Any((UpgradeItem y) => y.itemID == upgrade.itemID)).FirstOrDefault();
				if (researchItem != null)
				{
					_researchedItems.Add(researchItem);
				}
			}
		}
		if (_buildingOn)
		{
			_animator.SetBool("On", value: true);
			if (!_buildingOpened)
			{
				ShowTutorialArrow();
			}
		}
	}

	private void UpdateBoostFactorText()
	{
		_boosterFactorTextbox?.SetText((CurrentBoostFactor > 1f) ? $"+{CurrentBoostFactor - 1f}x" : "");
	}

	public void LoadData(PlayerResearchSaveData data)
	{
		if (GameState.LoadingFromSave)
		{
			_buildingOn = data.moduleOnline;
			_buildingOpened = data.moduleInspected;
		}
		BuildingLevel.SetStartLevel(data.buildingLevel);
		OnBuildingUpgraded?.Invoke();
		_currentResearch = (string.IsNullOrEmpty(data.currentResearchItemID) ? null : _masterItemList.GetResearchItemByID(data.currentResearchItemID, ""));
		_researchTimer = ((CurrentResearch == null) ? 0f : (data.currentResearchedPercent * CurrentResearch.researchTime));
		for (int i = 0; i < data.researchedItemsIds.Count; i++)
		{
			ResearchItem researchItemByID = _masterItemList.GetResearchItemByID(data.researchedItemsIds[i], "");
			if (researchItemByID != null)
			{
				_researchedItems.Add(researchItemByID);
			}
		}
		if (CurrentResearch != null)
		{
			_animator.SetBool("researching", value: true);
			SetInteractive(state: true);
			ShowProgressVisuals();
		}
	}

	public PlayerResearchSaveData GetResearchSaveData()
	{
		PlayerResearchSaveData playerResearchSaveData = new PlayerResearchSaveData();
		playerResearchSaveData.currentResearchItemID = ((CurrentResearch != null) ? CurrentResearch.ID : "");
		playerResearchSaveData.currentResearchedPercent = GetCurrentResearchPercent();
		playerResearchSaveData.moduleOnline = _buildingOn;
		playerResearchSaveData.moduleInspected = _buildingOpened;
		playerResearchSaveData.buildingLevel = BuildingLevel.Level;
		for (int i = 0; i < _researchedItems.Count; i++)
		{
			playerResearchSaveData.researchedItemsIds.Add(_researchedItems[i].ID);
		}
		return playerResearchSaveData;
	}

	public override void PlayerInteraction(AutomationPlayerController player, UserActions action)
	{
		if (Vector3.Distance(player.transform.position, GetInteractionPosition(player.transform.position)) < player.InteractionRange + _additionalInteractionRange)
		{
			if (_buildingPower.powered)
			{
				if (_itemPlacementObject != null)
				{
					UnityEngine.Object.Destroy(_itemPlacementObject);
					_buildingOpened = true;
				}
				_mainMenu.OpenMenu(GameMenusEnum.PLAYER_RESEARCH);
			}
			else
			{
				_sounds.PlayOneShot(_noPowerOnInteractionSFX, base.transform.position);
			}
		}
		else
		{
			player.SetMoveToAndInteractWithItem(this, 1.5f + _additionalInteractionRange);
		}
	}

	public override Vector3 GetInteractionPosition(Vector3 playerPosition)
	{
		return _interactionTarget.position;
	}

	public override string GetItemName()
	{
		return Loc.GetString(Constants.BUILDING_NAME_RESEARCHMODULE);
	}

	[ContextMenu("Trigger Off to On animation")]
	public void TurnOn()
	{
		if (!_buildingOn)
		{
			_buildingOn = true;
			_animator.SetTrigger("offToOn");
			if (!_buildingOpened)
			{
				ShowTutorialArrow();
			}
			BuildingTurnedOn?.Invoke(this, EventArgs.Empty);
		}
	}

	public void TurnOff()
	{
		_animator.SetBool("On", value: false);
		_buildingOn = false;
	}

	private void ShowTutorialArrow()
	{
		if (_itemPlacementObject == null)
		{
			_itemPlacementObject = UnityEngine.Object.Instantiate(_itemPlacementPrefab, _itemPlacementPosition.position, Quaternion.identity, base.transform);
		}
	}

	public override string GetToolTip(UserActions action)
	{
		return Loc.GetString(Constants.BUILDING_NAME_RESEARCHMODULE);
	}

	public override List<UserActions> GetValidActions()
	{
		return _actionList;
	}

	public bool HasItemBeenResearched(ResearchItem researchItem)
	{
		for (int i = 0; i < _researchedItems.Count; i++)
		{
			if (_researchedItems[i].ID.Equals(researchItem.ID))
			{
				return true;
			}
		}
		return false;
	}

	public void SetResearchItem(ResearchItem researchItem)
	{
		if (HasItemBeenResearched(researchItem))
		{
			Debug.LogError("Trying to research something already been researched.  ItemID:" + researchItem.ID);
			return;
		}
		_currentResearch = researchItem;
		_researchTimer = 0f;
		_animator.SetBool("researching", value: true);
		_sounds.PlayLoop(_researchRunningSFXLoop, base.transform.position);
		_researchCompleteMessageDisplayed = false;
	}

	public float GetCurrentResearchPercent()
	{
		if (CurrentResearch == null)
		{
			return 0f;
		}
		return Mathf.Clamp01(_researchTimer / CurrentResearchResearchTime);
	}

	public void CancelResearch()
	{
		_currentResearch = null;
		_animator.SetBool("researching", value: false);
		HideProgressVisuals();
		_sounds.StopLoop(_researchRunningSFXLoop);
		_researchCompleteMessageDisplayed = false;
	}

	public void CompleteResearch()
	{
		CancelInvoke("ShowResearchCompleteMessageRepeating");
		if (CurrentResearch == null)
		{
			Debug.LogWarning("Trying to complete research that has not been set.");
			return;
		}
		_analytics.RegisterResearchUnlocked(CurrentResearch.ID);
		ActivateResearchItems(CurrentResearch);
		ActivateResearchUpgrades(CurrentResearch);
		_researchedItems.Add(CurrentResearch);
		OnResearchComplete?.Invoke(CurrentResearch);
		Events.RaiseEvent("ResearchComplete");
		_currentResearch = null;
		_animator.SetBool("researching", value: false);
		_sounds.StopLoop(_researchRunningSFXLoop);
		_buildingDialogue.HideAlertMessage();
		HideProgressVisuals();
	}

	public void CompleteAllResearch()
	{
		DeleteAllResearch();
		for (int i = 0; i < _masterItemList.researchItems.Count; i++)
		{
			ResearchItem researchItem = _masterItemList.researchItems[i];
			ActivateResearchItems(researchItem);
			ActivateResearchUpgrades(researchItem);
			_researchedItems.Add(researchItem);
			OnResearchComplete?.Invoke(researchItem);
		}
		for (int j = 0; j < 3; j++)
		{
			_buildingLevel.IncreaseLevel();
		}
		Events.RaiseEvent("ResearchComplete");
	}

	public void DeleteAllResearch()
	{
		if (CurrentResearch != null)
		{
			CompleteResearch();
		}
		_playerProgress.UnlockedItems.Clear();
		_playerProgress.UnlockStartingItemSet();
		_playerUpgrades.UninstallAllUpgrades();
		_playerUpgrades.InstallStartingUpgrades();
		_researchedItems.Clear();
	}

	public void BoostResearch(float amount)
	{
		_researchTimer += amount;
	}

	public void AddBooster(AutomationResearchBooster booster)
	{
		if (!_boosters.Contains(booster))
		{
			_boosters.Add(booster);
		}
	}

	public void RemoveBooster(AutomationResearchBooster booster)
	{
		_boosters.Remove(booster);
	}

	private float GetBoostFactor()
	{
		float num = 1f;
		for (int i = 0; i < _boosters.Count; i++)
		{
			num += _boosters[i].BoostFactor;
		}
		return num;
	}

	private void ShowResearchCompleteMessageRepeating()
	{
		_uIMessages.CreateHighPriorityMsg(Loc.Get(_researchCompleteMessageKey), HighPriorityMessage.MessageType.success, Constants.DEFAULT_INFO_MESSAGE_LONG_DISPLAY_TIME);
	}

	public void UpgradeModule()
	{
		_buildingLevel.IncreaseLevel();
		OnBuildingUpgraded?.Invoke();
		_analytics.RegisterResearchCenterLevelUp(_buildingLevel.Level);
	}

	public void HideProgressVisuals()
	{
		_progressCanvas.enabled = false;
		_progressContainer.SetActive(value: false);
	}

	public void ShowProgressVisuals()
	{
		if (CurrentResearch != null && !ResearchComplete)
		{
			_progressCanvas.enabled = true;
			_progressContainer.SetActive(value: true);
		}
	}

	private void ActivateResearchItems(ResearchItem researched)
	{
		for (int i = 0; i < researched.itemUnlocks.Count; i++)
		{
			_playerProgress.UnlockItem(researched.itemUnlocks[i]);
		}
	}

	private void ActivateResearchUpgrades(ResearchItem researched)
	{
		for (int i = 0; i < researched.upgradeUnlocks.Count; i++)
		{
			_playerUpgrades.InstallUpgrade(researched.upgradeUnlocks[i]);
		}
	}
}
