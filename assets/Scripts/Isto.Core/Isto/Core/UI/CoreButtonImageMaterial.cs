using System;
using Isto.Core.UI.ButtonStyles;
using UnityEngine;
using UnityEngine.UI;

namespace Isto.Core.UI;

public class CoreButtonImageMaterial : CoreButtonTransitionBase, ICoreButtonStyled
{
	[SerializeField]
	private Image _image;

	public MaterialStyle style;

	public MaterialStateDataValue stateData;

	protected CoreButton.CoreButtonSelectionState _currentButtonState;

	public override void DoTransition(CoreButton.CoreButtonSelectionState state, bool instant = true)
	{
		_currentButtonState = state;
		MaterialStateData materialStateData = GetStateData();
		if (materialStateData != null)
		{
			MaterialData materialData = materialStateData.GetState(state) as MaterialData;
			Material material = null;
			if (materialData != null)
			{
				material = materialData.material;
			}
			if (_image != null)
			{
				_image.material = material;
			}
		}
	}

	protected MaterialStateData GetStateData()
	{
		if (style != null)
		{
			return style.GetStateData() as MaterialStateData;
		}
		return stateData;
	}

	public GameObject GetTargetObject()
	{
		return _image.gameObject;
	}

	public Type GetStyleType()
	{
		return typeof(MaterialStyle);
	}

	public void SetStyle(IStyle style)
	{
		this.style = style as MaterialStyle;
		DoTransition(_currentButtonState);
	}
}
