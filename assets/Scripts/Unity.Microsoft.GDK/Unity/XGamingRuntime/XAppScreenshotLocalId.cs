using System;

namespace Unity.XGamingRuntime;

[Serializable]
[Obsolete("class XAppScreenshotLocalId will be removed in future releases.", false)]
public class XAppScreenshotLocalId
{
	public byte[] Value { get; }

	public XAppScreenshotLocalId(byte[] value)
	{
		Value = value;
	}
}
