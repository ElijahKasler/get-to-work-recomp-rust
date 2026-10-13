using System;
using System.Runtime.InteropServices;
using AOT;
using FMOD;
using FMOD.Studio;
using Isto.GTW.Audio;
using PixelCrushers.DialogueSystem.SequencerCommands;
using UnityEngine;

namespace Isto.GTW.Dialogues;

public class SequencerCommandFMODWaitForMarkers : SequencerCommand
{
	private PLAYBACK_STATE state;

	private EventInstance eventInstance;

	private GTWGameSounds _sounds;

	private static bool shouldStop;

	private void Awake()
	{
		_sounds = UnityEngine.Object.FindObjectOfType<GTWGameSounds>();
	}

	private void Start()
	{
		string parameter = GetParameter(0);
		string eventRef = "event:/" + parameter;
		eventInstance = _sounds.GetOrCreateEventInstance(eventRef);
		eventInstance.setCallback(EventCallback, EVENT_CALLBACK_TYPE.TIMELINE_MARKER);
		eventInstance.getPlaybackState(out var pLAYBACK_STATE);
		if (pLAYBACK_STATE != PLAYBACK_STATE.PLAYING)
		{
			eventInstance.start();
		}
	}

	private void Update()
	{
		CheckPlaying();
		if (shouldStop)
		{
			shouldStop = false;
			Stop();
		}
	}

	[MonoPInvokeCallback(typeof(EVENT_CALLBACK))]
	private static RESULT EventCallback(EVENT_CALLBACK_TYPE type, IntPtr _event, IntPtr parameterPtr)
	{
		if (type == EVENT_CALLBACK_TYPE.TIMELINE_MARKER && ((string)Marshal.PtrToStructure<TIMELINE_MARKER_PROPERTIES>(parameterPtr).name).Contains("IncrementSubtitle"))
		{
			shouldStop = true;
		}
		return RESULT.OK;
	}

	private void CheckPlaying()
	{
		eventInstance.getPlaybackState(out state);
		if (state == PLAYBACK_STATE.STOPPED)
		{
			shouldStop = true;
		}
	}
}
