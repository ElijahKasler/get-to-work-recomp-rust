using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Isto.GTW.Dialogues;

public class DialogueSystemTriggerQueueable : DialogueSystemTrigger
{
	protected override void DoConversationAction(Transform actor)
	{
		Transform actor2 = PixelCrushers.DialogueSystem.Tools.Select(conversationActor, actor);
		Transform transform = conversationConversant;
		if (transform == null)
		{
			Conversation conversation = DialogueManager.MasterDatabase.GetConversation(base.conversation);
			Actor actor3 = DialogueManager.MasterDatabase.GetActor(conversation.ConversantID);
			Transform transform2 = ((actor3 != null) ? PixelCrushers.DialogueSystem.CharacterInfo.GetRegisteredActorTransform(actor3.Name) : null);
			transform = ((transform2 != null) ? transform2 : base.transform);
		}
		ConversationQueueManager.instance.AddConversation(base.conversation, actor2, transform);
	}
}
