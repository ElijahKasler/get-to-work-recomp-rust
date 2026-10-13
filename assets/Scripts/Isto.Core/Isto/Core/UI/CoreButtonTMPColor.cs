using TMPro;
using UnityEngine;

namespace Isto.Core.UI;

public class CoreButtonTMPColor : CoreButtonColorAnimTransition
{
	[SerializeField]
	private TextMeshProUGUI _tmp;

	private void OnValidate()
	{
		DoTransition(base.CoreButton.PreviewSelectionState);
	}

	public override GameObject GetTargetObject()
	{
		return _tmp.gameObject;
	}

	protected override void SetObjectProperties(Color color)
	{
		if (_tmp != null)
		{
			_tmp.color = color;
		}
	}
}
