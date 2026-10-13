using Isto.Core.Inputs;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class UIControllerScrolling : MonoBehaviour
{
	[SerializeField]
	private Scrollbar _scrollbar;

	private IControls _controls;

	[Inject]
	public void Inject(IControls controls)
	{
		_controls = controls;
	}

	private void Update()
	{
		if (Controls.UsingController)
		{
			bool flag = false;
			if (_scrollbar.direction == Scrollbar.Direction.RightToLeft || _scrollbar.direction == Scrollbar.Direction.TopToBottom)
			{
				flag = true;
			}
			bool flag2 = false;
			if (_scrollbar.direction == Scrollbar.Direction.LeftToRight || _scrollbar.direction == Scrollbar.Direction.RightToLeft)
			{
				flag2 = true;
			}
			float num = 0f;
			if (flag2)
			{
				float rawAxis = _controls.GetRawAxis(Controls.MovementAxis.UIHorizontal);
				float rawAxis2 = _controls.GetRawAxis(Controls.MovementAxis.UISecondaryHorizontal);
				num = rawAxis + rawAxis2;
			}
			else
			{
				float rawAxis3 = _controls.GetRawAxis(Controls.MovementAxis.UIVertical);
				float rawAxis4 = _controls.GetRawAxis(Controls.MovementAxis.UISecondaryVertical);
				num = rawAxis3 + rawAxis4;
			}
			num *= _scrollbar.size * 2f * Time.unscaledDeltaTime;
			if (flag)
			{
				num = 0f - num;
			}
			_scrollbar.value = Mathf.Clamp01(_scrollbar.value + num);
		}
	}
}
