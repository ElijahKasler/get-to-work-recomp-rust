using System;
using UnityEngine;

namespace Isto.Core.UI;

[Serializable]
[CreateAssetMenu(fileName = "Vector3Data", menuName = "Scriptables/Core Button/State Data/Vector 3 Data")]
public class Vector3DataObject : ScriptableObject
{
	public Vector3Data data = new Vector3Data();

	private void OnValidate()
	{
		data.UpdateAnimLength();
	}
}
