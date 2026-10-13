using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XStoreQueryResult
{
	internal XStoreProductQuery QueryHandle { get; private set; }

	public bool HasMorePages { get; private set; }

	public XStoreProduct[] PageItems { get; private set; }

	internal XStoreQueryResult(XStoreProductQuery queryHandle, XStoreProduct[] pageItems, bool hasMorePages)
	{
		QueryHandle = queryHandle;
		PageItems = pageItems;
		HasMorePages = hasMorePages;
	}

	public static implicit operator XStoreProductQuery(XStoreQueryResult result)
	{
		return result.QueryHandle;
	}
}
