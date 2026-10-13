using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Isto.Core.ObjectCulling;

public class ReleaseAddressableObject : MonoBehaviour
{
	public void ReleaseObject()
	{
		Addressables.ReleaseInstance(base.gameObject);
	}
}
