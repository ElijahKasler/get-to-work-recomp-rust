using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XGameSaveBlobInfo
{
	internal Unity.XGamingRuntime.Interop.XGameSaveBlobInfo interop;

	public string Name
	{
		get
		{
			return interop.name;
		}
		set
		{
			interop.name = value;
		}
	}

	public uint Size
	{
		get
		{
			return interop.size;
		}
		set
		{
			interop.size = value;
		}
	}

	internal XGameSaveBlobInfo(Unity.XGamingRuntime.Interop.XGameSaveBlobInfo interop)
	{
		this.interop = interop;
	}

	public XGameSaveBlobInfo()
	{
		interop = default;
	}
}
