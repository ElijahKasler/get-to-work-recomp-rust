using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Serialization;

namespace Isto.GTW.Data;

[Serializable]
[XmlRoot("PlayerData")]
public class PlayerSaveData
{
	public Vector3 position;

	public Vector3 forward;

	public Vector3 velocity;

	public Vector3 angularVelocity;

	[FormerlySerializedAs("checkpoingId")]
	public int checkpointId = -1;

	[FormerlySerializedAs("seenCheckoints")]
	public List<int> seenCheckpoints;

	public float totalGameTime;

	public float totalGameTimeUnscaled;

	public float totalHeightGained;

	public float totalDistanceFallen;

	public int totalBigCrashes;

	public int dunceHatsCollected;

	public bool giveUpAbility;

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
		if (forward != other.forward)
		{
			return false;
		}
		if (velocity != other.velocity)
		{
			return false;
		}
		if (angularVelocity != other.angularVelocity)
		{
			return false;
		}
		if (totalGameTime != other.totalGameTime)
		{
			return false;
		}
		if (totalGameTimeUnscaled != other.totalGameTimeUnscaled)
		{
			return false;
		}
		if (totalHeightGained != other.totalHeightGained)
		{
			return false;
		}
		if (totalDistanceFallen != other.totalDistanceFallen)
		{
			return false;
		}
		if (totalBigCrashes != other.totalBigCrashes)
		{
			return false;
		}
		if (dunceHatsCollected != other.dunceHatsCollected)
		{
			return false;
		}
		if (giveUpAbility != other.giveUpAbility)
		{
			return false;
		}
		return true;
	}
}
