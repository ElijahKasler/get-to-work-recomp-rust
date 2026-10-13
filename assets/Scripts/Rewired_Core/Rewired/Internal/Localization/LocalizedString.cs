using System;
using Rewired.Interfaces;

namespace Rewired.Internal.Localization;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
internal class LocalizedString
{
	public const uint INVALID_VERSION = 0u;

	private uint zNlGhbFzLrwxgBQhnKggGjzoFSHw;

	private uint uEoAqotKireOXhdCplxiZMLEJlUV;

	private string ZMlvtBLJEccOosIFMgYDFlYiFhRmA;

	private bool yTiFuWEpnMcDSOxRbmEXNTEfiVDE;

	public bool hasCachedValue => yTiFuWEpnMcDSOxRbmEXNTEfiVDE;

	public string cachedValue
	{
		get
		{
			return ZMlvtBLJEccOosIFMgYDFlYiFhRmA;
		}
		set
		{
			yTiFuWEpnMcDSOxRbmEXNTEfiVDE = true;
			ZMlvtBLJEccOosIFMgYDFlYiFhRmA = value;
		}
	}

	public LocalizedString()
	{
		zNlGhbFzLrwxgBQhnKggGjzoFSHw = 0u;
		uEoAqotKireOXhdCplxiZMLEJlUV = 0u;
	}

	public LocalizedString(LocalizedString P_0)
	{
		zNlGhbFzLrwxgBQhnKggGjzoFSHw = P_0.zNlGhbFzLrwxgBQhnKggGjzoFSHw;
		uEoAqotKireOXhdCplxiZMLEJlUV = P_0.uEoAqotKireOXhdCplxiZMLEJlUV;
		ZMlvtBLJEccOosIFMgYDFlYiFhRmA = P_0.ZMlvtBLJEccOosIFMgYDFlYiFhRmA;
		yTiFuWEpnMcDSOxRbmEXNTEfiVDE = P_0.yTiFuWEpnMcDSOxRbmEXNTEfiVDE;
	}

	public void Clear()
	{
		zNlGhbFzLrwxgBQhnKggGjzoFSHw = 0u;
		uEoAqotKireOXhdCplxiZMLEJlUV = 0u;
		ZMlvtBLJEccOosIFMgYDFlYiFhRmA = null;
		yTiFuWEpnMcDSOxRbmEXNTEfiVDE = false;
	}

	public bool TryGetLocalizedValue(string key, ILocalizedStringProvider localizer, uint localizerVersion, uint userVersion, out bool versionChanged, out string result)
	{
		versionChanged = zNlGhbFzLrwxgBQhnKggGjzoFSHw != ((localizer != null) ? localizerVersion : 0) || userVersion != uEoAqotKireOXhdCplxiZMLEJlUV;
		if (versionChanged)
		{
			Clear();
			zNlGhbFzLrwxgBQhnKggGjzoFSHw = localizerVersion;
			uEoAqotKireOXhdCplxiZMLEJlUV = userVersion;
		}
		if (!versionChanged || localizer == null)
		{
			result = (yTiFuWEpnMcDSOxRbmEXNTEfiVDE ? ZMlvtBLJEccOosIFMgYDFlYiFhRmA : null);
			return yTiFuWEpnMcDSOxRbmEXNTEfiVDE;
		}
		if (string.IsNullOrEmpty(key))
		{
			result = null;
			return false;
		}
		try
		{
			yTiFuWEpnMcDSOxRbmEXNTEfiVDE = localizer.TryGetLocalizedString(key, out ZMlvtBLJEccOosIFMgYDFlYiFhRmA) && !string.IsNullOrEmpty(ZMlvtBLJEccOosIFMgYDFlYiFhRmA);
		}
		catch (Exception exception)
		{
			ReInput.HandleExternalInterfaceException(typeof(ILocalizedStringProvider).Name + ".TryGetLocalizedString", exception);
		}
		result = (yTiFuWEpnMcDSOxRbmEXNTEfiVDE ? ZMlvtBLJEccOosIFMgYDFlYiFhRmA : null);
		return yTiFuWEpnMcDSOxRbmEXNTEfiVDE;
	}
}
