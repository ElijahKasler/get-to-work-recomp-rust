using System.ComponentModel;
using System.Drawing;
using Unity;

namespace System.Windows.Forms;

[TypeConverter(typeof(FlatButtonAppearanceConverter))]
public class FlatButtonAppearance
{
	private Color borderColor;

	private int borderSize;

	private Color checkedBackColor;

	private Color mouseDownBackColor;

	private Color mouseOverBackColor;

	private ButtonBase owner;

	[Browsable(true)]
	[NotifyParentProperty(true)]
	[DefaultValue(typeof(Color), "")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public Color BorderColor
	{
		get
		{
			return borderColor;
		}
		set
		{
			if (!(borderColor == value))
			{
				if (value == Color.Transparent)
				{
					throw new NotSupportedException("Cannot have a Transparent border.");
				}
				borderColor = value;
				if (owner != null)
				{
					owner.Invalidate();
				}
			}
		}
	}

	[NotifyParentProperty(true)]
	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(1)]
	public int BorderSize
	{
		get
		{
			return borderSize;
		}
		set
		{
			if (borderSize != value)
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("value", $"'{value}' is not a valid value for 'BorderSize'. 'BorderSize' must be greater or equal than {0}.");
				}
				borderSize = value;
				if (owner != null)
				{
					owner.Invalidate();
				}
			}
		}
	}

	[Browsable(true)]
	[NotifyParentProperty(true)]
	[DefaultValue(typeof(Color), "")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public Color CheckedBackColor
	{
		get
		{
			return checkedBackColor;
		}
		set
		{
			if (!(checkedBackColor == value))
			{
				checkedBackColor = value;
				if (owner != null)
				{
					owner.Invalidate();
				}
			}
		}
	}

	[DefaultValue(typeof(Color), "")]
	[NotifyParentProperty(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(true)]
	public Color MouseDownBackColor
	{
		get
		{
			return mouseDownBackColor;
		}
		set
		{
			if (!(mouseDownBackColor == value))
			{
				mouseDownBackColor = value;
				if (owner != null)
				{
					owner.Invalidate();
				}
			}
		}
	}

	[Browsable(true)]
	[NotifyParentProperty(true)]
	[DefaultValue(typeof(Color), "")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public Color MouseOverBackColor
	{
		get
		{
			return mouseOverBackColor;
		}
		set
		{
			if (!(mouseOverBackColor == value))
			{
				mouseOverBackColor = value;
				if (owner != null)
				{
					owner.Invalidate();
				}
			}
		}
	}

	internal FlatButtonAppearance(ButtonBase owner)
	{
		borderColor = Color.Empty;
		borderSize = 1;
		checkedBackColor = Color.Empty;
		mouseDownBackColor = Color.Empty;
		mouseOverBackColor = Color.Empty;
		base._002Ector();
		this.owner = owner;
	}

	internal FlatButtonAppearance()
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}
}
