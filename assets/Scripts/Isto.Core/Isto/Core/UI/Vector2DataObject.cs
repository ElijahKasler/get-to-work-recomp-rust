using System;
using UnityEngine;

namespace Isto.Core.UI;

[Serializable]
[CreateAssetMenu(fileName = "Vector2Data", menuName = "Scriptables/Core Button/State Data/Vector 2 Data")]
public class Vector2DataObject : ScriptableObject
{
	public Vector2Data data = new Vector2Data();

	private void OnValidate()
	{
		data.UpdateAnimLength();
	}
}
