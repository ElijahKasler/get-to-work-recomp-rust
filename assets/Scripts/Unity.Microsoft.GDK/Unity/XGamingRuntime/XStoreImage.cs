using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XStoreImage
{
	internal Unity.XGamingRuntime.Interop.XStoreImage interop;

	public string Uri
	{
		get
		{
			return interop.uri;
		}
		set
		{
			interop.uri = value;
		}
	}

	public uint Height
	{
		get
		{
			return interop.height;
		}
		set
		{
			interop.height = value;
		}
	}

	public uint Width
	{
		get
		{
			return interop.width;
		}
		set
		{
			interop.width = value;
		}
	}

	public string Caption
	{
		get
		{
			return interop.caption;
		}
		set
		{
			interop.caption = value;
		}
	}

	public string ImagePurposeTag
	{
		get
		{
			return interop.imagePurposeTag;
		}
		set
		{
			interop.imagePurposeTag = value;
		}
	}

	internal XStoreImage(Unity.XGamingRuntime.Interop.XStoreImage interop)
	{
		this.interop = interop;
	}

	public XStoreImage()
	{
		interop = default;
	}
}
