using System;
using System.Xml.Serialization;
using UnityEngine;

namespace Isto.Core.Data;

[Serializable]
[XmlRoot("CorePlayerData")]
public class PlayerSaveData
{
	public Vector3 position;

	public bool ContentEquals(PlayerSaveData other)
	{
		if (other == null)
		{
			return false;
		}
		if (position != other.position)
		{
			return false;
		}
		return true;
	}
}
