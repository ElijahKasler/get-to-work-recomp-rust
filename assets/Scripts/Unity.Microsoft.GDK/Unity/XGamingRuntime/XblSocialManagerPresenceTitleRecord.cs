using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblSocialManagerPresenceTitleRecord
{
	public uint TitleId { get; private set; }

	public string TitleName { get; private set; }

	public bool IsTitleActive { get; private set; }

	public string PresenceText { get; private set; }

	public bool IsBroadcasting { get; private set; }

	public XblPresenceDeviceType DeviceType { get; private set; }

	public bool IsPrimary { get; private set; }

	internal XblSocialManagerPresenceTitleRecord(Unity.XGamingRuntime.Interop.XblSocialManagerPresenceTitleRecord interopRecord)
	{
		TitleId = interopRecord.titleId;
		TitleName = Converters.ByteArrayToString(interopRecord.titleName);
		IsTitleActive = interopRecord.isTitleActive;
		PresenceText = Converters.ByteArrayToString(interopRecord.presenceText);
		IsBroadcasting = interopRecord.isBroadcasting;
		DeviceType = interopRecord.deviceType;
		IsPrimary = interopRecord.isPrimary;
	}
}
