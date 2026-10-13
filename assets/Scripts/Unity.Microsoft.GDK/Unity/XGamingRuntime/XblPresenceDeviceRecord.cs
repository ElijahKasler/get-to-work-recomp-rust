using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblPresenceDeviceRecord
{
	public XblPresenceDeviceType DeviceType { get; private set; }

	public XblPresenceTitleRecord[] TitleRecords { get; private set; }

	internal XblPresenceDeviceRecord(Unity.XGamingRuntime.Interop.XblPresenceDeviceRecord interopRecord)
	{
		DeviceType = interopRecord.deviceType;
		TitleRecords = interopRecord.GetTitleRecords((Unity.XGamingRuntime.Interop.XblPresenceTitleRecord tr) => new XblPresenceTitleRecord(tr));
	}
}
