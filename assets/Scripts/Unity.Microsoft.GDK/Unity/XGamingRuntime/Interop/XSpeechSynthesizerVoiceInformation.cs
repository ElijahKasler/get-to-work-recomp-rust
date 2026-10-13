using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XSpeechSynthesizerVoiceInformation
{
	[MarshalAs(UnmanagedType.LPStr)]
	internal string Description;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string DisplayName;

	internal XSpeechSynthesizerVoiceGender Gender;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string VoiceId;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string Language;
}
