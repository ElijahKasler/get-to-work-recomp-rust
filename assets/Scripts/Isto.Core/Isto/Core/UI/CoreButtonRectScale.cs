using UnityEngine;

namespace Isto.Core.UI;

public class CoreButtonRectScale : CoreButtonVector3AnimTransition
{
	[SerializeField]
	private RectTransform _rectTransform;

	private void OnValidate()
	{
		DoTransition(base.CoreButton.PreviewSelectionState);
	}

	public override GameObject GetTargetObject()
	{
		return _rectTransform.gameObject;
	}

	protected override void SetObjectProperties(Vector3 value)
	{
		if (_rectTransform != null)
		{
			_rectTransform.localScale = value;
		}
	}

	protected override void Reset()
	{
		base.Reset();
		Vector3StateDataValue vector3StateDataValue = stateData;
		vector3StateDataValue.normal.InstantValue = new Vector3(1f, 1f, 1f);
		vector3StateDataValue.selected.InstantValue = new Vector3(1f, 1f, 1f);
		vector3StateDataValue.pressed.InstantValue = new Vector3(1f, 1f, 1f);
		vector3StateDataValue.disabled.InstantValue = new Vector3(1f, 1f, 1f);
	}
}
