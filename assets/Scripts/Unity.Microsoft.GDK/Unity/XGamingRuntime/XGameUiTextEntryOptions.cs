using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XGameUiTextEntryOptions
{
	internal Unity.XGamingRuntime.Interop.XGameUiTextEntryOptions data;

	public XGameUiTextEntryInputScope InputScope
	{
		get
		{
			return data.inputScope;
		}
		set
		{
			data.inputScope = value;
		}
	}

	public XGameUiTextEntryPositionHint PositionHint
	{
		get
		{
			return data.positionHint;
		}
		set
		{
			data.positionHint = value;
		}
	}

	public XGameUiTextEntryVisibilityFlags VisibilityFlags
	{
		get
		{
			return data.visibilityFlags;
		}
		set
		{
			data.visibilityFlags = value;
		}
	}

	internal XGameUiTextEntryOptions(Unity.XGamingRuntime.Interop.XGameUiTextEntryOptions interop)
	{
		data = interop;
	}

	public XGameUiTextEntryOptions()
	{
		data = default;
	}
}
