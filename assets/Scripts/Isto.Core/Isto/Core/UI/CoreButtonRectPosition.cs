using UnityEngine;

namespace Isto.Core.UI;

public class CoreButtonRectPosition : CoreButtonVector3AnimTransition
{
	private enum SpaceTypeEnum
	{
		AnchoredPosition = 0,
		LocalPosition = 1,
		WorldPosition = 2
	}

	[SerializeField]
	private RectTransform _rectTransform;

	[SerializeField]
	private SpaceTypeEnum _space;

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
			switch (_space)
			{
			case SpaceTypeEnum.AnchoredPosition:
				_rectTransform.anchoredPosition3D = value;
				break;
			case SpaceTypeEnum.LocalPosition:
				_rectTransform.localPosition = value;
				break;
			case SpaceTypeEnum.WorldPosition:
				_rectTransform.position = value;
				break;
			default:
				_rectTransform.anchoredPosition3D = value;
				break;
			}
		}
	}
}
