using System.Collections.Generic;
using Isto.Core.Beings;
using Isto.Core.Inputs;
using UnityEngine;

namespace Isto.Core.Items;

public interface IInteractable
{
	List<UserActions> GetValidActions();

	string GetToolTip(UserActions action);

	void ShowTooltip();

	void SetInactive();

	void SetInteractive(bool state);

	Vector3 GetInteractionPosition(Vector3 playerPosition);

	void PlayerInteraction(AutomationPlayerController player, UserActions action);
}
