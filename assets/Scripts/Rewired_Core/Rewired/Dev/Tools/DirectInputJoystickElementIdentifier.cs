using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools;

[AddComponentMenu("")]
[RequireComponent(typeof(Rewired.Internal.GUIText))]
public sealed class DirectInputJoystickElementIdentifier : MonoBehaviour
{
	private IElementIdentifierTool KIMmgcICokKmwFsVXkxNEnuEHgYP;

	public void Awake()
	{
		if (UBOVYoJKqVxquflFUdpouSvYYJuG())
		{
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
			}
			KIMmgcICokKmwFsVXkxNEnuEHgYP = WLHyglkvLCgBAaUurZlEETLlMZMg.FGBGtvYdfOglTDIdJrNDuUndQlxDb("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
			if (KIMmgcICokKmwFsVXkxNEnuEHgYP == null)
			{
				Logger.LogError("DirectInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
			}
			else
			{
				KIMmgcICokKmwFsVXkxNEnuEHgYP.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
			}
		}
	}

	public void Start()
	{
		if (KIMmgcICokKmwFsVXkxNEnuEHgYP != null)
		{
			KIMmgcICokKmwFsVXkxNEnuEHgYP.Start();
		}
	}

	public void Update()
	{
		if (KIMmgcICokKmwFsVXkxNEnuEHgYP != null)
		{
			KIMmgcICokKmwFsVXkxNEnuEHgYP.Update();
		}
	}

	public void OnDestroy()
	{
		if (KIMmgcICokKmwFsVXkxNEnuEHgYP != null)
		{
			KIMmgcICokKmwFsVXkxNEnuEHgYP.OnDestroy();
		}
		KIMmgcICokKmwFsVXkxNEnuEHgYP = null;
	}

	private bool UBOVYoJKqVxquflFUdpouSvYYJuG()
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
