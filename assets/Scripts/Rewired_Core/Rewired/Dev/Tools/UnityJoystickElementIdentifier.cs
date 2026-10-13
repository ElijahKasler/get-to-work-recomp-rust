using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools;

[AddComponentMenu("")]
[RequireComponent(typeof(Rewired.Internal.GUIText))]
public sealed class UnityJoystickElementIdentifier : MonoBehaviour
{
	private IElementIdentifierTool obhgsHUfOcLgSMrRBAHvkBykXrXv;

	public void Awake()
	{
		obhgsHUfOcLgSMrRBAHvkBykXrXv = new ZaZakljPCuZqhaGAAJIhKqiAGYyfA();
		obhgsHUfOcLgSMrRBAHvkBykXrXv.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
	}

	public void Start()
	{
		obhgsHUfOcLgSMrRBAHvkBykXrXv.Start();
	}

	public void Update()
	{
		obhgsHUfOcLgSMrRBAHvkBykXrXv.Update();
	}

	public void OnDestroy()
	{
		obhgsHUfOcLgSMrRBAHvkBykXrXv.OnDestroy();
	}
}
