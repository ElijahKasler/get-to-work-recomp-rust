using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.InputManagers;
using Rewired.Interfaces;
using Rewired.Internal.Glyphs;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Platforms.Custom;
using Rewired.Platforms.XboxOne;
using Rewired.Utils;
using Rewired.Utils.Classes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired;

public static class ReInput
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class LocalizationHelper : CodeHelper
	{
		private static LocalizationHelper uDqdPKEwDUoMoOjjeBIhJlQBhuej;

		internal static LocalizationHelper JeJmhAtPuItmhTlnDrKHtfEZIwEcA => kpspwMgWDMiYxBcKjZUEFPkwxOov();

		public ILocalizedStringProvider localizedStringProvider
		{
			get
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return LocalizationManager.localizedStringProvider;
			}
			set
			{
				if (CheckInitialized())
				{
					LocalizationManager.localizedStringProvider = value;
				}
			}
		}

		public bool prefetch
		{
			get
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return LocalizationManager.autoPrefetch;
			}
			set
			{
				if (CheckInitialized())
				{
					LocalizationManager.autoPrefetch = value;
				}
			}
		}

		internal static LocalizationHelper kpspwMgWDMiYxBcKjZUEFPkwxOov()
		{
			return uDqdPKEwDUoMoOjjeBIhJlQBhuej ?? (uDqdPKEwDUoMoOjjeBIhJlQBhuej = new LocalizationHelper());
		}

		private LocalizationHelper()
		{
		}

		internal static void zVECgeyoOmbqFdRraabntBcTebnL()
		{
			uDqdPKEwDUoMoOjjeBIhJlQBhuej = null;
		}

		public void Reload()
		{
			if (CheckInitialized())
			{
				LocalizationManager.Reload();
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class GlyphHelper : CodeHelper
	{
		private static GlyphHelper aJivRDNOZSroUrGdHjZILjkjsiLU;

		internal static GlyphHelper DNPPEYusfDqdCrNHgVWmqFMLUMJC => MeiTncwkloGWBsNaUZsRiHijcyFN();

		public IGlyphProvider glyphProvider
		{
			get
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return GlyphManager.glyphProvider;
			}
			set
			{
				if (CheckInitialized())
				{
					GlyphManager.glyphProvider = value;
				}
			}
		}

		public bool prefetch
		{
			get
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return GlyphManager.autoPrefetch;
			}
			set
			{
				if (CheckInitialized())
				{
					GlyphManager.autoPrefetch = value;
				}
			}
		}

		internal static GlyphHelper MeiTncwkloGWBsNaUZsRiHijcyFN()
		{
			return aJivRDNOZSroUrGdHjZILjkjsiLU ?? (aJivRDNOZSroUrGdHjZILjkjsiLU = new GlyphHelper());
		}

		private GlyphHelper()
		{
		}

		internal static void LKhERsEkVSooVwukAiGjjRzmqVNCb()
		{
			aJivRDNOZSroUrGdHjZILjkjsiLU = null;
		}

		public void Reload()
		{
			if (CheckInitialized())
			{
				GlyphManager.Reload();
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class ConfigHelper : CodeHelper
	{
		private static ConfigHelper cnQgamcWsAwPHwKxnHzYXvunsEYdA;

		private float VFRkMGxHFAAltQqJvUzkoDrHhrkT = 0.7f;

		private float LipyzjNwVcpqdyjAABGNGJKIVYzKA = 100f;

		internal static ConfigHelper BdIjCHQSrnpBqmJlpKoEsGdOKJtF => KbbJTPFaiuWGBDGGTVHubWHJWBJlA();

		public bool useXInput
		{
			get
			{
				if (!CheckInitialized())
				{
					return false;
				}
				if (UnityTools.effectivePlatform == Platform.Windows && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
				{
					return true;
				}
				if (UnityTools.effectivePlatform == Platform.WindowsUWP)
				{
					return windowsUWPSupportGamepads;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.useXInput;
			}
			set
			{
				if (!CheckInitialized())
				{
					return;
				}
				if (UnityTools.effectivePlatform == Platform.WindowsUWP)
				{
					windowsUWPSupportGamepads = value;
				}
				else
				{
					if (GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.useXInput == value)
					{
						return;
					}
					if (value)
					{
						if (GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
						{
							return;
						}
						if (UnityTools.effectivePlatform == Platform.Windows && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.WindowsGamingInput)
						{
							Logger.LogWarning("XInput cannot be enabled with the current primary input source: " + GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.windowsStandalonePrimaryInputSource);
							return;
						}
					}
					else if (UnityTools.effectivePlatform == Platform.Windows && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
					{
						GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
						Logger.LogWarning("XInput cannot be used with the current primary input source. The primary input source has been changed to Raw Input.");
					}
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.useXInput = value;
					if (KRXMNGqTUEuSZnzlexLlRTibdOwA != null)
					{
						KRXMNGqTUEuSZnzlexLlRTibdOwA.ResetAll();
					}
				}
			}
		}

		public bool useWindowsGamingInput
		{
			get
			{
				if (!CheckInitialized())
				{
					return false;
				}
				if (UnityTools.effectivePlatform == Platform.Windows && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
				{
					return true;
				}
				if (UnityTools.effectivePlatform == Platform.WindowsUWP)
				{
					return windowsUWPSupportGamepads;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.GetPlatformVar_useWindowsGamingInput();
			}
			set
			{
				if (!CheckInitialized())
				{
					return;
				}
				if (UnityTools.effectivePlatform == Platform.WindowsUWP)
				{
					windowsUWPSupportGamepads = value;
				}
				else
				{
					if (GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.GetPlatformVar_useWindowsGamingInput() == value)
					{
						return;
					}
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.SetPlatformVar_useWindowsGamingInput(value);
					if (value)
					{
						if (GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
						{
							return;
						}
						if (UnityTools.effectivePlatform == Platform.Windows && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput)
						{
							Logger.LogWarning("Windows Gaming Input cannot be enabled with the current primary input source: " + GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.windowsStandalonePrimaryInputSource);
							return;
						}
					}
					else if (UnityTools.effectivePlatform == Platform.Windows && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
					{
						GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
						Logger.LogWarning("Windows Gaming Input cannot be used with the current primary input source. The primary input source has been changed to Raw Input.");
					}
					if (KRXMNGqTUEuSZnzlexLlRTibdOwA != null)
					{
						KRXMNGqTUEuSZnzlexLlRTibdOwA.ResetAll();
					}
				}
			}
		}

		public UpdateMode updateMode
		{
			get
			{
				if (!CheckInitialized())
				{
					return UpdateMode.Automatic;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.updateMode;
			}
			set
			{
				if (CheckInitialized() && value != GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.updateMode)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.updateMode = value;
					if (KRXMNGqTUEuSZnzlexLlRTibdOwA != null)
					{
						KRXMNGqTUEuSZnzlexLlRTibdOwA.ResetAll();
					}
				}
			}
		}

		public UpdateLoopSetting updateLoop
		{
			get
			{
				if (!CheckInitialized())
				{
					return UpdateLoopSetting.Update;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.updateLoop;
			}
			set
			{
				if (CheckInitialized() && value != GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.updateLoop)
				{
					if ((value & UpdateLoopSetting.Update) == 0)
					{
						value |= UpdateLoopSetting.Update;
					}
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.updateLoop = value;
					if (KRXMNGqTUEuSZnzlexLlRTibdOwA != null)
					{
						KRXMNGqTUEuSZnzlexLlRTibdOwA.ResetAll();
					}
				}
			}
		}

		public WindowsStandalonePrimaryInputSource windowsStandalonePrimaryInputSource
		{
			get
			{
				if (!CheckInitialized())
				{
					return WindowsStandalonePrimaryInputSource.RawInput;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.windowsStandalonePrimaryInputSource;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.windowsStandalonePrimaryInputSource != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.windowsStandalonePrimaryInputSource = value;
					if (UnityTools.effectivePlatform == Platform.Windows && value == WindowsStandalonePrimaryInputSource.XInput)
					{
						GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.useXInput = true;
					}
					if (KRXMNGqTUEuSZnzlexLlRTibdOwA != null)
					{
						KRXMNGqTUEuSZnzlexLlRTibdOwA.ResetAll();
					}
				}
			}
		}

		public OSXStandalonePrimaryInputSource osxStandalonePrimaryInputSource
		{
			get
			{
				if (!CheckInitialized())
				{
					return OSXStandalonePrimaryInputSource.Native;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.osx_primaryInputSource;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.osx_primaryInputSource != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.osx_primaryInputSource = value;
					if (KRXMNGqTUEuSZnzlexLlRTibdOwA != null)
					{
						KRXMNGqTUEuSZnzlexLlRTibdOwA.ResetAll();
					}
				}
			}
		}

		public LinuxStandalonePrimaryInputSource linuxStandalonePrimaryInputSource
		{
			get
			{
				if (!CheckInitialized())
				{
					return LinuxStandalonePrimaryInputSource.Native;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.linux_primaryInputSource;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.linux_primaryInputSource != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.linux_primaryInputSource = value;
					if (KRXMNGqTUEuSZnzlexLlRTibdOwA != null)
					{
						KRXMNGqTUEuSZnzlexLlRTibdOwA.ResetAll();
					}
				}
			}
		}

		public WindowsUWPPrimaryInputSource windowsUWPPrimaryInputSource
		{
			get
			{
				if (!CheckInitialized())
				{
					return WindowsUWPPrimaryInputSource.Native;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.windowsUWP_primaryInputSource;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.windowsUWP_primaryInputSource != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.windowsUWP_primaryInputSource = value;
					if (KRXMNGqTUEuSZnzlexLlRTibdOwA != null)
					{
						KRXMNGqTUEuSZnzlexLlRTibdOwA.ResetAll();
					}
				}
			}
		}

		public bool windowsUWPSupportHIDDevices
		{
			get
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return (GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useHIDAPI;
			}
			set
			{
				if (!CheckInitialized())
				{
					return;
				}
				ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
				if (platformVars_WindowsUWP.useHIDAPI != value)
				{
					platformVars_WindowsUWP.useHIDAPI = value;
					if (KRXMNGqTUEuSZnzlexLlRTibdOwA != null)
					{
						KRXMNGqTUEuSZnzlexLlRTibdOwA.ResetAll();
					}
				}
			}
		}

		public bool windowsUWPSupportGamepads
		{
			get
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return (GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useGamepadAPI;
			}
			set
			{
				if (!CheckInitialized())
				{
					return;
				}
				ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
				if (platformVars_WindowsUWP.useGamepadAPI != value)
				{
					platformVars_WindowsUWP.useGamepadAPI = value;
					if (KRXMNGqTUEuSZnzlexLlRTibdOwA != null)
					{
						KRXMNGqTUEuSZnzlexLlRTibdOwA.ResetAll();
					}
				}
			}
		}

		public bool useAppleGameControllerFramework
		{
			get
			{
				if (!CheckInitialized())
				{
					return false;
				}
				if (UnityTools.effectivePlatform == Platform.OSX && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.osx_primaryInputSource == OSXStandalonePrimaryInputSource.GameController)
				{
					return true;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.GetPlatformVar_useAppleGameController();
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.GetPlatformVar_useAppleGameController() != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.SetPlatformVar_useAppleGameController(value);
					if (KRXMNGqTUEuSZnzlexLlRTibdOwA != null)
					{
						KRXMNGqTUEuSZnzlexLlRTibdOwA.ResetAll();
					}
				}
			}
		}

		public XboxOnePrimaryInputSource xboxOnePrimaryInputSource
		{
			get
			{
				if (!CheckInitialized())
				{
					return XboxOnePrimaryInputSource.Native;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.xboxOne_primaryInputSource;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.xboxOne_primaryInputSource != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.xboxOne_primaryInputSource = value;
					if (KRXMNGqTUEuSZnzlexLlRTibdOwA != null)
					{
						KRXMNGqTUEuSZnzlexLlRTibdOwA.ResetAll();
					}
				}
			}
		}

		public PS4PrimaryInputSource ps4PrimaryInputSource
		{
			get
			{
				if (!CheckInitialized())
				{
					return PS4PrimaryInputSource.PS4Input;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.ps4_primaryInputSource;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.ps4_primaryInputSource != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.ps4_primaryInputSource = value;
					if (KRXMNGqTUEuSZnzlexLlRTibdOwA != null)
					{
						KRXMNGqTUEuSZnzlexLlRTibdOwA.ResetAll();
					}
				}
			}
		}

		public WebGLPrimaryInputSource webGLPrimaryInputSource
		{
			get
			{
				if (!CheckInitialized())
				{
					return WebGLPrimaryInputSource.Native;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.webGL_primaryInputSource;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.webGL_primaryInputSource != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.webGL_primaryInputSource = value;
					if (KRXMNGqTUEuSZnzlexLlRTibdOwA != null)
					{
						KRXMNGqTUEuSZnzlexLlRTibdOwA.ResetAll();
					}
				}
			}
		}

		public bool alwaysUseUnityInput
		{
			get
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.alwaysUseUnityInput;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.alwaysUseUnityInput != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.alwaysUseUnityInput = value;
					if (KRXMNGqTUEuSZnzlexLlRTibdOwA != null)
					{
						KRXMNGqTUEuSZnzlexLlRTibdOwA.ResetAll();
					}
				}
			}
		}

		public bool disableNativeInput
		{
			get
			{
				return alwaysUseUnityInput;
			}
			set
			{
				alwaysUseUnityInput = value;
			}
		}

		public bool nativeMouseSupport
		{
			get
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.GetPlatformVar_useNativeMouse();
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.SetPlatformVar_useNativeMouse(value) && KRXMNGqTUEuSZnzlexLlRTibdOwA != null)
				{
					KRXMNGqTUEuSZnzlexLlRTibdOwA.ResetAll();
				}
			}
		}

		public bool nativeKeyboardSupport
		{
			get
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.GetPlatformVar_useNativeKeyboard();
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.SetPlatformVar_useNativeKeyboard(value) && KRXMNGqTUEuSZnzlexLlRTibdOwA != null)
				{
					KRXMNGqTUEuSZnzlexLlRTibdOwA.ResetAll();
				}
			}
		}

		public bool enhancedDeviceSupport
		{
			get
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.GetPlatformVar_useEnhancedDeviceSupport();
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.SetPlatformVar_useEnhancedDeviceSupport(value) && KRXMNGqTUEuSZnzlexLlRTibdOwA != null)
				{
					KRXMNGqTUEuSZnzlexLlRTibdOwA.ResetAll();
				}
			}
		}

		public int joystickRefreshRate
		{
			get
			{
				if (!CheckInitialized())
				{
					return 0;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.GetPlatformVar_joystickRefreshRate();
			}
			set
			{
				if (CheckInitialized())
				{
					value = MathTools.Clamp(value, 0, 2000);
					if (value == 0)
					{
						value = 240;
					}
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.SetPlatformVar_joystickRefreshRate(value);
				}
			}
		}

		public bool ignoreInputWhenAppNotInFocus
		{
			get
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.GetPlatformVar_ignoreInputWhenAppNotInFocus();
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.SetPlatformVar_ignoreInputWhenAppNotInFocus(value))
				{
					CxfkmhzrQfrXFPALRIlzGSTWggoW();
				}
			}
		}

		public bool android_supportUnknownGamepads
		{
			get
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.android_supportUnknownGamepads;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.android_supportUnknownGamepads != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.android_supportUnknownGamepads = value;
					if (KRXMNGqTUEuSZnzlexLlRTibdOwA != null)
					{
						KRXMNGqTUEuSZnzlexLlRTibdOwA.ResetAll();
					}
				}
			}
		}

		public DeadZone2DType defaultJoystickAxis2DDeadZoneType
		{
			get
			{
				if (!CheckInitialized())
				{
					return DeadZone2DType.Radial;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.defaultJoystickAxis2DDeadZoneType;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.defaultJoystickAxis2DDeadZoneType != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.defaultJoystickAxis2DDeadZoneType = value;
				}
			}
		}

		public AxisSensitivity2DType defaultJoystickAxis2DSensitivityType
		{
			get
			{
				if (!CheckInitialized())
				{
					return AxisSensitivity2DType.Radial;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.defaultJoystickAxis2DSensitivityType;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.defaultJoystickAxis2DSensitivityType != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.defaultJoystickAxis2DSensitivityType = value;
				}
			}
		}

		public AxisSensitivityType defaultAxisSensitivityType
		{
			get
			{
				if (!CheckInitialized())
				{
					return AxisSensitivityType.Multiplier;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.defaultAxisSensitivityType;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.defaultAxisSensitivityType != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.defaultAxisSensitivityType = value;
				}
			}
		}

		public bool force4WayHats
		{
			get
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.force4WayHats;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.force4WayHats != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.force4WayHats = value;
				}
			}
		}

		public float defaultAbsoluteAxisPollingDeadZone
		{
			get
			{
				if (!CheckInitialized())
				{
					return 0.7f;
				}
				return VFRkMGxHFAAltQqJvUzkoDrHhrkT;
			}
			set
			{
				if (CheckInitialized())
				{
					if (value < 0f)
					{
						value = 0f;
					}
					if (VFRkMGxHFAAltQqJvUzkoDrHhrkT != value)
					{
						VFRkMGxHFAAltQqJvUzkoDrHhrkT = value;
					}
				}
			}
		}

		public float defaultRelativeAxisPollingDeadZone
		{
			get
			{
				if (!CheckInitialized())
				{
					return 100f;
				}
				return LipyzjNwVcpqdyjAABGNGJKIVYzKA;
			}
			set
			{
				if (CheckInitialized())
				{
					if (value < 0f)
					{
						value = 0f;
					}
					if (LipyzjNwVcpqdyjAABGNGJKIVYzKA != value)
					{
						LipyzjNwVcpqdyjAABGNGJKIVYzKA = value;
					}
				}
			}
		}

		public bool activateActionButtonsOnNegativeValue
		{
			get
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.activateActionButtonsOnNegativeValue;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.activateActionButtonsOnNegativeValue != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.activateActionButtonsOnNegativeValue = value;
				}
			}
		}

		public ThrottleCalibrationMode throttleCalibrationMode
		{
			get
			{
				if (!CheckInitialized())
				{
					return ThrottleCalibrationMode.ZeroToOne;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.throttleCalibrationMode;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.throttleCalibrationMode != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.throttleCalibrationMode = value;
					jCkgZLcnXoMycBxzcMXWvnUfSROEb.FeAoZeUixIJBomShUTykHxGLLRYy(value);
				}
			}
		}

		public bool deferControllerConnectedEventsOnStart
		{
			get
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.deferControllerConnectedEventsOnStart;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.deferControllerConnectedEventsOnStart != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.deferControllerConnectedEventsOnStart = value;
				}
			}
		}

		public KeyCombinationOverrideMode keyCombinationOverrideMode
		{
			get
			{
				if (!CheckInitialized())
				{
					return KeyCombinationOverrideMode.Cancel;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.keyCombinationOverrideMode;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.keyCombinationOverrideMode != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.keyCombinationOverrideMode = value;
				}
			}
		}

		public bool generateKeyEventsOnKeyCombinationOverride
		{
			get
			{
				if (!CheckInitialized())
				{
					return true;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.generateKeyEventsOnKeyCombinationOverride;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.generateKeyEventsOnKeyCombinationOverride != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.generateKeyEventsOnKeyCombinationOverride = value;
				}
			}
		}

		public bool autoAssignJoysticks
		{
			get
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.autoAssignJoysticks;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.autoAssignJoysticks != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.autoAssignJoysticks = value;
				}
			}
		}

		public int maxJoysticksPerPlayer
		{
			get
			{
				if (!CheckInitialized())
				{
					return 0;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.maxJoysticksPerPlayer;
			}
			set
			{
				if (CheckInitialized())
				{
					if (value < 1)
					{
						value = 1;
					}
					if (GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.maxJoysticksPerPlayer != value)
					{
						GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.maxJoysticksPerPlayer = value;
					}
				}
			}
		}

		public bool distributeJoysticksEvenly
		{
			get
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.distributeJoysticksEvenly;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.distributeJoysticksEvenly != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.distributeJoysticksEvenly = value;
				}
			}
		}

		public bool assignJoysticksToPlayingPlayersOnly
		{
			get
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.assignJoysticksToPlayingPlayersOnly;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.assignJoysticksToPlayingPlayersOnly != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.assignJoysticksToPlayingPlayersOnly = value;
				}
			}
		}

		public bool reassignJoystickToPreviousOwnerOnReconnect
		{
			get
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect = value;
				}
			}
		}

		public LogLevelFlags logLevel
		{
			get
			{
				if (!CheckInitialized())
				{
					return LogLevelFlags.Off;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.logLevel;
			}
			set
			{
				if (CheckInitialized() && GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.logLevel != value)
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.logLevel = value;
				}
			}
		}

		public List<EnhancedDeviceSupportDeviceType> enhancedDeviceSupportExcludedDeviceTypes
		{
			get
			{
				if (!CheckInitialized())
				{
					return new List<EnhancedDeviceSupportDeviceType>();
				}
				return new List<EnhancedDeviceSupportDeviceType>(GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.GetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes());
			}
			set
			{
				if (CheckInitialized())
				{
					GSaeDquNrvgMCNAsNvzHXfLVsESw.ConfigVars.SetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes(value);
					if (KRXMNGqTUEuSZnzlexLlRTibdOwA != null)
					{
						KRXMNGqTUEuSZnzlexLlRTibdOwA.ResetAll();
					}
				}
			}
		}

		internal static ConfigHelper KbbJTPFaiuWGBDGGTVHubWHJWBJlA()
		{
			return cnQgamcWsAwPHwKxnHzYXvunsEYdA ?? (cnQgamcWsAwPHwKxnHzYXvunsEYdA = new ConfigHelper());
		}

		private ConfigHelper()
		{
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class ControllerHelper : CodeHelper
	{
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class PollingHelper : CodeHelper
		{
			private sealed class bKdFmhDsAxmvTDfOJhsXOCxxrDREA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int QTlZSjtpCpgVyQCXbvfjLqXJZhzp;

				private ControllerPollingInfo cNwuPatLfStZnHlkzulRQsOqViXF;

				private int MwCRpCGSddxAqabPHdkmgiqejwpt;

				public PollingHelper PKsgzonBoXleQMvIeWtATYztxgfJ;

				private IEnumerator<ControllerPollingInfo> ryNJrikxfNkmOBICvHJPYUxvETpkA;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return cNwuPatLfStZnHlkzulRQsOqViXF;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return cNwuPatLfStZnHlkzulRQsOqViXF;
					}
				}

				[DebuggerHidden]
				public bKdFmhDsAxmvTDfOJhsXOCxxrDREA(int P_0)
				{
					QTlZSjtpCpgVyQCXbvfjLqXJZhzp = P_0;
					MwCRpCGSddxAqabPHdkmgiqejwpt = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					switch (QTlZSjtpCpgVyQCXbvfjLqXJZhzp)
					{
					case -3:
					case 1:
						try
						{
							break;
						}
						finally
						{
							gQEqzMDLIKCFlxvlFpJjsVxbBnYi();
						}
					case -4:
					case 2:
						try
						{
							break;
						}
						finally
						{
							IJiXSgegFlIfgCVdSmfyfCNMOXFsA();
						}
					case -5:
					case 3:
						try
						{
							break;
						}
						finally
						{
							TzqgxhyPjmXbPSpQrUvXXmNiVqPR();
						}
					case -2:
					case -1:
					case 0:
						break;
					}
				}

				private bool MoveNext()
				{
					try
					{
						int qTlZSjtpCpgVyQCXbvfjLqXJZhzp = QTlZSjtpCpgVyQCXbvfjLqXJZhzp;
						PollingHelper pKsgzonBoXleQMvIeWtATYztxgfJ = PKsgzonBoXleQMvIeWtATYztxgfJ;
						switch (qTlZSjtpCpgVyQCXbvfjLqXJZhzp)
						{
						default:
							return false;
						case 0:
							QTlZSjtpCpgVyQCXbvfjLqXJZhzp = -1;
							if (!CheckInitialized())
							{
								return false;
							}
							ryNJrikxfNkmOBICvHJPYUxvETpkA = pKsgzonBoXleQMvIeWtATYztxgfJ.bHUPKGxbmuHNXJxEYhqlFahcZjOn().GetEnumerator();
							QTlZSjtpCpgVyQCXbvfjLqXJZhzp = -3;
							goto IL_0084;
						case 1:
							QTlZSjtpCpgVyQCXbvfjLqXJZhzp = -3;
							goto IL_0084;
						case 2:
							QTlZSjtpCpgVyQCXbvfjLqXJZhzp = -4;
							goto IL_00e4;
						case 3:
							{
								QTlZSjtpCpgVyQCXbvfjLqXJZhzp = -5;
								break;
							}
							IL_00e4:
							if (ryNJrikxfNkmOBICvHJPYUxvETpkA.MoveNext())
							{
								ControllerPollingInfo current = ryNJrikxfNkmOBICvHJPYUxvETpkA.Current;
								cNwuPatLfStZnHlkzulRQsOqViXF = current;
								QTlZSjtpCpgVyQCXbvfjLqXJZhzp = 2;
								return true;
							}
							IJiXSgegFlIfgCVdSmfyfCNMOXFsA();
							ryNJrikxfNkmOBICvHJPYUxvETpkA = null;
							ryNJrikxfNkmOBICvHJPYUxvETpkA = pKsgzonBoXleQMvIeWtATYztxgfJ.fRdgDcKRPQsUxymcUNSOcACDLNBB().GetEnumerator();
							QTlZSjtpCpgVyQCXbvfjLqXJZhzp = -5;
							break;
							IL_0084:
							if (ryNJrikxfNkmOBICvHJPYUxvETpkA.MoveNext())
							{
								ControllerPollingInfo current2 = ryNJrikxfNkmOBICvHJPYUxvETpkA.Current;
								cNwuPatLfStZnHlkzulRQsOqViXF = current2;
								QTlZSjtpCpgVyQCXbvfjLqXJZhzp = 1;
								return true;
							}
							gQEqzMDLIKCFlxvlFpJjsVxbBnYi();
							ryNJrikxfNkmOBICvHJPYUxvETpkA = null;
							ryNJrikxfNkmOBICvHJPYUxvETpkA = pKsgzonBoXleQMvIeWtATYztxgfJ.bNVbbwAewWvgbaxnriWIqtHAMFSE().GetEnumerator();
							QTlZSjtpCpgVyQCXbvfjLqXJZhzp = -4;
							goto IL_00e4;
						}
						if (ryNJrikxfNkmOBICvHJPYUxvETpkA.MoveNext())
						{
							ControllerPollingInfo current3 = ryNJrikxfNkmOBICvHJPYUxvETpkA.Current;
							cNwuPatLfStZnHlkzulRQsOqViXF = current3;
							QTlZSjtpCpgVyQCXbvfjLqXJZhzp = 3;
							return true;
						}
						TzqgxhyPjmXbPSpQrUvXXmNiVqPR();
						ryNJrikxfNkmOBICvHJPYUxvETpkA = null;
						return false;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void gQEqzMDLIKCFlxvlFpJjsVxbBnYi()
				{
					QTlZSjtpCpgVyQCXbvfjLqXJZhzp = -1;
					if (ryNJrikxfNkmOBICvHJPYUxvETpkA != null)
					{
						ryNJrikxfNkmOBICvHJPYUxvETpkA.Dispose();
					}
				}

				private void IJiXSgegFlIfgCVdSmfyfCNMOXFsA()
				{
					QTlZSjtpCpgVyQCXbvfjLqXJZhzp = -1;
					if (ryNJrikxfNkmOBICvHJPYUxvETpkA != null)
					{
						ryNJrikxfNkmOBICvHJPYUxvETpkA.Dispose();
					}
				}

				private void TzqgxhyPjmXbPSpQrUvXXmNiVqPR()
				{
					QTlZSjtpCpgVyQCXbvfjLqXJZhzp = -1;
					if (ryNJrikxfNkmOBICvHJPYUxvETpkA != null)
					{
						ryNJrikxfNkmOBICvHJPYUxvETpkA.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					bKdFmhDsAxmvTDfOJhsXOCxxrDREA bKdFmhDsAxmvTDfOJhsXOCxxrDREA2;
					if (QTlZSjtpCpgVyQCXbvfjLqXJZhzp == -2 && MwCRpCGSddxAqabPHdkmgiqejwpt == Environment.CurrentManagedThreadId)
					{
						QTlZSjtpCpgVyQCXbvfjLqXJZhzp = 0;
						bKdFmhDsAxmvTDfOJhsXOCxxrDREA2 = this;
					}
					else
					{
						bKdFmhDsAxmvTDfOJhsXOCxxrDREA2 = new bKdFmhDsAxmvTDfOJhsXOCxxrDREA(0);
						bKdFmhDsAxmvTDfOJhsXOCxxrDREA2.PKsgzonBoXleQMvIeWtATYztxgfJ = PKsgzonBoXleQMvIeWtATYztxgfJ;
					}
					return bKdFmhDsAxmvTDfOJhsXOCxxrDREA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class RyWIjsXgRaSWaPnvCfHKIUHkdicW : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int DselRBgajRgvndYqIqXoSpMeCVfbb;

				private ControllerPollingInfo IGCCeTjsXQXuFBiEMOobrDbSVPnS;

				private int LJQrizoSWPXfIhUNUExGAnVaadDJ;

				public PollingHelper CyAZlrHrqHFoLfjAXYHDVJmyejYr;

				private IEnumerator<ControllerPollingInfo> jvEUckfOrWsMSaGwGDNsGKoSNzDN;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return IGCCeTjsXQXuFBiEMOobrDbSVPnS;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return IGCCeTjsXQXuFBiEMOobrDbSVPnS;
					}
				}

				[DebuggerHidden]
				public RyWIjsXgRaSWaPnvCfHKIUHkdicW(int P_0)
				{
					DselRBgajRgvndYqIqXoSpMeCVfbb = P_0;
					LJQrizoSWPXfIhUNUExGAnVaadDJ = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					switch (DselRBgajRgvndYqIqXoSpMeCVfbb)
					{
					case -3:
					case 1:
						try
						{
							break;
						}
						finally
						{
							qDgdvKDQSCMQGSERfbdTavQAfjYCB();
						}
					case -4:
					case 2:
						try
						{
							break;
						}
						finally
						{
							QFvbqbfuhMnWyjbfcBhhdgMItazq();
						}
					case -5:
					case 3:
						try
						{
							break;
						}
						finally
						{
							XWgoIMebDRTAnuunPyMFTyBzAiN();
						}
					case -6:
					case 4:
						try
						{
							break;
						}
						finally
						{
							ZrddmKNKEZzBiEOFIjpfJTbwfnyw();
						}
					case -2:
					case -1:
					case 0:
						break;
					}
				}

				private bool MoveNext()
				{
					try
					{
						int dselRBgajRgvndYqIqXoSpMeCVfbb = DselRBgajRgvndYqIqXoSpMeCVfbb;
						PollingHelper cyAZlrHrqHFoLfjAXYHDVJmyejYr = CyAZlrHrqHFoLfjAXYHDVJmyejYr;
						switch (dselRBgajRgvndYqIqXoSpMeCVfbb)
						{
						default:
							return false;
						case 0:
							DselRBgajRgvndYqIqXoSpMeCVfbb = -1;
							if (!CheckInitialized())
							{
								return false;
							}
							jvEUckfOrWsMSaGwGDNsGKoSNzDN = cyAZlrHrqHFoLfjAXYHDVJmyejYr.BNatYQQBlAJbhztUioIhYNkaERk().GetEnumerator();
							DselRBgajRgvndYqIqXoSpMeCVfbb = -3;
							goto IL_0088;
						case 1:
							DselRBgajRgvndYqIqXoSpMeCVfbb = -3;
							goto IL_0088;
						case 2:
							DselRBgajRgvndYqIqXoSpMeCVfbb = -4;
							goto IL_00e8;
						case 3:
							DselRBgajRgvndYqIqXoSpMeCVfbb = -5;
							goto IL_0148;
						case 4:
							{
								DselRBgajRgvndYqIqXoSpMeCVfbb = -6;
								break;
							}
							IL_00e8:
							if (jvEUckfOrWsMSaGwGDNsGKoSNzDN.MoveNext())
							{
								ControllerPollingInfo current = jvEUckfOrWsMSaGwGDNsGKoSNzDN.Current;
								IGCCeTjsXQXuFBiEMOobrDbSVPnS = current;
								DselRBgajRgvndYqIqXoSpMeCVfbb = 2;
								return true;
							}
							QFvbqbfuhMnWyjbfcBhhdgMItazq();
							jvEUckfOrWsMSaGwGDNsGKoSNzDN = null;
							jvEUckfOrWsMSaGwGDNsGKoSNzDN = cyAZlrHrqHFoLfjAXYHDVJmyejYr.AIyPZoXHBYlsFHLJnYngVzyxkAxv().GetEnumerator();
							DselRBgajRgvndYqIqXoSpMeCVfbb = -5;
							goto IL_0148;
							IL_0088:
							if (jvEUckfOrWsMSaGwGDNsGKoSNzDN.MoveNext())
							{
								ControllerPollingInfo current2 = jvEUckfOrWsMSaGwGDNsGKoSNzDN.Current;
								IGCCeTjsXQXuFBiEMOobrDbSVPnS = current2;
								DselRBgajRgvndYqIqXoSpMeCVfbb = 1;
								return true;
							}
							qDgdvKDQSCMQGSERfbdTavQAfjYCB();
							jvEUckfOrWsMSaGwGDNsGKoSNzDN = null;
							jvEUckfOrWsMSaGwGDNsGKoSNzDN = cyAZlrHrqHFoLfjAXYHDVJmyejYr.ozmBDRdYzWLUwQfyfACLhkxCDgRyb().GetEnumerator();
							DselRBgajRgvndYqIqXoSpMeCVfbb = -4;
							goto IL_00e8;
							IL_0148:
							if (jvEUckfOrWsMSaGwGDNsGKoSNzDN.MoveNext())
							{
								ControllerPollingInfo current3 = jvEUckfOrWsMSaGwGDNsGKoSNzDN.Current;
								IGCCeTjsXQXuFBiEMOobrDbSVPnS = current3;
								DselRBgajRgvndYqIqXoSpMeCVfbb = 3;
								return true;
							}
							XWgoIMebDRTAnuunPyMFTyBzAiN();
							jvEUckfOrWsMSaGwGDNsGKoSNzDN = null;
							jvEUckfOrWsMSaGwGDNsGKoSNzDN = cyAZlrHrqHFoLfjAXYHDVJmyejYr.FgeVayGrKtIjvqQBdlKzzfRdaFLcA().GetEnumerator();
							DselRBgajRgvndYqIqXoSpMeCVfbb = -6;
							break;
						}
						if (jvEUckfOrWsMSaGwGDNsGKoSNzDN.MoveNext())
						{
							ControllerPollingInfo current4 = jvEUckfOrWsMSaGwGDNsGKoSNzDN.Current;
							IGCCeTjsXQXuFBiEMOobrDbSVPnS = current4;
							DselRBgajRgvndYqIqXoSpMeCVfbb = 4;
							return true;
						}
						ZrddmKNKEZzBiEOFIjpfJTbwfnyw();
						jvEUckfOrWsMSaGwGDNsGKoSNzDN = null;
						return false;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void qDgdvKDQSCMQGSERfbdTavQAfjYCB()
				{
					DselRBgajRgvndYqIqXoSpMeCVfbb = -1;
					if (jvEUckfOrWsMSaGwGDNsGKoSNzDN != null)
					{
						jvEUckfOrWsMSaGwGDNsGKoSNzDN.Dispose();
					}
				}

				private void QFvbqbfuhMnWyjbfcBhhdgMItazq()
				{
					DselRBgajRgvndYqIqXoSpMeCVfbb = -1;
					if (jvEUckfOrWsMSaGwGDNsGKoSNzDN != null)
					{
						jvEUckfOrWsMSaGwGDNsGKoSNzDN.Dispose();
					}
				}

				private void XWgoIMebDRTAnuunPyMFTyBzAiN()
				{
					DselRBgajRgvndYqIqXoSpMeCVfbb = -1;
					if (jvEUckfOrWsMSaGwGDNsGKoSNzDN != null)
					{
						jvEUckfOrWsMSaGwGDNsGKoSNzDN.Dispose();
					}
				}

				private void ZrddmKNKEZzBiEOFIjpfJTbwfnyw()
				{
					DselRBgajRgvndYqIqXoSpMeCVfbb = -1;
					if (jvEUckfOrWsMSaGwGDNsGKoSNzDN != null)
					{
						jvEUckfOrWsMSaGwGDNsGKoSNzDN.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					RyWIjsXgRaSWaPnvCfHKIUHkdicW ryWIjsXgRaSWaPnvCfHKIUHkdicW;
					if (DselRBgajRgvndYqIqXoSpMeCVfbb == -2 && LJQrizoSWPXfIhUNUExGAnVaadDJ == Environment.CurrentManagedThreadId)
					{
						DselRBgajRgvndYqIqXoSpMeCVfbb = 0;
						ryWIjsXgRaSWaPnvCfHKIUHkdicW = this;
					}
					else
					{
						ryWIjsXgRaSWaPnvCfHKIUHkdicW = new RyWIjsXgRaSWaPnvCfHKIUHkdicW(0);
						ryWIjsXgRaSWaPnvCfHKIUHkdicW.CyAZlrHrqHFoLfjAXYHDVJmyejYr = CyAZlrHrqHFoLfjAXYHDVJmyejYr;
					}
					return ryWIjsXgRaSWaPnvCfHKIUHkdicW;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class JMneRkLLjfBndaEDQEqFyoUlTstqA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int FOlfRZfkouWbjcscAYVJoEBiYgwI;

				private ControllerPollingInfo SekXCzOXhcrJfjyltMVWHGBweqmz;

				private int OdXYKJTpiMMKjIUrCidITcVoZcMn;

				public PollingHelper oUvhteKwgJYBliKjguzWLNgPqgmg;

				private IEnumerator<ControllerPollingInfo> msCeVcFoirZSKFQXOpnRDmUkXBQDA;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return SekXCzOXhcrJfjyltMVWHGBweqmz;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return SekXCzOXhcrJfjyltMVWHGBweqmz;
					}
				}

				[DebuggerHidden]
				public JMneRkLLjfBndaEDQEqFyoUlTstqA(int P_0)
				{
					FOlfRZfkouWbjcscAYVJoEBiYgwI = P_0;
					OdXYKJTpiMMKjIUrCidITcVoZcMn = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					switch (FOlfRZfkouWbjcscAYVJoEBiYgwI)
					{
					case -3:
					case 1:
						try
						{
							break;
						}
						finally
						{
							IvcztwTdOCLCeOYHuisPvKdyMSnP();
						}
					case -4:
					case 2:
						try
						{
							break;
						}
						finally
						{
							pfMXLXrpRasfNHOLfmFPWgKKpqTI();
						}
					case -5:
					case 3:
						try
						{
							break;
						}
						finally
						{
							zkzBKBzjTNDWhYxTpdoSyLuoBcvX();
						}
					case -6:
					case 4:
						try
						{
							break;
						}
						finally
						{
							xHAXosjpTouITHqhvYSkhDkfiOkd();
						}
					case -2:
					case -1:
					case 0:
						break;
					}
				}

				private bool MoveNext()
				{
					try
					{
						int fOlfRZfkouWbjcscAYVJoEBiYgwI = FOlfRZfkouWbjcscAYVJoEBiYgwI;
						PollingHelper pollingHelper = oUvhteKwgJYBliKjguzWLNgPqgmg;
						switch (fOlfRZfkouWbjcscAYVJoEBiYgwI)
						{
						default:
							return false;
						case 0:
							FOlfRZfkouWbjcscAYVJoEBiYgwI = -1;
							if (!CheckInitialized())
							{
								return false;
							}
							msCeVcFoirZSKFQXOpnRDmUkXBQDA = pollingHelper.KOfUmuGVZeEuXzakDKbwYpJejtIU().GetEnumerator();
							FOlfRZfkouWbjcscAYVJoEBiYgwI = -3;
							goto IL_0088;
						case 1:
							FOlfRZfkouWbjcscAYVJoEBiYgwI = -3;
							goto IL_0088;
						case 2:
							FOlfRZfkouWbjcscAYVJoEBiYgwI = -4;
							goto IL_00e8;
						case 3:
							FOlfRZfkouWbjcscAYVJoEBiYgwI = -5;
							goto IL_0148;
						case 4:
							{
								FOlfRZfkouWbjcscAYVJoEBiYgwI = -6;
								break;
							}
							IL_00e8:
							if (msCeVcFoirZSKFQXOpnRDmUkXBQDA.MoveNext())
							{
								ControllerPollingInfo current = msCeVcFoirZSKFQXOpnRDmUkXBQDA.Current;
								SekXCzOXhcrJfjyltMVWHGBweqmz = current;
								FOlfRZfkouWbjcscAYVJoEBiYgwI = 2;
								return true;
							}
							pfMXLXrpRasfNHOLfmFPWgKKpqTI();
							msCeVcFoirZSKFQXOpnRDmUkXBQDA = null;
							msCeVcFoirZSKFQXOpnRDmUkXBQDA = pollingHelper.imfRmVEeiZfoYJLcvzMIQSTjIYwcb().GetEnumerator();
							FOlfRZfkouWbjcscAYVJoEBiYgwI = -5;
							goto IL_0148;
							IL_0088:
							if (msCeVcFoirZSKFQXOpnRDmUkXBQDA.MoveNext())
							{
								ControllerPollingInfo current2 = msCeVcFoirZSKFQXOpnRDmUkXBQDA.Current;
								SekXCzOXhcrJfjyltMVWHGBweqmz = current2;
								FOlfRZfkouWbjcscAYVJoEBiYgwI = 1;
								return true;
							}
							IvcztwTdOCLCeOYHuisPvKdyMSnP();
							msCeVcFoirZSKFQXOpnRDmUkXBQDA = null;
							msCeVcFoirZSKFQXOpnRDmUkXBQDA = pollingHelper.RJJCFfURfKgJyzPAzKEvHvoljyxC().GetEnumerator();
							FOlfRZfkouWbjcscAYVJoEBiYgwI = -4;
							goto IL_00e8;
							IL_0148:
							if (msCeVcFoirZSKFQXOpnRDmUkXBQDA.MoveNext())
							{
								ControllerPollingInfo current3 = msCeVcFoirZSKFQXOpnRDmUkXBQDA.Current;
								SekXCzOXhcrJfjyltMVWHGBweqmz = current3;
								FOlfRZfkouWbjcscAYVJoEBiYgwI = 3;
								return true;
							}
							zkzBKBzjTNDWhYxTpdoSyLuoBcvX();
							msCeVcFoirZSKFQXOpnRDmUkXBQDA = null;
							msCeVcFoirZSKFQXOpnRDmUkXBQDA = pollingHelper.DKChNbDNTRNWKwSqTouWfapYsDAmA().GetEnumerator();
							FOlfRZfkouWbjcscAYVJoEBiYgwI = -6;
							break;
						}
						if (msCeVcFoirZSKFQXOpnRDmUkXBQDA.MoveNext())
						{
							ControllerPollingInfo current4 = msCeVcFoirZSKFQXOpnRDmUkXBQDA.Current;
							SekXCzOXhcrJfjyltMVWHGBweqmz = current4;
							FOlfRZfkouWbjcscAYVJoEBiYgwI = 4;
							return true;
						}
						xHAXosjpTouITHqhvYSkhDkfiOkd();
						msCeVcFoirZSKFQXOpnRDmUkXBQDA = null;
						return false;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void IvcztwTdOCLCeOYHuisPvKdyMSnP()
				{
					FOlfRZfkouWbjcscAYVJoEBiYgwI = -1;
					if (msCeVcFoirZSKFQXOpnRDmUkXBQDA != null)
					{
						msCeVcFoirZSKFQXOpnRDmUkXBQDA.Dispose();
					}
				}

				private void pfMXLXrpRasfNHOLfmFPWgKKpqTI()
				{
					FOlfRZfkouWbjcscAYVJoEBiYgwI = -1;
					if (msCeVcFoirZSKFQXOpnRDmUkXBQDA != null)
					{
						msCeVcFoirZSKFQXOpnRDmUkXBQDA.Dispose();
					}
				}

				private void zkzBKBzjTNDWhYxTpdoSyLuoBcvX()
				{
					FOlfRZfkouWbjcscAYVJoEBiYgwI = -1;
					if (msCeVcFoirZSKFQXOpnRDmUkXBQDA != null)
					{
						msCeVcFoirZSKFQXOpnRDmUkXBQDA.Dispose();
					}
				}

				private void xHAXosjpTouITHqhvYSkhDkfiOkd()
				{
					FOlfRZfkouWbjcscAYVJoEBiYgwI = -1;
					if (msCeVcFoirZSKFQXOpnRDmUkXBQDA != null)
					{
						msCeVcFoirZSKFQXOpnRDmUkXBQDA.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					JMneRkLLjfBndaEDQEqFyoUlTstqA jMneRkLLjfBndaEDQEqFyoUlTstqA;
					if (FOlfRZfkouWbjcscAYVJoEBiYgwI == -2 && OdXYKJTpiMMKjIUrCidITcVoZcMn == Environment.CurrentManagedThreadId)
					{
						FOlfRZfkouWbjcscAYVJoEBiYgwI = 0;
						jMneRkLLjfBndaEDQEqFyoUlTstqA = this;
					}
					else
					{
						jMneRkLLjfBndaEDQEqFyoUlTstqA = new JMneRkLLjfBndaEDQEqFyoUlTstqA(0);
						jMneRkLLjfBndaEDQEqFyoUlTstqA.oUvhteKwgJYBliKjguzWLNgPqgmg = oUvhteKwgJYBliKjguzWLNgPqgmg;
					}
					return jMneRkLLjfBndaEDQEqFyoUlTstqA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class EzyIOEISichcTznwHOoQuCLlOcQb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int EVGDABjnagMsdMeBmVSXNdSShLLoA;

				private ControllerPollingInfo rnNnswtHBEmsHXsrzUNLzBgVpgjM;

				private int LMpsRBeQwamhLuGpAiIBjUqHYKhtA;

				public PollingHelper MkjmDlCPPagUVhWMdhDMJZivZBBr;

				private IEnumerator<ControllerPollingInfo> wEdTlPstEoYejUzRIVLVkEEBeuSj;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return rnNnswtHBEmsHXsrzUNLzBgVpgjM;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return rnNnswtHBEmsHXsrzUNLzBgVpgjM;
					}
				}

				[DebuggerHidden]
				public EzyIOEISichcTznwHOoQuCLlOcQb(int P_0)
				{
					EVGDABjnagMsdMeBmVSXNdSShLLoA = P_0;
					LMpsRBeQwamhLuGpAiIBjUqHYKhtA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					switch (EVGDABjnagMsdMeBmVSXNdSShLLoA)
					{
					case -3:
					case 1:
						try
						{
							break;
						}
						finally
						{
							GIbciTpptstggslfbBHVezTLqkTQA();
						}
					case -4:
					case 2:
						try
						{
							break;
						}
						finally
						{
							VkzBdAjQOmxDwDvIhefcWLYRkCkSA();
						}
					case -5:
					case 3:
						try
						{
							break;
						}
						finally
						{
							AuBbvcAxaCNFundhkAssnoqsqxImA();
						}
					case -6:
					case 4:
						try
						{
							break;
						}
						finally
						{
							adFUWoSYBTRKwSBiVaMMLaMlfYnA();
						}
					case -2:
					case -1:
					case 0:
						break;
					}
				}

				private bool MoveNext()
				{
					try
					{
						int eVGDABjnagMsdMeBmVSXNdSShLLoA = EVGDABjnagMsdMeBmVSXNdSShLLoA;
						PollingHelper mkjmDlCPPagUVhWMdhDMJZivZBBr = MkjmDlCPPagUVhWMdhDMJZivZBBr;
						switch (eVGDABjnagMsdMeBmVSXNdSShLLoA)
						{
						default:
							return false;
						case 0:
							EVGDABjnagMsdMeBmVSXNdSShLLoA = -1;
							if (!CheckInitialized())
							{
								return false;
							}
							wEdTlPstEoYejUzRIVLVkEEBeuSj = mkjmDlCPPagUVhWMdhDMJZivZBBr.KfmbhKIUQvEnDdAcdUrkeAekbQsmB().GetEnumerator();
							EVGDABjnagMsdMeBmVSXNdSShLLoA = -3;
							goto IL_0088;
						case 1:
							EVGDABjnagMsdMeBmVSXNdSShLLoA = -3;
							goto IL_0088;
						case 2:
							EVGDABjnagMsdMeBmVSXNdSShLLoA = -4;
							goto IL_00e8;
						case 3:
							EVGDABjnagMsdMeBmVSXNdSShLLoA = -5;
							goto IL_0148;
						case 4:
							{
								EVGDABjnagMsdMeBmVSXNdSShLLoA = -6;
								break;
							}
							IL_00e8:
							if (wEdTlPstEoYejUzRIVLVkEEBeuSj.MoveNext())
							{
								ControllerPollingInfo current = wEdTlPstEoYejUzRIVLVkEEBeuSj.Current;
								rnNnswtHBEmsHXsrzUNLzBgVpgjM = current;
								EVGDABjnagMsdMeBmVSXNdSShLLoA = 2;
								return true;
							}
							VkzBdAjQOmxDwDvIhefcWLYRkCkSA();
							wEdTlPstEoYejUzRIVLVkEEBeuSj = null;
							wEdTlPstEoYejUzRIVLVkEEBeuSj = mkjmDlCPPagUVhWMdhDMJZivZBBr.goGRwcaxYPqlGSYNxoaUMusfzfWA().GetEnumerator();
							EVGDABjnagMsdMeBmVSXNdSShLLoA = -5;
							goto IL_0148;
							IL_0088:
							if (wEdTlPstEoYejUzRIVLVkEEBeuSj.MoveNext())
							{
								ControllerPollingInfo current2 = wEdTlPstEoYejUzRIVLVkEEBeuSj.Current;
								rnNnswtHBEmsHXsrzUNLzBgVpgjM = current2;
								EVGDABjnagMsdMeBmVSXNdSShLLoA = 1;
								return true;
							}
							GIbciTpptstggslfbBHVezTLqkTQA();
							wEdTlPstEoYejUzRIVLVkEEBeuSj = null;
							wEdTlPstEoYejUzRIVLVkEEBeuSj = mkjmDlCPPagUVhWMdhDMJZivZBBr.ozmBDRdYzWLUwQfyfACLhkxCDgRyb().GetEnumerator();
							EVGDABjnagMsdMeBmVSXNdSShLLoA = -4;
							goto IL_00e8;
							IL_0148:
							if (wEdTlPstEoYejUzRIVLVkEEBeuSj.MoveNext())
							{
								ControllerPollingInfo current3 = wEdTlPstEoYejUzRIVLVkEEBeuSj.Current;
								rnNnswtHBEmsHXsrzUNLzBgVpgjM = current3;
								EVGDABjnagMsdMeBmVSXNdSShLLoA = 3;
								return true;
							}
							AuBbvcAxaCNFundhkAssnoqsqxImA();
							wEdTlPstEoYejUzRIVLVkEEBeuSj = null;
							wEdTlPstEoYejUzRIVLVkEEBeuSj = mkjmDlCPPagUVhWMdhDMJZivZBBr.iAmJiGqnDeznBUFGUyVysujsGzX().GetEnumerator();
							EVGDABjnagMsdMeBmVSXNdSShLLoA = -6;
							break;
						}
						if (wEdTlPstEoYejUzRIVLVkEEBeuSj.MoveNext())
						{
							ControllerPollingInfo current4 = wEdTlPstEoYejUzRIVLVkEEBeuSj.Current;
							rnNnswtHBEmsHXsrzUNLzBgVpgjM = current4;
							EVGDABjnagMsdMeBmVSXNdSShLLoA = 4;
							return true;
						}
						adFUWoSYBTRKwSBiVaMMLaMlfYnA();
						wEdTlPstEoYejUzRIVLVkEEBeuSj = null;
						return false;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void GIbciTpptstggslfbBHVezTLqkTQA()
				{
					EVGDABjnagMsdMeBmVSXNdSShLLoA = -1;
					if (wEdTlPstEoYejUzRIVLVkEEBeuSj != null)
					{
						wEdTlPstEoYejUzRIVLVkEEBeuSj.Dispose();
					}
				}

				private void VkzBdAjQOmxDwDvIhefcWLYRkCkSA()
				{
					EVGDABjnagMsdMeBmVSXNdSShLLoA = -1;
					if (wEdTlPstEoYejUzRIVLVkEEBeuSj != null)
					{
						wEdTlPstEoYejUzRIVLVkEEBeuSj.Dispose();
					}
				}

				private void AuBbvcAxaCNFundhkAssnoqsqxImA()
				{
					EVGDABjnagMsdMeBmVSXNdSShLLoA = -1;
					if (wEdTlPstEoYejUzRIVLVkEEBeuSj != null)
					{
						wEdTlPstEoYejUzRIVLVkEEBeuSj.Dispose();
					}
				}

				private void adFUWoSYBTRKwSBiVaMMLaMlfYnA()
				{
					EVGDABjnagMsdMeBmVSXNdSShLLoA = -1;
					if (wEdTlPstEoYejUzRIVLVkEEBeuSj != null)
					{
						wEdTlPstEoYejUzRIVLVkEEBeuSj.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					EzyIOEISichcTznwHOoQuCLlOcQb ezyIOEISichcTznwHOoQuCLlOcQb;
					if (EVGDABjnagMsdMeBmVSXNdSShLLoA == -2 && LMpsRBeQwamhLuGpAiIBjUqHYKhtA == Environment.CurrentManagedThreadId)
					{
						EVGDABjnagMsdMeBmVSXNdSShLLoA = 0;
						ezyIOEISichcTznwHOoQuCLlOcQb = this;
					}
					else
					{
						ezyIOEISichcTznwHOoQuCLlOcQb = new EzyIOEISichcTznwHOoQuCLlOcQb(0);
						ezyIOEISichcTznwHOoQuCLlOcQb.MkjmDlCPPagUVhWMdhDMJZivZBBr = MkjmDlCPPagUVhWMdhDMJZivZBBr;
					}
					return ezyIOEISichcTznwHOoQuCLlOcQb;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class eHvBcMEOTJhHHtHBbwweUNNvlGrtA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int xbwULGxwkswJwmUraafyiCOUtlXx;

				private ControllerPollingInfo pGZNjaABGGLrQLaHHgEFjRDZaONrA;

				private int LHneSYsDQdFvLkbZWqWbBuBFQqCy;

				public PollingHelper tpOfpUhEfjDrUeAPtmazKUSEoACFb;

				private IEnumerator<ControllerPollingInfo> AuOWlEExauYtllCIokxbywTMConD;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return pGZNjaABGGLrQLaHHgEFjRDZaONrA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return pGZNjaABGGLrQLaHHgEFjRDZaONrA;
					}
				}

				[DebuggerHidden]
				public eHvBcMEOTJhHHtHBbwweUNNvlGrtA(int P_0)
				{
					xbwULGxwkswJwmUraafyiCOUtlXx = P_0;
					LHneSYsDQdFvLkbZWqWbBuBFQqCy = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					switch (xbwULGxwkswJwmUraafyiCOUtlXx)
					{
					case -3:
					case 1:
						try
						{
							break;
						}
						finally
						{
							uOqeOyVRKycZLdMyIyzxCFWgmDPL();
						}
					case -4:
					case 2:
						try
						{
							break;
						}
						finally
						{
							haiYURqAJSYIphCrqnbXBNILZDGA();
						}
					case -5:
					case 3:
						try
						{
							break;
						}
						finally
						{
							kRfdOxPilTxKyYIwbBDiaqHqsaHV();
						}
					case -6:
					case 4:
						try
						{
							break;
						}
						finally
						{
							noSxZKgkzEeLchCImToGHgAwdMss();
						}
					case -2:
					case -1:
					case 0:
						break;
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = xbwULGxwkswJwmUraafyiCOUtlXx;
						PollingHelper pollingHelper = tpOfpUhEfjDrUeAPtmazKUSEoACFb;
						switch (num)
						{
						default:
							return false;
						case 0:
							xbwULGxwkswJwmUraafyiCOUtlXx = -1;
							if (!CheckInitialized())
							{
								return false;
							}
							AuOWlEExauYtllCIokxbywTMConD = pollingHelper.YRMXiJvkuJOICQfRULAWdmFUChHW().GetEnumerator();
							xbwULGxwkswJwmUraafyiCOUtlXx = -3;
							goto IL_0088;
						case 1:
							xbwULGxwkswJwmUraafyiCOUtlXx = -3;
							goto IL_0088;
						case 2:
							xbwULGxwkswJwmUraafyiCOUtlXx = -4;
							goto IL_00e8;
						case 3:
							xbwULGxwkswJwmUraafyiCOUtlXx = -5;
							goto IL_0148;
						case 4:
							{
								xbwULGxwkswJwmUraafyiCOUtlXx = -6;
								break;
							}
							IL_00e8:
							if (AuOWlEExauYtllCIokxbywTMConD.MoveNext())
							{
								ControllerPollingInfo current = AuOWlEExauYtllCIokxbywTMConD.Current;
								pGZNjaABGGLrQLaHHgEFjRDZaONrA = current;
								xbwULGxwkswJwmUraafyiCOUtlXx = 2;
								return true;
							}
							haiYURqAJSYIphCrqnbXBNILZDGA();
							AuOWlEExauYtllCIokxbywTMConD = null;
							AuOWlEExauYtllCIokxbywTMConD = pollingHelper.cFeVzjWyLkCGYMlgciPFuippbBOw().GetEnumerator();
							xbwULGxwkswJwmUraafyiCOUtlXx = -5;
							goto IL_0148;
							IL_0088:
							if (AuOWlEExauYtllCIokxbywTMConD.MoveNext())
							{
								ControllerPollingInfo current2 = AuOWlEExauYtllCIokxbywTMConD.Current;
								pGZNjaABGGLrQLaHHgEFjRDZaONrA = current2;
								xbwULGxwkswJwmUraafyiCOUtlXx = 1;
								return true;
							}
							uOqeOyVRKycZLdMyIyzxCFWgmDPL();
							AuOWlEExauYtllCIokxbywTMConD = null;
							AuOWlEExauYtllCIokxbywTMConD = pollingHelper.RJJCFfURfKgJyzPAzKEvHvoljyxC().GetEnumerator();
							xbwULGxwkswJwmUraafyiCOUtlXx = -4;
							goto IL_00e8;
							IL_0148:
							if (AuOWlEExauYtllCIokxbywTMConD.MoveNext())
							{
								ControllerPollingInfo current3 = AuOWlEExauYtllCIokxbywTMConD.Current;
								pGZNjaABGGLrQLaHHgEFjRDZaONrA = current3;
								xbwULGxwkswJwmUraafyiCOUtlXx = 3;
								return true;
							}
							kRfdOxPilTxKyYIwbBDiaqHqsaHV();
							AuOWlEExauYtllCIokxbywTMConD = null;
							AuOWlEExauYtllCIokxbywTMConD = pollingHelper.iWJZPgqzaKOlobkxUcJsCqhzBQEmA().GetEnumerator();
							xbwULGxwkswJwmUraafyiCOUtlXx = -6;
							break;
						}
						if (AuOWlEExauYtllCIokxbywTMConD.MoveNext())
						{
							ControllerPollingInfo current4 = AuOWlEExauYtllCIokxbywTMConD.Current;
							pGZNjaABGGLrQLaHHgEFjRDZaONrA = current4;
							xbwULGxwkswJwmUraafyiCOUtlXx = 4;
							return true;
						}
						noSxZKgkzEeLchCImToGHgAwdMss();
						AuOWlEExauYtllCIokxbywTMConD = null;
						return false;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void uOqeOyVRKycZLdMyIyzxCFWgmDPL()
				{
					xbwULGxwkswJwmUraafyiCOUtlXx = -1;
					if (AuOWlEExauYtllCIokxbywTMConD != null)
					{
						AuOWlEExauYtllCIokxbywTMConD.Dispose();
					}
				}

				private void haiYURqAJSYIphCrqnbXBNILZDGA()
				{
					xbwULGxwkswJwmUraafyiCOUtlXx = -1;
					if (AuOWlEExauYtllCIokxbywTMConD != null)
					{
						AuOWlEExauYtllCIokxbywTMConD.Dispose();
					}
				}

				private void kRfdOxPilTxKyYIwbBDiaqHqsaHV()
				{
					xbwULGxwkswJwmUraafyiCOUtlXx = -1;
					if (AuOWlEExauYtllCIokxbywTMConD != null)
					{
						AuOWlEExauYtllCIokxbywTMConD.Dispose();
					}
				}

				private void noSxZKgkzEeLchCImToGHgAwdMss()
				{
					xbwULGxwkswJwmUraafyiCOUtlXx = -1;
					if (AuOWlEExauYtllCIokxbywTMConD != null)
					{
						AuOWlEExauYtllCIokxbywTMConD.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					eHvBcMEOTJhHHtHBbwweUNNvlGrtA eHvBcMEOTJhHHtHBbwweUNNvlGrtA2;
					if (xbwULGxwkswJwmUraafyiCOUtlXx == -2 && LHneSYsDQdFvLkbZWqWbBuBFQqCy == Environment.CurrentManagedThreadId)
					{
						xbwULGxwkswJwmUraafyiCOUtlXx = 0;
						eHvBcMEOTJhHHtHBbwweUNNvlGrtA2 = this;
					}
					else
					{
						eHvBcMEOTJhHHtHBbwweUNNvlGrtA2 = new eHvBcMEOTJhHHtHBbwweUNNvlGrtA(0);
						eHvBcMEOTJhHHtHBbwweUNNvlGrtA2.tpOfpUhEfjDrUeAPtmazKUSEoACFb = tpOfpUhEfjDrUeAPtmazKUSEoACFb;
					}
					return eHvBcMEOTJhHHtHBbwweUNNvlGrtA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class oGifiEoyXRgDtRDAhdVmAPjzxEUC : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int LWWXvsrwJSTTqWKPlGahVUcqKYMT;

				private ControllerPollingInfo bZuYHOjjaWZkkuUdAjEdSmzjWciX;

				private int jwJhRyuXDilEQjyTudHtwPFJmOif;

				private IList<CustomController> kvRCmNIiPtvgNIhwUCwRPrjGLTWMA;

				private int yrqDxbOeLfjTYHwZqNBHvrmpULZG;

				private IEnumerator<ControllerPollingInfo> dIZbMuaDPiOJJFrkaFnkTBVlmJRcb;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return bZuYHOjjaWZkkuUdAjEdSmzjWciX;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return bZuYHOjjaWZkkuUdAjEdSmzjWciX;
					}
				}

				[DebuggerHidden]
				public oGifiEoyXRgDtRDAhdVmAPjzxEUC(int P_0)
				{
					LWWXvsrwJSTTqWKPlGahVUcqKYMT = P_0;
					jwJhRyuXDilEQjyTudHtwPFJmOif = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int lWWXvsrwJSTTqWKPlGahVUcqKYMT = LWWXvsrwJSTTqWKPlGahVUcqKYMT;
					if (lWWXvsrwJSTTqWKPlGahVUcqKYMT == -3 || lWWXvsrwJSTTqWKPlGahVUcqKYMT == 1)
					{
						try
						{
						}
						finally
						{
							UaelfkoBPqwYhCMfHSEvxGJopcxH();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int lWWXvsrwJSTTqWKPlGahVUcqKYMT = LWWXvsrwJSTTqWKPlGahVUcqKYMT;
						if (lWWXvsrwJSTTqWKPlGahVUcqKYMT != 0)
						{
							if (lWWXvsrwJSTTqWKPlGahVUcqKYMT != 1)
							{
								return false;
							}
							LWWXvsrwJSTTqWKPlGahVUcqKYMT = -3;
							goto IL_0086;
						}
						LWWXvsrwJSTTqWKPlGahVUcqKYMT = -1;
						kvRCmNIiPtvgNIhwUCwRPrjGLTWMA = jCkgZLcnXoMycBxzcMXWvnUfSROEb.oEBCyTxQXibzLFYTdcadMQGimPZS();
						yrqDxbOeLfjTYHwZqNBHvrmpULZG = 0;
						goto IL_00b0;
						IL_0086:
						if (dIZbMuaDPiOJJFrkaFnkTBVlmJRcb.MoveNext())
						{
							ControllerPollingInfo current = dIZbMuaDPiOJJFrkaFnkTBVlmJRcb.Current;
							bZuYHOjjaWZkkuUdAjEdSmzjWciX = current;
							LWWXvsrwJSTTqWKPlGahVUcqKYMT = 1;
							return true;
						}
						UaelfkoBPqwYhCMfHSEvxGJopcxH();
						dIZbMuaDPiOJJFrkaFnkTBVlmJRcb = null;
						yrqDxbOeLfjTYHwZqNBHvrmpULZG++;
						goto IL_00b0;
						IL_00b0:
						if (yrqDxbOeLfjTYHwZqNBHvrmpULZG < kvRCmNIiPtvgNIhwUCwRPrjGLTWMA.Count)
						{
							dIZbMuaDPiOJJFrkaFnkTBVlmJRcb = kvRCmNIiPtvgNIhwUCwRPrjGLTWMA[yrqDxbOeLfjTYHwZqNBHvrmpULZG].PollForAllAxes().GetEnumerator();
							LWWXvsrwJSTTqWKPlGahVUcqKYMT = -3;
							goto IL_0086;
						}
						return false;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void UaelfkoBPqwYhCMfHSEvxGJopcxH()
				{
					LWWXvsrwJSTTqWKPlGahVUcqKYMT = -1;
					if (dIZbMuaDPiOJJFrkaFnkTBVlmJRcb != null)
					{
						dIZbMuaDPiOJJFrkaFnkTBVlmJRcb.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					if (LWWXvsrwJSTTqWKPlGahVUcqKYMT == -2 && jwJhRyuXDilEQjyTudHtwPFJmOif == Environment.CurrentManagedThreadId)
					{
						LWWXvsrwJSTTqWKPlGahVUcqKYMT = 0;
						return this;
					}
					return new oGifiEoyXRgDtRDAhdVmAPjzxEUC(0);
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class WgzjtjyPCqnQDelsLzNcjtLRvJXy : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int YUIQupyBUoLAMxzBHikJfdRCZrxy;

				private ControllerPollingInfo LrZbztDhfSGKQOJPDkOydPqviCMnA;

				private int AJSlgyECDJHGpewZhNYrFSwOELOCb;

				private IList<CustomController> NYWAEaHRxpsTEgzpeDpyUNyMspgk;

				private int lhjrWOBjuecpKnBRWpWueTgBOmvS;

				private IEnumerator<ControllerPollingInfo> anrJKRMFCgnGVXETPBPwzNbzFbWHA;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return LrZbztDhfSGKQOJPDkOydPqviCMnA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return LrZbztDhfSGKQOJPDkOydPqviCMnA;
					}
				}

				[DebuggerHidden]
				public WgzjtjyPCqnQDelsLzNcjtLRvJXy(int P_0)
				{
					YUIQupyBUoLAMxzBHikJfdRCZrxy = P_0;
					AJSlgyECDJHGpewZhNYrFSwOELOCb = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int yUIQupyBUoLAMxzBHikJfdRCZrxy = YUIQupyBUoLAMxzBHikJfdRCZrxy;
					if (yUIQupyBUoLAMxzBHikJfdRCZrxy == -3 || yUIQupyBUoLAMxzBHikJfdRCZrxy == 1)
					{
						try
						{
						}
						finally
						{
							upLObslyQhgdiyQwAndvnFVBQuqO();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int yUIQupyBUoLAMxzBHikJfdRCZrxy = YUIQupyBUoLAMxzBHikJfdRCZrxy;
						if (yUIQupyBUoLAMxzBHikJfdRCZrxy != 0)
						{
							if (yUIQupyBUoLAMxzBHikJfdRCZrxy != 1)
							{
								return false;
							}
							YUIQupyBUoLAMxzBHikJfdRCZrxy = -3;
							goto IL_0086;
						}
						YUIQupyBUoLAMxzBHikJfdRCZrxy = -1;
						NYWAEaHRxpsTEgzpeDpyUNyMspgk = jCkgZLcnXoMycBxzcMXWvnUfSROEb.oEBCyTxQXibzLFYTdcadMQGimPZS();
						lhjrWOBjuecpKnBRWpWueTgBOmvS = 0;
						goto IL_00b0;
						IL_0086:
						if (anrJKRMFCgnGVXETPBPwzNbzFbWHA.MoveNext())
						{
							ControllerPollingInfo current = anrJKRMFCgnGVXETPBPwzNbzFbWHA.Current;
							LrZbztDhfSGKQOJPDkOydPqviCMnA = current;
							YUIQupyBUoLAMxzBHikJfdRCZrxy = 1;
							return true;
						}
						upLObslyQhgdiyQwAndvnFVBQuqO();
						anrJKRMFCgnGVXETPBPwzNbzFbWHA = null;
						lhjrWOBjuecpKnBRWpWueTgBOmvS++;
						goto IL_00b0;
						IL_00b0:
						if (lhjrWOBjuecpKnBRWpWueTgBOmvS < NYWAEaHRxpsTEgzpeDpyUNyMspgk.Count)
						{
							anrJKRMFCgnGVXETPBPwzNbzFbWHA = NYWAEaHRxpsTEgzpeDpyUNyMspgk[lhjrWOBjuecpKnBRWpWueTgBOmvS].PollForAllButtons().GetEnumerator();
							YUIQupyBUoLAMxzBHikJfdRCZrxy = -3;
							goto IL_0086;
						}
						return false;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void upLObslyQhgdiyQwAndvnFVBQuqO()
				{
					YUIQupyBUoLAMxzBHikJfdRCZrxy = -1;
					if (anrJKRMFCgnGVXETPBPwzNbzFbWHA != null)
					{
						anrJKRMFCgnGVXETPBPwzNbzFbWHA.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					if (YUIQupyBUoLAMxzBHikJfdRCZrxy == -2 && AJSlgyECDJHGpewZhNYrFSwOELOCb == Environment.CurrentManagedThreadId)
					{
						YUIQupyBUoLAMxzBHikJfdRCZrxy = 0;
						return this;
					}
					return new WgzjtjyPCqnQDelsLzNcjtLRvJXy(0);
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class JzURznUgFHJUVyDzVHjsJjQZcsJj : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int xPNonwtofJgkSeFzfxtvfMLpsXBHA;

				private ControllerPollingInfo FdsfqdadlFQoUnkoAndMbwAisDzNB;

				private int hTIuSQdchXCQJEgXewySSjAbjmmDb;

				private IList<CustomController> rebJWzCFkeUmUtlDhEItygTYJJWjb;

				private int KCaFxFcZYBicziRgcUeytdhXMMrBb;

				private IEnumerator<ControllerPollingInfo> RaSAtWxlUeesLDLFXPoHecqDqMSq;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return FdsfqdadlFQoUnkoAndMbwAisDzNB;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return FdsfqdadlFQoUnkoAndMbwAisDzNB;
					}
				}

				[DebuggerHidden]
				public JzURznUgFHJUVyDzVHjsJjQZcsJj(int P_0)
				{
					xPNonwtofJgkSeFzfxtvfMLpsXBHA = P_0;
					hTIuSQdchXCQJEgXewySSjAbjmmDb = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = xPNonwtofJgkSeFzfxtvfMLpsXBHA;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							RQQAGzMxxnXgQYciJJzCzKZmvZtH();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = xPNonwtofJgkSeFzfxtvfMLpsXBHA;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							xPNonwtofJgkSeFzfxtvfMLpsXBHA = -3;
							goto IL_0086;
						}
						xPNonwtofJgkSeFzfxtvfMLpsXBHA = -1;
						rebJWzCFkeUmUtlDhEItygTYJJWjb = jCkgZLcnXoMycBxzcMXWvnUfSROEb.oEBCyTxQXibzLFYTdcadMQGimPZS();
						KCaFxFcZYBicziRgcUeytdhXMMrBb = 0;
						goto IL_00b0;
						IL_0086:
						if (RaSAtWxlUeesLDLFXPoHecqDqMSq.MoveNext())
						{
							ControllerPollingInfo current = RaSAtWxlUeesLDLFXPoHecqDqMSq.Current;
							FdsfqdadlFQoUnkoAndMbwAisDzNB = current;
							xPNonwtofJgkSeFzfxtvfMLpsXBHA = 1;
							return true;
						}
						RQQAGzMxxnXgQYciJJzCzKZmvZtH();
						RaSAtWxlUeesLDLFXPoHecqDqMSq = null;
						KCaFxFcZYBicziRgcUeytdhXMMrBb++;
						goto IL_00b0;
						IL_00b0:
						if (KCaFxFcZYBicziRgcUeytdhXMMrBb < rebJWzCFkeUmUtlDhEItygTYJJWjb.Count)
						{
							RaSAtWxlUeesLDLFXPoHecqDqMSq = rebJWzCFkeUmUtlDhEItygTYJJWjb[KCaFxFcZYBicziRgcUeytdhXMMrBb].PollForAllButtonsDown().GetEnumerator();
							xPNonwtofJgkSeFzfxtvfMLpsXBHA = -3;
							goto IL_0086;
						}
						return false;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void RQQAGzMxxnXgQYciJJzCzKZmvZtH()
				{
					xPNonwtofJgkSeFzfxtvfMLpsXBHA = -1;
					if (RaSAtWxlUeesLDLFXPoHecqDqMSq != null)
					{
						RaSAtWxlUeesLDLFXPoHecqDqMSq.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					if (xPNonwtofJgkSeFzfxtvfMLpsXBHA == -2 && hTIuSQdchXCQJEgXewySSjAbjmmDb == Environment.CurrentManagedThreadId)
					{
						xPNonwtofJgkSeFzfxtvfMLpsXBHA = 0;
						return this;
					}
					return new JzURznUgFHJUVyDzVHjsJjQZcsJj(0);
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class aINBxwOHPsGIYgVzIKJwcSbFqUjWB : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int yKXrUrTbFxDWxdVhzFKGefAeFNzKc;

				private ControllerPollingInfo ZvmMkCTgragPUPDsRTlUIfBofuoHA;

				private int NgnQLfuHmXQQeZUcfWKhagmTlatx;

				private IList<CustomController> IhUcQAJiVnjmAivfjNRRtGCaRHnN;

				private int fdscrXAbVfLfogBaqtyASUsFarcu;

				private IEnumerator<ControllerPollingInfo> jqpIMMAhIjiBokZENJEdKrcwIhsBA;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return ZvmMkCTgragPUPDsRTlUIfBofuoHA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ZvmMkCTgragPUPDsRTlUIfBofuoHA;
					}
				}

				[DebuggerHidden]
				public aINBxwOHPsGIYgVzIKJwcSbFqUjWB(int P_0)
				{
					yKXrUrTbFxDWxdVhzFKGefAeFNzKc = P_0;
					NgnQLfuHmXQQeZUcfWKhagmTlatx = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = yKXrUrTbFxDWxdVhzFKGefAeFNzKc;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							tiVlbZXmRXcgfbYuNkkFMRoGIXTA();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = yKXrUrTbFxDWxdVhzFKGefAeFNzKc;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							yKXrUrTbFxDWxdVhzFKGefAeFNzKc = -3;
							goto IL_0086;
						}
						yKXrUrTbFxDWxdVhzFKGefAeFNzKc = -1;
						IhUcQAJiVnjmAivfjNRRtGCaRHnN = jCkgZLcnXoMycBxzcMXWvnUfSROEb.oEBCyTxQXibzLFYTdcadMQGimPZS();
						fdscrXAbVfLfogBaqtyASUsFarcu = 0;
						goto IL_00b0;
						IL_0086:
						if (jqpIMMAhIjiBokZENJEdKrcwIhsBA.MoveNext())
						{
							ControllerPollingInfo current = jqpIMMAhIjiBokZENJEdKrcwIhsBA.Current;
							ZvmMkCTgragPUPDsRTlUIfBofuoHA = current;
							yKXrUrTbFxDWxdVhzFKGefAeFNzKc = 1;
							return true;
						}
						tiVlbZXmRXcgfbYuNkkFMRoGIXTA();
						jqpIMMAhIjiBokZENJEdKrcwIhsBA = null;
						fdscrXAbVfLfogBaqtyASUsFarcu++;
						goto IL_00b0;
						IL_00b0:
						if (fdscrXAbVfLfogBaqtyASUsFarcu < IhUcQAJiVnjmAivfjNRRtGCaRHnN.Count)
						{
							jqpIMMAhIjiBokZENJEdKrcwIhsBA = IhUcQAJiVnjmAivfjNRRtGCaRHnN[fdscrXAbVfLfogBaqtyASUsFarcu].PollForAllElements().GetEnumerator();
							yKXrUrTbFxDWxdVhzFKGefAeFNzKc = -3;
							goto IL_0086;
						}
						return false;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void tiVlbZXmRXcgfbYuNkkFMRoGIXTA()
				{
					yKXrUrTbFxDWxdVhzFKGefAeFNzKc = -1;
					if (jqpIMMAhIjiBokZENJEdKrcwIhsBA != null)
					{
						jqpIMMAhIjiBokZENJEdKrcwIhsBA.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					if (yKXrUrTbFxDWxdVhzFKGefAeFNzKc == -2 && NgnQLfuHmXQQeZUcfWKhagmTlatx == Environment.CurrentManagedThreadId)
					{
						yKXrUrTbFxDWxdVhzFKGefAeFNzKc = 0;
						return this;
					}
					return new aINBxwOHPsGIYgVzIKJwcSbFqUjWB(0);
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class COZVSuLaKqlenwiyMJBxFjgYPbpQ : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int cHKcdvoNrzIIYXNmRPLVgvudzGDd;

				private ControllerPollingInfo JQVzHEFoMcGoqbOFmBDVKjHdfgOj;

				private int OYcbkCsdpMzoxsvLBhelxLhASqNq;

				private IList<CustomController> TozCwGAqtwwKcuPFqqqfQJXLqHLnA;

				private int ZmYDdgzQsVONxkQIVGscLpIkIIKB;

				private IEnumerator<ControllerPollingInfo> uWWJVAVsDgpMvyfgEhVSaKzOGKyAb;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return JQVzHEFoMcGoqbOFmBDVKjHdfgOj;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return JQVzHEFoMcGoqbOFmBDVKjHdfgOj;
					}
				}

				[DebuggerHidden]
				public COZVSuLaKqlenwiyMJBxFjgYPbpQ(int P_0)
				{
					cHKcdvoNrzIIYXNmRPLVgvudzGDd = P_0;
					OYcbkCsdpMzoxsvLBhelxLhASqNq = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = cHKcdvoNrzIIYXNmRPLVgvudzGDd;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							uTMKMWkeOvepWPauHnSCVJxmDDJs();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = cHKcdvoNrzIIYXNmRPLVgvudzGDd;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							cHKcdvoNrzIIYXNmRPLVgvudzGDd = -3;
							goto IL_0086;
						}
						cHKcdvoNrzIIYXNmRPLVgvudzGDd = -1;
						TozCwGAqtwwKcuPFqqqfQJXLqHLnA = jCkgZLcnXoMycBxzcMXWvnUfSROEb.oEBCyTxQXibzLFYTdcadMQGimPZS();
						ZmYDdgzQsVONxkQIVGscLpIkIIKB = 0;
						goto IL_00b0;
						IL_0086:
						if (uWWJVAVsDgpMvyfgEhVSaKzOGKyAb.MoveNext())
						{
							ControllerPollingInfo current = uWWJVAVsDgpMvyfgEhVSaKzOGKyAb.Current;
							JQVzHEFoMcGoqbOFmBDVKjHdfgOj = current;
							cHKcdvoNrzIIYXNmRPLVgvudzGDd = 1;
							return true;
						}
						uTMKMWkeOvepWPauHnSCVJxmDDJs();
						uWWJVAVsDgpMvyfgEhVSaKzOGKyAb = null;
						ZmYDdgzQsVONxkQIVGscLpIkIIKB++;
						goto IL_00b0;
						IL_00b0:
						if (ZmYDdgzQsVONxkQIVGscLpIkIIKB < TozCwGAqtwwKcuPFqqqfQJXLqHLnA.Count)
						{
							uWWJVAVsDgpMvyfgEhVSaKzOGKyAb = TozCwGAqtwwKcuPFqqqfQJXLqHLnA[ZmYDdgzQsVONxkQIVGscLpIkIIKB].PollForAllElementsDown().GetEnumerator();
							cHKcdvoNrzIIYXNmRPLVgvudzGDd = -3;
							goto IL_0086;
						}
						return false;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void uTMKMWkeOvepWPauHnSCVJxmDDJs()
				{
					cHKcdvoNrzIIYXNmRPLVgvudzGDd = -1;
					if (uWWJVAVsDgpMvyfgEhVSaKzOGKyAb != null)
					{
						uWWJVAVsDgpMvyfgEhVSaKzOGKyAb.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					if (cHKcdvoNrzIIYXNmRPLVgvudzGDd == -2 && OYcbkCsdpMzoxsvLBhelxLhASqNq == Environment.CurrentManagedThreadId)
					{
						cHKcdvoNrzIIYXNmRPLVgvudzGDd = 0;
						return this;
					}
					return new COZVSuLaKqlenwiyMJBxFjgYPbpQ(0);
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class QTBfGCdJuEfGSZnkuszHrCYraoly : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int hFlLpKGjhkcGdgYWRnYbciUDFbHw;

				private ControllerPollingInfo enJbEWihYWXrakJWBfOkEoLzxvrh;

				private int uGbkSOWLiMXYMzPwJDBdQGXOcWer;

				private IList<Joystick> AkcREHWvtBpFQYNCwtsSxCMRuXEo;

				private int hveyxWTvaNMJpxAILWLIgFaRiguGA;

				private IEnumerator<ControllerPollingInfo> uEnLEUDlWhkkPSQIqsoIllEqSrjh;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return enJbEWihYWXrakJWBfOkEoLzxvrh;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return enJbEWihYWXrakJWBfOkEoLzxvrh;
					}
				}

				[DebuggerHidden]
				public QTBfGCdJuEfGSZnkuszHrCYraoly(int P_0)
				{
					hFlLpKGjhkcGdgYWRnYbciUDFbHw = P_0;
					uGbkSOWLiMXYMzPwJDBdQGXOcWer = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = hFlLpKGjhkcGdgYWRnYbciUDFbHw;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							rwmETxTuYDHxGAKywuNlowVvjYiK();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = hFlLpKGjhkcGdgYWRnYbciUDFbHw;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							hFlLpKGjhkcGdgYWRnYbciUDFbHw = -3;
							goto IL_0086;
						}
						hFlLpKGjhkcGdgYWRnYbciUDFbHw = -1;
						AkcREHWvtBpFQYNCwtsSxCMRuXEo = jCkgZLcnXoMycBxzcMXWvnUfSROEb.EEbcrLiEhnvUlDgBBWavPqjmOUJZA();
						hveyxWTvaNMJpxAILWLIgFaRiguGA = 0;
						goto IL_00b0;
						IL_0086:
						if (uEnLEUDlWhkkPSQIqsoIllEqSrjh.MoveNext())
						{
							ControllerPollingInfo current = uEnLEUDlWhkkPSQIqsoIllEqSrjh.Current;
							enJbEWihYWXrakJWBfOkEoLzxvrh = current;
							hFlLpKGjhkcGdgYWRnYbciUDFbHw = 1;
							return true;
						}
						rwmETxTuYDHxGAKywuNlowVvjYiK();
						uEnLEUDlWhkkPSQIqsoIllEqSrjh = null;
						hveyxWTvaNMJpxAILWLIgFaRiguGA++;
						goto IL_00b0;
						IL_00b0:
						if (hveyxWTvaNMJpxAILWLIgFaRiguGA < AkcREHWvtBpFQYNCwtsSxCMRuXEo.Count)
						{
							uEnLEUDlWhkkPSQIqsoIllEqSrjh = AkcREHWvtBpFQYNCwtsSxCMRuXEo[hveyxWTvaNMJpxAILWLIgFaRiguGA].PollForAllAxes().GetEnumerator();
							hFlLpKGjhkcGdgYWRnYbciUDFbHw = -3;
							goto IL_0086;
						}
						return false;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void rwmETxTuYDHxGAKywuNlowVvjYiK()
				{
					hFlLpKGjhkcGdgYWRnYbciUDFbHw = -1;
					if (uEnLEUDlWhkkPSQIqsoIllEqSrjh != null)
					{
						uEnLEUDlWhkkPSQIqsoIllEqSrjh.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					if (hFlLpKGjhkcGdgYWRnYbciUDFbHw == -2 && uGbkSOWLiMXYMzPwJDBdQGXOcWer == Environment.CurrentManagedThreadId)
					{
						hFlLpKGjhkcGdgYWRnYbciUDFbHw = 0;
						return this;
					}
					return new QTBfGCdJuEfGSZnkuszHrCYraoly(0);
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class sdzJhGVwouTGZUimMPhjQUBZHsdA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int RdTLtYbdTumzaTbSPHgcsRiSdjpF;

				private ControllerPollingInfo VffyqncYSetZaNidycnHEniaGOUm;

				private int CYHyLCTKhlGbElGwaHLgughvOxds;

				private IList<Joystick> sRqyNfzEAFJBMXIZherOXnuQUoeW;

				private int BwvGdfHgsjGLucPmSJBbLYVPaDvXA;

				private IEnumerator<ControllerPollingInfo> PGSXFYMLBMmKEPOZAjLfbdhatFSq;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return VffyqncYSetZaNidycnHEniaGOUm;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return VffyqncYSetZaNidycnHEniaGOUm;
					}
				}

				[DebuggerHidden]
				public sdzJhGVwouTGZUimMPhjQUBZHsdA(int P_0)
				{
					RdTLtYbdTumzaTbSPHgcsRiSdjpF = P_0;
					CYHyLCTKhlGbElGwaHLgughvOxds = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int rdTLtYbdTumzaTbSPHgcsRiSdjpF = RdTLtYbdTumzaTbSPHgcsRiSdjpF;
					if (rdTLtYbdTumzaTbSPHgcsRiSdjpF == -3 || rdTLtYbdTumzaTbSPHgcsRiSdjpF == 1)
					{
						try
						{
						}
						finally
						{
							MXeUTmSiPyhhMFPNPtiYiqjvhsDDb();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int rdTLtYbdTumzaTbSPHgcsRiSdjpF = RdTLtYbdTumzaTbSPHgcsRiSdjpF;
						if (rdTLtYbdTumzaTbSPHgcsRiSdjpF != 0)
						{
							if (rdTLtYbdTumzaTbSPHgcsRiSdjpF != 1)
							{
								return false;
							}
							RdTLtYbdTumzaTbSPHgcsRiSdjpF = -3;
							goto IL_0086;
						}
						RdTLtYbdTumzaTbSPHgcsRiSdjpF = -1;
						sRqyNfzEAFJBMXIZherOXnuQUoeW = jCkgZLcnXoMycBxzcMXWvnUfSROEb.EEbcrLiEhnvUlDgBBWavPqjmOUJZA();
						BwvGdfHgsjGLucPmSJBbLYVPaDvXA = 0;
						goto IL_00b0;
						IL_0086:
						if (PGSXFYMLBMmKEPOZAjLfbdhatFSq.MoveNext())
						{
							ControllerPollingInfo current = PGSXFYMLBMmKEPOZAjLfbdhatFSq.Current;
							VffyqncYSetZaNidycnHEniaGOUm = current;
							RdTLtYbdTumzaTbSPHgcsRiSdjpF = 1;
							return true;
						}
						MXeUTmSiPyhhMFPNPtiYiqjvhsDDb();
						PGSXFYMLBMmKEPOZAjLfbdhatFSq = null;
						BwvGdfHgsjGLucPmSJBbLYVPaDvXA++;
						goto IL_00b0;
						IL_00b0:
						if (BwvGdfHgsjGLucPmSJBbLYVPaDvXA < sRqyNfzEAFJBMXIZherOXnuQUoeW.Count)
						{
							PGSXFYMLBMmKEPOZAjLfbdhatFSq = sRqyNfzEAFJBMXIZherOXnuQUoeW[BwvGdfHgsjGLucPmSJBbLYVPaDvXA].PollForAllButtons().GetEnumerator();
							RdTLtYbdTumzaTbSPHgcsRiSdjpF = -3;
							goto IL_0086;
						}
						return false;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void MXeUTmSiPyhhMFPNPtiYiqjvhsDDb()
				{
					RdTLtYbdTumzaTbSPHgcsRiSdjpF = -1;
					if (PGSXFYMLBMmKEPOZAjLfbdhatFSq != null)
					{
						PGSXFYMLBMmKEPOZAjLfbdhatFSq.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					if (RdTLtYbdTumzaTbSPHgcsRiSdjpF == -2 && CYHyLCTKhlGbElGwaHLgughvOxds == Environment.CurrentManagedThreadId)
					{
						RdTLtYbdTumzaTbSPHgcsRiSdjpF = 0;
						return this;
					}
					return new sdzJhGVwouTGZUimMPhjQUBZHsdA(0);
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class DllrTydnJeatRFChtsTXpCYHbvsB : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int JWnEAYGnzdCkVBtmioRWWiVxevuqA;

				private ControllerPollingInfo NdXjNSOpwQkEAdHMqrMYKiIwzFwc;

				private int dtxyYlkDZIyjOVOGcakAVIFdEBnaA;

				private IList<Joystick> txVYtmTlFLcEmVNaZFDxCLmmpZnW;

				private int RVOBwIBFKIGbGCKvJgAuUyAhjbrrb;

				private IEnumerator<ControllerPollingInfo> KKSgOXylKBEgKuGStzxARResQCPu;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return NdXjNSOpwQkEAdHMqrMYKiIwzFwc;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return NdXjNSOpwQkEAdHMqrMYKiIwzFwc;
					}
				}

				[DebuggerHidden]
				public DllrTydnJeatRFChtsTXpCYHbvsB(int P_0)
				{
					JWnEAYGnzdCkVBtmioRWWiVxevuqA = P_0;
					dtxyYlkDZIyjOVOGcakAVIFdEBnaA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int jWnEAYGnzdCkVBtmioRWWiVxevuqA = JWnEAYGnzdCkVBtmioRWWiVxevuqA;
					if (jWnEAYGnzdCkVBtmioRWWiVxevuqA == -3 || jWnEAYGnzdCkVBtmioRWWiVxevuqA == 1)
					{
						try
						{
						}
						finally
						{
							IOavbdTiQoFYWMXYchHaBFqzISDfA();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int jWnEAYGnzdCkVBtmioRWWiVxevuqA = JWnEAYGnzdCkVBtmioRWWiVxevuqA;
						if (jWnEAYGnzdCkVBtmioRWWiVxevuqA != 0)
						{
							if (jWnEAYGnzdCkVBtmioRWWiVxevuqA != 1)
							{
								return false;
							}
							JWnEAYGnzdCkVBtmioRWWiVxevuqA = -3;
							goto IL_0086;
						}
						JWnEAYGnzdCkVBtmioRWWiVxevuqA = -1;
						txVYtmTlFLcEmVNaZFDxCLmmpZnW = jCkgZLcnXoMycBxzcMXWvnUfSROEb.EEbcrLiEhnvUlDgBBWavPqjmOUJZA();
						RVOBwIBFKIGbGCKvJgAuUyAhjbrrb = 0;
						goto IL_00b0;
						IL_0086:
						if (KKSgOXylKBEgKuGStzxARResQCPu.MoveNext())
						{
							ControllerPollingInfo current = KKSgOXylKBEgKuGStzxARResQCPu.Current;
							NdXjNSOpwQkEAdHMqrMYKiIwzFwc = current;
							JWnEAYGnzdCkVBtmioRWWiVxevuqA = 1;
							return true;
						}
						IOavbdTiQoFYWMXYchHaBFqzISDfA();
						KKSgOXylKBEgKuGStzxARResQCPu = null;
						RVOBwIBFKIGbGCKvJgAuUyAhjbrrb++;
						goto IL_00b0;
						IL_00b0:
						if (RVOBwIBFKIGbGCKvJgAuUyAhjbrrb < txVYtmTlFLcEmVNaZFDxCLmmpZnW.Count)
						{
							KKSgOXylKBEgKuGStzxARResQCPu = txVYtmTlFLcEmVNaZFDxCLmmpZnW[RVOBwIBFKIGbGCKvJgAuUyAhjbrrb].PollForAllButtonsDown().GetEnumerator();
							JWnEAYGnzdCkVBtmioRWWiVxevuqA = -3;
							goto IL_0086;
						}
						return false;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void IOavbdTiQoFYWMXYchHaBFqzISDfA()
				{
					JWnEAYGnzdCkVBtmioRWWiVxevuqA = -1;
					if (KKSgOXylKBEgKuGStzxARResQCPu != null)
					{
						KKSgOXylKBEgKuGStzxARResQCPu.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					if (JWnEAYGnzdCkVBtmioRWWiVxevuqA == -2 && dtxyYlkDZIyjOVOGcakAVIFdEBnaA == Environment.CurrentManagedThreadId)
					{
						JWnEAYGnzdCkVBtmioRWWiVxevuqA = 0;
						return this;
					}
					return new DllrTydnJeatRFChtsTXpCYHbvsB(0);
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class tfxQawIahCDYtAJYgPoPcPJaKoJdb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int krSTgCYQSzOXLaZMikimGnejDxGJ;

				private ControllerPollingInfo oCCaxlBtpJgwrBNXkniWTzePctAFc;

				private int GJfAZSirbnYYzwPxVccbNhGRqAeB;

				private IList<Joystick> GZpbeHNDUEVDvdrekOsyodhWqUul;

				private int qrwSppageQPPbcyaCRofeZaSAQFC;

				private IEnumerator<ControllerPollingInfo> MOkGbktOldfxPlASqzERkTtqQccd;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return oCCaxlBtpJgwrBNXkniWTzePctAFc;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return oCCaxlBtpJgwrBNXkniWTzePctAFc;
					}
				}

				[DebuggerHidden]
				public tfxQawIahCDYtAJYgPoPcPJaKoJdb(int P_0)
				{
					krSTgCYQSzOXLaZMikimGnejDxGJ = P_0;
					GJfAZSirbnYYzwPxVccbNhGRqAeB = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = krSTgCYQSzOXLaZMikimGnejDxGJ;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							OIncINKtcmRqxggfbmQWVyxaaACYb();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = krSTgCYQSzOXLaZMikimGnejDxGJ;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							krSTgCYQSzOXLaZMikimGnejDxGJ = -3;
							goto IL_0086;
						}
						krSTgCYQSzOXLaZMikimGnejDxGJ = -1;
						GZpbeHNDUEVDvdrekOsyodhWqUul = jCkgZLcnXoMycBxzcMXWvnUfSROEb.EEbcrLiEhnvUlDgBBWavPqjmOUJZA();
						qrwSppageQPPbcyaCRofeZaSAQFC = 0;
						goto IL_00b0;
						IL_0086:
						if (MOkGbktOldfxPlASqzERkTtqQccd.MoveNext())
						{
							ControllerPollingInfo current = MOkGbktOldfxPlASqzERkTtqQccd.Current;
							oCCaxlBtpJgwrBNXkniWTzePctAFc = current;
							krSTgCYQSzOXLaZMikimGnejDxGJ = 1;
							return true;
						}
						OIncINKtcmRqxggfbmQWVyxaaACYb();
						MOkGbktOldfxPlASqzERkTtqQccd = null;
						qrwSppageQPPbcyaCRofeZaSAQFC++;
						goto IL_00b0;
						IL_00b0:
						if (qrwSppageQPPbcyaCRofeZaSAQFC < GZpbeHNDUEVDvdrekOsyodhWqUul.Count)
						{
							MOkGbktOldfxPlASqzERkTtqQccd = GZpbeHNDUEVDvdrekOsyodhWqUul[qrwSppageQPPbcyaCRofeZaSAQFC].PollForAllElements().GetEnumerator();
							krSTgCYQSzOXLaZMikimGnejDxGJ = -3;
							goto IL_0086;
						}
						return false;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void OIncINKtcmRqxggfbmQWVyxaaACYb()
				{
					krSTgCYQSzOXLaZMikimGnejDxGJ = -1;
					if (MOkGbktOldfxPlASqzERkTtqQccd != null)
					{
						MOkGbktOldfxPlASqzERkTtqQccd.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					if (krSTgCYQSzOXLaZMikimGnejDxGJ == -2 && GJfAZSirbnYYzwPxVccbNhGRqAeB == Environment.CurrentManagedThreadId)
					{
						krSTgCYQSzOXLaZMikimGnejDxGJ = 0;
						return this;
					}
					return new tfxQawIahCDYtAJYgPoPcPJaKoJdb(0);
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class bsuaRuunmqoSTGGoFRyuJCezCFUP : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int yKzYULlhNIAWogIbrVptJlsSDIteb;

				private ControllerPollingInfo fVAPGHgVUoNFctCIMGamtBJgYfJG;

				private int wftFVJFaDMXXvwPQTczVnKMlkgiP;

				private IList<Joystick> fcuXcPXxbGnNtDcOjuSQGTncYSF;

				private int xeEeKxUlnaFRDlRLXDssrgvaRBBq;

				private IEnumerator<ControllerPollingInfo> VhoRiEyjbHbVhJhKzUMCJnBCgpuH;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return fVAPGHgVUoNFctCIMGamtBJgYfJG;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return fVAPGHgVUoNFctCIMGamtBJgYfJG;
					}
				}

				[DebuggerHidden]
				public bsuaRuunmqoSTGGoFRyuJCezCFUP(int P_0)
				{
					yKzYULlhNIAWogIbrVptJlsSDIteb = P_0;
					wftFVJFaDMXXvwPQTczVnKMlkgiP = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = yKzYULlhNIAWogIbrVptJlsSDIteb;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							RxeRuPgGicEQYBWHTmEouoQjGxhZA();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = yKzYULlhNIAWogIbrVptJlsSDIteb;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							yKzYULlhNIAWogIbrVptJlsSDIteb = -3;
							goto IL_0086;
						}
						yKzYULlhNIAWogIbrVptJlsSDIteb = -1;
						fcuXcPXxbGnNtDcOjuSQGTncYSF = jCkgZLcnXoMycBxzcMXWvnUfSROEb.EEbcrLiEhnvUlDgBBWavPqjmOUJZA();
						xeEeKxUlnaFRDlRLXDssrgvaRBBq = 0;
						goto IL_00b0;
						IL_0086:
						if (VhoRiEyjbHbVhJhKzUMCJnBCgpuH.MoveNext())
						{
							ControllerPollingInfo current = VhoRiEyjbHbVhJhKzUMCJnBCgpuH.Current;
							fVAPGHgVUoNFctCIMGamtBJgYfJG = current;
							yKzYULlhNIAWogIbrVptJlsSDIteb = 1;
							return true;
						}
						RxeRuPgGicEQYBWHTmEouoQjGxhZA();
						VhoRiEyjbHbVhJhKzUMCJnBCgpuH = null;
						xeEeKxUlnaFRDlRLXDssrgvaRBBq++;
						goto IL_00b0;
						IL_00b0:
						if (xeEeKxUlnaFRDlRLXDssrgvaRBBq < fcuXcPXxbGnNtDcOjuSQGTncYSF.Count)
						{
							VhoRiEyjbHbVhJhKzUMCJnBCgpuH = fcuXcPXxbGnNtDcOjuSQGTncYSF[xeEeKxUlnaFRDlRLXDssrgvaRBBq].PollForAllElementsDown().GetEnumerator();
							yKzYULlhNIAWogIbrVptJlsSDIteb = -3;
							goto IL_0086;
						}
						return false;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void RxeRuPgGicEQYBWHTmEouoQjGxhZA()
				{
					yKzYULlhNIAWogIbrVptJlsSDIteb = -1;
					if (VhoRiEyjbHbVhJhKzUMCJnBCgpuH != null)
					{
						VhoRiEyjbHbVhJhKzUMCJnBCgpuH.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					if (yKzYULlhNIAWogIbrVptJlsSDIteb == -2 && wftFVJFaDMXXvwPQTczVnKMlkgiP == Environment.CurrentManagedThreadId)
					{
						yKzYULlhNIAWogIbrVptJlsSDIteb = 0;
						return this;
					}
					return new bsuaRuunmqoSTGGoFRyuJCezCFUP(0);
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private static PollingHelper XWXgYdUpIxuZKzJLiGzxChqZIZgu;

			internal static PollingHelper YbdXuhNPPwvXPNFCeGSrzgCQRMqI => RqkmUHqbtpXCFYtcefaNLeCLmHDX();

			internal static PollingHelper RqkmUHqbtpXCFYtcefaNLeCLmHDX()
			{
				return XWXgYdUpIxuZKzJLiGzxChqZIZgu ?? (XWXgYdUpIxuZKzJLiGzxChqZIZgu = new PollingHelper());
			}

			private PollingHelper()
			{
			}

			public ControllerPollingInfo PollAllControllersForFirstElement()
			{
				if (!CheckInitialized())
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				ControllerPollingInfo result = kNJQyofVKOuVoHyDaJFFMycTxaDE();
				if (result.success)
				{
					return result;
				}
				result = CSrfgJviKfzCDIQFeHruauwyNvMNA();
				if (result.success)
				{
					return result;
				}
				result = OzMPyeBwSGNkYrKlkzVJVVpljakL();
				if (result.success)
				{
					return result;
				}
				result = VOkwKznQgAUuCQBAZdsCKEOIAOJv();
				if (result.success)
				{
					return result;
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			public ControllerPollingInfo PollAllControllersForFirstElementDown()
			{
				if (!CheckInitialized())
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				ControllerPollingInfo result = AuSJrxMcjoajLWejlbxoyhOwtsum();
				if (result.success)
				{
					return result;
				}
				result = cmcWdhMLsWaZMoRqRPbBpUBiCLfp();
				if (result.success)
				{
					return result;
				}
				result = SPCeAuRxmVulfHRBKCithLlTaNeab();
				if (result.success)
				{
					return result;
				}
				result = DiIisNOssxMlXSAzRYlkINtfnxyk();
				if (result.success)
				{
					return result;
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			public ControllerPollingInfo PollAllControllersForFirstButton()
			{
				if (!CheckInitialized())
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				ControllerPollingInfo result = pJHvaNjySMPLmcjuBdVtQgWxupRR();
				if (result.success)
				{
					return result;
				}
				result = CSrfgJviKfzCDIQFeHruauwyNvMNA();
				if (result.success)
				{
					return result;
				}
				result = vpAvWcbOnIVuUJDdraJMINyGKbctA();
				if (result.success)
				{
					return result;
				}
				result = ABivDgTbhTPgwzPhSANXyCbVOVjw();
				if (result.success)
				{
					return result;
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			public ControllerPollingInfo PollAllControllersForFirstButtonDown()
			{
				if (!CheckInitialized())
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				ControllerPollingInfo result = EGUEoGkPVAEbrEqxkhUXVHaPHxWpc();
				if (result.success)
				{
					return result;
				}
				result = cmcWdhMLsWaZMoRqRPbBpUBiCLfp();
				if (result.success)
				{
					return result;
				}
				result = EeJChIAtEJvCHTchUFgLeEpkmEex();
				if (result.success)
				{
					return result;
				}
				result = idLEcHkZLeTRiQJBZUPwpMnvapMJA();
				if (result.success)
				{
					return result;
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			public ControllerPollingInfo PollAllControllersForFirstAxis()
			{
				if (!CheckInitialized())
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				ControllerPollingInfo result = VDWFrurhhIsaepqNaIuILVlCStUU();
				if (result.success)
				{
					return result;
				}
				result = ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				if (result.success)
				{
					return result;
				}
				result = wqPQQYsBSOrndnatwqKvELFpAcxCA();
				if (result.success)
				{
					return result;
				}
				result = AnccqOKOGVJvZgQbxHMmgTjRIzRBb();
				if (result.success)
				{
					return result;
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return controllerType switch
				{
					ControllerType.Joystick => kNJQyofVKOuVoHyDaJFFMycTxaDE(), 
					ControllerType.Keyboard => CSrfgJviKfzCDIQFeHruauwyNvMNA(), 
					ControllerType.Mouse => OzMPyeBwSGNkYrKlkzVJVVpljakL(), 
					ControllerType.Custom => VOkwKznQgAUuCQBAZdsCKEOIAOJv(), 
					_ => throw new NotImplementedException(), 
				};
			}

			public ControllerPollingInfo PollAllControllersOfTypeForFirstElementDown(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return controllerType switch
				{
					ControllerType.Joystick => AuSJrxMcjoajLWejlbxoyhOwtsum(), 
					ControllerType.Keyboard => cmcWdhMLsWaZMoRqRPbBpUBiCLfp(), 
					ControllerType.Mouse => SPCeAuRxmVulfHRBKCithLlTaNeab(), 
					ControllerType.Custom => DiIisNOssxMlXSAzRYlkINtfnxyk(), 
					_ => throw new NotImplementedException(), 
				};
			}

			public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return controllerType switch
				{
					ControllerType.Joystick => pJHvaNjySMPLmcjuBdVtQgWxupRR(), 
					ControllerType.Keyboard => CSrfgJviKfzCDIQFeHruauwyNvMNA(), 
					ControllerType.Mouse => vpAvWcbOnIVuUJDdraJMINyGKbctA(), 
					ControllerType.Custom => ABivDgTbhTPgwzPhSANXyCbVOVjw(), 
					_ => throw new NotImplementedException(), 
				};
			}

			public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return controllerType switch
				{
					ControllerType.Joystick => EGUEoGkPVAEbrEqxkhUXVHaPHxWpc(), 
					ControllerType.Keyboard => cmcWdhMLsWaZMoRqRPbBpUBiCLfp(), 
					ControllerType.Mouse => EeJChIAtEJvCHTchUFgLeEpkmEex(), 
					ControllerType.Custom => idLEcHkZLeTRiQJBZUPwpMnvapMJA(), 
					_ => throw new NotImplementedException(), 
				};
			}

			public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return controllerType switch
				{
					ControllerType.Joystick => VDWFrurhhIsaepqNaIuILVlCStUU(), 
					ControllerType.Keyboard => ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA(), 
					ControllerType.Mouse => wqPQQYsBSOrndnatwqKvELFpAcxCA(), 
					ControllerType.Custom => AnccqOKOGVJvZgQbxHMmgTjRIzRBb(), 
					_ => throw new NotImplementedException(), 
				};
			}

			public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return controllerType switch
				{
					ControllerType.Joystick => mLuCicHyeUCeViTOgqhqYXkqJogHA(controllerId), 
					ControllerType.Keyboard => CSrfgJviKfzCDIQFeHruauwyNvMNA(), 
					ControllerType.Mouse => OzMPyeBwSGNkYrKlkzVJVVpljakL(), 
					ControllerType.Custom => HSmbfPTNfpeCVbjGuHcDpwHYLNAz(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return controllerType switch
				{
					ControllerType.Joystick => lejiQsdcfhJTaBJmbZrEjYaRjlXeb(controllerId), 
					ControllerType.Keyboard => cmcWdhMLsWaZMoRqRPbBpUBiCLfp(), 
					ControllerType.Mouse => SPCeAuRxmVulfHRBKCithLlTaNeab(), 
					ControllerType.Custom => NgMADpjFIgTsNmhRrWUNKpJPJQkvA(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return controllerType switch
				{
					ControllerType.Joystick => GkSYvVcpWgwijtLsRnSfZAylHVjr(controllerId), 
					ControllerType.Keyboard => CSrfgJviKfzCDIQFeHruauwyNvMNA(), 
					ControllerType.Mouse => vpAvWcbOnIVuUJDdraJMINyGKbctA(), 
					ControllerType.Custom => tbElKjVooxrBwVDBOcbKUDVYbJqgA(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return controllerType switch
				{
					ControllerType.Joystick => ocSIHwWImkxpxqmlTEmpbIvOMzkkA(controllerId), 
					ControllerType.Keyboard => cmcWdhMLsWaZMoRqRPbBpUBiCLfp(), 
					ControllerType.Mouse => EeJChIAtEJvCHTchUFgLeEpkmEex(), 
					ControllerType.Custom => phDWViiqVnsZIFMPeFgpWbYEYLSt(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return controllerType switch
				{
					ControllerType.Joystick => qqGcHsjQdbJCbCiJRkPeJcZizpaSA(controllerId), 
					ControllerType.Keyboard => ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA(), 
					ControllerType.Mouse => wqPQQYsBSOrndnatwqKvELFpAcxCA(), 
					ControllerType.Custom => wuvaBfZPFomplXqIbGLoknQWrvZe(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			[IteratorStateMachine(typeof(EzyIOEISichcTznwHOoQuCLlOcQb))]
			public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElements()
			{
				return new EzyIOEISichcTznwHOoQuCLlOcQb(-2)
				{
					MkjmDlCPPagUVhWMdhDMJZivZBBr = this
				};
			}

			[IteratorStateMachine(typeof(eHvBcMEOTJhHHtHBbwweUNNvlGrtA))]
			public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElementsDown()
			{
				return new eHvBcMEOTJhHHtHBbwweUNNvlGrtA(-2)
				{
					tpOfpUhEfjDrUeAPtmazKUSEoACFb = this
				};
			}

			[IteratorStateMachine(typeof(RyWIjsXgRaSWaPnvCfHKIUHkdicW))]
			public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtons()
			{
				return new RyWIjsXgRaSWaPnvCfHKIUHkdicW(-2)
				{
					CyAZlrHrqHFoLfjAXYHDVJmyejYr = this
				};
			}

			[IteratorStateMachine(typeof(JMneRkLLjfBndaEDQEqFyoUlTstqA))]
			public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtonsDown()
			{
				return new JMneRkLLjfBndaEDQEqFyoUlTstqA(-2)
				{
					oUvhteKwgJYBliKjguzWLNgPqgmg = this
				};
			}

			[IteratorStateMachine(typeof(bKdFmhDsAxmvTDfOJhsXOCxxrDREA))]
			public IEnumerable<ControllerPollingInfo> PollAllControllersForAllAxes()
			{
				return new bKdFmhDsAxmvTDfOJhsXOCxxrDREA(-2)
				{
					PKsgzonBoXleQMvIeWtATYztxgfJ = this
				};
			}

			public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return controllerType switch
				{
					ControllerType.Joystick => gmtDZcAtmfGKKWYdHAMOwKvZWVsh(controllerId), 
					ControllerType.Keyboard => ozmBDRdYzWLUwQfyfACLhkxCDgRyb(), 
					ControllerType.Mouse => goGRwcaxYPqlGSYNxoaUMusfzfWA(), 
					ControllerType.Custom => WhCKGrJOUkgMgxNxyTztBEfImONS(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public IEnumerable<ControllerPollingInfo> PollControllerForAllElementsDown(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return controllerType switch
				{
					ControllerType.Joystick => YdQlByQtfZHSfhSOHxcySGsZfxNgA(controllerId), 
					ControllerType.Keyboard => RJJCFfURfKgJyzPAzKEvHvoljyxC(), 
					ControllerType.Mouse => cFeVzjWyLkCGYMlgciPFuippbBOw(), 
					ControllerType.Custom => jFExbvfzplMSrUqFbgIPzKPItVJw(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public IEnumerable<ControllerPollingInfo> PollControllerForAllButtons(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return controllerType switch
				{
					ControllerType.Joystick => qkbflDGcjeELbaDFGMBlIIBBUuQGB(controllerId), 
					ControllerType.Keyboard => ozmBDRdYzWLUwQfyfACLhkxCDgRyb(), 
					ControllerType.Mouse => AIyPZoXHBYlsFHLJnYngVzyxkAxv(), 
					ControllerType.Custom => cOuSaapfMYPnLZnLzKRaIrDGmYoL(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public IEnumerable<ControllerPollingInfo> PollControllerForAllButtonsDown(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return controllerType switch
				{
					ControllerType.Joystick => yjyRUXxgBxhJHFiAOwpmilMOEFeoA(controllerId), 
					ControllerType.Keyboard => RJJCFfURfKgJyzPAzKEvHvoljyxC(), 
					ControllerType.Mouse => imfRmVEeiZfoYJLcvzMIQSTjIYwcb(), 
					ControllerType.Custom => aCjeXAUOufBcZIiLxoPosPeQSCcvA(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public IEnumerable<ControllerPollingInfo> PollControllerForAllAxes(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return controllerType switch
				{
					ControllerType.Joystick => kRyIAtjIjppkuxKxQmsNJIYVUBLv(controllerId), 
					ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
					ControllerType.Mouse => bNVbbwAewWvgbaxnriWIqtHAMFSE(), 
					ControllerType.Custom => fsmPfpDVRvDZehPJvRrbiHLUWuDb(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			private ControllerPollingInfo kNJQyofVKOuVoHyDaJFFMycTxaDE()
			{
				IList<Joystick> list = jCkgZLcnXoMycBxzcMXWvnUfSROEb.EEbcrLiEhnvUlDgBBWavPqjmOUJZA();
				for (int i = 0; i < list.Count; i++)
				{
					ControllerPollingInfo result = list[i].PollForFirstElement();
					if (result.success)
					{
						return result;
					}
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo AuSJrxMcjoajLWejlbxoyhOwtsum()
			{
				IList<Joystick> list = jCkgZLcnXoMycBxzcMXWvnUfSROEb.EEbcrLiEhnvUlDgBBWavPqjmOUJZA();
				for (int i = 0; i < list.Count; i++)
				{
					ControllerPollingInfo result = list[i].PollForFirstElementDown();
					if (result.success)
					{
						return result;
					}
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo pJHvaNjySMPLmcjuBdVtQgWxupRR()
			{
				IList<Joystick> list = jCkgZLcnXoMycBxzcMXWvnUfSROEb.EEbcrLiEhnvUlDgBBWavPqjmOUJZA();
				for (int i = 0; i < list.Count; i++)
				{
					ControllerPollingInfo result = list[i].PollForFirstButton();
					if (result.success)
					{
						return result;
					}
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo EGUEoGkPVAEbrEqxkhUXVHaPHxWpc()
			{
				IList<Joystick> list = jCkgZLcnXoMycBxzcMXWvnUfSROEb.EEbcrLiEhnvUlDgBBWavPqjmOUJZA();
				for (int i = 0; i < list.Count; i++)
				{
					ControllerPollingInfo result = list[i].PollForFirstButtonDown();
					if (result.success)
					{
						return result;
					}
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo VDWFrurhhIsaepqNaIuILVlCStUU()
			{
				IList<Joystick> list = jCkgZLcnXoMycBxzcMXWvnUfSROEb.EEbcrLiEhnvUlDgBBWavPqjmOUJZA();
				for (int i = 0; i < list.Count; i++)
				{
					ControllerPollingInfo result = list[i].PollForFirstAxis();
					if (result.success)
					{
						return result;
					}
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo mLuCicHyeUCeViTOgqhqYXkqJogHA(int P_0)
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().GetJoystick(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo lejiQsdcfhJTaBJmbZrEjYaRjlXeb(int P_0)
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().GetJoystick(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo GkSYvVcpWgwijtLsRnSfZAylHVjr(int P_0)
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().GetJoystick(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo ocSIHwWImkxpxqmlTEmpbIvOMzkkA(int P_0)
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().GetJoystick(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo qqGcHsjQdbJCbCiJRkPeJcZizpaSA(int P_0)
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().GetJoystick(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo CSrfgJviKfzCDIQFeHruauwyNvMNA()
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().Keyboard.PollForFirstKey();
			}

			private ControllerPollingInfo cmcWdhMLsWaZMoRqRPbBpUBiCLfp()
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().Keyboard.PollForFirstKeyDown();
			}

			private ControllerPollingInfo OzMPyeBwSGNkYrKlkzVJVVpljakL()
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().Mouse.PollForFirstElement();
			}

			private ControllerPollingInfo SPCeAuRxmVulfHRBKCithLlTaNeab()
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().Mouse.PollForFirstElementDown();
			}

			private ControllerPollingInfo vpAvWcbOnIVuUJDdraJMINyGKbctA()
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().Mouse.PollForFirstButton();
			}

			private ControllerPollingInfo EeJChIAtEJvCHTchUFgLeEpkmEex()
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().Mouse.PollForFirstButtonDown();
			}

			private ControllerPollingInfo wqPQQYsBSOrndnatwqKvELFpAcxCA()
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().Mouse.PollForFirstAxis();
			}

			private ControllerPollingInfo VOkwKznQgAUuCQBAZdsCKEOIAOJv()
			{
				IList<CustomController> list = jCkgZLcnXoMycBxzcMXWvnUfSROEb.oEBCyTxQXibzLFYTdcadMQGimPZS();
				for (int i = 0; i < list.Count; i++)
				{
					ControllerPollingInfo result = list[i].PollForFirstElement();
					if (result.success)
					{
						return result;
					}
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo DiIisNOssxMlXSAzRYlkINtfnxyk()
			{
				IList<CustomController> list = jCkgZLcnXoMycBxzcMXWvnUfSROEb.oEBCyTxQXibzLFYTdcadMQGimPZS();
				for (int i = 0; i < list.Count; i++)
				{
					ControllerPollingInfo result = list[i].PollForFirstElementDown();
					if (result.success)
					{
						return result;
					}
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo ABivDgTbhTPgwzPhSANXyCbVOVjw()
			{
				IList<CustomController> list = jCkgZLcnXoMycBxzcMXWvnUfSROEb.oEBCyTxQXibzLFYTdcadMQGimPZS();
				for (int i = 0; i < list.Count; i++)
				{
					ControllerPollingInfo result = list[i].PollForFirstButton();
					if (result.success)
					{
						return result;
					}
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo idLEcHkZLeTRiQJBZUPwpMnvapMJA()
			{
				IList<CustomController> list = jCkgZLcnXoMycBxzcMXWvnUfSROEb.oEBCyTxQXibzLFYTdcadMQGimPZS();
				for (int i = 0; i < list.Count; i++)
				{
					ControllerPollingInfo result = list[i].PollForFirstButtonDown();
					if (result.success)
					{
						return result;
					}
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo AnccqOKOGVJvZgQbxHMmgTjRIzRBb()
			{
				IList<CustomController> list = jCkgZLcnXoMycBxzcMXWvnUfSROEb.oEBCyTxQXibzLFYTdcadMQGimPZS();
				for (int i = 0; i < list.Count; i++)
				{
					ControllerPollingInfo result = list[i].PollForFirstAxis();
					if (result.success)
					{
						return result;
					}
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo HSmbfPTNfpeCVbjGuHcDpwHYLNAz(int P_0)
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().GetCustomController(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo NgMADpjFIgTsNmhRrWUNKpJPJQkvA(int P_0)
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().GetCustomController(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo tbElKjVooxrBwVDBOcbKUDVYbJqgA(int P_0)
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().GetCustomController(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo phDWViiqVnsZIFMPeFgpWbYEYLSt(int P_0)
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().GetCustomController(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo wuvaBfZPFomplXqIbGLoknQWrvZe(int P_0)
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().GetCustomController(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			[IteratorStateMachine(typeof(tfxQawIahCDYtAJYgPoPcPJaKoJdb))]
			private IEnumerable<ControllerPollingInfo> KfmbhKIUQvEnDdAcdUrkeAekbQsmB()
			{
				return new tfxQawIahCDYtAJYgPoPcPJaKoJdb(-2);
			}

			[IteratorStateMachine(typeof(bsuaRuunmqoSTGGoFRyuJCezCFUP))]
			private IEnumerable<ControllerPollingInfo> YRMXiJvkuJOICQfRULAWdmFUChHW()
			{
				return new bsuaRuunmqoSTGGoFRyuJCezCFUP(-2);
			}

			[IteratorStateMachine(typeof(sdzJhGVwouTGZUimMPhjQUBZHsdA))]
			private IEnumerable<ControllerPollingInfo> BNatYQQBlAJbhztUioIhYNkaERk()
			{
				return new sdzJhGVwouTGZUimMPhjQUBZHsdA(-2);
			}

			[IteratorStateMachine(typeof(DllrTydnJeatRFChtsTXpCYHbvsB))]
			private IEnumerable<ControllerPollingInfo> KOfUmuGVZeEuXzakDKbwYpJejtIU()
			{
				return new DllrTydnJeatRFChtsTXpCYHbvsB(-2);
			}

			[IteratorStateMachine(typeof(QTBfGCdJuEfGSZnkuszHrCYraoly))]
			private IEnumerable<ControllerPollingInfo> bHUPKGxbmuHNXJxEYhqlFahcZjOn()
			{
				return new QTBfGCdJuEfGSZnkuszHrCYraoly(-2);
			}

			private IEnumerable<ControllerPollingInfo> gmtDZcAtmfGKKWYdHAMOwKvZWVsh(int P_0)
			{
				Joystick joystick = YNqVldwlIEQtzFpAeAvHuawYeKPCA().GetJoystick(P_0);
				if (joystick == null)
				{
					return new List<ControllerPollingInfo>();
				}
				return joystick.PollForAllElements();
			}

			private IEnumerable<ControllerPollingInfo> YdQlByQtfZHSfhSOHxcySGsZfxNgA(int P_0)
			{
				Joystick joystick = YNqVldwlIEQtzFpAeAvHuawYeKPCA().GetJoystick(P_0);
				if (joystick == null)
				{
					return new List<ControllerPollingInfo>();
				}
				return joystick.PollForAllElementsDown();
			}

			private IEnumerable<ControllerPollingInfo> qkbflDGcjeELbaDFGMBlIIBBUuQGB(int P_0)
			{
				Joystick joystick = YNqVldwlIEQtzFpAeAvHuawYeKPCA().GetJoystick(P_0);
				if (joystick == null)
				{
					return new List<ControllerPollingInfo>();
				}
				return joystick.PollForAllButtons();
			}

			private IEnumerable<ControllerPollingInfo> yjyRUXxgBxhJHFiAOwpmilMOEFeoA(int P_0)
			{
				Joystick joystick = YNqVldwlIEQtzFpAeAvHuawYeKPCA().GetJoystick(P_0);
				if (joystick == null)
				{
					return new List<ControllerPollingInfo>();
				}
				return joystick.PollForAllButtonsDown();
			}

			private IEnumerable<ControllerPollingInfo> kRyIAtjIjppkuxKxQmsNJIYVUBLv(int P_0)
			{
				Joystick joystick = YNqVldwlIEQtzFpAeAvHuawYeKPCA().GetJoystick(P_0);
				if (joystick == null)
				{
					return new List<ControllerPollingInfo>();
				}
				return joystick.PollForAllAxes();
			}

			private IEnumerable<ControllerPollingInfo> ozmBDRdYzWLUwQfyfACLhkxCDgRyb()
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().Keyboard.PollForAllKeys();
			}

			private IEnumerable<ControllerPollingInfo> RJJCFfURfKgJyzPAzKEvHvoljyxC()
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().Keyboard.PollForAllKeysDown();
			}

			private IEnumerable<ControllerPollingInfo> goGRwcaxYPqlGSYNxoaUMusfzfWA()
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().Mouse.PollForAllElements();
			}

			private IEnumerable<ControllerPollingInfo> cFeVzjWyLkCGYMlgciPFuippbBOw()
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().Mouse.PollForAllElementsDown();
			}

			private IEnumerable<ControllerPollingInfo> AIyPZoXHBYlsFHLJnYngVzyxkAxv()
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().Mouse.PollForAllButtons();
			}

			private IEnumerable<ControllerPollingInfo> imfRmVEeiZfoYJLcvzMIQSTjIYwcb()
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().Mouse.PollForAllButtonsDown();
			}

			private IEnumerable<ControllerPollingInfo> bNVbbwAewWvgbaxnriWIqtHAMFSE()
			{
				return YNqVldwlIEQtzFpAeAvHuawYeKPCA().Mouse.PollForAllAxes();
			}

			[IteratorStateMachine(typeof(aINBxwOHPsGIYgVzIKJwcSbFqUjWB))]
			private IEnumerable<ControllerPollingInfo> iAmJiGqnDeznBUFGUyVysujsGzX()
			{
				return new aINBxwOHPsGIYgVzIKJwcSbFqUjWB(-2);
			}

			[IteratorStateMachine(typeof(COZVSuLaKqlenwiyMJBxFjgYPbpQ))]
			private IEnumerable<ControllerPollingInfo> iWJZPgqzaKOlobkxUcJsCqhzBQEmA()
			{
				return new COZVSuLaKqlenwiyMJBxFjgYPbpQ(-2);
			}

			[IteratorStateMachine(typeof(WgzjtjyPCqnQDelsLzNcjtLRvJXy))]
			private IEnumerable<ControllerPollingInfo> FgeVayGrKtIjvqQBdlKzzfRdaFLcA()
			{
				return new WgzjtjyPCqnQDelsLzNcjtLRvJXy(-2);
			}

			[IteratorStateMachine(typeof(JzURznUgFHJUVyDzVHjsJjQZcsJj))]
			private IEnumerable<ControllerPollingInfo> DKChNbDNTRNWKwSqTouWfapYsDAmA()
			{
				return new JzURznUgFHJUVyDzVHjsJjQZcsJj(-2);
			}

			[IteratorStateMachine(typeof(oGifiEoyXRgDtRDAhdVmAPjzxEUC))]
			private IEnumerable<ControllerPollingInfo> fRdgDcKRPQsUxymcUNSOcACDLNBB()
			{
				return new oGifiEoyXRgDtRDAhdVmAPjzxEUC(-2);
			}

			private IEnumerable<ControllerPollingInfo> WhCKGrJOUkgMgxNxyTztBEfImONS(int P_0)
			{
				CustomController customController = YNqVldwlIEQtzFpAeAvHuawYeKPCA().GetCustomController(P_0);
				if (customController == null)
				{
					return new List<ControllerPollingInfo>();
				}
				return customController.PollForAllElements();
			}

			private IEnumerable<ControllerPollingInfo> jFExbvfzplMSrUqFbgIPzKPItVJw(int P_0)
			{
				CustomController customController = YNqVldwlIEQtzFpAeAvHuawYeKPCA().GetCustomController(P_0);
				if (customController == null)
				{
					return new List<ControllerPollingInfo>();
				}
				return customController.PollForAllElementsDown();
			}

			private IEnumerable<ControllerPollingInfo> cOuSaapfMYPnLZnLzKRaIrDGmYoL(int P_0)
			{
				CustomController customController = YNqVldwlIEQtzFpAeAvHuawYeKPCA().GetCustomController(P_0);
				if (customController == null)
				{
					return new List<ControllerPollingInfo>();
				}
				return customController.PollForAllButtons();
			}

			private IEnumerable<ControllerPollingInfo> aCjeXAUOufBcZIiLxoPosPeQSCcvA(int P_0)
			{
				CustomController customController = YNqVldwlIEQtzFpAeAvHuawYeKPCA().GetCustomController(P_0);
				if (customController == null)
				{
					return new List<ControllerPollingInfo>();
				}
				return customController.PollForAllButtonsDown();
			}

			private IEnumerable<ControllerPollingInfo> fsmPfpDVRvDZehPJvRrbiHLUWuDb(int P_0)
			{
				CustomController customController = YNqVldwlIEQtzFpAeAvHuawYeKPCA().GetCustomController(P_0);
				if (customController == null)
				{
					return new List<ControllerPollingInfo>();
				}
				return customController.PollForAllAxes();
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ConflictCheckingHelper : CodeHelper
		{
			private sealed class ShqBUlGKgiGQkLqFERkYECWfSLJI : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
			{
				private int ERXGgcqtwjDyFXXUxpoMDIzUMJxE;

				private ElementAssignmentConflictInfo qnWLsnbwfhJPZnMcXEbOWEEAHmXEA;

				private int MeuDsVqtpuEfegDDACyhoXhKKCyR;

				private int SNseUCQqGYgQVKGrTamrtMDrBiHyA;

				public int KHQCmJVSxnydGXzApPfwUxckxisr;

				private ActionElementMap NwQNKBSTJrGiyzMFbahqIUhuTppbA;

				public ActionElementMap ljhtdeYtKxQAaKTdNJcmVPYCTZuV;

				private bool aOWKarOhGCnSzopYyyKeexeftdru;

				public bool AKVUMfKUFoPsHmFdWqBluaSOzUwC;

				private int vlAAUQAjwtfarkdvthlfePVkPqrVB;

				public int ttVOLJqCzXHBKWokbDkSjSQNjpKM;

				private CustomControllerMap sFWVshxhQilaRjmPupiUgnChPjZn;

				public CustomControllerMap VldNBIKssqejQbslDQXCPoKUwqhd;

				private bool JkLXjLfQuuQFnloUROCqqQXwJSQW;

				public bool QnKSGeosOflbAJmHCZgvxFYxhEeS;

				private bool KnAnjTKXXzmawLPBteiZkgJLbCNab;

				public bool ralFTEAhfcUeDGFQTwoLEoJTZMLrA;

				private IList<Player> SpSbPgCSzwCQaWiugDVyuSwZdnEi;

				private int kZDtAhpddsaNcjoZNJEGIHldhpGJb;

				private IEnumerator<ElementAssignmentConflictInfo> ddgAoDfjBCckvsGiPMHPfNfiMGMRb;

				ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return qnWLsnbwfhJPZnMcXEbOWEEAHmXEA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return qnWLsnbwfhJPZnMcXEbOWEEAHmXEA;
					}
				}

				[DebuggerHidden]
				public ShqBUlGKgiGQkLqFERkYECWfSLJI(int P_0)
				{
					ERXGgcqtwjDyFXXUxpoMDIzUMJxE = P_0;
					MeuDsVqtpuEfegDDACyhoXhKKCyR = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int eRXGgcqtwjDyFXXUxpoMDIzUMJxE = ERXGgcqtwjDyFXXUxpoMDIzUMJxE;
					if (eRXGgcqtwjDyFXXUxpoMDIzUMJxE == -3 || eRXGgcqtwjDyFXXUxpoMDIzUMJxE == 1)
					{
						try
						{
						}
						finally
						{
							VlXHSOEeGnOwrpOVpAzXYTqOMCvj();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int eRXGgcqtwjDyFXXUxpoMDIzUMJxE = ERXGgcqtwjDyFXXUxpoMDIzUMJxE;
						if (eRXGgcqtwjDyFXXUxpoMDIzUMJxE != 0)
						{
							if (eRXGgcqtwjDyFXXUxpoMDIzUMJxE != 1)
							{
								return false;
							}
							ERXGgcqtwjDyFXXUxpoMDIzUMJxE = -3;
							goto IL_00e2;
						}
						ERXGgcqtwjDyFXXUxpoMDIzUMJxE = -1;
						if (SNseUCQqGYgQVKGrTamrtMDrBiHyA < 0 || NwQNKBSTJrGiyzMFbahqIUhuTppbA == null)
						{
							return false;
						}
						SpSbPgCSzwCQaWiugDVyuSwZdnEi = (aOWKarOhGCnSzopYyyKeexeftdru ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
						kZDtAhpddsaNcjoZNJEGIHldhpGJb = 0;
						goto IL_010c;
						IL_010c:
						if (kZDtAhpddsaNcjoZNJEGIHldhpGJb < SpSbPgCSzwCQaWiugDVyuSwZdnEi.Count)
						{
							ddgAoDfjBCckvsGiPMHPfNfiMGMRb = SpSbPgCSzwCQaWiugDVyuSwZdnEi[kZDtAhpddsaNcjoZNJEGIHldhpGJb].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Custom, vlAAUQAjwtfarkdvthlfePVkPqrVB, sFWVshxhQilaRjmPupiUgnChPjZn, NwQNKBSTJrGiyzMFbahqIUhuTppbA, JkLXjLfQuuQFnloUROCqqQXwJSQW, KnAnjTKXXzmawLPBteiZkgJLbCNab).GetEnumerator();
							ERXGgcqtwjDyFXXUxpoMDIzUMJxE = -3;
							goto IL_00e2;
						}
						return false;
						IL_00e2:
						if (ddgAoDfjBCckvsGiPMHPfNfiMGMRb.MoveNext())
						{
							ElementAssignmentConflictInfo current = ddgAoDfjBCckvsGiPMHPfNfiMGMRb.Current;
							qnWLsnbwfhJPZnMcXEbOWEEAHmXEA = current;
							ERXGgcqtwjDyFXXUxpoMDIzUMJxE = 1;
							return true;
						}
						VlXHSOEeGnOwrpOVpAzXYTqOMCvj();
						ddgAoDfjBCckvsGiPMHPfNfiMGMRb = null;
						kZDtAhpddsaNcjoZNJEGIHldhpGJb++;
						goto IL_010c;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void VlXHSOEeGnOwrpOVpAzXYTqOMCvj()
				{
					ERXGgcqtwjDyFXXUxpoMDIzUMJxE = -1;
					if (ddgAoDfjBCckvsGiPMHPfNfiMGMRb != null)
					{
						ddgAoDfjBCckvsGiPMHPfNfiMGMRb.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
				{
					ShqBUlGKgiGQkLqFERkYECWfSLJI shqBUlGKgiGQkLqFERkYECWfSLJI;
					if (ERXGgcqtwjDyFXXUxpoMDIzUMJxE == -2 && MeuDsVqtpuEfegDDACyhoXhKKCyR == Environment.CurrentManagedThreadId)
					{
						ERXGgcqtwjDyFXXUxpoMDIzUMJxE = 0;
						shqBUlGKgiGQkLqFERkYECWfSLJI = this;
					}
					else
					{
						shqBUlGKgiGQkLqFERkYECWfSLJI = new ShqBUlGKgiGQkLqFERkYECWfSLJI(0);
					}
					shqBUlGKgiGQkLqFERkYECWfSLJI.SNseUCQqGYgQVKGrTamrtMDrBiHyA = KHQCmJVSxnydGXzApPfwUxckxisr;
					shqBUlGKgiGQkLqFERkYECWfSLJI.vlAAUQAjwtfarkdvthlfePVkPqrVB = ttVOLJqCzXHBKWokbDkSjSQNjpKM;
					shqBUlGKgiGQkLqFERkYECWfSLJI.sFWVshxhQilaRjmPupiUgnChPjZn = VldNBIKssqejQbslDQXCPoKUwqhd;
					shqBUlGKgiGQkLqFERkYECWfSLJI.NwQNKBSTJrGiyzMFbahqIUhuTppbA = ljhtdeYtKxQAaKTdNJcmVPYCTZuV;
					shqBUlGKgiGQkLqFERkYECWfSLJI.JkLXjLfQuuQFnloUROCqqQXwJSQW = QnKSGeosOflbAJmHCZgvxFYxhEeS;
					shqBUlGKgiGQkLqFERkYECWfSLJI.KnAnjTKXXzmawLPBteiZkgJLbCNab = ralFTEAhfcUeDGFQTwoLEoJTZMLrA;
					shqBUlGKgiGQkLqFERkYECWfSLJI.aOWKarOhGCnSzopYyyKeexeftdru = AKVUMfKUFoPsHmFdWqBluaSOzUwC;
					return shqBUlGKgiGQkLqFERkYECWfSLJI;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
				}
			}

			private sealed class tzCnbhdpnJGgmuWRmhJVWZsLGOjl : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
			{
				private int YoeyYPuqsoaKOrcBNxyZjaqBvdnM;

				private ElementAssignmentConflictInfo KCYKtVqWbEVzNFUiHicSvLBCubHO;

				private int pKwbzrgkCBMzoNvUMHEODiwLfktEA;

				private ElementAssignmentConflictCheck LhefcncfssdcMIrwMMSeKPSYWcsGA;

				public ElementAssignmentConflictCheck fkDBgdOVgXcAWgFomPPzjiuFkUNnb;

				private bool apDHVrbLJjVdLRolDoJFNQQGJrqU;

				public bool RXtdIsHZowCIqWJqxJTLkrTHhnPdb;

				private bool EGeIbMcFMotDxVmVBKAUybNkBKekA;

				public bool SQvvlmBQcnUrFnJkNykIqdpKlasp;

				private bool OHJycIKLhCBWKvtFyJPuOSPniMHn;

				public bool UydCeneEPOScxrZVZMTHymJMoPrm;

				private IList<Player> hatoHATYcuePNzUxilSRwgCIFdHp;

				private int sXpeAccWNMOCiHaPHRNVmHwGTonSA;

				private IEnumerator<ElementAssignmentConflictInfo> hwmccIYhtBvNVIHuiABUzdyAAaCn;

				ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return KCYKtVqWbEVzNFUiHicSvLBCubHO;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return KCYKtVqWbEVzNFUiHicSvLBCubHO;
					}
				}

				[DebuggerHidden]
				public tzCnbhdpnJGgmuWRmhJVWZsLGOjl(int P_0)
				{
					YoeyYPuqsoaKOrcBNxyZjaqBvdnM = P_0;
					pKwbzrgkCBMzoNvUMHEODiwLfktEA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int yoeyYPuqsoaKOrcBNxyZjaqBvdnM = YoeyYPuqsoaKOrcBNxyZjaqBvdnM;
					if (yoeyYPuqsoaKOrcBNxyZjaqBvdnM == -3 || yoeyYPuqsoaKOrcBNxyZjaqBvdnM == 1)
					{
						try
						{
						}
						finally
						{
							OezbHnoeSXXQXVXCqrgfoduHVhjn();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int yoeyYPuqsoaKOrcBNxyZjaqBvdnM = YoeyYPuqsoaKOrcBNxyZjaqBvdnM;
						if (yoeyYPuqsoaKOrcBNxyZjaqBvdnM != 0)
						{
							if (yoeyYPuqsoaKOrcBNxyZjaqBvdnM != 1)
							{
								return false;
							}
							YoeyYPuqsoaKOrcBNxyZjaqBvdnM = -3;
							goto IL_00df;
						}
						YoeyYPuqsoaKOrcBNxyZjaqBvdnM = -1;
						if (LhefcncfssdcMIrwMMSeKPSYWcsGA.playerId < 0 || LhefcncfssdcMIrwMMSeKPSYWcsGA.elementAssignmentType == ElementAssignmentType.KeyboardKey)
						{
							return false;
						}
						hatoHATYcuePNzUxilSRwgCIFdHp = (apDHVrbLJjVdLRolDoJFNQQGJrqU ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
						sXpeAccWNMOCiHaPHRNVmHwGTonSA = 0;
						goto IL_0109;
						IL_0109:
						if (sXpeAccWNMOCiHaPHRNVmHwGTonSA < hatoHATYcuePNzUxilSRwgCIFdHp.Count)
						{
							hwmccIYhtBvNVIHuiABUzdyAAaCn = hatoHATYcuePNzUxilSRwgCIFdHp[sXpeAccWNMOCiHaPHRNVmHwGTonSA].controllers.conflictChecking.ElementAssignmentConflicts(LhefcncfssdcMIrwMMSeKPSYWcsGA, EGeIbMcFMotDxVmVBKAUybNkBKekA, OHJycIKLhCBWKvtFyJPuOSPniMHn).GetEnumerator();
							YoeyYPuqsoaKOrcBNxyZjaqBvdnM = -3;
							goto IL_00df;
						}
						return false;
						IL_00df:
						if (hwmccIYhtBvNVIHuiABUzdyAAaCn.MoveNext())
						{
							ElementAssignmentConflictInfo current = hwmccIYhtBvNVIHuiABUzdyAAaCn.Current;
							KCYKtVqWbEVzNFUiHicSvLBCubHO = current;
							YoeyYPuqsoaKOrcBNxyZjaqBvdnM = 1;
							return true;
						}
						OezbHnoeSXXQXVXCqrgfoduHVhjn();
						hwmccIYhtBvNVIHuiABUzdyAAaCn = null;
						sXpeAccWNMOCiHaPHRNVmHwGTonSA++;
						goto IL_0109;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void OezbHnoeSXXQXVXCqrgfoduHVhjn()
				{
					YoeyYPuqsoaKOrcBNxyZjaqBvdnM = -1;
					if (hwmccIYhtBvNVIHuiABUzdyAAaCn != null)
					{
						hwmccIYhtBvNVIHuiABUzdyAAaCn.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
				{
					tzCnbhdpnJGgmuWRmhJVWZsLGOjl tzCnbhdpnJGgmuWRmhJVWZsLGOjl2;
					if (YoeyYPuqsoaKOrcBNxyZjaqBvdnM == -2 && pKwbzrgkCBMzoNvUMHEODiwLfktEA == Environment.CurrentManagedThreadId)
					{
						YoeyYPuqsoaKOrcBNxyZjaqBvdnM = 0;
						tzCnbhdpnJGgmuWRmhJVWZsLGOjl2 = this;
					}
					else
					{
						tzCnbhdpnJGgmuWRmhJVWZsLGOjl2 = new tzCnbhdpnJGgmuWRmhJVWZsLGOjl(0);
					}
					tzCnbhdpnJGgmuWRmhJVWZsLGOjl2.LhefcncfssdcMIrwMMSeKPSYWcsGA = fkDBgdOVgXcAWgFomPPzjiuFkUNnb;
					tzCnbhdpnJGgmuWRmhJVWZsLGOjl2.EGeIbMcFMotDxVmVBKAUybNkBKekA = SQvvlmBQcnUrFnJkNykIqdpKlasp;
					tzCnbhdpnJGgmuWRmhJVWZsLGOjl2.OHJycIKLhCBWKvtFyJPuOSPniMHn = UydCeneEPOScxrZVZMTHymJMoPrm;
					tzCnbhdpnJGgmuWRmhJVWZsLGOjl2.apDHVrbLJjVdLRolDoJFNQQGJrqU = RXtdIsHZowCIqWJqxJTLkrTHhnPdb;
					return tzCnbhdpnJGgmuWRmhJVWZsLGOjl2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
				}
			}

			private sealed class DeqfGvNFkwCdvCDqvSjPqQrxUOOrA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
			{
				private int gEWcKjHRSNiEwgxCidzHgMzazcAMA;

				private ElementAssignmentConflictInfo CfjbLKjhNfIzQhqbvzNVjWKmTikd;

				private int BTIGxTFJPZbdLvXnFNBCDfNyFwzPA;

				private int AfguljKCQxogSgaliYgyZtxyOnxV;

				public int gVNVBVkOBQqgQkJvZsgtxdfiOiHL;

				private ActionElementMap ZHKfOSxbfdIQTPosYMCUYfJeFxCi;

				public ActionElementMap bpVhzkCujWKuURnXcMbqBXhRIdPt;

				private bool AlkjnegbVLvfOerklGIhCWoLeQFu;

				public bool ePQLsOjWWFmDkqEwcLmFUiYIdtcu;

				private int iLhKkXhmihBzPArMaxNgXfPXFGQW;

				public int uzBRFEvCxiUujlLXmmMIAHEQGdXi;

				private JoystickMap AjPzvTCxYgfkGRNjWnFtLrmxFPiX;

				public JoystickMap zSFLeYPlOuTjRPJsUAalKijxkzzT;

				private bool hINEstHoktWnmtqxWWZvtpuNONsWA;

				public bool cQKBVnxYdimDwFLDAOAOlkBgghKy;

				private bool izSCzGDECzFDEXXzaxdUMgFZZgmO;

				public bool ldbYmGdLeEosoTForcPRZWPqNUPp;

				private IList<Player> hPuMpRIJzFfQzyGaiGEtfTyhubFh;

				private int pDClGlDULbmSbqIYVjCLHdGbHdQf;

				private IEnumerator<ElementAssignmentConflictInfo> mgJqTodzylBsGpxsvqpaLgXZcLaW;

				ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return CfjbLKjhNfIzQhqbvzNVjWKmTikd;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return CfjbLKjhNfIzQhqbvzNVjWKmTikd;
					}
				}

				[DebuggerHidden]
				public DeqfGvNFkwCdvCDqvSjPqQrxUOOrA(int P_0)
				{
					gEWcKjHRSNiEwgxCidzHgMzazcAMA = P_0;
					BTIGxTFJPZbdLvXnFNBCDfNyFwzPA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = gEWcKjHRSNiEwgxCidzHgMzazcAMA;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							pZYoZDGxRtGsGfTjjKziVebYoCww();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = gEWcKjHRSNiEwgxCidzHgMzazcAMA;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							gEWcKjHRSNiEwgxCidzHgMzazcAMA = -3;
							goto IL_00e1;
						}
						gEWcKjHRSNiEwgxCidzHgMzazcAMA = -1;
						if (AfguljKCQxogSgaliYgyZtxyOnxV < 0 || ZHKfOSxbfdIQTPosYMCUYfJeFxCi == null)
						{
							return false;
						}
						hPuMpRIJzFfQzyGaiGEtfTyhubFh = (AlkjnegbVLvfOerklGIhCWoLeQFu ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
						pDClGlDULbmSbqIYVjCLHdGbHdQf = 0;
						goto IL_010b;
						IL_010b:
						if (pDClGlDULbmSbqIYVjCLHdGbHdQf < hPuMpRIJzFfQzyGaiGEtfTyhubFh.Count)
						{
							mgJqTodzylBsGpxsvqpaLgXZcLaW = hPuMpRIJzFfQzyGaiGEtfTyhubFh[pDClGlDULbmSbqIYVjCLHdGbHdQf].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Joystick, iLhKkXhmihBzPArMaxNgXfPXFGQW, AjPzvTCxYgfkGRNjWnFtLrmxFPiX, ZHKfOSxbfdIQTPosYMCUYfJeFxCi, hINEstHoktWnmtqxWWZvtpuNONsWA, izSCzGDECzFDEXXzaxdUMgFZZgmO).GetEnumerator();
							gEWcKjHRSNiEwgxCidzHgMzazcAMA = -3;
							goto IL_00e1;
						}
						return false;
						IL_00e1:
						if (mgJqTodzylBsGpxsvqpaLgXZcLaW.MoveNext())
						{
							ElementAssignmentConflictInfo current = mgJqTodzylBsGpxsvqpaLgXZcLaW.Current;
							CfjbLKjhNfIzQhqbvzNVjWKmTikd = current;
							gEWcKjHRSNiEwgxCidzHgMzazcAMA = 1;
							return true;
						}
						pZYoZDGxRtGsGfTjjKziVebYoCww();
						mgJqTodzylBsGpxsvqpaLgXZcLaW = null;
						pDClGlDULbmSbqIYVjCLHdGbHdQf++;
						goto IL_010b;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void pZYoZDGxRtGsGfTjjKziVebYoCww()
				{
					gEWcKjHRSNiEwgxCidzHgMzazcAMA = -1;
					if (mgJqTodzylBsGpxsvqpaLgXZcLaW != null)
					{
						mgJqTodzylBsGpxsvqpaLgXZcLaW.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
				{
					DeqfGvNFkwCdvCDqvSjPqQrxUOOrA deqfGvNFkwCdvCDqvSjPqQrxUOOrA;
					if (gEWcKjHRSNiEwgxCidzHgMzazcAMA == -2 && BTIGxTFJPZbdLvXnFNBCDfNyFwzPA == Environment.CurrentManagedThreadId)
					{
						gEWcKjHRSNiEwgxCidzHgMzazcAMA = 0;
						deqfGvNFkwCdvCDqvSjPqQrxUOOrA = this;
					}
					else
					{
						deqfGvNFkwCdvCDqvSjPqQrxUOOrA = new DeqfGvNFkwCdvCDqvSjPqQrxUOOrA(0);
					}
					deqfGvNFkwCdvCDqvSjPqQrxUOOrA.AfguljKCQxogSgaliYgyZtxyOnxV = gVNVBVkOBQqgQkJvZsgtxdfiOiHL;
					deqfGvNFkwCdvCDqvSjPqQrxUOOrA.iLhKkXhmihBzPArMaxNgXfPXFGQW = uzBRFEvCxiUujlLXmmMIAHEQGdXi;
					deqfGvNFkwCdvCDqvSjPqQrxUOOrA.AjPzvTCxYgfkGRNjWnFtLrmxFPiX = zSFLeYPlOuTjRPJsUAalKijxkzzT;
					deqfGvNFkwCdvCDqvSjPqQrxUOOrA.ZHKfOSxbfdIQTPosYMCUYfJeFxCi = bpVhzkCujWKuURnXcMbqBXhRIdPt;
					deqfGvNFkwCdvCDqvSjPqQrxUOOrA.hINEstHoktWnmtqxWWZvtpuNONsWA = cQKBVnxYdimDwFLDAOAOlkBgghKy;
					deqfGvNFkwCdvCDqvSjPqQrxUOOrA.izSCzGDECzFDEXXzaxdUMgFZZgmO = ldbYmGdLeEosoTForcPRZWPqNUPp;
					deqfGvNFkwCdvCDqvSjPqQrxUOOrA.AlkjnegbVLvfOerklGIhCWoLeQFu = ePQLsOjWWFmDkqEwcLmFUiYIdtcu;
					return deqfGvNFkwCdvCDqvSjPqQrxUOOrA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
				}
			}

			private sealed class gxOtUEAwmPKqFJyMMLyrCtdXZhWC : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
			{
				private int aKUtsyOQDBhWiYjkIHdbeeAmfBvn;

				private ElementAssignmentConflictInfo oxScYLcmMuReYBzKAioVmkETZimSA;

				private int yerXetEkkcAPLoPVmESTPekhaAmbA;

				private ElementAssignmentConflictCheck WEwejaJqJUdtDtSLKJzFTsPgxObiA;

				public ElementAssignmentConflictCheck yTKeReYqDZInHKAnRxHDhvwdMnFXA;

				private bool ienclxJbJKIvDoFlfAlMRtchrEZp;

				public bool WiBbKpGMfqiSUbPvGkhgfAAMyPHk;

				private bool xJdZsEkjSsYcfquKUJIlifgwoUse;

				public bool sCAJVtpUaHeYMDHCxXXQghsMqPny;

				private bool jMmovtwXlZVUFeCQEFmpkipzMgqmA;

				public bool JtyVchxjZGAbwgWxIabBfNslbBRdb;

				private IList<Player> GcAJJNVyckWvtQEDjPRroCoYJTJq;

				private int PqfytceKvxKXvWgqIlyOFVMipXCR;

				private IEnumerator<ElementAssignmentConflictInfo> IhZAXUlZEhHsJRUgzHjmVafNLTxq;

				ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return oxScYLcmMuReYBzKAioVmkETZimSA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return oxScYLcmMuReYBzKAioVmkETZimSA;
					}
				}

				[DebuggerHidden]
				public gxOtUEAwmPKqFJyMMLyrCtdXZhWC(int P_0)
				{
					aKUtsyOQDBhWiYjkIHdbeeAmfBvn = P_0;
					yerXetEkkcAPLoPVmESTPekhaAmbA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = aKUtsyOQDBhWiYjkIHdbeeAmfBvn;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							nCTcUiXdxBrNbtMLbPjOiyCjrrmU();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = aKUtsyOQDBhWiYjkIHdbeeAmfBvn;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							aKUtsyOQDBhWiYjkIHdbeeAmfBvn = -3;
							goto IL_00df;
						}
						aKUtsyOQDBhWiYjkIHdbeeAmfBvn = -1;
						if (WEwejaJqJUdtDtSLKJzFTsPgxObiA.playerId < 0 || WEwejaJqJUdtDtSLKJzFTsPgxObiA.elementAssignmentType == ElementAssignmentType.KeyboardKey)
						{
							return false;
						}
						GcAJJNVyckWvtQEDjPRroCoYJTJq = (ienclxJbJKIvDoFlfAlMRtchrEZp ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
						PqfytceKvxKXvWgqIlyOFVMipXCR = 0;
						goto IL_0109;
						IL_0109:
						if (PqfytceKvxKXvWgqIlyOFVMipXCR < GcAJJNVyckWvtQEDjPRroCoYJTJq.Count)
						{
							IhZAXUlZEhHsJRUgzHjmVafNLTxq = GcAJJNVyckWvtQEDjPRroCoYJTJq[PqfytceKvxKXvWgqIlyOFVMipXCR].controllers.conflictChecking.ElementAssignmentConflicts(WEwejaJqJUdtDtSLKJzFTsPgxObiA, xJdZsEkjSsYcfquKUJIlifgwoUse, jMmovtwXlZVUFeCQEFmpkipzMgqmA).GetEnumerator();
							aKUtsyOQDBhWiYjkIHdbeeAmfBvn = -3;
							goto IL_00df;
						}
						return false;
						IL_00df:
						if (IhZAXUlZEhHsJRUgzHjmVafNLTxq.MoveNext())
						{
							ElementAssignmentConflictInfo current = IhZAXUlZEhHsJRUgzHjmVafNLTxq.Current;
							oxScYLcmMuReYBzKAioVmkETZimSA = current;
							aKUtsyOQDBhWiYjkIHdbeeAmfBvn = 1;
							return true;
						}
						nCTcUiXdxBrNbtMLbPjOiyCjrrmU();
						IhZAXUlZEhHsJRUgzHjmVafNLTxq = null;
						PqfytceKvxKXvWgqIlyOFVMipXCR++;
						goto IL_0109;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void nCTcUiXdxBrNbtMLbPjOiyCjrrmU()
				{
					aKUtsyOQDBhWiYjkIHdbeeAmfBvn = -1;
					if (IhZAXUlZEhHsJRUgzHjmVafNLTxq != null)
					{
						IhZAXUlZEhHsJRUgzHjmVafNLTxq.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
				{
					gxOtUEAwmPKqFJyMMLyrCtdXZhWC gxOtUEAwmPKqFJyMMLyrCtdXZhWC2;
					if (aKUtsyOQDBhWiYjkIHdbeeAmfBvn == -2 && yerXetEkkcAPLoPVmESTPekhaAmbA == Environment.CurrentManagedThreadId)
					{
						aKUtsyOQDBhWiYjkIHdbeeAmfBvn = 0;
						gxOtUEAwmPKqFJyMMLyrCtdXZhWC2 = this;
					}
					else
					{
						gxOtUEAwmPKqFJyMMLyrCtdXZhWC2 = new gxOtUEAwmPKqFJyMMLyrCtdXZhWC(0);
					}
					gxOtUEAwmPKqFJyMMLyrCtdXZhWC2.WEwejaJqJUdtDtSLKJzFTsPgxObiA = yTKeReYqDZInHKAnRxHDhvwdMnFXA;
					gxOtUEAwmPKqFJyMMLyrCtdXZhWC2.xJdZsEkjSsYcfquKUJIlifgwoUse = sCAJVtpUaHeYMDHCxXXQghsMqPny;
					gxOtUEAwmPKqFJyMMLyrCtdXZhWC2.jMmovtwXlZVUFeCQEFmpkipzMgqmA = JtyVchxjZGAbwgWxIabBfNslbBRdb;
					gxOtUEAwmPKqFJyMMLyrCtdXZhWC2.ienclxJbJKIvDoFlfAlMRtchrEZp = WiBbKpGMfqiSUbPvGkhgfAAMyPHk;
					return gxOtUEAwmPKqFJyMMLyrCtdXZhWC2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
				}
			}

			private sealed class nrEAmfbKGNWwIhkJLelzdEllyoVQ : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
			{
				private int MNSIKHvZuOFCKqrVAbmVIRpKgfcw;

				private ElementAssignmentConflictInfo ZHxCQMjVupvRKNdFKBgcGbGDYYpPA;

				private int nOCZsNKUAATfoiupOiIgdkFMhjeDA;

				private int UMfbttJmNXqmWNtgTvfoUJWhgfpY;

				public int qANHOGTBazlqXauCfEHxczRNPbxq;

				private ActionElementMap OFZrUWBzpbKHAqQmdGpDISPUUSIbA;

				public ActionElementMap ZAfkxFDzcRYaTNzrLbHxtSrOJcFE;

				private bool hPuCrCDIfWAlMgNQEAghZTvKsNKbB;

				public bool NGVgmBdhqUuQzcLbyFEtnYoCrKJq;

				private KeyboardMap RNtLOAZLHXqMgdiNTHMPFgDWTQoG;

				public KeyboardMap bwSIjQHjIYqAartEEkvfvyUOlMAk;

				private bool mqxbOsUvAnrjbKmYpIExTZKUSMwj;

				public bool iDLZwBUvoCqvFBnobDuKGzoeZCrTA;

				private bool JvMqFqLgsyeOErxHJMBuSbuqUKAD;

				public bool qAieecBHJMhcWuCikwPSoxoBgFlkA;

				private IList<Player> aHjHhDhqDyvSXcUBPLVRDkQwCfvk;

				private int GQpHqlQTGncQuwyCzRQPzbytYLKL;

				private IEnumerator<ElementAssignmentConflictInfo> tcydfDWZjZHYYllYhZPehvhpDvOA;

				ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return ZHxCQMjVupvRKNdFKBgcGbGDYYpPA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ZHxCQMjVupvRKNdFKBgcGbGDYYpPA;
					}
				}

				[DebuggerHidden]
				public nrEAmfbKGNWwIhkJLelzdEllyoVQ(int P_0)
				{
					MNSIKHvZuOFCKqrVAbmVIRpKgfcw = P_0;
					nOCZsNKUAATfoiupOiIgdkFMhjeDA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int mNSIKHvZuOFCKqrVAbmVIRpKgfcw = MNSIKHvZuOFCKqrVAbmVIRpKgfcw;
					if (mNSIKHvZuOFCKqrVAbmVIRpKgfcw == -3 || mNSIKHvZuOFCKqrVAbmVIRpKgfcw == 1)
					{
						try
						{
						}
						finally
						{
							FucPszYklukbdnJKoQOsDucRepkM();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int mNSIKHvZuOFCKqrVAbmVIRpKgfcw = MNSIKHvZuOFCKqrVAbmVIRpKgfcw;
						if (mNSIKHvZuOFCKqrVAbmVIRpKgfcw != 0)
						{
							if (mNSIKHvZuOFCKqrVAbmVIRpKgfcw != 1)
							{
								return false;
							}
							MNSIKHvZuOFCKqrVAbmVIRpKgfcw = -3;
							goto IL_00dc;
						}
						MNSIKHvZuOFCKqrVAbmVIRpKgfcw = -1;
						if (UMfbttJmNXqmWNtgTvfoUJWhgfpY < 0 || OFZrUWBzpbKHAqQmdGpDISPUUSIbA == null)
						{
							return false;
						}
						aHjHhDhqDyvSXcUBPLVRDkQwCfvk = (hPuCrCDIfWAlMgNQEAghZTvKsNKbB ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
						GQpHqlQTGncQuwyCzRQPzbytYLKL = 0;
						goto IL_0106;
						IL_0106:
						if (GQpHqlQTGncQuwyCzRQPzbytYLKL < aHjHhDhqDyvSXcUBPLVRDkQwCfvk.Count)
						{
							tcydfDWZjZHYYllYhZPehvhpDvOA = aHjHhDhqDyvSXcUBPLVRDkQwCfvk[GQpHqlQTGncQuwyCzRQPzbytYLKL].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Keyboard, 0, RNtLOAZLHXqMgdiNTHMPFgDWTQoG, OFZrUWBzpbKHAqQmdGpDISPUUSIbA, mqxbOsUvAnrjbKmYpIExTZKUSMwj, JvMqFqLgsyeOErxHJMBuSbuqUKAD).GetEnumerator();
							MNSIKHvZuOFCKqrVAbmVIRpKgfcw = -3;
							goto IL_00dc;
						}
						return false;
						IL_00dc:
						if (tcydfDWZjZHYYllYhZPehvhpDvOA.MoveNext())
						{
							ElementAssignmentConflictInfo current = tcydfDWZjZHYYllYhZPehvhpDvOA.Current;
							ZHxCQMjVupvRKNdFKBgcGbGDYYpPA = current;
							MNSIKHvZuOFCKqrVAbmVIRpKgfcw = 1;
							return true;
						}
						FucPszYklukbdnJKoQOsDucRepkM();
						tcydfDWZjZHYYllYhZPehvhpDvOA = null;
						GQpHqlQTGncQuwyCzRQPzbytYLKL++;
						goto IL_0106;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void FucPszYklukbdnJKoQOsDucRepkM()
				{
					MNSIKHvZuOFCKqrVAbmVIRpKgfcw = -1;
					if (tcydfDWZjZHYYllYhZPehvhpDvOA != null)
					{
						tcydfDWZjZHYYllYhZPehvhpDvOA.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
				{
					nrEAmfbKGNWwIhkJLelzdEllyoVQ nrEAmfbKGNWwIhkJLelzdEllyoVQ2;
					if (MNSIKHvZuOFCKqrVAbmVIRpKgfcw == -2 && nOCZsNKUAATfoiupOiIgdkFMhjeDA == Environment.CurrentManagedThreadId)
					{
						MNSIKHvZuOFCKqrVAbmVIRpKgfcw = 0;
						nrEAmfbKGNWwIhkJLelzdEllyoVQ2 = this;
					}
					else
					{
						nrEAmfbKGNWwIhkJLelzdEllyoVQ2 = new nrEAmfbKGNWwIhkJLelzdEllyoVQ(0);
					}
					nrEAmfbKGNWwIhkJLelzdEllyoVQ2.UMfbttJmNXqmWNtgTvfoUJWhgfpY = qANHOGTBazlqXauCfEHxczRNPbxq;
					nrEAmfbKGNWwIhkJLelzdEllyoVQ2.RNtLOAZLHXqMgdiNTHMPFgDWTQoG = bwSIjQHjIYqAartEEkvfvyUOlMAk;
					nrEAmfbKGNWwIhkJLelzdEllyoVQ2.OFZrUWBzpbKHAqQmdGpDISPUUSIbA = ZAfkxFDzcRYaTNzrLbHxtSrOJcFE;
					nrEAmfbKGNWwIhkJLelzdEllyoVQ2.mqxbOsUvAnrjbKmYpIExTZKUSMwj = iDLZwBUvoCqvFBnobDuKGzoeZCrTA;
					nrEAmfbKGNWwIhkJLelzdEllyoVQ2.JvMqFqLgsyeOErxHJMBuSbuqUKAD = qAieecBHJMhcWuCikwPSoxoBgFlkA;
					nrEAmfbKGNWwIhkJLelzdEllyoVQ2.hPuCrCDIfWAlMgNQEAghZTvKsNKbB = NGVgmBdhqUuQzcLbyFEtnYoCrKJq;
					return nrEAmfbKGNWwIhkJLelzdEllyoVQ2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
				}
			}

			private sealed class IwjruZQobanCkOkSXgFMSIRwDxSh : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
			{
				private int GfjWWQlGCWuiJINTNLYqYJSjiVwD;

				private ElementAssignmentConflictInfo ODRRdYXPsbVxZWXikQNsEfHmzKIG;

				private int cemqKnBqhezMsmSpIRVJiQiJDJmd;

				private ElementAssignmentConflictCheck hKbGNlHJhCKNImOACuSZDjCQFNUD;

				public ElementAssignmentConflictCheck JJkSPpABvNBiTFgFRZFfaYuJYwkKA;

				private bool QxvSbjcBTOWPvcMinpsDnyFDtHZK;

				public bool ZjnfPHthwxMLbcSxdiwxCoTkTEak;

				private bool JWrkvIgNdTGUsbmuOxfAmlgxDmnV;

				public bool TFPqrhUrliUzCViTCGMTNOYWbCtS;

				private bool SeYnnnPsGsmrHMMIOjgyHMUJvnuBA;

				public bool zHEAPyxcakZhEEPJCxqUhmMGwKiE;

				private IList<Player> nUazgbjOzDTMsueLPPiNlxYnWJnJ;

				private int GIeUfvKbnVoAjYJiqBTMJpGPeCkiA;

				private IEnumerator<ElementAssignmentConflictInfo> uwEKmcvlUPgwNGjoyjpDevlijUPi;

				ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return ODRRdYXPsbVxZWXikQNsEfHmzKIG;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ODRRdYXPsbVxZWXikQNsEfHmzKIG;
					}
				}

				[DebuggerHidden]
				public IwjruZQobanCkOkSXgFMSIRwDxSh(int P_0)
				{
					GfjWWQlGCWuiJINTNLYqYJSjiVwD = P_0;
					cemqKnBqhezMsmSpIRVJiQiJDJmd = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int gfjWWQlGCWuiJINTNLYqYJSjiVwD = GfjWWQlGCWuiJINTNLYqYJSjiVwD;
					if (gfjWWQlGCWuiJINTNLYqYJSjiVwD == -3 || gfjWWQlGCWuiJINTNLYqYJSjiVwD == 1)
					{
						try
						{
						}
						finally
						{
							RBdZnsbjBdzitdEGgbYquPBXReAD();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int gfjWWQlGCWuiJINTNLYqYJSjiVwD = GfjWWQlGCWuiJINTNLYqYJSjiVwD;
						if (gfjWWQlGCWuiJINTNLYqYJSjiVwD != 0)
						{
							if (gfjWWQlGCWuiJINTNLYqYJSjiVwD != 1)
							{
								return false;
							}
							GfjWWQlGCWuiJINTNLYqYJSjiVwD = -3;
							goto IL_00df;
						}
						GfjWWQlGCWuiJINTNLYqYJSjiVwD = -1;
						if (hKbGNlHJhCKNImOACuSZDjCQFNUD.playerId < 0 || hKbGNlHJhCKNImOACuSZDjCQFNUD.elementAssignmentType != ElementAssignmentType.KeyboardKey)
						{
							return false;
						}
						nUazgbjOzDTMsueLPPiNlxYnWJnJ = (QxvSbjcBTOWPvcMinpsDnyFDtHZK ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
						GIeUfvKbnVoAjYJiqBTMJpGPeCkiA = 0;
						goto IL_0109;
						IL_0109:
						if (GIeUfvKbnVoAjYJiqBTMJpGPeCkiA < nUazgbjOzDTMsueLPPiNlxYnWJnJ.Count)
						{
							uwEKmcvlUPgwNGjoyjpDevlijUPi = nUazgbjOzDTMsueLPPiNlxYnWJnJ[GIeUfvKbnVoAjYJiqBTMJpGPeCkiA].controllers.conflictChecking.ElementAssignmentConflicts(hKbGNlHJhCKNImOACuSZDjCQFNUD, JWrkvIgNdTGUsbmuOxfAmlgxDmnV, SeYnnnPsGsmrHMMIOjgyHMUJvnuBA).GetEnumerator();
							GfjWWQlGCWuiJINTNLYqYJSjiVwD = -3;
							goto IL_00df;
						}
						return false;
						IL_00df:
						if (uwEKmcvlUPgwNGjoyjpDevlijUPi.MoveNext())
						{
							ElementAssignmentConflictInfo current = uwEKmcvlUPgwNGjoyjpDevlijUPi.Current;
							ODRRdYXPsbVxZWXikQNsEfHmzKIG = current;
							GfjWWQlGCWuiJINTNLYqYJSjiVwD = 1;
							return true;
						}
						RBdZnsbjBdzitdEGgbYquPBXReAD();
						uwEKmcvlUPgwNGjoyjpDevlijUPi = null;
						GIeUfvKbnVoAjYJiqBTMJpGPeCkiA++;
						goto IL_0109;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void RBdZnsbjBdzitdEGgbYquPBXReAD()
				{
					GfjWWQlGCWuiJINTNLYqYJSjiVwD = -1;
					if (uwEKmcvlUPgwNGjoyjpDevlijUPi != null)
					{
						uwEKmcvlUPgwNGjoyjpDevlijUPi.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
				{
					IwjruZQobanCkOkSXgFMSIRwDxSh iwjruZQobanCkOkSXgFMSIRwDxSh;
					if (GfjWWQlGCWuiJINTNLYqYJSjiVwD == -2 && cemqKnBqhezMsmSpIRVJiQiJDJmd == Environment.CurrentManagedThreadId)
					{
						GfjWWQlGCWuiJINTNLYqYJSjiVwD = 0;
						iwjruZQobanCkOkSXgFMSIRwDxSh = this;
					}
					else
					{
						iwjruZQobanCkOkSXgFMSIRwDxSh = new IwjruZQobanCkOkSXgFMSIRwDxSh(0);
					}
					iwjruZQobanCkOkSXgFMSIRwDxSh.hKbGNlHJhCKNImOACuSZDjCQFNUD = JJkSPpABvNBiTFgFRZFfaYuJYwkKA;
					iwjruZQobanCkOkSXgFMSIRwDxSh.JWrkvIgNdTGUsbmuOxfAmlgxDmnV = TFPqrhUrliUzCViTCGMTNOYWbCtS;
					iwjruZQobanCkOkSXgFMSIRwDxSh.SeYnnnPsGsmrHMMIOjgyHMUJvnuBA = zHEAPyxcakZhEEPJCxqUhmMGwKiE;
					iwjruZQobanCkOkSXgFMSIRwDxSh.QxvSbjcBTOWPvcMinpsDnyFDtHZK = ZjnfPHthwxMLbcSxdiwxCoTkTEak;
					return iwjruZQobanCkOkSXgFMSIRwDxSh;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
				}
			}

			private sealed class HHdhUJrfzXxTsFjYCpFaihCJllnN : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
			{
				private int kGXGfSeafLphIVwVkSVCjgdcSeifb;

				private ElementAssignmentConflictInfo BqQvVVQBOXIYPfYMGitpeukTguttA;

				private int TyRdFSaADCwFpCAAEmzoEePVOEvu;

				private int dYPAXYwpdqVWZeIspwIvsifavTQb;

				public int VsTPUQuwWpgvDPhPnLGHWcrwrXWh;

				private ActionElementMap cEgnvRdKIlwplgfqtQvvGHPIbPnl;

				public ActionElementMap qnSoIVQdcLKxjBtoxLjjRMpEJgob;

				private bool UBLaMtxovZBocqUDHNygGXjTNxsM;

				public bool QmapMPcbdCtUHgWYnBgpCuKPWPAY;

				private MouseMap RKWkWlxkmWndCSdfzZRFslFIHwwcA;

				public MouseMap gvgRVHSSyURBwDKCKjpghURdEQoZ;

				private bool DjcXFFSHLPSnZgLBKPLpzhUOcvwO;

				public bool ZkiyiHNZufHuKTMrngMHehchqHpGA;

				private bool GxCQQvNAgrfrEIVVBZvPMLASYLN;

				public bool dSOfzCObAjhCVAgxPmXLWDbsuKncA;

				private IList<Player> JcIQGkHBxvlSYMuPDKcoNURqfaEk;

				private int tyTuNWEFbOotpZquDRcKXFdPfhFE;

				private IEnumerator<ElementAssignmentConflictInfo> uOdyYVAaWTQCkIbzRPraeFvbikAk;

				ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return BqQvVVQBOXIYPfYMGitpeukTguttA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return BqQvVVQBOXIYPfYMGitpeukTguttA;
					}
				}

				[DebuggerHidden]
				public HHdhUJrfzXxTsFjYCpFaihCJllnN(int P_0)
				{
					kGXGfSeafLphIVwVkSVCjgdcSeifb = P_0;
					TyRdFSaADCwFpCAAEmzoEePVOEvu = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = kGXGfSeafLphIVwVkSVCjgdcSeifb;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							mlKwgcvTQYMORxrZPIyckaLShVEK();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = kGXGfSeafLphIVwVkSVCjgdcSeifb;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							kGXGfSeafLphIVwVkSVCjgdcSeifb = -3;
							goto IL_00dc;
						}
						kGXGfSeafLphIVwVkSVCjgdcSeifb = -1;
						if (dYPAXYwpdqVWZeIspwIvsifavTQb < 0 || cEgnvRdKIlwplgfqtQvvGHPIbPnl == null)
						{
							return false;
						}
						JcIQGkHBxvlSYMuPDKcoNURqfaEk = (UBLaMtxovZBocqUDHNygGXjTNxsM ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
						tyTuNWEFbOotpZquDRcKXFdPfhFE = 0;
						goto IL_0106;
						IL_0106:
						if (tyTuNWEFbOotpZquDRcKXFdPfhFE < JcIQGkHBxvlSYMuPDKcoNURqfaEk.Count)
						{
							uOdyYVAaWTQCkIbzRPraeFvbikAk = JcIQGkHBxvlSYMuPDKcoNURqfaEk[tyTuNWEFbOotpZquDRcKXFdPfhFE].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Mouse, 0, RKWkWlxkmWndCSdfzZRFslFIHwwcA, cEgnvRdKIlwplgfqtQvvGHPIbPnl, DjcXFFSHLPSnZgLBKPLpzhUOcvwO, GxCQQvNAgrfrEIVVBZvPMLASYLN).GetEnumerator();
							kGXGfSeafLphIVwVkSVCjgdcSeifb = -3;
							goto IL_00dc;
						}
						return false;
						IL_00dc:
						if (uOdyYVAaWTQCkIbzRPraeFvbikAk.MoveNext())
						{
							ElementAssignmentConflictInfo current = uOdyYVAaWTQCkIbzRPraeFvbikAk.Current;
							BqQvVVQBOXIYPfYMGitpeukTguttA = current;
							kGXGfSeafLphIVwVkSVCjgdcSeifb = 1;
							return true;
						}
						mlKwgcvTQYMORxrZPIyckaLShVEK();
						uOdyYVAaWTQCkIbzRPraeFvbikAk = null;
						tyTuNWEFbOotpZquDRcKXFdPfhFE++;
						goto IL_0106;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void mlKwgcvTQYMORxrZPIyckaLShVEK()
				{
					kGXGfSeafLphIVwVkSVCjgdcSeifb = -1;
					if (uOdyYVAaWTQCkIbzRPraeFvbikAk != null)
					{
						uOdyYVAaWTQCkIbzRPraeFvbikAk.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
				{
					HHdhUJrfzXxTsFjYCpFaihCJllnN hHdhUJrfzXxTsFjYCpFaihCJllnN;
					if (kGXGfSeafLphIVwVkSVCjgdcSeifb == -2 && TyRdFSaADCwFpCAAEmzoEePVOEvu == Environment.CurrentManagedThreadId)
					{
						kGXGfSeafLphIVwVkSVCjgdcSeifb = 0;
						hHdhUJrfzXxTsFjYCpFaihCJllnN = this;
					}
					else
					{
						hHdhUJrfzXxTsFjYCpFaihCJllnN = new HHdhUJrfzXxTsFjYCpFaihCJllnN(0);
					}
					hHdhUJrfzXxTsFjYCpFaihCJllnN.dYPAXYwpdqVWZeIspwIvsifavTQb = VsTPUQuwWpgvDPhPnLGHWcrwrXWh;
					hHdhUJrfzXxTsFjYCpFaihCJllnN.RKWkWlxkmWndCSdfzZRFslFIHwwcA = gvgRVHSSyURBwDKCKjpghURdEQoZ;
					hHdhUJrfzXxTsFjYCpFaihCJllnN.cEgnvRdKIlwplgfqtQvvGHPIbPnl = qnSoIVQdcLKxjBtoxLjjRMpEJgob;
					hHdhUJrfzXxTsFjYCpFaihCJllnN.DjcXFFSHLPSnZgLBKPLpzhUOcvwO = ZkiyiHNZufHuKTMrngMHehchqHpGA;
					hHdhUJrfzXxTsFjYCpFaihCJllnN.GxCQQvNAgrfrEIVVBZvPMLASYLN = dSOfzCObAjhCVAgxPmXLWDbsuKncA;
					hHdhUJrfzXxTsFjYCpFaihCJllnN.UBLaMtxovZBocqUDHNygGXjTNxsM = QmapMPcbdCtUHgWYnBgpCuKPWPAY;
					return hHdhUJrfzXxTsFjYCpFaihCJllnN;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
				}
			}

			private sealed class kvBrTKHMDtAdfunIGewkvUBgjmMN : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
			{
				private int qUhYiltKSDXBgwsMnrrwOiAEHdyI;

				private ElementAssignmentConflictInfo ieyaqsgLSccXVyOQJwvbDLhjwbbUA;

				private int wGZNShbjCJAlVaIVOTBiNaTFKgUj;

				private ElementAssignmentConflictCheck JPFtqCcDtNcRDuIJHiCGCBhqlwJKA;

				public ElementAssignmentConflictCheck GYsfDQBHpigxrETjWGmlPVDUkpXRA;

				private bool QblgOSmARIvvPkARHnYeGSISOpYH;

				public bool mUipoDchSrpTlbQlMBwnrGpirMdC;

				private bool QmWLQsgJEuBUOfQWsLSsOzSeOPtA;

				public bool WnJKwcTkIgkOPuKmnBaNnSrCQdrF;

				private bool evfTDBREyTxvfcEtMMTdKXSPcAKg;

				public bool mAYRnSoMXNpyqULVLqfgBUeNeRkg;

				private IList<Player> vvpDJIZXfwPdDVWjNJsGwfsKrijT;

				private int GTdlvPgmEzhgkJvuWurEDddmCasD;

				private IEnumerator<ElementAssignmentConflictInfo> hQOXnHcUKVmcOtoQcMDOkrEkbiVH;

				ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return ieyaqsgLSccXVyOQJwvbDLhjwbbUA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ieyaqsgLSccXVyOQJwvbDLhjwbbUA;
					}
				}

				[DebuggerHidden]
				public kvBrTKHMDtAdfunIGewkvUBgjmMN(int P_0)
				{
					qUhYiltKSDXBgwsMnrrwOiAEHdyI = P_0;
					wGZNShbjCJAlVaIVOTBiNaTFKgUj = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = qUhYiltKSDXBgwsMnrrwOiAEHdyI;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							zDxeOkiPRpDFnnAsfxcLLMPeuQGAA();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = qUhYiltKSDXBgwsMnrrwOiAEHdyI;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							qUhYiltKSDXBgwsMnrrwOiAEHdyI = -3;
							goto IL_00df;
						}
						qUhYiltKSDXBgwsMnrrwOiAEHdyI = -1;
						if (JPFtqCcDtNcRDuIJHiCGCBhqlwJKA.playerId < 0 || JPFtqCcDtNcRDuIJHiCGCBhqlwJKA.elementAssignmentType == ElementAssignmentType.KeyboardKey)
						{
							return false;
						}
						vvpDJIZXfwPdDVWjNJsGwfsKrijT = (QblgOSmARIvvPkARHnYeGSISOpYH ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
						GTdlvPgmEzhgkJvuWurEDddmCasD = 0;
						goto IL_0109;
						IL_0109:
						if (GTdlvPgmEzhgkJvuWurEDddmCasD < vvpDJIZXfwPdDVWjNJsGwfsKrijT.Count)
						{
							hQOXnHcUKVmcOtoQcMDOkrEkbiVH = vvpDJIZXfwPdDVWjNJsGwfsKrijT[GTdlvPgmEzhgkJvuWurEDddmCasD].controllers.conflictChecking.ElementAssignmentConflicts(JPFtqCcDtNcRDuIJHiCGCBhqlwJKA, QmWLQsgJEuBUOfQWsLSsOzSeOPtA, evfTDBREyTxvfcEtMMTdKXSPcAKg).GetEnumerator();
							qUhYiltKSDXBgwsMnrrwOiAEHdyI = -3;
							goto IL_00df;
						}
						return false;
						IL_00df:
						if (hQOXnHcUKVmcOtoQcMDOkrEkbiVH.MoveNext())
						{
							ElementAssignmentConflictInfo current = hQOXnHcUKVmcOtoQcMDOkrEkbiVH.Current;
							ieyaqsgLSccXVyOQJwvbDLhjwbbUA = current;
							qUhYiltKSDXBgwsMnrrwOiAEHdyI = 1;
							return true;
						}
						zDxeOkiPRpDFnnAsfxcLLMPeuQGAA();
						hQOXnHcUKVmcOtoQcMDOkrEkbiVH = null;
						GTdlvPgmEzhgkJvuWurEDddmCasD++;
						goto IL_0109;
					}
					catch
					{
						//try-fault
						((IDisposable)this).Dispose();
						throw;
					}
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void zDxeOkiPRpDFnnAsfxcLLMPeuQGAA()
				{
					qUhYiltKSDXBgwsMnrrwOiAEHdyI = -1;
					if (hQOXnHcUKVmcOtoQcMDOkrEkbiVH != null)
					{
						hQOXnHcUKVmcOtoQcMDOkrEkbiVH.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
				{
					kvBrTKHMDtAdfunIGewkvUBgjmMN kvBrTKHMDtAdfunIGewkvUBgjmMN2;
					if (qUhYiltKSDXBgwsMnrrwOiAEHdyI == -2 && wGZNShbjCJAlVaIVOTBiNaTFKgUj == Environment.CurrentManagedThreadId)
					{
						qUhYiltKSDXBgwsMnrrwOiAEHdyI = 0;
						kvBrTKHMDtAdfunIGewkvUBgjmMN2 = this;
					}
					else
					{
						kvBrTKHMDtAdfunIGewkvUBgjmMN2 = new kvBrTKHMDtAdfunIGewkvUBgjmMN(0);
					}
					kvBrTKHMDtAdfunIGewkvUBgjmMN2.JPFtqCcDtNcRDuIJHiCGCBhqlwJKA = GYsfDQBHpigxrETjWGmlPVDUkpXRA;
					kvBrTKHMDtAdfunIGewkvUBgjmMN2.QmWLQsgJEuBUOfQWsLSsOzSeOPtA = WnJKwcTkIgkOPuKmnBaNnSrCQdrF;
					kvBrTKHMDtAdfunIGewkvUBgjmMN2.evfTDBREyTxvfcEtMMTdKXSPcAKg = mAYRnSoMXNpyqULVLqfgBUeNeRkg;
					kvBrTKHMDtAdfunIGewkvUBgjmMN2.QblgOSmARIvvPkARHnYeGSISOpYH = mUipoDchSrpTlbQlMBwnrGpirMdC;
					return kvBrTKHMDtAdfunIGewkvUBgjmMN2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
				}
			}

			private static ConflictCheckingHelper yDQIirZTgLScXMmLLhJtBsgrIOMDb;

			internal static ConflictCheckingHelper owujfmTAazZFXHZDSmDsaehOqGIy => xDQFJiNVLOZvkYICURYmfyNKVxXP();

			internal static ConflictCheckingHelper xDQFJiNVLOZvkYICURYmfyNKVxXP()
			{
				return yDQIirZTgLScXMmLLhJtBsgrIOMDb ?? (yDQIirZTgLScXMmLLhJtBsgrIOMDb = new ConflictCheckingHelper());
			}

			private ConflictCheckingHelper()
			{
			}

			public bool DoesAnyElementAssignmentConflict()
			{
				return DoesAnyElementAssignmentConflict(skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
			}

			public bool DoesAnyElementAssignmentConflict(bool skipDisabledMaps)
			{
				return DoesAnyElementAssignmentConflict(skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
			}

			public bool DoesAnyElementAssignmentConflict(bool skipDisabledMaps, bool forceCheckAllCategories)
			{
				return DoesAnyElementAssignmentConflict(skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
			}

			public bool DoesAnyElementAssignmentConflict(bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				IList<Player> list = (includeSystemPlayer ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					Player player = list[i];
					int num = (forceCheckAllCategories ? i : 0);
					IList<Joystick> joysticks = player.controllers.Joysticks;
					for (int j = 0; j < joysticks.Count; j++)
					{
						Joystick joystick = joysticks[j];
						IList<JoystickMap> maps = player.controllers.maps.GetMaps<JoystickMap>(joystick.id);
						if (maps == null)
						{
							continue;
						}
						int count2 = maps.Count;
						for (int k = num; k < count; k++)
						{
							Player player2 = list[k];
							for (int l = 0; l < count2; l++)
							{
								if (player2.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, joystick.id, maps[l], skipDisabledMaps, forceCheckAllCategories))
								{
									return true;
								}
							}
						}
					}
					IList<KeyboardMap> maps2 = player.controllers.maps.GetMaps<KeyboardMap>(0);
					for (int m = 0; m < maps2.Count; m++)
					{
						for (int n = num; n < count; n++)
						{
							if (list[n].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, maps2[m], skipDisabledMaps, forceCheckAllCategories))
							{
								return true;
							}
						}
					}
					IList<MouseMap> maps3 = player.controllers.maps.GetMaps<MouseMap>(0);
					for (int num2 = 0; num2 < maps3.Count; num2++)
					{
						for (int num3 = num; num3 < count; num3++)
						{
							if (list[num3].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, maps3[num2], skipDisabledMaps, forceCheckAllCategories))
							{
								return true;
							}
						}
					}
					IList<CustomController> customControllers = player.controllers.CustomControllers;
					for (int num4 = 0; num4 < customControllers.Count; num4++)
					{
						CustomController customController = customControllers[num4];
						IList<CustomControllerMap> maps4 = player.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
						if (maps4 == null)
						{
							continue;
						}
						int count3 = maps4.Count;
						for (int num5 = num; num5 < count; num5++)
						{
							Player player3 = list[num5];
							for (int num6 = 0; num6 < count3; num6++)
							{
								if (player3.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, customController.id, maps4[num6], skipDisabledMaps, forceCheckAllCategories))
								{
									return true;
								}
							}
						}
					}
				}
				return false;
			}

			public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
			{
				return DoesElementAssignmentConflict(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
			}

			public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
			{
				return DoesElementAssignmentConflict(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
			}

			public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
			{
				return DoesElementAssignmentConflict(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
			}

			public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				if (playerId < 0 || elementMap == null)
				{
					return false;
				}
				return controllerType switch
				{
					ControllerType.Joystick => dFbHsTluEoXjevzZhyvNovqWsyIA(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
					ControllerType.Keyboard => fdOKFmOqUQLnlWVijhwVXFhualJf(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
					ControllerType.Mouse => qryCuhNOEPfOPdPghrmToqcZblwYA(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
					ControllerType.Custom => GNzxHdhqjSqJwldgudYfkKokJzWT(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
					_ => throw new NotImplementedException(), 
				};
			}

			public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck)
			{
				return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
			}

			public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
			{
				return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
			}

			public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
			{
				return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
			}

			public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				if (conflictCheck.playerId < 0)
				{
					return false;
				}
				if (conflictCheck.controllerType == ControllerType.Joystick)
				{
					return YDZHZzbJoMIMvRKEeyexzZUxRjOo(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
				}
				if (conflictCheck.controllerType == ControllerType.Keyboard)
				{
					return zgytPboPrHOcsZWxoDVvjUyInNgC(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
				}
				if (conflictCheck.controllerType == ControllerType.Mouse)
				{
					return sQVywaAEtHJPtYfKLnBBSThOojLE(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
				}
				if (conflictCheck.controllerType == ControllerType.Custom)
				{
					return wrJKCWRlEPLHWFqNCgfcbUUZeopn(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
				}
				throw new NotImplementedException();
			}

			private bool dFbHsTluEoXjevzZhyvNovqWsyIA(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
			{
				if (P_0 < 0 || P_3 == null)
				{
					return false;
				}
				IList<Player> list = (P_6 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5))
					{
						return true;
					}
				}
				return false;
			}

			private bool YDZHZzbJoMIMvRKEeyexzZUxRjOo(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
			{
				if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
				{
					return false;
				}
				IList<Player> list = (P_3 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
					{
						return true;
					}
				}
				return false;
			}

			private bool fdOKFmOqUQLnlWVijhwVXFhualJf(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
			{
				if (P_0 < 0 || P_2 == null)
				{
					return false;
				}
				IList<Player> list = (P_5 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4))
					{
						return true;
					}
				}
				return false;
			}

			private bool zgytPboPrHOcsZWxoDVvjUyInNgC(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
			{
				if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
				{
					return false;
				}
				IList<Player> list = (P_3 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
					{
						return true;
					}
				}
				return false;
			}

			private bool qryCuhNOEPfOPdPghrmToqcZblwYA(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
			{
				if (P_0 < 0 || P_2 == null)
				{
					return false;
				}
				IList<Player> list = (P_5 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4))
					{
						return true;
					}
				}
				return false;
			}

			private bool sQVywaAEtHJPtYfKLnBBSThOojLE(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
			{
				if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
				{
					return false;
				}
				IList<Player> list = (P_3 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
					{
						return true;
					}
				}
				return false;
			}

			private bool GNzxHdhqjSqJwldgudYfkKokJzWT(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
			{
				if (P_0 < 0 || P_3 == null)
				{
					return false;
				}
				IList<Player> list = (P_6 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5))
					{
						return true;
					}
				}
				return false;
			}

			private bool wrJKCWRlEPLHWFqNCgfcbUUZeopn(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
			{
				if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
				{
					return false;
				}
				IList<Player> list = (P_3 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
					{
						return true;
					}
				}
				return false;
			}

			public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
			{
				return ElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
			}

			public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
			{
				return ElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
			}

			public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
			{
				return ElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
			}

			public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
				}
				if (playerId < 0 || elementMap == null)
				{
					return new List<ElementAssignmentConflictInfo>();
				}
				return controllerType switch
				{
					ControllerType.Joystick => YlDXBVveFPMVYCVtfGmcPRIgsdVk(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
					ControllerType.Keyboard => oveHUMmcRmTRpGMVCcKqTWLsOAzg(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
					ControllerType.Mouse => ChZqGnuPdMEJGcNVnaOUYqCgZvLs(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
					ControllerType.Custom => jSpeOmWCwUBRShTuEACJZgTAsadhA(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
					_ => throw new NotImplementedException(), 
				};
			}

			public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
			{
				return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
			}

			public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
			{
				return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
			}

			public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
			{
				return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
			}

			public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
				}
				if (conflictCheck.playerId < 0)
				{
					return new List<ElementAssignmentConflictInfo>();
				}
				if (conflictCheck.controllerType == ControllerType.Joystick)
				{
					return JxxJGFkGAIAyBUpRnVQBtidpTWhi(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
				}
				if (conflictCheck.controllerType == ControllerType.Keyboard)
				{
					return homZPkTzyTxuqhSjJqyUHcJpJDOi(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
				}
				if (conflictCheck.controllerType == ControllerType.Mouse)
				{
					return cPfLJKPwkKiFEVhgbYrHfsuYDfvD(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
				}
				if (conflictCheck.controllerType == ControllerType.Custom)
				{
					return oyAAnMbncXcoqHXQRBIVPNJPabVaA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
				}
				throw new NotImplementedException();
			}

			[IteratorStateMachine(typeof(DeqfGvNFkwCdvCDqvSjPqQrxUOOrA))]
			private IEnumerable<ElementAssignmentConflictInfo> YlDXBVveFPMVYCVtfGmcPRIgsdVk(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
			{
				return new DeqfGvNFkwCdvCDqvSjPqQrxUOOrA(-2)
				{
					gVNVBVkOBQqgQkJvZsgtxdfiOiHL = P_0,
					uzBRFEvCxiUujlLXmmMIAHEQGdXi = P_1,
					zSFLeYPlOuTjRPJsUAalKijxkzzT = P_2,
					bpVhzkCujWKuURnXcMbqBXhRIdPt = P_3,
					cQKBVnxYdimDwFLDAOAOlkBgghKy = P_4,
					ldbYmGdLeEosoTForcPRZWPqNUPp = P_5,
					ePQLsOjWWFmDkqEwcLmFUiYIdtcu = P_6
				};
			}

			[IteratorStateMachine(typeof(gxOtUEAwmPKqFJyMMLyrCtdXZhWC))]
			private IEnumerable<ElementAssignmentConflictInfo> JxxJGFkGAIAyBUpRnVQBtidpTWhi(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
			{
				return new gxOtUEAwmPKqFJyMMLyrCtdXZhWC(-2)
				{
					yTKeReYqDZInHKAnRxHDhvwdMnFXA = P_0,
					sCAJVtpUaHeYMDHCxXXQghsMqPny = P_1,
					JtyVchxjZGAbwgWxIabBfNslbBRdb = P_2,
					WiBbKpGMfqiSUbPvGkhgfAAMyPHk = P_3
				};
			}

			[IteratorStateMachine(typeof(nrEAmfbKGNWwIhkJLelzdEllyoVQ))]
			private IEnumerable<ElementAssignmentConflictInfo> oveHUMmcRmTRpGMVCcKqTWLsOAzg(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
			{
				return new nrEAmfbKGNWwIhkJLelzdEllyoVQ(-2)
				{
					qANHOGTBazlqXauCfEHxczRNPbxq = P_0,
					bwSIjQHjIYqAartEEkvfvyUOlMAk = P_1,
					ZAfkxFDzcRYaTNzrLbHxtSrOJcFE = P_2,
					iDLZwBUvoCqvFBnobDuKGzoeZCrTA = P_3,
					qAieecBHJMhcWuCikwPSoxoBgFlkA = P_4,
					NGVgmBdhqUuQzcLbyFEtnYoCrKJq = P_5
				};
			}

			[IteratorStateMachine(typeof(IwjruZQobanCkOkSXgFMSIRwDxSh))]
			private IEnumerable<ElementAssignmentConflictInfo> homZPkTzyTxuqhSjJqyUHcJpJDOi(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
			{
				return new IwjruZQobanCkOkSXgFMSIRwDxSh(-2)
				{
					JJkSPpABvNBiTFgFRZFfaYuJYwkKA = P_0,
					TFPqrhUrliUzCViTCGMTNOYWbCtS = P_1,
					zHEAPyxcakZhEEPJCxqUhmMGwKiE = P_2,
					ZjnfPHthwxMLbcSxdiwxCoTkTEak = P_3
				};
			}

			[IteratorStateMachine(typeof(HHdhUJrfzXxTsFjYCpFaihCJllnN))]
			private IEnumerable<ElementAssignmentConflictInfo> ChZqGnuPdMEJGcNVnaOUYqCgZvLs(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
			{
				return new HHdhUJrfzXxTsFjYCpFaihCJllnN(-2)
				{
					VsTPUQuwWpgvDPhPnLGHWcrwrXWh = P_0,
					gvgRVHSSyURBwDKCKjpghURdEQoZ = P_1,
					qnSoIVQdcLKxjBtoxLjjRMpEJgob = P_2,
					ZkiyiHNZufHuKTMrngMHehchqHpGA = P_3,
					dSOfzCObAjhCVAgxPmXLWDbsuKncA = P_4,
					QmapMPcbdCtUHgWYnBgpCuKPWPAY = P_5
				};
			}

			[IteratorStateMachine(typeof(kvBrTKHMDtAdfunIGewkvUBgjmMN))]
			private IEnumerable<ElementAssignmentConflictInfo> cPfLJKPwkKiFEVhgbYrHfsuYDfvD(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
			{
				return new kvBrTKHMDtAdfunIGewkvUBgjmMN(-2)
				{
					GYsfDQBHpigxrETjWGmlPVDUkpXRA = P_0,
					WnJKwcTkIgkOPuKmnBaNnSrCQdrF = P_1,
					mAYRnSoMXNpyqULVLqfgBUeNeRkg = P_2,
					mUipoDchSrpTlbQlMBwnrGpirMdC = P_3
				};
			}

			[IteratorStateMachine(typeof(ShqBUlGKgiGQkLqFERkYECWfSLJI))]
			private IEnumerable<ElementAssignmentConflictInfo> jSpeOmWCwUBRShTuEACJZgTAsadhA(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
			{
				return new ShqBUlGKgiGQkLqFERkYECWfSLJI(-2)
				{
					KHQCmJVSxnydGXzApPfwUxckxisr = P_0,
					ttVOLJqCzXHBKWokbDkSjSQNjpKM = P_1,
					VldNBIKssqejQbslDQXCPoKUwqhd = P_2,
					ljhtdeYtKxQAaKTdNJcmVPYCTZuV = P_3,
					QnKSGeosOflbAJmHCZgvxFYxhEeS = P_4,
					ralFTEAhfcUeDGFQTwoLEoJTZMLrA = P_5,
					AKVUMfKUFoPsHmFdWqBluaSOzUwC = P_6
				};
			}

			[IteratorStateMachine(typeof(tzCnbhdpnJGgmuWRmhJVWZsLGOjl))]
			private IEnumerable<ElementAssignmentConflictInfo> oyAAnMbncXcoqHXQRBIVPNJPabVaA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
			{
				return new tzCnbhdpnJGgmuWRmhJVWZsLGOjl(-2)
				{
					fkDBgdOVgXcAWgFomPPzjiuFkUNnb = P_0,
					SQvvlmBQcnUrFnJkNykIqdpKlasp = P_1,
					UydCeneEPOScxrZVZMTHymJMoPrm = P_2,
					RXtdIsHZowCIqWJqxJTLkrTHhnPdb = P_3
				};
			}

			public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
			{
				return RemoveElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
			}

			public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
			{
				return RemoveElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
			}

			public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
			{
				return RemoveElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
			}

			public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
			{
				if (!CheckInitialized())
				{
					return 0;
				}
				if (playerId < 0 || elementMap == null)
				{
					return 0;
				}
				return controllerType switch
				{
					ControllerType.Joystick => DDdfRWfvrxZZwuiATqWRWtKhMYfR(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
					ControllerType.Keyboard => JzcsVWdBtkddtEIqAakceIigciEk(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
					ControllerType.Mouse => ndDSTSQDNMhwdCUXxJwyRqYrBiLR(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
					ControllerType.Custom => kUuVgQYASsEYIcArOGZZCTsPEillA(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
					_ => throw new NotImplementedException(), 
				};
			}

			public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
			{
				return RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
			}

			public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
			{
				return RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
			}

			public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
			{
				return RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
			}

			public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
			{
				if (!CheckInitialized())
				{
					return 0;
				}
				if (conflictCheck.playerId < 0)
				{
					return 0;
				}
				if (conflictCheck.controllerType == ControllerType.Joystick)
				{
					return wlBGAVfBcoaEyasCQjCGqewcySNX(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
				}
				if (conflictCheck.controllerType == ControllerType.Keyboard)
				{
					return KZaFbHYqTvRbVMGWRavdebjMDXPQA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
				}
				if (conflictCheck.controllerType == ControllerType.Mouse)
				{
					return VhKSpiOayFdGZgmFegvtnYrAzxLX(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
				}
				if (conflictCheck.controllerType == ControllerType.Custom)
				{
					return TMZTnJatyMdyopuyCgnLucdDrijK(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
				}
				throw new NotImplementedException();
			}

			private int DDdfRWfvrxZZwuiATqWRWtKhMYfR(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
			{
				if (P_0 < 0 || P_3 == null)
				{
					return 0;
				}
				IList<Player> list = (P_6 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				int num = 0;
				for (int i = 0; i < list.Count; i++)
				{
					num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
				}
				return num;
			}

			private int wlBGAVfBcoaEyasCQjCGqewcySNX(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
			{
				if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
				{
					return 0;
				}
				IList<Player> list = (P_3 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				int num = 0;
				for (int i = 0; i < list.Count; i++)
				{
					num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
				}
				return num;
			}

			private int JzcsVWdBtkddtEIqAakceIigciEk(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
			{
				if (P_0 < 0 || P_2 == null)
				{
					return 0;
				}
				IList<Player> list = (P_5 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				int num = 0;
				for (int i = 0; i < list.Count; i++)
				{
					num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
				}
				return num;
			}

			private int KZaFbHYqTvRbVMGWRavdebjMDXPQA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
			{
				if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
				{
					return 0;
				}
				IList<Player> list = (P_3 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				int num = 0;
				for (int i = 0; i < list.Count; i++)
				{
					num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
				}
				return num;
			}

			private int ndDSTSQDNMhwdCUXxJwyRqYrBiLR(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
			{
				if (P_0 < 0 || P_2 == null)
				{
					return 0;
				}
				IList<Player> list = (P_5 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				int num = 0;
				for (int i = 0; i < list.Count; i++)
				{
					num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
				}
				return num;
			}

			private int VhKSpiOayFdGZgmFegvtnYrAzxLX(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
			{
				if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
				{
					return 0;
				}
				IList<Player> list = (P_3 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				int num = 0;
				for (int i = 0; i < list.Count; i++)
				{
					num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
				}
				return num;
			}

			private int kUuVgQYASsEYIcArOGZZCTsPEillA(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
			{
				if (P_0 < 0 || P_3 == null)
				{
					return 0;
				}
				IList<Player> list = (P_6 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				int num = 0;
				for (int i = 0; i < list.Count; i++)
				{
					num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
				}
				return num;
			}

			private int TMZTnJatyMdyopuyCgnLucdDrijK(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
			{
				if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
				{
					return 0;
				}
				IList<Player> list = (P_3 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				int num = 0;
				for (int i = 0; i < list.Count; i++)
				{
					num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
				}
				return num;
			}

			public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
			{
				return DisableElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
			}

			public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
			{
				return DisableElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
			}

			public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
			{
				return DisableElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
			}

			public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
			{
				if (!CheckInitialized())
				{
					return 0;
				}
				if (playerId < 0 || elementMap == null)
				{
					return 0;
				}
				return controllerType switch
				{
					ControllerType.Joystick => EOEcFVEFzPhddmnnOJKGcIaeViIxA(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
					ControllerType.Keyboard => tNJpcMdcgVCBXGVDedrLuRObMUOsA(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
					ControllerType.Mouse => RhHrHvmJwQPNRxZrVnbIJUndwXuP(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
					ControllerType.Custom => fsgTHcwGfSjEuEJdpoCOiRRQLfBl(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
					_ => throw new NotImplementedException(), 
				};
			}

			public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
			{
				return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
			}

			public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
			{
				return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
			}

			public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
			{
				return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
			}

			public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
			{
				if (!CheckInitialized())
				{
					return 0;
				}
				if (conflictCheck.playerId < 0)
				{
					return 0;
				}
				if (conflictCheck.controllerType == ControllerType.Joystick)
				{
					return kSdLkNQNVmVmcVqdkKqqAECySdHi(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
				}
				if (conflictCheck.controllerType == ControllerType.Keyboard)
				{
					return PZjrOKuZGNVwUIQmmMxWgeuzSNBh(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
				}
				if (conflictCheck.controllerType == ControllerType.Mouse)
				{
					return zeAAZgHDPKbWIdozRJqgnpVWtDyf(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
				}
				if (conflictCheck.controllerType == ControllerType.Custom)
				{
					return aQoWpMupQpwmngxXtQPVxAXthCZG(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
				}
				throw new NotImplementedException();
			}

			private int EOEcFVEFzPhddmnnOJKGcIaeViIxA(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
			{
				if (P_0 < 0 || P_3 == null)
				{
					return 0;
				}
				IList<Player> list = (P_6 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				int num = 0;
				for (int i = 0; i < list.Count; i++)
				{
					num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
				}
				return num;
			}

			private int kSdLkNQNVmVmcVqdkKqqAECySdHi(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
			{
				if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
				{
					return 0;
				}
				IList<Player> list = (P_3 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				int num = 0;
				for (int i = 0; i < list.Count; i++)
				{
					num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
				}
				return num;
			}

			private int tNJpcMdcgVCBXGVDedrLuRObMUOsA(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
			{
				if (P_0 < 0 || P_2 == null)
				{
					return 0;
				}
				IList<Player> list = (P_5 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				int num = 0;
				for (int i = 0; i < list.Count; i++)
				{
					num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
				}
				return num;
			}

			private int PZjrOKuZGNVwUIQmmMxWgeuzSNBh(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
			{
				if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
				{
					return 0;
				}
				IList<Player> list = (P_3 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				int num = 0;
				for (int i = 0; i < list.Count; i++)
				{
					num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
				}
				return num;
			}

			private int RhHrHvmJwQPNRxZrVnbIJUndwXuP(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
			{
				if (P_0 < 0 || P_2 == null)
				{
					return 0;
				}
				IList<Player> list = (P_5 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				int num = 0;
				for (int i = 0; i < list.Count; i++)
				{
					num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
				}
				return num;
			}

			private int zeAAZgHDPKbWIdozRJqgnpVWtDyf(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
			{
				if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
				{
					return 0;
				}
				IList<Player> list = (P_3 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				int num = 0;
				for (int i = 0; i < list.Count; i++)
				{
					num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
				}
				return num;
			}

			private int fsgTHcwGfSjEuEJdpoCOiRRQLfBl(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
			{
				if (P_0 < 0 || P_3 == null)
				{
					return 0;
				}
				IList<Player> list = (P_6 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				int num = 0;
				for (int i = 0; i < list.Count; i++)
				{
					num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
				}
				return num;
			}

			private int aQoWpMupQpwmngxXtQPVxAXthCZG(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
			{
				if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
				{
					return 0;
				}
				IList<Player> list = (P_3 ? iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA() : iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK());
				int num = 0;
				for (int i = 0; i < list.Count; i++)
				{
					num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
				}
				return num;
			}
		}

		private static ControllerHelper NsGeLAflikNeFFaHPpmllPHuHBeeb;

		public readonly PollingHelper polling = PollingHelper.RqkmUHqbtpXCFYtcefaNLeCLmHDX();

		public readonly ConflictCheckingHelper conflictChecking = ConflictCheckingHelper.xDQFJiNVLOZvkYICURYmfyNKVxXP();

		internal static ControllerHelper nxBEWbHUEsvvOcLYiOebPOsLMBxE => YNqVldwlIEQtzFpAeAvHuawYeKPCA();

		public int controllerCount
		{
			get
			{
				if (!CheckInitialized())
				{
					return 0;
				}
				return jCkgZLcnXoMycBxzcMXWvnUfSROEb.pOFmLNpHHlXSdmUtdhorPuqYdUpI();
			}
		}

		public IList<Controller> Controllers
		{
			get
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<Controller>.EmptyReadOnlyIListT;
				}
				return jCkgZLcnXoMycBxzcMXWvnUfSROEb.YetqXxUEGPeQRCqyyCXaVhfrClnN();
			}
		}

		public Mouse Mouse
		{
			get
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jCkgZLcnXoMycBxzcMXWvnUfSROEb.QEiqHFnLLZJSkuwNvWvNEjeQXMlT();
			}
		}

		public Keyboard Keyboard
		{
			get
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jCkgZLcnXoMycBxzcMXWvnUfSROEb.CJDSMKuYTmJFQKoQSdBfaFNyeDGkA();
			}
		}

		[Obsolete("Deprecated: Use Controller.enabled instead. For example, to disable keyboard input: ReInput.controllers.Keyboard.enabled = false.")]
		public bool keyboardEnabled
		{
			get
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return Keyboard.enabled;
			}
			set
			{
				if (CheckInitialized())
				{
					Keyboard.enabled = value;
				}
			}
		}

		public int joystickCount
		{
			get
			{
				if (!CheckInitialized())
				{
					return 0;
				}
				return jCkgZLcnXoMycBxzcMXWvnUfSROEb.DgWkEwMpXTtCniXaqphVZqoNpNah();
			}
		}

		public IList<Joystick> Joysticks
		{
			get
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<Joystick>.EmptyReadOnlyIListT;
				}
				return jCkgZLcnXoMycBxzcMXWvnUfSROEb.EEbcrLiEhnvUlDgBBWavPqjmOUJZA();
			}
		}

		public int customControllerCount
		{
			get
			{
				if (!CheckInitialized())
				{
					return 0;
				}
				return jCkgZLcnXoMycBxzcMXWvnUfSROEb.iRWLoJbnOgesrOMvmrqqhNPmZYLV();
			}
		}

		public IList<CustomController> CustomControllers
		{
			get
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return jCkgZLcnXoMycBxzcMXWvnUfSROEb.oEBCyTxQXibzLFYTdcadMQGimPZS();
			}
		}

		internal static ControllerHelper YNqVldwlIEQtzFpAeAvHuawYeKPCA()
		{
			return NsGeLAflikNeFFaHPpmllPHuHBeeb ?? (NsGeLAflikNeFFaHPpmllPHuHBeeb = new ControllerHelper());
		}

		private ControllerHelper()
		{
		}

		public T GetController<T>(int controllerId) where T : Controller
		{
			if (!CheckInitialized())
			{
				return null;
			}
			if (controllerId < 0)
			{
				return null;
			}
			Type typeFromHandle = typeof(T);
			if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
			{
				return GetJoystick(controllerId) as T;
			}
			if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
			{
				return jCkgZLcnXoMycBxzcMXWvnUfSROEb.CJDSMKuYTmJFQKoQSdBfaFNyeDGkA() as T;
			}
			if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
			{
				return GetCustomController(controllerId) as T;
			}
			if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
			{
				return jCkgZLcnXoMycBxzcMXWvnUfSROEb.QEiqHFnLLZJSkuwNvWvNEjeQXMlT() as T;
			}
			throw new NotImplementedException();
		}

		public int GetControllerCount(ControllerType controllerType)
		{
			if (!CheckInitialized())
			{
				return 0;
			}
			return controllerType switch
			{
				ControllerType.Joystick => joystickCount, 
				ControllerType.Keyboard => 1, 
				ControllerType.Mouse => 1, 
				ControllerType.Custom => customControllerCount, 
				_ => throw new NotImplementedException(), 
			};
		}

		public Controller GetController(ControllerType controllerType, int controllerId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.qLXmBGgOrsBKkXyijYLMvlwfrnKd(controllerType, controllerId);
		}

		public Controller GetController(ControllerIdentifier controllerIdentifier)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.yFVHNGFipkTnAhiniBHCFElVkRXm(controllerIdentifier);
		}

		public Controller[] GetControllers(ControllerType controllerType)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<Controller>.array;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.TteiMHtSpVSPKPfmPaMamFMlYEGW(controllerType);
		}

		public string[] GetControllerNames(ControllerType controllerType)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<string>.array;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.FCawKZuaMNERONyyHTItVhQCqZPB(controllerType);
		}

		public bool IsControllerAssigned(ControllerType controllerType, Controller controller)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.StjEBPCacMFyqIDOIMMrjOvJYopN(controller);
		}

		public bool IsControllerAssigned(ControllerType controllerType, int controllerId)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.pbpkDFWLyvVGxBSpJgfiarllLpZf(controllerType, controllerId);
		}

		public bool IsControllerAssignedToPlayer(ControllerType controllerType, int controllerId, int playerId)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.etAFAgAOCdfGKYXkTSPaTZlOfjRIA(controllerType, controllerId, playerId);
		}

		public void RemoveControllerFromAllPlayers(Controller controller, bool includeSystemPlayer = true)
		{
			if (CheckInitialized())
			{
				iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.jvdadKUxrlQrFtJOhuSsautDzGic(controller, includeSystemPlayer);
			}
		}

		public void RemoveControllerFromAllPlayers(ControllerType controllerType, int controllerId, bool includeSystemPlayer = true)
		{
			if (CheckInitialized())
			{
				iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.pqvnYGsqSatGbOJKvCHsigtlKZxEA(controllerType, controllerId, includeSystemPlayer);
			}
		}

		public Joystick GetJoystick(int joystickId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.YYiuqUYQXVQfqAVVHuCdeZVvlDuO(joystickId);
		}

		public Joystick[] GetJoysticks()
		{
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.OlTVyyKrYbhIthgmlhMjBGqpgQLkA();
		}

		public string[] GetJoystickNames()
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<string>.array;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.PSvkQmuCvkwjUMJYCqiGWFVcjwcB();
		}

		public bool IsJoystickAssigned(Joystick joystick)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.QszGNdnMKMKxoVvTxiabqKnjEGpm(joystick);
		}

		public bool IsJoystickAssigned(int joystickId)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.oeXSyRVFNaeoWcVwHVyLzZdCtBGb(joystickId);
		}

		public bool IsJoystickAssignedToPlayer(int joystickId, int playerId)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.tNyThZVHDAzqtdlZebWBIRxfvdK(joystickId, playerId);
		}

		public void RemoveJoystickFromAllPlayers(Joystick joystick, bool includeSystemPlayer = true)
		{
			if (CheckInitialized())
			{
				iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.akAcLwgLARvzAtSRDJgOImodCwHt(joystick, includeSystemPlayer);
			}
		}

		public void RemoveJoystickFromAllPlayers(int joystickId, bool includeSystemPlayer = true)
		{
			if (CheckInitialized())
			{
				iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.oKNSYFYMkfdYASVbfCRuJsEtRUvT(joystickId, includeSystemPlayer);
			}
		}

		public int GetUnityJoystickIdFromAnyButtonPress()
		{
			if (!CheckInitialized())
			{
				return -1;
			}
			if (!sJwPaphnMJCMJkgqAeoxPkqvHssEb)
			{
				Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
				return -1;
			}
			MjKfEGwixYArvDaHMXvrICBOIIaN();
			for (int i = 0; i < 16; i++)
			{
				for (int j = 0; j < 20; j++)
				{
					if (ntZJMMLDNppJFyxcEJhPKrldSpyH().QwcakpxQrGbeKklsXCHumQBnIXyBb(i, j))
					{
						return i + 1;
					}
				}
			}
			return -1;
		}

		public int GetUnityJoystickIdFromAnyButtonOrAxisPress(float axisThreshold, bool positiveAxesOnly)
		{
			if (!CheckInitialized())
			{
				return -1;
			}
			if (!sJwPaphnMJCMJkgqAeoxPkqvHssEb)
			{
				Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
				return -1;
			}
			MjKfEGwixYArvDaHMXvrICBOIIaN();
			for (int i = 0; i < 16; i++)
			{
				for (int j = 0; j < 20; j++)
				{
					if (ntZJMMLDNppJFyxcEJhPKrldSpyH().QwcakpxQrGbeKklsXCHumQBnIXyBb(i, j))
					{
						return i + 1;
					}
				}
				for (int k = 0; k < 29; k++)
				{
					if (ntZJMMLDNppJFyxcEJhPKrldSpyH().kSXIcavTFqEOGTiKlNkRSDzrRnjX(i, k, positiveAxesOnly))
					{
						return i + 1;
					}
				}
			}
			return -1;
		}

		public void SetUnityJoystickId(int joystickId, int unityJoystickId)
		{
			if (CheckInitialized())
			{
				if (!sJwPaphnMJCMJkgqAeoxPkqvHssEb)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
				}
				else
				{
					LDKYdkBTvBDiUqmQeCvGVejyVoZQ.SetUnityJoystickId(joystickId, unityJoystickId);
				}
			}
		}

		public bool SetUnityJoystickIdFromAnyButtonPress(int joystickId)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			int unityJoystickIdFromAnyButtonPress = GetUnityJoystickIdFromAnyButtonPress();
			if (unityJoystickIdFromAnyButtonPress < 1)
			{
				return false;
			}
			SetUnityJoystickId(joystickId, unityJoystickIdFromAnyButtonPress);
			return true;
		}

		public bool SetUnityJoystickIdFromAnyButtonOrAxisPress(int joystickId, float axisThreshold, bool positiveAxesOnly)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			int unityJoystickIdFromAnyButtonOrAxisPress = GetUnityJoystickIdFromAnyButtonOrAxisPress(axisThreshold, positiveAxesOnly);
			if (unityJoystickIdFromAnyButtonOrAxisPress < 1)
			{
				return false;
			}
			SetUnityJoystickId(joystickId, unityJoystickIdFromAnyButtonOrAxisPress);
			return true;
		}

		public CustomController GetCustomController(int customControllerId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.cNvGhiLhBqBkMjstwPCFpIgHOEJPA(customControllerId);
		}

		public CustomController[] GetCustomControllers()
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<CustomController>.array;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.dpzWurkNAYaGurHoUPRvylHcBkoc();
		}

		public string[] GetCustomControllerNames()
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<string>.array;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.IzqWIAEvFXrjaSNXLlvongQnbgKU();
		}

		public bool IsCustomControllerAssigned(CustomController customController)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.WUDloiZNdxvQbNtGJfIVecKWjLhEA(customController);
		}

		public bool IsCustomControllerAssigned(int customControllerId)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.MMMvSOKmncavygzMEJgShKKjfqSGA(customControllerId);
		}

		public bool IsCustomControllerAssignedToPlayer(int customControllerId, int playerId)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.UGXkGtHtCqHVtDcoxtHZlZuGVXwk(customControllerId, playerId);
		}

		public void RemoveCustomControllerFromAllPlayers(CustomController customController, bool includeSystemPlayer = true)
		{
			if (CheckInitialized())
			{
				iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.FrIbSVOSopiPWmgCSjakhuZezLrM(customController, includeSystemPlayer);
			}
		}

		public void RemoveCustomControllerFromAllPlayers(int customControllerId, bool includeSystemPlayer = true)
		{
			if (CheckInitialized())
			{
				iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.ZJUYtApoxbyjDmgasUdBiDPrIOIY(customControllerId, includeSystemPlayer);
			}
		}

		public CustomController CreateCustomController(int sourceControllerId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.oaWEUwQBJYSYwzCbnvEfgAPDfPNDA(sourceControllerId);
		}

		public CustomController CreateCustomController(int sourceControllerId, string tag)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			CustomController customController = jCkgZLcnXoMycBxzcMXWvnUfSROEb.oaWEUwQBJYSYwzCbnvEfgAPDfPNDA(sourceControllerId);
			if (customController == null)
			{
				return null;
			}
			customController.tag = tag;
			return customController;
		}

		public bool DestroyCustomController(CustomController customController)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			if (customController == null)
			{
				return false;
			}
			RemoveCustomControllerFromAllPlayers(customController);
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.TfgIHSqQsObdHhgJlJbYDvPtGznq(customController);
		}

		public CustomController GetFirstCustomControllerWithSourceId(int sourceId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.ZReYteTbCRHDzfhYIAYCGBSAabcdb(sourceId);
		}

		public CustomController GetFirstCustomControllerWithTag(string tag)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.coyYsFjtpyMjvGJMHYBJfJddaTdP(tag);
		}

		public IEnumerable<CustomController> CustomControllersWithSourceId(int sourceId)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.MinawsELaisjszvkgzDelEepVYWy(sourceId);
		}

		public IEnumerable<CustomController> CustomControllersWithTag(string tag)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.VxMEqFMbwvBFyrrIjLKlGcpDyDoI(tag);
		}

		public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.yXYcmRWjoOVbDBydITFCFBQJYLPL<TInterface>();
		}

		public Controller GetLastActiveController()
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.ueaTKiPRuPiTOchGFBOpIIIInKSYA();
		}

		public Controller GetLastActiveController(ControllerType controllerType)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.UWMvVlrEwXOGXYrVvAnQboMCavFX(controllerType);
		}

		public T GetLastActiveController<T>() where T : Controller
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.ueaTKiPRuPiTOchGFBOpIIIInKSYA<T>();
		}

		public ControllerType GetLastActiveControllerType()
		{
			if (!CheckInitialized())
			{
				return ControllerType.Keyboard;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.QYuDVUqDNXMdWyVBlAqOaraomLJw();
		}

		public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
		{
			if (CheckInitialized())
			{
				jCkgZLcnXoMycBxzcMXWvnUfSROEb.IYykcTAARAgvwBfmoPUHirUsKBwEA(callback);
			}
		}

		public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
		{
			if (CheckInitialized())
			{
				jCkgZLcnXoMycBxzcMXWvnUfSROEb.itPCDGQNCMUpxUNFoYTUQtGpvKgC(callback, controllerType);
			}
		}

		public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
		{
			if (CheckInitialized())
			{
				jCkgZLcnXoMycBxzcMXWvnUfSROEb.dKTNOqWFTGeLEmKboHtmHsgyIurAA(callback);
			}
		}

		public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
		{
			if (CheckInitialized())
			{
				jCkgZLcnXoMycBxzcMXWvnUfSROEb.sstcjkQjOrWpFkatZvVWsvttrnZQ(callback, controllerType);
			}
		}

		public void ClearLastActiveControllerChangedDelegates()
		{
			if (CheckInitialized())
			{
				jCkgZLcnXoMycBxzcMXWvnUfSROEb.KHuHXIoZMmfDeGmjaoGhoBdZagpy();
			}
		}

		public bool GetAnyButton()
		{
			if (!CheckInitialized())
			{
				return false;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.nYvJgOkjCCMLqIFxktJXOGmmBYvG();
		}

		public bool GetAnyButton(ControllerType controllerType)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.GwOKLpnICKITidiDcUOOMDpxXbMmA(controllerType);
		}

		public bool GetAnyButtonDown()
		{
			if (!CheckInitialized())
			{
				return false;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.IUqghlOmQmFTTfrOwKcSbNbDKPYmB();
		}

		public bool GetAnyButtonDown(ControllerType controllerType)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.HvBYIfDOZcrvaBiYactrcffoxInb(controllerType);
		}

		public bool GetAnyButtonUp()
		{
			if (!CheckInitialized())
			{
				return false;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.fiMbFYkLxEuvoNCowKkiFBmMRHFDb();
		}

		public bool GetAnyButtonUp(ControllerType controllerType)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.LsnPcfHCSwHBPpAlCfeibMcQRxvPA(controllerType);
		}

		public bool GetAnyButtonChanged()
		{
			if (!CheckInitialized())
			{
				return false;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.sNeRFNHzldSwOvacSdXSZIgyIenr();
		}

		public bool GetAnyButtonChanged(ControllerType controllerType)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.xpUWrBEtCkSMDQEvSWBJoTMKwMvT(controllerType);
		}

		public bool GetAnyButtonPrev()
		{
			if (!CheckInitialized())
			{
				return false;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.DrMOrdTzJptTLshRDGKymsEEbyIFA();
		}

		public bool GetAnyButtonPrev(ControllerType controllerType)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.QswDmmYOjhFMFQMFMXFcxCwYVrSE(controllerType);
		}

		public bool AutoAssignJoystick(Joystick joystick)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			if (joystick == null)
			{
				return false;
			}
			if (IsJoystickAssigned(joystick))
			{
				return true;
			}
			iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.AtVdNRhtoEgwPJjBhRmQCdoRWoEO(joystick);
			return IsJoystickAssigned(joystick);
		}

		public void AutoAssignJoysticks()
		{
			if (CheckInitialized())
			{
				int num = joystickCount;
				IList<Joystick> joysticks = Joysticks;
				for (int i = 0; i < num; i++)
				{
					AutoAssignJoystick(joysticks[i]);
				}
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class MappingHelper : CodeHelper
	{
		private static MappingHelper rkGpeFRotOSyyACsNJmqSERfhDNQ;

		internal static MappingHelper mzjLqBoiGuMDjcdPVOUQPEpCJUDK => xHfENUwCqCMayHmpgMGXapCnwHjk();

		public IList<InputMapCategory> MapCategories
		{
			get
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.KGLCPkjegIYRmxgYDEkcEyIXeWcP();
			}
		}

		public IEnumerable<InputMapCategory> UserAssignableMapCategories
		{
			get
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.fkYaCXctyuQobnOHiOHTpLvFKhnR();
			}
		}

		public IList<InputCategory> ActionCategories
		{
			get
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.dldukEmLnWcHWmmZNAgyZwhPimKt();
			}
		}

		public IEnumerable<InputCategory> UserAssignableActionCategories
		{
			get
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.lylgbFHNFybUqvcskVLrtLPYTiaVA();
			}
		}

		public IList<InputLayout> JoystickLayouts
		{
			get
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.AGGQAALOcCGoeEVYdgGAwuMHjxNIA();
			}
		}

		public IList<InputLayout> KeyboardLayouts
		{
			get
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.xiAbwejaFqgDlIbiSFVfGzQleagBb();
			}
		}

		public IList<InputLayout> MouseLayouts
		{
			get
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.uPwNYhKApbdhnmgbIcnffUUEMzMhA();
			}
		}

		public IList<InputLayout> CustomControllerLayouts
		{
			get
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.NlIeCEqkTYVKlNPaZUFcgbvfIhK();
			}
		}

		public IList<InputAction> Actions
		{
			get
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return IsSPFehscBAmxtEADWGWuasjDvqf.zdxfeLDxzrLnPTHJkaqdCRuxfJBcA();
			}
		}

		public IEnumerable<InputAction> UserAssignableActions
		{
			get
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return GSaeDquNrvgMCNAsNvzHXfLVsESw.aJopemPKhGLrvVcwQwSuNCdkHsIv();
			}
		}

		internal static MappingHelper xHfENUwCqCMayHmpgMGXapCnwHjk()
		{
			return rkGpeFRotOSyyACsNJmqSERfhDNQ ?? (rkGpeFRotOSyyACsNJmqSERfhDNQ = new MappingHelper());
		}

		private MappingHelper()
		{
		}

		public InputMapCategory GetMapCategory(int mapCategoryId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetMapCategoryById(mapCategoryId);
		}

		public InputMapCategory GetMapCategory(string name)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetMapCategory(name);
		}

		public int GetMapCategoryId(string name)
		{
			if (!CheckInitialized())
			{
				return -1;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetMapCategoryId(name);
		}

		public IEnumerable<InputMapCategory> MapCategoriesWithTag(string tag)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.NftGzkrXNJoNomrqElzLEhjbseEQ(tag);
		}

		public IEnumerable<InputMapCategory> UserAssignableMapCategoriesWithTag(string tag)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.EObBBElaMgCRLbcyuxiwNRJTjfSD(tag);
		}

		public bool IsMapCategoryUserAssignable(int mapCategoryId)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			return GetMapCategory(mapCategoryId)?.userAssignable ?? false;
		}

		public InputCategory GetActionCategory(int mapCategoryId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetActionCategoryById(mapCategoryId);
		}

		public InputCategory GetActionCategory(string name)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetActionCategory(name);
		}

		public int GetActionCategoryId(string name)
		{
			if (!CheckInitialized())
			{
				return -1;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetActionCategoryId(name);
		}

		public IEnumerable<InputCategory> ActionCategoriesWithTag(string tag)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.omZhprCgbSCJaEsuDekUmlbKoyaWA(tag);
		}

		public IEnumerable<InputCategory> UserAssignableActionCategoriesWithTag(string tag)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GJogoheLZfgnRiTZbkhodAYZEfhyA(tag);
		}

		public bool IsActionCategoryUserAssignable(int mapCategoryId)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			return GetActionCategory(mapCategoryId)?.userAssignable ?? false;
		}

		public InputLayout GetLayout(ControllerType controllerType, int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return controllerType switch
			{
				ControllerType.Joystick => GSaeDquNrvgMCNAsNvzHXfLVsESw.GetJoystickLayoutById(layoutId), 
				ControllerType.Keyboard => GSaeDquNrvgMCNAsNvzHXfLVsESw.GetKeyboardLayoutById(layoutId), 
				ControllerType.Mouse => GSaeDquNrvgMCNAsNvzHXfLVsESw.GetMouseLayoutById(layoutId), 
				ControllerType.Custom => GSaeDquNrvgMCNAsNvzHXfLVsESw.GetCustomControllerLayoutById(layoutId), 
				_ => throw new NotImplementedException(), 
			};
		}

		public InputLayout GetLayout(ControllerType controllerType, string name)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return controllerType switch
			{
				ControllerType.Joystick => GSaeDquNrvgMCNAsNvzHXfLVsESw.GetJoystickLayout(name), 
				ControllerType.Keyboard => GSaeDquNrvgMCNAsNvzHXfLVsESw.GetKeyboardLayout(name), 
				ControllerType.Mouse => GSaeDquNrvgMCNAsNvzHXfLVsESw.GetMouseLayout(name), 
				ControllerType.Custom => GSaeDquNrvgMCNAsNvzHXfLVsESw.GetCustomControllerLayout(name), 
				_ => throw new NotImplementedException(), 
			};
		}

		public int GetLayoutId(ControllerType controllerType, string name)
		{
			if (!CheckInitialized())
			{
				return -1;
			}
			return controllerType switch
			{
				ControllerType.Joystick => GSaeDquNrvgMCNAsNvzHXfLVsESw.GetJoystickLayoutId(name), 
				ControllerType.Keyboard => GSaeDquNrvgMCNAsNvzHXfLVsESw.GetKeyboardLayoutId(name), 
				ControllerType.Mouse => GSaeDquNrvgMCNAsNvzHXfLVsESw.GetMouseLayoutId(name), 
				ControllerType.Custom => GSaeDquNrvgMCNAsNvzHXfLVsESw.GetCustomControllerLayoutId(name), 
				_ => throw new NotImplementedException(), 
			};
		}

		public InputLayout GetJoystickLayout(int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetJoystickLayoutById(layoutId);
		}

		public InputLayout GetJoystickLayout(string name)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetJoystickLayout(name);
		}

		public int GetJoystickLayoutId(string name)
		{
			if (!CheckInitialized())
			{
				return -1;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetJoystickLayoutId(name);
		}

		public InputLayout GetKeyboardLayout(int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetKeyboardLayoutById(layoutId);
		}

		public InputLayout GetKeyboardLayout(string name)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetKeyboardLayout(name);
		}

		public int GetKeyboardLayoutId(string name)
		{
			if (!CheckInitialized())
			{
				return -1;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetKeyboardLayoutId(name);
		}

		public InputLayout GetMouseLayout(int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetMouseLayoutById(layoutId);
		}

		public InputLayout GetMouseLayout(string name)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetMouseLayout(name);
		}

		public int GetMouseLayoutId(string name)
		{
			if (!CheckInitialized())
			{
				return -1;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetMouseLayoutId(name);
		}

		public InputLayout GetCustomControllerLayout(int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetCustomControllerLayoutById(layoutId);
		}

		public InputLayout GetCustomControllerLayout(string name)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetCustomControllerLayout(name);
		}

		public int GetCustomControllerLayoutId(string name)
		{
			if (!CheckInitialized())
			{
				return -1;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetCustomControllerLayoutId(name);
		}

		public IList<InputLayout> MapLayouts(ControllerType controllerType)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
			}
			return controllerType switch
			{
				ControllerType.Joystick => JoystickLayouts, 
				ControllerType.Keyboard => KeyboardLayouts, 
				ControllerType.Mouse => MouseLayouts, 
				ControllerType.Custom => CustomControllerLayouts, 
				_ => throw new NotImplementedException(), 
			};
		}

		public InputAction GetAction(int actionId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetActionById(actionId);
		}

		public InputAction GetAction(string name)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetAction(name);
		}

		public int GetActionId(string name)
		{
			if (!CheckInitialized())
			{
				return -1;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetActionId(name);
		}

		public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.iIwmDVLkaAXbcoSoRaTMVPQyqehH(mapCategoryName, false);
		}

		public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName, bool sort)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.iIwmDVLkaAXbcoSoRaTMVPQyqehH(mapCategoryName, sort);
		}

		public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.SkyggREfKoHWjPoLUZZdEbJuIpDsA(mapCategoryId, false);
		}

		public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId, bool sort)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.SkyggREfKoHWjPoLUZZdEbJuIpDsA(mapCategoryId, sort);
		}

		public IEnumerable<InputAction> ActionsInCategoriesWithTag(string tag)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.VsUjzpARabWnaSvqyqONRgkChBvBA(tag);
		}

		public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.fREfkcIHCttPZUmFsaQmQQrsGLZJA(mapCategoryId, false);
		}

		public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId, bool sort)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.fREfkcIHCttPZUmFsaQmQQrsGLZJA(mapCategoryId, sort);
		}

		public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.IPOjBIqStJVbKHsakMVgJnnOSPUI(mapCategoryName, false);
		}

		public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName, bool sort)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.IPOjBIqStJVbKHsakMVgJnnOSPUI(mapCategoryName, sort);
		}

		public IList<InputBehavior> GetInputBehaviors(int playerId)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.izqLvkKDlFDzgajxGeteFupmnbXi(playerId);
		}

		public IList<InputBehavior> GetSystemPlayerInputBehaviors()
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.izqLvkKDlFDzgajxGeteFupmnbXi(9999999);
		}

		public InputBehavior GetInputBehavior(int playerId, int behaviorId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.uyBqFIyZpwLzlzouiLRXfbnAHPne(playerId, behaviorId);
		}

		public InputBehavior GetInputBehavior(int playerId, string behaviorName)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return jCkgZLcnXoMycBxzcMXWvnUfSROEb.nTzpCiyaupxejSxqAqKddbAtpDvL(playerId, behaviorName);
		}

		public InputBehavior GetSystemPlayerInputBehavior(int behaviorId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return GetInputBehavior(9999999, behaviorId);
		}

		public InputBehavior GetSystemPlayerInputBehavior(string behaviorName)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return GetInputBehavior(9999999, behaviorName);
		}

		public int GetInputBehaviorId(string behaviorName)
		{
			if (!CheckInitialized())
			{
				return -1;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetInputBehaviorId(behaviorName);
		}

		internal InputBehavior mQwYZeFrvpdqLediDjZwEfClgLEKA(int P_0)
		{
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetInputBehaviorById(P_0);
		}

		internal InputBehavior fsbYgdkSfWfbUNXSAAyuCtGRWIwy(string P_0)
		{
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetInputBehavior(P_0);
		}

		public ControllerMap GetControllerMap(int id)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			IList<Player> allPlayers = players.AllPlayers;
			for (int i = 0; i < allPlayers.Count; i++)
			{
				ControllerMap map = allPlayers[i].controllers.maps.GetMap(id);
				if (map != null)
				{
					return map;
				}
			}
			return null;
		}

		public ActionElementMap GetActionElementMap(int id)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			IList<Player> allPlayers = players.AllPlayers;
			for (int i = 0; i < allPlayers.Count; i++)
			{
				foreach (ControllerMap allMap in allPlayers[i].controllers.maps.GetAllMaps())
				{
					if (allMap != null)
					{
						ActionElementMap elementMap = allMap.GetElementMap(id);
						if (elementMap != null)
						{
							return elementMap;
						}
					}
				}
			}
			return null;
		}

		public ControllerMap GetControllerMapInstance(Controller controller, int mapCategoryId, int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			if (controller == null)
			{
				return null;
			}
			return controller.type switch
			{
				ControllerType.Joystick => GetJoystickMapInstance((Joystick)controller, mapCategoryId, layoutId), 
				ControllerType.Keyboard => GetKeyboardMapInstance(mapCategoryId, layoutId), 
				ControllerType.Mouse => GetMouseMapInstance(mapCategoryId, layoutId), 
				ControllerType.Custom => GetCustomControllerMapInstance((CustomController)controller, mapCategoryId, layoutId), 
				_ => throw new NotImplementedException(), 
			};
		}

		public ControllerMap GetControllerMapInstance(Controller controller, string mapCategoryName, string layoutName)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			if (controller == null)
			{
				return null;
			}
			int mapCategoryId = GetMapCategoryId(mapCategoryName);
			if (mapCategoryId < 0)
			{
				return null;
			}
			int layoutId = GetLayoutId(controller.type, layoutName);
			if (layoutId < 0)
			{
				return null;
			}
			return GetControllerMapInstance(controller, mapCategoryId, layoutId);
		}

		public ControllerMap GetControllerMapInstance(ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			int mapCategoryId = GetMapCategoryId(mapCategoryName);
			if (mapCategoryId < 0)
			{
				return null;
			}
			int layoutId = GetLayoutId(controllerIdentifier.controllerType, layoutName);
			if (layoutId < 0)
			{
				return null;
			}
			return GetControllerMapInstance(controllerIdentifier, mapCategoryId, layoutId);
		}

		public ControllerMap GetControllerMapInstance(ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			Controller controller = jCkgZLcnXoMycBxzcMXWvnUfSROEb.yFVHNGFipkTnAhiniBHCFElVkRXm(controllerIdentifier);
			if (controller != null)
			{
				return GetControllerMapInstance(controller, mapCategoryId, layoutId);
			}
			return controllerIdentifier.controllerType switch
			{
				ControllerType.Joystick => GetJoystickMapInstance(controllerIdentifier, mapCategoryId, layoutId), 
				ControllerType.Custom => GetCustomControllerMapInstance(controllerIdentifier, mapCategoryId, layoutId), 
				ControllerType.Keyboard => GetKeyboardMapInstance(mapCategoryId, layoutId), 
				ControllerType.Mouse => GetMouseMapInstance(mapCategoryId, layoutId), 
				_ => throw new NotImplementedException(), 
			};
		}

		public JoystickMap GetJoystickMapInstance(Joystick joystick, int mapCategoryId, int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			if (joystick == null)
			{
				return null;
			}
			JoystickMap joystickMap = GSaeDquNrvgMCNAsNvzHXfLVsESw.HSFpDuCYQzabsUTxQTsPcGMueout(joystick, mapCategoryId, layoutId);
			if (joystickMap != null)
			{
				joystick.dLKEnXOkLZMBMnjljyrBEBHwOgie(joystickMap);
			}
			return joystickMap;
		}

		public JoystickMap GetJoystickMapInstance(Joystick joystick, string mapCategoryName, string layoutName)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			int mapCategoryId = GetMapCategoryId(mapCategoryName);
			if (mapCategoryId < 0)
			{
				return null;
			}
			int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
			if (layoutId < 0)
			{
				return null;
			}
			return GetJoystickMapInstance(joystick, mapCategoryId, layoutId);
		}

		public JoystickMap GetJoystickMapInstance(Guid joystickTypeGuid, int mapCategoryId, int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			if (joystickTypeGuid == Guid.Empty)
			{
				return null;
			}
			InputSource inputSourceType = LDKYdkBTvBDiUqmQeCvGVejyVoZQ.inputSourceType;
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = rEHckUItvSTizptREslLvYDLFEArA.XwuIRNgdEYifUEgMMmRtzSqhnLxz(joystickTypeGuid, inputSourceType);
			if (hardwareJoystickMap_InputManager == null)
			{
				Logger.LogError("No hardware map found.");
				return null;
			}
			JoystickMap joystickMap = GSaeDquNrvgMCNAsNvzHXfLVsESw.fhefDsGnvGyvtedaGTaIvgntieZMA(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
			if (joystickMap != null)
			{
				HardwareControllerMap_Game hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
				foreach (ActionElementMap allMap in joystickMap.AllMaps)
				{
					allMap.MsrHnapuLJRPVgecpQsxshWHyuEK(joystickMap, hardwareControllerMap_Game);
				}
			}
			return joystickMap;
		}

		public JoystickMap GetJoystickMapInstance(Guid joystickTypeGuid, string mapCategoryName, string layoutName)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			if (joystickTypeGuid == Guid.Empty)
			{
				return null;
			}
			int mapCategoryId = GetMapCategoryId(mapCategoryName);
			if (mapCategoryId < 0)
			{
				return null;
			}
			int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
			if (layoutId < 0)
			{
				return null;
			}
			return GetJoystickMapInstance(joystickTypeGuid, mapCategoryId, layoutId);
		}

		public JoystickMap GetJoystickMapInstance(ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			if (controllerIdentifier.controllerType != ControllerType.Joystick)
			{
				return null;
			}
			if (jCkgZLcnXoMycBxzcMXWvnUfSROEb.yFVHNGFipkTnAhiniBHCFElVkRXm(controllerIdentifier) is Joystick joystick)
			{
				return GetJoystickMapInstance(joystick, mapCategoryId, layoutId);
			}
			return GetJoystickMapInstance(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
		}

		public JoystickMap GetJoystickMapInstance(ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			int mapCategoryId = GetMapCategoryId(mapCategoryName);
			if (mapCategoryId < 0)
			{
				return null;
			}
			int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
			if (layoutId < 0)
			{
				return null;
			}
			return GetJoystickMapInstance(controllerIdentifier, mapCategoryId, layoutId);
		}

		public KeyboardMap GetKeyboardMapInstance(int mapCategoryId, int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			KeyboardMap keyboardMap = GSaeDquNrvgMCNAsNvzHXfLVsESw.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
			if (keyboardMap != null)
			{
				controllers.Keyboard.dLKEnXOkLZMBMnjljyrBEBHwOgie(keyboardMap);
			}
			return keyboardMap;
		}

		public KeyboardMap GetKeyboardMapInstance(string mapCategoryName, string layoutName)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			int mapCategoryId = GetMapCategoryId(mapCategoryName);
			if (mapCategoryId < 0)
			{
				return null;
			}
			int layoutId = GetLayoutId(ControllerType.Keyboard, layoutName);
			if (layoutId < 0)
			{
				return null;
			}
			return GetKeyboardMapInstance(mapCategoryId, layoutId);
		}

		public MouseMap GetMouseMapInstance(int mapCategoryId, int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			MouseMap mouseMap = GSaeDquNrvgMCNAsNvzHXfLVsESw.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
			if (mouseMap != null)
			{
				controllers.Mouse.dLKEnXOkLZMBMnjljyrBEBHwOgie(mouseMap);
			}
			return mouseMap;
		}

		public MouseMap GetMouseMapInstance(string mapCategoryName, string layoutName)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			int mapCategoryId = GetMapCategoryId(mapCategoryName);
			if (mapCategoryId < 0)
			{
				return null;
			}
			int layoutId = GetLayoutId(ControllerType.Mouse, layoutName);
			if (layoutId < 0)
			{
				return null;
			}
			return GetMouseMapInstance(mapCategoryId, layoutId);
		}

		public CustomControllerMap GetCustomControllerMapInstance(CustomController customController, int mapCategoryId, int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			CustomControllerMap customControllerMap = GSaeDquNrvgMCNAsNvzHXfLVsESw.kICgImNyfVCgjcsYESaTqSPMJsfH(customController.sourceControllerId, mapCategoryId, layoutId);
			if (customControllerMap != null)
			{
				customController.dLKEnXOkLZMBMnjljyrBEBHwOgie(customControllerMap);
			}
			return customControllerMap;
		}

		public CustomControllerMap GetCustomControllerMapInstance(CustomController customController, string mapCategoryName, string layoutName)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			int mapCategoryId = GetMapCategoryId(mapCategoryName);
			if (mapCategoryId < 0)
			{
				return null;
			}
			int layoutId = GetLayoutId(ControllerType.Custom, layoutName);
			if (layoutId < 0)
			{
				return null;
			}
			return GetCustomControllerMapInstance(customController, mapCategoryId, layoutId);
		}

		public CustomControllerMap GetCustomControllerMapInstance(ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			if (controllerIdentifier.controllerType != ControllerType.Custom)
			{
				return null;
			}
			if (jCkgZLcnXoMycBxzcMXWvnUfSROEb.yFVHNGFipkTnAhiniBHCFElVkRXm(controllerIdentifier) is CustomController customController)
			{
				return GetCustomControllerMapInstance(customController, mapCategoryId, layoutId);
			}
			if (controllerIdentifier.hardwareTypeGuid == Guid.Empty)
			{
				return null;
			}
			CustomController_Editor customControllerByHardwareTypeGuid = GSaeDquNrvgMCNAsNvzHXfLVsESw.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
			if (customControllerByHardwareTypeGuid == null)
			{
				return null;
			}
			CustomControllerMap customControllerMap = GSaeDquNrvgMCNAsNvzHXfLVsESw.hbYDQRrxHXJmEhufYerMYJHTEtuB(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
			if (customControllerMap != null)
			{
				HardwareControllerMap_Game hardwareControllerMap_Game = customControllerByHardwareTypeGuid.CreateGameHardwareMap();
				if (hardwareControllerMap_Game == null)
				{
					Logger.LogError("No hardware map found.");
					return null;
				}
				foreach (ActionElementMap allMap in customControllerMap.AllMaps)
				{
					allMap.MsrHnapuLJRPVgecpQsxshWHyuEK(customControllerMap, hardwareControllerMap_Game);
				}
			}
			return customControllerMap;
		}

		public CustomControllerMap GetCustomControllerMapInstance(ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			int mapCategoryId = GetMapCategoryId(mapCategoryName);
			if (mapCategoryId < 0)
			{
				return null;
			}
			int layoutId = GetLayoutId(ControllerType.Custom, layoutName);
			if (layoutId < 0)
			{
				return null;
			}
			return GetCustomControllerMapInstance(controllerIdentifier, mapCategoryId, layoutId);
		}

		public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, Controller controller, int mapCategoryId, int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			if (controller == null)
			{
				return null;
			}
			ControllerMap controllerMap = null;
			if (userDataStore is IControllerMapStore controllerMapStore)
			{
				controllerMap = controllerMapStore.LoadControllerMap(playerId, controller.identifier, mapCategoryId, layoutId);
			}
			if (controllerMap == null)
			{
				controllerMap = GSaeDquNrvgMCNAsNvzHXfLVsESw.AHLAGlhKqFwTnTYyhALfOyZwHEfMA(controller, mapCategoryId, layoutId);
			}
			if (controllerMap != null)
			{
				Player player = players.GetPlayer(playerId);
				if (player != null)
				{
					player.controllers.maps.rDfRPZOWEwhiCARLvGxXFLUmCaieb(controller, controllerMap);
				}
				else
				{
					controller.dLKEnXOkLZMBMnjljyrBEBHwOgie(controllerMap);
				}
			}
			return controllerMap;
		}

		public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, Controller controller, string mapCategoryName, string layoutName)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			if (controller == null)
			{
				return null;
			}
			int mapCategoryId = GetMapCategoryId(mapCategoryName);
			if (mapCategoryId < 0)
			{
				return null;
			}
			int layoutId = GetLayoutId(controller.type, layoutName);
			if (layoutId < 0)
			{
				return null;
			}
			return GetControllerMapInstanceSavedOrDefault(playerId, controller, mapCategoryId, layoutId);
		}

		public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return controllerIdentifier.controllerType switch
			{
				ControllerType.Joystick => GetJoystickMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId), 
				ControllerType.Custom => GetCustomControllerMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId), 
				ControllerType.Keyboard => GetKeyboardMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId), 
				ControllerType.Mouse => GetMouseMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId), 
				_ => throw new NotImplementedException(), 
			};
		}

		public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			int mapCategoryId = GetMapCategoryId(mapCategoryName);
			if (mapCategoryId < 0)
			{
				return null;
			}
			int layoutId = GetLayoutId(controllerIdentifier.controllerType, layoutName);
			if (layoutId < 0)
			{
				return null;
			}
			return GetControllerMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
		}

		public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, Joystick joystick, int mapCategoryId, int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return GetControllerMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId) as JoystickMap;
		}

		public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, Joystick joystick, string mapCategoryName, string layoutName)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			int mapCategoryId = GetMapCategoryId(mapCategoryName);
			if (mapCategoryId < 0)
			{
				return null;
			}
			int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
			if (layoutId < 0)
			{
				return null;
			}
			return GetJoystickMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId);
		}

		public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			if (jCkgZLcnXoMycBxzcMXWvnUfSROEb.yFVHNGFipkTnAhiniBHCFElVkRXm(controllerIdentifier) is Joystick joystick)
			{
				return GetJoystickMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId);
			}
			InputSource inputSourceType = LDKYdkBTvBDiUqmQeCvGVejyVoZQ.inputSourceType;
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = rEHckUItvSTizptREslLvYDLFEArA.XwuIRNgdEYifUEgMMmRtzSqhnLxz(controllerIdentifier.hardwareTypeGuid, inputSourceType);
			if (hardwareJoystickMap_InputManager == null)
			{
				Logger.LogError("No hardware map found.");
				return null;
			}
			JoystickMap joystickMap = null;
			if (userDataStore is IControllerMapStore controllerMapStore)
			{
				joystickMap = controllerMapStore.LoadControllerMap(playerId, controllerIdentifier, mapCategoryId, layoutId) as JoystickMap;
			}
			if (joystickMap == null)
			{
				joystickMap = GSaeDquNrvgMCNAsNvzHXfLVsESw.fhefDsGnvGyvtedaGTaIvgntieZMA(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
			}
			if (joystickMap != null)
			{
				if (players.GetPlayer(playerId) != null)
				{
					joystickMap.tgCplRFOOvjFEJhHddHKDbDkUHnkB(playerId);
				}
				HardwareControllerMap_Game hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
				foreach (ActionElementMap allMap in joystickMap.AllMaps)
				{
					allMap.MsrHnapuLJRPVgecpQsxshWHyuEK(joystickMap, hardwareControllerMap_Game);
				}
			}
			return joystickMap;
		}

		public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			int mapCategoryId = GetMapCategoryId(mapCategoryName);
			if (mapCategoryId < 0)
			{
				return null;
			}
			int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
			if (layoutId < 0)
			{
				return null;
			}
			return GetJoystickMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
		}

		public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, CustomController customController, int mapCategoryId, int layoutId)
		{
			return GetControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId) as CustomControllerMap;
		}

		public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, CustomController customController, string mapCategoryName, string layoutName)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			int mapCategoryId = GetMapCategoryId(mapCategoryName);
			if (mapCategoryId < 0)
			{
				return null;
			}
			int layoutId = GetLayoutId(ControllerType.Custom, layoutName);
			if (layoutId < 0)
			{
				return null;
			}
			return GetCustomControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId);
		}

		public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			if (jCkgZLcnXoMycBxzcMXWvnUfSROEb.yFVHNGFipkTnAhiniBHCFElVkRXm(controllerIdentifier) is CustomController customController)
			{
				return GetCustomControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId);
			}
			CustomController_Editor customControllerByHardwareTypeGuid = GSaeDquNrvgMCNAsNvzHXfLVsESw.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
			if (customControllerByHardwareTypeGuid == null)
			{
				return null;
			}
			CustomControllerMap customControllerMap = null;
			if (userDataStore is IControllerMapStore controllerMapStore)
			{
				customControllerMap = controllerMapStore.LoadControllerMap(playerId, controllerIdentifier, mapCategoryId, layoutId) as CustomControllerMap;
			}
			if (customControllerMap == null)
			{
				customControllerMap = GSaeDquNrvgMCNAsNvzHXfLVsESw.hbYDQRrxHXJmEhufYerMYJHTEtuB(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
			}
			if (customControllerMap != null)
			{
				HardwareControllerMap_Game hardwareControllerMap_Game = customControllerByHardwareTypeGuid.CreateGameHardwareMap();
				if (hardwareControllerMap_Game == null)
				{
					Logger.LogError("No hardware map found.");
					return null;
				}
				if (players.GetPlayer(playerId) != null)
				{
					customControllerMap.tgCplRFOOvjFEJhHddHKDbDkUHnkB(playerId);
				}
				foreach (ActionElementMap allMap in customControllerMap.AllMaps)
				{
					allMap.MsrHnapuLJRPVgecpQsxshWHyuEK(customControllerMap, hardwareControllerMap_Game);
				}
			}
			return customControllerMap;
		}

		public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			int mapCategoryId = GetMapCategoryId(mapCategoryName);
			if (mapCategoryId < 0)
			{
				return null;
			}
			int layoutId = GetLayoutId(ControllerType.Custom, layoutName);
			if (layoutId < 0)
			{
				return null;
			}
			return GetCustomControllerMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
		}

		public KeyboardMap GetKeyboardMapInstanceSavedOrDefault(int playerId, int mapCategoryId, int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			Controller keyboard = controllers.Keyboard;
			KeyboardMap keyboardMap = null;
			if (userDataStore is IControllerMapStore controllerMapStore)
			{
				keyboardMap = controllerMapStore.LoadControllerMap(playerId, keyboard.identifier, mapCategoryId, layoutId) as KeyboardMap;
			}
			if (keyboardMap == null)
			{
				keyboardMap = GSaeDquNrvgMCNAsNvzHXfLVsESw.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
			}
			if (keyboardMap != null)
			{
				Player player = players.GetPlayer(playerId);
				if (player != null)
				{
					player.controllers.maps.rDfRPZOWEwhiCARLvGxXFLUmCaieb(keyboard, keyboardMap);
				}
				else
				{
					keyboard.dLKEnXOkLZMBMnjljyrBEBHwOgie(keyboardMap);
				}
			}
			return keyboardMap;
		}

		public KeyboardMap GetKeyboardMapInstanceSavedOrDefault(int playerId, string mapCategoryName, string layoutName)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			int mapCategoryId = GetMapCategoryId(mapCategoryName);
			if (mapCategoryId < 0)
			{
				return null;
			}
			int layoutId = GetLayoutId(ControllerType.Keyboard, layoutName);
			if (layoutId < 0)
			{
				return null;
			}
			return GetKeyboardMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId);
		}

		public MouseMap GetMouseMapInstanceSavedOrDefault(int playerId, int mapCategoryId, int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			Controller mouse = controllers.Mouse;
			MouseMap mouseMap = null;
			if (userDataStore is IControllerMapStore controllerMapStore)
			{
				mouseMap = controllerMapStore.LoadControllerMap(playerId, mouse.identifier, mapCategoryId, layoutId) as MouseMap;
			}
			if (mouseMap == null)
			{
				mouseMap = GSaeDquNrvgMCNAsNvzHXfLVsESw.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
			}
			if (mouseMap != null)
			{
				Player player = players.GetPlayer(playerId);
				if (player != null)
				{
					player.controllers.maps.rDfRPZOWEwhiCARLvGxXFLUmCaieb(mouse, mouseMap);
				}
				else
				{
					mouse.dLKEnXOkLZMBMnjljyrBEBHwOgie(mouseMap);
				}
			}
			return mouseMap;
		}

		public MouseMap GetMouseMapInstanceSavedOrDefault(int playerId, string mapCategoryName, string layoutName)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			int mapCategoryId = GetMapCategoryId(mapCategoryName);
			if (mapCategoryId < 0)
			{
				return null;
			}
			int layoutId = GetLayoutId(ControllerType.Mouse, layoutName);
			if (layoutId < 0)
			{
				return null;
			}
			return GetMouseMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId);
		}

		[Obsolete("This method has been deprecated. Use the Controller Template system instead.", false)]
		public ControllerElementIdentifier GetFirstJoystickTemplateElementIdentifier(Joystick joystick, int joystickElementIdentifierId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			if (joystick == null)
			{
				return null;
			}
			return MaCRqNOyMqgUzOwFowioHfLHnout(joystick.hardwareTypeGuid, joystickElementIdentifierId);
		}

		private ControllerElementIdentifier MaCRqNOyMqgUzOwFowioHfLHnout(Guid P_0, int P_1)
		{
			HardwareJoystickMap hardwareControllerMap;
			return rEHckUItvSTizptREslLvYDLFEArA.DISaiguSIeRYlnuXBibYOhOBWeay(P_0, P_1, out hardwareControllerMap)?.ToControllerElementIdentifier(hardwareControllerMap);
		}

		internal int swGRyXRQUOVmtAdNpAhhJtaAiDqs(Guid P_0, Guid P_1, int P_2, List<HardwareControllerTemplateMap.PgcfNfWcImnrYkHGMEnMulFOKNwn> P_3)
		{
			return rEHckUItvSTizptREslLvYDLFEArA.HFYtOexCstXXexTgWMJjYZZaLPzy(P_0, P_1, P_2, P_3);
		}

		public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, int mapCategoryId, int layoutId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.jxnSWikLAkRaTLercDEykvizZMDw(templateTypeGuid, mapCategoryId, layoutId);
		}

		public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, string mapCategoryName, string layoutName)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			int mapCategoryId = GetMapCategoryId(mapCategoryName);
			if (mapCategoryId < 0)
			{
				return null;
			}
			int layoutId = GetLayoutId(ControllerType.Custom, layoutName);
			if (layoutId < 0)
			{
				return null;
			}
			return GetControllerTemplateMapInstance(templateTypeGuid, mapCategoryId, layoutId);
		}

		public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(int id)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetControllerMapLayoutManagerRuleSetById(id)?.ToRuntime();
		}

		public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(string name)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			int controllerMapLayoutManagerRuleSetId = GSaeDquNrvgMCNAsNvzHXfLVsESw.GetControllerMapLayoutManagerRuleSetId(name);
			if (controllerMapLayoutManagerRuleSetId < 0)
			{
				return null;
			}
			return GetControllerMapLayoutManagerRuleSetInstance(controllerMapLayoutManagerRuleSetId);
		}

		public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(int id)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return GSaeDquNrvgMCNAsNvzHXfLVsESw.GetControllerMapEnablerRuleSetById(id)?.ToRuntime();
		}

		public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(string name)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			int controllerMapEnablerRuleSetId = GSaeDquNrvgMCNAsNvzHXfLVsESw.GetControllerMapEnablerRuleSetId(name);
			if (controllerMapEnablerRuleSetId < 0)
			{
				return null;
			}
			return GetControllerMapEnablerRuleSetInstance(controllerMapEnablerRuleSetId);
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class PlayerHelper : CodeHelper
	{
		private static PlayerHelper NOMQpDpZcASUbIbSPBkvdpsNKqPD;

		internal static PlayerHelper TydtkfRwicAYwrDRHtMKegCbqfVy => FCkMbMUbIYQXpwvuoQocTbjBbvREA();

		public int playerCount
		{
			get
			{
				if (!CheckInitialized())
				{
					return 0;
				}
				return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.hUvGgieeUHPERTuNwsrVwxUSzbGsA();
			}
		}

		public int allPlayerCount
		{
			get
			{
				if (!CheckInitialized())
				{
					return 0;
				}
				return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.EDgVOlSZldfZdLwENGKrPAFdrHXk();
			}
		}

		public IList<Player> Players
		{
			get
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<Player>.EmptyReadOnlyIListT;
				}
				return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK();
			}
		}

		public IList<Player> AllPlayers
		{
			get
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<Player>.EmptyReadOnlyIListT;
				}
				return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA();
			}
		}

		public Player SystemPlayer
		{
			get
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.aIWEWBhJOdPKbObSWugNVHKhlmbjA();
			}
		}

		internal static PlayerHelper FCkMbMUbIYQXpwvuoQocTbjBbvREA()
		{
			return NOMQpDpZcASUbIbSPBkvdpsNKqPD ?? (NOMQpDpZcASUbIbSPBkvdpsNKqPD = new PlayerHelper());
		}

		private PlayerHelper()
		{
		}

		public IList<Player> GetPlayers(bool includeSystemPlayer = false)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<Player>.EmptyReadOnlyIListT;
			}
			if (!includeSystemPlayer)
			{
				return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.rUjFidcPCnnbRlfRlnVMNbJHbHAK();
			}
			return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.YFfklZQPcnbKRfkKpicSsOCMtOngA();
		}

		public Player GetPlayer(int playerId)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.fucJiwJzRsWBBQakvQMUMarJaFob(playerId);
		}

		public Player GetPlayer(string name)
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.ZfwWgflvHlqQxkMonGglAIcEnDUNA(name);
		}

		public Player GetSystemPlayer()
		{
			if (!CheckInitialized())
			{
				return null;
			}
			return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.aIWEWBhJOdPKbObSWugNVHKhlmbjA();
		}

		public int GetPlayerId(string playerName)
		{
			if (!CheckInitialized())
			{
				return -1;
			}
			return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.yxksTnTkZhPFcRqEkjAtQanVpBwV(playerName);
		}

		public string[] GetPlayerNames(bool includeSystemPlayer = false)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<string>.array;
			}
			return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.chaHKoSSzwMskPDTTZuXolmSjfty(includeSystemPlayer);
		}

		public string[] GetPlayerDescriptiveNames(bool includeSystemPlayer = false)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<string>.array;
			}
			return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.RcqbCVhBYKhDQlrSluIHkKPcznxUA(includeSystemPlayer);
		}

		public int[] GetPlayerIds(bool includeSystemPlayer = false)
		{
			if (!CheckInitialized())
			{
				return EmptyObjects<int>.array;
			}
			return iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.xANjQlcwifYpKrbzIRmXAjgXBGKHA(includeSystemPlayer);
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class TimeHelper : CodeHelper
	{
		private static TimeHelper wPTRIXJhagQitjtmHuDAqQGLpHfW;

		internal static TimeHelper IBhfWqfuOSeZvBTNCfaXGlGGsjjMd => cYcEPoVAyiCWgEUSNtdCRsghIklCA();

		public float unscaledDeltaTime
		{
			get
			{
				if (!CheckInitialized())
				{
					return 0f;
				}
				return (float)FKxLJdNmjvXkvQmEKBKJBzHUMTReA.SmrMnDPKLsTEjALLVciIZcYXZAnx();
			}
		}

		public double unscaledTime
		{
			get
			{
				if (!CheckInitialized())
				{
					return 0.0;
				}
				return FKxLJdNmjvXkvQmEKBKJBzHUMTReA.IaqAusrFmHHLEBgApSDabLcVtRqCb();
			}
		}

		public uint currentFrame
		{
			get
			{
				if (!CheckInitialized())
				{
					return 0u;
				}
				return FKxLJdNmjvXkvQmEKBKJBzHUMTReA.PISgPrHSzEStAEJHOMnRFPrqKsmz();
			}
		}

		internal static TimeHelper cYcEPoVAyiCWgEUSNtdCRsghIklCA()
		{
			return wPTRIXJhagQitjtmHuDAqQGLpHfW ?? (wPTRIXJhagQitjtmHuDAqQGLpHfW = new TimeHelper());
		}

		private TimeHelper()
		{
		}
	}

	private class tpvMtijIgvyynGcKqmAJeacXwhgn
	{
		private class aLeDUnkRPuPSKRHAuottYcxGfCyf
		{
			public readonly UpdateLoopType jyZZxMfiqkbcvcbCkeIYutAvOafR;

			private double kyQfoGjnMmQUubXMjXLRTtvXiiBhb;

			private double koSFEOoAlcBXsduMpKKKJxTOOzUg;

			private double zjyOGJpgKTENeDtruqnpsXDydVat;

			private double sjRNobpWiaIRYeDwAOxVmjhacUNu;

			private uint iVbChIaSeibCuzvXOoUcxSgtByhB;

			private uint ZpqxpbWUtYUoKEoZFwNjLJvIkvmI;

			private float OvqJjTNuouYmDRSydDNTeJNXeKpk;

			private float LgZyfwGeZESLQYKokdMwQTJuFoID;

			public double ayBOHfHIduDNLheNMcJKJfHeXDIR => hUOMPEiRDcGUQTqySEgobpmaJMZrA();

			public double gEzHCXJZdtqzHFEaDbprIKCDnuxeb => mKNmXoBcLJbWAiUMcSWpzOmjxgXk();

			public double DDuaLCohmImcgKFshlsYylwrxRRm => BMSKGHhAxoMsgiQzlKgLuCqdGoSN();

			public uint yfOQyrRiJtgwETdVRzndGxlkOZhe => QYzkUWpOXNrMBjZFiVNAarVuZbEF();

			public uint MtHbjChLRJZXQIIbhYmUyFfNQtDE => FgEZGuQqvtTxYpbSxAaPhxZtvUfK();

			public float ETExILyjziSYOhdiKzjGHdCGXdAW => bGYTqTOpcWFFWkYPdrNYAXEUnkTDA();

			public float mqZcpJGPKREKlZlZbKKnvnpjxuIGA => ZDmbopiRLJwdItoeytmisNDGJUYI();

			public double hUOMPEiRDcGUQTqySEgobpmaJMZrA()
			{
				return kyQfoGjnMmQUubXMjXLRTtvXiiBhb;
			}

			public double mKNmXoBcLJbWAiUMcSWpzOmjxgXk()
			{
				return koSFEOoAlcBXsduMpKKKJxTOOzUg;
			}

			public double BMSKGHhAxoMsgiQzlKgLuCqdGoSN()
			{
				return zjyOGJpgKTENeDtruqnpsXDydVat;
			}

			public uint QYzkUWpOXNrMBjZFiVNAarVuZbEF()
			{
				return iVbChIaSeibCuzvXOoUcxSgtByhB;
			}

			public uint FgEZGuQqvtTxYpbSxAaPhxZtvUfK()
			{
				return ZpqxpbWUtYUoKEoZFwNjLJvIkvmI;
			}

			public float bGYTqTOpcWFFWkYPdrNYAXEUnkTDA()
			{
				return OvqJjTNuouYmDRSydDNTeJNXeKpk;
			}

			public float ZDmbopiRLJwdItoeytmisNDGJUYI()
			{
				return LgZyfwGeZESLQYKokdMwQTJuFoID;
			}

			public aLeDUnkRPuPSKRHAuottYcxGfCyf(UpdateLoopType P_0)
			{
				jyZZxMfiqkbcvcbCkeIYutAvOafR = P_0;
				sjRNobpWiaIRYeDwAOxVmjhacUNu = Time.realtimeSinceStartup;
				iVbChIaSeibCuzvXOoUcxSgtByhB = 0u;
			}

			public void WMIkrRdBqYexXlxvTkjiyGbyUzpV()
			{
				koSFEOoAlcBXsduMpKKKJxTOOzUg = kyQfoGjnMmQUubXMjXLRTtvXiiBhb;
				kyQfoGjnMmQUubXMjXLRTtvXiiBhb = realTime;
				if (sjRNobpWiaIRYeDwAOxVmjhacUNu > kyQfoGjnMmQUubXMjXLRTtvXiiBhb)
				{
					sjRNobpWiaIRYeDwAOxVmjhacUNu = 0.0;
				}
				zjyOGJpgKTENeDtruqnpsXDydVat = kyQfoGjnMmQUubXMjXLRTtvXiiBhb - sjRNobpWiaIRYeDwAOxVmjhacUNu;
				sjRNobpWiaIRYeDwAOxVmjhacUNu = kyQfoGjnMmQUubXMjXLRTtvXiiBhb;
				ZpqxpbWUtYUoKEoZFwNjLJvIkvmI = iVbChIaSeibCuzvXOoUcxSgtByhB;
				iVbChIaSeibCuzvXOoUcxSgtByhB = MiscTools.Tick(iVbChIaSeibCuzvXOoUcxSgtByhB);
				LgZyfwGeZESLQYKokdMwQTJuFoID = OvqJjTNuouYmDRSydDNTeJNXeKpk;
				OvqJjTNuouYmDRSydDNTeJNXeKpk = IwviHzjnjPftonCgNMJfnYkBwIvy();
				previousFrame = ZpqxpbWUtYUoKEoZFwNjLJvIkvmI;
				currentFrame = iVbChIaSeibCuzvXOoUcxSgtByhB;
				unscaledTime = kyQfoGjnMmQUubXMjXLRTtvXiiBhb;
				unscaledTimePrev = koSFEOoAlcBXsduMpKKKJxTOOzUg;
				unscaledDeltaTime = zjyOGJpgKTENeDtruqnpsXDydVat;
			}
		}

		private static class BdfHgyhhVqhhXBVsoJrnBFoEJaZkb
		{
			public static StopwatchBase ZxxLASwFEwutenDPrzBmmtayczCE => DzloRBKhGvrHzGlrHjRlnpCMcOCIA();

			public static StopwatchBase DzloRBKhGvrHzGlrHjRlnpCMcOCIA()
			{
				if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
				{
					return UnityStopwatch.Global;
				}
				return Rewired.Utils.Classes.Utility.Stopwatch.Global;
			}

			public static StopwatchBase WeKCFqYdcAadmnSfAMrtRXIflQHC()
			{
				if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
				{
					return new UnityStopwatch();
				}
				return new Rewired.Utils.Classes.Utility.Stopwatch();
			}

			public static StopwatchBase TArilNJUvSDGDexGogDXnKsxBDzn()
			{
				if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
				{
					return UnityStopwatch.StartNew();
				}
				return Rewired.Utils.Classes.Utility.Stopwatch.StartNew();
			}
		}

		private StopwatchBase vpltNyKkHoibJWttsZkYIPiRgAUp;

		private double ZUHlLxGWTvHyDFfOigoUAlPGKYHbb;

		private aLeDUnkRPuPSKRHAuottYcxGfCyf fMkqGNDFvtBBkHVBPpfrkasBVQYX;

		private ADictionary<int, aLeDUnkRPuPSKRHAuottYcxGfCyf> CUtVoDruawDHHylMZxNbBOHdQghL;

		private uint gnuANEhFhJTWOQUtOLVhNoWmCAMmA;

		public double leiFOHKbwNVAHikPczNwUTVRrRmhA => IaqAusrFmHHLEBgApSDabLcVtRqCb();

		public double zQYtDrMEtpKDmcElqtPzaEUTTIlM => dwtTSecWUqPSjhhgIgFlBVgSrLxD();

		public double qczfjkFycVbbGbpSrhIYsKkjGplwA => SmrMnDPKLsTEjALLVciIZcYXZAnx();

		public float hZIUXmisHrWNgyekjFVxbkBeJrBlA => KcZmTvKKBmjhfuFFWEQwuhPqpEwD();

		public float qjuUFoqxUHKqUoZVDHsRFgKCcpeHA => rNaMdusOHpgwcfvUZbWVwEfYkswv();

		internal double xgTdJyXFfGDtqMbqxnKoTupZbWif => jufkhDEMTYMrbFnqHNQYbhioylkU();

		public uint uipbPMcmwKMYkRLwGqosIsjUFSAfA => PISgPrHSzEStAEJHOMnRFPrqKsmz();

		public uint yHGvXqdQIQPMpklhnlqsGDqNZflI => ILjlDMeRLtbBnHznBxrYprXuAJzb();

		public uint WyLXCYxoTBNsrWhFbDYmoFPIDryW => JfRwNlnzEzBcTsEpAZxOZsjEzGYB();

		public double IaqAusrFmHHLEBgApSDabLcVtRqCb()
		{
			return fMkqGNDFvtBBkHVBPpfrkasBVQYX.hUOMPEiRDcGUQTqySEgobpmaJMZrA();
		}

		public double dwtTSecWUqPSjhhgIgFlBVgSrLxD()
		{
			return fMkqGNDFvtBBkHVBPpfrkasBVQYX.mKNmXoBcLJbWAiUMcSWpzOmjxgXk();
		}

		public double SmrMnDPKLsTEjALLVciIZcYXZAnx()
		{
			return fMkqGNDFvtBBkHVBPpfrkasBVQYX.BMSKGHhAxoMsgiQzlKgLuCqdGoSN();
		}

		public float KcZmTvKKBmjhfuFFWEQwuhPqpEwD()
		{
			return fMkqGNDFvtBBkHVBPpfrkasBVQYX.bGYTqTOpcWFFWkYPdrNYAXEUnkTDA();
		}

		public float rNaMdusOHpgwcfvUZbWVwEfYkswv()
		{
			return fMkqGNDFvtBBkHVBPpfrkasBVQYX.ZDmbopiRLJwdItoeytmisNDGJUYI();
		}

		internal double jufkhDEMTYMrbFnqHNQYbhioylkU()
		{
			return vpltNyKkHoibJWttsZkYIPiRgAUp.elapsedSeconds + ZUHlLxGWTvHyDFfOigoUAlPGKYHbb;
		}

		public uint PISgPrHSzEStAEJHOMnRFPrqKsmz()
		{
			return fMkqGNDFvtBBkHVBPpfrkasBVQYX.QYzkUWpOXNrMBjZFiVNAarVuZbEF();
		}

		public uint ILjlDMeRLtbBnHznBxrYprXuAJzb()
		{
			return fMkqGNDFvtBBkHVBPpfrkasBVQYX.FgEZGuQqvtTxYpbSxAaPhxZtvUfK();
		}

		public uint JfRwNlnzEzBcTsEpAZxOZsjEzGYB()
		{
			return gnuANEhFhJTWOQUtOLVhNoWmCAMmA;
		}

		public tpvMtijIgvyynGcKqmAJeacXwhgn()
		{
			vpltNyKkHoibJWttsZkYIPiRgAUp = BdfHgyhhVqhhXBVsoJrnBFoEJaZkb.DzloRBKhGvrHzGlrHjRlnpCMcOCIA();
			JOiaTbMthZZjlLpcDIygkJtJbfZeA();
		}

		public void EomtxvlJOVvZhGIIgwUHlMfUeOXG()
		{
			ZUHlLxGWTvHyDFfOigoUAlPGKYHbb = Time.realtimeSinceStartup;
		}

		public void JOiaTbMthZZjlLpcDIygkJtJbfZeA()
		{
			fMkqGNDFvtBBkHVBPpfrkasBVQYX = null;
			CUtVoDruawDHHylMZxNbBOHdQghL = new ADictionary<int, aLeDUnkRPuPSKRHAuottYcxGfCyf>();
			using TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3);
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes((UpdateLoopSetting)(-1), list);
			for (int i = 0; i < list.Count; i++)
			{
				aLeDUnkRPuPSKRHAuottYcxGfCyf value = new aLeDUnkRPuPSKRHAuottYcxGfCyf(list[i]);
				CUtVoDruawDHHylMZxNbBOHdQghL.Add((int)list[i], value);
				if (fMkqGNDFvtBBkHVBPpfrkasBVQYX == null)
				{
					fMkqGNDFvtBBkHVBPpfrkasBVQYX = value;
				}
			}
		}

		public void VgJNWrMtvBgAscBzVMjdMaoUcMshA(UpdateLoopType P_0)
		{
			if (fMkqGNDFvtBBkHVBPpfrkasBVQYX.jyZZxMfiqkbcvcbCkeIYutAvOafR != P_0)
			{
				fMkqGNDFvtBBkHVBPpfrkasBVQYX = CUtVoDruawDHHylMZxNbBOHdQghL.get_Item((int)P_0);
			}
			if (P_0 != UpdateLoopType.OnGUI || Event.current.rawType == EventType.Layout)
			{
				fMkqGNDFvtBBkHVBPpfrkasBVQYX.WMIkrRdBqYexXlxvTkjiyGbyUzpV();
				gnuANEhFhJTWOQUtOLVhNoWmCAMmA = MiscTools.Tick(gnuANEhFhJTWOQUtOLVhNoWmCAMmA);
				absFrame = gnuANEhFhJTWOQUtOLVhNoWmCAMmA;
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class UnityTouch : CodeHelper
	{
		private static UnityTouch FUklCwOsFOTUwqbcxQTJczEsWAQd;

		internal static UnityTouch dlVbhdEWZRTYAheiyiLirZQmhLcBA => IPjenODOrubLUzmTEceMSVNSALcoA();

		public int touchCount => Input.touchCount;

		public Touch[] touches => Input.touches;

		public bool simulateMouseWithTouches
		{
			get
			{
				return Input.simulateMouseWithTouches;
			}
			set
			{
				Input.simulateMouseWithTouches = value;
			}
		}

		public bool multiTouchEnabled
		{
			get
			{
				return Input.multiTouchEnabled;
			}
			set
			{
				Input.multiTouchEnabled = value;
			}
		}

		internal static UnityTouch IPjenODOrubLUzmTEceMSVNSALcoA()
		{
			return FUklCwOsFOTUwqbcxQTJczEsWAQd ?? (FUklCwOsFOTUwqbcxQTJczEsWAQd = new UnityTouch());
		}

		private UnityTouch()
		{
		}

		public Touch GetTouch(int index)
		{
			return Input.GetTouch(index);
		}
	}

	internal class OkkiCFiYKtSSxTplFjKjVcmCHvOn
	{
		[Serializable]
		private sealed class JYyfdRISRKiQkGgJgalCzoThopym
		{
			public static readonly JYyfdRISRKiQkGgJgalCzoThopym _003C_003E9 = new JYyfdRISRKiQkGgJgalCzoThopym();

			public static Func<bool> _003C_003E9__12_1;

			public static Func<bool> _003C_003E9__12_2;

			public static Func<int> _003C_003E9__12_3;

			public static Func<float> _003C_003E9__12_4;

			public static Func<bool> _003C_003E9__12_5;

			public static Func<string> _003C_003E9__12_0;

			internal bool LXhecxEdgsfrZDaoCQYVQhpQTwmm()
			{
				return Screen.fullScreen;
			}

			internal bool ynSeZobflsHTutWAFTyGnmOUqxqY()
			{
				return Application.runInBackground;
			}

			internal int XGmmPIYKaVgtQIChhlKMZTEHzylc()
			{
				return (int)Screen.fullScreenMode;
			}

			internal float FGtMjAUMKiFaKbTkLpPyxydzmxhO()
			{
				return Time.unscaledDeltaTime;
			}

			internal bool AHinPPlGtxcvrECUTOnCtsqqodtcb()
			{
				return MathTools.ApproximatelyZero(Time.timeScale);
			}

			internal string dauwExnysOfGFIJOVUuCCJdhGodaA()
			{
				return UnityTools.externalTools.GetFocusedEditorWindowTitle();
			}
		}

		public readonly ValueWatcher<bool> LUPravlxwsaWnkpJMDdZCBXoqtre;

		public readonly ValueWatcher<bool> JVzdRvemOzvWdobxhSaGkeyRxRvD;

		public readonly ValueWatcher<bool> nkhtvJYMTLebPhByEUCNfQvwHZkiA;

		public readonly ValueWatcher<bool> XUugLpvcebTXjZrMMPqnTGSddbpQ;

		public readonly ValueWatcher<int> ZasxBVxdAPBcVeTutcOLiPIIQxquB;

		public readonly ValueWatcher<float> ihHvfeEASTpLCUyJOdSbefOwhvRX;

		public readonly ValueWatcher<string> kuEEgrkQPVaNBPAxyTSbQgTyDhcwA;

		public readonly ValueWatcher<bool> fhgELFgzRwCpgdqZJxmTkegmwYPA;

		private int CIjkFMZsKLBipwtrNKSLcvVgEAEy;

		private readonly ValueWatcher[] vmiIOszIFvmCeeUuGZwhQwXBmnUC;

		public int nDsNlCpToYudlZVTqgCjPOtWDIxS => zMsAtVAkDIfPzEBdJKyBuDBqkcAlb();

		public int zMsAtVAkDIfPzEBdJKyBuDBqkcAlb()
		{
			return CIjkFMZsKLBipwtrNKSLcvVgEAEy;
		}

		public OkkiCFiYKtSSxTplFjKjVcmCHvOn()
		{
			bool flag = UnityTools.isEditor || Application.isFocused;
			List<ValueWatcher> list = new List<ValueWatcher>
			{
				(LUPravlxwsaWnkpJMDdZCBXoqtre = new ValueWatcher<bool>(flag, false)),
				(JVzdRvemOzvWdobxhSaGkeyRxRvD = new ValueWatcher<bool>(false, false)),
				(nkhtvJYMTLebPhByEUCNfQvwHZkiA = new ValueWatcher<bool>(Screen.fullScreen, JYyfdRISRKiQkGgJgalCzoThopym._003C_003E9.LXhecxEdgsfrZDaoCQYVQhpQTwmm, false)),
				(XUugLpvcebTXjZrMMPqnTGSddbpQ = new ValueWatcher<bool>(Application.runInBackground, JYyfdRISRKiQkGgJgalCzoThopym._003C_003E9.ynSeZobflsHTutWAFTyGnmOUqxqY, false)),
				(ZasxBVxdAPBcVeTutcOLiPIIQxquB = new ValueWatcher<int>((int)Screen.fullScreenMode, JYyfdRISRKiQkGgJgalCzoThopym._003C_003E9.XGmmPIYKaVgtQIChhlKMZTEHzylc, false)),
				(ihHvfeEASTpLCUyJOdSbefOwhvRX = new ValueWatcher<float>(Time.unscaledDeltaTime, JYyfdRISRKiQkGgJgalCzoThopym._003C_003E9.FGtMjAUMKiFaKbTkLpPyxydzmxhO, false)),
				(fhgELFgzRwCpgdqZJxmTkegmwYPA = new ValueWatcher<bool>(MathTools.ApproximatelyZero(Time.timeScale), JYyfdRISRKiQkGgJgalCzoThopym._003C_003E9.AHinPPlGtxcvrECUTOnCtsqqodtcb, MathTools.ApproximatelyZero(Time.timeScale)))
			};
			if (editorPlatform != EditorPlatform.None)
			{
				list.Add(kuEEgrkQPVaNBPAxyTSbQgTyDhcwA = new ValueWatcher<string>(UnityTools.externalTools.GetFocusedEditorWindowTitle(), JYyfdRISRKiQkGgJgalCzoThopym._003C_003E9.dauwExnysOfGFIJOVUuCCJdhGodaA, false));
			}
			vmiIOszIFvmCeeUuGZwhQwXBmnUC = list.ToArray();
			NpQENMMHxkpQMjsCVVrUsEJZDGj();
		}

		public void NpQENMMHxkpQMjsCVVrUsEJZDGj()
		{
			for (int i = 0; i < vmiIOszIFvmCeeUuGZwhQwXBmnUC.Length; i++)
			{
				vmiIOszIFvmCeeUuGZwhQwXBmnUC[i].Update();
			}
			CIjkFMZsKLBipwtrNKSLcvVgEAEy = Time.frameCount;
		}

		public void yBsdIdbTfLslaBUSeQhTAXywHmGT()
		{
			for (int i = 0; i < vmiIOszIFvmCeeUuGZwhQwXBmnUC.Length; i++)
			{
				vmiIOszIFvmCeeUuGZwhQwXBmnUC[i].TriggerEvent();
			}
		}
	}

	[Serializable]
	private sealed class yksghDPohDiVhBBTOuqRnvSVqnKx
	{
		public static readonly yksghDPohDiVhBBTOuqRnvSVqnKx _003C_003E9 = new yksghDPohDiVhBBTOuqRnvSVqnKx();

		public static Func<bool> _003C_003E9__235_0;

		internal void MlsASaggFJLYPlGfiplXBfiqaQzT(Exception P_0)
		{
			HandleCallbackException("", P_0);
		}

		internal void QXPMumxbaEkMAnxgmWyXWINfbQZl(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ControllerConnectedEvent", P_0);
		}

		internal void vxlhuVRLyMhKmTwCSXLFcBlewZic(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ControllerPreDisconnectEvent", P_0);
		}

		internal void LvPAZtZdqYECCDAuHPBQkzHVQWYmA(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ControllerDisconnectedEvent", P_0);
		}

		internal void kTpcKlNTKmbTEtiEbmeyvSClwklG(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.InputSourceUpdateEvent", P_0);
		}

		internal void OiFtsqXOQrWLmPzJEkGpbEpvGHHGA(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.EditorRecompileEvent", P_0);
		}

		internal void jDkIouwaZlMJOgKLezkkMCizBJbBA(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.PreShutDownEvent", P_0);
		}

		internal void hZtIqeALYEmRarpNnjjlrxkBGOCE(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ShutDownEvent", P_0);
		}

		internal void RnHroAceqsGRVKLVvoYRGJEdlvVpc(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.InitializedEvent", P_0);
		}

		internal bool OhwWgCyvAkDEMyAZKttlosrOmZiA()
		{
			if (isUnityEditorFocused)
			{
				return isAllowedEditorWindowFocused;
			}
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	internal const int programVersion1 = 1;

	[CustomObfuscation(rename = false)]
	internal const int programVersion2 = 1;

	[CustomObfuscation(rename = false)]
	internal const int programVersion3 = 58;

	[CustomObfuscation(rename = false)]
	internal const int programVersion4 = 2;

	[CustomObfuscation(rename = false)]
	internal const int dataVersion = 1;

	[CustomObfuscation(rename = false)]
	internal const bool isTrial = false;

	[CustomObfuscation(rename = false)]
	internal const string majorBranch = "U2022";

	private static InputManager_Base KRXMNGqTUEuSZnzlexLlRTibdOwA;

	private static PlatformInputManager LDKYdkBTvBDiUqmQeCvGVejyVoZQ;

	internal static lQoAAQNPpFWyUNnFoiTjITGTmsQh IsSPFehscBAmxtEADWGWuasjDvqf;

	internal static rrNUAxqqEizlnWVKRaqVmKdJebkM jCkgZLcnXoMycBxzcMXWvnUfSROEb;

	internal static PZIrFQmTYjOFmeiRPrMzBSOSvuwD iJRGiWfOZRwVGgOxWlHrWBzdJmvdA;

	private static ControllerDataFiles rEHckUItvSTizptREslLvYDLFEArA;

	private static UserData GSaeDquNrvgMCNAsNvzHXfLVsESw;

	private static bool UJsvrGEMKlXkCjGlrRbNmdqzObVj;

	private static ConfigVars yZbloWHGkzkpTWiASTPgAShwAgah;

	private static UpdateLoopType DsvcxYMJbnguNBHofUwSPPVGobOI;

	private static bool sJwPaphnMJCMJkgqAeoxPkqvHssEb;

	private static Platform mEwnOsXbuQEGmLDxEkROAPjAjYOT;

	private static WebplayerPlatform LTMHQkwtBevmTaFeQRmrJrgDCMzf;

	private static EditorPlatform rOxPDwAkwXFgbfLssjclSsErUCBWA;

	private static bool dfJsCIHzUmwVRICvbHzjezzieXwf;

	private static TimerAbs AqWIRNEeuVzYaXnHqgMlrUpSDKyg;

	private static tpvMtijIgvyynGcKqmAJeacXwhgn FKxLJdNmjvXkvQmEKBKJBzHUMTReA;

	private static string gucurGOUjhxvvYQarpsrYhilGfSiA;

	private static bool cRVaiuBtmpcxTgtzwaDWmCEQsccv;

	private static bool LpBnqxdWJJFMwYJxdaJtCrRYMHDB;

	private static bool JNicJPqehYVSsevadzMHTHnWffzh;

	private static int WKGQErYGqxYWkTzYcqmnNwNQAVPn;

	[CustomObfuscation(rename = false)]
	internal static int _id;

	private static int sJIEwcKuQvmyFfDKuBxigXndloYnA;

	private static int TNFnJuFPVFFcKErUnlbyWKLMKEmb;

	private static bool AuSbamOqiesJxxIIDbYQFwfSutfu;

	private static readonly UnityTouch uxIqvIOVKwREJbTltMrNNClEBfvN;

	private static readonly PlayerHelper xwrLOKTxYJnsbGDarnPCXoDcLJxt;

	private static readonly ControllerHelper AkAQMgXaKaTPPGyeZJtlKaMrfzDGA;

	private static readonly MappingHelper nowronjolYHCZmQmDOsBfzQifayW;

	private static readonly TimeHelper vDNPQlhiBNWlrxOoIXpnNhIFyCpD;

	private static readonly ConfigHelper vuLhTsAbMqbJTxoXTwWTMcyWkfYE;

	private static readonly LocalizationHelper HOgGGTFDVaCkxTXUyiPBEFDykOH;

	private static readonly GlyphHelper CgAeRHunfdTLxinuaTvEGnYfXqIW;

	private static QhiddugZGpIeVluIsyWwoiQEhHjf SGdcxAVhuyCMLJBfzNtvXvjDZqzG;

	private static UserDataStore iLHKRkdaCZktMmwChlBmDYIPJikk;

	private static IControllerAssigner bwpygVfTeDmccDbXCbTQjMpOrRRUA;

	private static OkkiCFiYKtSSxTplFjKjVcmCHvOn uWFGARmQSApmyFkxwRvhWWkwDohH;

	private static SafeAction<ControllerStatusChangedEventArgs> uvMukUaxTeFVeHXdjVdnMUQlUqpA;

	private static SafeAction<ControllerStatusChangedEventArgs> DPHkUlVeUOBBWWEHtZvOdLaKhokA;

	private static SafeAction<ControllerStatusChangedEventArgs> yWPZNfBshompeDjslhdxWrPJAwHt;

	private static SafeAction fwNSFuVOVEJhuGmCVeUflVgzJzTh;

	private static SafeAction XxpHBczYGUVjhwHeWtgVFAVgDDED;

	private static SafeAction LKHDdmdZDCktRkapcYDDWKbWPCrWA;

	private static SafeAction JJJFLFHsalfWgHTQOpvSTCRWouZMA;

	private static SafeAction LftZqMUTvYXewBXJKtrsPSxZKUHh;

	[CustomObfuscation(rename = false)]
	private static Action<bool> _ApplicationFocusChangedEvent;

	[CustomObfuscation(rename = false)]
	private static Action<bool> _ApplicationPauseChangedEvent;

	private static Action FdqumDzCZBZGxBYTSqwAgbomKxbe;

	private static Action<UpdateLoopType> BzjHFahIyiZUfjiytewhpnyyWjui;

	private static Action<UpdateLoopType> xzwIJYhyfIkTzWqlCCzfpyozvkLf;

	private static Action<UpdateLoopType> EsvUkTdIXotrlNMHxEhOYbDisLeM;

	private static Action pYLfGEUXIhZwLcTEQckceNVZwXOB;

	private static Action<bool> jhfEhJVTAtaukEVLNnMsaBKYsRoo;

	private static Action<bool> GxIecdQzTjppWTXsXxbmwupczDYE;

	private static Action<bool> yXmESBRKmvEpMuLxNCamFxEWigYA;

	private static Action<FullScreenMode> kUARjFQVZPLxFTSDhiFNQhjKSloP;

	private static Action trUnRAyQAVMTokoYwParVtbfvitf;

	private static Action<bool> FKuNsEflurOJwjEnJrKWOAMINTyO;

	[CustomObfuscation(rename = false)]
	internal static double unscaledDeltaTime;

	[CustomObfuscation(rename = false)]
	internal static double unscaledTime;

	[CustomObfuscation(rename = false)]
	internal static double unscaledTimePrev;

	[CustomObfuscation(rename = false)]
	internal static uint currentFrame;

	[CustomObfuscation(rename = false)]
	internal static uint previousFrame;

	[CustomObfuscation(rename = false)]
	internal static uint absFrame;

	private static QhiddugZGpIeVluIsyWwoiQEhHjf ndDXDrmhXHUwxItsPGsSAhIlylnm => ntZJMMLDNppJFyxcEJhPKrldSpyH();

	public static PlayerHelper players
	{
		get
		{
			if (!UJsvrGEMKlXkCjGlrRbNmdqzObVj)
			{
				CcEmyIndYqeirDbCynzgLUKzCRYGA();
				return null;
			}
			return xwrLOKTxYJnsbGDarnPCXoDcLJxt;
		}
	}

	public static ControllerHelper controllers
	{
		get
		{
			if (!UJsvrGEMKlXkCjGlrRbNmdqzObVj)
			{
				CcEmyIndYqeirDbCynzgLUKzCRYGA();
				return null;
			}
			return AkAQMgXaKaTPPGyeZJtlKaMrfzDGA;
		}
	}

	public static MappingHelper mapping
	{
		get
		{
			if (!UJsvrGEMKlXkCjGlrRbNmdqzObVj)
			{
				CcEmyIndYqeirDbCynzgLUKzCRYGA();
				return null;
			}
			return nowronjolYHCZmQmDOsBfzQifayW;
		}
	}

	public static UnityTouch touch
	{
		get
		{
			if (!UJsvrGEMKlXkCjGlrRbNmdqzObVj)
			{
				CcEmyIndYqeirDbCynzgLUKzCRYGA();
				return null;
			}
			return uxIqvIOVKwREJbTltMrNNClEBfvN;
		}
	}

	public static TimeHelper time
	{
		get
		{
			if (!UJsvrGEMKlXkCjGlrRbNmdqzObVj)
			{
				CcEmyIndYqeirDbCynzgLUKzCRYGA();
				return null;
			}
			return vDNPQlhiBNWlrxOoIXpnNhIFyCpD;
		}
	}

	public static IUserDataStore userDataStore
	{
		get
		{
			if (!UJsvrGEMKlXkCjGlrRbNmdqzObVj)
			{
				CcEmyIndYqeirDbCynzgLUKzCRYGA();
				return null;
			}
			return iLHKRkdaCZktMmwChlBmDYIPJikk;
		}
	}

	public static ConfigHelper configuration
	{
		get
		{
			if (!UJsvrGEMKlXkCjGlrRbNmdqzObVj)
			{
				CcEmyIndYqeirDbCynzgLUKzCRYGA();
				return null;
			}
			return vuLhTsAbMqbJTxoXTwWTMcyWkfYE;
		}
	}

	public static LocalizationHelper localization
	{
		get
		{
			if (!UJsvrGEMKlXkCjGlrRbNmdqzObVj)
			{
				CcEmyIndYqeirDbCynzgLUKzCRYGA();
				return null;
			}
			return HOgGGTFDVaCkxTXUyiPBEFDykOH;
		}
	}

	public static GlyphHelper glyphs
	{
		get
		{
			if (!UJsvrGEMKlXkCjGlrRbNmdqzObVj)
			{
				CcEmyIndYqeirDbCynzgLUKzCRYGA();
				return null;
			}
			return CgAeRHunfdTLxinuaTvEGnYfXqIW;
		}
	}

	public static string programVersion => 1 + "." + 1 + "." + 58 + "." + 2 + ".U2022";

	public static bool usingUnityInput => sJwPaphnMJCMJkgqAeoxPkqvHssEb;

	public static bool unityJoystickIdentificationRequired
	{
		get
		{
			if (!UJsvrGEMKlXkCjGlrRbNmdqzObVj)
			{
				return false;
			}
			if (isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
			{
				return true;
			}
			return false;
		}
	}

	public static bool isReady => UJsvrGEMKlXkCjGlrRbNmdqzObVj;

	[CustomObfuscation(rename = false)]
	internal static int id => _id;

	[CustomObfuscation(rename = false)]
	internal static bool initialized => UJsvrGEMKlXkCjGlrRbNmdqzObVj;

	[CustomObfuscation(rename = false)]
	internal static UpdateLoopType currentUpdateLoop => DsvcxYMJbnguNBHofUwSPPVGobOI;

	[CustomObfuscation(rename = false)]
	internal static ConfigVars configVars => yZbloWHGkzkpTWiASTPgAShwAgah;

	[CustomObfuscation(rename = false)]
	internal static IConfigVars_Internal pluginConfigVars => yZbloWHGkzkpTWiASTPgAShwAgah;

	[CustomObfuscation(rename = false)]
	internal static UserData UserData => GSaeDquNrvgMCNAsNvzHXfLVsESw;

	[CustomObfuscation(rename = false)]
	internal static Platform currentPlatform => mEwnOsXbuQEGmLDxEkROAPjAjYOT;

	[CustomObfuscation(rename = false)]
	internal static WebplayerPlatform webplayerPlatform => LTMHQkwtBevmTaFeQRmrJrgDCMzf;

	[CustomObfuscation(rename = false)]
	internal static EditorPlatform editorPlatform => rOxPDwAkwXFgbfLssjclSsErUCBWA;

	[CustomObfuscation(rename = false)]
	internal static bool checkNeverPressed
	{
		get
		{
			if (mEwnOsXbuQEGmLDxEkROAPjAjYOT == Platform.Linux && sJwPaphnMJCMJkgqAeoxPkqvHssEb)
			{
				return true;
			}
			if (mEwnOsXbuQEGmLDxEkROAPjAjYOT == Platform.OSX && (sJwPaphnMJCMJkgqAeoxPkqvHssEb || primaryInputManager.inputSourceType == InputSource.OSX))
			{
				return true;
			}
			if (UnityTools.isAndroidPlatform && sJwPaphnMJCMJkgqAeoxPkqvHssEb)
			{
				return true;
			}
			if (mEwnOsXbuQEGmLDxEkROAPjAjYOT == Platform.Webplayer && LTMHQkwtBevmTaFeQRmrJrgDCMzf == WebplayerPlatform.OSX)
			{
				return true;
			}
			if (mEwnOsXbuQEGmLDxEkROAPjAjYOT == Platform.WebGL)
			{
				return true;
			}
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	internal static bool isEditor => rOxPDwAkwXFgbfLssjclSsErUCBWA != EditorPlatform.None;

	[CustomObfuscation(rename = false)]
	internal static Guid defaultHardwareJoystickMapGuid
	{
		get
		{
			if (!UJsvrGEMKlXkCjGlrRbNmdqzObVj)
			{
				return Guid.Empty;
			}
			return rEHckUItvSTizptREslLvYDLFEArA.defaultHardwareJoystickMapGuid;
		}
	}

	[CustomObfuscation(rename = false)]
	internal static bool isRunningInEditMode => LpBnqxdWJJFMwYJxdaJtCrRYMHDB;

	[CustomObfuscation(rename = false)]
	internal static bool isEditorPaused => UnityTools.externalTools.isEditorPaused;

	[CustomObfuscation(rename = false)]
	internal static float unityUnscaledDeltaTime => FKxLJdNmjvXkvQmEKBKJBzHUMTReA.KcZmTvKKBmjhfuFFWEQwuhPqpEwD();

	[CustomObfuscation(rename = false)]
	internal static float unityUnscaledDeltaTimePrev => FKxLJdNmjvXkvQmEKBKJBzHUMTReA.rNaMdusOHpgwcfvUZbWVwEfYkswv();

	[CustomObfuscation(rename = false)]
	internal static double realTime
	{
		get
		{
			if (!UJsvrGEMKlXkCjGlrRbNmdqzObVj)
			{
				return 0.0;
			}
			return FKxLJdNmjvXkvQmEKBKJBzHUMTReA.jufkhDEMTYMrbFnqHNQYbhioylkU();
		}
	}

	[CustomObfuscation(rename = false)]
	internal static int currentUnityFrame
	{
		get
		{
			if (!UJsvrGEMKlXkCjGlrRbNmdqzObVj)
			{
				return 0;
			}
			return uWFGARmQSApmyFkxwRvhWWkwDohH.zMsAtVAkDIfPzEBdJKyBuDBqkcAlb();
		}
	}

	private static bool ipcEnGhxozfSXGssrEtAJaYXHSSE => jQZMnpuHLMuvuQLmRXfizlCuninR();

	[CustomObfuscation(rename = false)]
	internal static bool isAllowedEditorWindowFocused
	{
		get
		{
			if (yZbloWHGkzkpTWiASTPgAShwAgah.allowInputInEditorSceneView && UnityTools.externalTools.IsEditorSceneViewFocused())
			{
				return true;
			}
			if (!JNicJPqehYVSsevadzMHTHnWffzh)
			{
				return jQZMnpuHLMuvuQLmRXfizlCuninR();
			}
			return true;
		}
	}

	[CustomObfuscation(rename = false)]
	internal static bool isUnityEditorFocused
	{
		get
		{
			if (LDKYdkBTvBDiUqmQeCvGVejyVoZQ is INativePlatformHelper nativePlatformHelper)
			{
				return nativePlatformHelper.isApplicationFocused;
			}
			return JNicJPqehYVSsevadzMHTHnWffzh;
		}
	}

	[CustomObfuscation(rename = false)]
	internal static bool isWindowsStandaloneWebplayerOrEditorPlatform
	{
		get
		{
			if (!UJsvrGEMKlXkCjGlrRbNmdqzObVj)
			{
				return false;
			}
			if (!sJwPaphnMJCMJkgqAeoxPkqvHssEb)
			{
				return false;
			}
			if (mEwnOsXbuQEGmLDxEkROAPjAjYOT != Platform.Windows && (mEwnOsXbuQEGmLDxEkROAPjAjYOT != Platform.Webplayer || LTMHQkwtBevmTaFeQRmrJrgDCMzf != WebplayerPlatform.Windows))
			{
				return rOxPDwAkwXFgbfLssjclSsErUCBWA == EditorPlatform.Windows;
			}
			return true;
		}
	}

	private static bool EwsRafvthWiovxguTXOLiMkvStlN => ZBUDmHHxrwgiIBStzPamcOElaGtzA();

	[CustomObfuscation(rename = false)]
	internal static bool applicationIsFocused
	{
		get
		{
			if (UJsvrGEMKlXkCjGlrRbNmdqzObVj)
			{
				return uWFGARmQSApmyFkxwRvhWWkwDohH.LUPravlxwsaWnkpJMDdZCBXoqtre.value;
			}
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	internal static bool applicationIsPaused
	{
		get
		{
			if (UJsvrGEMKlXkCjGlrRbNmdqzObVj)
			{
				return uWFGARmQSApmyFkxwRvhWWkwDohH.JVzdRvemOzvWdobxhSaGkeyRxRvD.value;
			}
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	internal static bool applicationIsFullScreen
	{
		get
		{
			if (UJsvrGEMKlXkCjGlrRbNmdqzObVj)
			{
				return uWFGARmQSApmyFkxwRvhWWkwDohH.nkhtvJYMTLebPhByEUCNfQvwHZkiA.value;
			}
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	internal static bool applicationRunInBackground
	{
		get
		{
			if (UJsvrGEMKlXkCjGlrRbNmdqzObVj)
			{
				return uWFGARmQSApmyFkxwRvhWWkwDohH.XUugLpvcebTXjZrMMPqnTGSddbpQ.value;
			}
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	internal static bool timeScaleIsPaused
	{
		get
		{
			if (UJsvrGEMKlXkCjGlrRbNmdqzObVj)
			{
				return uWFGARmQSApmyFkxwRvhWWkwDohH.fhgELFgzRwCpgdqZJxmTkegmwYPA.value;
			}
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	internal static InputManager_Base rewiredInputManager => KRXMNGqTUEuSZnzlexLlRTibdOwA;

	[CustomObfuscation(rename = false)]
	internal static PlatformInputManager primaryInputManager
	{
		get
		{
			if (!UJsvrGEMKlXkCjGlrRbNmdqzObVj)
			{
				CcEmyIndYqeirDbCynzgLUKzCRYGA();
				return null;
			}
			return LDKYdkBTvBDiUqmQeCvGVejyVoZQ.primaryInputManager;
		}
	}

	[CustomObfuscation(rename = false)]
	internal static IControllerAssigner controllerAssigner
	{
		get
		{
			return bwpygVfTeDmccDbXCbTQjMpOrRRUA;
		}
		set
		{
			bwpygVfTeDmccDbXCbTQjMpOrRRUA = value;
		}
	}

	[CustomObfuscation(rename = false)]
	internal static RewiredVersion rewiredVersion => new RewiredVersion(programVersion);

	[CustomObfuscation(rename = false)]
	internal static int timeScalePauseChangedCount => TNFnJuFPVFFcKErUnlbyWKLMKEmb;

	public static event Action<ControllerStatusChangedEventArgs> ControllerConnectedEvent
	{
		add
		{
			uvMukUaxTeFVeHXdjVdnMUQlUqpA += value;
		}
		remove
		{
			uvMukUaxTeFVeHXdjVdnMUQlUqpA -= value;
		}
	}

	public static event Action<ControllerStatusChangedEventArgs> ControllerPreDisconnectEvent
	{
		add
		{
			DPHkUlVeUOBBWWEHtZvOdLaKhokA += value;
		}
		remove
		{
			DPHkUlVeUOBBWWEHtZvOdLaKhokA -= value;
		}
	}

	public static event Action<ControllerStatusChangedEventArgs> ControllerDisconnectedEvent
	{
		add
		{
			yWPZNfBshompeDjslhdxWrPJAwHt += value;
		}
		remove
		{
			yWPZNfBshompeDjslhdxWrPJAwHt -= value;
		}
	}

	public static event Action InputSourceUpdateEvent
	{
		add
		{
			fwNSFuVOVEJhuGmCVeUflVgzJzTh += value;
		}
		remove
		{
			fwNSFuVOVEJhuGmCVeUflVgzJzTh -= value;
		}
	}

	public static event Action EditorRecompileEvent
	{
		add
		{
			XxpHBczYGUVjhwHeWtgVFAVgDDED += value;
		}
		remove
		{
			XxpHBczYGUVjhwHeWtgVFAVgDDED -= value;
		}
	}

	public static event Action PreShutDownEvent
	{
		add
		{
			LKHDdmdZDCktRkapcYDDWKbWPCrWA += value;
		}
		remove
		{
			LKHDdmdZDCktRkapcYDDWKbWPCrWA -= value;
		}
	}

	public static event Action ShutDownEvent
	{
		add
		{
			JJJFLFHsalfWgHTQOpvSTCRWouZMA += value;
		}
		remove
		{
			JJJFLFHsalfWgHTQOpvSTCRWouZMA -= value;
		}
	}

	public static event Action InitializedEvent
	{
		add
		{
			LftZqMUTvYXewBXJKtrsPSxZKUHh += value;
		}
		remove
		{
			LftZqMUTvYXewBXJKtrsPSxZKUHh -= value;
		}
	}

	[CustomObfuscation(rename = false)]
	internal static event Action<bool> ApplicationFocusChangedEvent
	{
		add
		{
			_ApplicationFocusChangedEvent = (Action<bool>)Delegate.Combine(_ApplicationFocusChangedEvent, value);
		}
		remove
		{
			_ApplicationFocusChangedEvent = (Action<bool>)Delegate.Remove(_ApplicationFocusChangedEvent, value);
		}
	}

	[CustomObfuscation(rename = false)]
	internal static event Action<bool> ApplicationPauseChangedEvent
	{
		add
		{
			_ApplicationPauseChangedEvent = (Action<bool>)Delegate.Combine(_ApplicationPauseChangedEvent, value);
		}
		remove
		{
			_ApplicationPauseChangedEvent = (Action<bool>)Delegate.Remove(_ApplicationPauseChangedEvent, value);
		}
	}

	[CustomObfuscation(rename = false)]
	internal static event Action EarlyUpdateEvent
	{
		add
		{
			FdqumDzCZBZGxBYTSqwAgbomKxbe = (Action)Delegate.Combine(FdqumDzCZBZGxBYTSqwAgbomKxbe, value);
		}
		remove
		{
			FdqumDzCZBZGxBYTSqwAgbomKxbe = (Action)Delegate.Remove(FdqumDzCZBZGxBYTSqwAgbomKxbe, value);
		}
	}

	[CustomObfuscation(rename = false)]
	internal static event Action<UpdateLoopType> BeforeTimeManagerUpdateEvent
	{
		add
		{
			BzjHFahIyiZUfjiytewhpnyyWjui = (Action<UpdateLoopType>)Delegate.Combine(BzjHFahIyiZUfjiytewhpnyyWjui, value);
		}
		remove
		{
			BzjHFahIyiZUfjiytewhpnyyWjui = (Action<UpdateLoopType>)Delegate.Remove(BzjHFahIyiZUfjiytewhpnyyWjui, value);
		}
	}

	[CustomObfuscation(rename = false)]
	internal static event Action<UpdateLoopType> UpdateStartedEvent
	{
		add
		{
			xzwIJYhyfIkTzWqlCCzfpyozvkLf = (Action<UpdateLoopType>)Delegate.Combine(xzwIJYhyfIkTzWqlCCzfpyozvkLf, value);
		}
		remove
		{
			xzwIJYhyfIkTzWqlCCzfpyozvkLf = (Action<UpdateLoopType>)Delegate.Remove(xzwIJYhyfIkTzWqlCCzfpyozvkLf, value);
		}
	}

	[CustomObfuscation(rename = false)]
	internal static event Action<UpdateLoopType> UpdateEndedEvent
	{
		add
		{
			EsvUkTdIXotrlNMHxEhOYbDisLeM = (Action<UpdateLoopType>)Delegate.Combine(EsvUkTdIXotrlNMHxEhOYbDisLeM, value);
		}
		remove
		{
			EsvUkTdIXotrlNMHxEhOYbDisLeM = (Action<UpdateLoopType>)Delegate.Remove(EsvUkTdIXotrlNMHxEhOYbDisLeM, value);
		}
	}

	[CustomObfuscation(rename = false)]
	internal static event Action LateUpdateEvent
	{
		add
		{
			pYLfGEUXIhZwLcTEQckceNVZwXOB = (Action)Delegate.Combine(pYLfGEUXIhZwLcTEQckceNVZwXOB, value);
		}
		remove
		{
			pYLfGEUXIhZwLcTEQckceNVZwXOB = (Action)Delegate.Remove(pYLfGEUXIhZwLcTEQckceNVZwXOB, value);
		}
	}

	[CustomObfuscation(rename = false)]
	internal static event Action<bool> ApplicationIsFullScreenChangedEvent
	{
		add
		{
			jhfEhJVTAtaukEVLNnMsaBKYsRoo = (Action<bool>)Delegate.Combine(jhfEhJVTAtaukEVLNnMsaBKYsRoo, value);
		}
		remove
		{
			jhfEhJVTAtaukEVLNnMsaBKYsRoo = (Action<bool>)Delegate.Remove(jhfEhJVTAtaukEVLNnMsaBKYsRoo, value);
		}
	}

	[CustomObfuscation(rename = false)]
	internal static event Action<bool> ApplicationRunInBackgroundChangedEvent
	{
		add
		{
			GxIecdQzTjppWTXsXxbmwupczDYE = (Action<bool>)Delegate.Combine(GxIecdQzTjppWTXsXxbmwupczDYE, value);
		}
		remove
		{
			GxIecdQzTjppWTXsXxbmwupczDYE = (Action<bool>)Delegate.Remove(GxIecdQzTjppWTXsXxbmwupczDYE, value);
		}
	}

	[CustomObfuscation(rename = false)]
	internal static event Action<bool> TimeScalePauseChangedEvent
	{
		add
		{
			yXmESBRKmvEpMuLxNCamFxEWigYA = (Action<bool>)Delegate.Combine(yXmESBRKmvEpMuLxNCamFxEWigYA, value);
		}
		remove
		{
			yXmESBRKmvEpMuLxNCamFxEWigYA = (Action<bool>)Delegate.Remove(yXmESBRKmvEpMuLxNCamFxEWigYA, value);
		}
	}

	[CustomObfuscation(rename = false)]
	internal static event Action<FullScreenMode> ApplicationFullScreenModeChangedEvent
	{
		add
		{
			kUARjFQVZPLxFTSDhiFNQhjKSloP = (Action<FullScreenMode>)Delegate.Combine(kUARjFQVZPLxFTSDhiFNQhjKSloP, value);
		}
		remove
		{
			kUARjFQVZPLxFTSDhiFNQhjKSloP = (Action<FullScreenMode>)Delegate.Remove(kUARjFQVZPLxFTSDhiFNQhjKSloP, value);
		}
	}

	[CustomObfuscation(rename = false)]
	internal static event Action SceneLoadedEvent
	{
		add
		{
			trUnRAyQAVMTokoYwParVtbfvitf = (Action)Delegate.Combine(trUnRAyQAVMTokoYwParVtbfvitf, value);
		}
		remove
		{
			trUnRAyQAVMTokoYwParVtbfvitf = (Action)Delegate.Remove(trUnRAyQAVMTokoYwParVtbfvitf, value);
		}
	}

	[CustomObfuscation(rename = false)]
	internal static event Action<bool> EditorPauseChangedEvent
	{
		add
		{
			FKuNsEflurOJwjEnJrKWOAMINTyO = (Action<bool>)Delegate.Combine(FKuNsEflurOJwjEnJrKWOAMINTyO, value);
		}
		remove
		{
			FKuNsEflurOJwjEnJrKWOAMINTyO = (Action<bool>)Delegate.Remove(FKuNsEflurOJwjEnJrKWOAMINTyO, value);
		}
	}

	static ReInput()
	{
		JNicJPqehYVSsevadzMHTHnWffzh = true;
		WKGQErYGqxYWkTzYcqmnNwNQAVPn = -1;
		_id = -1;
		sJIEwcKuQvmyFfDKuBxigXndloYnA = 0;
		uxIqvIOVKwREJbTltMrNNClEBfvN = UnityTouch.IPjenODOrubLUzmTEceMSVNSALcoA();
		xwrLOKTxYJnsbGDarnPCXoDcLJxt = PlayerHelper.FCkMbMUbIYQXpwvuoQocTbjBbvREA();
		AkAQMgXaKaTPPGyeZJtlKaMrfzDGA = ControllerHelper.YNqVldwlIEQtzFpAeAvHuawYeKPCA();
		nowronjolYHCZmQmDOsBfzQifayW = MappingHelper.xHfENUwCqCMayHmpgMGXapCnwHjk();
		vDNPQlhiBNWlrxOoIXpnNhIFyCpD = TimeHelper.cYcEPoVAyiCWgEUSNtdCRsghIklCA();
		vuLhTsAbMqbJTxoXTwWTMcyWkfYE = ConfigHelper.KbbJTPFaiuWGBDGGTVHubWHJWBJlA();
		HOgGGTFDVaCkxTXUyiPBEFDykOH = LocalizationHelper.kpspwMgWDMiYxBcKjZUEFPkwxOov();
		CgAeRHunfdTLxinuaTvEGnYfXqIW = GlyphHelper.MeiTncwkloGWBsNaUZsRiHijcyFN();
		uvMukUaxTeFVeHXdjVdnMUQlUqpA = new SafeAction<ControllerStatusChangedEventArgs>(yksghDPohDiVhBBTOuqRnvSVqnKx._003C_003E9.QXPMumxbaEkMAnxgmWyXWINfbQZl);
		DPHkUlVeUOBBWWEHtZvOdLaKhokA = new SafeAction<ControllerStatusChangedEventArgs>(yksghDPohDiVhBBTOuqRnvSVqnKx._003C_003E9.vxlhuVRLyMhKmTwCSXLFcBlewZic);
		yWPZNfBshompeDjslhdxWrPJAwHt = new SafeAction<ControllerStatusChangedEventArgs>(yksghDPohDiVhBBTOuqRnvSVqnKx._003C_003E9.LvPAZtZdqYECCDAuHPBQkzHVQWYmA);
		fwNSFuVOVEJhuGmCVeUflVgzJzTh = new SafeAction(yksghDPohDiVhBBTOuqRnvSVqnKx._003C_003E9.kTpcKlNTKmbTEtiEbmeyvSClwklG);
		XxpHBczYGUVjhwHeWtgVFAVgDDED = new SafeAction(yksghDPohDiVhBBTOuqRnvSVqnKx._003C_003E9.OiFtsqXOQrWLmPzJEkGpbEpvGHHGA);
		LKHDdmdZDCktRkapcYDDWKbWPCrWA = new SafeAction(yksghDPohDiVhBBTOuqRnvSVqnKx._003C_003E9.jDkIouwaZlMJOgKLezkkMCizBJbBA);
		JJJFLFHsalfWgHTQOpvSTCRWouZMA = new SafeAction(yksghDPohDiVhBBTOuqRnvSVqnKx._003C_003E9.hZtIqeALYEmRarpNnjjlrxkBGOCE);
		LftZqMUTvYXewBXJKtrsPSxZKUHh = new SafeAction(yksghDPohDiVhBBTOuqRnvSVqnKx._003C_003E9.RnHroAceqsGRVKLVvoYRGJEdlvVpc);
		SafeDelegate.S_ExceptionHandler = yksghDPohDiVhBBTOuqRnvSVqnKx._003C_003E9.MlsASaggFJLYPlGfiplXBfiqaQzT;
	}

	private static QhiddugZGpIeVluIsyWwoiQEhHjf ntZJMMLDNppJFyxcEJhPKrldSpyH()
	{
		return SGdcxAVhuyCMLJBfzNtvXvjDZqzG ?? (SGdcxAVhuyCMLJBfzNtvXvjDZqzG = new QhiddugZGpIeVluIsyWwoiQEhHjf(yZbloWHGkzkpTWiASTPgAShwAgah.updateLoop));
	}

	public static void Update()
	{
		if (UJsvrGEMKlXkCjGlrRbNmdqzObVj)
		{
			if (yZbloWHGkzkpTWiASTPgAShwAgah.updateMode != UpdateMode.Manual)
			{
				Logger.LogError("Rewired cannot be updated manually unless Update Mode is set to Manual.");
			}
			else
			{
				KRXMNGqTUEuSZnzlexLlRTibdOwA.DoUpdate(UpdateLoopType.Update, UpdateLoopSetting.Update);
			}
		}
	}

	public static void Reset()
	{
		if (UJsvrGEMKlXkCjGlrRbNmdqzObVj && !(KRXMNGqTUEuSZnzlexLlRTibdOwA == null))
		{
			KRXMNGqTUEuSZnzlexLlRTibdOwA.ResetAll();
		}
	}

	private static bool jQZMnpuHLMuvuQLmRXfizlCuninR()
	{
		if (UnityTools.unityVersion >= UnityTools.UnityVersion.UNITY_5_1)
		{
			return gucurGOUjhxvvYQarpsrYhilGfSiA == "Game";
		}
		return gucurGOUjhxvvYQarpsrYhilGfSiA == "UnityEditor.GameView";
	}

	private static bool ZBUDmHHxrwgiIBStzPamcOElaGtzA()
	{
		if (!UJsvrGEMKlXkCjGlrRbNmdqzObVj)
		{
			return false;
		}
		if (!uWFGARmQSApmyFkxwRvhWWkwDohH.LUPravlxwsaWnkpJMDdZCBXoqtre.value)
		{
			if (AuSbamOqiesJxxIIDbYQFwfSutfu)
			{
				return false;
			}
			if ((!isEditor || !isUnityEditorFocused) && !uWFGARmQSApmyFkxwRvhWWkwDohH.XUugLpvcebTXjZrMMPqnTGSddbpQ.value)
			{
				return false;
			}
		}
		return true;
	}

	[CustomObfuscation(rename = false)]
	internal static bool IsInputAllowed(ControllerType controllerType)
	{
		if (!ZBUDmHHxrwgiIBStzPamcOElaGtzA())
		{
			return false;
		}
		if (rOxPDwAkwXFgbfLssjclSsErUCBWA != EditorPlatform.None && (controllerType == ControllerType.Keyboard || controllerType == ControllerType.Mouse))
		{
			if (AuSbamOqiesJxxIIDbYQFwfSutfu)
			{
				if (!uWFGARmQSApmyFkxwRvhWWkwDohH.LUPravlxwsaWnkpJMDdZCBXoqtre.value)
				{
					return false;
				}
			}
			else if (!isAllowedEditorWindowFocused)
			{
				return false;
			}
		}
		return true;
	}

	private static void jHrBSiIXJHUXIFLvlerZMXKKEyce()
	{
		mEwnOsXbuQEGmLDxEkROAPjAjYOT = UnityTools.platform;
		LTMHQkwtBevmTaFeQRmrJrgDCMzf = UnityTools.webplayerPlatform;
		rOxPDwAkwXFgbfLssjclSsErUCBWA = UnityTools.editorPlatform;
	}

	internal static void nBbikkrlkZzDhglDlTXouvswecHp(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4, Func<UnityTools.kJCrKrVttyLKcUctlPeIVyCNobPn> P_5, Action<Platform> P_6, Action<InputManager_Base.WNkJQjorcLeyWPbqINyIvuHFDGIo> P_7)
	{
		try
		{
			_id = sJIEwcKuQvmyFfDKuBxigXndloYnA;
			sJIEwcKuQvmyFfDKuBxigXndloYnA++;
			UJsvrGEMKlXkCjGlrRbNmdqzObVj = true;
			cRVaiuBtmpcxTgtzwaDWmCEQsccv = true;
			LpBnqxdWJJFMwYJxdaJtCrRYMHDB = UnityTools.isEditor && !Application.isPlaying;
			if (UnityTools.isEditor)
			{
				CheckRewiredVersionCompatibility();
			}
			KRXMNGqTUEuSZnzlexLlRTibdOwA = P_0;
			yZbloWHGkzkpTWiASTPgAShwAgah = P_2;
			jHrBSiIXJHUXIFLvlerZMXKKEyce();
			if (P_2.logToScreen)
			{
				Logger.logToScreen = true;
			}
			UnityTools.externalTools.EditorPausedStateChangedEvent += bBElupCmdPHXMhJiBTtRenPAjKvgb;
			rEHckUItvSTizptREslLvYDLFEArA = P_3;
			GSaeDquNrvgMCNAsNvzHXfLVsESw = P_4;
			AqWIRNEeuVzYaXnHqgMlrUpSDKyg = new TimerAbs(1.0);
			FKxLJdNmjvXkvQmEKBKJBzHUMTReA = new tpvMtijIgvyynGcKqmAJeacXwhgn();
			LocalizationManager.Initialize();
			GlyphManager.Initialize();
			P_4.ELkrLLMwoOMdWIxKlaIpbhKkaISe();
			ThreadSafeUnityInput.Initialize();
			uWFGARmQSApmyFkxwRvhWWkwDohH = new OkkiCFiYKtSSxTplFjKjVcmCHvOn();
			if (!UnityTools.isEditor)
			{
				JNicJPqehYVSsevadzMHTHnWffzh = Application.isFocused;
			}
			uWFGARmQSApmyFkxwRvhWWkwDohH.LUPravlxwsaWnkpJMDdZCBXoqtre.Set(JNicJPqehYVSsevadzMHTHnWffzh);
			uWFGARmQSApmyFkxwRvhWWkwDohH.LUPravlxwsaWnkpJMDdZCBXoqtre.Use();
			if (rOxPDwAkwXFgbfLssjclSsErUCBWA != EditorPlatform.None)
			{
				uWFGARmQSApmyFkxwRvhWWkwDohH.LUPravlxwsaWnkpJMDdZCBXoqtre.getValueDelegate = yksghDPohDiVhBBTOuqRnvSVqnKx._003C_003E9.OhwWgCyvAkDEMyAZKttlosrOmZiA;
				if (LpBnqxdWJJFMwYJxdaJtCrRYMHDB)
				{
					JNicJPqehYVSsevadzMHTHnWffzh = jQZMnpuHLMuvuQLmRXfizlCuninR();
				}
				uWFGARmQSApmyFkxwRvhWWkwDohH.LUPravlxwsaWnkpJMDdZCBXoqtre.Set(isUnityEditorFocused && isAllowedEditorWindowFocused);
			}
			bgmJSfsebRpyKEgkeMheVHZNjeJU();
			List<ICustomPlatformInitializer> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<ICustomPlatformInitializer>(P_0.gameObject);
			if (componentsInSelfAndChildren != null)
			{
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					Behaviour behaviour = componentsInSelfAndChildren[i] as Behaviour;
					if (behaviour == null || !behaviour.enabled || !behaviour.gameObject.activeInHierarchy)
					{
						continue;
					}
					CustomPlatformInitOptions customPlatformInitOptions = componentsInSelfAndChildren[i].GetCustomPlatformInitOptions();
					if (customPlatformInitOptions != null)
					{
						DYXEicTUvpxnVFlTbwIfiujTNpTs.YJFbOEoruEbekiwzNrSDeDOguozlA(customPlatformInitOptions);
						bool num = rOxPDwAkwXFgbfLssjclSsErUCBWA != EditorPlatform.None;
						P_7(new InputManager_Base.WNkJQjorcLeyWPbqINyIvuHFDGIo
						{
							EWiaBdsKMOMbjVZpVMUASFTKeFKFA = Platform.Custom,
							LMpCicIyvFPXwIGCkjGDQXdamKlUA = EditorPlatform.None,
							XjVlQPcbdbDSlGgOhxphOKPzZWYI = WebplayerPlatform.None
						});
						jHrBSiIXJHUXIFLvlerZMXKKEyce();
						FKxLJdNmjvXkvQmEKBKJBzHUMTReA = new tpvMtijIgvyynGcKqmAJeacXwhgn();
						if (num)
						{
							Logger.LogWarning("A custom platform is in use. All input will be managed by user-defined custom platform handling.");
						}
						break;
					}
				}
			}
			kuubVgtjMbHtChgcetKmTrqknMyXA(P_1, P_5(), P_6);
			IsSPFehscBAmxtEADWGWuasjDvqf = new lQoAAQNPpFWyUNnFoiTjITGTmsQh(P_4.GetActions_Copy());
			jCkgZLcnXoMycBxzcMXWvnUfSROEb = new rrNUAxqqEizlnWVKRaqVmKdJebkM(P_2, LDKYdkBTvBDiUqmQeCvGVejyVoZQ);
			iJRGiWfOZRwVGgOxWlHrWBzdJmvdA = new PZIrFQmTYjOFmeiRPrMzBSOSvuwD(P_2);
			LDKYdkBTvBDiUqmQeCvGVejyVoZQ.DeviceConnectedEvent += jPnkSKJzRyPgAJjGjbfsFpWokBRt;
			LDKYdkBTvBDiUqmQeCvGVejyVoZQ.DeviceDisconnectedEvent += mZTFnUERqgQPTClACrtSbEUiMEfF;
			LDKYdkBTvBDiUqmQeCvGVejyVoZQ.UpdateControllerInfoEvent += ePIPVYjgNrTknhbderdmvWgfghzi;
			jCkgZLcnXoMycBxzcMXWvnUfSROEb.vsNscyxBZOhEpbDKCYkLRAiUHcml(aHcyKoFywBhyoTjHjkukclipkGIU);
			jCkgZLcnXoMycBxzcMXWvnUfSROEb.LTMeRkwEVNEJBVjAeirnVOQnbnEKA(iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.vhodcUKgFIymUSlKmnRMUseXKWDfA);
			ThreadSafeUnityInput.PostInitialize();
			ixhrUrrbpKhoUcgyZUFtOCDWRHClA();
			ThreadSafeUnityInput.PostInitialize2();
			iLHKRkdaCZktMmwChlBmDYIPJikk = UnityTools.GetComponent<UserDataStore>(KRXMNGqTUEuSZnzlexLlRTibdOwA);
			if (iLHKRkdaCZktMmwChlBmDYIPJikk != null)
			{
				iLHKRkdaCZktMmwChlBmDYIPJikk.Initialize();
			}
			cvBXFIYYtKQDyHhnjwFGIgwpbSQeA();
			cRVaiuBtmpcxTgtzwaDWmCEQsccv = false;
			if (LpBnqxdWJJFMwYJxdaJtCrRYMHDB)
			{
				Logger.Log("Rewired is running in Edit mode.");
			}
			if (LftZqMUTvYXewBXJKtrsPSxZKUHh != null)
			{
				LftZqMUTvYXewBXJKtrsPSxZKUHh.Invoke();
			}
		}
		catch (Exception)
		{
			UJsvrGEMKlXkCjGlrRbNmdqzObVj = false;
			cRVaiuBtmpcxTgtzwaDWmCEQsccv = false;
			throw;
		}
	}

	internal static void ddSaYCLkYXwjfZqVPIMtgFXBhbUq()
	{
		if (FKxLJdNmjvXkvQmEKBKJBzHUMTReA != null)
		{
			FKxLJdNmjvXkvQmEKBKJBzHUMTReA.EomtxvlJOVvZhGIIgwUHlMfUeOXG();
		}
		if (configVars.deferControllerConnectedEventsOnStart)
		{
			for (int i = 0; i < jCkgZLcnXoMycBxzcMXWvnUfSROEb.DgWkEwMpXTtCniXaqphVZqoNpNah(); i++)
			{
				Joystick joystick = jCkgZLcnXoMycBxzcMXWvnUfSROEb.EEbcrLiEhnvUlDgBBWavPqjmOUJZA()[i];
				wvLCREFZcVmxSiZGjdjNhqhGeZSTB(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
			}
		}
	}

	internal static void DDqtoGBugrpFobxJVsmkcyhnpQKk(UpdateLoopType P_0)
	{
		if (UJsvrGEMKlXkCjGlrRbNmdqzObVj)
		{
			vzccxsCiMAkOAaBjJiZbHaPaJZnRB(P_0);
			if ((uint)P_0 <= 1u)
			{
				KqETndLUundHgWaYIeCEYvSnVvMC();
			}
		}
	}

	private static void vzccxsCiMAkOAaBjJiZbHaPaJZnRB(UpdateLoopType P_0)
	{
		if (uWFGARmQSApmyFkxwRvhWWkwDohH != null)
		{
			uWFGARmQSApmyFkxwRvhWWkwDohH.NpQENMMHxkpQMjsCVVrUsEJZDGj();
		}
		Action<UpdateLoopType> bzjHFahIyiZUfjiytewhpnyyWjui = BzjHFahIyiZUfjiytewhpnyyWjui;
		if (bzjHFahIyiZUfjiytewhpnyyWjui != null)
		{
			try
			{
				bzjHFahIyiZUfjiytewhpnyyWjui(P_0);
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.BeforeTimeManagerUpdateEvent", exception);
			}
		}
		FKxLJdNmjvXkvQmEKBKJBzHUMTReA.VgJNWrMtvBgAscBzVMjdMaoUcMshA(P_0);
	}

	private static void KqETndLUundHgWaYIeCEYvSnVvMC()
	{
		int frameCount = Time.frameCount;
		if (WKGQErYGqxYWkTzYcqmnNwNQAVPn == frameCount)
		{
			return;
		}
		WKGQErYGqxYWkTzYcqmnNwNQAVPn = frameCount;
		ThreadSafeUnityInput.Update();
		Action fdqumDzCZBZGxBYTSqwAgbomKxbe = FdqumDzCZBZGxBYTSqwAgbomKxbe;
		if (fdqumDzCZBZGxBYTSqwAgbomKxbe == null)
		{
			return;
		}
		try
		{
			fdqumDzCZBZGxBYTSqwAgbomKxbe();
		}
		catch (Exception exception)
		{
			HandleCallbackException("ReInput.EarlyUpdateEvent", exception);
		}
	}

	internal static void NdXMDOjPrjUKEJESjxAxlFSycuzz(UpdateLoopType P_0)
	{
		if (!UJsvrGEMKlXkCjGlrRbNmdqzObVj)
		{
			return;
		}
		if (DsvcxYMJbnguNBHofUwSPPVGobOI != P_0)
		{
			DsvcxYMJbnguNBHofUwSPPVGobOI = P_0;
		}
		if (editorPlatform != EditorPlatform.None)
		{
			gucurGOUjhxvvYQarpsrYhilGfSiA = uWFGARmQSApmyFkxwRvhWWkwDohH.kuEEgrkQPVaNBPAxyTSbQgTyDhcwA.value;
		}
		if (dfJsCIHzUmwVRICvbHzjezzieXwf)
		{
			if (AqWIRNEeuVzYaXnHqgMlrUpSDKyg.Update())
			{
				dfJsCIHzUmwVRICvbHzjezzieXwf = false;
				AqWIRNEeuVzYaXnHqgMlrUpSDKyg.Clear();
			}
			else
			{
				ntZJMMLDNppJFyxcEJhPKrldSpyH().VbmBgDTmQTqNOOXfOvBohFlNvqVo(P_0);
			}
		}
		uWFGARmQSApmyFkxwRvhWWkwDohH.yBsdIdbTfLslaBUSeQhTAXywHmGT();
		Action<UpdateLoopType> action = xzwIJYhyfIkTzWqlCCzfpyozvkLf;
		if (action != null)
		{
			try
			{
				action(P_0);
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.UpdateStartedEvent", exception);
			}
		}
		LDKYdkBTvBDiUqmQeCvGVejyVoZQ.Update(P_0);
		if (fwNSFuVOVEJhuGmCVeUflVgzJzTh != null)
		{
			fwNSFuVOVEJhuGmCVeUflVgzJzTh.Invoke();
		}
		jCkgZLcnXoMycBxzcMXWvnUfSROEb.qxOhWFAsFIAojJSQpPYYmbIBYsiJ(P_0);
		Action<UpdateLoopType> esvUkTdIXotrlNMHxEhOYbDisLeM = EsvUkTdIXotrlNMHxEhOYbDisLeM;
		if (esvUkTdIXotrlNMHxEhOYbDisLeM == null)
		{
			return;
		}
		try
		{
			esvUkTdIXotrlNMHxEhOYbDisLeM(P_0);
		}
		catch (Exception exception2)
		{
			HandleCallbackException("ReInput.UpdateEndedEvent", exception2);
		}
	}

	internal static void lvKfFcAUrPUrkFmtBDAJeGKqXPOWA()
	{
		Action action = pYLfGEUXIhZwLcTEQckceNVZwXOB;
		if (action != null)
		{
			try
			{
				action();
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.LateUpdateEvent", exception);
			}
		}
	}

	[CustomObfuscation(rename = false)]
	internal static void EditorUpdate()
	{
		if (UJsvrGEMKlXkCjGlrRbNmdqzObVj && LpBnqxdWJJFMwYJxdaJtCrRYMHDB)
		{
			DDqtoGBugrpFobxJVsmkcyhnpQKk(UpdateLoopType.Update);
			NdXMDOjPrjUKEJESjxAxlFSycuzz(UpdateLoopType.Update);
			lvKfFcAUrPUrkFmtBDAJeGKqXPOWA();
		}
	}

	internal static void LFdTJBuzOcFcHRwVMzPeWHCBdtGM()
	{
		if (LKHDdmdZDCktRkapcYDDWKbWPCrWA != null)
		{
			LKHDdmdZDCktRkapcYDDWKbWPCrWA.Invoke();
		}
		if (LDKYdkBTvBDiUqmQeCvGVejyVoZQ != null)
		{
			LDKYdkBTvBDiUqmQeCvGVejyVoZQ.OnDestroy();
		}
		byFapCJzFMGpbayxhUCgREUCHpkL();
		if (JJJFLFHsalfWgHTQOpvSTCRWouZMA != null)
		{
			JJJFLFHsalfWgHTQOpvSTCRWouZMA.Invoke();
			JJJFLFHsalfWgHTQOpvSTCRWouZMA = null;
		}
	}

	internal static void bFUBsbIRUzTDQsejpnYynWxGPOpC()
	{
		if (XxpHBczYGUVjhwHeWtgVFAVgDDED != null)
		{
			XxpHBczYGUVjhwHeWtgVFAVgDDED.Invoke();
		}
	}

	internal static void QvdrawFPHQcvHEUsCBPTkdAyJkUsA(bool P_0)
	{
		JNicJPqehYVSsevadzMHTHnWffzh = P_0;
		if (rOxPDwAkwXFgbfLssjclSsErUCBWA == EditorPlatform.None && UJsvrGEMKlXkCjGlrRbNmdqzObVj)
		{
			uWFGARmQSApmyFkxwRvhWWkwDohH.LUPravlxwsaWnkpJMDdZCBXoqtre.Set(P_0);
			uWFGARmQSApmyFkxwRvhWWkwDohH.LUPravlxwsaWnkpJMDdZCBXoqtre.TriggerEvent();
		}
	}

	internal static void eQueBZUUgHdIVvEJmXrsPzWiPAtP(bool P_0)
	{
		if (UJsvrGEMKlXkCjGlrRbNmdqzObVj)
		{
			uWFGARmQSApmyFkxwRvhWWkwDohH.JVzdRvemOzvWdobxhSaGkeyRxRvD.Set(P_0);
			uWFGARmQSApmyFkxwRvhWWkwDohH.JVzdRvemOzvWdobxhSaGkeyRxRvD.TriggerEvent();
		}
	}

	internal static void hqYAVQEraPnEuxWGEeSZrioRcbOpA()
	{
		if (!UJsvrGEMKlXkCjGlrRbNmdqzObVj)
		{
			return;
		}
		Action action = trUnRAyQAVMTokoYwParVtbfvitf;
		if (action == null)
		{
			return;
		}
		try
		{
			action();
		}
		catch (Exception exception)
		{
			HandleCallbackException("ReInput.SceneLoadedEvent", exception);
		}
	}

	[CustomObfuscation(rename = false)]
	internal static HardwareJoystickMap_InputManager GetHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
	{
		return rEHckUItvSTizptREslLvYDLFEArA.LGqfndQqsSiKCGWyBONuqVomSfoA(bridgedController);
	}

	internal static HardwareJoystickMap WXHBrnXMjLJvcVAQCoEWvVAxpHaq(Guid P_0)
	{
		return rEHckUItvSTizptREslLvYDLFEArA.GetHardwareJoystickMap(P_0);
	}

	internal static HardwareJoystickTemplateMap CJxBKaYlWcxIRqJmrPDwZXxmWcfb(Guid P_0)
	{
		return rEHckUItvSTizptREslLvYDLFEArA.GetJoystickTemplate(P_0);
	}

	internal static iaIUVVeHlIHTbKHbIuOgJotHxcqD XtiXdGauTVLmWDzraWhhHISljycG(Guid P_0)
	{
		return rEHckUItvSTizptREslLvYDLFEArA.HBSPtAfOrSEGakZRFpoZQKHgeogw(P_0);
	}

	internal static IHardwareControllerTemplateMap hwKlFPQCRbmrGfKgtRgxidBnEwDdA(Guid P_0)
	{
		return rEHckUItvSTizptREslLvYDLFEArA.GetControllerTemplate(P_0);
	}

	internal static IHardwareControllerTemplateMap gehEMLnjCXKGoofNxoiGetkJskO(Guid P_0)
	{
		return rEHckUItvSTizptREslLvYDLFEArA.MXaiHiYZvfegroSIQNmUmIbyGdVv(P_0);
	}

	internal static IList<iaIUVVeHlIHTbKHbIuOgJotHxcqD> pFqEuDuQTUHBlUazWTWXPbWylRbu(Guid P_0)
	{
		HardwareJoystickMap hardwareJoystickMap = rEHckUItvSTizptREslLvYDLFEArA.GetHardwareJoystickMap(P_0);
		if (hardwareJoystickMap == null)
		{
			return EmptyObjects<iaIUVVeHlIHTbKHbIuOgJotHxcqD>.EmptyReadOnlyIListT;
		}
		string[] templateGuidsOrig = hardwareJoystickMap.GetTemplateGuidsOrig();
		if (templateGuidsOrig == null || templateGuidsOrig.Length == 0)
		{
			return EmptyObjects<iaIUVVeHlIHTbKHbIuOgJotHxcqD>.EmptyReadOnlyIListT;
		}
		List<iaIUVVeHlIHTbKHbIuOgJotHxcqD> list = null;
		for (int i = 0; i < templateGuidsOrig.Length; i++)
		{
			Guid guid;
			try
			{
				guid = new Guid(templateGuidsOrig[i]);
			}
			catch
			{
				Logger.LogWarning("Controller Template GUID is invalid: " + templateGuidsOrig[i]);
				continue;
			}
			iaIUVVeHlIHTbKHbIuOgJotHxcqD iaIUVVeHlIHTbKHbIuOgJotHxcqD2 = XtiXdGauTVLmWDzraWhhHISljycG(guid);
			if (iaIUVVeHlIHTbKHbIuOgJotHxcqD2 == null)
			{
				Logger.LogWarning("Controller Template was not found for GUID " + guid.ToString());
				continue;
			}
			if (list == null)
			{
				list = new List<iaIUVVeHlIHTbKHbIuOgJotHxcqD>();
			}
			ListTools.AddIfUnique(list, iaIUVVeHlIHTbKHbIuOgJotHxcqD2);
		}
		if (list == null)
		{
			return EmptyObjects<iaIUVVeHlIHTbKHbIuOgJotHxcqD>.EmptyReadOnlyIListT;
		}
		return list;
	}

	[CustomObfuscation(rename = false)]
	internal static int GetNewJoystickId()
	{
		return jCkgZLcnXoMycBxzcMXWvnUfSROEb.wbLVUZcAndPoAHjIMjDACtdSNktG();
	}

	[CustomObfuscation(rename = false)]
	internal static void HandleCallbackException(string source, Exception exception)
	{
		string msg = "An exception occurred inside an event handler or callback.\nSource: " + source + "\n\nThis happens if your event handler/callback code throws an exception. This means the error is in your code, not Rewired. Read the exception message and the stack trace carefully to find the source of the exception being thrown by your code.\n\nThis can also happen if you forget to unsubscribe to an event in a MonoBehaviour class and that object gets destroyed. Make sure you unsubscribe to events in OnDisable or OnDestroy. Rewired will attempt to continue running.\n\nException:\n" + ((exception.InnerException != null) ? exception.InnerException : exception);
		Logger.LogException((exception.InnerException != null) ? exception.InnerException : exception, msg, requiredThreadSafety: true);
	}

	[CustomObfuscation(rename = false)]
	internal static void HandleExternException(string source, Exception exception)
	{
		Logger.LogException((exception.InnerException != null) ? exception.InnerException : exception, string.Empty, requiredThreadSafety: true);
	}

	[CustomObfuscation(rename = false)]
	internal static void HandleExternalInterfaceException(string source, Exception exception)
	{
		string msg = "An exception occurred inside an external function call.\nSource: " + source + "\n\nThis happens if the external function throws an exception. This could indicate the error is in your code if Rewired is calling a function in an interface implementation you created. Read the exception message and the stack trace carefully to find the source of the exception being thrown.\n\nThis can also happen if you forget to unsubscribe to an event in a MonoBehaviour class and that object gets destroyed.\n\nException:\n" + ((exception.InnerException != null) ? exception.InnerException : exception);
		Logger.LogException((exception.InnerException != null) ? exception.InnerException : exception, msg, requiredThreadSafety: true);
	}

	internal static void CxfkmhzrQfrXFPALRIlzGSTWggoW()
	{
		if (UJsvrGEMKlXkCjGlrRbNmdqzObVj)
		{
			cvBXFIYYtKQDyHhnjwFGIgwpbSQeA();
		}
	}

	[CustomObfuscation(rename = false)]
	internal static void CheckRewiredVersionCompatibility()
	{
		if (UnityTools.unityVersionObj != null && 2022 != UnityTools.unityVersionObj.major)
		{
			ushfbTaMWlLMaQtgAAdncLXaYfwaB();
		}
	}

	internal static float IwviHzjnjPftonCgNMJfnYkBwIvy()
	{
		return uWFGARmQSApmyFkxwRvhWWkwDohH.ihHvfeEASTpLCUyJOdSbefOwhvRX.value;
	}

	[CustomObfuscation(rename = false)]
	internal static bool CheckInitialized()
	{
		if (!UJsvrGEMKlXkCjGlrRbNmdqzObVj)
		{
			Logger.LogError("Rewired is not initialized. You must have an active and enabled Rewired Input Manager in the scene before calling any part of the Rewired API.");
			return false;
		}
		return true;
	}

	[CustomObfuscation(rename = false)]
	internal static bool CheckInitialized(int reInputId)
	{
		if (!CheckInitialized())
		{
			return false;
		}
		if (_id != reInputId)
		{
			Logger.LogError("You are attemping to access an object that was created by a previous session or different instance of Rewired and is no longer valid. When Rewired is reset or the Rewired Input Manager is disabled or destroyed, all old object references become invalid and can no longer be used. If you deinitialize Rewired, you cannot use locally stored Rewired objects obtained prior to deinitialization and you must get new objects from the Rewired API.");
			return false;
		}
		return true;
	}

	private static void ixhrUrrbpKhoUcgyZUFtOCDWRHClA()
	{
		iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.BSSPjRyqmFavLeqkoUtSBapkXNLiA();
		jCkgZLcnXoMycBxzcMXWvnUfSROEb.CoffVmbmnIFbLiPsHFTYPoKcelCPD(LDKYdkBTvBDiUqmQeCvGVejyVoZQ.GetInputDataUpdateDelegate(), GSaeDquNrvgMCNAsNvzHXfLVsESw.GetInputBehaviors_Copy());
		LDKYdkBTvBDiUqmQeCvGVejyVoZQ.Initialize();
	}

	private static void byFapCJzFMGpbayxhUCgREUCHpkL()
	{
		if (KRXMNGqTUEuSZnzlexLlRTibdOwA != null)
		{
			List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(KRXMNGqTUEuSZnzlexLlRTibdOwA);
			for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
			{
				componentsInSelfAndChildren[i].Deinitialize();
			}
		}
		KRXMNGqTUEuSZnzlexLlRTibdOwA = null;
		LDKYdkBTvBDiUqmQeCvGVejyVoZQ = null;
		IsSPFehscBAmxtEADWGWuasjDvqf = null;
		if (jCkgZLcnXoMycBxzcMXWvnUfSROEb != null)
		{
			jCkgZLcnXoMycBxzcMXWvnUfSROEb.Dispose();
		}
		jCkgZLcnXoMycBxzcMXWvnUfSROEb = null;
		iJRGiWfOZRwVGgOxWlHrWBzdJmvdA = null;
		rEHckUItvSTizptREslLvYDLFEArA = null;
		if (GSaeDquNrvgMCNAsNvzHXfLVsESw != null)
		{
			GSaeDquNrvgMCNAsNvzHXfLVsESw.tkfgFrbCKnsTJUVjYHeEUkKWNQvS();
		}
		GSaeDquNrvgMCNAsNvzHXfLVsESw = null;
		LocalizationHelper.zVECgeyoOmbqFdRraabntBcTebnL();
		GlyphHelper.LKhERsEkVSooVwukAiGjjRzmqVNCb();
		LocalizationManager.Deinitialize();
		GlyphManager.Deinitialize();
		bwpygVfTeDmccDbXCbTQjMpOrRRUA = null;
		UJsvrGEMKlXkCjGlrRbNmdqzObVj = false;
		yZbloWHGkzkpTWiASTPgAShwAgah = null;
		DsvcxYMJbnguNBHofUwSPPVGobOI = UpdateLoopType.Update;
		sJwPaphnMJCMJkgqAeoxPkqvHssEb = false;
		mEwnOsXbuQEGmLDxEkROAPjAjYOT = Platform.Windows;
		LTMHQkwtBevmTaFeQRmrJrgDCMzf = WebplayerPlatform.None;
		rOxPDwAkwXFgbfLssjclSsErUCBWA = EditorPlatform.None;
		dfJsCIHzUmwVRICvbHzjezzieXwf = false;
		AqWIRNEeuVzYaXnHqgMlrUpSDKyg = null;
		FKxLJdNmjvXkvQmEKBKJBzHUMTReA = null;
		gucurGOUjhxvvYQarpsrYhilGfSiA = null;
		AuSbamOqiesJxxIIDbYQFwfSutfu = false;
		LpBnqxdWJJFMwYJxdaJtCrRYMHDB = false;
		JNicJPqehYVSsevadzMHTHnWffzh = true;
		WKGQErYGqxYWkTzYcqmnNwNQAVPn = -1;
		_id = -1;
		TNFnJuFPVFFcKErUnlbyWKLMKEmb = 0;
		unscaledDeltaTime = 0.0;
		unscaledTime = 0.0;
		unscaledTimePrev = 0.0;
		currentFrame = 0u;
		previousFrame = 0u;
		absFrame = 0u;
		uvMukUaxTeFVeHXdjVdnMUQlUqpA.Clear();
		DPHkUlVeUOBBWWEHtZvOdLaKhokA.Clear();
		yWPZNfBshompeDjslhdxWrPJAwHt.Clear();
		fwNSFuVOVEJhuGmCVeUflVgzJzTh.Clear();
		XxpHBczYGUVjhwHeWtgVFAVgDDED.Clear();
		_ApplicationFocusChangedEvent = null;
		_ApplicationPauseChangedEvent = null;
		jhfEhJVTAtaukEVLNnMsaBKYsRoo = null;
		GxIecdQzTjppWTXsXxbmwupczDYE = null;
		kUARjFQVZPLxFTSDhiFNQhjKSloP = null;
		yXmESBRKmvEpMuLxNCamFxEWigYA = null;
		FdqumDzCZBZGxBYTSqwAgbomKxbe = null;
		xzwIJYhyfIkTzWqlCCzfpyozvkLf = null;
		EsvUkTdIXotrlNMHxEhOYbDisLeM = null;
		pYLfGEUXIhZwLcTEQckceNVZwXOB = null;
		LKHDdmdZDCktRkapcYDDWKbWPCrWA = null;
		trUnRAyQAVMTokoYwParVtbfvitf = null;
		FKuNsEflurOJwjEnJrKWOAMINTyO = null;
		sqZFKBUtLMWfhHRgjCGqQnaysuCy();
		uWFGARmQSApmyFkxwRvhWWkwDohH = null;
		ThreadSafeUnityInput.Deinitialize();
		if (UnityTools.externalTools != null)
		{
			UnityTools.externalTools.EditorPausedStateChangedEvent -= bBElupCmdPHXMhJiBTtRenPAjKvgb;
		}
		DYXEicTUvpxnVFlTbwIfiujTNpTs.XTaFmbCBLnnqwnehfQHABeOCIlFFb();
	}

	private static void vzFWZZfCavuHZsplSeeibOhUbwGT(string P_0 = null)
	{
		string text = ((P_0 == null) ? "This function" : P_0);
		Logger.LogError(text + " can only be called in Play mode!");
	}

	private static void MjKfEGwixYArvDaHMXvrICBOIIaN()
	{
		if (!dfJsCIHzUmwVRICvbHzjezzieXwf)
		{
			dfJsCIHzUmwVRICvbHzjezzieXwf = true;
			ntZJMMLDNppJFyxcEJhPKrldSpyH().VsotHYncrJgIVwOfIxRoXbfNdrSN();
			ntZJMMLDNppJFyxcEJhPKrldSpyH().vvPfzvENYdNkqDBVkNqhGlctjiZnA();
		}
		AqWIRNEeuVzYaXnHqgMlrUpSDKyg.Start();
	}

	private static void CcEmyIndYqeirDbCynzgLUKzCRYGA()
	{
		Logger.LogError("Rewired is not initialized. Do you have a Rewired Input Manager in the scene and enabled?");
	}

	private static void jPnkSKJzRyPgAJjGjbfsFpWokBRt(BridgedController P_0)
	{
		if (P_0.sourceJoystick == null)
		{
			return;
		}
		jCkgZLcnXoMycBxzcMXWvnUfSROEb.MZSqepAMvCGEUUSWPaGzYVtZfzkX(P_0);
		Joystick joystick = jCkgZLcnXoMycBxzcMXWvnUfSROEb.YYiuqUYQXVQfqAVVHuCdeZVvlDuO(P_0.sourceJoystick.rewiredId);
		if (joystick != null)
		{
			iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.zTbhIKwTVlMdnUXsULQkGtdSqilm(joystick);
			if (!configVars.deferControllerConnectedEventsOnStart || !cRVaiuBtmpcxTgtzwaDWmCEQsccv)
			{
				wvLCREFZcVmxSiZGjdjNhqhGeZSTB(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
			}
		}
	}

	private static void mZTFnUERqgQPTClACrtSbEUiMEfF(ControllerDisconnectedEventArgs P_0)
	{
		if (P_0 != null)
		{
			Joystick joystick = jCkgZLcnXoMycBxzcMXWvnUfSROEb.YYiuqUYQXVQfqAVVHuCdeZVvlDuO(P_0.rewiredId);
			if (joystick != null)
			{
				jCkgZLcnXoMycBxzcMXWvnUfSROEb.HxsXeHbHIrEZowOGaGQrtmzDaWNT(P_0.rewiredId);
				XDhtlqavqjcSIsyqsObDibSstTQR(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
			}
		}
	}

	private static void wvLCREFZcVmxSiZGjdjNhqhGeZSTB(ControllerStatusChangedEventArgs P_0)
	{
		if (uvMukUaxTeFVeHXdjVdnMUQlUqpA != null)
		{
			uvMukUaxTeFVeHXdjVdnMUQlUqpA.Invoke(P_0);
		}
	}

	private static void aHcyKoFywBhyoTjHjkukclipkGIU(ControllerStatusChangedEventArgs P_0)
	{
		if (DPHkUlVeUOBBWWEHtZvOdLaKhokA != null)
		{
			DPHkUlVeUOBBWWEHtZvOdLaKhokA.Invoke(P_0);
		}
	}

	private static void XDhtlqavqjcSIsyqsObDibSstTQR(ControllerStatusChangedEventArgs P_0)
	{
		if (yWPZNfBshompeDjslhdxWrPJAwHt != null)
		{
			yWPZNfBshompeDjslhdxWrPJAwHt.Invoke(P_0);
		}
	}

	private static void ePIPVYjgNrTknhbderdmvWgfghzi(UpdateControllerInfoEventArgs P_0)
	{
		jCkgZLcnXoMycBxzcMXWvnUfSROEb.qIJKvNxZaquKrbzVxYfTtMmoiMbj(P_0);
	}

	private static void ruShuYbyhJqszTSTnDEgvonwdFuV(bool P_0)
	{
		if (!UJsvrGEMKlXkCjGlrRbNmdqzObVj)
		{
			return;
		}
		Action<bool> applicationFocusChangedEvent = _ApplicationFocusChangedEvent;
		if (applicationFocusChangedEvent == null)
		{
			return;
		}
		try
		{
			applicationFocusChangedEvent(P_0);
		}
		catch (Exception exception)
		{
			HandleCallbackException("ReInput.ApplicationFocusChangedEvent", exception);
		}
	}

	private static void ldKgMzcZUuhBgEoaKnhneCKAdoUqA(bool P_0)
	{
		if (!UJsvrGEMKlXkCjGlrRbNmdqzObVj)
		{
			return;
		}
		Action<bool> applicationPauseChangedEvent = _ApplicationPauseChangedEvent;
		if (applicationPauseChangedEvent == null)
		{
			return;
		}
		try
		{
			applicationPauseChangedEvent(P_0);
		}
		catch (Exception exception)
		{
			HandleCallbackException("ReInput.ApplicationPauseChangedEvent", exception);
		}
	}

	private static void bLevvQtaHpAvjcIMTgpdvhzMNXWT(bool P_0)
	{
		Action<bool> action = jhfEhJVTAtaukEVLNnMsaBKYsRoo;
		if (action != null)
		{
			try
			{
				action(P_0);
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.ApplicationIsFullScreenChangedEvent", exception);
			}
		}
	}

	private static void urZPZwprEGEDkxVLGIEquAQpGVMm(int P_0)
	{
		if (kUARjFQVZPLxFTSDhiFNQhjKSloP != null)
		{
			try
			{
				kUARjFQVZPLxFTSDhiFNQhjKSloP((FullScreenMode)P_0);
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.ApplicationFullScreenModeChangedEvent", exception);
			}
		}
	}

	private static void RQgANKbnmSPzORstVBqvZuLwsVwH(bool P_0)
	{
		Action<bool> gxIecdQzTjppWTXsXxbmwupczDYE = GxIecdQzTjppWTXsXxbmwupczDYE;
		if (gxIecdQzTjppWTXsXxbmwupczDYE != null)
		{
			try
			{
				gxIecdQzTjppWTXsXxbmwupczDYE(P_0);
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.ApplicationRunInBackgroundChangedEvent", exception);
			}
		}
	}

	private static void VkCJVxdWnKunRgvETBTWppjEhymY(bool P_0)
	{
		TNFnJuFPVFFcKErUnlbyWKLMKEmb++;
		Action<bool> action = yXmESBRKmvEpMuLxNCamFxEWigYA;
		if (action != null)
		{
			try
			{
				action(P_0);
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.TimeScalePauseChangedEvent", exception);
			}
		}
	}

	private static void bgmJSfsebRpyKEgkeMheVHZNjeJU()
	{
		if (uWFGARmQSApmyFkxwRvhWWkwDohH != null)
		{
			sqZFKBUtLMWfhHRgjCGqQnaysuCy();
			uWFGARmQSApmyFkxwRvhWWkwDohH.LUPravlxwsaWnkpJMDdZCBXoqtre.ChangedEvent += ruShuYbyhJqszTSTnDEgvonwdFuV;
			uWFGARmQSApmyFkxwRvhWWkwDohH.JVzdRvemOzvWdobxhSaGkeyRxRvD.ChangedEvent += ldKgMzcZUuhBgEoaKnhneCKAdoUqA;
			uWFGARmQSApmyFkxwRvhWWkwDohH.nkhtvJYMTLebPhByEUCNfQvwHZkiA.ChangedEvent += bLevvQtaHpAvjcIMTgpdvhzMNXWT;
			uWFGARmQSApmyFkxwRvhWWkwDohH.XUugLpvcebTXjZrMMPqnTGSddbpQ.ChangedEvent += RQgANKbnmSPzORstVBqvZuLwsVwH;
			uWFGARmQSApmyFkxwRvhWWkwDohH.ZasxBVxdAPBcVeTutcOLiPIIQxquB.ChangedEvent += urZPZwprEGEDkxVLGIEquAQpGVMm;
			uWFGARmQSApmyFkxwRvhWWkwDohH.fhgELFgzRwCpgdqZJxmTkegmwYPA.ChangedEvent += VkCJVxdWnKunRgvETBTWppjEhymY;
		}
	}

	private static void sqZFKBUtLMWfhHRgjCGqQnaysuCy()
	{
		if (uWFGARmQSApmyFkxwRvhWWkwDohH != null)
		{
			uWFGARmQSApmyFkxwRvhWWkwDohH.LUPravlxwsaWnkpJMDdZCBXoqtre.ChangedEvent -= ruShuYbyhJqszTSTnDEgvonwdFuV;
			uWFGARmQSApmyFkxwRvhWWkwDohH.JVzdRvemOzvWdobxhSaGkeyRxRvD.ChangedEvent -= ldKgMzcZUuhBgEoaKnhneCKAdoUqA;
			uWFGARmQSApmyFkxwRvhWWkwDohH.nkhtvJYMTLebPhByEUCNfQvwHZkiA.ChangedEvent -= bLevvQtaHpAvjcIMTgpdvhzMNXWT;
			uWFGARmQSApmyFkxwRvhWWkwDohH.XUugLpvcebTXjZrMMPqnTGSddbpQ.ChangedEvent -= RQgANKbnmSPzORstVBqvZuLwsVwH;
			uWFGARmQSApmyFkxwRvhWWkwDohH.ZasxBVxdAPBcVeTutcOLiPIIQxquB.ChangedEvent -= urZPZwprEGEDkxVLGIEquAQpGVMm;
			uWFGARmQSApmyFkxwRvhWWkwDohH.fhgELFgzRwCpgdqZJxmTkegmwYPA.ChangedEvent -= VkCJVxdWnKunRgvETBTWppjEhymY;
		}
	}

	private static void bBElupCmdPHXMhJiBTtRenPAjKvgb(bool P_0)
	{
		Action<bool> fKuNsEflurOJwjEnJrKWOAMINTyO = FKuNsEflurOJwjEnJrKWOAMINTyO;
		if (fKuNsEflurOJwjEnJrKWOAMINTyO != null)
		{
			try
			{
				fKuNsEflurOJwjEnJrKWOAMINTyO(P_0);
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.EditorPauseChangedEvent", exception);
			}
		}
	}

	private static void kuubVgtjMbHtChgcetKmTrqknMyXA(Func<ConfigVars, object> P_0, UnityTools.kJCrKrVttyLKcUctlPeIVyCNobPn P_1, Action<Platform> P_2)
	{
		bool flag = false;
		if (P_1.tAnpnFwESsGjkEhZHhdphDjgYrMOb != P_1.DjeEmVeAuBFSJuYnpeXjRVEfRKISA)
		{
			UnityTools.kJCrKrVttyLKcUctlPeIVyCNobPn kJCrKrVttyLKcUctlPeIVyCNobPn = P_1;
			kJCrKrVttyLKcUctlPeIVyCNobPn.tAnpnFwESsGjkEhZHhdphDjgYrMOb = P_1.DjeEmVeAuBFSJuYnpeXjRVEfRKISA;
			UnityTools.JAWFJjxZqzQqHSqWiZxZAuxZZZXC(kJCrKrVttyLKcUctlPeIVyCNobPn);
			P_2(kJCrKrVttyLKcUctlPeIVyCNobPn.DjeEmVeAuBFSJuYnpeXjRVEfRKISA);
			jHrBSiIXJHUXIFLvlerZMXKKEyce();
			flag = true;
		}
		if (!configVars.DoesPlatformUseFallback(P_1.DjeEmVeAuBFSJuYnpeXjRVEfRKISA, P_1.KuaCJUqRbxhJHiKTxFcCeVLmoPCv, isEditor) && !configVars.DoesPlatformUseFallback(P_1.tAnpnFwESsGjkEhZHhdphDjgYrMOb, P_1.KuaCJUqRbxhJHiKTxFcCeVLmoPCv, isEditor))
		{
			List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(KRXMNGqTUEuSZnzlexLlRTibdOwA);
			for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
			{
				if (componentsInSelfAndChildren[i].Initialize(P_1.DjeEmVeAuBFSJuYnpeXjRVEfRKISA, yZbloWHGkzkpTWiASTPgAShwAgah) is PlatformInputManager lDKYdkBTvBDiUqmQeCvGVejyVoZQ)
				{
					LDKYdkBTvBDiUqmQeCvGVejyVoZQ = lDKYdkBTvBDiUqmQeCvGVejyVoZQ;
					return;
				}
			}
		}
		if (flag)
		{
			UnityTools.JAWFJjxZqzQqHSqWiZxZAuxZZZXC(P_1);
			P_2(P_1.DjeEmVeAuBFSJuYnpeXjRVEfRKISA);
			jHrBSiIXJHUXIFLvlerZMXKKEyce();
			flag = false;
		}
		if (configVars.DoesPlatformUseFallback(mEwnOsXbuQEGmLDxEkROAPjAjYOT, LTMHQkwtBevmTaFeQRmrJrgDCMzf, isEditor))
		{
			sJwPaphnMJCMJkgqAeoxPkqvHssEb = true;
			LDKYdkBTvBDiUqmQeCvGVejyVoZQ = new JRJujyYkIYDcAFcIVJVNsJrvvVWuA(yZbloWHGkzkpTWiASTPgAShwAgah.updateLoop);
		}
		else if (mEwnOsXbuQEGmLDxEkROAPjAjYOT == Platform.Windows || mEwnOsXbuQEGmLDxEkROAPjAjYOT == Platform.WindowsAppStore || mEwnOsXbuQEGmLDxEkROAPjAjYOT == Platform.WindowsUWP || mEwnOsXbuQEGmLDxEkROAPjAjYOT == Platform.OSX || mEwnOsXbuQEGmLDxEkROAPjAjYOT == Platform.Linux)
		{
			LDKYdkBTvBDiUqmQeCvGVejyVoZQ = P_0(yZbloWHGkzkpTWiASTPgAShwAgah) as PlatformInputManager;
		}
		else if (mEwnOsXbuQEGmLDxEkROAPjAjYOT == Platform.WebGL && !isEditor)
		{
			try
			{
				LDKYdkBTvBDiUqmQeCvGVejyVoZQ = P_0(yZbloWHGkzkpTWiASTPgAShwAgah) as PlatformInputManager;
				if (LDKYdkBTvBDiUqmQeCvGVejyVoZQ == null)
				{
					throw new Exception();
				}
			}
			catch
			{
				Logger.LogError("WebGL platform could not be initialized! Is the Rewired WebGL library installed? See the documentation for more information.");
				LDKYdkBTvBDiUqmQeCvGVejyVoZQ = null;
			}
		}
		else if (mEwnOsXbuQEGmLDxEkROAPjAjYOT == Platform.XboxOne && !isEditor)
		{
			try
			{
				LDKYdkBTvBDiUqmQeCvGVejyVoZQ = new CustomInputManager(new XboxOneInputSource(), yZbloWHGkzkpTWiASTPgAShwAgah.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
				if (LDKYdkBTvBDiUqmQeCvGVejyVoZQ == null)
				{
					throw new Exception();
				}
			}
			catch
			{
				Logger.LogError("Xbox One platform could not be initialized! Is the Rewired Xbox One library installed? See the documentation for more information.");
				LDKYdkBTvBDiUqmQeCvGVejyVoZQ = null;
			}
		}
		else if (mEwnOsXbuQEGmLDxEkROAPjAjYOT == Platform.PS4 && !isEditor)
		{
			try
			{
				LDKYdkBTvBDiUqmQeCvGVejyVoZQ = P_0(yZbloWHGkzkpTWiASTPgAShwAgah) as PlatformInputManager;
				if (LDKYdkBTvBDiUqmQeCvGVejyVoZQ == null)
				{
					throw new Exception("Input Manager was null.");
				}
			}
			catch (Exception msg)
			{
				Logger.LogError("PS4 platform could not be initialized! Is the Rewired PS4 plugin installed? See the documentation for more information.");
				Logger.LogError(msg);
				LDKYdkBTvBDiUqmQeCvGVejyVoZQ = null;
			}
		}
		else if (mEwnOsXbuQEGmLDxEkROAPjAjYOT == Platform.PS5 && !isEditor)
		{
			try
			{
				LDKYdkBTvBDiUqmQeCvGVejyVoZQ = P_0(yZbloWHGkzkpTWiASTPgAShwAgah) as PlatformInputManager;
				if (LDKYdkBTvBDiUqmQeCvGVejyVoZQ == null)
				{
					throw new Exception("Input Manager was null.");
				}
			}
			catch (Exception msg2)
			{
				Logger.LogError("PS5 platform could not be initialized! Is the Rewired PS5 plugin installed? See the documentation for more information.");
				Logger.LogError(msg2);
				LDKYdkBTvBDiUqmQeCvGVejyVoZQ = null;
			}
		}
		else if ((mEwnOsXbuQEGmLDxEkROAPjAjYOT == Platform.GameCoreXboxOne || mEwnOsXbuQEGmLDxEkROAPjAjYOT == Platform.GameCoreScarlett) && !isEditor)
		{
			try
			{
				LDKYdkBTvBDiUqmQeCvGVejyVoZQ = P_0(yZbloWHGkzkpTWiASTPgAShwAgah) as PlatformInputManager;
				if (LDKYdkBTvBDiUqmQeCvGVejyVoZQ == null)
				{
					throw new Exception("Input Manager was null.");
				}
			}
			catch (Exception msg3)
			{
				string text = ((mEwnOsXbuQEGmLDxEkROAPjAjYOT == Platform.GameCoreXboxOne) ? "Xbox One" : "Xbox Series X");
				Logger.LogError(text + " platform could not be initialized! Is the Rewired " + text + " library installed? See the documentation for more information.");
				Logger.LogError(msg3);
				LDKYdkBTvBDiUqmQeCvGVejyVoZQ = null;
			}
		}
		else if (mEwnOsXbuQEGmLDxEkROAPjAjYOT == Platform.Ouya && !isEditor)
		{
			Logger.LogError("Ouya is no longer supported.");
			LDKYdkBTvBDiUqmQeCvGVejyVoZQ = null;
		}
		else if (UnityTools.isAndroidPlatform && !isEditor)
		{
			try
			{
				UnityTools.CYBMOsUBiwTvgCKlsHchrluYbiZj(P_0(yZbloWHGkzkpTWiASTPgAShwAgah) as IAndroidFallbackPlatformHelper);
			}
			catch (Exception msg4)
			{
				Logger.LogError(msg4);
			}
		}
		else if (mEwnOsXbuQEGmLDxEkROAPjAjYOT == Platform.Custom)
		{
			try
			{
				LDKYdkBTvBDiUqmQeCvGVejyVoZQ = new CustomInputManager(DYXEicTUvpxnVFlTbwIfiujTNpTs.ectXnsdbCBpTYMmJvRmxynhQNLbY(), yZbloWHGkzkpTWiASTPgAShwAgah.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
				if (LDKYdkBTvBDiUqmQeCvGVejyVoZQ == null)
				{
					throw new Exception();
				}
			}
			catch
			{
				Logger.LogError("Custom platform could not be initialized due to an exception!");
				LDKYdkBTvBDiUqmQeCvGVejyVoZQ = null;
				throw;
			}
		}
		if (LDKYdkBTvBDiUqmQeCvGVejyVoZQ == null)
		{
			sJwPaphnMJCMJkgqAeoxPkqvHssEb = true;
			LDKYdkBTvBDiUqmQeCvGVejyVoZQ = new JRJujyYkIYDcAFcIVJVNsJrvvVWuA(yZbloWHGkzkpTWiASTPgAShwAgah.updateLoop);
		}
	}

	private static void cvBXFIYYtKQDyHhnjwFGIgwpbSQeA()
	{
		if (AuSbamOqiesJxxIIDbYQFwfSutfu != yZbloWHGkzkpTWiASTPgAShwAgah.GetPlatformVar_ignoreInputWhenAppNotInFocus())
		{
			AuSbamOqiesJxxIIDbYQFwfSutfu = !AuSbamOqiesJxxIIDbYQFwfSutfu;
		}
	}

	private static void ushfbTaMWlLMaQtgAAdncLXaYfwaB()
	{
		if (!(UnityTools.unityVersionObj == null))
		{
			string[] obj = new string[7] { "The version of Rewired installed (", programVersion, ") was not designed for Unity ", null, null, null, null };
			int major = UnityTools.unityVersionObj.major;
			obj[3] = major.ToString();
			obj[4] = ". Please install Rewired for Unity ";
			major = UnityTools.unityVersionObj.major;
			obj[5] = major.ToString();
			obj[6] = ".\n\nThis warning does not mean that Rewired will not function, but it may not function optimally.\n\nSome different major versions of Unity download Asset Store assets to the same folder location on disk, so if you download an asset in one version of the Unity editor, then open another version of the Unity editor and install the asset without re-downloading it, the wrong asset version will be installed. To fix this, manually re-download Rewired in the Unity Asset Store panel in this version of the Unity Editor, then install it.\n\nIf you are using a beta version of a new major version of Unity, you will have to wait until the release of the final version before a compatible version of Rewired can be uploaded to the Asset Store. When the new version is ready, it will be available through the Unity Asset Store for download as usual.";
			Logger.LogWarning(string.Concat(obj));
		}
	}
}
