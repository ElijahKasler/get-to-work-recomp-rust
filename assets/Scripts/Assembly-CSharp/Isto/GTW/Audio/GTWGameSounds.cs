using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using Isto.Core.Audio;

namespace Isto.GTW.Audio;

public class GTWGameSounds : GameSounds
{
	public void SetGameplaySoundsPaused(bool isPaused)
	{
		Bus bus = RuntimeManager.GetBus(GTWConstants.GAMEPLAY_SFX_BUS_PATH);
		Bus bus2 = RuntimeManager.GetBus(GTWConstants.GAMEPLAY_DIALOGUE_BUS_PATH);
		Bus bus3 = RuntimeManager.GetBus(GTWConstants.AMBIENT_BUS_PATH);
		Bus bus4 = RuntimeManager.GetBus(GTWConstants.MUSIC_BUS_PATH);
		bus.setPaused(isPaused);
		bus2.setPaused(isPaused);
		bus3.setPaused(isPaused);
		bus4.setPaused(isPaused);
	}

	public void StopAllSounds(FMOD.Studio.STOP_MODE stopMode)
	{
		Bus bus = RuntimeManager.GetBus(GTWConstants.GAMEPLAY_SFX_BUS_PATH);
		Bus bus2 = RuntimeManager.GetBus(GTWConstants.GAMEPLAY_DIALOGUE_BUS_PATH);
		Bus bus3 = RuntimeManager.GetBus(GTWConstants.AMBIENT_BUS_PATH);
		bus.stopAllEvents(stopMode);
		bus2.stopAllEvents(stopMode);
		bus3.stopAllEvents(stopMode);
	}

	public EventInstance GetOrCreateEventInstance(string eventRef)
	{
		EventInstance eventInstance = default;
		if (!_runningInstances.ContainsKey(eventRef))
		{
			eventInstance = RuntimeManager.CreateInstance(eventRef);
			_runningInstances.Add(eventRef, eventInstance);
		}
		else if (_runningInstances.ContainsKey(eventRef) && !_runningInstances[eventRef].isValid())
		{
			eventInstance = RuntimeManager.CreateInstance(eventRef);
			_runningInstances[eventRef] = eventInstance;
		}
		else if (_runningInstances.ContainsKey(eventRef) && _runningInstances[eventRef].isValid())
		{
			eventInstance = _runningInstances[eventRef];
		}
		return eventInstance;
	}

	public void StopAllEventInstances()
	{
		foreach (KeyValuePair<string, EventInstance> runningInstance in _runningInstances)
		{
			runningInstance.Value.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
			runningInstance.Value.release();
		}
	}
}
