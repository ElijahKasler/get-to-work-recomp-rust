using System;
using Isto.Core.UI;

namespace Isto.Core;

public class NotificationEventArgs : EventArgs
{
	public int countChange;

	public UINotification notification;

	public NotificationEventArgs(UINotification sender, int countChange)
	{
		notification = sender;
		this.countChange = countChange;
	}
}
