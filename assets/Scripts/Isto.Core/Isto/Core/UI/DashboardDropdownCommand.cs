using UnityEngine;
using UnityEngine.UI;

namespace Isto.Core.UI;

public class DashboardDropdownCommand : DashboardCommand
{
	[Header("DashboardDropdownCommand Config")]
	[SerializeField]
	private Dropdown _dropdown;

	protected override void Start()
	{
		if (_dropdown == null)
		{
			Debug.LogError("DashboardDropdownCommand not setup properly in the CheaterDashboardDropdown prefab", this);
		}
		base.Start();
	}
}
