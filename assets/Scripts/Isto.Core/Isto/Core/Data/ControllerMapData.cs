using System;
using Rewired;

namespace Isto.Core.Data;

[Serializable]
public class ControllerMapData
{
	public ControllerType type;

	public int categoryID;

	public string xmlString;
}
