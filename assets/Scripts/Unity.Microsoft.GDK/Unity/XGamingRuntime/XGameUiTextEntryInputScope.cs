using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XGameUiTextEntryInputScope : uint
{
	Default = 0u,
	Url = 1u,
	EmailSmtpAddress = 5u,
	Number = 29u,
	Password = 31u,
	TelephoneNumber = 32u,
	Alphanumeric = 40u,
	Search = 50u,
	ChatWithoutEmoji = 68u
}
