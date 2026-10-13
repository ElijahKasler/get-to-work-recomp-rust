using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools;

[AddComponentMenu("")]
[RequireComponent(typeof(Rewired.Internal.GUIText))]
public sealed class OSXJoystickElementIdentifier : MonoBehaviour
{
	private IElementIdentifierTool SoxwftgTCMbcIbtWAdeRhdzVhdBU;

	public void Awake()
	{
		if (EsmyZmNeAzRGwhYuExYwgbFXzeie())
		{
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
			}
			SoxwftgTCMbcIbtWAdeRhdzVhdBU = WLHyglkvLCgBAaUurZlEETLlMZMg.FGBGtvYdfOglTDIdJrNDuUndQlxDb("Rewired_OSX", "OSX") as IElementIdentifierTool;
			if (SoxwftgTCMbcIbtWAdeRhdzVhdBU == null)
			{
				Logger.LogError("OSX Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
			}
			else
			{
				SoxwftgTCMbcIbtWAdeRhdzVhdBU.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
			}
		}
	}

	public void Start()
	{
		if (SoxwftgTCMbcIbtWAdeRhdzVhdBU != null)
		{
			SoxwftgTCMbcIbtWAdeRhdzVhdBU.Start();
		}
	}

	public void Update()
	{
		if (SoxwftgTCMbcIbtWAdeRhdzVhdBU != null)
		{
			SoxwftgTCMbcIbtWAdeRhdzVhdBU.Update();
		}
	}

	public void OnDestroy()
	{
		if (SoxwftgTCMbcIbtWAdeRhdzVhdBU != null)
		{
			SoxwftgTCMbcIbtWAdeRhdzVhdBU.OnDestroy();
		}
		SoxwftgTCMbcIbtWAdeRhdzVhdBU = null;
	}

	private bool EsmyZmNeAzRGwhYuExYwgbFXzeie()
	{
		InputManager_Base[] array = (InputManager_Base[])Object.FindObjectsOfType(typeof(InputManager_Base));
		if (array == null || array.Length == 0)
		{
			Logger.LogError("No active Rewired Input Manager was found in the scene! You must create a Rewired Input Manager for the tool to function.");
			return false;
		}
		return true;
	}
}
