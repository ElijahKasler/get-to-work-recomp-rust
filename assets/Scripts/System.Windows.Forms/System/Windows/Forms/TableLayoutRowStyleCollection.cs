using System.Collections;
using System.Windows.Forms.Layout;
using Unity;

namespace System.Windows.Forms;

public class TableLayoutRowStyleCollection : TableLayoutStyleCollection
{
	public new RowStyle this[int index]
	{
		get
		{
			return (RowStyle)base[index];
		}
		set
		{
			base[index] = value;
		}
	}

	internal TableLayoutRowStyleCollection(IArrangedContainer panel)
		: base(panel, "RowStyles")
	{
	}

	public int Add(RowStyle rowStyle)
	{
		return Add((TableLayoutStyle)rowStyle);
	}

	public bool Contains(RowStyle rowStyle)
	{
		return ((IList)this).Contains((object)rowStyle);
	}

	public int IndexOf(RowStyle rowStyle)
	{
		return ((IList)this).IndexOf((object)rowStyle);
	}

	public void Insert(int index, RowStyle rowStyle)
	{
		((IList)this).Insert(index, (object)rowStyle);
	}

	public void Remove(RowStyle rowStyle)
	{
		((IList)this).Remove((object)rowStyle);
	}

	internal TableLayoutRowStyleCollection()
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}
}
