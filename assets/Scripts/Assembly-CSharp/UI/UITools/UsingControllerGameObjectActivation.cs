using Isto.Core.Inputs;
using UnityEngine;

namespace UI.UITools;

public class UsingControllerGameObjectActivation : MonoBehaviour
{
	[SerializeField]
	private GameObject[] _controllerObjects;

	[SerializeField]
	private GameObject[] _keyboardObjects;

	private bool _previousUsingController;

	private void Awake()
	{
		UpdateActivation();
	}

	private void Update()
	{
		if (Controls.UsingController != _previousUsingController)
		{
			UpdateActivation();
		}
	}

	private void UpdateActivation()
	{
		_previousUsingController = Controls.UsingController;
		GameObject[] controllerObjects = _controllerObjects;
		for (int i = 0; i < controllerObjects.Length; i++)
		{
			controllerObjects[i].SetActive(_previousUsingController);
		}
		controllerObjects = _keyboardObjects;
		for (int i = 0; i < controllerObjects.Length; i++)
		{
			controllerObjects[i].SetActive(!_previousUsingController);
		}
	}
}
