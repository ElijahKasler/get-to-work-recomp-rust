using System.ComponentModel;

namespace System.Windows.Forms;

public abstract class GridItem
{
	private bool expanded;

	private object tag;

	public virtual bool Expandable => GridItems.Count > 1;

	public virtual bool Expanded
	{
		get
		{
			return expanded;
		}
		set
		{
			expanded = value;
		}
	}

	public abstract GridItemCollection GridItems { get; }

	public abstract GridItemType GridItemType { get; }

	public abstract string Label { get; }

	public abstract GridItem Parent { get; }

	public abstract PropertyDescriptor PropertyDescriptor { get; }

	[Bindable(true)]
	[Localizable(false)]
	[DefaultValue(null)]
	[TypeConverter(typeof(StringConverter))]
	public object Tag
	{
		get
		{
			return tag;
		}
		set
		{
			tag = value;
		}
	}

	public abstract object Value { get; }

	protected GridItem()
	{
		expanded = false;
	}

	public abstract bool Select();
}
