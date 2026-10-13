using System;
using TMPro;
using UnityEngine;

namespace Isto.Core.UI;

public class UINotification : MonoBehaviour
{
	public GameObject notificationContainer;

	public GameObject wideCircle;

	public GameObject regularCircle;

	public TextMeshProUGUI notificationCount;

	public bool hasCount;

	public bool active;

	private int _notificationCount;

	private bool _active;

	private bool _bottomNode;

	public bool BottomNode => _bottomNode;

	public event Action<NotificationEventArgs> OnNotificationChanged;

	private void Start()
	{
		SetCountVisibility(hasCount);
	}

	public void Setup(int notificationCount, bool bottomNode, bool hasCount = false)
	{
		_bottomNode = bottomNode;
		_active = true;
		_notificationCount = notificationCount;
		if (_active)
		{
			SetCountVisibility(hasCount);
		}
		else
		{
			ClearNotification();
		}
		UpdateUI();
		if (_bottomNode)
		{
			InformParent(_notificationCount);
		}
	}

	public void ReInitialize(int count, bool bottomNode)
	{
		_notificationCount = count;
		_bottomNode = bottomNode;
		UpdateUI();
	}

	public void UpdateUI()
	{
		if (_active)
		{
			if (_notificationCount <= 0)
			{
				ClearNotification();
				return;
			}
			notificationContainer.SetActive(value: true);
			notificationCount.text = _notificationCount.ToString();
		}
	}

	public void UpdateNotificationCount(int count)
	{
		_notificationCount = count;
		UpdateUI();
		if (_notificationCount >= 0 && _bottomNode)
		{
			InformParent(_notificationCount);
		}
	}

	public void InformParent(int amount)
	{
		OnNotificationChanged?.Invoke(new NotificationEventArgs(this, amount));
	}

	public void ClearNotification()
	{
		notificationCount.text = 0.ToString();
		notificationContainer.SetActive(value: false);
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void SetCountVisibility(bool isVisible)
	{
		if (isVisible)
		{
			wideCircle.SetActive(value: true);
			regularCircle.SetActive(value: false);
		}
		else
		{
			wideCircle.SetActive(value: false);
			regularCircle.SetActive(value: true);
		}
	}
}
