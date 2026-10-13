using Isto.Core.Automation;
using UnityEngine;

namespace Isto.Core.Items;

public interface ISpecialPositioning
{
	Vector3 GetAutomationPosition();

	void SetupWorldPosition(AutomationGridSpace space);

	Vector3 GetPositionOffset();
}
