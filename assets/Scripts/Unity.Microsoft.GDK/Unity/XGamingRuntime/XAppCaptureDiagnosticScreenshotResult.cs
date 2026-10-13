using System.Collections.Generic;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XAppCaptureDiagnosticScreenshotResult
{
	public XAppCaptureScreenshotFile[] Files { get; set; }

	internal XAppCaptureDiagnosticScreenshotResult(Unity.XGamingRuntime.Interop.XAppCaptureDiagnosticScreenshotResult interop)
	{
		List<XAppCaptureScreenshotFile> list = new List<XAppCaptureScreenshotFile>();
		for (int i = 0; i < interop.fileCount; i++)
		{
			XAppCaptureScreenshotFile item = new XAppCaptureScreenshotFile(interop.files[i]);
			list.Add(item);
		}
		Files = list.ToArray();
	}
}
