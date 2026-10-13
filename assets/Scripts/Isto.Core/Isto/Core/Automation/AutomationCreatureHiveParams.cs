using UnityEngine;

namespace Isto.Core.Automation;

public struct AutomationCreatureHiveParams(string iD, string creatureAssetGUID, string stockPileitemId, int pileCount, int pileSize, int maxCreatureCount, float timePerSpawn, Vector3 creatureRange, Vector3 itemDroppingPosition, Vector3 hiveDirection)
{
	public string ID = iD;

	public string CreatureAssetGUID = creatureAssetGUID;

	public string StockPiledItemId = stockPileitemId;

	public int pileCount = pileCount;

	public int pileSize = pileSize;

	public int maxCreatureCount = maxCreatureCount;

	public float timePerSpawn = timePerSpawn;

	public Vector3 creatureRange = creatureRange;

	public Vector3 itemDroppingPosition = itemDroppingPosition;

	public Vector3 hiveDirection = hiveDirection;
}
