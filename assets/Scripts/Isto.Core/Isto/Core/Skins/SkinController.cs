using Isto.Core.Data;
using Isto.Core.Game;
using Isto.Core.Themes;
using UnityEngine;
using Zenject;

namespace Isto.Core.Skins;

public class SkinController : MonoBehaviour, IDataLoadCompleteHandler
{
	protected bool _registeredEvents;

	protected MasterSkinList _masterSkinList;

	protected GameState _gameState;

	protected ThemeManager _themeManager;

	[Inject]
	public void Inject(MasterSkinList masterSkinList, GameState gameState, ThemeManager themeManager)
	{
		_masterSkinList = masterSkinList;
		_gameState = gameState;
		_themeManager = themeManager;
	}

	protected virtual void Start()
	{
		RegisterEvents();
	}

	private void OnEnable()
	{
		OnSkinChanged();
		RegisterEvents();
	}

	private void OnDisable()
	{
		UnregisterEvents();
	}

	private void OnDestroy()
	{
		UnregisterEvents();
	}

	protected virtual void RegisterEvents()
	{
		if (!_registeredEvents)
		{
			Events.Subscribe("MiniDeerSkinChanged", OnSkinChanged);
			Events.Subscribe("PushbackSkinChanged", OnSkinChanged);
			_registeredEvents = true;
		}
	}

	protected virtual void UnregisterEvents()
	{
		if (_registeredEvents)
		{
			Events.UnSubscribe("MiniDeerSkinChanged", OnSkinChanged);
			Events.UnSubscribe("PushbackSkinChanged", OnSkinChanged);
			_registeredEvents = false;
		}
	}

	protected virtual void OnSkinChanged()
	{
		if (_themeManager == null)
		{
			return;
		}
		CreatureSkinSet currentCreatureSkinSet = _themeManager.GetCurrentCreatureSkinSet(base.gameObject);
		if (!(currentCreatureSkinSet == null))
		{
			string skinSetSpineName = currentCreatureSkinSet.skinSetSpineName;
			if (!string.IsNullOrEmpty(skinSetSpineName))
			{
				SetSkin(skinSetSpineName);
			}
		}
	}

	public virtual void SetSkin(string skinName)
	{
	}

	public virtual string GetSkin()
	{
		return Constants.DEFAULT_SKIN_NAME;
	}

	public virtual void SetSkinNameFromData(string name)
	{
	}

	public virtual void OnDataLoadComplete()
	{
	}
}
