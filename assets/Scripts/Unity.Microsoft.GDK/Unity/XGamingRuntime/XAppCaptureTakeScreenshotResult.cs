using System;
using System.Text;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XAppCaptureTakeScreenshotResult
{
	internal Unity.XGamingRuntime.Interop.XAppCaptureTakeScreenshotResult data;

	public string LocalId
	{
		get
		{
			return data.localId;
		}
		set
		{
			data.localId = value;
		}
	}

	public XAppCaptureScreenshotFormatFlag AvailableScreenshotFormats
	{
		get
		{
			return data.availableScreenshotFormats;
		}
		set
		{
			data.availableScreenshotFormats = value;
		}
	}

	[Obsolete("XAppScreenshotLocalId will be removed in future releases. Use XAppCaptureTakeScreenshotResult.localId", false)]
	public XAppScreenshotLocalId Id => new XAppScreenshotLocalId(Encoding.UTF8.GetBytes(data.localId));

	internal XAppCaptureTakeScreenshotResult(Unity.XGamingRuntime.Interop.XAppCaptureTakeScreenshotResult interop)
	{
		data = interop;
	}

	public XAppCaptureTakeScreenshotResult()
	{
		data = default;
	}
}
