using Isto.Core;
using Isto.Core.Audio;
using Isto.GTW.Audio;
using Isto.GTW.Dialogues;
using Isto.GTW.LevelFeatures;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelEvents.LevelEvents;

public class DialogueEvent : LevelEvent
{
	public DialogueDatabase selectedDatabase;

	[ConversationPopup(false)]
	public string conversation;

	[Tooltip("Queue the conversation if another conversation is playing. Uncheck to not play the conversation if another is currently playing or in queue.")]
	[SerializeField]
	private bool _queueConversation = true;

	[SerializeField]
	private bool _stopAllButThisConversation;

	[SerializeField]
	private Transform _conversationActor;

	[SerializeField]
	private Transform _conversationConversant;

	private GTWGameState _gtwGameState;

	private GTWGameSounds _sounds;

	public string UniqueID => conversation;

	[Inject]
	public void Inject(GTWGameState gameState, IGameSounds sounds)
	{
		_gtwGameState = gameState;
		_sounds = sounds as GTWGameSounds;
	}

	public override void TriggerEvent(bool initialization = false)
	{
		if (!initialization)
		{
			StartConversation();
		}
	}

	protected void StartConversation()
	{
		if (_queueConversation || !ConversationQueueManager.instance.IsConversationPlayingOrWaitingToPlay)
		{
			if (_stopAllButThisConversation)
			{
				ConversationQueueManager.instance.ClearQueue();
				DialogueManager.StopConversation();
				_sounds.StopAllEventInstances();
			}
			Transform actor = PixelCrushers.DialogueSystem.Tools.Select(_conversationActor, null);
			Transform transform = _conversationConversant;
			if (transform == null)
			{
				Conversation conversation = DialogueManager.MasterDatabase.GetConversation(this.conversation);
				Actor actor2 = DialogueManager.MasterDatabase.GetActor(conversation.ConversantID);
				Transform transform2 = ((actor2 != null) ? PixelCrushers.DialogueSystem.CharacterInfo.GetRegisteredActorTransform(actor2.Name) : null);
				transform = ((transform2 != null) ? transform2 : base.transform);
			}
			ConversationQueueManager.instance.AddConversation(this.conversation, actor, transform);
			if (!_gtwGameState.IsDoinklerPortfolio && !_gtwGameState.IsDoinklerSpecial)
			{
				Events.RaiseEvent(GTWEvents.DIALOGUE_EVENT);
			}
		}
	}
}
