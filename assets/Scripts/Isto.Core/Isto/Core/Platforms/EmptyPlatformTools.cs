using System;

namespace Isto.Core.Platforms;

public class EmptyPlatformTools : IPlatformTools
{
	public string GetPlayerName()
	{
		return "";
	}

	public bool TryGetPurchaseDate(out DateTime purchaseDate)
	{
		purchaseDate = new DateTime(1900, 1, 1);
		return true;
	}
}
