using System.Collections.Generic;

namespace UnityEngine.Rendering.RenderGraphModule;

internal class RenderGraphDebugParams : IDebugDisplaySettingsQuery
{
	private static class Strings
	{
		public static readonly DebugUI.Widget.NameAndTooltip ClearRenderTargetsAtCreation = new DebugUI.Widget.NameAndTooltip
		{
			name = "Clear Render Targets At Creation",
			tooltip = "Enable to clear all render textures before any rendergraph passes to check if some clears are missing."
		};

		public static readonly DebugUI.Widget.NameAndTooltip ClearRenderTargetsAtFree = new DebugUI.Widget.NameAndTooltip
		{
			name = "Clear Render Targets When Freed",
			tooltip = "Enable to clear all render textures when textures are freed by the graph to detect use after free of textures."
		};

		public static readonly DebugUI.Widget.NameAndTooltip DisablePassCulling = new DebugUI.Widget.NameAndTooltip
		{
			name = "Disable Pass Culling",
			tooltip = "Enable to temporarily disable culling to assess if a pass is culled."
		};

		public static readonly DebugUI.Widget.NameAndTooltip ImmediateMode = new DebugUI.Widget.NameAndTooltip
		{
			name = "Immediate Mode",
			tooltip = "Enable to force render graph to execute all passes in the order you registered them."
		};

		public static readonly DebugUI.Widget.NameAndTooltip EnableLogging = new DebugUI.Widget.NameAndTooltip
		{
			name = "Enable Logging",
			tooltip = "Enable to allow HDRP to capture information in the log."
		};

		public static readonly DebugUI.Widget.NameAndTooltip LogFrameInformation = new DebugUI.Widget.NameAndTooltip
		{
			name = "Log Frame Information",
			tooltip = "Enable to log information output from each frame."
		};

		public static readonly DebugUI.Widget.NameAndTooltip LogResources = new DebugUI.Widget.NameAndTooltip
		{
			name = "Log Resources",
			tooltip = "Enable to log the current render graph's global resource usage."
		};

		public static readonly DebugUI.Widget.NameAndTooltip EnableNativeCompiler = new DebugUI.Widget.NameAndTooltip
		{
			name = "Enable Native Pass Compiler",
			tooltip = "Enable the new native pass compiler."
		};
	}

	private DebugUI.Widget[] m_DebugItems;

	private DebugUI.Panel m_DebugPanel;

	public bool clearRenderTargetsAtCreation;

	public bool clearRenderTargetsAtRelease;

	public bool disablePassCulling;

	public bool immediateMode;

	public bool enableLogging;

	public bool logFrameInformation;

	public bool logResources;

	public bool AreAnySettingsActive
	{
		get
		{
			if (!clearRenderTargetsAtCreation && !clearRenderTargetsAtRelease && !disablePassCulling && !immediateMode)
			{
				return enableLogging;
			}
			return true;
		}
	}

	internal void Reset()
	{
		clearRenderTargetsAtCreation = false;
		clearRenderTargetsAtRelease = false;
		disablePassCulling = false;
		immediateMode = false;
		enableLogging = false;
		logFrameInformation = false;
		logResources = false;
	}

	internal List<DebugUI.Widget> GetWidgetList(string name)
	{
		return new List<DebugUI.Widget>
		{
			new DebugUI.Container
			{
				displayName = name + " Render Graph",
				children = 
				{
					(DebugUI.Widget)new DebugUI.BoolField
					{
						nameAndTooltip = Strings.ClearRenderTargetsAtCreation,
						getter = () => clearRenderTargetsAtCreation,
						setter = (bool value) =>
						{
							clearRenderTargetsAtCreation = value;
						}
					},
					(DebugUI.Widget)new DebugUI.BoolField
					{
						nameAndTooltip = Strings.ClearRenderTargetsAtFree,
						getter = () => clearRenderTargetsAtRelease,
						setter = (bool value) =>
						{
							clearRenderTargetsAtRelease = value;
						}
					},
					(DebugUI.Widget)new DebugUI.BoolField
					{
						nameAndTooltip = Strings.DisablePassCulling,
						getter = () => disablePassCulling,
						setter = (bool value) =>
						{
							disablePassCulling = value;
						}
					},
					(DebugUI.Widget)new DebugUI.BoolField
					{
						nameAndTooltip = Strings.ImmediateMode,
						getter = () => immediateMode,
						setter = (bool value) =>
						{
							immediateMode = value;
						},
						isHiddenCallback = () => !IsImmediateModeSupported()
					},
					(DebugUI.Widget)new DebugUI.BoolField
					{
						nameAndTooltip = Strings.EnableLogging,
						getter = () => enableLogging,
						setter = (bool value) =>
						{
							enableLogging = value;
						}
					},
					(DebugUI.Widget)new DebugUI.Button
					{
						nameAndTooltip = Strings.LogFrameInformation,
						action = () =>
						{
							if (!enableLogging)
							{
								Debug.Log("You must first enable logging before logging frame information.");
							}
							logFrameInformation = true;
						}
					},
					(DebugUI.Widget)new DebugUI.Button
					{
						nameAndTooltip = Strings.LogResources,
						action = () =>
						{
							if (!enableLogging)
							{
								Debug.Log("You must first enable logging before logging resources.");
							}
							logResources = true;
						}
					}
				}
			}
		};
	}

	private bool IsImmediateModeSupported()
	{
		if (GraphicsSettings.currentRenderPipeline is IRenderGraphEnabledRenderPipeline renderGraphEnabledRenderPipeline)
		{
			return renderGraphEnabledRenderPipeline.isImmediateModeSupported;
		}
		return false;
	}

	public void RegisterDebug(string name, DebugUI.Panel debugPanel = null)
	{
		List<DebugUI.Widget> widgetList = GetWidgetList(name);
		m_DebugItems = widgetList.ToArray();
		m_DebugPanel = ((debugPanel != null) ? debugPanel : DebugManager.instance.GetPanel((name.Length == 0) ? "Render Graph" : name, createIfNull: true));
		m_DebugPanel.children.Add(m_DebugItems);
	}

	public void UnRegisterDebug(string name)
	{
		if (m_DebugPanel != null)
		{
			m_DebugPanel.children.Remove(m_DebugItems);
		}
		m_DebugPanel = null;
		m_DebugItems = null;
	}
}
