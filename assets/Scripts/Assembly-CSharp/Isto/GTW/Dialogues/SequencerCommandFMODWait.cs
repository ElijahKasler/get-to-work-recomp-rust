using System.Collections;
using System.IO;
using FMOD.Studio;
using FMODUnity;
using Isto.Core;
using PixelCrushers.DialogueSystem;
using PixelCrushers.DialogueSystem.SequencerCommands;
using UnityEngine;

namespace Isto.GTW.Dialogues;

public class SequencerCommandFMODWait : SequencerCommand
{
	private EventInstance eventInstance;

	private PLAYBACK_STATE state;

	private EventDescription eventCheck;

	public IEnumerator Start()
	{
		string parameter = GetParameter(0);
		string FMODEventName = Path.GetFileName(parameter);
		string text = "event:/" + parameter;
		if (DialogueDebug.logInfo)
		{
			Debug.Log("Dialogue System: Sequencer: FMODWait(" + text + ")");
		}
		RuntimeManager.StudioSystem.getEvent(text, out eventCheck);
		if (!eventCheck.isValid())
		{
			Debug.LogWarning("Event not found");
			Stop();
			yield break;
		}
		eventInstance = RuntimeManager.CreateInstance(text);
		eventInstance.start();
		if (state != PLAYBACK_STATE.STOPPED)
		{
			while (IsPlaying())
			{
				yield return null;
			}
		}
		Events.RaiseEvent(GTWEvents.FMOD_AUDIO_EVENT_COMPLETED, FMODEventName);
		Stop();
	}

	private new bool IsPlaying()
	{
		if (state == PLAYBACK_STATE.STOPPED)
		{
			return false;
		}
		eventInstance.getPlaybackState(out state);
		return state != PLAYBACK_STATE.STOPPED;
	}

	public void OnDestroy()
	{
		if (IsPlaying())
		{
			eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
		}
		eventInstance.release();
	}
}
