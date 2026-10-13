using UnityEngine;

namespace Isto.Core.Items;

public interface IDirectionalItem
{
	void SetForwardDirection(Vector3 forward);

	Vector3 GetDirection();
}
