using System;

namespace Isto.Core.Platforms;

public interface IPlatformTools
{
	string GetPlayerName();

	bool TryGetPurchaseDate(out DateTime purchaseDate);
}
