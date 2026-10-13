using UnityEngine.TextCore.Text;

namespace UnityEngine.UIElements;

public class PanelTextSettings : TextSettings
{
	private static PanelTextSettings s_DefaultPanelTextSettings;

	internal static PanelTextSettings defaultPanelTextSettings
	{
		get
		{
			InitializeDefaultPanelTextSettingsIfNull();
			return s_DefaultPanelTextSettings;
		}
	}

	internal static void InitializeDefaultPanelTextSettingsIfNull()
	{
		if (s_DefaultPanelTextSettings == null)
		{
			s_DefaultPanelTextSettings = ScriptableObject.CreateInstance<PanelTextSettings>();
		}
	}
}
