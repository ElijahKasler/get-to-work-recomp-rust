using UnityEngine;
using Zenject;

namespace Isto.Core.UI;

public class UICloseButton : MonoBehaviour
{
	private IUIMenu _mainMenu;

	[Inject]
	public void Inject(IUIMenu uIMainMenu)
	{
		_mainMenu = uIMainMenu;
	}

	public void CloseMenu()
	{
		_mainMenu.CloseMenu();
	}
}
