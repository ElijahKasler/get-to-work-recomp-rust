using System.Collections;
using System.ComponentModel;

namespace System.Windows.Forms;

public class BaseCollection : MarshalByRefObject, ICollection, IEnumerable
{
	internal ArrayList list;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public virtual int Count => List.Count;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	public bool IsReadOnly => false;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public bool IsSynchronized => false;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public object SyncRoot => this;

	protected virtual ArrayList List
	{
		get
		{
			if (list == null)
			{
				list = new ArrayList();
			}
			return list;
		}
	}

	public void CopyTo(Array ar, int index)
	{
		List.CopyTo(ar, index);
	}

	public IEnumerator GetEnumerator()
	{
		return List.GetEnumerator();
	}
}
