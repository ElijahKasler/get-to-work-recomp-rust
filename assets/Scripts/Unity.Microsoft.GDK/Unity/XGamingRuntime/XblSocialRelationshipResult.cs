using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblSocialRelationshipResult : IDisposable
{
	private bool _disposed;

	internal XblSocialRelationshipResultHandle InteropHandle { get; set; }

	internal XblSocialRelationshipResult(XblSocialRelationshipResultHandle interopHandle)
	{
		InteropHandle = interopHandle;
	}

	~XblSocialRelationshipResult()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			XblInterop.XblSocialRelationshipResultCloseHandle(InteropHandle);
			InteropHandle = default;
			_disposed = true;
		}
	}
}
