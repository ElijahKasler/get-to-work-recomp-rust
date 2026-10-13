using System.Drawing;
using System.Windows.Forms.Theming.Default;

namespace System.Windows.Forms.Theming;

internal class ThemeElements
{
	private static ThemeElementsDefault theme;

	public static ThemeElementsDefault CurrentTheme => theme;

	public virtual ButtonPainter ButtonPainter => theme.ButtonPainter;

	public static LabelPainter LabelPainter => theme.LabelPainter;

	public static LinkLabelPainter LinkLabelPainter => theme.LinkLabelPainter;

	public virtual TabControlPainter TabControlPainter => theme.TabControlPainter;

	public virtual CheckBoxPainter CheckBoxPainter => theme.CheckBoxPainter;

	public virtual RadioButtonPainter RadioButtonPainter => theme.RadioButtonPainter;

	public virtual ToolStripPainter ToolStripPainter => theme.ToolStripPainter;

	static ThemeElements()
	{
		if (Application.VisualStylesEnabled)
		{
			theme = new ThemeElementsVisualStyles();
		}
		else
		{
			theme = new ThemeElementsDefault();
		}
	}

	public static void DrawButton(Graphics g, Rectangle bounds, ButtonThemeState state, Color backColor, Color foreColor)
	{
		theme.ButtonPainter.Draw(g, bounds, state, backColor, foreColor);
	}

	public static void DrawFlatButton(Graphics g, Rectangle bounds, ButtonThemeState state, Color backColor, Color foreColor, FlatButtonAppearance appearance)
	{
		theme.ButtonPainter.DrawFlat(g, bounds, state, backColor, foreColor, appearance);
	}

	public static void DrawPopupButton(Graphics g, Rectangle bounds, ButtonThemeState state, Color backColor, Color foreColor)
	{
		theme.ButtonPainter.DrawPopup(g, bounds, state, backColor, foreColor);
	}
}
