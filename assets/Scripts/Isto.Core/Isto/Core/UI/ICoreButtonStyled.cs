using System;
using Isto.Core.UI.ButtonStyles;
using UnityEngine;

namespace Isto.Core.UI;

public interface ICoreButtonStyled
{
	GameObject GetTargetObject();

	Type GetStyleType();

	void SetStyle(IStyle style);
}
