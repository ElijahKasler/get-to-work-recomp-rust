using System;
using Rewired.Interfaces;

namespace Rewired.Internal.Glyphs;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
internal class KeyedGlyph
{
	public const uint INVALID_VERSION = 0u;

	private uint ymxeEaDHoFAdezgYDQgYEQdQbkUcb;

	private uint KEHmHAUaGpMJDzQsPddwoHMWDgFz;

	private object IxgyJamcExkSYFGqkXHjQGrCuqkH;

	private bool YhBlDNWytjgzwfhNSBqSKntYFIPn;

	private string mMJwlwbTqJhhDxCcEqyACbhSBUHz;

	public bool hasCachedValue => YhBlDNWytjgzwfhNSBqSKntYFIPn;

	public object cachedValue
	{
		get
		{
			return IxgyJamcExkSYFGqkXHjQGrCuqkH;
		}
		set
		{
			YhBlDNWytjgzwfhNSBqSKntYFIPn = true;
			IxgyJamcExkSYFGqkXHjQGrCuqkH = value;
			if (value == null)
			{
				mMJwlwbTqJhhDxCcEqyACbhSBUHz = null;
			}
		}
	}

	public string cachedKey => mMJwlwbTqJhhDxCcEqyACbhSBUHz;

	public KeyedGlyph()
	{
		ymxeEaDHoFAdezgYDQgYEQdQbkUcb = 0u;
		KEHmHAUaGpMJDzQsPddwoHMWDgFz = 0u;
	}

	public KeyedGlyph(KeyedGlyph P_0)
	{
		ymxeEaDHoFAdezgYDQgYEQdQbkUcb = P_0.ymxeEaDHoFAdezgYDQgYEQdQbkUcb;
		KEHmHAUaGpMJDzQsPddwoHMWDgFz = P_0.KEHmHAUaGpMJDzQsPddwoHMWDgFz;
		IxgyJamcExkSYFGqkXHjQGrCuqkH = P_0.IxgyJamcExkSYFGqkXHjQGrCuqkH;
		YhBlDNWytjgzwfhNSBqSKntYFIPn = P_0.YhBlDNWytjgzwfhNSBqSKntYFIPn;
		mMJwlwbTqJhhDxCcEqyACbhSBUHz = P_0.mMJwlwbTqJhhDxCcEqyACbhSBUHz;
	}

	public void Clear()
	{
		ymxeEaDHoFAdezgYDQgYEQdQbkUcb = 0u;
		KEHmHAUaGpMJDzQsPddwoHMWDgFz = 0u;
		IxgyJamcExkSYFGqkXHjQGrCuqkH = null;
		YhBlDNWytjgzwfhNSBqSKntYFIPn = false;
		mMJwlwbTqJhhDxCcEqyACbhSBUHz = null;
	}

	public bool TryGetValue(string key, IGlyphProvider glyphProvider, uint glyphProviderVersion, uint userVersion, out bool versionChanged, out object result)
	{
		versionChanged = ymxeEaDHoFAdezgYDQgYEQdQbkUcb != ((glyphProvider != null) ? glyphProviderVersion : 0) || userVersion != KEHmHAUaGpMJDzQsPddwoHMWDgFz;
		if (versionChanged)
		{
			Clear();
			ymxeEaDHoFAdezgYDQgYEQdQbkUcb = glyphProviderVersion;
			KEHmHAUaGpMJDzQsPddwoHMWDgFz = userVersion;
		}
		if (!versionChanged || glyphProvider == null)
		{
			result = (YhBlDNWytjgzwfhNSBqSKntYFIPn ? IxgyJamcExkSYFGqkXHjQGrCuqkH : null);
			return YhBlDNWytjgzwfhNSBqSKntYFIPn;
		}
		if (string.IsNullOrEmpty(key))
		{
			result = null;
			return false;
		}
		try
		{
			YhBlDNWytjgzwfhNSBqSKntYFIPn = glyphProvider.TryGetGlyph(key, out IxgyJamcExkSYFGqkXHjQGrCuqkH) && IxgyJamcExkSYFGqkXHjQGrCuqkH != null;
			if (YhBlDNWytjgzwfhNSBqSKntYFIPn)
			{
				mMJwlwbTqJhhDxCcEqyACbhSBUHz = key;
			}
		}
		catch (Exception exception)
		{
			ReInput.HandleExternalInterfaceException(typeof(IGlyphProvider).Name + ".TryGetGlyph", exception);
		}
		result = (YhBlDNWytjgzwfhNSBqSKntYFIPn ? IxgyJamcExkSYFGqkXHjQGrCuqkH : null);
		return YhBlDNWytjgzwfhNSBqSKntYFIPn;
	}
}
