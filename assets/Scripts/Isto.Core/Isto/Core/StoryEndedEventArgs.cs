using System;

namespace Isto.Core;

public class StoryEndedEventArgs : EventArgs
{
	public string conversationID;

	public StoryEndedEventArgs(string conversationID)
	{
		this.conversationID = conversationID;
	}
}
