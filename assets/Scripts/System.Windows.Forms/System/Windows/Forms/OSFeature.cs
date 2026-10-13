namespace System.Windows.Forms;

public class OSFeature : FeatureSupport
{
	private static OSFeature feature = new OSFeature();

	public static readonly object LayeredWindows;

	public static readonly object Themes;

	public static OSFeature Feature => feature;

	protected OSFeature()
	{
	}

	public static bool IsPresent(SystemParameter enumVal)
	{
		switch (enumVal)
		{
		case SystemParameter.DropShadow:
			try
			{
				_ = SystemInformation.IsDropShadowEnabled;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		case SystemParameter.FlatMenu:
			try
			{
				_ = SystemInformation.IsFlatMenuEnabled;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		case SystemParameter.FontSmoothingContrastMetric:
			try
			{
				_ = SystemInformation.FontSmoothingContrast;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		case SystemParameter.FontSmoothingTypeMetric:
			try
			{
				_ = SystemInformation.FontSmoothingType;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		case SystemParameter.MenuFadeEnabled:
			try
			{
				_ = SystemInformation.IsMenuFadeEnabled;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		case SystemParameter.SelectionFade:
			try
			{
				_ = SystemInformation.IsSelectionFadeEnabled;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		case SystemParameter.ToolTipAnimationMetric:
			try
			{
				_ = SystemInformation.IsToolTipAnimationEnabled;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		case SystemParameter.UIEffects:
			try
			{
				_ = SystemInformation.UIEffectsEnabled;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		case SystemParameter.CaretWidthMetric:
			try
			{
				_ = SystemInformation.CaretWidth;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		case SystemParameter.VerticalFocusThicknessMetric:
			try
			{
				_ = SystemInformation.VerticalFocusThickness;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		case SystemParameter.HorizontalFocusThicknessMetric:
			try
			{
				_ = SystemInformation.HorizontalFocusThickness;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		default:
			return false;
		}
	}

	public override Version GetVersionPresent(object feature)
	{
		if (feature == Themes)
		{
			return ThemeEngine.Current.Version;
		}
		return null;
	}
}
