using System;
using System.Collections;
using Isto.Core.UI.ButtonStyles;
using UnityEngine;

namespace Isto.Core.UI;

public abstract class CoreButtonAnimTransitionBase<TStyle, TStateData, TValueStateData> : CoreButtonTransitionBase, ICoreButtonAnimTransition, ICoreButtonStyled where TStyle : class, IStyle where TStateData : class, IStateData, IAnimatedStateData, new() where TValueStateData : class, TStateData, new()
{
	public TStyle style;

	public TValueStateData stateData = new TValueStateData();

	protected CoreButton.CoreButtonSelectionState _currentButtonState;

	protected bool _isAnimating;

	protected Coroutine _currentAnimationCoroutine;

	protected TStateData GetStateData()
	{
		if (style != null)
		{
			return style.GetStateData() as TStateData;
		}
		return (TStateData)stateData;
	}

	protected virtual void Awake()
	{
		stateData.UpdateAnimLength();
	}

	public override void DoTransition(CoreButton.CoreButtonSelectionState state, bool instant = true)
	{
		if (!base.gameObject.activeInHierarchy)
		{
			instant = true;
		}
		if (_isAnimating && state != _currentButtonState)
		{
			Evaluate(_currentButtonState, float.MaxValue);
		}
		_currentButtonState = state;
		if (instant)
		{
			Evaluate(_currentButtonState, float.MaxValue);
		}
		else
		{
			_currentAnimationCoroutine = StartCoroutine(EvaluateAnimation());
		}
	}

	public IEnumerator EvaluateAnimation(CoreButton.CoreButtonSelectionState state)
	{
		_currentButtonState = state;
		return EvaluateAnimation();
	}

	public IEnumerator EvaluateAnimation()
	{
		if (_currentAnimationCoroutine != null)
		{
			StopCoroutine(_currentAnimationCoroutine);
			_currentAnimationCoroutine = null;
		}
		_isAnimating = true;
		float currentTime = 0f;
		bool animFinished = false;
		while (!animFinished)
		{
			animFinished = Evaluate(_currentButtonState, currentTime);
			currentTime = ((!Application.isPlaying) ? (currentTime + Time.fixedUnscaledDeltaTime) : (currentTime + Time.deltaTime));
			yield return null;
		}
		_isAnimating = false;
		_currentAnimationCoroutine = null;
	}

	protected abstract bool Evaluate(CoreButton.CoreButtonSelectionState state, float time);

	public virtual GameObject GetTargetObject()
	{
		return null;
	}

	public Type GetStyleType()
	{
		return typeof(TStyle);
	}

	public void SetStyle(IStyle style)
	{
		this.style = style as TStyle;
		DoTransition(_currentButtonState);
	}
}
