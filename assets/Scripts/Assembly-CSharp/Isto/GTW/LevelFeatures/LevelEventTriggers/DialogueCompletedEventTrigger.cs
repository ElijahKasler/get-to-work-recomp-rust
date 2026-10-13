using Isto.Core;
using Isto.GTW.LevelEvents.LevelEvents;
using UnityEngine;

namespace Isto.GTW.LevelFeatures.LevelEventTriggers;

public class DialogueCompletedEventTrigger : LevelEventTrigger
{
	[SerializeField]
	private DialogueEvent _dialogueEvent;

	private void OnEnable()
	{
		Events.SubscribeWithParams(GTWEvents.FMOD_AUDIO_EVENT_COMPLETED, Event_FmodAudioEventCompleted);
	}

	private void OnDisable()
	{
		Events.UnSubscribeWithParams(GTWEvents.FMOD_AUDIO_EVENT_COMPLETED, Event_FmodAudioEventCompleted);
	}

	private void Event_FmodAudioEventCompleted(object[] args)
	{
		if (args[0].Equals(_dialogueEvent.conversation))
		{
			TriggerEvent();
		}
	}
}
