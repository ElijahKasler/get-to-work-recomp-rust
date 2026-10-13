using Isto.Core.Automation;
using UnityEngine;

namespace Isto.Core.UI;

public interface IUIMessages
{
	void CreateMessage(string localizedMessage, Sprite icon = null, float displayTime = 0f);

	void CreateProgressMessage(string message, CraftingQueue queue, Sprite sprite = null);

	void CreateHighPriorityMsg(string localizedMessage, HighPriorityMessage.MessageType msgType, float displayTime = 0f);

	void SetCraftingMessageLocations(Vector3 craftingQueueLocation, Vector3 craftingMessagesLocation);
}
