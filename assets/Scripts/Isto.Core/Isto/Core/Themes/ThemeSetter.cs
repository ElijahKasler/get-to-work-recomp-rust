using TMPro;
using UnityEngine;
using Zenject;

namespace Isto.Core.Themes;

public class ThemeSetter : MonoBehaviour
{
	[SerializeField]
	private string _themeName;

	[SerializeField]
	private TextMeshProUGUI _buttonText;

	[SerializeField]
	private string _buttonOnText;

	[SerializeField]
	private string _buttonOffText;

	private ThemeManager _themeManager;

	[Inject]
	public void Inject(ThemeManager themeManager)
	{
		_themeManager = themeManager;
	}

	public void ToggleTheme()
	{
		if (_themeManager.CurrentTheme.internalName != _themeName)
		{
			SetTheme(_themeName);
			_buttonText.text = _buttonOnText;
		}
		else
		{
			SetTheme(Constants.DEFAULT_THEME_NAME);
			_buttonText.text = _buttonOffText;
		}
	}

	private void SetTheme(string themeName)
	{
		ThemeSetup themeSetup = Resources.Load<ThemeSetup>("Themes");
		if (themeSetup == null)
		{
			Debug.LogError("SetThemeDeveloperAction could not find ThemeSetup object at Resources/Themes");
			return;
		}
		ThemeDefinition theme = themeSetup.GetTheme(themeName);
		if (theme != null)
		{
			_themeManager.CurrentTheme = theme;
		}
		else
		{
			Debug.LogError("Argument error. No theme found with name \"" + themeName + "\". Useage example: SetTheme Normal");
		}
	}
}
