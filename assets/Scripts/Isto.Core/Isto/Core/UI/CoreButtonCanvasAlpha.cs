using UnityEngine;

namespace Isto.Core.UI;

public class CoreButtonCanvasAlpha : CoreButtonVector1AnimTransition
{
	[SerializeField]
	private CanvasGroup _canvasGroup;

	private void OnValidate()
	{
	}

	public override GameObject GetTargetObject()
	{
		return _canvasGroup.gameObject;
	}

	protected override void SetObjectProperties(float xValue)
	{
		if (_canvasGroup != null)
		{
			_canvasGroup.alpha = xValue;
		}
	}
}
