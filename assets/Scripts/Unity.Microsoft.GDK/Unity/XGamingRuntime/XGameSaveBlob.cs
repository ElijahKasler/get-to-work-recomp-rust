using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XGameSaveBlob
{
	public XGameSaveBlobInfo Info { get; set; }

	public byte[] Data { get; set; }

	internal XGameSaveBlob(XGameSaveBlobInterop interop)
	{
		Info = new XGameSaveBlobInfo(interop.info);
		Data = InteropHelpers.MarshalArray<byte>(interop.data, interop.info.size);
	}
}
