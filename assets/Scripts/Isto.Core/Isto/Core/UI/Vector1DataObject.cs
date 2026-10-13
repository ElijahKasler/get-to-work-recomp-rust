using System;
using UnityEngine;

namespace Isto.Core.UI;

[Serializable]
[CreateAssetMenu(fileName = "Vector1Data", menuName = "Scriptables/Core Button/State Data/Vector 1 Data")]
public class Vector1DataObject : ScriptableObject
{
	public Vector1Data data = new Vector1Data();

	private void OnValidate()
	{
		data.UpdateAnimLength();
	}
}
