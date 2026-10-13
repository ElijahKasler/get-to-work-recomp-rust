using System;
using Isto.Core.Automation;
using Isto.Core.UI;
using UnityEngine;

public class UIMessagesAsLogs : IUIMessages, IUIDisplayMessage
{
	public void CreateHighPriorityMsg(string localizedMessage, HighPriorityMessage.MessageType msgType, float displayTime = 0f)
	{
		Debug.Log($"UI HP Message: [{msgType}] {localizedMessage}");
	}

	public void CreateMessage(string localizedMessage, Sprite icon = null, float displayTime = 0f)
	{
		Debug.Log("UI Message: " + localizedMessage);
	}

	public void CreateProgressMessage(string message, CraftingQueue queue, Sprite sprite = null)
	{
		Debug.Log("UI Queue Message: " + message);
	}

	public void DisplayMessage(string message, float time)
	{
		throw new NotImplementedException();
	}

	public void SetCraftingMessageLocations(Vector3 craftingQueueLocation, Vector3 craftingMessagesLocation)
	{
	}
}
