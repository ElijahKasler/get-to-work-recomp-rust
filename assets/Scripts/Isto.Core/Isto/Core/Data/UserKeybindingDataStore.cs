using System;
using System.Collections.Generic;
using Isto.Core.Inputs;
using Rewired;
using Rewired.Data;
using UnityEngine;
using Zenject;

namespace Isto.Core.Data;

public class UserKeybindingDataStore : UserDataStore
{
	[SerializeField]
	private bool _loadDataOnStart;

	[NonSerialized]
	private bool allowImpreciseJoystickAssignmentMatching = true;

	[NonSerialized]
	private List<int> __allActionIds;

	[Inject]
	private IGameData _gameData;

	private List<int> allActionIds
	{
		get
		{
			if (__allActionIds != null)
			{
				return __allActionIds;
			}
			List<int> list = new List<int>();
			IList<InputAction> actions = ReInput.mapping.Actions;
			for (int i = 0; i < actions.Count; i++)
			{
				list.Add(actions[i].id);
			}
			__allActionIds = list;
			return list;
		}
	}

	protected override void OnInitialize()
	{
		if (_loadDataOnStart)
		{
			Load();
		}
	}

	public override void Load()
	{
		Player player = ReInput.players.GetPlayer(Controls.DEFAULT_REWIRED_PLAYER_ID);
		_gameData.HasCustomControlsData((bool result) =>
		{
			if (result)
			{
				_gameData.LoadCustomControlMappings((PlayerCustomControlsSaveData saveData) =>
				{
					if (saveData != null)
					{
						LoadPlayerDataNow(player, saveData);
					}
					else
					{
						Debug.LogError("Couldn't load data but some exists");
					}
				});
			}
			else
			{
				Save();
			}
		});
	}

	public override void LoadControllerData(int playerId, ControllerType controllerType, int controllerId)
	{
		throw new NotImplementedException();
	}

	public override void LoadControllerData(ControllerType controllerType, int controllerId)
	{
		throw new NotImplementedException();
	}

	public override void LoadInputBehavior(int playerId, int behaviorId)
	{
		throw new NotImplementedException();
	}

	public override void LoadPlayerData(int playerId)
	{
		throw new NotImplementedException();
	}

	public override void Save()
	{
		Player player = ReInput.players.GetPlayer(Controls.DEFAULT_REWIRED_PLAYER_ID);
		SavePlayerDataNow(player);
	}

	public override void SaveControllerData(int playerId, ControllerType controllerType, int controllerId)
	{
		throw new NotImplementedException();
	}

	public override void SaveControllerData(ControllerType controllerType, int controllerId)
	{
		throw new NotImplementedException();
	}

	public override void SaveInputBehavior(int playerId, int behaviorId)
	{
		throw new NotImplementedException();
	}

	public override void SavePlayerData(int playerId)
	{
		throw new NotImplementedException();
	}

	protected override void OnControllerConnected(ControllerStatusChangedEventArgs args)
	{
		if (args.controllerType == ControllerType.Joystick)
		{
			LoadJoystickData(args.controllerId);
		}
	}

	protected override void OnControllerDisconnected(ControllerStatusChangedEventArgs args)
	{
	}

	private void SavePlayerDataNow(Player player)
	{
		if (player == null)
		{
			return;
		}
		Rewired.PlayerSaveData saveData = player.GetSaveData(userAssignableMapsOnly: true);
		PlayerCustomControlsSaveData playerCustomControlsSaveData = new PlayerCustomControlsSaveData();
		foreach (ControllerMapSaveData allControllerMapSaveDatum in saveData.AllControllerMapSaveData)
		{
			playerCustomControlsSaveData.mapDatas.Add(new ControllerMapData
			{
				categoryID = allControllerMapSaveDatum.map.categoryId,
				type = allControllerMapSaveDatum.controllerType,
				xmlString = allControllerMapSaveDatum.map.ToXmlString()
			});
		}
		_gameData.SaveCustomControlMappings(playerCustomControlsSaveData);
	}

	private void LoadPlayerDataNow(Player player, PlayerCustomControlsSaveData saveData)
	{
		LoadControllerMaps(player.id, ControllerType.Keyboard, 0, saveData);
		LoadControllerMaps(player.id, ControllerType.Mouse, 0, saveData);
		foreach (Joystick joystick in player.controllers.Joysticks)
		{
			LoadControllerMaps(player.id, ControllerType.Joystick, joystick.id, saveData);
		}
		RefreshLayoutManager(player.id);
	}

	private void LoadControllerMaps(int playerId, ControllerType controllerType, int controllerId, PlayerCustomControlsSaveData saveData)
	{
		Player player = ReInput.players.GetPlayer(playerId);
		if (player == null)
		{
			return;
		}
		Controller controller = ReInput.controllers.GetController(controllerType, controllerId);
		if (controller == null)
		{
			return;
		}
		IList<InputMapCategory> mapCategories = ReInput.mapping.MapCategories;
		for (int i = 0; i < mapCategories.Count; i++)
		{
			InputMapCategory inputMapCategory = mapCategories[i];
			if (!inputMapCategory.userAssignable)
			{
				continue;
			}
			IList<InputLayout> list = ReInput.mapping.MapLayouts(controller.type);
			for (int j = 0; j < list.Count; j++)
			{
				InputLayout inputLayout = list[j];
				ControllerMap controllerMap = LoadControllerMap(player, controller.identifier, inputMapCategory.id, inputLayout.id, saveData);
				if (controllerMap != null)
				{
					player.controllers.maps.AddMap(controller, controllerMap);
				}
			}
		}
	}

	private ControllerMap LoadControllerMap(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId, PlayerCustomControlsSaveData saveData)
	{
		if (player == null)
		{
			return null;
		}
		string controllerMapXml = GetControllerMapXml(controllerIdentifier, categoryId, saveData);
		if (string.IsNullOrEmpty(controllerMapXml))
		{
			return null;
		}
		ControllerMap controllerMap = ControllerMap.CreateFromXml(controllerIdentifier.controllerType, controllerMapXml);
		if (controllerMap == null)
		{
			return null;
		}
		List<int> list = new List<int>();
		foreach (ActionElementMap allMap in controllerMap.AllMaps)
		{
			list.Add(allMap.actionId);
		}
		AddDefaultMappingsForNewActions(controllerIdentifier, controllerMap, list);
		return controllerMap;
	}

	private string GetControllerMapXml(ControllerIdentifier controllerIdentifier, int categoryId, PlayerCustomControlsSaveData saveData)
	{
		for (int i = 0; i < saveData.mapDatas.Count; i++)
		{
			ControllerMapData controllerMapData = saveData.mapDatas[i];
			if (controllerMapData.type == controllerIdentifier.controllerType && controllerMapData.categoryID == categoryId)
			{
				return controllerMapData.xmlString;
			}
		}
		return null;
	}

	private void AddDefaultMappingsForNewActions(ControllerIdentifier controllerIdentifier, ControllerMap controllerMap, List<int> knownActionIds)
	{
		if (controllerMap == null || knownActionIds == null || knownActionIds == null || knownActionIds.Count == 0)
		{
			return;
		}
		ControllerMap controllerMapInstance = ReInput.mapping.GetControllerMapInstance(controllerIdentifier, controllerMap.categoryId, controllerMap.layoutId);
		if (controllerMapInstance == null)
		{
			return;
		}
		List<int> list = new List<int>();
		foreach (int allActionId in allActionIds)
		{
			if (!knownActionIds.Contains(allActionId))
			{
				list.Add(allActionId);
			}
		}
		if (list.Count == 0)
		{
			return;
		}
		foreach (ActionElementMap allMap in controllerMapInstance.AllMaps)
		{
			if (list.Contains(allMap.actionId) && !controllerMap.DoesElementAssignmentConflict(allMap))
			{
				ElementAssignment elementAssignment = new ElementAssignment(controllerMap.controllerType, allMap.elementType, allMap.elementIdentifierId, allMap.axisRange, allMap.keyCode, allMap.modifierKeyFlags, allMap.actionId, allMap.axisContribution, allMap.invert);
				controllerMap.CreateElementMap(elementAssignment);
			}
		}
	}

	private void LoadJoystickData(int joystickId)
	{
		_gameData.HasCustomControlsData((bool result) =>
		{
			if (result)
			{
				_gameData.LoadCustomControlMappings((PlayerCustomControlsSaveData saveData) =>
				{
					if (saveData != null)
					{
						Player player = ReInput.players.GetPlayer(Controls.DEFAULT_REWIRED_PLAYER_ID);
						if (player.controllers.ContainsController(ControllerType.Joystick, joystickId))
						{
							LoadControllerMaps(player.id, ControllerType.Joystick, joystickId, saveData);
						}
					}
				});
			}
		});
	}

	private void RefreshLayoutManager(int playerId)
	{
		ReInput.players.GetPlayer(playerId)?.controllers.maps.layoutManager.Apply();
	}
}
