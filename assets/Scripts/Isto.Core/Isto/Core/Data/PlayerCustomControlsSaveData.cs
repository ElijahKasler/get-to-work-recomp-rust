using System;
using System.Collections.Generic;

namespace Isto.Core.Data;

[Serializable]
public class PlayerCustomControlsSaveData
{
	public List<ControllerMapData> mapDatas;

	public PlayerCustomControlsSaveData()
	{
		mapDatas = new List<ControllerMapData>();
	}
}
