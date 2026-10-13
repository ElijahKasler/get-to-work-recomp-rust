using System;
using Steamworks;
using UnityEngine;

namespace Isto.Core.Platforms;

public class SteamPlatformTools : IPlatformTools
{
	public uint storeAppID;

	public SteamPlatformTools(uint storeAppID)
	{
		this.storeAppID = storeAppID;
	}

	public string GetPlayerName()
	{
		if (SteamManager.Initialized)
		{
			return SteamFriends.GetPersonaName();
		}
		Debug.LogError("Steam not initialized");
		return "";
	}

	public bool TryGetPurchaseDate(out DateTime purchaseDate)
	{
		if (SteamManager.Initialized)
		{
			purchaseDate = DateTimeOffset.FromUnixTimeSeconds(SteamApps.GetEarliestPurchaseUnixTime(new AppId_t(storeAppID))).LocalDateTime;
			return true;
		}
		Debug.LogError("Steam not initialized");
		purchaseDate = DateTime.Now;
		return false;
	}
}
