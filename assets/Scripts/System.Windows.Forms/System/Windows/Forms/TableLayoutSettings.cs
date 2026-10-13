using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using System.Windows.Forms.Layout;
using Unity;

namespace System.Windows.Forms;

[Serializable]
[TypeConverter(typeof(TableLayoutSettingsTypeConverter))]
public sealed class TableLayoutSettings : LayoutSettings, ISerializable
{
	internal class StyleConverter : TypeConverter
	{
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value == null || !(value is string))
			{
				return base.ConvertFrom(context, culture, value);
			}
			return Enum.Parse(typeof(StyleConverter), (string)value, ignoreCase: true);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (value == null || !(value is StyleConverter) || destinationType != typeof(string))
			{
				return base.ConvertTo(context, culture, value, destinationType);
			}
			return ((StyleConverter)value).ToString();
		}
	}

	private TableLayoutColumnStyleCollection column_styles;

	private TableLayoutRowStyleCollection row_styles;

	private TableLayoutPanelGrowStyle grow_style;

	private int column_count;

	private int row_count;

	private Dictionary<object, int> columns;

	private Dictionary<object, int> column_spans;

	private Dictionary<object, int> rows;

	private Dictionary<object, int> row_spans;

	private IArrangedContainer panel;

	internal bool isSerialized;

	[DefaultValue(0)]
	public int ColumnCount
	{
		get
		{
			return column_count;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (column_count != value)
			{
				column_count = value;
				if (panel != null)
				{
					panel.PerformLayout(panel, "ColumnCount");
				}
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public TableLayoutColumnStyleCollection ColumnStyles => column_styles;

	[DefaultValue(TableLayoutPanelGrowStyle.AddRows)]
	public TableLayoutPanelGrowStyle GrowStyle
	{
		get
		{
			return grow_style;
		}
		set
		{
			if (!Enum.IsDefined(typeof(TableLayoutPanelGrowStyle), value))
			{
				throw new ArgumentException();
			}
			if (grow_style != value)
			{
				grow_style = value;
				if (panel != null)
				{
					panel.PerformLayout(panel, "GrowStyle");
				}
			}
		}
	}

	public override LayoutEngine LayoutEngine => TableLayout.Instance;

	[DefaultValue(0)]
	public int RowCount
	{
		get
		{
			return row_count;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (row_count != value)
			{
				row_count = value;
				if (panel != null)
				{
					panel.PerformLayout(panel, "Rows");
				}
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public TableLayoutRowStyleCollection RowStyles => row_styles;

	internal TableLayoutSettings(IArrangedContainer panel)
	{
		column_styles = new TableLayoutColumnStyleCollection(panel);
		row_styles = new TableLayoutRowStyleCollection(panel);
		grow_style = TableLayoutPanelGrowStyle.AddRows;
		column_count = 0;
		row_count = 0;
		columns = new Dictionary<object, int>();
		column_spans = new Dictionary<object, int>();
		rows = new Dictionary<object, int>();
		row_spans = new Dictionary<object, int>();
		this.panel = panel;
	}

	internal TableLayoutSettings(IArrangedContainer panel, TableLayoutSettings settings)
	{
		column_styles = new TableLayoutColumnStyleCollection(panel);
		row_styles = new TableLayoutRowStyleCollection(panel);
		grow_style = settings.grow_style;
		column_count = settings.column_count;
		row_count = settings.row_count;
		columns = new Dictionary<object, int>(settings.columns);
		column_spans = new Dictionary<object, int>(settings.column_spans);
		rows = new Dictionary<object, int>(settings.rows);
		row_spans = new Dictionary<object, int>(settings.row_spans);
		this.panel = panel;
		foreach (ColumnStyle item in (IEnumerable)settings.column_styles)
		{
			column_styles.Add(new ColumnStyle(item.SizeType, item.Width));
		}
		foreach (RowStyle item2 in (IEnumerable)settings.row_styles)
		{
			row_styles.Add(new RowStyle(item2.SizeType, item2.Height));
		}
	}

	private TableLayoutSettings(SerializationInfo serializationInfo, StreamingContext context)
	{
		TypeConverter converter = TypeDescriptor.GetConverter(this);
		string text = serializationInfo.GetString("SerializedString");
		if (!string.IsNullOrEmpty(text) && converter != null)
		{
			TableLayoutSettings tableLayoutSettings = converter.ConvertFromInvariantString(text) as TableLayoutSettings;
			column_styles = tableLayoutSettings.column_styles;
			row_styles = tableLayoutSettings.row_styles;
			grow_style = tableLayoutSettings.grow_style;
			column_count = tableLayoutSettings.column_count;
			row_count = tableLayoutSettings.row_count;
			columns = tableLayoutSettings.columns;
			column_spans = tableLayoutSettings.column_spans;
			rows = tableLayoutSettings.rows;
			row_spans = tableLayoutSettings.row_spans;
			panel = tableLayoutSettings.panel;
			isSerialized = true;
		}
	}

	[DefaultValue(-1)]
	public TableLayoutPanelCellPosition GetCellPosition(object control)
	{
		if (control == null)
		{
			throw new ArgumentNullException();
		}
		if (!columns.TryGetValue(control, out var value) && (!(control is Control) || !columns.TryGetValue((control as Control).Name, out value)))
		{
			value = -1;
		}
		if (!rows.TryGetValue(control, out var value2) && (!(control is Control) || !rows.TryGetValue((control as Control).Name, out value2)))
		{
			value2 = -1;
		}
		return new TableLayoutPanelCellPosition(value, value2);
	}

	[DefaultValue(-1)]
	public int GetColumn(object control)
	{
		if (control == null)
		{
			throw new ArgumentNullException();
		}
		if (columns.TryGetValue(control, out var value))
		{
			return value;
		}
		if (control is Control && columns.TryGetValue((control as Control).Name, out value))
		{
			return value;
		}
		return -1;
	}

	public int GetColumnSpan(object control)
	{
		if (control == null)
		{
			throw new ArgumentNullException();
		}
		if (column_spans.TryGetValue(control, out var value))
		{
			return value;
		}
		if (control is Control && column_spans.TryGetValue((control as Control).Name, out value))
		{
			return value;
		}
		return 1;
	}

	[DefaultValue(-1)]
	public int GetRow(object control)
	{
		if (control == null)
		{
			throw new ArgumentNullException();
		}
		if (rows.TryGetValue(control, out var value))
		{
			return value;
		}
		if (control is Control && rows.TryGetValue((control as Control).Name, out value))
		{
			return value;
		}
		return -1;
	}

	public int GetRowSpan(object control)
	{
		if (control == null)
		{
			throw new ArgumentNullException();
		}
		if (row_spans.TryGetValue(control, out var value))
		{
			return value;
		}
		if (control is Control && row_spans.TryGetValue((control as Control).Name, out value))
		{
			return value;
		}
		return 1;
	}

	[DefaultValue(-1)]
	public void SetCellPosition(object control, TableLayoutPanelCellPosition cellPosition)
	{
		if (control == null)
		{
			throw new ArgumentNullException();
		}
		columns[control] = cellPosition.Column;
		rows[control] = cellPosition.Row;
		if (panel != null)
		{
			panel.PerformLayout((IArrangedElement)control, "TableIndex");
		}
	}

	public void SetColumn(object control, int column)
	{
		if (control == null)
		{
			throw new ArgumentNullException();
		}
		if (column < -1)
		{
			throw new ArgumentException();
		}
		columns[control] = column;
		if (panel != null)
		{
			panel.PerformLayout((IArrangedElement)control, "TableIndex");
		}
	}

	public void SetColumnSpan(object control, int value)
	{
		if (control == null)
		{
			throw new ArgumentNullException();
		}
		if (value < 1)
		{
			throw new ArgumentOutOfRangeException();
		}
		column_spans[control] = value;
		if (panel != null)
		{
			panel.PerformLayout((IArrangedElement)control, "ColumnSpan");
		}
	}

	public void SetRow(object control, int row)
	{
		if (control == null)
		{
			throw new ArgumentNullException();
		}
		if (row < -1)
		{
			throw new ArgumentException();
		}
		rows[control] = row;
		if (panel != null)
		{
			panel.PerformLayout((IArrangedElement)control, "TableIndex");
		}
	}

	public void SetRowSpan(object control, int value)
	{
		if (control == null)
		{
			throw new ArgumentNullException();
		}
		if (value < 1)
		{
			throw new ArgumentOutOfRangeException();
		}
		row_spans[control] = value;
		if (panel != null)
		{
			panel.PerformLayout((IArrangedElement)control, "RowSpan");
		}
	}

	internal List<ControlInfo> GetControls()
	{
		List<ControlInfo> list = new List<ControlInfo>();
		foreach (KeyValuePair<object, int> column in columns)
		{
			list.Add(new ControlInfo
			{
				Control = column.Key,
				Col = GetColumn(column.Key),
				ColSpan = GetColumnSpan(column.Key),
				Row = GetRow(column.Key),
				RowSpan = GetRowSpan(column.Key)
			});
		}
		return list;
	}

	void ISerializable.GetObjectData(SerializationInfo si, StreamingContext context)
	{
		string value = new TableLayoutSettingsTypeConverter().ConvertToInvariantString(this);
		si.AddValue("SerializedString", value);
	}

	internal TableLayoutSettings()
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}
}
