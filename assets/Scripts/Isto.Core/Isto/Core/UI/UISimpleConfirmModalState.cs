using System.Collections.Generic;
using Isto.Core.Inputs;
using Isto.Core.Localization;
using Isto.Core.StateMachine;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Isto.Core.UI;

public class UISimpleConfirmModalState : UISimpleModalStateBase
{
	[SerializeField]
	private TextMeshProUGUI _messageTextbox;

	[FormerlySerializedAs("_coutdownTextBox")]
	[SerializeField]
	private TextMeshProUGUI _countdownTextBox;

	[SerializeField]
	private CoreButton _confirmButton;

	[SerializeField]
	private CoreButton _cancelButton;

	private bool _timedCancelActive;

	private float _cancelTimer;

	private LocTerm _secondsPrefix;

	private LocTerm _secondsSuffix;

	protected LocTerm.Factory _locTermFactory;

	[Inject]
	public virtual void Inject(LocTerm.Factory locTermFactory)
	{
		_locTermFactory = locTermFactory;
	}

	public override void Enter(MonoStateMachine controller)
	{
		base.Enter(controller);
		if (!_timedCancelActive && _countdownTextBox != null)
		{
			_countdownTextBox.text = "";
		}
		_secondsPrefix = _locTermFactory.Create(LocTerm.LocalizationType.Localized, Constants.SECONDS_PREFIX);
		_secondsSuffix = _locTermFactory.Create(LocTerm.LocalizationType.Localized, Constants.SECONDS_SUFFIX);
	}

	public override void Exit(MonoStateMachine controller)
	{
		_timedCancelActive = false;
		if (_countdownTextBox != null)
		{
			_countdownTextBox.text = "";
		}
		base.Exit(controller);
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
		base.ReturnFromSubState(controller, previousState);
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		if (_timedCancelActive)
		{
			_cancelTimer -= Time.unscaledDeltaTime;
			LocTerm item = _locTermFactory.Create(LocTerm.LocalizationType.NonLocalized, $"{_cancelTimer:N0}");
			List<LocTerm> list = new List<LocTerm>();
			list.Add(_secondsPrefix);
			list.Add(item);
			list.Add(_secondsSuffix);
			new MultiTermLocExpression(list).LocalizeInto(_countdownTextBox);
			if (_cancelTimer < 0f)
			{
				_timedCancelActive = false;
				CancelClicked();
				return null;
			}
		}
		return base.Run(controller);
	}

	public void SetTimer(float time)
	{
		_timedCancelActive = true;
		_cancelTimer = time;
	}

	public void SetMainText(string text)
	{
		_messageTextbox.text = text;
	}

	public void SetMainText(LocTerm mainLocTerm)
	{
		mainLocTerm.LocalizeInto(_messageTextbox);
	}

	public override void SetDefaultSelection()
	{
		if (Controls.UsingController)
		{
			if (_cancelButton != null)
			{
				_cancelButton.Select();
			}
			else if (_confirmButton != null)
			{
				_confirmButton.Select();
			}
		}
	}
}
