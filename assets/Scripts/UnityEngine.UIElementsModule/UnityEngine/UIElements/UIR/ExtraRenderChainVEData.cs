#define UNITY_ASSERTIONS
namespace UnityEngine.UIElements.UIR;

internal class ExtraRenderChainVEData : LinkedPoolItem<ExtraRenderChainVEData>
{
	public BasicNode<MeshHandle> extraMesh;

	public void Reset()
	{
		Debug.Assert(extraMesh == null);
	}
}
