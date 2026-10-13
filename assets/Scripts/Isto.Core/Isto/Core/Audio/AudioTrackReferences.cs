using System;
using FMODUnity;
using Isto.Core.Enums;
using UnityEngine;

namespace Isto.Core.Audio;

[CreateAssetMenu(fileName = "AudioTrackReferences", menuName = "Scriptables/Audio/AudioTrackReferences")]
public class AudioTrackReferences : ScriptableObject
{
	[Serializable]
	public class GameSoundReference
	{
		public string name;

		[EnumDropdown(typeof(GameSoundEnum))]
		public int soundEnum;

		public EventReference eventRef;
	}

	[Serializable]
	public class UISoundReference
	{
		public string name;

		[EnumDropdown(typeof(UISoundEnum))]
		public int soundEnum;

		public EventReference eventRef;
	}

	[Serializable]
	public class MusicReference
	{
		public string name;

		[EnumDropdown(typeof(MusicTrackEnum))]
		public int musicEnum;

		public EventReference eventRef;
	}

	[Serializable]
	public class SettingsSoundReference
	{
		public string name;

		[EnumDropdown(typeof(SettingsSoundEnum))]
		public int soundEnum;

		public EventReference eventRef;
	}

	public SettingsSoundReference[] SettingsSounds;

	public UISoundReference[] UISounds;

	public GameSoundReference[] GameSounds;

	public MusicReference[] GameMusicTracks;
}
