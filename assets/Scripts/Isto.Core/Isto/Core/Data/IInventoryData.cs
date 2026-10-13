using System.Collections.Generic;

namespace Isto.Core.Data;

public interface IInventoryData
{
	List<ItemData> GetInventoryData();
}
