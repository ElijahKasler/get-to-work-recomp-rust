using UnityEngine;

namespace Isto.Core.UI;

public class CoreButtonEnableComponent : CoreButtonVector1AnimTransition
{
	[SerializeField]
	private Behaviour _component;

	private void OnValidate()
	{
		DoTransition(base.CoreButton.PreviewSelectionState);
	}

	public override GameObject GetTargetObject()
	{
		return _component.gameObject;
	}

	protected override void SetObjectProperties(float xValue)
	{
		bool flag = xValue > 0.9f;
		if (_component != null && _component.enabled != flag)
		{
			_component.enabled = flag;
		}
	}
}
