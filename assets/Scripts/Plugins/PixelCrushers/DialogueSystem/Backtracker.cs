using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem;

public class Backtracker : MonoBehaviour
{
	public bool debug;

	private Stack<ConversationState> stack = new Stack<ConversationState>();

	private ConversationState lastState;

	private bool isRecordingStates;

	public void OnConversationStart(Transform actor)
	{
		if (debug)
		{
			Debug.Log("Backtracker: Starting a new conversation. Clearing stack.");
		}
		isRecordingStates = true;
		stack.Clear();
		if (lastState != null)
		{
			if (debug)
			{
				Debug.Log("Backtracker: Recording dialogue entry " + lastState.subtitle.dialogueEntry.conversationID + ":" + lastState.subtitle.dialogueEntry.id + " on stack: '" + lastState.subtitle.formattedText.text + "' (" + lastState.subtitle.speakerInfo.characterType.ToString() + ").");
			}
			stack.Push(lastState);
			lastState = null;
		}
	}

	public void OnConversationEnd(Transform actor)
	{
		isRecordingStates = false;
		lastState = null;
		stack.Clear();
	}

	public void OnConversationLine(Subtitle subtitle)
	{
		if (isRecordingStates)
		{
			if (debug)
			{
				Debug.Log("Backtracker: Recording dialogue entry " + subtitle.dialogueEntry.conversationID + ":" + subtitle.dialogueEntry.id + " on stack: '" + subtitle.formattedText.text + "' (" + subtitle.speakerInfo.characterType.ToString() + ").");
			}
			stack.Push(DialogueManager.CurrentConversationState);
		}
		lastState = DialogueManager.CurrentConversationState;
	}

	public void Backtrack(bool toPreviousNPCLine)
	{
		if (stack.Count < 2)
		{
			return;
		}
		stack.Pop();
		ConversationState conversationState = stack.Pop();
		if (toPreviousNPCLine)
		{
			while (!conversationState.subtitle.speakerInfo.IsNPC && stack.Count > 0)
			{
				conversationState = stack.Pop();
			}
			if (!conversationState.subtitle.speakerInfo.IsNPC)
			{
				return;
			}
		}
		if (debug)
		{
			Debug.Log("Backtracker: Backtracking to " + conversationState.subtitle.dialogueEntry.conversationID + ":" + conversationState.subtitle.dialogueEntry.id + " on stack: '" + conversationState.subtitle.formattedText.text + "' (" + conversationState.subtitle.speakerInfo.characterType.ToString() + ").");
		}
		DialogueManager.conversationView.sequencer.Stop();
		DialogueManager.ConversationController.GotoState(conversationState);
	}
}
