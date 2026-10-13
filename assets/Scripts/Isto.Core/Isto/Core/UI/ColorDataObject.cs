using System;
using UnityEngine;

namespace Isto.Core.UI;

[Serializable]
[CreateAssetMenu(fileName = "ColorData", menuName = "Scriptables/Core Button/State Data/Color Data")]
public class ColorDataObject : ColorDataObjectBase
{
	public ColorData data = new ColorData();

	public override IData GetData()
	{
		return data;
	}
}
