using System;

namespace Isto.Core.Automation;

[Serializable]
public class ResearchBoosts
{
	public string boostItemID;

	public float boost;

	public float cookTime;

	public float timeRemaing;

	public ResearchBoosts()
	{
		boostItemID = "";
		boost = 0f;
		cookTime = 0f;
		timeRemaing = 0f;
	}

	public ResearchBoosts(string boostItemID, float boost, float cookTime, float timeRemaing)
	{
		this.boostItemID = boostItemID;
		this.boost = boost;
		this.cookTime = cookTime;
		this.timeRemaing = timeRemaing;
	}
}
