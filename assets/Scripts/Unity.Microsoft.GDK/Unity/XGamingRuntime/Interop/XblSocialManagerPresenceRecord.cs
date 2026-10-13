using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XblSocialManagerPresenceRecord
{
	internal readonly XblPresenceUserState userState;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	internal readonly XblSocialManagerPresenceTitleRecord[] presenceTitleRecords;

	internal readonly uint presenceTitleCount;

	internal XblSocialManagerPresenceRecord(Unity.XGamingRuntime.XblSocialManagerPresenceRecord presenceRecord)
	{
		userState = presenceRecord.UserState;
		presenceTitleRecords = Converters.ConvertArrayToFixedLength(presenceRecord.PresenceTitleRecords, 6, (Unity.XGamingRuntime.XblSocialManagerPresenceTitleRecord r) => new XblSocialManagerPresenceTitleRecord(r));
		presenceTitleCount = Convert.ToUInt32(presenceTitleRecords.Length);
	}
}
