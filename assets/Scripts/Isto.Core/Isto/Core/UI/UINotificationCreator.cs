using UnityEngine;

namespace Isto.Core.UI;

public class UINotificationCreator : MonoBehaviour
{
	[SerializeField]
	private GameObject notificationPrefab;

	[SerializeField]
	private GameObject notificationParent;

	public UINotification Notification { get; set; }

	public void InstantiateNotification()
	{
		if (Notification == null)
		{
			GameObject gameObject = Object.Instantiate(notificationPrefab, notificationParent.transform);
			Notification = gameObject.GetComponent<UINotification>();
		}
	}

	public void DestroyNotification()
	{
		if (Notification != null)
		{
			Object.Destroy(Notification.gameObject);
		}
	}

	public void ShowNotification(bool show)
	{
		if (Notification != null)
		{
			Notification.gameObject.SetActive(show);
		}
	}
}
