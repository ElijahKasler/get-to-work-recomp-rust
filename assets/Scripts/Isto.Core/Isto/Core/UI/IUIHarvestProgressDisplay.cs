using UnityEngine;

namespace Isto.Core.UI;

public interface IUIHarvestProgressDisplay
{
	void SetProgress(float value, Transform target);

	void HideDisplay();
}
