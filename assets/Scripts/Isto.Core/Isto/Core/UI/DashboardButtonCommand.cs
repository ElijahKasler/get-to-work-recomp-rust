using UnityEngine;
using UnityEngine.UI;

namespace Isto.Core.UI;

public class DashboardButtonCommand : DashboardCommand
{
	[Header("DashboardButtonCommand Config")]
	[SerializeField]
	private Button _button;

	protected override void Start()
	{
		if (_button == null)
		{
			Debug.LogError("DashboardButtonCommand not setup properly in the CheaterDashboardButton prefab", this);
		}
		base.Start();
	}

	protected override void OnEnable()
	{
		_button.onClick.AddListener(OnClick);
	}

	protected override void OnDisable()
	{
		_button.onClick.RemoveListener(OnClick);
	}

	protected override void OnDestroy()
	{
	}

	private void OnClick()
	{
		ActivateCommand();
	}
}
