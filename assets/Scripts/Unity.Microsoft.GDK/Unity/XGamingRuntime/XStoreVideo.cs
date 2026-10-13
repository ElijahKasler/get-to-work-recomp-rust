using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XStoreVideo
{
	internal Unity.XGamingRuntime.Interop.XStoreVideo _interop;

	internal XStoreImage _previewImage;

	internal Unity.XGamingRuntime.Interop.XStoreVideo interop
	{
		get
		{
			_interop.previewImage = _previewImage.interop;
			return _interop;
		}
		set
		{
			_interop = value;
		}
	}

	public string Uri
	{
		get
		{
			return _interop.uri;
		}
		set
		{
			_interop.uri = value;
		}
	}

	public uint Height
	{
		get
		{
			return _interop.height;
		}
		set
		{
			_interop.height = value;
		}
	}

	public uint Width
	{
		get
		{
			return _interop.width;
		}
		set
		{
			_interop.width = value;
		}
	}

	public string Caption
	{
		get
		{
			return _interop.caption;
		}
		set
		{
			_interop.caption = value;
		}
	}

	public string VideoPurposeTag
	{
		get
		{
			return _interop.videoPurposeTag;
		}
		set
		{
			_interop.videoPurposeTag = value;
		}
	}

	public XStoreImage PreviewImage
	{
		get
		{
			return _previewImage;
		}
		set
		{
			_interop.previewImage = value.interop;
			_previewImage = value;
		}
	}

	internal XStoreVideo(Unity.XGamingRuntime.Interop.XStoreVideo interop)
	{
		_interop = interop;
		_previewImage = new XStoreImage(_interop.previewImage);
	}

	public XStoreVideo()
	{
		_interop = default;
		_previewImage = new XStoreImage();
	}
}
