using UnityEngine;

namespace Isto.Core.Beings;

public interface IPlayerTriggered
{
	void TriggerItem();

	bool InRange(Vector3 position);
}
