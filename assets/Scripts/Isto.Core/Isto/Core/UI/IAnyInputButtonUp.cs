using UnityEngine.EventSystems;

namespace Isto.Core.UI;

public interface IAnyInputButtonUp : IAdditionalInputEventSystemHandler, IEventSystemHandler
{
	void OnAnyInputButtonUp();
}
