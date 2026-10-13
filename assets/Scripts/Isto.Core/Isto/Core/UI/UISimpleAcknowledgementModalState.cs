using Isto.Core.Inputs;
using Isto.Core.StateMachine;
using TMPro;
using UnityEngine;

namespace Isto.Core.UI;

public class UISimpleAcknowledgementModalState : UISimpleModalStateBase
{
	[SerializeField]
	private TextMeshProUGUI _mainTextbox;

	[SerializeField]
	private TextMeshProUGUI _detailsTextbox;

	public override void Enter(MonoStateMachine controller)
	{
		base.Enter(controller);
		CancelAllowed = false;
	}

	public override void Exit(MonoStateMachine controller)
	{
		base.Exit(controller);
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
		base.ReturnFromSubState(controller, previousState);
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		return base.Run(controller);
	}

	public override void SetDefaultSelection()
	{
		if (Controls.UsingController)
		{
			CoreButton componentInChildren = GetComponentInChildren<CoreButton>();
			if (componentInChildren != null)
			{
				componentInChildren.Select();
			}
		}
	}

	public void SetMainText(string text)
	{
		_mainTextbox.text = text;
	}

	public void SetDetailsText(string text)
	{
		_detailsTextbox.text = text;
	}
}
