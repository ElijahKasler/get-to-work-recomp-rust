using System.Runtime.InteropServices;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XPackageChunkSelector
{
	internal XPackageChunkSelectorInterop interop;

	internal string _languageOrTagOrFeature;

	public XPackageChunkSelectorType Type
	{
		get
		{
			return interop.type;
		}
		set
		{
			interop.type = value;
		}
	}

	public string LanguageTagOrFeature
	{
		get
		{
			return _languageOrTagOrFeature;
		}
		set
		{
			_languageOrTagOrFeature = value;
		}
	}

	public uint ChunkId
	{
		get
		{
			return interop.chunkId;
		}
		set
		{
			interop.chunkId = value;
		}
	}

	internal XPackageChunkSelector(XPackageChunkSelectorInterop interop)
	{
		_languageOrTagOrFeature = Marshal.PtrToStringAnsi(interop.languageOrTagOrFeature);
		this.interop = interop;
	}

	public XPackageChunkSelector()
	{
		interop = default;
	}
}
