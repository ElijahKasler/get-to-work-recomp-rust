using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace System.Windows.Forms;

[DesignTimeVisible(false)]
[ToolboxItem(false)]
public class DataGridTableStyle : Component, IDataGridEditingService
{
	public static readonly DataGridTableStyle DefaultTableStyle = new DataGridTableStyle(isDefaultTableStyle: true);

	private static readonly Color def_alternating_backcolor = ThemeEngine.Current.DataGridAlternatingBackColor;

	private static readonly Color def_backcolor = ThemeEngine.Current.DataGridBackColor;

	private static readonly Color def_forecolor = SystemColors.WindowText;

	private static readonly Color def_gridline_color = ThemeEngine.Current.DataGridGridLineColor;

	private static readonly Color def_header_backcolor = ThemeEngine.Current.DataGridHeaderBackColor;

	private static readonly Font def_header_font = ThemeEngine.Current.DefaultFont;

	private static readonly Color def_header_forecolor = ThemeEngine.Current.DataGridHeaderForeColor;

	private static readonly Color def_link_color = ThemeEngine.Current.DataGridLinkColor;

	private static readonly Color def_link_hovercolor = ThemeEngine.Current.DataGridLinkHoverColor;

	private static readonly Color def_selection_backcolor = ThemeEngine.Current.DataGridSelectionBackColor;

	private static readonly Color def_selection_forecolor = ThemeEngine.Current.DataGridSelectionForeColor;

	private static readonly int def_preferredrow_height = ThemeEngine.Current.DefaultFont.Height + 3;

	private bool allow_sorting;

	private DataGrid datagrid;

	private Color header_forecolor;

	private string mapping_name;

	private Color alternating_backcolor;

	private bool columnheaders_visible;

	private GridColumnStylesCollection column_styles;

	private Color gridline_color;

	private DataGridLineStyle gridline_style;

	private Color header_backcolor;

	private Font header_font;

	private Color link_color;

	private Color link_hovercolor;

	private int preferredcolumn_width;

	private int preferredrow_height;

	private bool _readonly;

	private bool rowheaders_visible;

	private Color selection_backcolor;

	private Color selection_forecolor;

	private int rowheaders_width;

	private Color backcolor;

	private Color forecolor;

	private bool is_default;

	internal ArrayList table_relations;

	private CurrencyManager manager;

	private static object AllowSortingChangedEvent = new object();

	private static object AlternatingBackColorChangedEvent = new object();

	private static object BackColorChangedEvent = new object();

	private static object ColumnHeadersVisibleChangedEvent = new object();

	private static object ForeColorChangedEvent = new object();

	private static object GridLineColorChangedEvent = new object();

	private static object GridLineStyleChangedEvent = new object();

	private static object HeaderBackColorChangedEvent = new object();

	private static object HeaderFontChangedEvent = new object();

	private static object HeaderForeColorChangedEvent = new object();

	private static object LinkColorChangedEvent = new object();

	private static object LinkHoverColorChangedEvent = new object();

	private static object MappingNameChangedEvent = new object();

	private static object PreferredColumnWidthChangedEvent = new object();

	private static object PreferredRowHeightChangedEvent = new object();

	private static object ReadOnlyChangedEvent = new object();

	private static object RowHeadersVisibleChangedEvent = new object();

	private static object RowHeaderWidthChangedEvent = new object();

	private static object SelectionBackColorChangedEvent = new object();

	private static object SelectionForeColorChangedEvent = new object();

	[DefaultValue(true)]
	public bool AllowSorting
	{
		get
		{
			return allow_sorting;
		}
		set
		{
			if (is_default)
			{
				throw new ArgumentException("Cannot change the value of this property on the default DataGridTableStyle.");
			}
			if (allow_sorting != value)
			{
				allow_sorting = value;
				OnAllowSortingChanged(EventArgs.Empty);
			}
		}
	}

	public Color AlternatingBackColor
	{
		get
		{
			return alternating_backcolor;
		}
		set
		{
			if (is_default)
			{
				throw new ArgumentException("Cannot change the value of this property on the default DataGridTableStyle.");
			}
			if (alternating_backcolor != value)
			{
				alternating_backcolor = value;
				OnAlternatingBackColorChanged(EventArgs.Empty);
			}
		}
	}

	public Color BackColor
	{
		get
		{
			return backcolor;
		}
		set
		{
			if (is_default)
			{
				throw new ArgumentException("Cannot change the value of this property on the default DataGridTableStyle.");
			}
			if (backcolor != value)
			{
				backcolor = value;
				OnForeColorChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(true)]
	public bool ColumnHeadersVisible
	{
		get
		{
			return columnheaders_visible;
		}
		set
		{
			if (columnheaders_visible != value)
			{
				columnheaders_visible = value;
				OnColumnHeadersVisibleChanged(EventArgs.Empty);
			}
		}
	}

	[Browsable(false)]
	public virtual DataGrid DataGrid
	{
		get
		{
			return datagrid;
		}
		set
		{
			if (datagrid != value)
			{
				datagrid = value;
				for (int i = 0; i < column_styles.Count; i++)
				{
					column_styles[i].SetDataGridInternal(datagrid);
				}
			}
		}
	}

	public Color ForeColor
	{
		get
		{
			return forecolor;
		}
		set
		{
			if (is_default)
			{
				throw new ArgumentException("Cannot change the value of this property on the default DataGridTableStyle.");
			}
			if (forecolor != value)
			{
				forecolor = value;
				OnBackColorChanged(EventArgs.Empty);
			}
		}
	}

	[Localizable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual GridColumnStylesCollection GridColumnStyles => column_styles;

	public Color GridLineColor
	{
		get
		{
			return gridline_color;
		}
		set
		{
			if (is_default)
			{
				throw new ArgumentException("Cannot change the value of this property on the default DataGridTableStyle.");
			}
			if (gridline_color != value)
			{
				gridline_color = value;
				OnGridLineColorChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(DataGridLineStyle.Solid)]
	public DataGridLineStyle GridLineStyle
	{
		get
		{
			return gridline_style;
		}
		set
		{
			if (is_default)
			{
				throw new ArgumentException("Cannot change the value of this property on the default DataGridTableStyle.");
			}
			if (gridline_style != value)
			{
				gridline_style = value;
				OnGridLineStyleChanged(EventArgs.Empty);
			}
		}
	}

	public Color HeaderBackColor
	{
		get
		{
			return header_backcolor;
		}
		set
		{
			if (is_default)
			{
				throw new ArgumentException("Cannot change the value of this property on the default DataGridTableStyle.");
			}
			if (value == Color.Empty)
			{
				throw new ArgumentNullException("Color.Empty value is invalid.");
			}
			if (header_backcolor != value)
			{
				header_backcolor = value;
				OnHeaderBackColorChanged(EventArgs.Empty);
			}
		}
	}

	[Localizable(true)]
	[AmbientValue(null)]
	public Font HeaderFont
	{
		get
		{
			if (header_font != null)
			{
				return header_font;
			}
			if (DataGrid != null)
			{
				return DataGrid.Font;
			}
			return def_header_font;
		}
		set
		{
			if (is_default)
			{
				throw new ArgumentException("Cannot change the value of this property on the default DataGridTableStyle.");
			}
			if (header_font != value)
			{
				header_font = value;
				OnHeaderFontChanged(EventArgs.Empty);
			}
		}
	}

	public Color HeaderForeColor
	{
		get
		{
			return header_forecolor;
		}
		set
		{
			if (is_default)
			{
				throw new ArgumentException("Cannot change the value of this property on the default DataGridTableStyle.");
			}
			if (header_forecolor != value)
			{
				header_forecolor = value;
				OnHeaderForeColorChanged(EventArgs.Empty);
			}
		}
	}

	public Color LinkColor
	{
		get
		{
			return link_color;
		}
		set
		{
			if (is_default)
			{
				throw new ArgumentException("Cannot change the value of this property on the default DataGridTableStyle.");
			}
			if (link_color != value)
			{
				link_color = value;
				OnLinkColorChanged(EventArgs.Empty);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public Color LinkHoverColor
	{
		get
		{
			return link_hovercolor;
		}
		set
		{
			if (link_hovercolor != value)
			{
				link_hovercolor = value;
			}
		}
	}

	[Editor("System.Windows.Forms.Design.DataGridTableStyleMappingNameEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
	public string MappingName
	{
		get
		{
			return mapping_name;
		}
		set
		{
			if (value == null)
			{
				value = "";
			}
			if (mapping_name != value)
			{
				mapping_name = value;
				OnMappingNameChanged(EventArgs.Empty);
			}
		}
	}

	[Localizable(true)]
	[TypeConverter(typeof(DataGridPreferredColumnWidthTypeConverter))]
	[DefaultValue(75)]
	public int PreferredColumnWidth
	{
		get
		{
			return preferredcolumn_width;
		}
		set
		{
			if (is_default)
			{
				throw new ArgumentException("Cannot change the value of this property on the default DataGridTableStyle.");
			}
			if (value < 0)
			{
				throw new ArgumentException("PreferredColumnWidth is less than 0");
			}
			if (preferredcolumn_width != value)
			{
				preferredcolumn_width = value;
				OnPreferredColumnWidthChanged(EventArgs.Empty);
			}
		}
	}

	[Localizable(true)]
	public int PreferredRowHeight
	{
		get
		{
			return preferredrow_height;
		}
		set
		{
			if (is_default)
			{
				throw new ArgumentException("Cannot change the value of this property on the default DataGridTableStyle.");
			}
			if (preferredrow_height != value)
			{
				preferredrow_height = value;
				OnPreferredRowHeightChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(false)]
	public virtual bool ReadOnly
	{
		get
		{
			return _readonly;
		}
		set
		{
			if (_readonly != value)
			{
				_readonly = value;
				OnReadOnlyChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(true)]
	public bool RowHeadersVisible
	{
		get
		{
			return rowheaders_visible;
		}
		set
		{
			if (rowheaders_visible != value)
			{
				rowheaders_visible = value;
				OnRowHeadersVisibleChanged(EventArgs.Empty);
			}
		}
	}

	[Localizable(true)]
	[DefaultValue(35)]
	public int RowHeaderWidth
	{
		get
		{
			return rowheaders_width;
		}
		set
		{
			if (rowheaders_width != value)
			{
				rowheaders_width = value;
				OnRowHeaderWidthChanged(EventArgs.Empty);
			}
		}
	}

	public Color SelectionBackColor
	{
		get
		{
			return selection_backcolor;
		}
		set
		{
			if (is_default)
			{
				throw new ArgumentException("Cannot change the value of this property on the default DataGridTableStyle.");
			}
			if (selection_backcolor != value)
			{
				selection_backcolor = value;
				OnSelectionBackColorChanged(EventArgs.Empty);
			}
		}
	}

	[Description("The foreground color for the current data grid row")]
	public Color SelectionForeColor
	{
		get
		{
			return selection_forecolor;
		}
		set
		{
			if (is_default)
			{
				throw new ArgumentException("Cannot change the value of this property on the default DataGridTableStyle.");
			}
			if (selection_forecolor != value)
			{
				selection_forecolor = value;
				OnSelectionForeColorChanged(EventArgs.Empty);
			}
		}
	}

	internal DataGridLineStyle CurrentGridLineStyle
	{
		get
		{
			if (is_default && datagrid != null)
			{
				return datagrid.GridLineStyle;
			}
			return gridline_style;
		}
	}

	internal Color CurrentGridLineColor
	{
		get
		{
			if (is_default && datagrid != null)
			{
				return datagrid.GridLineColor;
			}
			return gridline_color;
		}
	}

	internal Color CurrentHeaderBackColor
	{
		get
		{
			if (is_default && datagrid != null)
			{
				return datagrid.HeaderBackColor;
			}
			return header_backcolor;
		}
	}

	internal Color CurrentHeaderForeColor
	{
		get
		{
			if (is_default && datagrid != null)
			{
				return datagrid.HeaderForeColor;
			}
			return header_forecolor;
		}
	}

	internal int CurrentPreferredColumnWidth
	{
		get
		{
			if (is_default && datagrid != null)
			{
				return datagrid.PreferredColumnWidth;
			}
			return preferredcolumn_width;
		}
	}

	internal int CurrentPreferredRowHeight
	{
		get
		{
			if (is_default && datagrid != null)
			{
				return datagrid.PreferredRowHeight;
			}
			return preferredrow_height;
		}
	}

	internal bool CurrentRowHeadersVisible
	{
		get
		{
			if (is_default && datagrid != null)
			{
				return datagrid.RowHeadersVisible;
			}
			return rowheaders_visible;
		}
	}

	internal bool HasRelations => table_relations.Count > 0;

	internal string[] Relations
	{
		get
		{
			string[] array = new string[table_relations.Count];
			table_relations.CopyTo(array, 0);
			return array;
		}
	}

	public event EventHandler AllowSortingChanged
	{
		add
		{
			base.Events.AddHandler(AllowSortingChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(AllowSortingChangedEvent, value);
		}
	}

	public event EventHandler AlternatingBackColorChanged
	{
		add
		{
			base.Events.AddHandler(AlternatingBackColorChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(AlternatingBackColorChangedEvent, value);
		}
	}

	public event EventHandler BackColorChanged
	{
		add
		{
			base.Events.AddHandler(BackColorChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(BackColorChangedEvent, value);
		}
	}

	public event EventHandler ColumnHeadersVisibleChanged
	{
		add
		{
			base.Events.AddHandler(ColumnHeadersVisibleChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnHeadersVisibleChangedEvent, value);
		}
	}

	public event EventHandler ForeColorChanged
	{
		add
		{
			base.Events.AddHandler(ForeColorChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ForeColorChangedEvent, value);
		}
	}

	public event EventHandler GridLineColorChanged
	{
		add
		{
			base.Events.AddHandler(GridLineColorChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(GridLineColorChangedEvent, value);
		}
	}

	public event EventHandler GridLineStyleChanged
	{
		add
		{
			base.Events.AddHandler(GridLineStyleChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(GridLineStyleChangedEvent, value);
		}
	}

	public event EventHandler HeaderBackColorChanged
	{
		add
		{
			base.Events.AddHandler(HeaderBackColorChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(HeaderBackColorChangedEvent, value);
		}
	}

	public event EventHandler HeaderFontChanged
	{
		add
		{
			base.Events.AddHandler(HeaderFontChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(HeaderFontChangedEvent, value);
		}
	}

	public event EventHandler HeaderForeColorChanged
	{
		add
		{
			base.Events.AddHandler(HeaderForeColorChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(HeaderForeColorChangedEvent, value);
		}
	}

	public event EventHandler LinkColorChanged
	{
		add
		{
			base.Events.AddHandler(LinkColorChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(LinkColorChangedEvent, value);
		}
	}

	public event EventHandler LinkHoverColorChanged
	{
		add
		{
			base.Events.AddHandler(LinkHoverColorChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(LinkHoverColorChangedEvent, value);
		}
	}

	public event EventHandler MappingNameChanged
	{
		add
		{
			base.Events.AddHandler(MappingNameChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(MappingNameChangedEvent, value);
		}
	}

	public event EventHandler PreferredColumnWidthChanged
	{
		add
		{
			base.Events.AddHandler(PreferredColumnWidthChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(PreferredColumnWidthChangedEvent, value);
		}
	}

	public event EventHandler PreferredRowHeightChanged
	{
		add
		{
			base.Events.AddHandler(PreferredRowHeightChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(PreferredRowHeightChangedEvent, value);
		}
	}

	public event EventHandler ReadOnlyChanged
	{
		add
		{
			base.Events.AddHandler(ReadOnlyChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ReadOnlyChangedEvent, value);
		}
	}

	public event EventHandler RowHeadersVisibleChanged
	{
		add
		{
			base.Events.AddHandler(RowHeadersVisibleChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowHeadersVisibleChangedEvent, value);
		}
	}

	public event EventHandler RowHeaderWidthChanged
	{
		add
		{
			base.Events.AddHandler(RowHeaderWidthChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowHeaderWidthChangedEvent, value);
		}
	}

	public event EventHandler SelectionBackColorChanged
	{
		add
		{
			base.Events.AddHandler(SelectionBackColorChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(SelectionBackColorChangedEvent, value);
		}
	}

	public event EventHandler SelectionForeColorChanged
	{
		add
		{
			base.Events.AddHandler(SelectionForeColorChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(SelectionForeColorChangedEvent, value);
		}
	}

	public DataGridTableStyle()
		: this(isDefaultTableStyle: false)
	{
	}

	public DataGridTableStyle(bool isDefaultTableStyle)
	{
		is_default = isDefaultTableStyle;
		allow_sorting = true;
		datagrid = null;
		header_forecolor = def_header_forecolor;
		mapping_name = string.Empty;
		table_relations = new ArrayList();
		column_styles = new GridColumnStylesCollection(this);
		alternating_backcolor = def_alternating_backcolor;
		columnheaders_visible = true;
		gridline_color = def_gridline_color;
		gridline_style = DataGridLineStyle.Solid;
		header_backcolor = def_header_backcolor;
		header_font = null;
		link_color = def_link_color;
		link_hovercolor = def_link_hovercolor;
		preferredcolumn_width = ThemeEngine.Current.DataGridPreferredColumnWidth;
		preferredrow_height = ThemeEngine.Current.DefaultFont.Height + 3;
		_readonly = false;
		rowheaders_visible = true;
		selection_backcolor = def_selection_backcolor;
		selection_forecolor = def_selection_forecolor;
		rowheaders_width = 35;
		backcolor = def_backcolor;
		forecolor = def_forecolor;
	}

	public DataGridTableStyle(CurrencyManager listManager)
		: this(isDefaultTableStyle: false)
	{
		manager = listManager;
	}

	[System.MonoTODO("Not implemented, will throw NotImplementedException")]
	public bool BeginEdit(DataGridColumnStyle gridColumn, int rowNumber)
	{
		throw new NotImplementedException();
	}

	protected internal virtual DataGridColumnStyle CreateGridColumn(PropertyDescriptor prop)
	{
		return CreateGridColumn(prop, isDefault: false);
	}

	protected internal virtual DataGridColumnStyle CreateGridColumn(PropertyDescriptor prop, bool isDefault)
	{
		if (prop.PropertyType == typeof(bool))
		{
			return new DataGridBoolColumn(prop, isDefault);
		}
		if (prop.PropertyType.Equals(typeof(DateTime)))
		{
			return new DataGridTextBoxColumn(prop, "d", isDefault);
		}
		if (prop.PropertyType.Equals(typeof(int)) || prop.PropertyType.Equals(typeof(short)))
		{
			return new DataGridTextBoxColumn(prop, "G", isDefault);
		}
		return new DataGridTextBoxColumn(prop, isDefault);
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	[System.MonoTODO("Not implemented, will throw NotImplementedException")]
	public bool EndEdit(DataGridColumnStyle gridColumn, int rowNumber, bool shouldAbort)
	{
		throw new NotImplementedException();
	}

	protected virtual void OnAllowSortingChanged(EventArgs e)
	{
		((EventHandler)base.Events[AllowSortingChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnAlternatingBackColorChanged(EventArgs e)
	{
		((EventHandler)base.Events[AlternatingBackColorChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnBackColorChanged(EventArgs e)
	{
		((EventHandler)base.Events[BackColorChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnColumnHeadersVisibleChanged(EventArgs e)
	{
		((EventHandler)base.Events[ColumnHeadersVisibleChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnForeColorChanged(EventArgs e)
	{
		((EventHandler)base.Events[ForeColorChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnGridLineColorChanged(EventArgs e)
	{
		((EventHandler)base.Events[GridLineColorChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnGridLineStyleChanged(EventArgs e)
	{
		((EventHandler)base.Events[GridLineStyleChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnHeaderBackColorChanged(EventArgs e)
	{
		((EventHandler)base.Events[HeaderBackColorChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnHeaderFontChanged(EventArgs e)
	{
		((EventHandler)base.Events[HeaderFontChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnHeaderForeColorChanged(EventArgs e)
	{
		((EventHandler)base.Events[HeaderForeColorChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnLinkColorChanged(EventArgs e)
	{
		((EventHandler)base.Events[LinkColorChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnLinkHoverColorChanged(EventArgs e)
	{
		((EventHandler)base.Events[LinkHoverColorChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnMappingNameChanged(EventArgs e)
	{
		((EventHandler)base.Events[MappingNameChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnPreferredColumnWidthChanged(EventArgs e)
	{
		((EventHandler)base.Events[PreferredColumnWidthChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnPreferredRowHeightChanged(EventArgs e)
	{
		((EventHandler)base.Events[PreferredRowHeightChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnReadOnlyChanged(EventArgs e)
	{
		((EventHandler)base.Events[ReadOnlyChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnRowHeadersVisibleChanged(EventArgs e)
	{
		((EventHandler)base.Events[RowHeadersVisibleChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnRowHeaderWidthChanged(EventArgs e)
	{
		((EventHandler)base.Events[RowHeaderWidthChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnSelectionBackColorChanged(EventArgs e)
	{
		((EventHandler)base.Events[SelectionBackColorChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnSelectionForeColorChanged(EventArgs e)
	{
		((EventHandler)base.Events[SelectionForeColorChangedEvent])?.Invoke(this, e);
	}

	public void ResetAlternatingBackColor()
	{
		AlternatingBackColor = def_alternating_backcolor;
	}

	public void ResetBackColor()
	{
		BackColor = def_backcolor;
	}

	public void ResetForeColor()
	{
		ForeColor = def_forecolor;
	}

	public void ResetGridLineColor()
	{
		GridLineColor = def_gridline_color;
	}

	public void ResetHeaderBackColor()
	{
		HeaderBackColor = def_header_backcolor;
	}

	public void ResetHeaderFont()
	{
		HeaderFont = def_header_font;
	}

	public void ResetHeaderForeColor()
	{
		HeaderForeColor = def_header_forecolor;
	}

	public void ResetLinkColor()
	{
		LinkColor = def_link_color;
	}

	public void ResetLinkHoverColor()
	{
		LinkHoverColor = def_link_hovercolor;
	}

	public void ResetSelectionBackColor()
	{
		SelectionBackColor = def_selection_backcolor;
	}

	public void ResetSelectionForeColor()
	{
		SelectionForeColor = def_selection_forecolor;
	}

	protected virtual bool ShouldSerializeAlternatingBackColor()
	{
		return alternating_backcolor != def_alternating_backcolor;
	}

	protected bool ShouldSerializeBackColor()
	{
		return backcolor != def_backcolor;
	}

	protected bool ShouldSerializeForeColor()
	{
		return forecolor != def_forecolor;
	}

	protected virtual bool ShouldSerializeGridLineColor()
	{
		return gridline_color != def_gridline_color;
	}

	protected virtual bool ShouldSerializeHeaderBackColor()
	{
		return header_backcolor != def_header_backcolor;
	}

	protected virtual bool ShouldSerializeHeaderForeColor()
	{
		return header_forecolor != def_header_forecolor;
	}

	protected virtual bool ShouldSerializeLinkColor()
	{
		return link_color != def_link_color;
	}

	protected virtual bool ShouldSerializeLinkHoverColor()
	{
		return link_hovercolor != def_link_hovercolor;
	}

	protected bool ShouldSerializePreferredRowHeight()
	{
		return preferredrow_height != def_preferredrow_height;
	}

	protected bool ShouldSerializeSelectionBackColor()
	{
		return selection_backcolor != def_selection_backcolor;
	}

	protected virtual bool ShouldSerializeSelectionForeColor()
	{
		return selection_forecolor != def_selection_forecolor;
	}

	internal void CreateColumnsForTable(bool onlyBind)
	{
		CurrencyManager listManager = manager;
		if (listManager == null)
		{
			listManager = datagrid.ListManager;
			if (listManager == null)
			{
				return;
			}
		}
		for (int i = 0; i < column_styles.Count; i++)
		{
			column_styles[i].bound = false;
		}
		table_relations.Clear();
		PropertyDescriptorCollection itemProperties = listManager.GetItemProperties();
		for (int j = 0; j < itemProperties.Count; j++)
		{
			DataGridColumnStyle dataGridColumnStyle = column_styles[itemProperties[j].Name];
			if (dataGridColumnStyle != null)
			{
				if (dataGridColumnStyle.Width == -1)
				{
					dataGridColumnStyle.Width = CurrentPreferredColumnWidth;
				}
				dataGridColumnStyle.PropertyDescriptor = itemProperties[j];
				dataGridColumnStyle.bound = true;
			}
			else if (!onlyBind)
			{
				if (typeof(IBindingList).IsAssignableFrom(itemProperties[j].PropertyType))
				{
					table_relations.Add(itemProperties[j].Name);
				}
				else if (itemProperties[j].IsBrowsable)
				{
					dataGridColumnStyle = CreateGridColumn(itemProperties[j], isDefault: true);
					dataGridColumnStyle.bound = true;
					dataGridColumnStyle.grid = datagrid;
					dataGridColumnStyle.MappingName = itemProperties[j].Name;
					dataGridColumnStyle.HeaderText = itemProperties[j].Name;
					dataGridColumnStyle.Width = CurrentPreferredColumnWidth;
					column_styles.Add(dataGridColumnStyle);
				}
			}
		}
	}
}
