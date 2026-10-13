using FMOD.Studio;
using FMODUnity;
using Isto.Core.Audio;
using Isto.GTW.Dialogues;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using Zenject;

namespace Isto.GTW.Audio;

public class EndGameMusic : MonoBehaviour
{
	[SerializeField]
	private EventReference _soundEvent;

	private BoxCollider[] _colliders;

	private GTWGameSounds _gameSounds;

	private Music _gameMusic;

	[Inject]
	public void Inject(IGameSounds gameSounds, IGameMusic gameMusic)
	{
		_gameSounds = gameSounds as GTWGameSounds;
		_gameMusic = gameMusic as Music;
	}

	private void Start()
	{
		if (!_soundEvent.IsNull)
		{
			ConversationQueueManager.instance.ClearQueue();
			DialogueManager.StopConversation();
			_gameSounds.StopAllEventInstances();
			_gameSounds.StopAllSounds(FMOD.Studio.STOP_MODE.IMMEDIATE);
			_gameMusic.PlayEventReference(_soundEvent);
		}
	}
}
