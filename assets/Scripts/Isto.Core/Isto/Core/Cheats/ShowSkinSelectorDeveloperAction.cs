using Isto.Core.UI;
using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New Show Skin Selector Action", menuName = "Scriptables/Dev Mode Actions/Show Skin Selector Action")]
public class ShowSkinSelectorDeveloperAction : CheatAction
{
	public override void Activate(params object[] args)
	{
		Object.FindObjectOfType<CheatMenuState>().ShowSkinSelector();
	}

	public override void Deactivate()
	{
	}

	public override void OnUpdate()
	{
	}
}
