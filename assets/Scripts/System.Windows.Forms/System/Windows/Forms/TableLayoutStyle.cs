using System.ComponentModel;
using System.Windows.Forms.Layout;

namespace System.Windows.Forms;

[TypeConverter(typeof(TableLayoutSettings.StyleConverter))]
public abstract class TableLayoutStyle
{
	private SizeType size_type;

	private IArrangedContainer owner;

	[DefaultValue(SizeType.AutoSize)]
	public SizeType SizeType
	{
		get
		{
			return size_type;
		}
		set
		{
			if (size_type != value)
			{
				size_type = value;
				if (owner != null)
				{
					owner.PerformLayout(owner, "Style");
				}
			}
		}
	}

	internal IArrangedContainer Owner
	{
		get
		{
			return owner;
		}
		set
		{
			owner = value;
		}
	}

	protected TableLayoutStyle()
	{
		size_type = SizeType.AutoSize;
	}
}
