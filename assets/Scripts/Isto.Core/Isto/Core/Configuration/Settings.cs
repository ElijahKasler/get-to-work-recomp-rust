using Isto.Core.Audio;
using UnityEngine;

namespace Isto.Core.Configuration;

[CreateAssetMenu(fileName = "DefaultSettings", menuName = "Scriptables/Settings")]
public class Settings : ScriptableObject
{
	[Header("Controller Options")]
	[SerializeField]
	private bool _useController;

	[SerializeField]
	private bool _useVibration;

	[Header("Save Data")]
	[SerializeField]
	private int _maxCharactersInSaveName = 30;

	[Header("Auto Save Frequency")]
	[SerializeField]
	private int[] _autoSaveOptions = new int[4] { 5, 10, 15, 0 };

	[Header("Default Audio Volumes")]
	[SerializeField]
	private float _defaultMasterVolume = 1f;

	[SerializeField]
	private float _defaultMusicVolume = 1f;

	[SerializeField]
	private float _defaultSfxVolume = 1f;

	[SerializeField]
	private float _defaultDialogueVolume = 1f;

	[SerializeField]
	private float _defaultAmbientVolume = 1f;

	[Header("Audio Track References")]
	[SerializeField]
	private AudioTrackReferences _audioReferences;

	public const string ASSET_NAME = "DefaultSettings";

	public bool UseController => _useController;

	public bool UseVibration => _useVibration;

	public int MaxCharactersInSaveName => _maxCharactersInSaveName;

	public int[] AutoSaveOptions => _autoSaveOptions;

	public float DefaultMasterVolume => _defaultMasterVolume;

	public float DefaultMusicVolume => _defaultMusicVolume;

	public float DefaultSfxVolume => _defaultSfxVolume;

	public float DefaultDialogueVolume => _defaultDialogueVolume;

	public float DefaultAmbientVolume => _defaultAmbientVolume;

	public AudioTrackReferences AudioReferences => _audioReferences;

	public void SetUseJoystick(bool useJoystick)
	{
		_useController = useJoystick;
	}

	public void SetUseVibration(bool useVibration)
	{
		_useVibration = useVibration;
	}

	public static Settings LoadFromResources()
	{
		Settings settings = Resources.Load<Settings>("DefaultSettings");
		if (settings == null)
		{
			Debug.LogError("Could not find DefaultSettings file in the project");
		}
		return settings;
	}
}
