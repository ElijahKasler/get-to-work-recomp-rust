using UnityEngine.Rendering.RenderGraphModule;

namespace UnityEngine.Rendering;

internal class DebugDisplaySettingsRenderGraph : IDebugDisplaySettingsData, IDebugDisplaySettingsQuery
{
	[DisplayInfo(name = "Render Graph", order = 10)]
	private class SettingsPanel : DebugDisplaySettingsPanel
	{
		public override string PanelName => "Render Graph";

		public SettingsPanel(DebugDisplaySettingsRenderGraph _)
		{
			bool flag = false;
			foreach (RenderGraph registeredRenderGraph in RenderGraph.GetRegisteredRenderGraphs())
			{
				flag = true;
				foreach (DebugUI.Widget widget in registeredRenderGraph.GetWidgetList())
				{
					AddWidget(widget);
				}
			}
			if (!flag)
			{
				AddWidget(new DebugUI.MessageBox
				{
					displayName = "Warning: The current render pipeline does not have Render Graphs Registered",
					style = DebugUI.MessageBox.Style.Warning
				});
			}
		}
	}

	public bool AreAnySettingsActive
	{
		get
		{
			foreach (RenderGraph registeredRenderGraph in RenderGraph.GetRegisteredRenderGraphs())
			{
				if (registeredRenderGraph.areAnySettingsActive)
				{
					return true;
				}
			}
			return false;
		}
	}

	public DebugDisplaySettingsRenderGraph()
	{
		foreach (RenderGraph registeredRenderGraph in RenderGraph.GetRegisteredRenderGraphs())
		{
			registeredRenderGraph.debugParams.Reset();
		}
	}

	IDebugDisplaySettingsPanelDisposable IDebugDisplaySettingsData.CreatePanel()
	{
		return new SettingsPanel(this);
	}
}
