using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XPackageFeature
{
	internal Unity.XGamingRuntime.Interop.XPackageFeature _interop;

	private string[] _storeIds;

	public string Id
	{
		get
		{
			return _interop.id;
		}
		set
		{
			_interop.id = value;
		}
	}

	public string DisplayName
	{
		get
		{
			return _interop.displayName;
		}
		set
		{
			_interop.displayName = value;
		}
	}

	public string Tags
	{
		get
		{
			return _interop.tags;
		}
		set
		{
			_interop.tags = value;
		}
	}

	public bool Hidden
	{
		get
		{
			return _interop.hidden;
		}
		set
		{
			_interop.hidden = value;
		}
	}

	public string[] StoreIds
	{
		get
		{
			return _storeIds;
		}
		set
		{
			_storeIds = value;
		}
	}

	internal XPackageFeature(Unity.XGamingRuntime.Interop.XPackageFeature interop)
	{
		_interop = interop;
		_storeIds = InteropHelpers.MarshalStringArrayAnsi(interop.storeIds, interop.storeIdCount);
	}

	public XPackageFeature()
	{
		_interop = default;
	}
}
