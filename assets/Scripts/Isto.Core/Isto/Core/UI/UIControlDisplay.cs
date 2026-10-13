using UnityEngine;

namespace Isto.Core.UI;

public class UIControlDisplay : MonoBehaviour
{
	public GameObject container;

	public void Awake()
	{
		ShowControlDisplay(show: false);
	}

	public void MenuActive(bool active)
	{
		ShowControlDisplay(active);
	}

	public void ShowControlDisplay(bool show)
	{
		container.SetActive(show);
	}
}
