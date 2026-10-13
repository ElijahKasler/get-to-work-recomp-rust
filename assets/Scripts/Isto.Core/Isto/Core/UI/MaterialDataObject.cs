using System;
using UnityEngine;

namespace Isto.Core.UI;

[Serializable]
[CreateAssetMenu(fileName = "MaterialData", menuName = "Scriptables/Core Button/State Data/Material Data")]
public class MaterialDataObject : ScriptableObject
{
	public MaterialData data = new MaterialData();
}
