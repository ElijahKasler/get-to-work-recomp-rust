using System;
using UnityEngine;

namespace Isto.Core.Inputs;

[Serializable]
public class ControlInput
{
	public UserActions action;

	public float timeBeforeAction;

	public Vector3 position;

	public string description;

	public Color sphereColor = Color.yellow;
}
