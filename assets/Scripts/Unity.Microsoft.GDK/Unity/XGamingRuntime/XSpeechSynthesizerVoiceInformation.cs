using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XSpeechSynthesizerVoiceInformation
{
	internal Unity.XGamingRuntime.Interop.XSpeechSynthesizerVoiceInformation interop;

	public string Description
	{
		get
		{
			return interop.Description;
		}
		set
		{
			interop.Description = value;
		}
	}

	public string DisplayName
	{
		get
		{
			return interop.DisplayName;
		}
		set
		{
			interop.DisplayName = value;
		}
	}

	public XSpeechSynthesizerVoiceGender Gender
	{
		get
		{
			return interop.Gender;
		}
		set
		{
			interop.Gender = value;
		}
	}

	public string VoiceId
	{
		get
		{
			return interop.VoiceId;
		}
		set
		{
			interop.VoiceId = value;
		}
	}

	public string Language
	{
		get
		{
			return interop.Language;
		}
		set
		{
			interop.Language = value;
		}
	}

	internal XSpeechSynthesizerVoiceInformation(Unity.XGamingRuntime.Interop.XSpeechSynthesizerVoiceInformation interop)
	{
		this.interop = interop;
	}

	public XSpeechSynthesizerVoiceInformation()
	{
		interop = default;
	}
}
