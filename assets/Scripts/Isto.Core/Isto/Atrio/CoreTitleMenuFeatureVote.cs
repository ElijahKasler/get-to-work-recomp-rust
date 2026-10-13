using Isto.Core.UI;
using UnityEngine;

namespace Isto.Atrio;

public class CoreTitleMenuFeatureVote : MonoBehaviour
{
	[SerializeField]
	private string url;

	[SerializeField]
	private UISimpleConfirmModalState _confirmDialogue;

	[SerializeField]
	private SimpleTitleMenuStateMachine _titleMenu;

	public void OpenURL()
	{
		OpenConfirmed();
	}

	private void OpenConfirmed()
	{
		Application.OpenURL(url);
	}
}
