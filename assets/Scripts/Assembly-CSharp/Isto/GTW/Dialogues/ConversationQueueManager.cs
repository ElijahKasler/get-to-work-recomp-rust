using System;
using System.Collections.Generic;
using System.Linq;
using Isto.Core.Audio;
using Isto.GTW.Audio;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using Zenject;

namespace Isto.GTW.Dialogues;

public class ConversationQueueManager : MonoBehaviour
{
	[Serializable]
	public class QueuedConversation
	{
		public string queuedConversation;

		public Transform queuedActor;

		public Transform queuedConversant;
	}

	public static ConversationQueueManager instance;

	public bool useBacktracker;

	private Queue<QueuedConversation> queue = new Queue<QueuedConversation>();

	private bool isRestartingConversation;

	private GTWGameSounds _sounds;

	public int ConversationQueueLength => queue.Count;

	public bool IsConversationPlaying => DialogueManager.isConversationActive;

	public bool IsConversationPlayingOrWaitingToPlay
	{
		get
		{
			if (!IsConversationPlaying)
			{
				return ConversationQueueLength > 0;
			}
			return true;
		}
	}

	[Inject]
	private void Inject(IGameSounds sounds)
	{
		_sounds = sounds as GTWGameSounds;
	}

	private void Awake()
	{
		instance = this;
		queue.Clear();
	}

	private void Update()
	{
		if (!DialogueManager.isConversationActive && queue.Count > 0)
		{
			QueuedConversation queuedConversation = queue.Dequeue();
			DialogueManager.StartConversation(queuedConversation.queuedConversation, queuedConversation.queuedActor, queuedConversation.queuedConversant, -1);
		}
	}

	private void OnConversationEnd(Transform actor)
	{
		if (queue.Count > 0 && !isRestartingConversation)
		{
			QueuedConversation queuedConversation = queue.Dequeue();
			DialogueManager.StartConversation(queuedConversation.queuedConversation, queuedConversation.queuedActor, queuedConversation.queuedConversant, -1);
		}
		isRestartingConversation = false;
	}

	[ContextMenu("RestartCurrentConversation")]
	public void RestartConversation()
	{
		if (DialogueManager.isConversationActive)
		{
			isRestartingConversation = true;
			int initialDialogueEntryID = 1;
			DialogueManager.StopConversation();
			_sounds.StopAllEventInstances();
			DialogueManager.StartConversation(DialogueManager.LastConversationStarted, DialogueManager.CurrentActor, DialogueManager.CurrentConversant, initialDialogueEntryID);
		}
	}

	public void ClearQueue()
	{
		queue.Clear();
	}

	public void AddConversation(string conversation, Transform actor, Transform conversant)
	{
		if (DialogueManager.isConversationActive || queue.Count > 0)
		{
			if ((!DialogueManager.isConversationActive || !(DialogueManager.LastConversationStarted == conversation)) && !queue.Any((QueuedConversation x) => x.queuedConversation == conversation))
			{
				queue.Enqueue(new QueuedConversation
				{
					queuedConversation = conversation,
					queuedActor = actor,
					queuedConversant = conversant
				});
			}
		}
		else
		{
			DialogueManager.StartConversation(conversation, actor, conversant, -1);
		}
	}
}
