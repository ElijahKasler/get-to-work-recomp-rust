using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Automation;

public struct AutomationFactoryParams
{
	public int pileCount;

	public int pileSize;

	public Recipe recipe;

	public string Id;

	public Vector3Int entranceOffset;

	public bool allowIntakeWhileCooking;

	public bool createDisplayItemOnOutput;

	public bool pullFromSpaceInfront;

	public List<Vector3> footPrint;

	public AutomationFactoryParams(int pileCount, int pileSize, Recipe recipe, string id, List<Vector3> footPrint, Vector3 entranceOffset, bool allowIntakeWhileCooking = true, bool createDisplayItemOnOutput = true, bool pullFromSpaceInfront = false)
	{
		this.pileCount = pileCount;
		this.pileSize = pileSize;
		this.recipe = recipe;
		Id = id;
		this.footPrint = footPrint;
		this.entranceOffset = new Vector3Int(Mathf.RoundToInt(entranceOffset.x), Mathf.RoundToInt(entranceOffset.y), Mathf.RoundToInt(entranceOffset.z));
		this.allowIntakeWhileCooking = allowIntakeWhileCooking;
		this.createDisplayItemOnOutput = createDisplayItemOnOutput;
		this.pullFromSpaceInfront = pullFromSpaceInfront;
	}

	public AutomationFactoryParams(int pileCount, int pileSize, Recipe recipe, string id, List<Vector3> footPrint)
	{
		this.pileCount = pileCount;
		this.pileSize = pileSize;
		this.recipe = recipe;
		Id = id;
		this.footPrint = footPrint;
		entranceOffset = Vector3Int.zero;
		allowIntakeWhileCooking = true;
		createDisplayItemOnOutput = true;
		pullFromSpaceInfront = false;
	}
}
