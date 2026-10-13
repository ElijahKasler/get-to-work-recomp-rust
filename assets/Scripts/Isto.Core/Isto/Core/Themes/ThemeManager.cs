using Isto.Core.Analytics;
using Isto.Core.Data;
using Isto.Core.Skins;
using UnityEngine;
using Zenject;

namespace Isto.Core.Themes;

public class ThemeManager : MonoBehaviour
{
	private ThemeDefinition _defaultTheme;

	private ThemeDefinition _customTheme;

	private PlayerSkinSet _customPlayerSkinSet;

	private ThemeDefinition _currentTheme;

	private PlayerSkinSet _currentPlayerSet;

	private PlayerSkinPart _currentPlayerHat;

	private PlayerSkinPart _currentPlayerBody;

	private CreatureSkinSet _currentMiniDeer;

	private CreatureSkinSet _currentPushback;

	private ItemSkinGroup _currentItemGroup;

	private MasterSkinList _masterSkinList;

	private ThemeSetup _themeSetup;

	private IAnalyticsHandler _analytics;

	public ThemeDefinition CurrentTheme
	{
		get
		{
			return _currentTheme;
		}
		set
		{
			if (_currentTheme == null || _currentTheme.internalName != value.internalName)
			{
				_currentTheme = value;
				Events.RaiseEvent("ThemeChanged");
				_analytics.RegisterThemeChanged(_currentTheme.internalName);
				ApplyCurrentTheme();
			}
		}
	}

	public PlayerSkinSet CurrentPlayerSet
	{
		get
		{
			return _currentPlayerSet;
		}
		set
		{
			if (_currentPlayerSet == null || _currentPlayerSet.skinSetInternalName != value.skinSetInternalName)
			{
				_currentPlayerSet = value;
				if (_currentPlayerSet.skinSetInternalName != _currentTheme?.skinSet?.player?.skinSetInternalName)
				{
					SetCustomTheme();
				}
				Events.RaiseEvent("PlayerSkinSetChanged");
				ApplyCurrentPlayerSkinSet();
			}
		}
	}

	public PlayerSkinPart CurrentPlayerHat
	{
		get
		{
			return _currentPlayerHat;
		}
		set
		{
			if (_currentPlayerHat == null || _currentPlayerHat.skinPartInternalName != value.skinPartInternalName)
			{
				_currentPlayerHat = value;
				if (_currentPlayerHat.skinPartInternalName != _currentPlayerSet?.hat?.skinPartInternalName)
				{
					SetCustomPlayerSkinSet();
				}
				Events.RaiseEvent("PlayerHatChanged");
			}
		}
	}

	public PlayerSkinPart CurrentPlayerBody
	{
		get
		{
			return _currentPlayerBody;
		}
		set
		{
			if (_currentPlayerBody == null || _currentPlayerBody.skinPartInternalName != value.skinPartInternalName)
			{
				_currentPlayerBody = value;
				if (_currentPlayerBody.skinPartInternalName != _currentPlayerSet?.body?.skinPartInternalName)
				{
					SetCustomPlayerSkinSet();
				}
				Events.RaiseEvent("PlayerBodyChanged");
			}
		}
	}

	public CreatureSkinSet CurrentMiniDeer
	{
		get
		{
			return _currentMiniDeer;
		}
		set
		{
			if (_currentMiniDeer == null || _currentMiniDeer.skinSetInternalName != value.skinSetInternalName)
			{
				_currentMiniDeer = value;
				if (_currentMiniDeer.skinSetInternalName != _currentTheme?.skinSet?.miniDeer?.skinSetInternalName)
				{
					SetCustomTheme();
				}
				Events.RaiseEvent("MiniDeerSkinChanged");
			}
		}
	}

	public CreatureSkinSet CurrentPushback
	{
		get
		{
			return _currentPushback;
		}
		set
		{
			if (_currentPushback == null || _currentPushback.skinSetInternalName != value.skinSetInternalName)
			{
				_currentPushback = value;
				if (_currentPushback.skinSetInternalName != _currentTheme?.skinSet?.pushback?.skinSetInternalName)
				{
					SetCustomTheme();
				}
				Events.RaiseEvent("PushbackSkinChanged");
			}
		}
	}

	public ItemSkinGroup CurrentItemGroup
	{
		get
		{
			return _currentItemGroup;
		}
		set
		{
			if (_currentItemGroup == null || _currentItemGroup.skinGroupInternalName != value.skinGroupInternalName)
			{
				_currentItemGroup = value;
				if (_currentItemGroup.skinGroupInternalName != _currentTheme?.skinSet?.itemGroup?.skinGroupInternalName)
				{
					SetCustomTheme();
				}
				Events.RaiseEvent("AdvancedItemsSkinChanged");
			}
		}
	}

	private void Awake()
	{
		_defaultTheme = _themeSetup.GetTheme(Constants.DEFAULT_THEME_NAME);
		_customTheme = _themeSetup.GetTheme(Constants.CUSTOM_THEME_NAME);
		_customPlayerSkinSet = _masterSkinList.GetPlayerSkinSet(Constants.CUSTOM_SKIN_SET_NAME);
		_currentTheme = _defaultTheme;
		Events.RaiseEvent("ThemeChanged");
		ApplyCurrentTheme();
	}

	[Inject]
	public void Inject(MasterSkinList masterSkinList, ThemeSetup themeSetup, IAnalyticsHandler analytics)
	{
		_masterSkinList = masterSkinList;
		_themeSetup = themeSetup;
		_analytics = analytics;
	}

	private void SetCustomTheme()
	{
		CurrentTheme = _customTheme;
	}

	private void SetCustomPlayerSkinSet()
	{
		CurrentPlayerSet = _customPlayerSkinSet;
	}

	private void ApplyCurrentTheme()
	{
		if (_currentTheme.skinSet?.player != null)
		{
			CurrentPlayerSet = _currentTheme.skinSet.player;
		}
		if (_currentTheme.skinSet?.miniDeer != null)
		{
			CurrentMiniDeer = _currentTheme.skinSet.miniDeer;
		}
		if (_currentTheme.skinSet?.pushback != null)
		{
			CurrentPushback = _currentTheme.skinSet.pushback;
		}
		if (_currentTheme.skinSet?.itemGroup != null)
		{
			CurrentItemGroup = _currentTheme.skinSet.itemGroup;
		}
	}

	private void ApplyCurrentPlayerSkinSet()
	{
		if (_currentPlayerSet.hat != null)
		{
			CurrentPlayerHat = _currentPlayerSet.hat;
		}
		if (_currentPlayerSet.body != null)
		{
			CurrentPlayerBody = _currentPlayerSet.body;
		}
	}

	public CreatureSkinSet GetCurrentCreatureSkinSet(GameObject creature)
	{
		Identifier component = creature.GetComponent<Identifier>();
		if (component == null)
		{
			return null;
		}
		if (component.Flag == Identifier.IdentifierFlags.MiniDeer)
		{
			return CurrentMiniDeer;
		}
		return null;
	}

	public ThemeManagerData GetData()
	{
		return new ThemeManagerData
		{
			themeInternalName = CurrentTheme?.internalName,
			playerSetInternalName = CurrentPlayerSet?.skinSetInternalName,
			playerHatInternalName = CurrentPlayerHat?.skinPartInternalName,
			playerBodyInternalName = CurrentPlayerBody?.skinPartInternalName,
			miniDeerInternalName = CurrentMiniDeer?.skinSetInternalName,
			pushbackInternalName = CurrentPushback?.skinSetInternalName,
			itemGroupInternalName = CurrentItemGroup?.skinGroupInternalName
		};
	}

	public void SetData(ThemeManagerData data)
	{
	}
}
