using System.Collections;
using System.Collections.Generic;
using Mono.WebBrowser;
using Mono.WebBrowser.DOM;
using Unity;

namespace System.Windows.Forms;

public class HtmlWindowCollection : ICollection, IEnumerable
{
	private List<HtmlWindow> windows;

	public int Count => windows.Count;

	public HtmlWindow this[string windowId]
	{
		get
		{
			foreach (HtmlWindow window in windows)
			{
				if (window.Name.Equals(windowId))
				{
					return window;
				}
			}
			return null;
		}
	}

	public HtmlWindow this[int index]
	{
		get
		{
			if (index > windows.Count || index < 0)
			{
				return null;
			}
			return windows[index];
		}
	}

	object ICollection.SyncRoot => this;

	bool ICollection.IsSynchronized => false;

	internal HtmlWindowCollection(WebBrowser owner, IWebBrowser webHost, IWindowCollection col)
	{
		windows = new List<HtmlWindow>();
		foreach (IWindow item in col)
		{
			windows.Add(new HtmlWindow(owner, webHost, item));
		}
	}

	public IEnumerator GetEnumerator()
	{
		return windows.GetEnumerator();
	}

	void ICollection.CopyTo(Array dest, int index)
	{
		windows.CopyTo(dest as HtmlWindow[], index);
	}

	internal HtmlWindowCollection()
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}
}
