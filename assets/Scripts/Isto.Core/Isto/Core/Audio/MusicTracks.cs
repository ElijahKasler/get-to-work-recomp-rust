using UnityEngine;

namespace Isto.Core.Audio;

[CreateAssetMenu(fileName = "MusicTracks", menuName = "Scriptables/Audio/Music Tracks")]
public class MusicTracks : ScriptableObject
{
	public string[] MusicTrackRefs;

	public string TitleMusicRef;
}
