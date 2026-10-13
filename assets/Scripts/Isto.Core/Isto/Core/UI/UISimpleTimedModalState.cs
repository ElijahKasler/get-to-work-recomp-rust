using Isto.Core.StateMachine;
using TMPro;
using UnityEngine;

namespace Isto.Core.UI;

public class UISimpleTimedModalState : UISimpleModalStateBase
{
	[SerializeField]
	private TextMeshProUGUI _mainTextbox;

	[SerializeField]
	private TextMeshProUGUI _countdownTextbox;

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

	public void SetMainText(string text)
	{
		_mainTextbox.text = text;
	}

	public void SetCountdownText(string text)
	{
		_countdownTextbox.text = text;
	}
}
