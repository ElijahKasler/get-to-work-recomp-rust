using System.Linq;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblSocialManagerPresenceRecord
{
	public XblSocialManagerPresenceTitleRecord[] PresenceTitleRecords;

	public XblPresenceUserState UserState { get; private set; }

	internal XblSocialManagerPresenceRecord(Unity.XGamingRuntime.Interop.XblSocialManagerPresenceRecord interopRecord)
	{
		UserState = interopRecord.userState;
		PresenceTitleRecords = (from r in interopRecord.presenceTitleRecords.Where((Unity.XGamingRuntime.Interop.XblSocialManagerPresenceTitleRecord r, int index) => (uint)index < interopRecord.presenceTitleCount)
			select new XblSocialManagerPresenceTitleRecord(r)).ToArray();
	}
}
