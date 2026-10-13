using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Dev.Tools;

[AddComponentMenu("")]
[RequireComponent(typeof(Rewired.Internal.GUIText))]
public sealed class JoystickElementIdentifier : MonoBehaviour
{
	private IElementIdentifierTool dGfZVggcMmhzpcCgXBAWpsLFeXIWA;

	public void Awake()
	{
		if (!RCLSYUKEktnJrkSXsfpjLJCNuJvU())
		{
			return;
		}
		if (base.transform.position != Vector3.zero)
		{
			base.transform.position = Vector3.zero;
		}
		if (ReInput.UserData.ConfigVars.alwaysUseUnityInput || ReInput.usingUnityInput)
		{
			dGfZVggcMmhzpcCgXBAWpsLFeXIWA = new ZaZakljPCuZqhaGAAJIhKqiAGYyfA();
		}
		else
		{
			Platform platform = UnityTools.platform;
			if (UnityTools.isEditor)
			{
				switch (UnityTools.editorPlatform)
				{
				case EditorPlatform.Windows:
					platform = Platform.Windows;
					break;
				case EditorPlatform.OSX:
					platform = Platform.OSX;
					break;
				case EditorPlatform.Linux:
					platform = Platform.Linux;
					break;
				}
			}
			InputSource inputSourceType = ReInput.primaryInputManager.inputSourceType;
			if (inputSourceType == InputSource.Fallback || inputSourceType == InputSource.Fallback_PreConfigured)
			{
				dGfZVggcMmhzpcCgXBAWpsLFeXIWA = new ZaZakljPCuZqhaGAAJIhKqiAGYyfA();
			}
			if (dGfZVggcMmhzpcCgXBAWpsLFeXIWA == null)
			{
				switch (platform)
				{
				case Platform.Windows:
					switch (ReInput.primaryInputManager.inputSourceType)
					{
					case InputSource.DirectInput:
						dGfZVggcMmhzpcCgXBAWpsLFeXIWA = WLHyglkvLCgBAaUurZlEETLlMZMg.FGBGtvYdfOglTDIdJrNDuUndQlxDb("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
						break;
					case InputSource.RawInput:
						dGfZVggcMmhzpcCgXBAWpsLFeXIWA = WLHyglkvLCgBAaUurZlEETLlMZMg.FGBGtvYdfOglTDIdJrNDuUndQlxDb("Rewired_Windows", "RawInput") as IElementIdentifierTool;
						break;
					}
					break;
				case Platform.WindowsAppStore:
					dGfZVggcMmhzpcCgXBAWpsLFeXIWA = new ZaZakljPCuZqhaGAAJIhKqiAGYyfA();
					break;
				case Platform.WindowsUWP:
					dGfZVggcMmhzpcCgXBAWpsLFeXIWA = WLHyglkvLCgBAaUurZlEETLlMZMg.FGBGtvYdfOglTDIdJrNDuUndQlxDb("", "WindowsUWP") as IElementIdentifierTool;
					break;
				case Platform.OSX:
					dGfZVggcMmhzpcCgXBAWpsLFeXIWA = WLHyglkvLCgBAaUurZlEETLlMZMg.FGBGtvYdfOglTDIdJrNDuUndQlxDb("Rewired_OSX", "OSX") as IElementIdentifierTool;
					break;
				case Platform.Linux:
					dGfZVggcMmhzpcCgXBAWpsLFeXIWA = WLHyglkvLCgBAaUurZlEETLlMZMg.FGBGtvYdfOglTDIdJrNDuUndQlxDb("Rewired_Linux", "Linux") as IElementIdentifierTool;
					break;
				case Platform.WebGL:
					dGfZVggcMmhzpcCgXBAWpsLFeXIWA = WLHyglkvLCgBAaUurZlEETLlMZMg.FGBGtvYdfOglTDIdJrNDuUndQlxDb("Rewired_WebGL", "WebGL") as IElementIdentifierTool;
					break;
				case Platform.GameCoreXboxOne:
				case Platform.GameCoreScarlett:
					dGfZVggcMmhzpcCgXBAWpsLFeXIWA = WLHyglkvLCgBAaUurZlEETLlMZMg.FGBGtvYdfOglTDIdJrNDuUndQlxDb("Rewired_GameCore", "GameCore") as IElementIdentifierTool;
					break;
				}
			}
		}
		if (dGfZVggcMmhzpcCgXBAWpsLFeXIWA == null)
		{
			Logger.LogWarning("There was an error initializing the platform tool for the current platform and input source. Unity input will be shown instead.");
			dGfZVggcMmhzpcCgXBAWpsLFeXIWA = new ZaZakljPCuZqhaGAAJIhKqiAGYyfA();
		}
		dGfZVggcMmhzpcCgXBAWpsLFeXIWA.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
	}

	public void Start()
	{
		if (dGfZVggcMmhzpcCgXBAWpsLFeXIWA != null)
		{
			dGfZVggcMmhzpcCgXBAWpsLFeXIWA.Start();
		}
	}

	public void Update()
	{
		if (dGfZVggcMmhzpcCgXBAWpsLFeXIWA != null)
		{
			dGfZVggcMmhzpcCgXBAWpsLFeXIWA.Update();
		}
	}

	public void OnDestroy()
	{
		if (dGfZVggcMmhzpcCgXBAWpsLFeXIWA != null)
		{
			dGfZVggcMmhzpcCgXBAWpsLFeXIWA.OnDestroy();
		}
		dGfZVggcMmhzpcCgXBAWpsLFeXIWA = null;
	}

	private bool RCLSYUKEktnJrkSXsfpjLJCNuJvU()
	{
		if (!ReInput.isReady)
		{
			Logger.LogError("No active Rewired Input Manager was found in the scene! You must create a Rewired Input Manager for the tool to function.");
			return false;
		}
		return true;
	}
}
