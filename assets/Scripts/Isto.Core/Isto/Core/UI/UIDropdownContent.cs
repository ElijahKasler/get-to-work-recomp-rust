using UnityEngine;
using UnityEngine.Events;

namespace Isto.Core.UI;

public class UIDropdownContent : MonoBehaviour
{
	public UnityEvent<UIDropdownContent> ContentDisabled;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
		ContentDisabled?.Invoke(null);
	}
}
