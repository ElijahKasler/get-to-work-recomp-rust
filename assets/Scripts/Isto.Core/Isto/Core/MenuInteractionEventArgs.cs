using System;
using Isto.Core.UI;

namespace Isto.Core;

public class MenuInteractionEventArgs : EventArgs
{
	public enum Action
	{
		Open = 0,
		Close = 1
	}

	public GameMenusEnum menu;

	public Action action;

	public MenuInteractionEventArgs(GameMenusEnum gameMenu, Action actionType)
	{
		menu = gameMenu;
		action = actionType;
	}
}
