using Isto.Core;
using UnityEngine;

namespace Isto.GTW.LevelEvents.LevelEvents;

public class StartGiveUpButtonDialogue : MonoBehaviour
{
	public DialogueEvent dialogueEvent;

	private void Awake()
	{
		Events.Subscribe(GTWEvents.GIVE_UP_DIALOGUE_START, Events_OnGiveUpDialogueStart);
	}

	public void Events_OnGiveUpDialogueStart()
	{
		Debug.Log("Playing Give up button sequence");
		dialogueEvent.TriggerEvent();
	}

	private void OnDestroy()
	{
		Events.UnSubscribe(GTWEvents.GIVE_UP_DIALOGUE_START, Events_OnGiveUpDialogueStart);
	}
}
