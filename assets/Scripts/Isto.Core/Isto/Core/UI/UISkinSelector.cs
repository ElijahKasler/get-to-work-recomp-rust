using System.Collections.Generic;
using System.Linq;
using Isto.Core.Inputs;
using Isto.Core.Skins;
using Isto.Core.Themes;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class UISkinSelector : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
{
	[Header("Assignations")]
	[SerializeField]
	private TMP_Dropdown _themeDropdown;

	[Space]
	[SerializeField]
	private TMP_Dropdown _playerSkinSetDropdown;

	[SerializeField]
	private TMP_Dropdown _playerHatDropdown;

	[SerializeField]
	private TMP_Dropdown _playerHeadDropdown;

	[SerializeField]
	private TMP_Dropdown _playerTorsoDropdown;

	[Space]
	[SerializeField]
	private TMP_Dropdown _miniDeerDropdown;

	[SerializeField]
	private TMP_Dropdown _pushbackDropdown;

	[Space]
	[SerializeField]
	private TMP_Dropdown _advancedItemsDropdown;

	[Space]
	[SerializeField]
	private CoreButtonController _applyUIButton;

	[SerializeField]
	private Button _applyButton;

	private bool _dragging;

	private Vector2 _previousMousePos;

	private IControls _controls;

	private ThemeSetup _themeSetup;

	private MasterSkinList _masterSkinList;

	private ThemeManager _themeManager;

	[Inject]
	public void Inject(IControls controls, ThemeSetup themeSetup, MasterSkinList masterSkinList, ThemeManager themeManager)
	{
		_controls = controls;
		_themeSetup = themeSetup;
		_masterSkinList = masterSkinList;
		_themeManager = themeManager;
	}

	private void OnEnable()
	{
		Initialize();
		PopulateDropdowns();
		RegisterEvents();
	}

	private void OnDisable()
	{
		UnregisterEvents();
	}

	private void Update()
	{
		if (_dragging)
		{
			Vector2 vector = _controls.GetPointerPosition() - _previousMousePos;
			_previousMousePos = _controls.GetPointerPosition();
			(base.transform as RectTransform).anchoredPosition += new Vector2(vector.x, vector.y);
		}
	}

	private void Initialize()
	{
		DisableUnusedControls();
	}

	private void DisableUnusedControls()
	{
		_playerHeadDropdown.gameObject.SetActive(value: false);
		_pushbackDropdown.gameObject.SetActive(value: false);
		_applyButton.gameObject.SetActive(value: false);
	}

	private void PopulateDropdowns()
	{
		IEnumerable<string> options = _themeSetup.themes.Select((ThemeDefinition x) => x.internalName);
		PopulateDropdown(_themeDropdown, options);
		OnThemeChanged();
		IEnumerable<string> options2 = _masterSkinList.playerSets.Select((PlayerSkinSet x) => x.skinSetInternalName);
		PopulateDropdown(_playerSkinSetDropdown, options2);
		OnPlayerSkinSetChanged();
		IEnumerable<string> options3 = from x in _masterSkinList.playerParts
			where x.type == PlayerSkinPart.SkinPartType.Hat
			select x.skinPartInternalName;
		PopulateDropdown(_playerHatDropdown, options3);
		OnPlayerHatChanged();
		IEnumerable<string> options4 = from x in _masterSkinList.playerParts
			where x.type == PlayerSkinPart.SkinPartType.Body
			select x.skinPartInternalName;
		PopulateDropdown(_playerTorsoDropdown, options4);
		OnPlayerBodyChanged();
		IEnumerable<string> options5 = from x in _masterSkinList.creatureSets
			where x.type == Identifier.IdentifierFlags.MiniDeer
			select x.skinSetInternalName;
		PopulateDropdown(_miniDeerDropdown, options5);
		OnMiniDeerSkinChanged();
		IEnumerable<string> options6 = from x in _masterSkinList.creatureSets
			where Identifier.IdentifierFlags.AllPushbacks.HasFlag(x.type)
			select x.skinSetInternalName;
		PopulateDropdown(_pushbackDropdown, options6);
		OnPushbackSkinChanged();
		IEnumerable<string> options7 = _masterSkinList.itemGroups.Select((ItemSkinGroup x) => x.skinGroupInternalName);
		PopulateDropdown(_advancedItemsDropdown, options7);
		OnAdvancedItemsSkinChanged();
		_playerHeadDropdown.ClearOptions();
	}

	private void PopulateDropdown(TMP_Dropdown dropdown, IEnumerable<string> options)
	{
		dropdown.ClearOptions();
		List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
		foreach (string option in options)
		{
			if (option != null)
			{
				list.Add(new TMP_Dropdown.OptionData(option));
			}
		}
		dropdown.AddOptions(list);
	}

	private void RegisterEvents()
	{
		Events.Subscribe("ThemeChanged", OnThemeChanged);
		Events.Subscribe("PlayerSkinSetChanged", OnPlayerSkinSetChanged);
		Events.Subscribe("PlayerHatChanged", OnPlayerHatChanged);
		Events.Subscribe("PlayerBodyChanged", OnPlayerBodyChanged);
		Events.Subscribe("MiniDeerSkinChanged", OnMiniDeerSkinChanged);
		Events.Subscribe("AdvancedItemsSkinChanged", OnAdvancedItemsSkinChanged);
		_themeDropdown.onValueChanged.AddListener(OnThemeSelectionChanged);
		_playerSkinSetDropdown.onValueChanged.AddListener(OnPlayerSkinSetSelectionChanged);
		_playerHatDropdown.onValueChanged.AddListener(OnPlayerHatSelectionChanged);
		_playerTorsoDropdown.onValueChanged.AddListener(OnPlayerBodySelectionChanged);
		_miniDeerDropdown.onValueChanged.AddListener(OnMiniDeerSkinSelectionChanged);
		_advancedItemsDropdown.onValueChanged.AddListener(OnAdvancedItemsSkinSelectionChanged);
	}

	private void UnregisterEvents()
	{
		Events.UnSubscribe("ThemeChanged", OnThemeChanged);
		Events.UnSubscribe("PlayerSkinSetChanged", OnPlayerSkinSetChanged);
		Events.UnSubscribe("PlayerHatChanged", OnPlayerHatChanged);
		Events.UnSubscribe("PlayerBodyChanged", OnPlayerBodyChanged);
		Events.UnSubscribe("MiniDeerSkinChanged", OnMiniDeerSkinChanged);
		Events.UnSubscribe("AdvancedItemsSkinChanged", OnAdvancedItemsSkinChanged);
		_themeDropdown.onValueChanged.RemoveListener(OnThemeSelectionChanged);
		_playerSkinSetDropdown.onValueChanged.RemoveListener(OnPlayerSkinSetSelectionChanged);
		_playerHatDropdown.onValueChanged.RemoveListener(OnPlayerHatSelectionChanged);
		_playerTorsoDropdown.onValueChanged.RemoveListener(OnPlayerBodySelectionChanged);
		_miniDeerDropdown.onValueChanged.RemoveListener(OnMiniDeerSkinSelectionChanged);
		_advancedItemsDropdown.onValueChanged.RemoveListener(OnAdvancedItemsSkinSelectionChanged);
	}

	private int GetOptionIndex(string optionName, TMP_Dropdown dropdown)
	{
		int num = -1;
		for (int i = 0; i < dropdown.options.Count; i++)
		{
			if (dropdown.options[i].text == optionName)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			Debug.LogError("UISkinSelector: Option \"" + optionName + "\" not found in dropdown " + dropdown.transform.parent.name, dropdown);
		}
		return num;
	}

	private void OnThemeChanged()
	{
		int optionIndex = GetOptionIndex(_themeManager.CurrentTheme.internalName, _themeDropdown);
		_themeDropdown.SetValueWithoutNotify(optionIndex);
	}

	private void OnThemeSelectionChanged(int selected)
	{
		string text = _themeDropdown.options[selected].text;
		ThemeDefinition theme = _themeSetup.GetTheme(text);
		_themeManager.CurrentTheme = theme;
	}

	private void OnPlayerSkinSetChanged()
	{
		string skinSetInternalName = _themeManager.CurrentPlayerSet.skinSetInternalName;
		_playerSkinSetDropdown.SetValueWithoutNotify(GetOptionIndex(skinSetInternalName, _playerSkinSetDropdown));
	}

	private void OnPlayerSkinSetSelectionChanged(int selected)
	{
		string text = _playerSkinSetDropdown.options[selected].text;
		_themeManager.CurrentPlayerSet = _masterSkinList.GetPlayerSkinSet(text);
	}

	private void OnPlayerHatChanged()
	{
		_playerHatDropdown.SetValueWithoutNotify(GetOptionIndex(_themeManager.CurrentPlayerHat.skinPartInternalName, _playerHatDropdown));
	}

	private void OnPlayerHatSelectionChanged(int selected)
	{
		string text = _playerHatDropdown.options[selected].text;
		_themeManager.CurrentPlayerHat = _masterSkinList.GetPlayerHatSkin(text);
	}

	private void OnPlayerBodyChanged()
	{
		_playerTorsoDropdown.SetValueWithoutNotify(GetOptionIndex(_themeManager.CurrentPlayerBody.skinPartInternalName, _playerTorsoDropdown));
	}

	private void OnPlayerBodySelectionChanged(int selected)
	{
		string text = _playerTorsoDropdown.options[selected].text;
		_themeManager.CurrentPlayerBody = _masterSkinList.GetPlayerBodySkin(text);
	}

	private void OnMiniDeerSkinChanged()
	{
		_miniDeerDropdown.SetValueWithoutNotify(GetOptionIndex(_themeManager.CurrentMiniDeer.skinSetInternalName, _miniDeerDropdown));
	}

	private void OnMiniDeerSkinSelectionChanged(int selected)
	{
		string text = _miniDeerDropdown.options[selected].text;
		_themeManager.CurrentMiniDeer = _masterSkinList.GetMiniDeerSkin(text);
	}

	private void OnPushbackSkinChanged()
	{
		_pushbackDropdown.SetValueWithoutNotify(GetOptionIndex(_themeManager.CurrentPushback.skinSetInternalName, _pushbackDropdown));
	}

	private void OnPushbackSkinSelectionChanged(int selected)
	{
		string text = _pushbackDropdown.options[selected].text;
		_themeManager.CurrentPushback = _masterSkinList.GetPushbackSkin(text);
	}

	private void OnAdvancedItemsSkinChanged()
	{
		_advancedItemsDropdown.SetValueWithoutNotify(GetOptionIndex(_themeManager.CurrentItemGroup.skinGroupInternalName, _advancedItemsDropdown));
	}

	private void OnAdvancedItemsSkinSelectionChanged(int selected)
	{
		string text = _advancedItemsDropdown.options[selected].text;
		_themeManager.CurrentItemGroup = _masterSkinList.GetItemSkinGroup(text);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		_dragging = true;
		_previousMousePos = _controls.GetPointerPosition();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		_dragging = false;
	}
}
