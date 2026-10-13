using UnityEngine;

namespace Isto.Core.UI;

public class CoreButtonActivateGameObject : CoreButtonVector1AnimTransition
{
	[SerializeField]
	private GameObject _go;

	private void OnValidate()
	{
		DoTransition(base.CoreButton.PreviewSelectionState);
	}

	public override GameObject GetTargetObject()
	{
		return _go;
	}

	protected override void SetObjectProperties(float xValue)
	{
		bool flag = xValue > 0.9f;
		if (_go != null && _go.activeSelf != flag)
		{
			_go.SetActive(flag);
		}
	}
}
