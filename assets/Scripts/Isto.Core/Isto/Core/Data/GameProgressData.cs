using System.Xml.Serialization;

namespace Isto.Core.Data;

public class GameProgressData
{
	[XmlAttribute("ActionID")]
	public string progressActionID;

	[XmlAttribute("Completed")]
	public bool completed;

	[XmlAttribute("Started")]
	public bool started;

	public GameProgressData()
	{
	}

	public GameProgressData(string actionID)
	{
		progressActionID = actionID;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is GameProgressData gameProgressData))
		{
			return false;
		}
		if (!progressActionID.IsEqualWithNullsAsEmpty(gameProgressData.progressActionID))
		{
			return false;
		}
		if (completed != gameProgressData.completed)
		{
			return false;
		}
		return started == gameProgressData.started;
	}

	public override int GetHashCode()
	{
		return (progressActionID, completed, started).GetHashCode();
	}
}
