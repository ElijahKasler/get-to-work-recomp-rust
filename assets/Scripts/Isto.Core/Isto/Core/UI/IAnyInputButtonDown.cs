using UnityEngine.EventSystems;

namespace Isto.Core.UI;

public interface IAnyInputButtonDown : IAdditionalInputEventSystemHandler, IEventSystemHandler
{
	void OnAnyInputButtonDown();
}
