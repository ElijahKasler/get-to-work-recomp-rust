using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools;

[AddComponentMenu("")]
[RequireComponent(typeof(Rewired.Internal.GUIText))]
public sealed class RawInputJoystickElementIdentifier : MonoBehaviour
{
	private IElementIdentifierTool GqkVZRcKwEFoorREocSjPffBzzyd;

	public void Awake()
	{
		if (MelrbQkWwLGdFOjwWFxXtwLexhGb())
		{
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
			}
			GqkVZRcKwEFoorREocSjPffBzzyd = WLHyglkvLCgBAaUurZlEETLlMZMg.FGBGtvYdfOglTDIdJrNDuUndQlxDb("Rewired_Windows", "RawInput") as IElementIdentifierTool;
			if (GqkVZRcKwEFoorREocSjPffBzzyd == null)
			{
				Logger.LogError("RawInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
			}
			else
			{
				GqkVZRcKwEFoorREocSjPffBzzyd.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
			}
		}
	}

	public void Start()
	{
		if (GqkVZRcKwEFoorREocSjPffBzzyd != null)
		{
			GqkVZRcKwEFoorREocSjPffBzzyd.Start();
		}
	}

	public void Update()
	{
		if (GqkVZRcKwEFoorREocSjPffBzzyd != null)
		{
			GqkVZRcKwEFoorREocSjPffBzzyd.Update();
		}
	}

	public void OnDestroy()
	{
		if (GqkVZRcKwEFoorREocSjPffBzzyd != null)
		{
			GqkVZRcKwEFoorREocSjPffBzzyd.OnDestroy();
		}
		GqkVZRcKwEFoorREocSjPffBzzyd = null;
	}

	private bool MelrbQkWwLGdFOjwWFxXtwLexhGb()
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
