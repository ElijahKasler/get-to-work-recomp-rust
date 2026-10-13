namespace System.Windows.Forms;

internal class ThemeEngine
{
	private static Theme theme;

	public static Theme Current => theme;

	static ThemeEngine()
	{
		if (Application.VisualStylesEnabled)
		{
			theme = new ThemeVisualStyles();
		}
		else
		{
			theme = new ThemeWin32Classic();
		}
	}
}
