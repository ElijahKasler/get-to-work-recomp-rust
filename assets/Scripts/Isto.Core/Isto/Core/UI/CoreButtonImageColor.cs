using UnityEngine;
using UnityEngine.UI;

namespace Isto.Core.UI;

public class CoreButtonImageColor : CoreButtonColorAnimTransition
{
	[SerializeField]
	private Image _image;

	private void OnValidate()
	{
		DoTransition(base.CoreButton.PreviewSelectionState);
	}

	public override GameObject GetTargetObject()
	{
		return _image.gameObject;
	}

	protected override void SetObjectProperties(Color color)
	{
		if (_image != null)
		{
			_image.color = color;
		}
	}
}
