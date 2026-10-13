using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace System.Windows.Forms;

[Editor("System.Windows.Forms.Design.DataGridViewCellStyleEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[TypeConverter(typeof(DataGridViewCellStyleConverter))]
public class DataGridViewCellStyle : ICloneable
{
	private DataGridViewContentAlignment alignment;

	private Color backColor;

	private object dataSourceNullValue;

	private Font font;

	private Color foreColor;

	private string format;

	private IFormatProvider formatProvider;

	private object nullValue;

	private Padding padding;

	private Color selectionBackColor;

	private Color selectionForeColor;

	private object tag;

	private DataGridViewTriState wrapMode;

	[DefaultValue(DataGridViewContentAlignment.NotSet)]
	public DataGridViewContentAlignment Alignment
	{
		get
		{
			return alignment;
		}
		set
		{
			if (!Enum.IsDefined(typeof(DataGridViewContentAlignment), value))
			{
				throw new InvalidEnumArgumentException("Value is not valid DataGridViewContentAlignment.");
			}
			if (alignment != value)
			{
				alignment = value;
				OnStyleChanged();
			}
		}
	}

	public Color BackColor
	{
		get
		{
			return backColor;
		}
		set
		{
			if (backColor != value)
			{
				backColor = value;
				OnStyleChanged();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	public object DataSourceNullValue
	{
		get
		{
			return dataSourceNullValue;
		}
		set
		{
			if (dataSourceNullValue != value)
			{
				dataSourceNullValue = value;
				OnStyleChanged();
			}
		}
	}

	public Font Font
	{
		get
		{
			return font;
		}
		set
		{
			if (font != value)
			{
				font = value;
				OnStyleChanged();
			}
		}
	}

	public Color ForeColor
	{
		get
		{
			return foreColor;
		}
		set
		{
			if (foreColor != value)
			{
				foreColor = value;
				OnStyleChanged();
			}
		}
	}

	[Editor("System.Windows.Forms.Design.FormatStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue("")]
	public string Format
	{
		get
		{
			return format;
		}
		set
		{
			if (format != value)
			{
				format = value;
				OnStyleChanged();
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public IFormatProvider FormatProvider
	{
		get
		{
			if (formatProvider == null)
			{
				return CultureInfo.CurrentCulture;
			}
			return formatProvider;
		}
		set
		{
			if (formatProvider != value)
			{
				formatProvider = value;
				OnStyleChanged();
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public bool IsDataSourceNullValueDefault => dataSourceNullValue != null;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public bool IsFormatProviderDefault => formatProvider == null;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public bool IsNullValueDefault
	{
		get
		{
			if (nullValue is string)
			{
				return (string)nullValue == string.Empty;
			}
			return false;
		}
	}

	[TypeConverter(typeof(StringConverter))]
	[DefaultValue("")]
	public object NullValue
	{
		get
		{
			return nullValue;
		}
		set
		{
			if (nullValue != value)
			{
				nullValue = value;
				OnStyleChanged();
			}
		}
	}

	public Padding Padding
	{
		get
		{
			return padding;
		}
		set
		{
			if (padding != value)
			{
				padding = value;
				OnStyleChanged();
			}
		}
	}

	public Color SelectionBackColor
	{
		get
		{
			return selectionBackColor;
		}
		set
		{
			if (selectionBackColor != value)
			{
				selectionBackColor = value;
				OnStyleChanged();
			}
		}
	}

	public Color SelectionForeColor
	{
		get
		{
			return selectionForeColor;
		}
		set
		{
			if (selectionForeColor != value)
			{
				selectionForeColor = value;
				OnStyleChanged();
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public object Tag
	{
		get
		{
			return tag;
		}
		set
		{
			if (tag != value)
			{
				tag = value;
				OnStyleChanged();
			}
		}
	}

	[DefaultValue(DataGridViewTriState.NotSet)]
	public DataGridViewTriState WrapMode
	{
		get
		{
			return wrapMode;
		}
		set
		{
			if (!Enum.IsDefined(typeof(DataGridViewTriState), value))
			{
				throw new InvalidEnumArgumentException("Value is not valid DataGridViewTriState.");
			}
			if (wrapMode != value)
			{
				wrapMode = value;
				OnStyleChanged();
			}
		}
	}

	internal event EventHandler StyleChanged;

	public DataGridViewCellStyle()
	{
		alignment = DataGridViewContentAlignment.NotSet;
		backColor = Color.Empty;
		dataSourceNullValue = DBNull.Value;
		font = null;
		foreColor = Color.Empty;
		format = string.Empty;
		nullValue = string.Empty;
		padding = Padding.Empty;
		selectionBackColor = Color.Empty;
		selectionForeColor = Color.Empty;
		tag = null;
		wrapMode = DataGridViewTriState.NotSet;
	}

	public DataGridViewCellStyle(DataGridViewCellStyle dataGridViewCellStyle)
	{
		alignment = dataGridViewCellStyle.alignment;
		backColor = dataGridViewCellStyle.backColor;
		dataSourceNullValue = dataGridViewCellStyle.dataSourceNullValue;
		font = dataGridViewCellStyle.font;
		foreColor = dataGridViewCellStyle.foreColor;
		format = dataGridViewCellStyle.format;
		formatProvider = dataGridViewCellStyle.formatProvider;
		nullValue = dataGridViewCellStyle.nullValue;
		padding = dataGridViewCellStyle.padding;
		selectionBackColor = dataGridViewCellStyle.selectionBackColor;
		selectionForeColor = dataGridViewCellStyle.selectionForeColor;
		tag = dataGridViewCellStyle.tag;
		wrapMode = dataGridViewCellStyle.wrapMode;
	}

	public virtual void ApplyStyle(DataGridViewCellStyle dataGridViewCellStyle)
	{
		if (dataGridViewCellStyle.alignment != DataGridViewContentAlignment.NotSet)
		{
			alignment = dataGridViewCellStyle.alignment;
		}
		if (dataGridViewCellStyle.backColor != Color.Empty)
		{
			backColor = dataGridViewCellStyle.backColor;
		}
		if (dataGridViewCellStyle.dataSourceNullValue != DBNull.Value)
		{
			dataSourceNullValue = dataGridViewCellStyle.dataSourceNullValue;
		}
		if (dataGridViewCellStyle.font != null)
		{
			font = dataGridViewCellStyle.font;
		}
		if (dataGridViewCellStyle.foreColor != Color.Empty)
		{
			foreColor = dataGridViewCellStyle.foreColor;
		}
		if (dataGridViewCellStyle.format != string.Empty)
		{
			format = dataGridViewCellStyle.format;
		}
		if (dataGridViewCellStyle.formatProvider != null)
		{
			formatProvider = dataGridViewCellStyle.formatProvider;
		}
		if (dataGridViewCellStyle.nullValue != null)
		{
			nullValue = dataGridViewCellStyle.nullValue;
		}
		if (dataGridViewCellStyle.padding != Padding.Empty)
		{
			padding = dataGridViewCellStyle.padding;
		}
		if (dataGridViewCellStyle.selectionBackColor != Color.Empty)
		{
			selectionBackColor = dataGridViewCellStyle.selectionBackColor;
		}
		if (dataGridViewCellStyle.selectionForeColor != Color.Empty)
		{
			selectionForeColor = dataGridViewCellStyle.selectionForeColor;
		}
		if (dataGridViewCellStyle.tag != null)
		{
			tag = dataGridViewCellStyle.tag;
		}
		if (dataGridViewCellStyle.wrapMode != DataGridViewTriState.NotSet)
		{
			wrapMode = dataGridViewCellStyle.wrapMode;
		}
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public virtual DataGridViewCellStyle Clone()
	{
		return new DataGridViewCellStyle(this);
	}

	public override bool Equals(object o)
	{
		if (o is DataGridViewCellStyle)
		{
			DataGridViewCellStyle dataGridViewCellStyle = (DataGridViewCellStyle)o;
			if (alignment == dataGridViewCellStyle.alignment && backColor == dataGridViewCellStyle.backColor && dataSourceNullValue == dataGridViewCellStyle.dataSourceNullValue && font == dataGridViewCellStyle.font && foreColor == dataGridViewCellStyle.foreColor && format == dataGridViewCellStyle.format && formatProvider == dataGridViewCellStyle.formatProvider && nullValue == dataGridViewCellStyle.nullValue && padding == dataGridViewCellStyle.padding && selectionBackColor == dataGridViewCellStyle.selectionBackColor && selectionForeColor == dataGridViewCellStyle.selectionForeColor && tag == dataGridViewCellStyle.tag)
			{
				return wrapMode == dataGridViewCellStyle.wrapMode;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override string ToString()
	{
		return "";
	}

	internal void OnStyleChanged()
	{
		if (StyleChanged != null)
		{
			StyleChanged(this, EventArgs.Empty);
		}
	}

	internal StringFormat SetAlignment(StringFormat format)
	{
		switch (Alignment)
		{
		case DataGridViewContentAlignment.BottomLeft:
		case DataGridViewContentAlignment.BottomCenter:
		case DataGridViewContentAlignment.BottomRight:
			format.LineAlignment = StringAlignment.Near;
			break;
		case DataGridViewContentAlignment.MiddleLeft:
		case DataGridViewContentAlignment.MiddleCenter:
		case DataGridViewContentAlignment.MiddleRight:
			format.LineAlignment = StringAlignment.Center;
			break;
		case DataGridViewContentAlignment.TopLeft:
		case DataGridViewContentAlignment.TopCenter:
		case DataGridViewContentAlignment.TopRight:
			format.LineAlignment = StringAlignment.Far;
			break;
		}
		switch (Alignment)
		{
		case DataGridViewContentAlignment.TopCenter:
		case DataGridViewContentAlignment.MiddleCenter:
		case DataGridViewContentAlignment.BottomCenter:
			format.Alignment = StringAlignment.Center;
			break;
		case DataGridViewContentAlignment.TopLeft:
		case DataGridViewContentAlignment.MiddleLeft:
		case DataGridViewContentAlignment.BottomLeft:
			format.Alignment = StringAlignment.Near;
			break;
		case DataGridViewContentAlignment.TopRight:
		case DataGridViewContentAlignment.MiddleRight:
		case DataGridViewContentAlignment.BottomRight:
			format.Alignment = StringAlignment.Far;
			break;
		}
		return format;
	}
}
