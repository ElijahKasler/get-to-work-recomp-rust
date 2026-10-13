using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using Unity;

namespace System.Windows.Forms;

[Docking(DockingBehavior.Ask)]
[DefaultEvent("CellContentClick")]
[ComplexBindingProperties("DataSource", "DataMember")]
[Editor("System.Windows.Forms.Design.DataGridViewComponentEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(ComponentEditor))]
[Designer("System.Windows.Forms.Design.DataGridViewDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.IDesigner")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class DataGridView : Control, ISupportInitialize, IBindableComponent, IComponent, IDisposable, IDropTarget
{
	private class ColumnSorter : IComparer
	{
		private int column;

		private int direction = 1;

		private bool numeric_sort;

		public ColumnSorter(DataGridViewColumn column, ListSortDirection direction, bool numeric)
		{
			this.column = column.Index;
			numeric_sort = numeric;
			if (direction == ListSortDirection.Descending)
			{
				this.direction = -1;
			}
		}

		public int Compare(object x, object y)
		{
			DataGridViewRow dataGridViewRow = (DataGridViewRow)x;
			DataGridViewRow dataGridViewRow2 = (DataGridViewRow)y;
			if (dataGridViewRow.Cells[column].ValueType == typeof(DateTime) && dataGridViewRow2.Cells[column].ValueType == typeof(DateTime))
			{
				return DateTime.Compare((DateTime)dataGridViewRow.Cells[column].Value, (DateTime)dataGridViewRow2.Cells[column].Value) * direction;
			}
			object formattedValue = dataGridViewRow.Cells[column].FormattedValue;
			object formattedValue2 = dataGridViewRow2.Cells[column].FormattedValue;
			object nullValue = dataGridViewRow.Cells[column].InheritedStyle.NullValue;
			object nullValue2 = dataGridViewRow2.Cells[column].InheritedStyle.NullValue;
			if (formattedValue == nullValue && formattedValue2 == nullValue2)
			{
				return 0;
			}
			if (formattedValue == nullValue)
			{
				return direction;
			}
			if (formattedValue2 == nullValue2)
			{
				return -1 * direction;
			}
			if (numeric_sort)
			{
				return (int)(double.Parse(formattedValue.ToString()) - double.Parse(formattedValue2.ToString())) * direction;
			}
			return string.Compare(formattedValue.ToString(), formattedValue2.ToString()) * direction;
		}
	}

	public sealed class HitTestInfo
	{
		public static readonly HitTestInfo Nowhere = new HitTestInfo(-1, -1, -1, -1, DataGridViewHitTestType.None);

		private int columnIndex;

		private int columnX;

		private int rowIndex;

		private int rowY;

		private DataGridViewHitTestType type;

		public int ColumnIndex => columnIndex;

		public int ColumnX => columnX;

		public int RowIndex => rowIndex;

		public int RowY => rowY;

		public DataGridViewHitTestType Type => type;

		internal HitTestInfo(int columnIndex, int columnX, int rowIndex, int rowY, DataGridViewHitTestType type)
		{
			this.columnIndex = columnIndex;
			this.columnX = columnX;
			this.rowIndex = rowIndex;
			this.rowY = rowY;
			this.type = type;
		}

		public override bool Equals(object value)
		{
			if (value is HitTestInfo)
			{
				HitTestInfo hitTestInfo = (HitTestInfo)value;
				if (hitTestInfo.columnIndex == columnIndex && hitTestInfo.columnX == columnX && hitTestInfo.rowIndex == rowIndex && hitTestInfo.rowY == rowY && hitTestInfo.type == type)
				{
					return true;
				}
			}
			return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override string ToString()
		{
			return $"Type:{type}, Column:{columnIndex}, Row:{rowIndex}";
		}

		internal HitTestInfo()
		{
			Unity.ThrowStub.ThrowNotSupportedException();
		}
	}

	[ComVisible(false)]
	public class DataGridViewControlCollection : ControlCollection
	{
		private DataGridView owner;

		public DataGridViewControlCollection(DataGridView owner)
			: base(owner)
		{
			this.owner = owner;
		}

		public override void Clear()
		{
			for (int i = 0; i < Count; i++)
			{
				Remove(this[i]);
			}
		}

		public void CopyTo(Control[] array, int index)
		{
			CopyTo((Array)array, index);
		}

		public void Insert(int index, Control value)
		{
			throw new NotSupportedException();
		}

		public override void Remove(Control value)
		{
			if (value != owner.horizontalScrollBar && value != owner.verticalScrollBar && value != owner.editingControl)
			{
				base.Remove(value);
			}
		}

		internal void RemoveInternal(Control value)
		{
			base.Remove(value);
		}
	}

	[ComVisible(true)]
	protected class DataGridViewAccessibleObject : ControlAccessibleObject
	{
		public override AccessibleRole Role => base.Role;

		public override string Name => base.Name;

		public DataGridViewAccessibleObject(DataGridView owner)
			: base(owner)
		{
		}

		public override AccessibleObject GetChild(int index)
		{
			return base.GetChild(index);
		}

		public override int GetChildCount()
		{
			return base.GetChildCount();
		}

		public override AccessibleObject GetFocused()
		{
			return base.GetFocused();
		}

		public override AccessibleObject GetSelected()
		{
			return base.GetSelected();
		}

		public override AccessibleObject HitTest(int x, int y)
		{
			return base.HitTest(x, y);
		}

		public override AccessibleObject Navigate(AccessibleNavigation navigationDirection)
		{
			return base.Navigate(navigationDirection);
		}
	}

	[ComVisible(true)]
	protected class DataGridViewTopRowAccessibleObject : AccessibleObject
	{
		public override Rectangle Bounds => base.Bounds;

		public override string Name => base.Name;

		public DataGridView Owner
		{
			get
			{
				return (DataGridView)owner;
			}
			set
			{
				if (owner != null)
				{
					throw new InvalidOperationException("owner has already been set");
				}
				owner = value;
			}
		}

		public override AccessibleObject Parent => base.Parent;

		public override AccessibleRole Role => base.Role;

		public override string Value => base.Value;

		public DataGridViewTopRowAccessibleObject()
		{
		}

		public DataGridViewTopRowAccessibleObject(DataGridView owner)
		{
			base.owner = owner;
		}

		public override AccessibleObject GetChild(int index)
		{
			return base.GetChild(index);
		}

		public override int GetChildCount()
		{
			return base.GetChildCount();
		}

		public override AccessibleObject Navigate(AccessibleNavigation navigationDirection)
		{
			return base.Navigate(navigationDirection);
		}
	}

	private DataGridViewAdvancedBorderStyle adjustedTopLeftHeaderBorderStyle;

	private DataGridViewAdvancedBorderStyle advancedCellBorderStyle;

	private DataGridViewAdvancedBorderStyle advancedColumnHeadersBorderStyle;

	private DataGridViewAdvancedBorderStyle advancedRowHeadersBorderStyle;

	private bool allowUserToAddRows;

	private bool allowUserToDeleteRows;

	private bool allowUserToOrderColumns;

	private bool allowUserToResizeColumns;

	private bool allowUserToResizeRows;

	private DataGridViewCellStyle alternatingRowsDefaultCellStyle;

	private Point anchor_cell;

	private bool autoGenerateColumns;

	private bool autoSize;

	private DataGridViewAutoSizeColumnsMode autoSizeColumnsMode;

	private DataGridViewAutoSizeRowsMode autoSizeRowsMode;

	private Color backColor;

	private Color backgroundColor;

	private Image backgroundImage;

	private BorderStyle borderStyle;

	private DataGridViewCellBorderStyle cellBorderStyle;

	private DataGridViewClipboardCopyMode clipboardCopyMode;

	private DataGridViewHeaderBorderStyle columnHeadersBorderStyle;

	private DataGridViewCellStyle columnHeadersDefaultCellStyle;

	private int columnHeadersHeight;

	private DataGridViewColumnHeadersHeightSizeMode columnHeadersHeightSizeMode;

	private bool columnHeadersVisible;

	private DataGridViewColumnCollection columns;

	private DataGridViewCell currentCell;

	private Point currentCellAddress;

	private string dataMember;

	private object dataSource;

	private DataGridViewCellStyle defaultCellStyle;

	private DataGridViewEditMode editMode;

	private bool enableHeadersVisualStyles = true;

	private DataGridViewCell firstDisplayedCell;

	private int firstDisplayedScrollingColumnHiddenWidth;

	private int firstDisplayedScrollingColumnIndex;

	private int firstDisplayedScrollingRowIndex;

	private Color gridColor = Color.FromKnownColor(KnownColor.ControlDark);

	private int horizontalScrollingOffset;

	private DataGridViewCell hover_cell;

	private bool isCurrentCellDirty;

	private bool multiSelect;

	private bool readOnly;

	private DataGridViewHeaderBorderStyle rowHeadersBorderStyle;

	private DataGridViewCellStyle rowHeadersDefaultCellStyle;

	private bool rowHeadersVisible;

	private int rowHeadersWidth;

	private DataGridViewRowHeadersWidthSizeMode rowHeadersWidthSizeMode;

	private DataGridViewRowCollection rows;

	private DataGridViewCellStyle rowsDefaultCellStyle;

	private DataGridViewRow rowTemplate;

	private ScrollBars scrollBars;

	private DataGridViewSelectionMode selectionMode;

	private bool showCellErrors;

	private bool showCellToolTips;

	private bool showEditingIcon;

	private bool showRowErrors;

	private DataGridViewColumn sortedColumn;

	private SortOrder sortOrder;

	private bool standardTab;

	private DataGridViewHeaderCell topLeftHeaderCell;

	private Cursor userSetCursor;

	private int verticalScrollingOffset;

	private bool virtualMode;

	private HScrollBar horizontalScrollBar;

	private VScrollBar verticalScrollBar;

	private Control editingControl;

	private bool is_autogenerating_columns;

	private bool is_binding;

	private bool new_row_editing;

	private int selected_row = -1;

	private int selected_column = -1;

	private Timer tooltip_timer;

	private ToolTip tooltip_window;

	private DataGridViewCell tooltip_currently_showing;

	private DataGridViewSelectedRowCollection selected_rows;

	private DataGridViewSelectedColumnCollection selected_columns;

	private DataGridViewRow editing_row;

	private DataGridViewHeaderCell pressed_header_cell;

	private DataGridViewHeaderCell entered_header_cell;

	private bool column_resize_active;

	private bool row_resize_active;

	private int resize_band = -1;

	private int resize_band_start;

	private int resize_band_delta;

	private static object AllowUserToAddRowsChangedEvent = new object();

	private static object AllowUserToDeleteRowsChangedEvent = new object();

	private static object AllowUserToOrderColumnsChangedEvent = new object();

	private static object AllowUserToResizeColumnsChangedEvent = new object();

	private static object AllowUserToResizeRowsChangedEvent = new object();

	private static object AlternatingRowsDefaultCellStyleChangedEvent = new object();

	private static object AutoGenerateColumnsChangedEvent = new object();

	private static object AutoSizeColumnModeChangedEvent = new object();

	private static object AutoSizeColumnsModeChangedEvent = new object();

	private static object AutoSizeRowsModeChangedEvent = new object();

	private static object BackgroundColorChangedEvent = new object();

	private static object BorderStyleChangedEvent = new object();

	private static object CancelRowEditEvent = new object();

	private static object CellBeginEditEvent = new object();

	private static object CellBorderStyleChangedEvent = new object();

	private static object CellClickEvent = new object();

	private static object CellContentClickEvent = new object();

	private static object CellContentDoubleClickEvent = new object();

	private static object CellContextMenuStripChangedEvent = new object();

	private static object CellContextMenuStripNeededEvent = new object();

	private static object CellDoubleClickEvent = new object();

	private static object CellEndEditEvent = new object();

	private static object CellEnterEvent = new object();

	private static object CellErrorTextChangedEvent = new object();

	private static object CellErrorTextNeededEvent = new object();

	private static object CellFormattingEvent = new object();

	private static object CellLeaveEvent = new object();

	private static object CellMouseClickEvent = new object();

	private static object CellMouseDoubleClickEvent = new object();

	private static object CellMouseDownEvent = new object();

	private static object CellMouseEnterEvent = new object();

	private static object CellMouseLeaveEvent = new object();

	private static object CellMouseMoveEvent = new object();

	private static object CellMouseUpEvent = new object();

	private static object CellPaintingEvent = new object();

	private static object CellParsingEvent = new object();

	private static object CellStateChangedEvent = new object();

	private static object CellStyleChangedEvent = new object();

	private static object CellStyleContentChangedEvent = new object();

	private static object CellToolTipTextChangedEvent = new object();

	private static object CellToolTipTextNeededEvent = new object();

	private static object CellValidatedEvent = new object();

	private static object CellValidatingEvent = new object();

	private static object CellValueChangedEvent = new object();

	private static object CellValueNeededEvent = new object();

	private static object CellValuePushedEvent = new object();

	private static object ColumnAddedEvent = new object();

	private static object ColumnContextMenuStripChangedEvent = new object();

	private static object ColumnDataPropertyNameChangedEvent = new object();

	private static object ColumnDefaultCellStyleChangedEvent = new object();

	private static object ColumnDisplayIndexChangedEvent = new object();

	private static object ColumnDividerDoubleClickEvent = new object();

	private static object ColumnDividerWidthChangedEvent = new object();

	private static object ColumnHeaderCellChangedEvent = new object();

	private static object ColumnHeaderMouseClickEvent = new object();

	private static object ColumnHeaderMouseDoubleClickEvent = new object();

	private static object ColumnHeadersBorderStyleChangedEvent = new object();

	private static object ColumnHeadersDefaultCellStyleChangedEvent = new object();

	private static object ColumnHeadersHeightChangedEvent = new object();

	private static object ColumnHeadersHeightSizeModeChangedEvent = new object();

	private static object ColumnMinimumWidthChangedEvent = new object();

	private static object ColumnNameChangedEvent = new object();

	private static object ColumnRemovedEvent = new object();

	private static object ColumnSortModeChangedEvent = new object();

	private static object ColumnStateChangedEvent = new object();

	private static object ColumnToolTipTextChangedEvent = new object();

	private static object ColumnWidthChangedEvent = new object();

	private static object CurrentCellChangedEvent = new object();

	private static object CurrentCellDirtyStateChangedEvent = new object();

	private static object DataBindingCompleteEvent = new object();

	private static object DataErrorEvent = new object();

	private static object DataMemberChangedEvent = new object();

	private static object DataSourceChangedEvent = new object();

	private static object DefaultCellStyleChangedEvent = new object();

	private static object DefaultValuesNeededEvent = new object();

	private static object EditingControlShowingEvent = new object();

	private static object EditModeChangedEvent = new object();

	private static object GridColorChangedEvent = new object();

	private static object MultiSelectChangedEvent = new object();

	private static object NewRowNeededEvent = new object();

	private static object ReadOnlyChangedEvent = new object();

	private static object RowContextMenuStripChangedEvent = new object();

	private static object RowContextMenuStripNeededEvent = new object();

	private static object RowDefaultCellStyleChangedEvent = new object();

	private static object RowDirtyStateNeededEvent = new object();

	private static object RowDividerDoubleClickEvent = new object();

	private static object RowDividerHeightChangedEvent = new object();

	private static object RowEnterEvent = new object();

	private static object RowErrorTextChangedEvent = new object();

	private static object RowErrorTextNeededEvent = new object();

	private static object RowHeaderCellChangedEvent = new object();

	private static object RowHeaderMouseClickEvent = new object();

	private static object RowHeaderMouseDoubleClickEvent = new object();

	private static object RowHeadersBorderStyleChangedEvent = new object();

	private static object RowHeadersDefaultCellStyleChangedEvent = new object();

	private static object RowHeadersWidthChangedEvent = new object();

	private static object RowHeadersWidthSizeModeChangedEvent = new object();

	private static object RowHeightChangedEvent = new object();

	private static object RowHeightInfoNeededEvent = new object();

	private static object RowHeightInfoPushedEvent = new object();

	private static object RowLeaveEvent = new object();

	private static object RowMinimumHeightChangedEvent = new object();

	private static object RowPostPaintEvent = new object();

	private static object RowPrePaintEvent = new object();

	private static object RowsAddedEvent = new object();

	private static object RowsDefaultCellStyleChangedEvent = new object();

	private static object RowsRemovedEvent = new object();

	private static object RowStateChangedEvent = new object();

	private static object RowUnsharedEvent = new object();

	private static object RowValidatedEvent = new object();

	private static object RowValidatingEvent = new object();

	private static object ScrollEvent = new object();

	private static object SelectionChangedEvent = new object();

	private static object SortCompareEvent = new object();

	private static object SortedEvent = new object();

	private static object UserAddedRowEvent = new object();

	private static object UserDeletedRowEvent = new object();

	private static object UserDeletingRowEvent = new object();

	private int first_row_index;

	internal int first_col_index;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual DataGridViewAdvancedBorderStyle AdjustedTopLeftHeaderBorderStyle => adjustedTopLeftHeaderBorderStyle;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	public DataGridViewAdvancedBorderStyle AdvancedCellBorderStyle => advancedCellBorderStyle;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	public DataGridViewAdvancedBorderStyle AdvancedColumnHeadersBorderStyle => advancedColumnHeadersBorderStyle;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public DataGridViewAdvancedBorderStyle AdvancedRowHeadersBorderStyle => advancedRowHeadersBorderStyle;

	[DefaultValue(true)]
	public bool AllowUserToAddRows
	{
		get
		{
			if (allowUserToAddRows && DataManager != null)
			{
				return DataManager.AllowNew;
			}
			return allowUserToAddRows;
		}
		set
		{
			if (allowUserToAddRows == value)
			{
				return;
			}
			allowUserToAddRows = value;
			if (!value)
			{
				if (new_row_editing)
				{
					CancelEdit();
				}
				RemoveEditingRow();
			}
			else
			{
				PrepareEditingRow(cell_changed: false, column_changed: false);
			}
			OnAllowUserToAddRowsChanged(EventArgs.Empty);
			Invalidate();
		}
	}

	[DefaultValue(true)]
	public bool AllowUserToDeleteRows
	{
		get
		{
			if (allowUserToDeleteRows && DataManager != null)
			{
				return DataManager.AllowRemove;
			}
			return allowUserToDeleteRows;
		}
		set
		{
			if (allowUserToDeleteRows != value)
			{
				allowUserToDeleteRows = value;
				OnAllowUserToDeleteRowsChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(false)]
	public bool AllowUserToOrderColumns
	{
		get
		{
			return allowUserToOrderColumns;
		}
		set
		{
			if (allowUserToOrderColumns != value)
			{
				allowUserToOrderColumns = value;
				OnAllowUserToOrderColumnsChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(true)]
	public bool AllowUserToResizeColumns
	{
		get
		{
			return allowUserToResizeColumns;
		}
		set
		{
			if (allowUserToResizeColumns != value)
			{
				allowUserToResizeColumns = value;
				OnAllowUserToResizeColumnsChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(true)]
	public bool AllowUserToResizeRows
	{
		get
		{
			return allowUserToResizeRows;
		}
		set
		{
			if (allowUserToResizeRows != value)
			{
				allowUserToResizeRows = value;
				OnAllowUserToResizeRowsChanged(EventArgs.Empty);
			}
		}
	}

	public DataGridViewCellStyle AlternatingRowsDefaultCellStyle
	{
		get
		{
			return alternatingRowsDefaultCellStyle;
		}
		set
		{
			if (alternatingRowsDefaultCellStyle != value)
			{
				alternatingRowsDefaultCellStyle = value;
				OnAlternatingRowsDefaultCellStyleChanged(EventArgs.Empty);
				Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	[DefaultValue(true)]
	public bool AutoGenerateColumns
	{
		get
		{
			return autoGenerateColumns;
		}
		set
		{
			if (autoGenerateColumns != value)
			{
				autoGenerateColumns = value;
				OnAutoGenerateColumnsChanged(EventArgs.Empty);
			}
		}
	}

	public override bool AutoSize
	{
		get
		{
			return autoSize;
		}
		set
		{
			if (autoSize != value)
			{
				autoSize = value;
			}
		}
	}

	[DefaultValue(DataGridViewAutoSizeColumnsMode.None)]
	public DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode
	{
		get
		{
			return autoSizeColumnsMode;
		}
		set
		{
			if (!Enum.IsDefined(typeof(DataGridViewAutoSizeColumnsMode), value))
			{
				throw new InvalidEnumArgumentException("Value is not valid DataGridViewAutoSizeColumnsMode.");
			}
			if (value == DataGridViewAutoSizeColumnsMode.ColumnHeader && !columnHeadersVisible)
			{
				foreach (DataGridViewColumn column in columns)
				{
					if (column.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet)
					{
						throw new InvalidOperationException("Cant set this property to ColumnHeader in this DataGridView.");
					}
				}
			}
			if (value == DataGridViewAutoSizeColumnsMode.Fill)
			{
				foreach (DataGridViewColumn column2 in columns)
				{
					if (column2.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet && column2.Frozen)
					{
						throw new InvalidOperationException("Cant set this property to Fill in this DataGridView.");
					}
				}
			}
			autoSizeColumnsMode = value;
			AutoResizeColumns(value);
			Invalidate();
		}
	}

	[DefaultValue(DataGridViewAutoSizeRowsMode.None)]
	public DataGridViewAutoSizeRowsMode AutoSizeRowsMode
	{
		get
		{
			return autoSizeRowsMode;
		}
		set
		{
			if (autoSizeRowsMode == value)
			{
				return;
			}
			if (!Enum.IsDefined(typeof(DataGridViewAutoSizeRowsMode), value))
			{
				throw new InvalidEnumArgumentException("Value is not valid DataGridViewRowsMode.");
			}
			if ((value == DataGridViewAutoSizeRowsMode.AllHeaders || value == DataGridViewAutoSizeRowsMode.DisplayedHeaders) && !rowHeadersVisible)
			{
				throw new InvalidOperationException("Cant set this property to AllHeaders or DisplayedHeaders in this DataGridView.");
			}
			autoSizeRowsMode = value;
			if (value == DataGridViewAutoSizeRowsMode.None)
			{
				foreach (DataGridViewRow item in (IEnumerable)Rows)
				{
					item.ResetToExplicitHeight();
				}
			}
			else
			{
				AutoResizeRows(value);
			}
			OnAutoSizeRowsModeChanged(new DataGridViewAutoSizeModeEventArgs(previousModeAutoSized: false));
			Invalidate();
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override Color BackColor
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
				OnBackColorChanged(EventArgs.Empty);
			}
		}
	}

	public Color BackgroundColor
	{
		get
		{
			return backgroundColor;
		}
		set
		{
			if (backgroundColor != value)
			{
				if (value == Color.Empty)
				{
					throw new ArgumentException("Cant set an Empty color.");
				}
				backgroundColor = value;
				OnBackgroundColorChanged(EventArgs.Empty);
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override Image BackgroundImage
	{
		get
		{
			return backgroundImage;
		}
		set
		{
			if (backgroundImage != value)
			{
				backgroundImage = value;
				OnBackgroundImageChanged(EventArgs.Empty);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public override ImageLayout BackgroundImageLayout
	{
		get
		{
			return base.BackgroundImageLayout;
		}
		set
		{
			base.BackgroundImageLayout = value;
		}
	}

	[DefaultValue(BorderStyle.FixedSingle)]
	public BorderStyle BorderStyle
	{
		get
		{
			return borderStyle;
		}
		set
		{
			if (borderStyle != value)
			{
				if (!Enum.IsDefined(typeof(BorderStyle), value))
				{
					throw new InvalidEnumArgumentException("Invalid border style.");
				}
				borderStyle = value;
				OnBorderStyleChanged(EventArgs.Empty);
			}
		}
	}

	internal int BorderWidth => BorderStyle switch
	{
		BorderStyle.Fixed3D => 2, 
		BorderStyle.FixedSingle => 1, 
		_ => 0, 
	};

	[Browsable(true)]
	[DefaultValue(DataGridViewCellBorderStyle.Single)]
	public DataGridViewCellBorderStyle CellBorderStyle
	{
		get
		{
			return cellBorderStyle;
		}
		set
		{
			if (cellBorderStyle != value)
			{
				if (value == DataGridViewCellBorderStyle.Custom)
				{
					throw new ArgumentException("CellBorderStyle cannot be set to Custom.");
				}
				cellBorderStyle = value;
				DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStyle = new DataGridViewAdvancedBorderStyle();
				switch (cellBorderStyle)
				{
				case DataGridViewCellBorderStyle.Single:
					dataGridViewAdvancedBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
					break;
				case DataGridViewCellBorderStyle.Raised:
					dataGridViewAdvancedBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Outset;
					break;
				case DataGridViewCellBorderStyle.RaisedVertical:
					dataGridViewAdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
					dataGridViewAdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
					dataGridViewAdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.Outset;
					dataGridViewAdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Outset;
					break;
				case DataGridViewCellBorderStyle.Sunken:
					dataGridViewAdvancedBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Inset;
					break;
				case DataGridViewCellBorderStyle.None:
					dataGridViewAdvancedBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
					break;
				case DataGridViewCellBorderStyle.SingleVertical:
					dataGridViewAdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
					dataGridViewAdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
					dataGridViewAdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
					dataGridViewAdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Single;
					break;
				case DataGridViewCellBorderStyle.SunkenVertical:
					dataGridViewAdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
					dataGridViewAdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
					dataGridViewAdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.Inset;
					dataGridViewAdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Inset;
					break;
				case DataGridViewCellBorderStyle.SingleHorizontal:
					dataGridViewAdvancedBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
					dataGridViewAdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
					break;
				case DataGridViewCellBorderStyle.SunkenHorizontal:
					dataGridViewAdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Inset;
					dataGridViewAdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Inset;
					dataGridViewAdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
					dataGridViewAdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
					break;
				case DataGridViewCellBorderStyle.RaisedHorizontal:
					dataGridViewAdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Outset;
					dataGridViewAdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Outset;
					dataGridViewAdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
					dataGridViewAdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
					break;
				}
				advancedCellBorderStyle = dataGridViewAdvancedBorderStyle;
				OnCellBorderStyleChanged(EventArgs.Empty);
			}
		}
	}

	[Browsable(true)]
	[DefaultValue(DataGridViewClipboardCopyMode.EnableWithAutoHeaderText)]
	public DataGridViewClipboardCopyMode ClipboardCopyMode
	{
		get
		{
			return clipboardCopyMode;
		}
		set
		{
			clipboardCopyMode = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DefaultValue(0)]
	public int ColumnCount
	{
		get
		{
			return columns.Count;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("ColumnCount", "ColumnCount must be >= 0.");
			}
			if (dataSource != null)
			{
				throw new InvalidOperationException("Cant change column count if DataSource is set.");
			}
			if (value < columns.Count)
			{
				for (int num = columns.Count - 1; num >= value; num--)
				{
					columns.RemoveAt(num);
				}
			}
			else if (value > columns.Count)
			{
				for (int i = columns.Count; i < value; i++)
				{
					DataGridViewTextBoxColumn dataGridViewColumn = new DataGridViewTextBoxColumn();
					columns.Add(dataGridViewColumn);
				}
			}
		}
	}

	[DefaultValue(DataGridViewHeaderBorderStyle.Raised)]
	[Browsable(true)]
	public DataGridViewHeaderBorderStyle ColumnHeadersBorderStyle
	{
		get
		{
			return columnHeadersBorderStyle;
		}
		set
		{
			if (columnHeadersBorderStyle != value)
			{
				columnHeadersBorderStyle = value;
				OnColumnHeadersBorderStyleChanged(EventArgs.Empty);
			}
		}
	}

	[AmbientValue(null)]
	public DataGridViewCellStyle ColumnHeadersDefaultCellStyle
	{
		get
		{
			return columnHeadersDefaultCellStyle;
		}
		set
		{
			if (columnHeadersDefaultCellStyle != value)
			{
				columnHeadersDefaultCellStyle = value;
				OnColumnHeadersDefaultCellStyleChanged(EventArgs.Empty);
			}
		}
	}

	[Localizable(true)]
	public int ColumnHeadersHeight
	{
		get
		{
			return columnHeadersHeight;
		}
		set
		{
			if (columnHeadersHeight != value)
			{
				if (value < 4)
				{
					throw new ArgumentOutOfRangeException("ColumnHeadersHeight", "Column headers height cant be less than 4.");
				}
				if (value > 32768)
				{
					throw new ArgumentOutOfRangeException("ColumnHeadersHeight", "Column headers height cannot be more than 32768.");
				}
				columnHeadersHeight = value;
				OnColumnHeadersHeightChanged(EventArgs.Empty);
				if (columnHeadersVisible)
				{
					Invalidate();
				}
			}
		}
	}

	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(DataGridViewColumnHeadersHeightSizeMode.EnableResizing)]
	public DataGridViewColumnHeadersHeightSizeMode ColumnHeadersHeightSizeMode
	{
		get
		{
			return columnHeadersHeightSizeMode;
		}
		set
		{
			if (columnHeadersHeightSizeMode != value)
			{
				if (!Enum.IsDefined(typeof(DataGridViewColumnHeadersHeightSizeMode), value))
				{
					throw new InvalidEnumArgumentException("Value is not a valid DataGridViewColumnHeadersHeightSizeMode.");
				}
				columnHeadersHeightSizeMode = value;
				OnColumnHeadersHeightSizeModeChanged(new DataGridViewAutoSizeModeEventArgs(previousModeAutoSized: false));
			}
		}
	}

	[DefaultValue(true)]
	public bool ColumnHeadersVisible
	{
		get
		{
			return columnHeadersVisible;
		}
		set
		{
			if (columnHeadersVisible != value)
			{
				columnHeadersVisible = value;
				Invalidate();
			}
		}
	}

	[MergableProperty(false)]
	[Editor("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DataGridViewColumnCollection Columns => columns;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public DataGridViewCell CurrentCell
	{
		get
		{
			return currentCell;
		}
		set
		{
			if (value == null)
			{
				MoveCurrentCell(-1, -1, select: true, isControl: false, isShift: false, scroll: true);
				return;
			}
			if (value.DataGridView != this)
			{
				throw new ArgumentException("The cell is not in this DataGridView.");
			}
			MoveCurrentCell(value.OwningColumn.Index, value.OwningRow.Index, select: true, isControl: false, isShift: false, scroll: true);
		}
	}

	[Browsable(false)]
	public Point CurrentCellAddress => currentCellAddress;

	[Browsable(false)]
	public DataGridViewRow CurrentRow
	{
		get
		{
			if (currentCell != null)
			{
				return currentCell.OwningRow;
			}
			return null;
		}
	}

	[Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
	public string DataMember
	{
		get
		{
			return dataMember;
		}
		set
		{
			if (dataMember != value)
			{
				dataMember = value;
				if (BindingContext != null)
				{
					ReBind();
				}
				OnDataMemberChanged(EventArgs.Empty);
			}
		}
	}

	[AttributeProvider(typeof(IListSource))]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.Repaint)]
	public object DataSource
	{
		get
		{
			return dataSource;
		}
		set
		{
			if (value != null && !(value is IList) && !(value is IListSource) && !(value is IBindingList) && !(value is IBindingListView))
			{
				throw new NotSupportedException("Type cannot be bound.");
			}
			if (value != DataSource)
			{
				if (base.IsHandleCreated && value != null && BindingContext != null && BindingContext[value] != null)
				{
					DataMember = string.Empty;
				}
				ClearBinding();
				if (BindingContext != null)
				{
					dataSource = value;
					ReBind();
				}
				else
				{
					dataSource = value;
				}
				OnDataSourceChanged(EventArgs.Empty);
			}
		}
	}

	internal CurrencyManager DataManager
	{
		get
		{
			if (DataSource != null && BindingContext != null)
			{
				string empty = DataMember;
				if (empty == null)
				{
					empty = string.Empty;
				}
				return (CurrencyManager)BindingContext[DataSource, empty];
			}
			return null;
		}
	}

	[AmbientValue(null)]
	public DataGridViewCellStyle DefaultCellStyle
	{
		get
		{
			return defaultCellStyle;
		}
		set
		{
			if (defaultCellStyle != value)
			{
				defaultCellStyle = value;
				OnDefaultCellStyleChanged(EventArgs.Empty);
			}
		}
	}

	public override Rectangle DisplayRectangle => base.DisplayRectangle;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public Control EditingControl => editingControl;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	public Panel EditingPanel
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	[DefaultValue(DataGridViewEditMode.EditOnKeystrokeOrF2)]
	public DataGridViewEditMode EditMode
	{
		get
		{
			return editMode;
		}
		set
		{
			if (editMode != value)
			{
				editMode = value;
				OnEditModeChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(true)]
	public bool EnableHeadersVisualStyles
	{
		get
		{
			return enableHeadersVisualStyles;
		}
		set
		{
			enableHeadersVisualStyles = value;
		}
	}

	internal DataGridViewHeaderCell EnteredHeaderCell
	{
		get
		{
			return entered_header_cell;
		}
		set
		{
			if (entered_header_cell == value)
			{
				return;
			}
			if (ThemeEngine.Current.DataGridViewHeaderCellHasHotStyle(this))
			{
				Region region = new Region();
				region.MakeEmpty();
				if (entered_header_cell != null)
				{
					region.Union(GetHeaderCellBounds(entered_header_cell));
				}
				entered_header_cell = value;
				if (entered_header_cell != null)
				{
					region.Union(GetHeaderCellBounds(entered_header_cell));
				}
				Invalidate(region);
				region.Dispose();
			}
			else
			{
				entered_header_cell = value;
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DataGridViewCell FirstDisplayedCell
	{
		get
		{
			return firstDisplayedCell;
		}
		set
		{
			if (value.DataGridView != this)
			{
				throw new ArgumentException("The cell is not in this DataGridView.");
			}
			firstDisplayedCell = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int FirstDisplayedScrollingColumnHiddenWidth => firstDisplayedScrollingColumnHiddenWidth;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int FirstDisplayedScrollingColumnIndex
	{
		get
		{
			return firstDisplayedScrollingColumnIndex;
		}
		set
		{
			firstDisplayedScrollingColumnIndex = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int FirstDisplayedScrollingRowIndex
	{
		get
		{
			return firstDisplayedScrollingRowIndex;
		}
		set
		{
			firstDisplayedScrollingRowIndex = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	public override Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			base.Font = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public override Color ForeColor
	{
		get
		{
			return base.ForeColor;
		}
		set
		{
			base.ForeColor = value;
		}
	}

	public Color GridColor
	{
		get
		{
			return gridColor;
		}
		set
		{
			if (gridColor != value)
			{
				if (value == Color.Empty)
				{
					throw new ArgumentException("Cant set an Empty color.");
				}
				gridColor = value;
				OnGridColorChanged(EventArgs.Empty);
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int HorizontalScrollingOffset
	{
		get
		{
			return horizontalScrollingOffset;
		}
		set
		{
			horizontalScrollingOffset = value;
		}
	}

	[Browsable(false)]
	public bool IsCurrentCellDirty => isCurrentCellDirty;

	[Browsable(false)]
	public bool IsCurrentCellInEditMode
	{
		get
		{
			if (currentCell == null)
			{
				return false;
			}
			return currentCell.IsInEditMode;
		}
	}

	[Browsable(false)]
	public bool IsCurrentRowDirty
	{
		get
		{
			if (!virtualMode)
			{
				return IsCurrentCellDirty;
			}
			QuestionEventArgs e = new QuestionEventArgs();
			OnRowDirtyStateNeeded(e);
			return e.Response;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DataGridViewCell this[int columnIndex, int rowIndex]
	{
		get
		{
			return rows[rowIndex].Cells[columnIndex];
		}
		set
		{
			rows[rowIndex].Cells[columnIndex] = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DataGridViewCell this[string columnName, int rowIndex]
	{
		get
		{
			int columnIndex = -1;
			foreach (DataGridViewColumn column in columns)
			{
				if (column.Name == columnName)
				{
					columnIndex = column.Index;
					break;
				}
			}
			return this[columnIndex, rowIndex];
		}
		set
		{
			int columnIndex = -1;
			foreach (DataGridViewColumn column in columns)
			{
				if (column.Name == columnName)
				{
					columnIndex = column.Index;
					break;
				}
			}
			this[columnIndex, rowIndex] = value;
		}
	}

	[DefaultValue(true)]
	public bool MultiSelect
	{
		get
		{
			return multiSelect;
		}
		set
		{
			if (multiSelect != value)
			{
				multiSelect = value;
				OnMultiSelectChanged(EventArgs.Empty);
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int NewRowIndex
	{
		get
		{
			if (!AllowUserToAddRows || ColumnCount == 0)
			{
				return -1;
			}
			return rows.Count - 1;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Padding Padding
	{
		get
		{
			return Padding.Empty;
		}
		set
		{
		}
	}

	internal DataGridViewHeaderCell PressedHeaderCell => pressed_header_cell;

	[Browsable(true)]
	[DefaultValue(false)]
	public bool ReadOnly
	{
		get
		{
			return readOnly;
		}
		set
		{
			if (readOnly != value)
			{
				readOnly = value;
				OnReadOnlyChanged(EventArgs.Empty);
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DefaultValue(0)]
	public int RowCount
	{
		get
		{
			return rows.Count;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentException("RowCount must be >= 0.");
			}
			if (value < 1 && AllowUserToAddRows)
			{
				throw new ArgumentException("RowCount must be >= 1 if AllowUserToAddRows is true.");
			}
			if (dataSource != null)
			{
				throw new InvalidOperationException("Cant change row count if DataSource is set.");
			}
			if (value < rows.Count)
			{
				int num = rows.Count - 1;
				if (AllowUserToAddRows)
				{
					num--;
				}
				int num2 = value - 1;
				if (AllowUserToAddRows)
				{
					num2--;
				}
				for (int num3 = num; num3 > num2; num3--)
				{
					rows.RemoveAt(num3);
				}
			}
			else
			{
				if (value <= rows.Count)
				{
					return;
				}
				if (ColumnCount == 0)
				{
					ColumnCount = 1;
					if (VirtualMode)
					{
						UpdateRowHeightInfo(0, updateToEnd: false);
					}
				}
				List<DataGridViewRow> list = new List<DataGridViewRow>(value - rows.Count);
				for (int i = rows.Count; i < value; i++)
				{
					list.Add(RowTemplateFull);
				}
				rows.AddRange(list.ToArray());
			}
		}
	}

	[Browsable(true)]
	[DefaultValue(DataGridViewHeaderBorderStyle.Raised)]
	public DataGridViewHeaderBorderStyle RowHeadersBorderStyle
	{
		get
		{
			return rowHeadersBorderStyle;
		}
		set
		{
			if (rowHeadersBorderStyle != value)
			{
				rowHeadersBorderStyle = value;
				OnRowHeadersBorderStyleChanged(EventArgs.Empty);
			}
		}
	}

	[AmbientValue(null)]
	public DataGridViewCellStyle RowHeadersDefaultCellStyle
	{
		get
		{
			return rowHeadersDefaultCellStyle;
		}
		set
		{
			if (rowHeadersDefaultCellStyle != value)
			{
				rowHeadersDefaultCellStyle = value;
				OnRowHeadersDefaultCellStyleChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(true)]
	public bool RowHeadersVisible
	{
		get
		{
			return rowHeadersVisible;
		}
		set
		{
			if (rowHeadersVisible != value)
			{
				rowHeadersVisible = value;
				Invalidate();
			}
		}
	}

	[Localizable(true)]
	public int RowHeadersWidth
	{
		get
		{
			return rowHeadersWidth;
		}
		set
		{
			if (rowHeadersWidth != value)
			{
				if (value < 4)
				{
					throw new ArgumentOutOfRangeException("RowHeadersWidth", "Row headers width cant be less than 4.");
				}
				if (value > 32768)
				{
					throw new ArgumentOutOfRangeException("RowHeadersWidth", "Row headers width cannot be more than 32768.");
				}
				rowHeadersWidth = value;
				OnRowHeadersWidthChanged(EventArgs.Empty);
				if (rowHeadersVisible)
				{
					Invalidate();
				}
			}
		}
	}

	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(DataGridViewRowHeadersWidthSizeMode.EnableResizing)]
	public DataGridViewRowHeadersWidthSizeMode RowHeadersWidthSizeMode
	{
		get
		{
			return rowHeadersWidthSizeMode;
		}
		set
		{
			if (rowHeadersWidthSizeMode != value)
			{
				if (!Enum.IsDefined(typeof(DataGridViewRowHeadersWidthSizeMode), value))
				{
					throw new InvalidEnumArgumentException("Value is not valid DataGridViewRowHeadersWidthSizeMode.");
				}
				rowHeadersWidthSizeMode = value;
				OnRowHeadersWidthSizeModeChanged(new DataGridViewAutoSizeModeEventArgs(previousModeAutoSized: false));
			}
		}
	}

	[Browsable(false)]
	public DataGridViewRowCollection Rows => rows;

	public DataGridViewCellStyle RowsDefaultCellStyle
	{
		get
		{
			return rowsDefaultCellStyle;
		}
		set
		{
			if (rowsDefaultCellStyle != value)
			{
				rowsDefaultCellStyle = value;
				OnRowsDefaultCellStyleChanged(EventArgs.Empty);
			}
		}
	}

	[Browsable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DataGridViewRow RowTemplate
	{
		get
		{
			if (rowTemplate == null)
			{
				rowTemplate = new DataGridViewRow();
			}
			return rowTemplate;
		}
		set
		{
			rowTemplate = value;
		}
	}

	internal DataGridViewRow RowTemplateFull
	{
		get
		{
			DataGridViewRow dataGridViewRow = (DataGridViewRow)RowTemplate.Clone();
			for (int i = dataGridViewRow.Cells.Count; i < Columns.Count; i++)
			{
				DataGridViewCell cellTemplate = columns[i].CellTemplate;
				if (cellTemplate == null)
				{
					throw new InvalidOperationException("At least one of the DataGridView control's columns has no cell template.");
				}
				dataGridViewRow.Cells.Add((DataGridViewCell)cellTemplate.Clone());
			}
			return dataGridViewRow;
		}
	}

	internal override bool ScaleChildrenInternal => false;

	[Localizable(true)]
	[DefaultValue(ScrollBars.Both)]
	public ScrollBars ScrollBars
	{
		get
		{
			return scrollBars;
		}
		set
		{
			if (!Enum.IsDefined(typeof(ScrollBars), value))
			{
				throw new InvalidEnumArgumentException("Invalid ScrollBars value.");
			}
			scrollBars = value;
			PerformLayout();
			Invalidate();
		}
	}

	[Browsable(false)]
	public DataGridViewSelectedCellCollection SelectedCells
	{
		get
		{
			DataGridViewSelectedCellCollection dataGridViewSelectedCellCollection = new DataGridViewSelectedCellCollection();
			foreach (DataGridViewRow item in (IEnumerable)rows)
			{
				foreach (DataGridViewCell cell in item.Cells)
				{
					if (cell.Selected)
					{
						dataGridViewSelectedCellCollection.InternalAdd(cell);
					}
				}
			}
			return dataGridViewSelectedCellCollection;
		}
	}

	[Browsable(false)]
	public DataGridViewSelectedColumnCollection SelectedColumns
	{
		get
		{
			DataGridViewSelectedColumnCollection dataGridViewSelectedColumnCollection = new DataGridViewSelectedColumnCollection();
			if (selectionMode != DataGridViewSelectionMode.FullColumnSelect && selectionMode != DataGridViewSelectionMode.ColumnHeaderSelect)
			{
				return dataGridViewSelectedColumnCollection;
			}
			dataGridViewSelectedColumnCollection.InternalAddRange(selected_columns);
			return dataGridViewSelectedColumnCollection;
		}
	}

	[Browsable(false)]
	public DataGridViewSelectedRowCollection SelectedRows
	{
		get
		{
			DataGridViewSelectedRowCollection dataGridViewSelectedRowCollection = new DataGridViewSelectedRowCollection(this);
			if (selectionMode != DataGridViewSelectionMode.FullRowSelect && selectionMode != DataGridViewSelectionMode.RowHeaderSelect)
			{
				return dataGridViewSelectedRowCollection;
			}
			dataGridViewSelectedRowCollection.InternalAddRange(selected_rows);
			return dataGridViewSelectedRowCollection;
		}
	}

	[Browsable(true)]
	[DefaultValue(DataGridViewSelectionMode.RowHeaderSelect)]
	public DataGridViewSelectionMode SelectionMode
	{
		get
		{
			return selectionMode;
		}
		set
		{
			if (!Enum.IsDefined(typeof(DataGridViewSelectionMode), value))
			{
				throw new InvalidEnumArgumentException("Value is not valid DataGridViewSelectionMode.");
			}
			if (value == DataGridViewSelectionMode.ColumnHeaderSelect || value == DataGridViewSelectionMode.FullColumnSelect)
			{
				foreach (DataGridViewColumn column in Columns)
				{
					if (column.SortMode == DataGridViewColumnSortMode.Automatic)
					{
						throw new InvalidOperationException($"Cannot set SelectionMode to {value} because there are Automatic sort columns.");
					}
				}
			}
			selectionMode = value;
		}
	}

	[DefaultValue(true)]
	public bool ShowCellErrors
	{
		get
		{
			return showCellErrors;
		}
		set
		{
			showCellErrors = value;
		}
	}

	[DefaultValue(true)]
	public bool ShowCellToolTips
	{
		get
		{
			return showCellToolTips;
		}
		set
		{
			showCellToolTips = value;
		}
	}

	[DefaultValue(true)]
	public bool ShowEditingIcon
	{
		get
		{
			return showEditingIcon;
		}
		set
		{
			showEditingIcon = value;
		}
	}

	[DefaultValue(true)]
	public bool ShowRowErrors
	{
		get
		{
			return showRowErrors;
		}
		set
		{
			showRowErrors = value;
		}
	}

	[Browsable(false)]
	public DataGridViewColumn SortedColumn => sortedColumn;

	[Browsable(false)]
	public SortOrder SortOrder => sortOrder;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(false)]
	public bool StandardTab
	{
		get
		{
			return standardTab;
		}
		set
		{
			standardTab = value;
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DataGridViewHeaderCell TopLeftHeaderCell
	{
		get
		{
			if (topLeftHeaderCell == null)
			{
				topLeftHeaderCell = new DataGridViewTopLeftHeaderCell();
				topLeftHeaderCell.SetDataGridView(this);
			}
			return topLeftHeaderCell;
		}
		set
		{
			if (topLeftHeaderCell != value)
			{
				if (topLeftHeaderCell != null)
				{
					topLeftHeaderCell.SetDataGridView(null);
				}
				topLeftHeaderCell = value;
				if (topLeftHeaderCell != null)
				{
					topLeftHeaderCell.SetDataGridView(this);
				}
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	public Cursor UserSetCursor => userSetCursor;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int VerticalScrollingOffset => verticalScrollingOffset;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[System.MonoTODO("VirtualMode is not supported.")]
	[DefaultValue(false)]
	public bool VirtualMode
	{
		get
		{
			return virtualMode;
		}
		set
		{
			virtualMode = value;
		}
	}

	internal Control EditingControlInternal
	{
		get
		{
			return editingControl;
		}
		set
		{
			if (value == editingControl)
			{
				return;
			}
			if (editingControl != null)
			{
				if (base.Controls is DataGridViewControlCollection dataGridViewControlCollection)
				{
					dataGridViewControlCollection.RemoveInternal(editingControl);
				}
				else
				{
					base.Controls.Remove(editingControl);
				}
				editingControl.Dispose();
			}
			if (value != null)
			{
				value.Visible = false;
				base.Controls.Add(value);
			}
			editingControl = value;
		}
	}

	protected override bool CanEnableIme
	{
		get
		{
			if (CurrentCell != null && CurrentCell.EditType != null)
			{
				return true;
			}
			return false;
		}
	}

	protected override Size DefaultSize => new Size(240, 150);

	protected ScrollBar HorizontalScrollBar => horizontalScrollBar;

	protected ScrollBar VerticalScrollBar => verticalScrollBar;

	internal DataGridViewRow EditingRow => editing_row;

	private Timer ToolTipTimer
	{
		get
		{
			if (tooltip_timer == null)
			{
				tooltip_timer = new Timer();
				tooltip_timer.Enabled = false;
				tooltip_timer.Interval = 500;
				tooltip_timer.Tick += ToolTipTimer_Tick;
			}
			return tooltip_timer;
		}
	}

	private ToolTip ToolTipWindow
	{
		get
		{
			if (tooltip_window == null)
			{
				tooltip_window = new ToolTip(this);
			}
			return tooltip_window;
		}
	}

	public event EventHandler AllowUserToAddRowsChanged
	{
		add
		{
			base.Events.AddHandler(AllowUserToAddRowsChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(AllowUserToAddRowsChangedEvent, value);
		}
	}

	public event EventHandler AllowUserToDeleteRowsChanged
	{
		add
		{
			base.Events.AddHandler(AllowUserToDeleteRowsChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(AllowUserToDeleteRowsChangedEvent, value);
		}
	}

	public event EventHandler AllowUserToOrderColumnsChanged
	{
		add
		{
			base.Events.AddHandler(AllowUserToOrderColumnsChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(AllowUserToOrderColumnsChangedEvent, value);
		}
	}

	public event EventHandler AllowUserToResizeColumnsChanged
	{
		add
		{
			base.Events.AddHandler(AllowUserToResizeColumnsChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(AllowUserToResizeColumnsChangedEvent, value);
		}
	}

	public event EventHandler AllowUserToResizeRowsChanged
	{
		add
		{
			base.Events.AddHandler(AllowUserToResizeRowsChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(AllowUserToResizeRowsChangedEvent, value);
		}
	}

	public event EventHandler AlternatingRowsDefaultCellStyleChanged
	{
		add
		{
			base.Events.AddHandler(AlternatingRowsDefaultCellStyleChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(AlternatingRowsDefaultCellStyleChangedEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	public event EventHandler AutoGenerateColumnsChanged
	{
		add
		{
			base.Events.AddHandler(AutoGenerateColumnsChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(AutoGenerateColumnsChangedEvent, value);
		}
	}

	public event DataGridViewAutoSizeColumnModeEventHandler AutoSizeColumnModeChanged
	{
		add
		{
			base.Events.AddHandler(AutoSizeColumnModeChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(AutoSizeColumnModeChangedEvent, value);
		}
	}

	public event DataGridViewAutoSizeColumnsModeEventHandler AutoSizeColumnsModeChanged
	{
		add
		{
			base.Events.AddHandler(AutoSizeColumnsModeChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(AutoSizeColumnsModeChangedEvent, value);
		}
	}

	public event DataGridViewAutoSizeModeEventHandler AutoSizeRowsModeChanged
	{
		add
		{
			base.Events.AddHandler(AutoSizeRowsModeChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(AutoSizeRowsModeChangedEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public new event EventHandler BackColorChanged
	{
		add
		{
			base.BackColorChanged += value;
		}
		remove
		{
			base.BackColorChanged -= value;
		}
	}

	public event EventHandler BackgroundColorChanged
	{
		add
		{
			base.Events.AddHandler(BackgroundColorChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(BackgroundColorChangedEvent, value);
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler BackgroundImageChanged
	{
		add
		{
			base.BackgroundImageChanged += value;
		}
		remove
		{
			base.BackgroundImageChanged -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler BackgroundImageLayoutChanged
	{
		add
		{
			base.BackgroundImageLayoutChanged += value;
		}
		remove
		{
			base.BackgroundImageLayoutChanged -= value;
		}
	}

	public event EventHandler BorderStyleChanged
	{
		add
		{
			base.Events.AddHandler(BorderStyleChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(BorderStyleChangedEvent, value);
		}
	}

	public event QuestionEventHandler CancelRowEdit
	{
		add
		{
			base.Events.AddHandler(CancelRowEditEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CancelRowEditEvent, value);
		}
	}

	public event DataGridViewCellCancelEventHandler CellBeginEdit
	{
		add
		{
			base.Events.AddHandler(CellBeginEditEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellBeginEditEvent, value);
		}
	}

	public event EventHandler CellBorderStyleChanged
	{
		add
		{
			base.Events.AddHandler(CellBorderStyleChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellBorderStyleChangedEvent, value);
		}
	}

	public event DataGridViewCellEventHandler CellClick
	{
		add
		{
			base.Events.AddHandler(CellClickEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellClickEvent, value);
		}
	}

	public event DataGridViewCellEventHandler CellContentClick
	{
		add
		{
			base.Events.AddHandler(CellContentClickEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellContentClickEvent, value);
		}
	}

	public event DataGridViewCellEventHandler CellContentDoubleClick
	{
		add
		{
			base.Events.AddHandler(CellContentDoubleClickEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellContentDoubleClickEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public event DataGridViewCellEventHandler CellContextMenuStripChanged
	{
		add
		{
			base.Events.AddHandler(CellContextMenuStripChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellContextMenuStripChangedEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public event DataGridViewCellContextMenuStripNeededEventHandler CellContextMenuStripNeeded
	{
		add
		{
			base.Events.AddHandler(CellContextMenuStripNeededEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellContextMenuStripNeededEvent, value);
		}
	}

	public event DataGridViewCellEventHandler CellDoubleClick
	{
		add
		{
			base.Events.AddHandler(CellDoubleClickEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellDoubleClickEvent, value);
		}
	}

	public event DataGridViewCellEventHandler CellEndEdit
	{
		add
		{
			base.Events.AddHandler(CellEndEditEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellEndEditEvent, value);
		}
	}

	public event DataGridViewCellEventHandler CellEnter
	{
		add
		{
			base.Events.AddHandler(CellEnterEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellEnterEvent, value);
		}
	}

	public event DataGridViewCellEventHandler CellErrorTextChanged
	{
		add
		{
			base.Events.AddHandler(CellErrorTextChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellErrorTextChangedEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public event DataGridViewCellErrorTextNeededEventHandler CellErrorTextNeeded
	{
		add
		{
			base.Events.AddHandler(CellErrorTextNeededEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellErrorTextNeededEvent, value);
		}
	}

	public event DataGridViewCellFormattingEventHandler CellFormatting
	{
		add
		{
			base.Events.AddHandler(CellFormattingEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellFormattingEvent, value);
		}
	}

	public event DataGridViewCellEventHandler CellLeave
	{
		add
		{
			base.Events.AddHandler(CellLeaveEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellLeaveEvent, value);
		}
	}

	public event DataGridViewCellMouseEventHandler CellMouseClick
	{
		add
		{
			base.Events.AddHandler(CellMouseClickEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellMouseClickEvent, value);
		}
	}

	public event DataGridViewCellMouseEventHandler CellMouseDoubleClick
	{
		add
		{
			base.Events.AddHandler(CellMouseDoubleClickEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellMouseDoubleClickEvent, value);
		}
	}

	public event DataGridViewCellMouseEventHandler CellMouseDown
	{
		add
		{
			base.Events.AddHandler(CellMouseDownEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellMouseDownEvent, value);
		}
	}

	public event DataGridViewCellEventHandler CellMouseEnter
	{
		add
		{
			base.Events.AddHandler(CellMouseEnterEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellMouseEnterEvent, value);
		}
	}

	public event DataGridViewCellEventHandler CellMouseLeave
	{
		add
		{
			base.Events.AddHandler(CellMouseLeaveEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellMouseLeaveEvent, value);
		}
	}

	public event DataGridViewCellMouseEventHandler CellMouseMove
	{
		add
		{
			base.Events.AddHandler(CellMouseMoveEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellMouseMoveEvent, value);
		}
	}

	public event DataGridViewCellMouseEventHandler CellMouseUp
	{
		add
		{
			base.Events.AddHandler(CellMouseUpEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellMouseUpEvent, value);
		}
	}

	public event DataGridViewCellPaintingEventHandler CellPainting
	{
		add
		{
			base.Events.AddHandler(CellPaintingEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellPaintingEvent, value);
		}
	}

	public event DataGridViewCellParsingEventHandler CellParsing
	{
		add
		{
			base.Events.AddHandler(CellParsingEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellParsingEvent, value);
		}
	}

	public event DataGridViewCellStateChangedEventHandler CellStateChanged
	{
		add
		{
			base.Events.AddHandler(CellStateChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellStateChangedEvent, value);
		}
	}

	public event DataGridViewCellEventHandler CellStyleChanged
	{
		add
		{
			base.Events.AddHandler(CellStyleChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellStyleChangedEvent, value);
		}
	}

	public event DataGridViewCellStyleContentChangedEventHandler CellStyleContentChanged
	{
		add
		{
			base.Events.AddHandler(CellStyleContentChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellStyleContentChangedEvent, value);
		}
	}

	public event DataGridViewCellEventHandler CellToolTipTextChanged
	{
		add
		{
			base.Events.AddHandler(CellToolTipTextChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellToolTipTextChangedEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public event DataGridViewCellToolTipTextNeededEventHandler CellToolTipTextNeeded
	{
		add
		{
			base.Events.AddHandler(CellToolTipTextNeededEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellToolTipTextNeededEvent, value);
		}
	}

	public event DataGridViewCellEventHandler CellValidated
	{
		add
		{
			base.Events.AddHandler(CellValidatedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellValidatedEvent, value);
		}
	}

	public event DataGridViewCellValidatingEventHandler CellValidating
	{
		add
		{
			base.Events.AddHandler(CellValidatingEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellValidatingEvent, value);
		}
	}

	public event DataGridViewCellEventHandler CellValueChanged
	{
		add
		{
			base.Events.AddHandler(CellValueChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellValueChangedEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public event DataGridViewCellValueEventHandler CellValueNeeded
	{
		add
		{
			base.Events.AddHandler(CellValueNeededEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellValueNeededEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public event DataGridViewCellValueEventHandler CellValuePushed
	{
		add
		{
			base.Events.AddHandler(CellValuePushedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellValuePushedEvent, value);
		}
	}

	public event DataGridViewColumnEventHandler ColumnAdded
	{
		add
		{
			base.Events.AddHandler(ColumnAddedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnAddedEvent, value);
		}
	}

	public event DataGridViewColumnEventHandler ColumnContextMenuStripChanged
	{
		add
		{
			base.Events.AddHandler(ColumnContextMenuStripChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnContextMenuStripChangedEvent, value);
		}
	}

	public event DataGridViewColumnEventHandler ColumnDataPropertyNameChanged
	{
		add
		{
			base.Events.AddHandler(ColumnDataPropertyNameChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnDataPropertyNameChangedEvent, value);
		}
	}

	public event DataGridViewColumnEventHandler ColumnDefaultCellStyleChanged
	{
		add
		{
			base.Events.AddHandler(ColumnDefaultCellStyleChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnDefaultCellStyleChangedEvent, value);
		}
	}

	public event DataGridViewColumnEventHandler ColumnDisplayIndexChanged
	{
		add
		{
			base.Events.AddHandler(ColumnDisplayIndexChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnDisplayIndexChangedEvent, value);
		}
	}

	public event DataGridViewColumnDividerDoubleClickEventHandler ColumnDividerDoubleClick
	{
		add
		{
			base.Events.AddHandler(ColumnDividerDoubleClickEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnDividerDoubleClickEvent, value);
		}
	}

	public event DataGridViewColumnEventHandler ColumnDividerWidthChanged
	{
		add
		{
			base.Events.AddHandler(ColumnDividerWidthChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnDividerWidthChangedEvent, value);
		}
	}

	public event DataGridViewColumnEventHandler ColumnHeaderCellChanged
	{
		add
		{
			base.Events.AddHandler(ColumnHeaderCellChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnHeaderCellChangedEvent, value);
		}
	}

	public event DataGridViewCellMouseEventHandler ColumnHeaderMouseClick
	{
		add
		{
			base.Events.AddHandler(ColumnHeaderMouseClickEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnHeaderMouseClickEvent, value);
		}
	}

	public event DataGridViewCellMouseEventHandler ColumnHeaderMouseDoubleClick
	{
		add
		{
			base.Events.AddHandler(ColumnHeaderMouseDoubleClickEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnHeaderMouseDoubleClickEvent, value);
		}
	}

	public event EventHandler ColumnHeadersBorderStyleChanged
	{
		add
		{
			base.Events.AddHandler(ColumnHeadersBorderStyleChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnHeadersBorderStyleChangedEvent, value);
		}
	}

	public event EventHandler ColumnHeadersDefaultCellStyleChanged
	{
		add
		{
			base.Events.AddHandler(ColumnHeadersDefaultCellStyleChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnHeadersDefaultCellStyleChangedEvent, value);
		}
	}

	public event EventHandler ColumnHeadersHeightChanged
	{
		add
		{
			base.Events.AddHandler(ColumnHeadersHeightChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnHeadersHeightChangedEvent, value);
		}
	}

	public event DataGridViewAutoSizeModeEventHandler ColumnHeadersHeightSizeModeChanged
	{
		add
		{
			base.Events.AddHandler(ColumnHeadersHeightSizeModeChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnHeadersHeightSizeModeChangedEvent, value);
		}
	}

	public event DataGridViewColumnEventHandler ColumnMinimumWidthChanged
	{
		add
		{
			base.Events.AddHandler(ColumnMinimumWidthChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnMinimumWidthChangedEvent, value);
		}
	}

	public event DataGridViewColumnEventHandler ColumnNameChanged
	{
		add
		{
			base.Events.AddHandler(ColumnNameChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnNameChangedEvent, value);
		}
	}

	public event DataGridViewColumnEventHandler ColumnRemoved
	{
		add
		{
			base.Events.AddHandler(ColumnRemovedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnRemovedEvent, value);
		}
	}

	public event DataGridViewColumnEventHandler ColumnSortModeChanged
	{
		add
		{
			base.Events.AddHandler(ColumnSortModeChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnSortModeChangedEvent, value);
		}
	}

	public event DataGridViewColumnStateChangedEventHandler ColumnStateChanged
	{
		add
		{
			base.Events.AddHandler(ColumnStateChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnStateChangedEvent, value);
		}
	}

	public event DataGridViewColumnEventHandler ColumnToolTipTextChanged
	{
		add
		{
			base.Events.AddHandler(ColumnToolTipTextChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnToolTipTextChangedEvent, value);
		}
	}

	public event DataGridViewColumnEventHandler ColumnWidthChanged
	{
		add
		{
			base.Events.AddHandler(ColumnWidthChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ColumnWidthChangedEvent, value);
		}
	}

	public event EventHandler CurrentCellChanged
	{
		add
		{
			base.Events.AddHandler(CurrentCellChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CurrentCellChangedEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public event EventHandler CurrentCellDirtyStateChanged
	{
		add
		{
			base.Events.AddHandler(CurrentCellDirtyStateChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CurrentCellDirtyStateChangedEvent, value);
		}
	}

	public event DataGridViewBindingCompleteEventHandler DataBindingComplete
	{
		add
		{
			base.Events.AddHandler(DataBindingCompleteEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(DataBindingCompleteEvent, value);
		}
	}

	public event DataGridViewDataErrorEventHandler DataError
	{
		add
		{
			base.Events.AddHandler(DataErrorEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(DataErrorEvent, value);
		}
	}

	public event EventHandler DataMemberChanged
	{
		add
		{
			base.Events.AddHandler(DataMemberChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(DataMemberChangedEvent, value);
		}
	}

	public event EventHandler DataSourceChanged
	{
		add
		{
			base.Events.AddHandler(DataSourceChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(DataSourceChangedEvent, value);
		}
	}

	public event EventHandler DefaultCellStyleChanged
	{
		add
		{
			base.Events.AddHandler(DefaultCellStyleChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(DefaultCellStyleChangedEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public event DataGridViewRowEventHandler DefaultValuesNeeded
	{
		add
		{
			base.Events.AddHandler(DefaultValuesNeededEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(DefaultValuesNeededEvent, value);
		}
	}

	public event DataGridViewEditingControlShowingEventHandler EditingControlShowing
	{
		add
		{
			base.Events.AddHandler(EditingControlShowingEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(EditingControlShowingEvent, value);
		}
	}

	public event EventHandler EditModeChanged
	{
		add
		{
			base.Events.AddHandler(EditModeChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(EditModeChangedEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	public new event EventHandler FontChanged
	{
		add
		{
			base.FontChanged += value;
		}
		remove
		{
			base.FontChanged -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public new event EventHandler ForeColorChanged
	{
		add
		{
			base.ForeColorChanged += value;
		}
		remove
		{
			base.ForeColorChanged -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new event EventHandler PaddingChanged
	{
		add
		{
			base.PaddingChanged += value;
		}
		remove
		{
			base.PaddingChanged -= value;
		}
	}

	public event EventHandler GridColorChanged
	{
		add
		{
			base.Events.AddHandler(GridColorChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(GridColorChangedEvent, value);
		}
	}

	public event EventHandler MultiSelectChanged
	{
		add
		{
			base.Events.AddHandler(MultiSelectChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(MultiSelectChangedEvent, value);
		}
	}

	public event DataGridViewRowEventHandler NewRowNeeded
	{
		add
		{
			base.Events.AddHandler(NewRowNeededEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(NewRowNeededEvent, value);
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

	public event DataGridViewRowEventHandler RowContextMenuStripChanged
	{
		add
		{
			base.Events.AddHandler(RowContextMenuStripChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowContextMenuStripChangedEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public event DataGridViewRowContextMenuStripNeededEventHandler RowContextMenuStripNeeded
	{
		add
		{
			base.Events.AddHandler(RowContextMenuStripNeededEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowContextMenuStripNeededEvent, value);
		}
	}

	public event DataGridViewRowEventHandler RowDefaultCellStyleChanged
	{
		add
		{
			base.Events.AddHandler(RowDefaultCellStyleChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowDefaultCellStyleChangedEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public event QuestionEventHandler RowDirtyStateNeeded
	{
		add
		{
			base.Events.AddHandler(RowDirtyStateNeededEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowDirtyStateNeededEvent, value);
		}
	}

	public event DataGridViewRowDividerDoubleClickEventHandler RowDividerDoubleClick
	{
		add
		{
			base.Events.AddHandler(RowDividerDoubleClickEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowDividerDoubleClickEvent, value);
		}
	}

	public event DataGridViewRowEventHandler RowDividerHeightChanged
	{
		add
		{
			base.Events.AddHandler(RowDividerHeightChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowDividerHeightChangedEvent, value);
		}
	}

	public event DataGridViewCellEventHandler RowEnter
	{
		add
		{
			base.Events.AddHandler(RowEnterEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowEnterEvent, value);
		}
	}

	public event DataGridViewRowEventHandler RowErrorTextChanged
	{
		add
		{
			base.Events.AddHandler(RowErrorTextChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowErrorTextChangedEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public event DataGridViewRowErrorTextNeededEventHandler RowErrorTextNeeded
	{
		add
		{
			base.Events.AddHandler(RowErrorTextNeededEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowErrorTextNeededEvent, value);
		}
	}

	public event DataGridViewRowEventHandler RowHeaderCellChanged
	{
		add
		{
			base.Events.AddHandler(RowHeaderCellChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowHeaderCellChangedEvent, value);
		}
	}

	public event DataGridViewCellMouseEventHandler RowHeaderMouseClick
	{
		add
		{
			base.Events.AddHandler(RowHeaderMouseClickEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowHeaderMouseClickEvent, value);
		}
	}

	public event DataGridViewCellMouseEventHandler RowHeaderMouseDoubleClick
	{
		add
		{
			base.Events.AddHandler(RowHeaderMouseDoubleClickEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowHeaderMouseDoubleClickEvent, value);
		}
	}

	public event EventHandler RowHeadersBorderStyleChanged
	{
		add
		{
			base.Events.AddHandler(RowHeadersBorderStyleChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowHeadersBorderStyleChangedEvent, value);
		}
	}

	public event EventHandler RowHeadersDefaultCellStyleChanged
	{
		add
		{
			base.Events.AddHandler(RowHeadersDefaultCellStyleChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowHeadersDefaultCellStyleChangedEvent, value);
		}
	}

	public event EventHandler RowHeadersWidthChanged
	{
		add
		{
			base.Events.AddHandler(RowHeadersWidthChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowHeadersWidthChangedEvent, value);
		}
	}

	public event DataGridViewAutoSizeModeEventHandler RowHeadersWidthSizeModeChanged
	{
		add
		{
			base.Events.AddHandler(RowHeadersWidthSizeModeChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowHeadersWidthSizeModeChangedEvent, value);
		}
	}

	public event DataGridViewRowEventHandler RowHeightChanged
	{
		add
		{
			base.Events.AddHandler(RowHeightChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowHeightChangedEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public event DataGridViewRowHeightInfoNeededEventHandler RowHeightInfoNeeded
	{
		add
		{
			base.Events.AddHandler(RowHeightInfoNeededEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowHeightInfoNeededEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public event DataGridViewRowHeightInfoPushedEventHandler RowHeightInfoPushed
	{
		add
		{
			base.Events.AddHandler(RowHeightInfoPushedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowHeightInfoPushedEvent, value);
		}
	}

	public event DataGridViewCellEventHandler RowLeave
	{
		add
		{
			base.Events.AddHandler(RowLeaveEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowLeaveEvent, value);
		}
	}

	public event DataGridViewRowEventHandler RowMinimumHeightChanged
	{
		add
		{
			base.Events.AddHandler(RowMinimumHeightChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowMinimumHeightChangedEvent, value);
		}
	}

	public event DataGridViewRowPostPaintEventHandler RowPostPaint
	{
		add
		{
			base.Events.AddHandler(RowPostPaintEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowPostPaintEvent, value);
		}
	}

	public event DataGridViewRowPrePaintEventHandler RowPrePaint
	{
		add
		{
			base.Events.AddHandler(RowPrePaintEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowPrePaintEvent, value);
		}
	}

	public event DataGridViewRowsAddedEventHandler RowsAdded
	{
		add
		{
			base.Events.AddHandler(RowsAddedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowsAddedEvent, value);
		}
	}

	public event EventHandler RowsDefaultCellStyleChanged
	{
		add
		{
			base.Events.AddHandler(RowsDefaultCellStyleChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowsDefaultCellStyleChangedEvent, value);
		}
	}

	public event DataGridViewRowsRemovedEventHandler RowsRemoved
	{
		add
		{
			base.Events.AddHandler(RowsRemovedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowsRemovedEvent, value);
		}
	}

	public event DataGridViewRowStateChangedEventHandler RowStateChanged
	{
		add
		{
			base.Events.AddHandler(RowStateChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowStateChangedEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public event DataGridViewRowEventHandler RowUnshared
	{
		add
		{
			base.Events.AddHandler(RowUnsharedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowUnsharedEvent, value);
		}
	}

	public event DataGridViewCellEventHandler RowValidated
	{
		add
		{
			base.Events.AddHandler(RowValidatedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowValidatedEvent, value);
		}
	}

	public event DataGridViewCellCancelEventHandler RowValidating
	{
		add
		{
			base.Events.AddHandler(RowValidatingEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RowValidatingEvent, value);
		}
	}

	public event ScrollEventHandler Scroll
	{
		add
		{
			base.Events.AddHandler(ScrollEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ScrollEvent, value);
		}
	}

	public event EventHandler SelectionChanged
	{
		add
		{
			base.Events.AddHandler(SelectionChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(SelectionChangedEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public event DataGridViewSortCompareEventHandler SortCompare
	{
		add
		{
			base.Events.AddHandler(SortCompareEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(SortCompareEvent, value);
		}
	}

	public event EventHandler Sorted
	{
		add
		{
			base.Events.AddHandler(SortedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(SortedEvent, value);
		}
	}

	public event DataGridViewRowEventHandler UserAddedRow
	{
		add
		{
			base.Events.AddHandler(UserAddedRowEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(UserAddedRowEvent, value);
		}
	}

	public event DataGridViewRowEventHandler UserDeletedRow
	{
		add
		{
			base.Events.AddHandler(UserDeletedRowEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(UserDeletedRowEvent, value);
		}
	}

	public event DataGridViewRowCancelEventHandler UserDeletingRow
	{
		add
		{
			base.Events.AddHandler(UserDeletingRowEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(UserDeletingRowEvent, value);
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler StyleChanged
	{
		add
		{
			base.StyleChanged += value;
		}
		remove
		{
			base.StyleChanged -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler TextChanged
	{
		add
		{
			base.TextChanged += value;
		}
		remove
		{
			base.TextChanged -= value;
		}
	}

	public DataGridView()
	{
		SetStyle(ControlStyles.Opaque, value: true);
		SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
		adjustedTopLeftHeaderBorderStyle = new DataGridViewAdvancedBorderStyle();
		adjustedTopLeftHeaderBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
		advancedCellBorderStyle = new DataGridViewAdvancedBorderStyle();
		advancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
		advancedColumnHeadersBorderStyle = new DataGridViewAdvancedBorderStyle();
		advancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
		advancedRowHeadersBorderStyle = new DataGridViewAdvancedBorderStyle();
		advancedRowHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
		alternatingRowsDefaultCellStyle = new DataGridViewCellStyle();
		allowUserToAddRows = true;
		allowUserToDeleteRows = true;
		allowUserToOrderColumns = false;
		allowUserToResizeColumns = true;
		allowUserToResizeRows = true;
		autoGenerateColumns = true;
		autoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
		autoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
		backColor = Control.DefaultBackColor;
		backgroundColor = SystemColors.AppWorkspace;
		borderStyle = BorderStyle.FixedSingle;
		cellBorderStyle = DataGridViewCellBorderStyle.Single;
		clipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
		columnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		columnHeadersDefaultCellStyle = new DataGridViewCellStyle();
		columnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
		columnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;
		columnHeadersDefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
		columnHeadersDefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
		columnHeadersDefaultCellStyle.Font = Font;
		columnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		columnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
		columnHeadersHeight = 23;
		columnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
		columnHeadersVisible = true;
		columns = CreateColumnsInstance();
		columns.CollectionChanged += OnColumnCollectionChanged;
		currentCellAddress = new Point(-1, -1);
		dataMember = string.Empty;
		defaultCellStyle = new DataGridViewCellStyle();
		defaultCellStyle.BackColor = SystemColors.Window;
		defaultCellStyle.ForeColor = SystemColors.WindowText;
		defaultCellStyle.SelectionBackColor = SystemColors.Highlight;
		defaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
		defaultCellStyle.Font = Font;
		defaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		defaultCellStyle.WrapMode = DataGridViewTriState.False;
		editMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
		firstDisplayedScrollingColumnHiddenWidth = 0;
		isCurrentCellDirty = false;
		multiSelect = true;
		readOnly = false;
		rowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		rowHeadersDefaultCellStyle = columnHeadersDefaultCellStyle.Clone();
		rowHeadersVisible = true;
		rowHeadersWidth = 41;
		rowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
		rows = CreateRowsInstance();
		rowsDefaultCellStyle = new DataGridViewCellStyle();
		selectionMode = DataGridViewSelectionMode.RowHeaderSelect;
		showCellErrors = true;
		showEditingIcon = true;
		scrollBars = ScrollBars.Both;
		userSetCursor = Cursor.Current;
		virtualMode = false;
		horizontalScrollBar = new HScrollBar();
		horizontalScrollBar.Scroll += OnHScrollBarScroll;
		horizontalScrollBar.Visible = false;
		verticalScrollBar = new VScrollBar();
		verticalScrollBar.Scroll += OnVScrollBarScroll;
		verticalScrollBar.Visible = false;
		base.Controls.AddRange(new Control[2] { horizontalScrollBar, verticalScrollBar });
	}

	void ISupportInitialize.BeginInit()
	{
	}

	void ISupportInitialize.EndInit()
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public virtual DataGridViewAdvancedBorderStyle AdjustColumnHeaderBorderStyle(DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStyleInput, DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStylePlaceholder, bool isFirstDisplayedColumn, bool isLastVisibleColumn)
	{
		return (DataGridViewAdvancedBorderStyle)((ICloneable)dataGridViewAdvancedBorderStyleInput).Clone();
	}

	public bool AreAllCellsSelected(bool includeInvisibleCells)
	{
		foreach (DataGridViewRow item in (IEnumerable)rows)
		{
			foreach (DataGridViewCell cell in item.Cells)
			{
				if ((includeInvisibleCells || cell.Visible) && !cell.Selected)
				{
					return false;
				}
			}
		}
		return true;
	}

	public void AutoResizeColumn(int columnIndex)
	{
		AutoResizeColumn(columnIndex, DataGridViewAutoSizeColumnMode.AllCells);
	}

	public void AutoResizeColumn(int columnIndex, DataGridViewAutoSizeColumnMode autoSizeColumnMode)
	{
		AutoResizeColumnInternal(columnIndex, autoSizeColumnMode);
	}

	public void AutoResizeColumnHeadersHeight()
	{
		int num = 0;
		foreach (DataGridViewColumn column in Columns)
		{
			num = Math.Max(num, column.HeaderCell.PreferredSize.Height);
		}
		if (ColumnHeadersHeight != num)
		{
			ColumnHeadersHeight = num;
		}
	}

	[System.MonoTODO("columnIndex parameter is not used")]
	public void AutoResizeColumnHeadersHeight(int columnIndex)
	{
		AutoResizeColumnHeadersHeight();
	}

	public void AutoResizeColumns()
	{
		AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
	}

	public void AutoResizeColumns(DataGridViewAutoSizeColumnsMode autoSizeColumnsMode)
	{
		AutoResizeColumns(autoSizeColumnsMode, fixedHeight: true);
	}

	public void AutoResizeRow(int rowIndex)
	{
		AutoResizeRow(rowIndex, DataGridViewAutoSizeRowMode.AllCells, fixedWidth: true);
	}

	public void AutoResizeRow(int rowIndex, DataGridViewAutoSizeRowMode autoSizeRowMode)
	{
		AutoResizeRow(rowIndex, autoSizeRowMode, fixedWidth: true);
	}

	public void AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode rowHeadersWidthSizeMode)
	{
		if (rowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader)
		{
			RowHeadersWidth = GetRowInternal(0).HeaderCell.PreferredSize.Width;
			return;
		}
		int num = 0;
		switch (rowHeadersWidthSizeMode)
		{
		case DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders:
		{
			bool flag = false;
			foreach (DataGridViewRow item in (IEnumerable)Rows)
			{
				if (item.Displayed)
				{
					flag = true;
					num = Math.Max(num, item.HeaderCell.PreferredSize.Width);
				}
			}
			if (!flag)
			{
				foreach (DataGridViewRow item2 in (IEnumerable)Rows)
				{
					num = Math.Max(num, item2.HeaderCell.PreferredSize.Width);
				}
			}
			if (RowHeadersWidth != num)
			{
				RowHeadersWidth = num;
			}
			break;
		}
		case DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders:
			foreach (DataGridViewRow item3 in (IEnumerable)Rows)
			{
				num = Math.Max(num, item3.HeaderCell.PreferredSize.Width);
			}
			if (RowHeadersWidth != num)
			{
				RowHeadersWidth = num;
			}
			break;
		}
	}

	[System.MonoTODO("Does not use rowIndex parameter.")]
	public void AutoResizeRowHeadersWidth(int rowIndex, DataGridViewRowHeadersWidthSizeMode rowHeadersWidthSizeMode)
	{
		AutoResizeRowHeadersWidth(rowHeadersWidthSizeMode);
	}

	public void AutoResizeRows()
	{
		AutoResizeRows(0, Rows.Count, DataGridViewAutoSizeRowMode.AllCells, fixedWidth: false);
	}

	public void AutoResizeRows(DataGridViewAutoSizeRowsMode autoSizeRowsMode)
	{
		if (!Enum.IsDefined(typeof(DataGridViewAutoSizeRowsMode), autoSizeRowsMode))
		{
			throw new InvalidEnumArgumentException("Parameter autoSizeRowsMode is not a valid DataGridViewRowsMode.");
		}
		if ((autoSizeRowsMode == DataGridViewAutoSizeRowsMode.AllHeaders || autoSizeRowsMode == DataGridViewAutoSizeRowsMode.DisplayedHeaders) && !rowHeadersVisible)
		{
			throw new InvalidOperationException("Parameter autoSizeRowsMode cannot be AllHeaders or DisplayedHeaders in this DataGridView.");
		}
		if (autoSizeRowsMode == DataGridViewAutoSizeRowsMode.None)
		{
			throw new ArgumentException("Parameter autoSizeRowsMode cannot be None.");
		}
		AutoResizeRows(autoSizeRowsMode, fixedWidth: false);
	}

	public virtual bool BeginEdit(bool selectAll)
	{
		if (currentCell == null || currentCell.IsInEditMode)
		{
			return false;
		}
		if (currentCell.RowIndex >= 0 && (currentCell.InheritedState & DataGridViewElementStates.ReadOnly) == DataGridViewElementStates.ReadOnly)
		{
			return false;
		}
		DataGridViewCell dataGridViewCell = currentCell;
		Type editType = dataGridViewCell.EditType;
		if (editType == null && !(dataGridViewCell is IDataGridViewEditingCell))
		{
			return false;
		}
		DataGridViewCellCancelEventArgs e = new DataGridViewCellCancelEventArgs(dataGridViewCell.ColumnIndex, dataGridViewCell.RowIndex);
		OnCellBeginEdit(e);
		if (e.Cancel)
		{
			return false;
		}
		dataGridViewCell.SetIsInEditMode(isInEditMode: true);
		if (editType != null)
		{
			Control control = EditingControlInternal;
			if (control == null || !(control.GetType() == editType))
			{
				control = null;
			}
			if (control == null)
			{
				control = (Control)Activator.CreateInstance(editType);
				EditingControlInternal = control;
			}
			DataGridViewCellStyle dataGridViewCellStyle = ((dataGridViewCell.RowIndex == -1) ? DefaultCellStyle : dataGridViewCell.InheritedStyle);
			dataGridViewCell.InitializeEditingControl(dataGridViewCell.RowIndex, dataGridViewCell.FormattedValue, dataGridViewCellStyle);
			OnEditingControlShowing(new DataGridViewEditingControlShowingEventArgs(EditingControlInternal, dataGridViewCellStyle));
			dataGridViewCell.PositionEditingControl(setLocation: true, setSize: true, GetCellDisplayRectangle(dataGridViewCell.ColumnIndex, dataGridViewCell.RowIndex, cutOverflow: false), bounds, dataGridViewCellStyle, singleVerticalBorderAdded: false, singleHorizontalBorderAdded: false, columns[dataGridViewCell.ColumnIndex].DisplayIndex == 0, dataGridViewCell.RowIndex == 0);
			if (EditingControlInternal != null)
			{
				EditingControlInternal.Visible = true;
			}
			IDataGridViewEditingControl dataGridViewEditingControl = (IDataGridViewEditingControl)EditingControlInternal;
			if (dataGridViewEditingControl != null)
			{
				dataGridViewEditingControl.EditingControlDataGridView = this;
				dataGridViewEditingControl.EditingControlRowIndex = currentCell.OwningRow.Index;
				dataGridViewEditingControl.ApplyCellStyleToEditingControl(dataGridViewCellStyle);
				dataGridViewEditingControl.PrepareEditingControlForEdit(selectAll);
				dataGridViewEditingControl.EditingControlFormattedValue = currentCell.EditedFormattedValue;
			}
			return true;
		}
		(dataGridViewCell as IDataGridViewEditingCell).PrepareEditingCellForEdit(selectAll);
		return true;
	}

	public bool CancelEdit()
	{
		if (currentCell != null)
		{
			if (currentCell.IsInEditMode)
			{
				currentCell.SetIsInEditMode(isInEditMode: false);
				currentCell.DetachEditingControl();
			}
			if (currentCell.RowIndex == NewRowIndex)
			{
				if (DataManager != null)
				{
					DataManager.CancelCurrentEdit();
				}
				new_row_editing = false;
				PrepareEditingRow(cell_changed: false, column_changed: false);
				MoveCurrentCell(currentCell.ColumnIndex, NewRowIndex, select: true, isControl: false, isShift: false, scroll: true);
				OnUserDeletedRow(new DataGridViewRowEventArgs(EditingRow));
			}
		}
		return true;
	}

	public void ClearSelection()
	{
		foreach (DataGridViewColumn selectedColumn in SelectedColumns)
		{
			selectedColumn.Selected = false;
		}
		foreach (DataGridViewRow selectedRow in SelectedRows)
		{
			selectedRow.Selected = false;
		}
		foreach (DataGridViewCell selectedCell in SelectedCells)
		{
			selectedCell.Selected = false;
		}
	}

	public bool CommitEdit(DataGridViewDataErrorContexts context)
	{
		if (currentCell == null)
		{
			return true;
		}
		try
		{
			object obj = currentCell.ParseFormattedValue(currentCell.EditedFormattedValue, currentCell.InheritedStyle, null, null);
			DataGridViewCellValidatingEventArgs e = new DataGridViewCellValidatingEventArgs(currentCell.ColumnIndex, currentCell.RowIndex, obj);
			OnCellValidating(e);
			if (e.Cancel)
			{
				return false;
			}
			OnCellValidated(new DataGridViewCellEventArgs(currentCell.ColumnIndex, currentCell.RowIndex));
			currentCell.Value = obj;
		}
		catch (Exception ex)
		{
			DataGridViewDataErrorEventArgs e2 = new DataGridViewDataErrorEventArgs(ex, currentCell.ColumnIndex, currentCell.RowIndex, DataGridViewDataErrorContexts.Commit);
			OnDataError(displayErrorDialogIfNoHandler: false, e2);
			if (e2.ThrowException)
			{
				throw ex;
			}
			return false;
		}
		return true;
	}

	public int DisplayedColumnCount(bool includePartialColumns)
	{
		int num = 0;
		int num2 = 0;
		if (RowHeadersVisible)
		{
			num2 += RowHeadersWidth;
		}
		Size clientSize = base.ClientSize;
		if (verticalScrollBar.Visible)
		{
			clientSize.Width -= verticalScrollBar.Width;
		}
		if (horizontalScrollBar.Visible)
		{
			clientSize.Height -= horizontalScrollBar.Height;
		}
		for (int i = first_col_index; i < Columns.Count; i++)
		{
			DataGridViewColumn dataGridViewColumn = Columns[ColumnDisplayIndexToIndex(i)];
			if (num2 + dataGridViewColumn.Width <= clientSize.Width)
			{
				num++;
				num2 += dataGridViewColumn.Width;
				continue;
			}
			if (includePartialColumns)
			{
				num++;
			}
			break;
		}
		return num;
	}

	public int DisplayedRowCount(bool includePartialRow)
	{
		int num = 0;
		int num2 = 0;
		if (ColumnHeadersVisible)
		{
			num2 += ColumnHeadersHeight;
		}
		Size clientSize = base.ClientSize;
		if (verticalScrollBar.Visible)
		{
			clientSize.Width -= verticalScrollBar.Width;
		}
		if (horizontalScrollBar.Visible)
		{
			clientSize.Height -= horizontalScrollBar.Height;
		}
		for (int i = first_row_index; i < Rows.Count; i++)
		{
			DataGridViewRow rowInternal = GetRowInternal(i);
			if (num2 + rowInternal.Height <= clientSize.Height)
			{
				num++;
				num2 += rowInternal.Height;
				continue;
			}
			if (includePartialRow)
			{
				num++;
			}
			break;
		}
		return num;
	}

	public bool EndEdit()
	{
		return EndEdit(DataGridViewDataErrorContexts.Commit);
	}

	[System.MonoTODO("Does not use context parameter")]
	public bool EndEdit(DataGridViewDataErrorContexts context)
	{
		if (currentCell == null || !currentCell.IsInEditMode)
		{
			return true;
		}
		if (!CommitEdit(context))
		{
			if (DataManager != null)
			{
				DataManager.EndCurrentEdit();
			}
			if (EditingControl != null)
			{
				EditingControl.Focus();
			}
			return false;
		}
		currentCell.SetIsInEditMode(isInEditMode: false);
		currentCell.DetachEditingControl();
		OnCellEndEdit(new DataGridViewCellEventArgs(currentCell.ColumnIndex, currentCell.RowIndex));
		if (context != DataGridViewDataErrorContexts.LeaveControl)
		{
			Focus();
		}
		if (currentCell.RowIndex == NewRowIndex)
		{
			new_row_editing = false;
			editing_row = null;
			PrepareEditingRow(cell_changed: true, column_changed: false);
			MoveCurrentCell(currentCell.ColumnIndex, NewRowIndex, select: true, isControl: false, isShift: false, scroll: true);
		}
		return true;
	}

	public int GetCellCount(DataGridViewElementStates includeFilter)
	{
		int num = 0;
		foreach (DataGridViewRow item in (IEnumerable)rows)
		{
			foreach (DataGridViewCell cell in item.Cells)
			{
				if ((cell.State & includeFilter) != DataGridViewElementStates.None)
				{
					num++;
				}
			}
		}
		return num;
	}

	internal DataGridViewRow GetRowInternal(int rowIndex)
	{
		return Rows.SharedRow(rowIndex);
	}

	internal DataGridViewCell GetCellInternal(int colIndex, int rowIndex)
	{
		return GetRowInternal(rowIndex).Cells.GetCellInternal(colIndex);
	}

	public Rectangle GetCellDisplayRectangle(int columnIndex, int rowIndex, bool cutOverflow)
	{
		if (columnIndex < -1 || columnIndex >= columns.Count)
		{
			throw new ArgumentOutOfRangeException("Column index is out of range.");
		}
		if (rowIndex < -1 || (rowIndex > 0 && rowIndex >= rows.Count))
		{
			throw new ArgumentOutOfRangeException("Row index is out of range.");
		}
		int num = 0;
		int num2 = 0;
		int width = 0;
		int height = 0;
		num = BorderWidth;
		num2 = BorderWidth;
		if (ColumnHeadersVisible)
		{
			num2 += ColumnHeadersHeight;
		}
		if (RowHeadersVisible)
		{
			num += RowHeadersWidth;
		}
		if (columnIndex == -1 && rowIndex == -1)
		{
			return new Rectangle(BorderWidth, BorderWidth, RowHeadersWidth, ColumnHeadersHeight);
		}
		if (columnIndex >= 0)
		{
			List<DataGridViewColumn> columnDisplayIndexSortedArrayList = columns.ColumnDisplayIndexSortedArrayList;
			for (int i = first_col_index; i < columnDisplayIndexSortedArrayList.Count; i++)
			{
				if (columnDisplayIndexSortedArrayList[i].Visible)
				{
					if (columnDisplayIndexSortedArrayList[i].Index == columnIndex)
					{
						width = columnDisplayIndexSortedArrayList[i].Width;
						break;
					}
					num += columnDisplayIndexSortedArrayList[i].Width;
				}
			}
		}
		if (rowIndex == -1)
		{
			return new Rectangle(num, BorderWidth, width, ColumnHeadersHeight);
		}
		for (int j = first_row_index; j < Rows.Count; j++)
		{
			if (rows[j].Visible)
			{
				if (rows[j].Index == rowIndex)
				{
					height = rows[j].Height;
					break;
				}
				num2 += rows[j].Height;
			}
		}
		if (columnIndex == -1)
		{
			return new Rectangle(BorderWidth, num2, RowHeadersWidth, height);
		}
		return new Rectangle(num, num2, width, height);
	}

	public virtual DataObject GetClipboardContent()
	{
		if (clipboardCopyMode == DataGridViewClipboardCopyMode.Disable)
		{
			throw new InvalidOperationException("Generating Clipboard content is not supported when the ClipboardCopyMode property is Disable.");
		}
		int num = int.MaxValue;
		int num2 = int.MinValue;
		int num3 = int.MaxValue;
		int num4 = int.MinValue;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		switch (ClipboardCopyMode)
		{
		case DataGridViewClipboardCopyMode.EnableWithAutoHeaderText:
			flag4 = selectionMode != DataGridViewSelectionMode.CellSelect;
			break;
		case DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText:
			flag2 = (flag = true);
			break;
		}
		BitArray bitArray = new BitArray(RowCount);
		BitArray bitArray2 = new BitArray(ColumnCount);
		if (flag4 && !flag2)
		{
			for (int i = 0; i < ColumnCount; i++)
			{
				if (Columns[i].Selected)
				{
					flag2 = true;
					break;
				}
			}
		}
		for (int j = 0; j < RowCount; j++)
		{
			DataGridViewRow dataGridViewRow = Rows[j];
			if (flag4 && !flag && dataGridViewRow.Selected)
			{
				flag = true;
			}
			for (int k = 0; k < ColumnCount; k++)
			{
				DataGridViewCell dataGridViewCell = dataGridViewRow.Cells[k];
				if (dataGridViewCell != null && dataGridViewCell.Selected)
				{
					bitArray2[k] = true;
					bitArray[j] = true;
					num = Math.Min(num, j);
					num3 = Math.Min(num3, k);
					num2 = Math.Max(num2, j);
					num4 = Math.Max(num4, k);
				}
			}
		}
		switch (selectionMode)
		{
		case DataGridViewSelectionMode.CellSelect:
		case DataGridViewSelectionMode.RowHeaderSelect:
		case DataGridViewSelectionMode.ColumnHeaderSelect:
			if (selectionMode != DataGridViewSelectionMode.ColumnHeaderSelect)
			{
				for (int l = num; l <= num2; l++)
				{
					bitArray.Set(l, value: true);
				}
			}
			else if (num <= num2)
			{
				bitArray.SetAll(value: true);
			}
			if (selectionMode != DataGridViewSelectionMode.RowHeaderSelect)
			{
				for (int m = num3; m <= num4; m++)
				{
					bitArray2.Set(m, value: true);
				}
			}
			break;
		case DataGridViewSelectionMode.FullRowSelect:
		case DataGridViewSelectionMode.FullColumnSelect:
			flag3 = true;
			break;
		}
		if (num > num2)
		{
			return null;
		}
		if (num3 > num4)
		{
			return null;
		}
		DataObject dataObject = new DataObject();
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		StringBuilder stringBuilder3 = new StringBuilder();
		StringBuilder stringBuilder4 = new StringBuilder();
		int num5 = num;
		int num6 = num3;
		if (flag2)
		{
			num5 = -1;
		}
		for (int n = num5; n <= num2; n++)
		{
			DataGridViewRow dataGridViewRow2 = null;
			if (n >= 0)
			{
				if (!bitArray[n])
				{
					continue;
				}
				dataGridViewRow2 = Rows[n];
			}
			if (flag)
			{
				num6 = -1;
			}
			for (int num7 = num6; num7 <= num4; num7++)
			{
				DataGridViewCell dataGridViewCell2 = null;
				if (!((num7 >= 0) & flag3) || bitArray2[num7])
				{
					dataGridViewCell2 = ((dataGridViewRow2 == null) ? ((num7 != -1) ? Columns[num7].HeaderCell : TopLeftHeaderCell) : ((num7 != -1) ? dataGridViewRow2.Cells[num7] : dataGridViewRow2.HeaderCell));
					bool firstCell = num7 == num6;
					bool lastCell = num7 == num4;
					bool inFirstRow = n == num5;
					bool inLastRow = n == num2;
					string value;
					string value2;
					string value3;
					string value4;
					if (dataGridViewCell2 == null)
					{
						value = string.Empty;
						value2 = string.Empty;
						value3 = string.Empty;
						value4 = string.Empty;
					}
					else
					{
						value = dataGridViewCell2.GetClipboardContentInternal(n, firstCell, lastCell, inFirstRow, inLastRow, DataFormats.Text) as string;
						value2 = dataGridViewCell2.GetClipboardContentInternal(n, firstCell, lastCell, inFirstRow, inLastRow, DataFormats.UnicodeText) as string;
						value3 = dataGridViewCell2.GetClipboardContentInternal(n, firstCell, lastCell, inFirstRow, inLastRow, DataFormats.Html) as string;
						value4 = dataGridViewCell2.GetClipboardContentInternal(n, firstCell, lastCell, inFirstRow, inLastRow, DataFormats.CommaSeparatedValue) as string;
					}
					stringBuilder.Append(value);
					stringBuilder2.Append(value2);
					stringBuilder3.Append(value3);
					stringBuilder4.Append(value4);
					if (num7 == -1)
					{
						num7 = num3 - 1;
					}
				}
			}
			if (n == -1)
			{
				n = num - 1;
			}
		}
		int num8 = 135 + stringBuilder3.Length;
		int num9 = num8 + 36;
		string format = "Version:1.0{0}StartHTML:00000097{0}EndHTML:{1:00000000}{0}StartFragment:00000133{0}EndFragment:{2:00000000}{0}<HTML>{0}<BODY>{0}<!--StartFragment-->";
		format = string.Format(format, "\r\n", num9, num8);
		stringBuilder3.Insert(0, format);
		stringBuilder3.AppendFormat("{0}<!--EndFragment-->{0}</BODY>{0}</HTML>", "\r\n");
		dataObject.SetData(DataFormats.CommaSeparatedValue, autoConvert: false, stringBuilder4.ToString());
		dataObject.SetData(DataFormats.Html, autoConvert: false, stringBuilder3.ToString());
		dataObject.SetData(DataFormats.UnicodeText, autoConvert: false, stringBuilder2.ToString());
		dataObject.SetData(DataFormats.Text, autoConvert: false, stringBuilder.ToString());
		return dataObject;
	}

	[System.MonoTODO("Does not use cutOverflow parameter")]
	public Rectangle GetColumnDisplayRectangle(int columnIndex, bool cutOverflow)
	{
		if (columnIndex < 0 || columnIndex > Columns.Count - 1)
		{
			throw new ArgumentOutOfRangeException("columnIndex");
		}
		int num = 0;
		int width = 0;
		num = BorderWidth;
		if (RowHeadersVisible)
		{
			num += RowHeadersWidth;
		}
		List<DataGridViewColumn> columnDisplayIndexSortedArrayList = columns.ColumnDisplayIndexSortedArrayList;
		for (int i = first_col_index; i < columnDisplayIndexSortedArrayList.Count; i++)
		{
			if (columnDisplayIndexSortedArrayList[i].Visible)
			{
				if (columnDisplayIndexSortedArrayList[i].Index == columnIndex)
				{
					width = columnDisplayIndexSortedArrayList[i].Width;
					break;
				}
				num += columnDisplayIndexSortedArrayList[i].Width;
			}
		}
		return new Rectangle(num, 0, width, base.Height);
	}

	[System.MonoTODO("Does not use cutOverflow parameter")]
	public Rectangle GetRowDisplayRectangle(int rowIndex, bool cutOverflow)
	{
		if (rowIndex < 0 || rowIndex > Rows.Count - 1)
		{
			throw new ArgumentOutOfRangeException("rowIndex");
		}
		int num = 0;
		int height = 0;
		num = BorderWidth;
		if (ColumnHeadersVisible)
		{
			num += ColumnHeadersHeight;
		}
		for (int i = first_row_index; i < Rows.Count; i++)
		{
			if (rows[i].Visible)
			{
				if (rows[i].Index == rowIndex)
				{
					height = rows[i].Height;
					break;
				}
				num += rows[i].Height;
			}
		}
		return new Rectangle(0, num, base.Width, height);
	}

	public HitTestInfo HitTest(int x, int y)
	{
		bool flag = columnHeadersVisible && y >= 0 && y <= ColumnHeadersHeight;
		bool flag2 = rowHeadersVisible && x >= 0 && x <= RowHeadersWidth;
		if (flag & flag2)
		{
			return new HitTestInfo(-1, x, -1, y, DataGridViewHitTestType.TopLeftHeader);
		}
		if (horizontalScrollBar.Visible && horizontalScrollBar.Bounds.Contains(x, y))
		{
			return new HitTestInfo(-1, x, -1, y, DataGridViewHitTestType.HorizontalScrollBar);
		}
		if (verticalScrollBar.Visible && verticalScrollBar.Bounds.Contains(x, y))
		{
			return new HitTestInfo(-1, x, -1, y, DataGridViewHitTestType.VerticalScrollBar);
		}
		if (verticalScrollBar.Visible && horizontalScrollBar.Visible && new Rectangle(verticalScrollBar.Left, horizontalScrollBar.Top, verticalScrollBar.Width, horizontalScrollBar.Height).Contains(x, y))
		{
			return new HitTestInfo(-1, x, -1, y, DataGridViewHitTestType.None);
		}
		int num = -1;
		int num2 = -1;
		int num3 = (columnHeadersVisible ? columnHeadersHeight : 0);
		for (int i = first_row_index; i < Rows.Count; i++)
		{
			DataGridViewRow dataGridViewRow = Rows[i];
			if (dataGridViewRow.Visible)
			{
				if (y > num3 && y <= num3 + dataGridViewRow.Height)
				{
					num = i;
					break;
				}
				num3 += dataGridViewRow.Height;
			}
		}
		int num4 = (rowHeadersVisible ? RowHeadersWidth : 0);
		List<DataGridViewColumn> columnDisplayIndexSortedArrayList = columns.ColumnDisplayIndexSortedArrayList;
		for (int j = first_col_index; j < columnDisplayIndexSortedArrayList.Count; j++)
		{
			if (columnDisplayIndexSortedArrayList[j].Visible)
			{
				if (x > num4 && x <= num4 + columnDisplayIndexSortedArrayList[j].Width)
				{
					num2 = columnDisplayIndexSortedArrayList[j].Index;
					break;
				}
				num4 += columnDisplayIndexSortedArrayList[j].Width;
			}
		}
		if (num2 >= 0 && num >= 0)
		{
			return new HitTestInfo(num2, x, num, y, DataGridViewHitTestType.Cell);
		}
		if (flag && num2 > -1)
		{
			return new HitTestInfo(num2, x, num, y, DataGridViewHitTestType.ColumnHeader);
		}
		if (flag2 && num > -1)
		{
			return new HitTestInfo(num2, x, num, y, DataGridViewHitTestType.RowHeader);
		}
		return new HitTestInfo(-1, x, -1, y, DataGridViewHitTestType.None);
	}

	public void InvalidateCell(DataGridViewCell dataGridViewCell)
	{
		if (dataGridViewCell == null)
		{
			throw new ArgumentNullException("Cell is null");
		}
		if (dataGridViewCell.DataGridView != this)
		{
			throw new ArgumentException("The specified cell does not belong to this DataGridView.");
		}
		InvalidateCell(dataGridViewCell.ColumnIndex, dataGridViewCell.RowIndex);
	}

	public void InvalidateCell(int columnIndex, int rowIndex)
	{
		if (columnIndex < -1 || columnIndex >= columns.Count)
		{
			throw new ArgumentOutOfRangeException("Column index is out of range.");
		}
		if (rowIndex < -1 || rowIndex >= rows.Count)
		{
			throw new ArgumentOutOfRangeException("Row index is out of range.");
		}
		if (!is_binding)
		{
			Invalidate(GetCellDisplayRectangle(columnIndex, rowIndex, cutOverflow: true));
		}
	}

	public void InvalidateColumn(int columnIndex)
	{
		if (columnIndex < 0 || columnIndex >= columns.Count)
		{
			throw new ArgumentOutOfRangeException("Column index is out of range.");
		}
		if (!is_binding)
		{
			Invalidate(GetColumnDisplayRectangle(columnIndex, cutOverflow: true));
		}
	}

	public void InvalidateRow(int rowIndex)
	{
		if (rowIndex < 0 || rowIndex >= rows.Count)
		{
			throw new ArgumentOutOfRangeException("Row index is out of range.");
		}
		if (!is_binding)
		{
			Invalidate(GetRowDisplayRectangle(rowIndex, cutOverflow: true));
		}
	}

	public virtual void NotifyCurrentCellDirty(bool dirty)
	{
		if (currentCell != null)
		{
			InvalidateCell(currentCell);
		}
	}

	public bool RefreshEdit()
	{
		if (IsCurrentCellInEditMode)
		{
			currentCell.InitializeEditingControl(currentCell.RowIndex, currentCell.FormattedValue, currentCell.InheritedStyle);
			return true;
		}
		return false;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override void ResetText()
	{
		Text = string.Empty;
	}

	public void SelectAll()
	{
		switch (selectionMode)
		{
		case DataGridViewSelectionMode.FullRowSelect:
			foreach (DataGridViewRow item in (IEnumerable)rows)
			{
				item.Selected = true;
			}
			break;
		case DataGridViewSelectionMode.FullColumnSelect:
			foreach (DataGridViewColumn column in columns)
			{
				column.Selected = true;
			}
			break;
		default:
			foreach (DataGridViewRow item2 in (IEnumerable)rows)
			{
				foreach (DataGridViewCell cell in item2.Cells)
				{
					cell.Selected = true;
				}
			}
			break;
		}
		Invalidate();
	}

	public virtual void Sort(IComparer comparer)
	{
		if (comparer == null)
		{
			throw new ArgumentNullException("comparer");
		}
		if (VirtualMode || DataSource != null)
		{
			throw new InvalidOperationException();
		}
		if (SortedColumn != null)
		{
			SortedColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
		}
		EndEdit();
		Rows.Sort(comparer);
		sortedColumn = null;
		sortOrder = SortOrder.None;
		currentCell = null;
		Invalidate();
		OnSorted(EventArgs.Empty);
	}

	public virtual void Sort(DataGridViewColumn dataGridViewColumn, ListSortDirection direction)
	{
		if (dataGridViewColumn == null)
		{
			throw new ArgumentNullException("dataGridViewColumn");
		}
		if (dataGridViewColumn.DataGridView != this)
		{
			throw new ArgumentException("dataGridViewColumn");
		}
		if (!EndEdit())
		{
			return;
		}
		if (SortedColumn != null)
		{
			SortedColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
		}
		sortedColumn = dataGridViewColumn;
		sortOrder = ((direction == ListSortDirection.Ascending) ? SortOrder.Ascending : SortOrder.Descending);
		if (Rows.Count == 0)
		{
			return;
		}
		if (dataGridViewColumn.IsDataBound)
		{
			if (DataManager.List is IBindingList { SupportsSorting: not false } bindingList)
			{
				bindingList.ApplySort(DataManager.GetItemProperties()[dataGridViewColumn.DataPropertyName], direction);
				dataGridViewColumn.HeaderCell.SortGlyphDirection = sortOrder;
			}
		}
		else
		{
			bool numeric = true;
			foreach (DataGridViewRow item in (IEnumerable)Rows)
			{
				object value = item.Cells[dataGridViewColumn.Index].Value;
				if (value != null && !double.TryParse(value.ToString(), out var _))
				{
					numeric = false;
					break;
				}
			}
			ColumnSorter comparer = new ColumnSorter(dataGridViewColumn, direction, numeric);
			Rows.Sort(comparer);
			dataGridViewColumn.HeaderCell.SortGlyphDirection = sortOrder;
		}
		Invalidate();
		OnSorted(EventArgs.Empty);
	}

	public void UpdateCellErrorText(int columnIndex, int rowIndex)
	{
		if (columnIndex < 0 || columnIndex > Columns.Count - 1)
		{
			throw new ArgumentOutOfRangeException("columnIndex");
		}
		if (rowIndex < 0 || rowIndex > Rows.Count - 1)
		{
			throw new ArgumentOutOfRangeException("rowIndex");
		}
		InvalidateCell(columnIndex, rowIndex);
	}

	public void UpdateCellValue(int columnIndex, int rowIndex)
	{
		if (columnIndex < 0 || columnIndex > Columns.Count - 1)
		{
			throw new ArgumentOutOfRangeException("columnIndex");
		}
		if (rowIndex < 0 || rowIndex > Rows.Count - 1)
		{
			throw new ArgumentOutOfRangeException("rowIndex");
		}
		InvalidateCell(columnIndex, rowIndex);
	}

	public void UpdateRowErrorText(int rowIndex)
	{
		if (rowIndex < 0 || rowIndex > Rows.Count - 1)
		{
			throw new ArgumentOutOfRangeException("rowIndex");
		}
		InvalidateRow(rowIndex);
	}

	public void UpdateRowErrorText(int rowIndexStart, int rowIndexEnd)
	{
		if (rowIndexStart < 0 || rowIndexStart > Rows.Count - 1)
		{
			throw new ArgumentOutOfRangeException("rowIndexStart");
		}
		if (rowIndexEnd < 0 || rowIndexEnd > Rows.Count - 1)
		{
			throw new ArgumentOutOfRangeException("rowIndexEnd");
		}
		if (rowIndexEnd < rowIndexStart)
		{
			throw new ArgumentOutOfRangeException("rowIndexEnd", "rowIndexEnd must be greater than rowIndexStart");
		}
		for (int i = rowIndexStart; i <= rowIndexEnd; i++)
		{
			InvalidateRow(i);
		}
	}

	private void UpdateRowHeightInfo(DataGridViewRow row)
	{
		DataGridViewRowHeightInfoNeededEventArgs e = new DataGridViewRowHeightInfoNeededEventArgs(row.Index, row.Height, row.MinimumHeight);
		OnRowHeightInfoNeeded(e);
		if (row.Height != e.Height || row.MinimumHeight != e.MinimumHeight)
		{
			row.MinimumHeight = e.MinimumHeight;
			row.Height = e.Height;
			OnRowHeightInfoPushed(new DataGridViewRowHeightInfoPushedEventArgs(row.Index, e.Height, e.MinimumHeight));
		}
	}

	public void UpdateRowHeightInfo(int rowIndex, bool updateToEnd)
	{
		if ((rowIndex < 0) & updateToEnd)
		{
			throw new ArgumentOutOfRangeException("rowIndex");
		}
		if (rowIndex < -1 && !updateToEnd)
		{
			throw new ArgumentOutOfRangeException("rowIndex");
		}
		if (rowIndex >= Rows.Count)
		{
			throw new ArgumentOutOfRangeException("rowIndex");
		}
		if (!VirtualMode && DataManager == null)
		{
			return;
		}
		if (rowIndex == -1)
		{
			updateToEnd = true;
			rowIndex = 0;
		}
		if (updateToEnd)
		{
			for (int i = rowIndex; i < Rows.Count; i++)
			{
				DataGridViewRow dataGridViewRow = Rows[i];
				if (dataGridViewRow.Visible)
				{
					UpdateRowHeightInfo(dataGridViewRow);
				}
			}
		}
		else
		{
			UpdateRowHeightInfo(Rows[rowIndex]);
		}
	}

	protected virtual void AccessibilityNotifyCurrentCellChanged(Point cellAddress)
	{
		throw new NotImplementedException();
	}

	[System.MonoTODO("Does not use fixedHeight parameter")]
	protected void AutoResizeColumn(int columnIndex, DataGridViewAutoSizeColumnMode autoSizeColumnMode, bool fixedHeight)
	{
		AutoResizeColumn(columnIndex, autoSizeColumnMode);
	}

	[System.MonoTODO("Does not use fixedRowHeadersWidth or fixedColumnsWidth parameters")]
	protected void AutoResizeColumnHeadersHeight(bool fixedRowHeadersWidth, bool fixedColumnsWidth)
	{
		AutoResizeColumnHeadersHeight();
	}

	[System.MonoTODO("Does not use columnIndex or fixedRowHeadersWidth or fixedColumnsWidth parameters")]
	protected void AutoResizeColumnHeadersHeight(int columnIndex, bool fixedRowHeadersWidth, bool fixedColumnWidth)
	{
		AutoResizeColumnHeadersHeight(columnIndex);
	}

	protected void AutoResizeColumns(DataGridViewAutoSizeColumnsMode autoSizeColumnsMode, bool fixedHeight)
	{
		for (int i = 0; i < Columns.Count; i++)
		{
			AutoResizeColumn(i, (DataGridViewAutoSizeColumnMode)autoSizeColumnsMode, fixedHeight);
		}
	}

	[System.MonoTODO("Does not use fixedWidth parameter")]
	protected void AutoResizeRow(int rowIndex, DataGridViewAutoSizeRowMode autoSizeRowMode, bool fixedWidth)
	{
		if (autoSizeRowMode == DataGridViewAutoSizeRowMode.RowHeader && !rowHeadersVisible)
		{
			throw new InvalidOperationException("row headers are not visible");
		}
		if (rowIndex < 0 || rowIndex > Rows.Count - 1)
		{
			throw new ArgumentOutOfRangeException("rowIndex");
		}
		DataGridViewRow rowInternal = GetRowInternal(rowIndex);
		int preferredHeight = rowInternal.GetPreferredHeight(rowIndex, autoSizeRowMode, fixedWidth: true);
		if (rowInternal.Height != preferredHeight)
		{
			rowInternal.SetAutoSizeHeight(preferredHeight);
		}
	}

	[System.MonoTODO("Does not use fixedColumnHeadersHeight or fixedRowsHeight parameter")]
	protected void AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode rowHeadersWidthSizeMode, bool fixedColumnHeadersHeight, bool fixedRowsHeight)
	{
		AutoResizeRowHeadersWidth(rowHeadersWidthSizeMode);
	}

	[System.MonoTODO("Does not use rowIndex or fixedColumnHeadersHeight or fixedRowsHeight parameter")]
	protected void AutoResizeRowHeadersWidth(int rowIndex, DataGridViewRowHeadersWidthSizeMode rowHeadersWidthSizeMode, bool fixedColumnHeadersHeight, bool fixedRowHeight)
	{
		AutoResizeRowHeadersWidth(rowHeadersWidthSizeMode);
	}

	[System.MonoTODO("Does not use fixedWidth parameter")]
	protected void AutoResizeRows(DataGridViewAutoSizeRowsMode autoSizeRowsMode, bool fixedWidth)
	{
		if (autoSizeRowsMode == DataGridViewAutoSizeRowsMode.None)
		{
			return;
		}
		bool flag = false;
		DataGridViewAutoSizeRowMode autoSizeRowMode = DataGridViewAutoSizeRowMode.AllCells;
		switch (autoSizeRowsMode)
		{
		case DataGridViewAutoSizeRowsMode.AllHeaders:
			autoSizeRowMode = DataGridViewAutoSizeRowMode.RowHeader;
			break;
		case DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders:
			autoSizeRowMode = DataGridViewAutoSizeRowMode.AllCellsExceptHeader;
			break;
		case DataGridViewAutoSizeRowsMode.AllCells:
			autoSizeRowMode = DataGridViewAutoSizeRowMode.AllCells;
			break;
		case DataGridViewAutoSizeRowsMode.DisplayedHeaders:
			autoSizeRowMode = DataGridViewAutoSizeRowMode.RowHeader;
			flag = true;
			break;
		case DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders:
			autoSizeRowMode = DataGridViewAutoSizeRowMode.AllCellsExceptHeader;
			flag = true;
			break;
		case DataGridViewAutoSizeRowsMode.DisplayedCells:
			autoSizeRowMode = DataGridViewAutoSizeRowMode.AllCells;
			flag = true;
			break;
		}
		foreach (DataGridViewRow item in (IEnumerable)Rows)
		{
			if (item.Visible && (!flag || item.Displayed))
			{
				int preferredHeight = item.GetPreferredHeight(item.Index, autoSizeRowMode, fixedWidth);
				if (item.Height != preferredHeight)
				{
					item.SetAutoSizeHeight(preferredHeight);
				}
			}
		}
	}

	[System.MonoTODO("Does not use fixedMode parameter")]
	protected void AutoResizeRows(int rowIndexStart, int rowsCount, DataGridViewAutoSizeRowMode autoSizeRowMode, bool fixedWidth)
	{
		for (int i = rowIndexStart; i < rowIndexStart + rowsCount; i++)
		{
			AutoResizeRow(i, autoSizeRowMode, fixedWidth);
		}
	}

	protected void ClearSelection(int columnIndexException, int rowIndexException, bool selectExceptionElement)
	{
		if (columnIndexException >= columns.Count)
		{
			throw new ArgumentOutOfRangeException("ColumnIndexException is greater than the highest column index.");
		}
		if (selectionMode == DataGridViewSelectionMode.FullRowSelect)
		{
			if (columnIndexException < -1)
			{
				throw new ArgumentOutOfRangeException("ColumnIndexException is less than -1.");
			}
		}
		else if (columnIndexException < 0)
		{
			throw new ArgumentOutOfRangeException("ColumnIndexException is less than 0.");
		}
		if (rowIndexException >= rows.Count)
		{
			throw new ArgumentOutOfRangeException("RowIndexException is greater than the highest row index.");
		}
		if (selectionMode == DataGridViewSelectionMode.FullColumnSelect)
		{
			if (rowIndexException < -1)
			{
				throw new ArgumentOutOfRangeException("RowIndexException is less than -1.");
			}
		}
		else if (rowIndexException < 0)
		{
			throw new ArgumentOutOfRangeException("RowIndexException is less than 0.");
		}
		switch (selectionMode)
		{
		case DataGridViewSelectionMode.FullRowSelect:
		{
			foreach (DataGridViewRow item in (IEnumerable)rows)
			{
				if (!selectExceptionElement || item.Index != rowIndexException)
				{
					SetSelectedRowCore(item.Index, selected: false);
				}
			}
			return;
		}
		case DataGridViewSelectionMode.FullColumnSelect:
		{
			foreach (DataGridViewColumn column in columns)
			{
				if (!selectExceptionElement || column.Index != columnIndexException)
				{
					SetSelectedColumnCore(column.Index, selected: false);
				}
			}
			return;
		}
		}
		foreach (DataGridViewCell selectedCell in SelectedCells)
		{
			if (!selectExceptionElement || selectedCell.RowIndex != rowIndexException || selectedCell.ColumnIndex != columnIndexException)
			{
				SetSelectedCellCore(selectedCell.ColumnIndex, selectedCell.RowIndex, selected: false);
			}
		}
	}

	protected override AccessibleObject CreateAccessibilityInstance()
	{
		return new DataGridViewAccessibleObject(this);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual DataGridViewColumnCollection CreateColumnsInstance()
	{
		return new DataGridViewColumnCollection(this);
	}

	protected override ControlCollection CreateControlsInstance()
	{
		return new DataGridViewControlCollection(this);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual DataGridViewRowCollection CreateRowsInstance()
	{
		return new DataGridViewRowCollection(this);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			ClearSelection();
			currentCell = null;
			foreach (DataGridViewColumn column in Columns)
			{
				column.Dispose();
			}
			Columns.Clear();
			foreach (DataGridViewRow item in (IEnumerable)Rows)
			{
				item.Dispose();
			}
			Rows.Clear();
			if (tooltip_timer != null)
			{
				tooltip_timer.Dispose();
			}
			if (tooltip_window != null)
			{
				tooltip_window.Dispose();
			}
		}
		editingControl = null;
		base.Dispose(disposing);
	}

	protected override AccessibleObject GetAccessibilityObjectById(int objectId)
	{
		throw new NotImplementedException();
	}

	protected override bool IsInputChar(char charCode)
	{
		return true;
	}

	protected override bool IsInputKey(Keys keyData)
	{
		keyData &= Keys.KeyCode;
		switch (keyData)
		{
		case Keys.Return:
		case Keys.PageUp:
		case Keys.PageDown:
		case Keys.End:
		case Keys.Home:
		case Keys.Left:
		case Keys.Up:
		case Keys.Right:
		case Keys.Down:
		case Keys.Delete:
		case Keys.D0:
		case Keys.NumPad0:
		case Keys.F2:
			return true;
		default:
			return false;
		}
	}

	protected virtual void OnAllowUserToAddRowsChanged(EventArgs e)
	{
		((EventHandler)base.Events[AllowUserToAddRowsChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnAllowUserToDeleteRowsChanged(EventArgs e)
	{
		((EventHandler)base.Events[AllowUserToDeleteRowsChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnAllowUserToOrderColumnsChanged(EventArgs e)
	{
		((EventHandler)base.Events[AllowUserToOrderColumnsChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnAllowUserToResizeColumnsChanged(EventArgs e)
	{
		((EventHandler)base.Events[AllowUserToResizeColumnsChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnAllowUserToResizeRowsChanged(EventArgs e)
	{
		((EventHandler)base.Events[AllowUserToResizeRowsChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnAlternatingRowsDefaultCellStyleChanged(EventArgs e)
	{
		((EventHandler)base.Events[AlternatingRowsDefaultCellStyleChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnAutoGenerateColumnsChanged(EventArgs e)
	{
		((EventHandler)base.Events[AutoGenerateColumnsChangedEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnAutoSizeColumnModeChanged(DataGridViewAutoSizeColumnModeEventArgs e)
	{
		((DataGridViewAutoSizeColumnModeEventHandler)base.Events[AutoSizeColumnModeChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnAutoSizeColumnsModeChanged(DataGridViewAutoSizeColumnsModeEventArgs e)
	{
		((DataGridViewAutoSizeColumnsModeEventHandler)base.Events[AutoSizeColumnsModeChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnAutoSizeRowsModeChanged(DataGridViewAutoSizeModeEventArgs e)
	{
		((DataGridViewAutoSizeModeEventHandler)base.Events[AutoSizeRowsModeChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnBackgroundColorChanged(EventArgs e)
	{
		((EventHandler)base.Events[BackgroundColorChangedEvent])?.Invoke(this, e);
	}

	protected override void OnBindingContextChanged(EventArgs e)
	{
		base.OnBindingContextChanged(e);
		ReBind();
	}

	protected virtual void OnBorderStyleChanged(EventArgs e)
	{
		((EventHandler)base.Events[BorderStyleChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnCancelRowEdit(QuestionEventArgs e)
	{
		((QuestionEventHandler)base.Events[CancelRowEditEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellBeginEdit(DataGridViewCellCancelEventArgs e)
	{
		((DataGridViewCellCancelEventHandler)base.Events[CellBeginEditEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellBorderStyleChanged(EventArgs e)
	{
		((EventHandler)base.Events[CellBorderStyleChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellClick(DataGridViewCellEventArgs e)
	{
		GetCellInternal(e.ColumnIndex, e.RowIndex).OnClickInternal(e);
		((DataGridViewCellEventHandler)base.Events[CellClickEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellContentClick(DataGridViewCellEventArgs e)
	{
		GetCellInternal(e.ColumnIndex, e.RowIndex).OnContentClickInternal(e);
		((DataGridViewCellEventHandler)base.Events[CellContentClickEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellContentDoubleClick(DataGridViewCellEventArgs e)
	{
		GetCellInternal(e.ColumnIndex, e.RowIndex).OnContentDoubleClickInternal(e);
		((DataGridViewCellEventHandler)base.Events[CellContentDoubleClickEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellContextMenuStripChanged(DataGridViewCellEventArgs e)
	{
		((DataGridViewCellEventHandler)base.Events[CellContextMenuStripChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellContextMenuStripNeeded(DataGridViewCellContextMenuStripNeededEventArgs e)
	{
		((DataGridViewCellContextMenuStripNeededEventHandler)base.Events[CellContextMenuStripNeededEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellDoubleClick(DataGridViewCellEventArgs e)
	{
		GetCellInternal(e.ColumnIndex, e.RowIndex).OnDoubleClickInternal(e);
		((DataGridViewCellEventHandler)base.Events[CellDoubleClickEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellEndEdit(DataGridViewCellEventArgs e)
	{
		((DataGridViewCellEventHandler)base.Events[CellEndEditEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellEnter(DataGridViewCellEventArgs e)
	{
		GetCellInternal(e.ColumnIndex, e.RowIndex).OnEnterInternal(e.RowIndex, throughMouseClick: true);
		((DataGridViewCellEventHandler)base.Events[CellEnterEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnCellErrorTextChanged(DataGridViewCellEventArgs e)
	{
		((DataGridViewCellEventHandler)base.Events[CellErrorTextChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellErrorTextNeeded(DataGridViewCellErrorTextNeededEventArgs e)
	{
		((DataGridViewCellErrorTextNeededEventHandler)base.Events[CellErrorTextNeededEvent])?.Invoke(this, e);
	}

	internal void OnCellFormattingInternal(DataGridViewCellFormattingEventArgs e)
	{
		OnCellFormatting(e);
	}

	protected virtual void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
	{
		((DataGridViewCellFormattingEventHandler)base.Events[CellFormattingEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellLeave(DataGridViewCellEventArgs e)
	{
		GetCellInternal(e.ColumnIndex, e.RowIndex).OnLeaveInternal(e.RowIndex, throughMouseClick: true);
		((DataGridViewCellEventHandler)base.Events[CellLeaveEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellMouseClick(DataGridViewCellMouseEventArgs e)
	{
		GetCellInternal(e.ColumnIndex, e.RowIndex).OnMouseClickInternal(e);
		((DataGridViewCellMouseEventHandler)base.Events[CellMouseClickEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellMouseDoubleClick(DataGridViewCellMouseEventArgs e)
	{
		GetCellInternal(e.ColumnIndex, e.RowIndex).OnMouseDoubleClickInternal(e);
		((DataGridViewCellMouseEventHandler)base.Events[CellMouseDoubleClickEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellMouseDown(DataGridViewCellMouseEventArgs e)
	{
		GetCellInternal(e.ColumnIndex, e.RowIndex).OnMouseDownInternal(e);
		((DataGridViewCellMouseEventHandler)base.Events[CellMouseDownEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellMouseEnter(DataGridViewCellEventArgs e)
	{
		GetCellInternal(e.ColumnIndex, e.RowIndex).OnMouseEnterInternal(e.RowIndex);
		((DataGridViewCellEventHandler)base.Events[CellMouseEnterEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellMouseLeave(DataGridViewCellEventArgs e)
	{
		GetCellInternal(e.ColumnIndex, e.RowIndex).OnMouseLeaveInternal(e.RowIndex);
		((DataGridViewCellEventHandler)base.Events[CellMouseLeaveEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellMouseMove(DataGridViewCellMouseEventArgs e)
	{
		GetCellInternal(e.ColumnIndex, e.RowIndex).OnMouseMoveInternal(e);
		((DataGridViewCellMouseEventHandler)base.Events[CellMouseMoveEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellMouseUp(DataGridViewCellMouseEventArgs e)
	{
		GetCellInternal(e.ColumnIndex, e.RowIndex).OnMouseUpInternal(e);
		((DataGridViewCellMouseEventHandler)base.Events[CellMouseUpEvent])?.Invoke(this, e);
	}

	internal void OnCellPaintingInternal(DataGridViewCellPaintingEventArgs e)
	{
		OnCellPainting(e);
	}

	protected virtual void OnCellPainting(DataGridViewCellPaintingEventArgs e)
	{
		((DataGridViewCellPaintingEventHandler)base.Events[CellPaintingEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnCellParsing(DataGridViewCellParsingEventArgs e)
	{
		((DataGridViewCellParsingEventHandler)base.Events[CellParsingEvent])?.Invoke(this, e);
	}

	internal void OnCellStateChangedInternal(DataGridViewCellStateChangedEventArgs e)
	{
		OnCellStateChanged(e);
	}

	protected virtual void OnCellStateChanged(DataGridViewCellStateChangedEventArgs e)
	{
		((DataGridViewCellStateChangedEventHandler)base.Events[CellStateChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellStyleChanged(DataGridViewCellEventArgs e)
	{
		((DataGridViewCellEventHandler)base.Events[CellStyleChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellStyleContentChanged(DataGridViewCellStyleContentChangedEventArgs e)
	{
		((DataGridViewCellStyleContentChangedEventHandler)base.Events[CellStyleContentChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellToolTipTextChanged(DataGridViewCellEventArgs e)
	{
		((DataGridViewCellEventHandler)base.Events[CellToolTipTextChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellToolTipTextNeeded(DataGridViewCellToolTipTextNeededEventArgs e)
	{
		((DataGridViewCellToolTipTextNeededEventHandler)base.Events[CellToolTipTextNeededEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellValidated(DataGridViewCellEventArgs e)
	{
		((DataGridViewCellEventHandler)base.Events[CellValidatedEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellValidating(DataGridViewCellValidatingEventArgs e)
	{
		((DataGridViewCellValidatingEventHandler)base.Events[CellValidatingEvent])?.Invoke(this, e);
	}

	protected virtual void OnCellValueChanged(DataGridViewCellEventArgs e)
	{
		((DataGridViewCellEventHandler)base.Events[CellValueChangedEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnCellValueNeeded(DataGridViewCellValueEventArgs e)
	{
		((DataGridViewCellValueEventHandler)base.Events[CellValueNeededEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnCellValuePushed(DataGridViewCellValueEventArgs e)
	{
		((DataGridViewCellValueEventHandler)base.Events[CellValuePushedEvent])?.Invoke(this, e);
	}

	internal void OnColumnAddedInternal(DataGridViewColumnEventArgs e)
	{
		e.Column.DataColumnIndex = FindDataColumnIndex(e.Column);
		if (e.Column.CellTemplate != null)
		{
			if (!is_autogenerating_columns && columns.Count == 1)
			{
				ReBind();
			}
			foreach (DataGridViewRow item in (IEnumerable)Rows)
			{
				if (item.Index == NewRowIndex)
				{
					continue;
				}
				DataGridViewCell dataGridViewCell = (DataGridViewCell)e.Column.CellTemplate.Clone();
				if (item.Cells.Count == columns.Count)
				{
					DataGridViewCell dataGridViewCell2 = item.Cells[e.Column.Index];
					if (currentCell != null && dataGridViewCell2 == currentCell)
					{
						currentCell = dataGridViewCell;
					}
					if (!e.Column.IsDataBound && dataGridViewCell2.OwningRow.DataBoundItem == null)
					{
						dataGridViewCell.Value = dataGridViewCell2.Value;
					}
					item.Cells.Replace(e.Column.Index, dataGridViewCell);
				}
				else if (e.Column.Index >= item.Cells.Count)
				{
					item.Cells.Add(dataGridViewCell);
				}
				else
				{
					item.Cells.Insert(e.Column.Index, dataGridViewCell);
				}
			}
		}
		AutoResizeColumnsInternal();
		OnColumnAdded(e);
		PrepareEditingRow(cell_changed: false, column_changed: true);
	}

	private int FindDataColumnIndex(DataGridViewColumn column)
	{
		if (column != null && DataManager != null)
		{
			PropertyDescriptorCollection itemProperties = DataManager.GetItemProperties();
			for (int i = 0; i < itemProperties.Count; i++)
			{
				if (string.Compare(column.DataPropertyName, itemProperties[i].Name, ignoreCase: true) == 0)
				{
					return i;
				}
			}
		}
		return -1;
	}

	protected virtual void OnColumnAdded(DataGridViewColumnEventArgs e)
	{
		((DataGridViewColumnEventHandler)base.Events[ColumnAddedEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnColumnContextMenuStripChanged(DataGridViewColumnEventArgs e)
	{
		((DataGridViewColumnEventHandler)base.Events[ColumnContextMenuStripChangedEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnColumnDataPropertyNameChanged(DataGridViewColumnEventArgs e)
	{
		((DataGridViewColumnEventHandler)base.Events[ColumnDataPropertyNameChangedEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnColumnDefaultCellStyleChanged(DataGridViewColumnEventArgs e)
	{
		((DataGridViewColumnEventHandler)base.Events[ColumnDefaultCellStyleChangedEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnColumnDisplayIndexChanged(DataGridViewColumnEventArgs e)
	{
		((DataGridViewColumnEventHandler)base.Events[ColumnDisplayIndexChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnColumnDividerDoubleClick(DataGridViewColumnDividerDoubleClickEventArgs e)
	{
		((DataGridViewColumnDividerDoubleClickEventHandler)base.Events[ColumnDividerDoubleClickEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnColumnDividerWidthChanged(DataGridViewColumnEventArgs e)
	{
		((DataGridViewColumnEventHandler)base.Events[ColumnDividerWidthChangedEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnColumnHeaderCellChanged(DataGridViewColumnEventArgs e)
	{
		((DataGridViewColumnEventHandler)base.Events[ColumnHeaderCellChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
	{
		DataGridViewColumn dataGridViewColumn = Columns[e.ColumnIndex];
		if (dataGridViewColumn.SortMode == DataGridViewColumnSortMode.Automatic)
		{
			ListSortDirection direction = ((SortedColumn == dataGridViewColumn && sortOrder == SortOrder.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending);
			Sort(dataGridViewColumn, direction);
		}
		((DataGridViewCellMouseEventHandler)base.Events[ColumnHeaderMouseClickEvent])?.Invoke(this, e);
	}

	protected virtual void OnColumnHeaderMouseDoubleClick(DataGridViewCellMouseEventArgs e)
	{
		((DataGridViewCellMouseEventHandler)base.Events[ColumnHeaderMouseDoubleClickEvent])?.Invoke(this, e);
	}

	protected virtual void OnColumnHeadersBorderStyleChanged(EventArgs e)
	{
		((EventHandler)base.Events[ColumnHeadersBorderStyleChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnColumnHeadersDefaultCellStyleChanged(EventArgs e)
	{
		((EventHandler)base.Events[ColumnHeadersDefaultCellStyleChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnColumnHeadersHeightChanged(EventArgs e)
	{
		((EventHandler)base.Events[ColumnHeadersHeightChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnColumnHeadersHeightSizeModeChanged(DataGridViewAutoSizeModeEventArgs e)
	{
		((DataGridViewAutoSizeModeEventHandler)base.Events[ColumnHeadersHeightSizeModeChangedEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnColumnMinimumWidthChanged(DataGridViewColumnEventArgs e)
	{
		((DataGridViewColumnEventHandler)base.Events[ColumnMinimumWidthChangedEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnColumnNameChanged(DataGridViewColumnEventArgs e)
	{
		((DataGridViewColumnEventHandler)base.Events[ColumnNameChangedEvent])?.Invoke(this, e);
	}

	internal void OnColumnPreRemovedInternal(DataGridViewColumnEventArgs e)
	{
		if (selected_columns != null)
		{
			SetSelectedColumnCore(e.Column.Index, selected: false);
		}
		if (Columns.Count - 1 == 0)
		{
			MoveCurrentCell(-1, -1, select: true, isControl: false, isShift: false, scroll: true);
			rows.ClearInternal();
		}
		else if (currentCell != null && CurrentCell.ColumnIndex == e.Column.Index)
		{
			int num = e.Column.Index;
			if (num >= Columns.Count - 1)
			{
				num = Columns.Count - 1 - 1;
			}
			MoveCurrentCell(num, currentCell.RowIndex, select: true, isControl: false, isShift: false, scroll: true);
			if (hover_cell != null && hover_cell.ColumnIndex >= e.Column.Index)
			{
				hover_cell = null;
			}
		}
	}

	private void OnColumnPostRemovedInternal(DataGridViewColumnEventArgs e)
	{
		if (e.Column.CellTemplate != null)
		{
			int index = e.Column.Index;
			foreach (DataGridViewRow item in (IEnumerable)Rows)
			{
				item.Cells.RemoveAt(index);
			}
		}
		AutoResizeColumnsInternal();
		PrepareEditingRow(cell_changed: false, column_changed: true);
		OnColumnRemoved(e);
	}

	protected virtual void OnColumnRemoved(DataGridViewColumnEventArgs e)
	{
		((DataGridViewColumnEventHandler)base.Events[ColumnRemovedEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnColumnSortModeChanged(DataGridViewColumnEventArgs e)
	{
		((DataGridViewColumnEventHandler)base.Events[ColumnSortModeChangedEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnColumnStateChanged(DataGridViewColumnStateChangedEventArgs e)
	{
		((DataGridViewColumnStateChangedEventHandler)base.Events[ColumnStateChangedEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnColumnToolTipTextChanged(DataGridViewColumnEventArgs e)
	{
		((DataGridViewColumnEventHandler)base.Events[ColumnToolTipTextChangedEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnColumnWidthChanged(DataGridViewColumnEventArgs e)
	{
		((DataGridViewColumnEventHandler)base.Events[ColumnWidthChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnCurrentCellChanged(EventArgs e)
	{
		((EventHandler)base.Events[CurrentCellChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnCurrentCellDirtyStateChanged(EventArgs e)
	{
		((EventHandler)base.Events[CurrentCellDirtyStateChangedEvent])?.Invoke(this, e);
	}

	protected override void OnCursorChanged(EventArgs e)
	{
		base.OnCursorChanged(e);
	}

	protected virtual void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
	{
		((DataGridViewBindingCompleteEventHandler)base.Events[DataBindingCompleteEvent])?.Invoke(this, e);
	}

	protected virtual void OnDataError(bool displayErrorDialogIfNoHandler, DataGridViewDataErrorEventArgs e)
	{
		DataGridViewDataErrorEventHandler dataGridViewDataErrorEventHandler = (DataGridViewDataErrorEventHandler)base.Events[DataErrorEvent];
		if (dataGridViewDataErrorEventHandler != null)
		{
			dataGridViewDataErrorEventHandler(this, e);
		}
		else if (displayErrorDialogIfNoHandler)
		{
			MessageBox.Show(e.ToString());
		}
	}

	protected virtual void OnDataMemberChanged(EventArgs e)
	{
		((EventHandler)base.Events[DataMemberChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnDataSourceChanged(EventArgs e)
	{
		((EventHandler)base.Events[DataSourceChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnDefaultCellStyleChanged(EventArgs e)
	{
		((EventHandler)base.Events[DefaultCellStyleChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnDefaultValuesNeeded(DataGridViewRowEventArgs e)
	{
		((DataGridViewRowEventHandler)base.Events[DefaultValuesNeededEvent])?.Invoke(this, e);
	}

	protected override void OnDoubleClick(EventArgs e)
	{
		base.OnDoubleClick(e);
		Point point = PointToClient(Control.MousePosition);
		HitTestInfo hitTestInfo = HitTest(point.X, point.Y);
		if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
		{
			OnCellDoubleClick(new DataGridViewCellEventArgs(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex));
		}
	}

	protected virtual void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
	{
		((DataGridViewEditingControlShowingEventHandler)base.Events[EditingControlShowingEvent])?.Invoke(this, e);
	}

	protected virtual void OnEditModeChanged(EventArgs e)
	{
		((EventHandler)base.Events[EditModeChangedEvent])?.Invoke(this, e);
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		base.OnEnabledChanged(e);
	}

	protected override void OnEnter(EventArgs e)
	{
		base.OnEnter(e);
	}

	protected override void OnGotFocus(EventArgs e)
	{
		base.OnGotFocus(e);
		if (currentCell != null && ShowFocusCues)
		{
			InvalidateCell(currentCell);
		}
	}

	protected override void OnFontChanged(EventArgs e)
	{
		base.OnFontChanged(e);
	}

	protected override void OnForeColorChanged(EventArgs e)
	{
		base.OnForeColorChanged(e);
	}

	protected virtual void OnGridColorChanged(EventArgs e)
	{
		((EventHandler)base.Events[GridColorChangedEvent])?.Invoke(this, e);
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		ReBind();
		if (DataManager == null && CurrentCell == null && Rows.Count > 0 && Columns.Count > 0)
		{
			MoveCurrentCell(ColumnDisplayIndexToIndex(0), 0, select: true, isControl: false, isShift: false, scroll: false);
		}
	}

	protected override void OnHandleDestroyed(EventArgs e)
	{
		base.OnHandleDestroyed(e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected override void OnKeyDown(KeyEventArgs e)
	{
		base.OnKeyDown(e);
		e.Handled = ProcessDataGridViewKey(e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected override void OnKeyPress(KeyPressEventArgs e)
	{
		base.OnKeyPress(e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected override void OnKeyUp(KeyEventArgs e)
	{
		base.OnKeyUp(e);
	}

	protected override void OnLayout(LayoutEventArgs e)
	{
		if (horizontalScrollBar.Visible && verticalScrollBar.Visible)
		{
			horizontalScrollBar.Bounds = new Rectangle(BorderWidth, base.Height - BorderWidth - horizontalScrollBar.Height, base.Width - 2 * BorderWidth - verticalScrollBar.Width, horizontalScrollBar.Height);
			verticalScrollBar.Bounds = new Rectangle(base.Width - BorderWidth - verticalScrollBar.Width, BorderWidth, verticalScrollBar.Width, base.Height - 2 * BorderWidth - horizontalScrollBar.Height);
		}
		else if (horizontalScrollBar.Visible)
		{
			horizontalScrollBar.Bounds = new Rectangle(BorderWidth, base.Height - BorderWidth - horizontalScrollBar.Height, base.Width - 2 * BorderWidth, horizontalScrollBar.Height);
		}
		else if (verticalScrollBar.Visible)
		{
			verticalScrollBar.Bounds = new Rectangle(base.Width - BorderWidth - verticalScrollBar.Width, BorderWidth, verticalScrollBar.Width, base.Height - 2 * BorderWidth);
		}
		AutoResizeColumnsInternal();
		Invalidate();
	}

	protected override void OnLeave(EventArgs e)
	{
		EndEdit(DataGridViewDataErrorContexts.LeaveControl);
		base.OnLeave(e);
	}

	protected override void OnLostFocus(EventArgs e)
	{
		base.OnLostFocus(e);
		if (currentCell != null && ShowFocusCues)
		{
			InvalidateCell(currentCell);
		}
	}

	protected override void OnMouseClick(MouseEventArgs e)
	{
		base.OnMouseClick(e);
		if (column_resize_active || row_resize_active)
		{
			return;
		}
		HitTestInfo hitTestInfo = HitTest(e.X, e.Y);
		switch (hitTestInfo.Type)
		{
		case DataGridViewHitTestType.Cell:
		{
			Rectangle cellDisplayRectangle2 = GetCellDisplayRectangle(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex, cutOverflow: false);
			Point pt = new Point(e.X - cellDisplayRectangle2.X, e.Y - cellDisplayRectangle2.Y);
			OnCellMouseClick(new DataGridViewCellMouseEventArgs(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex, pt.X, pt.Y, e));
			if (GetCellInternal(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex).GetContentBounds(hitTestInfo.RowIndex).Contains(pt))
			{
				DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex);
				OnCellContentClick(e2);
			}
			break;
		}
		case DataGridViewHitTestType.ColumnHeader:
		{
			Rectangle cellDisplayRectangle = GetCellDisplayRectangle(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex, cutOverflow: false);
			Point point = new Point(e.X - cellDisplayRectangle.X, e.Y - cellDisplayRectangle.Y);
			OnColumnHeaderMouseClick(new DataGridViewCellMouseEventArgs(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex, point.X, point.Y, e));
			break;
		}
		}
	}

	protected override void OnMouseDoubleClick(MouseEventArgs e)
	{
		base.OnMouseDoubleClick(e);
		HitTestInfo hitTestInfo = HitTest(e.X, e.Y);
		if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
		{
			OnCellMouseDoubleClick(new DataGridViewCellMouseEventArgs(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex, hitTestInfo.ColumnX, hitTestInfo.RowY, e));
		}
	}

	private void DoSelectionOnMouseDown(HitTestInfo hitTest)
	{
		Keys modifierKeys = Control.ModifierKeys;
		bool flag = (modifierKeys & Keys.Control) != 0;
		bool flag2 = (modifierKeys & Keys.Shift) != 0;
		DataGridViewSelectionMode dataGridViewSelectionMode;
		switch (hitTest.Type)
		{
		default:
			return;
		case DataGridViewHitTestType.Cell:
			dataGridViewSelectionMode = selectionMode;
			break;
		case DataGridViewHitTestType.ColumnHeader:
			dataGridViewSelectionMode = ((selectionMode == DataGridViewSelectionMode.ColumnHeaderSelect) ? DataGridViewSelectionMode.FullColumnSelect : selectionMode);
			if (dataGridViewSelectionMode != DataGridViewSelectionMode.FullColumnSelect)
			{
				return;
			}
			break;
		case DataGridViewHitTestType.RowHeader:
			dataGridViewSelectionMode = ((selectionMode == DataGridViewSelectionMode.RowHeaderSelect) ? DataGridViewSelectionMode.FullRowSelect : selectionMode);
			if (dataGridViewSelectionMode != DataGridViewSelectionMode.FullRowSelect)
			{
				return;
			}
			break;
		}
		if (!flag)
		{
			if (!flag2)
			{
				selected_row = hitTest.RowIndex;
				selected_column = hitTest.ColumnIndex;
			}
			if (!flag2)
			{
				if (selected_row != -1)
				{
					selected_row = hitTest.RowIndex;
				}
				if (selected_column != -1)
				{
					selected_column = hitTest.ColumnIndex;
				}
			}
			int num;
			int num2;
			if (selected_row >= hitTest.RowIndex)
			{
				num = hitTest.RowIndex;
				num2 = (flag2 ? selected_row : num);
			}
			else
			{
				num2 = hitTest.RowIndex;
				num = (flag2 ? selected_row : num2);
			}
			int num3;
			int num4;
			if (selected_column >= hitTest.ColumnIndex)
			{
				num3 = hitTest.ColumnIndex;
				num4 = (flag2 ? selected_column : num3);
			}
			else
			{
				num4 = hitTest.ColumnIndex;
				num3 = (flag2 ? selected_column : num4);
			}
			switch (dataGridViewSelectionMode)
			{
			case DataGridViewSelectionMode.FullRowSelect:
			{
				for (int num5 = 0; num5 < RowCount; num5++)
				{
					bool flag5 = num5 >= num && num5 <= num2;
					if (!flag5)
					{
						for (int num6 = 0; num6 < ColumnCount; num6++)
						{
							if (Rows[num5].Cells[num6].Selected)
							{
								SetSelectedCellCore(num6, num5, selected: false);
							}
						}
					}
					if (flag5 != Rows[num5].Selected)
					{
						SetSelectedRowCore(num5, flag5);
					}
				}
				break;
			}
			case DataGridViewSelectionMode.FullColumnSelect:
			{
				for (int m = 0; m < ColumnCount; m++)
				{
					bool flag4 = m >= num3 && m <= num4;
					if (!flag4)
					{
						for (int n = 0; n < RowCount; n++)
						{
							if (Rows[n].Cells[m].Selected)
							{
								SetSelectedCellCore(m, n, selected: false);
							}
						}
					}
					if (flag4 != Columns[m].Selected)
					{
						SetSelectedColumnCore(m, flag4);
					}
				}
				break;
			}
			case DataGridViewSelectionMode.CellSelect:
			case DataGridViewSelectionMode.RowHeaderSelect:
			case DataGridViewSelectionMode.ColumnHeaderSelect:
			{
				if (!flag2)
				{
					for (int i = 0; i < ColumnCount; i++)
					{
						if (columns[i].Selected)
						{
							SetSelectedColumnCore(i, selected: false);
						}
					}
					for (int j = 0; j < RowCount; j++)
					{
						if (rows[j].Selected)
						{
							SetSelectedRowCore(j, selected: false);
						}
					}
				}
				for (int k = 0; k < RowCount; k++)
				{
					for (int l = 0; l < ColumnCount; l++)
					{
						bool flag3 = k >= num && k <= num2 && l >= num3 && l <= num4;
						if (flag3 != Rows[k].Cells[l].Selected)
						{
							SetSelectedCellCore(l, k, flag3);
						}
					}
				}
				break;
			}
			}
		}
		else
		{
			if (!flag)
			{
				return;
			}
			switch (dataGridViewSelectionMode)
			{
			case DataGridViewSelectionMode.FullRowSelect:
				SetSelectedRowCore(hitTest.RowIndex, !rows[hitTest.RowIndex].Selected);
				break;
			case DataGridViewSelectionMode.FullColumnSelect:
				SetSelectedColumnCore(hitTest.ColumnIndex, !columns[hitTest.ColumnIndex].Selected);
				break;
			case DataGridViewSelectionMode.CellSelect:
			case DataGridViewSelectionMode.RowHeaderSelect:
			case DataGridViewSelectionMode.ColumnHeaderSelect:
				if (hitTest.ColumnIndex >= 0 && hitTest.RowIndex >= 0)
				{
					SetSelectedCellCore(hitTest.ColumnIndex, hitTest.RowIndex, !Rows[hitTest.RowIndex].Cells[hitTest.ColumnIndex].Selected);
				}
				break;
			}
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (!EndEdit())
		{
			return;
		}
		HitTestInfo hitTestInfo = HitTest(e.X, e.Y);
		DataGridViewCell dataGridViewCell = null;
		if ((hitTestInfo.Type == DataGridViewHitTestType.ColumnHeader || (hitTestInfo.Type == DataGridViewHitTestType.Cell && !ColumnHeadersVisible)) && MouseOverColumnResize(hitTestInfo.ColumnIndex, e.X))
		{
			if (e.Clicks == 2)
			{
				AutoResizeColumn(hitTestInfo.ColumnIndex);
				return;
			}
			resize_band = hitTestInfo.ColumnIndex;
			column_resize_active = true;
			resize_band_start = e.X;
			resize_band_delta = 0;
			DrawVerticalResizeLine(resize_band_start);
			return;
		}
		if ((hitTestInfo.Type == DataGridViewHitTestType.RowHeader || (hitTestInfo.Type == DataGridViewHitTestType.Cell && !RowHeadersVisible)) && MouseOverRowResize(hitTestInfo.RowIndex, e.Y))
		{
			if (e.Clicks == 2)
			{
				AutoResizeRow(hitTestInfo.RowIndex);
				return;
			}
			resize_band = hitTestInfo.RowIndex;
			row_resize_active = true;
			resize_band_start = e.Y;
			resize_band_delta = 0;
			DrawHorizontalResizeLine(resize_band_start);
			return;
		}
		if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
		{
			dataGridViewCell = rows[hitTestInfo.RowIndex].Cells[hitTestInfo.ColumnIndex];
			SetCurrentCellAddressCore(dataGridViewCell.ColumnIndex, dataGridViewCell.RowIndex, setAnchorCellAddress: false, validateCurrentCell: true, throughMouseClick: true);
			Rectangle cellDisplayRectangle = GetCellDisplayRectangle(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex, cutOverflow: false);
			OnCellMouseDown(new DataGridViewCellMouseEventArgs(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex, e.X - cellDisplayRectangle.X, e.Y - cellDisplayRectangle.Y, e));
			OnCellClick(new DataGridViewCellEventArgs(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex));
		}
		DoSelectionOnMouseDown(hitTestInfo);
		if (hitTestInfo.Type != DataGridViewHitTestType.Cell)
		{
			if (hitTestInfo.Type == DataGridViewHitTestType.ColumnHeader)
			{
				pressed_header_cell = columns[hitTestInfo.ColumnIndex].HeaderCell;
			}
			else if (hitTestInfo.Type == DataGridViewHitTestType.RowHeader)
			{
				pressed_header_cell = rows[hitTestInfo.RowIndex].HeaderCell;
			}
			Invalidate();
		}
		else
		{
			Invalidate();
		}
	}

	private void UpdateBindingPosition(int position)
	{
		if (DataManager != null)
		{
			DataManager.Position = position;
		}
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		base.OnMouseEnter(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		if (hover_cell != null)
		{
			OnCellMouseLeave(new DataGridViewCellEventArgs(hover_cell.ColumnIndex, hover_cell.RowIndex));
			hover_cell = null;
		}
		EnteredHeaderCell = null;
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		if (column_resize_active)
		{
			DrawVerticalResizeLine(resize_band_start + resize_band_delta);
			resize_band_delta = e.X - resize_band_start;
			DrawVerticalResizeLine(resize_band_start + resize_band_delta);
			return;
		}
		if (row_resize_active)
		{
			DrawHorizontalResizeLine(resize_band_start + resize_band_delta);
			resize_band_delta = e.Y - resize_band_start;
			DrawHorizontalResizeLine(resize_band_start + resize_band_delta);
			return;
		}
		Cursor cursor = Cursors.Default;
		HitTestInfo hitTestInfo = HitTest(e.X, e.Y);
		if (hitTestInfo.Type == DataGridViewHitTestType.ColumnHeader || (!ColumnHeadersVisible && hitTestInfo.Type == DataGridViewHitTestType.Cell && MouseOverColumnResize(hitTestInfo.ColumnIndex, e.X)))
		{
			EnteredHeaderCell = Columns[hitTestInfo.ColumnIndex].HeaderCell;
			if (MouseOverColumnResize(hitTestInfo.ColumnIndex, e.X))
			{
				cursor = Cursors.VSplit;
			}
		}
		else if (!RowHeadersVisible && hitTestInfo.Type == DataGridViewHitTestType.Cell && MouseOverRowResize(hitTestInfo.RowIndex, e.Y))
		{
			EnteredHeaderCell = Rows[hitTestInfo.RowIndex].HeaderCell;
			cursor = Cursors.HSplit;
		}
		else
		{
			if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
			{
				EnteredHeaderCell = null;
				DataGridViewCell cellInternal = GetCellInternal(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex);
				Rectangle errorIconBounds = cellInternal.ErrorIconBounds;
				if (!errorIconBounds.IsEmpty)
				{
					Point location = GetCellDisplayRectangle(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex, cutOverflow: false).Location;
					errorIconBounds.X += location.X;
					errorIconBounds.Y += location.Y;
					if (errorIconBounds.Contains(e.X, e.Y))
					{
						if (tooltip_currently_showing != cellInternal)
						{
							MouseEnteredErrorIcon(cellInternal);
						}
					}
					else
					{
						MouseLeftErrorIcon(cellInternal);
					}
				}
				Cursor = cursor;
				if (hover_cell == null)
				{
					hover_cell = cellInternal;
					OnCellMouseEnter(new DataGridViewCellEventArgs(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex));
					Rectangle cellDisplayRectangle = GetCellDisplayRectangle(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex, cutOverflow: false);
					OnCellMouseMove(new DataGridViewCellMouseEventArgs(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex, e.X - cellDisplayRectangle.X, e.Y - cellDisplayRectangle.Y, e));
				}
				else if (hover_cell.RowIndex == hitTestInfo.RowIndex && hover_cell.ColumnIndex == hitTestInfo.ColumnIndex)
				{
					Rectangle cellDisplayRectangle2 = GetCellDisplayRectangle(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex, cutOverflow: false);
					OnCellMouseMove(new DataGridViewCellMouseEventArgs(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex, e.X - cellDisplayRectangle2.X, e.Y - cellDisplayRectangle2.Y, e));
				}
				else
				{
					OnCellMouseLeave(new DataGridViewCellEventArgs(hover_cell.ColumnIndex, hover_cell.RowIndex));
					hover_cell = cellInternal;
					OnCellMouseEnter(new DataGridViewCellEventArgs(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex));
					Rectangle cellDisplayRectangle3 = GetCellDisplayRectangle(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex, cutOverflow: false);
					OnCellMouseMove(new DataGridViewCellMouseEventArgs(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex, e.X - cellDisplayRectangle3.X, e.Y - cellDisplayRectangle3.Y, e));
				}
				return;
			}
			if (hitTestInfo.Type == DataGridViewHitTestType.RowHeader)
			{
				DataGridViewRowHeaderCell dataGridViewRowHeaderCell = (DataGridViewRowHeaderCell)(EnteredHeaderCell = Rows[hitTestInfo.RowIndex].HeaderCell);
				if (MouseOverRowResize(hitTestInfo.RowIndex, e.Y))
				{
					cursor = Cursors.HSplit;
				}
				Rectangle internalErrorIconsBounds = dataGridViewRowHeaderCell.InternalErrorIconsBounds;
				if (!internalErrorIconsBounds.IsEmpty)
				{
					Point location2 = GetCellDisplayRectangle(0, hitTestInfo.RowIndex, cutOverflow: false).Location;
					internalErrorIconsBounds.X += BorderWidth;
					internalErrorIconsBounds.Y += location2.Y;
					if (internalErrorIconsBounds.Contains(e.X, e.Y))
					{
						if (tooltip_currently_showing != dataGridViewRowHeaderCell)
						{
							MouseEnteredErrorIcon(dataGridViewRowHeaderCell);
						}
					}
					else
					{
						MouseLeftErrorIcon(dataGridViewRowHeaderCell);
					}
				}
			}
			else if (hitTestInfo.Type == DataGridViewHitTestType.TopLeftHeader)
			{
				EnteredHeaderCell = null;
				DataGridViewTopLeftHeaderCell dataGridViewTopLeftHeaderCell = (DataGridViewTopLeftHeaderCell)TopLeftHeaderCell;
				Rectangle internalErrorIconsBounds2 = dataGridViewTopLeftHeaderCell.InternalErrorIconsBounds;
				if (!internalErrorIconsBounds2.IsEmpty)
				{
					Point empty = Point.Empty;
					internalErrorIconsBounds2.X += BorderWidth;
					internalErrorIconsBounds2.Y += empty.Y;
					if (internalErrorIconsBounds2.Contains(e.X, e.Y))
					{
						if (tooltip_currently_showing != dataGridViewTopLeftHeaderCell)
						{
							MouseEnteredErrorIcon(dataGridViewTopLeftHeaderCell);
						}
					}
					else
					{
						MouseLeftErrorIcon(dataGridViewTopLeftHeaderCell);
					}
				}
			}
			else
			{
				EnteredHeaderCell = null;
				if (hover_cell != null)
				{
					OnCellMouseLeave(new DataGridViewCellEventArgs(hover_cell.ColumnIndex, hover_cell.RowIndex));
					hover_cell = null;
				}
			}
		}
		Cursor = cursor;
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		base.OnMouseUp(e);
		if (column_resize_active)
		{
			column_resize_active = false;
			if (resize_band_delta + Columns[resize_band].Width < 0)
			{
				resize_band_delta = -Columns[resize_band].Width;
			}
			Columns[resize_band].Width = Math.Max(resize_band_delta + Columns[resize_band].Width, Columns[resize_band].MinimumWidth);
			Invalidate();
			return;
		}
		if (row_resize_active)
		{
			row_resize_active = false;
			if (resize_band_delta + Rows[resize_band].Height < 0)
			{
				resize_band_delta = -Rows[resize_band].Height;
			}
			Rows[resize_band].Height = Math.Max(resize_band_delta + Rows[resize_band].Height, Rows[resize_band].MinimumHeight);
			Invalidate();
			return;
		}
		HitTestInfo hitTestInfo = HitTest(e.X, e.Y);
		if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
		{
			Rectangle cellDisplayRectangle = GetCellDisplayRectangle(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex, cutOverflow: false);
			OnCellMouseUp(new DataGridViewCellMouseEventArgs(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex, e.X - cellDisplayRectangle.X, e.Y - cellDisplayRectangle.Y, e));
		}
		if (pressed_header_cell != null)
		{
			DataGridViewHeaderCell cell = pressed_header_cell;
			pressed_header_cell = null;
			if (ThemeEngine.Current.DataGridViewHeaderCellHasPressedStyle(this))
			{
				Invalidate(GetHeaderCellBounds(cell));
			}
		}
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		base.OnMouseWheel(e);
		int num = SystemInformation.MouseWheelScrollLines * verticalScrollBar.SmallChange;
		if (e.Delta < 0)
		{
			verticalScrollBar.SafeValueSet(verticalScrollBar.Value + num);
		}
		else
		{
			verticalScrollBar.SafeValueSet(verticalScrollBar.Value - num);
		}
		OnVScrollBarScroll(this, new ScrollEventArgs(ScrollEventType.ThumbPosition, verticalScrollBar.Value, ScrollOrientation.VerticalScroll));
	}

	protected virtual void OnMultiSelectChanged(EventArgs e)
	{
		((EventHandler)base.Events[MultiSelectChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnNewRowNeeded(DataGridViewRowEventArgs e)
	{
		((DataGridViewRowEventHandler)base.Events[NewRowNeededEvent])?.Invoke(this, e);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		Rectangle clientRectangle = base.ClientRectangle;
		PaintBackground(graphics, e.ClipRectangle, clientRectangle);
		List<DataGridViewColumn> columnDisplayIndexSortedArrayList = columns.ColumnDisplayIndexSortedArrayList;
		clientRectangle.Inflate(-BorderWidth, -BorderWidth);
		if (rowHeadersVisible && columnHeadersVisible && ColumnCount > 0)
		{
			Rectangle cellBounds = new Rectangle(clientRectangle.X, clientRectangle.Y, rowHeadersWidth, columnHeadersHeight);
			TopLeftHeaderCell.PaintWork(graphics, e.ClipRectangle, cellBounds, -1, TopLeftHeaderCell.State, ColumnHeadersDefaultCellStyle, AdvancedColumnHeadersBorderStyle, DataGridViewPaintParts.All);
		}
		if (columnHeadersVisible)
		{
			Rectangle cellBounds2 = clientRectangle;
			cellBounds2.Height = columnHeadersHeight;
			if (rowHeadersVisible)
			{
				cellBounds2.X += rowHeadersWidth;
			}
			for (int i = first_col_index; i < columnDisplayIndexSortedArrayList.Count; i++)
			{
				DataGridViewColumn dataGridViewColumn = columnDisplayIndexSortedArrayList[i];
				if (dataGridViewColumn.Visible)
				{
					cellBounds2.Width = dataGridViewColumn.Width;
					DataGridViewCell headerCell = dataGridViewColumn.HeaderCell;
					DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStylePlaceholder = (DataGridViewAdvancedBorderStyle)((ICloneable)AdvancedColumnHeadersBorderStyle).Clone();
					DataGridViewAdvancedBorderStyle advancedBorderStyle = AdjustColumnHeaderBorderStyle(AdvancedColumnHeadersBorderStyle, dataGridViewAdvancedBorderStylePlaceholder, headerCell.ColumnIndex == 0, headerCell.ColumnIndex == columns.Count - 1);
					headerCell.PaintWork(graphics, e.ClipRectangle, cellBounds2, -1, headerCell.State, headerCell.InheritedStyle, advancedBorderStyle, DataGridViewPaintParts.All);
					cellBounds2.X += dataGridViewColumn.Width;
				}
			}
			clientRectangle.Y += columnHeadersHeight;
		}
		for (int j = 0; j < first_col_index; j++)
		{
			Columns[j].DisplayedInternal = false;
		}
		int num = (rowHeadersVisible ? rowHeadersWidth : 0);
		for (int k = first_col_index; k < Columns.Count; k++)
		{
			DataGridViewColumn dataGridViewColumn2 = Columns.ColumnDisplayIndexSortedArrayList[k];
			if (dataGridViewColumn2.Visible)
			{
				dataGridViewColumn2.DisplayedInternal = true;
				num += dataGridViewColumn2.Width;
				if (num >= base.Width)
				{
					break;
				}
			}
		}
		for (int l = 0; l < first_row_index; l++)
		{
			GetRowInternal(l).DisplayedInternal = false;
		}
		for (int m = first_row_index; m < Rows.Count; m++)
		{
			DataGridViewRow dataGridViewRow = Rows[m];
			if (dataGridViewRow.Visible)
			{
				GetRowInternal(m).DisplayedInternal = true;
				clientRectangle.Height = dataGridViewRow.Height;
				bool isFirstDisplayedRow = dataGridViewRow.Index == 0;
				bool isLastVisibleRow = dataGridViewRow.Index == rows.Count - 1;
				dataGridViewRow.Paint(graphics, e.ClipRectangle, clientRectangle, dataGridViewRow.Index, dataGridViewRow.GetState(dataGridViewRow.Index), isFirstDisplayedRow, isLastVisibleRow);
				clientRectangle.Y += clientRectangle.Height;
				clientRectangle.X = BorderWidth;
				if (clientRectangle.Y >= base.ClientSize.Height - (horizontalScrollBar.Visible ? horizontalScrollBar.Height : 0))
				{
					break;
				}
			}
		}
		RefreshScrollBars();
		if (horizontalScrollBar.Visible && verticalScrollBar.Visible)
		{
			graphics.FillRectangle(SystemBrushes.Control, new Rectangle(horizontalScrollBar.Right, verticalScrollBar.Bottom, verticalScrollBar.Width, horizontalScrollBar.Height));
		}
		clientRectangle = base.ClientRectangle;
		switch (BorderStyle)
		{
		case BorderStyle.FixedSingle:
			graphics.DrawRectangle(Pens.Black, new Rectangle(clientRectangle.Left, clientRectangle.Top, clientRectangle.Width - 1, clientRectangle.Height - 1));
			break;
		case BorderStyle.Fixed3D:
			ControlPaint.DrawBorder3D(graphics, clientRectangle, Border3DStyle.Sunken);
			break;
		}
		base.OnPaint(e);
	}

	private void RefreshScrollBars()
	{
		int num = 0;
		int num2 = 0;
		foreach (DataGridViewColumn columnDisplayIndexSortedArray in columns.ColumnDisplayIndexSortedArrayList)
		{
			if (columnDisplayIndexSortedArray.Visible)
			{
				num += columnDisplayIndexSortedArray.Width;
			}
		}
		foreach (DataGridViewRow item in (IEnumerable)Rows)
		{
			if (item.Visible)
			{
				num2 += item.Height;
			}
		}
		if (rowHeadersVisible)
		{
			num += rowHeadersWidth;
		}
		if (columnHeadersVisible)
		{
			num2 += columnHeadersHeight;
		}
		bool flag = false;
		bool flag2 = false;
		if (AutoSize)
		{
			if (num > base.Size.Width || num2 > base.Size.Height)
			{
				base.Size = new Size(num, num2);
			}
		}
		else
		{
			if (num > base.Size.Width)
			{
				flag = true;
			}
			if (num2 > base.Size.Height)
			{
				flag2 = true;
			}
			if (horizontalScrollBar.Visible && num2 + horizontalScrollBar.Height > base.Size.Height)
			{
				flag2 = true;
			}
			if (verticalScrollBar.Visible && num + verticalScrollBar.Width > base.Size.Width)
			{
				flag = true;
			}
			if (flag)
			{
				horizontalScrollBar.Minimum = 0;
				horizontalScrollBar.Maximum = num;
				horizontalScrollBar.SmallChange = Columns[first_col_index].Width;
				int num3 = base.ClientSize.Width - rowHeadersWidth - horizontalScrollBar.Height;
				if (num3 <= 0)
				{
					num3 = base.ClientSize.Width;
				}
				horizontalScrollBar.LargeChange = num3;
			}
			if (flag2)
			{
				verticalScrollBar.Minimum = 0;
				verticalScrollBar.Maximum = num2;
				int num4 = ((Rows.Count > 0) ? Rows[Math.Min(Rows.Count - 1, first_row_index)].Height : 0);
				verticalScrollBar.SmallChange = num4 + 1;
				int num5 = base.ClientSize.Height - columnHeadersHeight - verticalScrollBar.Width;
				if (num5 <= 0)
				{
					num5 = base.ClientSize.Height;
				}
				verticalScrollBar.LargeChange = num5;
			}
			if (scrollBars != ScrollBars.Vertical && scrollBars != ScrollBars.Both)
			{
				flag2 = false;
			}
			if (scrollBars != ScrollBars.Horizontal && scrollBars != ScrollBars.Both)
			{
				flag = false;
			}
			if (RowCount <= 1)
			{
				flag2 = false;
			}
		}
		horizontalScrollBar.Visible = flag;
		verticalScrollBar.Visible = flag2;
	}

	protected virtual void OnReadOnlyChanged(EventArgs e)
	{
		((EventHandler)base.Events[ReadOnlyChangedEvent])?.Invoke(this, e);
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		AutoResizeColumnsInternal();
		OnVScrollBarScroll(this, new ScrollEventArgs(ScrollEventType.ThumbPosition, verticalScrollBar.Value, ScrollOrientation.VerticalScroll));
		OnHScrollBarScroll(this, new ScrollEventArgs(ScrollEventType.ThumbPosition, horizontalScrollBar.Value, ScrollOrientation.HorizontalScroll));
	}

	protected override void OnRightToLeftChanged(EventArgs e)
	{
		base.OnRightToLeftChanged(e);
	}

	protected internal virtual void OnRowContextMenuStripChanged(DataGridViewRowEventArgs e)
	{
		((DataGridViewRowEventHandler)base.Events[RowContextMenuStripChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnRowContextMenuStripNeeded(DataGridViewRowContextMenuStripNeededEventArgs e)
	{
		((DataGridViewRowContextMenuStripNeededEventHandler)base.Events[RowContextMenuStripNeededEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnRowDefaultCellStyleChanged(DataGridViewRowEventArgs e)
	{
		((DataGridViewRowEventHandler)base.Events[RowDefaultCellStyleChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnRowDirtyStateNeeded(QuestionEventArgs e)
	{
		((QuestionEventHandler)base.Events[RowDirtyStateNeededEvent])?.Invoke(this, e);
	}

	protected virtual void OnRowDividerDoubleClick(DataGridViewRowDividerDoubleClickEventArgs e)
	{
		((DataGridViewRowDividerDoubleClickEventHandler)base.Events[RowDividerDoubleClickEvent])?.Invoke(this, e);
	}

	protected virtual void OnRowDividerHeightChanged(DataGridViewRowEventArgs e)
	{
		((DataGridViewRowEventHandler)base.Events[RowDividerHeightChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnRowEnter(DataGridViewCellEventArgs e)
	{
		((DataGridViewCellEventHandler)base.Events[RowEnterEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnRowErrorTextChanged(DataGridViewRowEventArgs e)
	{
		((DataGridViewRowEventHandler)base.Events[RowErrorTextChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnRowErrorTextNeeded(DataGridViewRowErrorTextNeededEventArgs e)
	{
		((DataGridViewRowErrorTextNeededEventHandler)base.Events[RowErrorTextNeededEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnRowHeaderCellChanged(DataGridViewRowEventArgs e)
	{
		((DataGridViewRowEventHandler)base.Events[RowHeaderCellChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnRowHeaderMouseClick(DataGridViewCellMouseEventArgs e)
	{
		((DataGridViewCellMouseEventHandler)base.Events[RowHeaderMouseClickEvent])?.Invoke(this, e);
	}

	protected virtual void OnRowHeaderMouseDoubleClick(DataGridViewCellMouseEventArgs e)
	{
		((DataGridViewCellMouseEventHandler)base.Events[RowHeaderMouseDoubleClickEvent])?.Invoke(this, e);
	}

	protected virtual void OnRowHeadersBorderStyleChanged(EventArgs e)
	{
		((EventHandler)base.Events[RowHeadersBorderStyleChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnRowHeadersDefaultCellStyleChanged(EventArgs e)
	{
		((EventHandler)base.Events[RowHeadersDefaultCellStyleChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnRowHeadersWidthChanged(EventArgs e)
	{
		((EventHandler)base.Events[RowHeadersWidthChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnRowHeadersWidthSizeModeChanged(DataGridViewAutoSizeModeEventArgs e)
	{
		((DataGridViewAutoSizeModeEventHandler)base.Events[RowHeadersWidthSizeModeChangedEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnRowHeightChanged(DataGridViewRowEventArgs e)
	{
		UpdateRowHeightInfo(e.Row.Index, updateToEnd: false);
		((DataGridViewRowEventHandler)base.Events[RowHeightChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnRowHeightInfoNeeded(DataGridViewRowHeightInfoNeededEventArgs e)
	{
		((DataGridViewRowHeightInfoNeededEventHandler)base.Events[RowHeightInfoNeededEvent])?.Invoke(this, e);
	}

	protected virtual void OnRowHeightInfoPushed(DataGridViewRowHeightInfoPushedEventArgs e)
	{
		((DataGridViewRowHeightInfoPushedEventHandler)base.Events[RowHeightInfoPushedEvent])?.Invoke(this, e);
	}

	protected virtual void OnRowLeave(DataGridViewCellEventArgs e)
	{
		((DataGridViewCellEventHandler)base.Events[RowLeaveEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnRowMinimumHeightChanged(DataGridViewRowEventArgs e)
	{
		((DataGridViewRowEventHandler)base.Events[RowMinimumHeightChangedEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
	{
		((DataGridViewRowPostPaintEventHandler)base.Events[RowPostPaintEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnRowPrePaint(DataGridViewRowPrePaintEventArgs e)
	{
		((DataGridViewRowPrePaintEventHandler)base.Events[RowPrePaintEvent])?.Invoke(this, e);
	}

	internal void OnRowsAddedInternal(DataGridViewRowsAddedEventArgs e)
	{
		if (hover_cell != null && hover_cell.RowIndex >= e.RowIndex)
		{
			hover_cell = null;
		}
		if (base.IsHandleCreated && DataManager == null && CurrentCell == null && Rows.Count > 0 && Columns.Count > 0)
		{
			MoveCurrentCell(ColumnDisplayIndexToIndex(0), 0, select: true, isControl: false, isShift: false, scroll: true);
		}
		AutoResizeColumnsInternal();
		if (VirtualMode)
		{
			for (int i = 0; i < e.RowCount; i++)
			{
				UpdateRowHeightInfo(e.RowIndex + i, updateToEnd: false);
			}
		}
		Invalidate();
		OnRowsAdded(e);
	}

	protected virtual void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
	{
		((DataGridViewRowsAddedEventHandler)base.Events[RowsAddedEvent])?.Invoke(this, e);
	}

	protected virtual void OnRowsDefaultCellStyleChanged(EventArgs e)
	{
		((EventHandler)base.Events[RowsDefaultCellStyleChangedEvent])?.Invoke(this, e);
	}

	internal void OnRowsPreRemovedInternal(DataGridViewRowsRemovedEventArgs e)
	{
		if (selected_rows != null)
		{
			int num = e.RowIndex + e.RowCount;
			for (int i = e.RowIndex; i < num; i++)
			{
				SetSelectedRowCore(i, selected: false);
			}
		}
		int num2 = Rows.Count - e.RowCount;
		if (num2 < 0)
		{
			num2 = 0;
		}
		if (num2 == 0)
		{
			MoveCurrentCell(-1, -1, select: true, isControl: false, isShift: false, scroll: true);
			hover_cell = null;
		}
		else if (Columns.Count == 0)
		{
			MoveCurrentCell(-1, -1, select: true, isControl: false, isShift: false, scroll: true);
			hover_cell = null;
		}
		else
		{
			if (currentCell != null && currentCell.RowIndex >= e.RowIndex && currentCell.RowIndex < e.RowIndex + e.RowCount)
			{
				int num3 = e.RowIndex + e.RowCount;
				if (num3 >= Rows.Count)
				{
					num3 = e.RowIndex - 1;
				}
				MoveCurrentCell(currentCell.ColumnIndex, num3, select: true, isControl: false, isShift: false, scroll: true);
			}
			if (hover_cell != null && hover_cell.RowIndex >= e.RowIndex)
			{
				hover_cell = null;
			}
		}
		if (first_row_index > num2 - 1)
		{
			first_row_index = num2 - 1;
		}
		if (first_row_index < 0)
		{
			first_row_index = 0;
		}
	}

	internal void OnRowsPostRemovedInternal(DataGridViewRowsRemovedEventArgs e)
	{
		Invalidate();
		OnRowsRemoved(e);
	}

	protected virtual void OnRowsRemoved(DataGridViewRowsRemovedEventArgs e)
	{
		((DataGridViewRowsRemovedEventHandler)base.Events[RowsRemovedEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnRowStateChanged(int rowIndex, DataGridViewRowStateChangedEventArgs e)
	{
		((DataGridViewRowStateChangedEventHandler)base.Events[RowStateChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnRowUnshared(DataGridViewRowEventArgs e)
	{
		((DataGridViewRowEventHandler)base.Events[RowUnsharedEvent])?.Invoke(this, e);
	}

	protected virtual void OnRowValidated(DataGridViewCellEventArgs e)
	{
		((DataGridViewCellEventHandler)base.Events[RowValidatedEvent])?.Invoke(this, e);
	}

	protected virtual void OnRowValidating(DataGridViewCellCancelEventArgs e)
	{
		((DataGridViewCellCancelEventHandler)base.Events[RowValidatingEvent])?.Invoke(this, e);
	}

	protected virtual void OnScroll(ScrollEventArgs e)
	{
		((ScrollEventHandler)base.Events[ScrollEvent])?.Invoke(this, e);
	}

	protected virtual void OnSelectionChanged(EventArgs e)
	{
		((EventHandler)base.Events[SelectionChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnSortCompare(DataGridViewSortCompareEventArgs e)
	{
		((DataGridViewSortCompareEventHandler)base.Events[SortCompareEvent])?.Invoke(this, e);
	}

	protected virtual void OnSorted(EventArgs e)
	{
		((EventHandler)base.Events[SortedEvent])?.Invoke(this, e);
	}

	protected virtual void OnUserAddedRow(DataGridViewRowEventArgs e)
	{
		PrepareEditingRow(cell_changed: false, column_changed: false);
		new_row_editing = true;
		if (DataManager != null)
		{
			if (editing_row != null)
			{
				Rows.RemoveInternal(editing_row);
				editing_row = null;
			}
			DataManager.AddNew();
		}
		e = new DataGridViewRowEventArgs(Rows[NewRowIndex]);
		((DataGridViewRowEventHandler)base.Events[UserAddedRowEvent])?.Invoke(this, e);
	}

	protected virtual void OnUserDeletedRow(DataGridViewRowEventArgs e)
	{
		((DataGridViewRowEventHandler)base.Events[UserDeletedRowEvent])?.Invoke(this, e);
	}

	protected virtual void OnUserDeletingRow(DataGridViewRowCancelEventArgs e)
	{
		((DataGridViewRowCancelEventHandler)base.Events[UserDeletingRowEvent])?.Invoke(this, e);
	}

	protected override void OnValidating(CancelEventArgs e)
	{
		base.OnValidating(e);
	}

	protected override void OnVisibleChanged(EventArgs e)
	{
		base.OnVisibleChanged(e);
	}

	protected virtual void PaintBackground(Graphics graphics, Rectangle clipBounds, Rectangle gridBounds)
	{
		graphics.FillRectangle(ThemeEngine.Current.ResPool.GetSolidBrush(backgroundColor), gridBounds);
	}

	protected bool ProcessAKey(Keys keyData)
	{
		if (!MultiSelect)
		{
			return false;
		}
		if ((keyData & Keys.Control) == Keys.Control)
		{
			SelectAll();
			return true;
		}
		return false;
	}

	protected virtual bool ProcessDataGridViewKey(KeyEventArgs e)
	{
		switch (e.KeyData & Keys.KeyCode)
		{
		case Keys.A:
			return ProcessAKey(e.KeyData);
		case Keys.Delete:
			return ProcessDeleteKey(e.KeyData);
		case Keys.Down:
			return ProcessDownKey(e.KeyData);
		case Keys.Escape:
			return ProcessEscapeKey(e.KeyData);
		case Keys.End:
			return ProcessEndKey(e.KeyData);
		case Keys.Return:
			return ProcessEnterKey(e.KeyData);
		case Keys.F2:
			return ProcessF2Key(e.KeyData);
		case Keys.Home:
			return ProcessHomeKey(e.KeyData);
		case Keys.Left:
			return ProcessLeftKey(e.KeyData);
		case Keys.PageDown:
			return ProcessNextKey(e.KeyData);
		case Keys.PageUp:
			return ProcessPriorKey(e.KeyData);
		case Keys.Right:
			return ProcessRightKey(e.KeyData);
		case Keys.Space:
			return ProcessSpaceKey(e.KeyData);
		case Keys.Tab:
			return ProcessTabKey(e.KeyData);
		case Keys.Up:
			return ProcessUpKey(e.KeyData);
		case Keys.D0:
		case Keys.NumPad0:
			return ProcessZeroKey(e.KeyData);
		default:
			return false;
		}
	}

	protected bool ProcessDeleteKey(Keys keyData)
	{
		if (!AllowUserToDeleteRows || SelectedRows.Count == 0)
		{
			return false;
		}
		for (int num = SelectedRows.Count - 1; num >= 0; num--)
		{
			DataGridViewRow dataGridViewRow = SelectedRows[num];
			if (!dataGridViewRow.IsNewRow)
			{
				if (hover_cell != null && hover_cell.OwningRow == dataGridViewRow)
				{
					hover_cell = null;
				}
				if (DataManager != null)
				{
					DataManager.RemoveAt(dataGridViewRow.Index);
				}
				else
				{
					Rows.RemoveAt(dataGridViewRow.Index);
				}
			}
		}
		return true;
	}

	protected override bool ProcessDialogKey(Keys keyData)
	{
		switch (keyData)
		{
		case Keys.Tab:
		case Keys.Tab | Keys.Shift:
			if (standardTab)
			{
				return base.ProcessDialogKey(keyData & ~Keys.Control);
			}
			if (ProcessDataGridViewKey(new KeyEventArgs(keyData)))
			{
				return true;
			}
			break;
		case Keys.Tab | Keys.Control:
		case Keys.Tab | Keys.Shift | Keys.Control:
			if (!standardTab)
			{
				return base.ProcessDialogKey(keyData & ~Keys.Control);
			}
			if (ProcessDataGridViewKey(new KeyEventArgs(keyData)))
			{
				return true;
			}
			break;
		case Keys.Return:
		case Keys.Escape:
			if (ProcessDataGridViewKey(new KeyEventArgs(keyData)))
			{
				return true;
			}
			break;
		}
		return base.ProcessDialogKey(keyData);
	}

	protected bool ProcessDownKey(Keys keyData)
	{
		int y = CurrentCellAddress.Y;
		if (y < Rows.Count - 1)
		{
			if ((keyData & Keys.Control) == Keys.Control)
			{
				MoveCurrentCell(CurrentCellAddress.X, Rows.Count - 1, select: true, (keyData & Keys.Control) == Keys.Control, (keyData & Keys.Shift) == Keys.Shift, scroll: true);
			}
			else
			{
				MoveCurrentCell(CurrentCellAddress.X, y + 1, select: true, (keyData & Keys.Control) == Keys.Control, (keyData & Keys.Shift) == Keys.Shift, scroll: true);
			}
			return true;
		}
		return false;
	}

	protected bool ProcessEndKey(Keys keyData)
	{
		int num = ColumnIndexToDisplayIndex(currentCellAddress.X);
		if ((keyData & Keys.Control) == Keys.Control)
		{
			MoveCurrentCell(ColumnDisplayIndexToIndex(Columns.Count - 1), Rows.Count - 1, select: true, (keyData & Keys.Control) == Keys.Control, (keyData & Keys.Shift) == Keys.Shift, scroll: true);
			return true;
		}
		if (num < Columns.Count - 1)
		{
			MoveCurrentCell(ColumnDisplayIndexToIndex(Columns.Count - 1), currentCellAddress.Y, select: true, (keyData & Keys.Control) == Keys.Control, (keyData & Keys.Shift) == Keys.Shift, scroll: true);
			return true;
		}
		return false;
	}

	protected bool ProcessEnterKey(Keys keyData)
	{
		if (ProcessDownKey(keyData))
		{
			return true;
		}
		EndEdit();
		return true;
	}

	protected bool ProcessEscapeKey(Keys keyData)
	{
		if (!IsCurrentCellInEditMode)
		{
			return false;
		}
		CancelEdit();
		return true;
	}

	protected bool ProcessF2Key(Keys keyData)
	{
		if (editMode == DataGridViewEditMode.EditOnF2 || editMode == DataGridViewEditMode.EditOnKeystrokeOrF2)
		{
			BeginEdit(selectAll: true);
			return true;
		}
		return false;
	}

	protected bool ProcessHomeKey(Keys keyData)
	{
		int num = ColumnIndexToDisplayIndex(currentCellAddress.X);
		if ((keyData & Keys.Control) == Keys.Control)
		{
			MoveCurrentCell(ColumnDisplayIndexToIndex(0), 0, select: true, (keyData & Keys.Control) == Keys.Control, (keyData & Keys.Shift) == Keys.Shift, scroll: true);
			return true;
		}
		if (num > 0)
		{
			MoveCurrentCell(ColumnDisplayIndexToIndex(0), currentCellAddress.Y, select: true, (keyData & Keys.Control) == Keys.Control, (keyData & Keys.Shift) == Keys.Shift, scroll: true);
			return true;
		}
		return false;
	}

	[System.MonoInternalNote("What does insert do?")]
	protected bool ProcessInsertKey(Keys keyData)
	{
		return false;
	}

	protected override bool ProcessKeyEventArgs(ref Message m)
	{
		DataGridViewCell dataGridViewCell = CurrentCell;
		if (dataGridViewCell != null)
		{
			if (dataGridViewCell.KeyEntersEditMode(new KeyEventArgs((Keys)(m.WParam.ToInt32() | (int)XplatUI.State.ModifierKeys))))
			{
				BeginEdit(selectAll: true);
			}
			if (EditingControl != null && (m.Msg == 256 || m.Msg == 258))
			{
				XplatUI.SendMessage(EditingControl.Handle, (Msg)m.Msg, m.WParam, m.LParam);
			}
		}
		return base.ProcessKeyEventArgs(ref m);
	}

	protected override bool ProcessKeyPreview(ref Message m)
	{
		if (m.Msg == 256 && (IsCurrentCellInEditMode || m.HWnd == horizontalScrollBar.Handle || m.HWnd == verticalScrollBar.Handle))
		{
			KeyEventArgs e = new KeyEventArgs((Keys)(m.WParam.ToInt32() | (int)XplatUI.State.ModifierKeys));
			IDataGridViewEditingControl dataGridViewEditingControl = (IDataGridViewEditingControl)EditingControlInternal;
			if (dataGridViewEditingControl != null && dataGridViewEditingControl.EditingControlWantsInputKey(e.KeyData, dataGridViewWantsInputKey: false))
			{
				return false;
			}
			switch (e.KeyData)
			{
			case Keys.Tab:
			case Keys.Escape:
			case Keys.PageUp:
			case Keys.PageDown:
			case Keys.Left:
			case Keys.Up:
			case Keys.Right:
			case Keys.Down:
				return ProcessDataGridViewKey(e);
			}
		}
		return base.ProcessKeyPreview(ref m);
	}

	protected bool ProcessLeftKey(Keys keyData)
	{
		int num = ColumnIndexToDisplayIndex(currentCellAddress.X);
		if (num > 0)
		{
			if ((keyData & Keys.Control) == Keys.Control)
			{
				MoveCurrentCell(ColumnDisplayIndexToIndex(0), currentCellAddress.Y, select: true, (keyData & Keys.Control) == Keys.Control, (keyData & Keys.Shift) == Keys.Shift, scroll: true);
			}
			else
			{
				MoveCurrentCell(ColumnDisplayIndexToIndex(num - 1), currentCellAddress.Y, select: true, (keyData & Keys.Control) == Keys.Control, (keyData & Keys.Shift) == Keys.Shift, scroll: true);
			}
			return true;
		}
		return false;
	}

	protected bool ProcessNextKey(Keys keyData)
	{
		int y = CurrentCellAddress.Y;
		if (y < Rows.Count - 1)
		{
			int y2 = Math.Min(Rows.Count - 1, y + DisplayedRowCount(includePartialRow: false));
			MoveCurrentCell(CurrentCellAddress.X, y2, select: true, (keyData & Keys.Control) == Keys.Control, (keyData & Keys.Shift) == Keys.Shift, scroll: true);
			return true;
		}
		return false;
	}

	protected bool ProcessPriorKey(Keys keyData)
	{
		int y = CurrentCellAddress.Y;
		if (y > 0)
		{
			int y2 = Math.Max(0, y - DisplayedRowCount(includePartialRow: false));
			MoveCurrentCell(CurrentCellAddress.X, y2, select: true, (keyData & Keys.Control) == Keys.Control, (keyData & Keys.Shift) == Keys.Shift, scroll: true);
			return true;
		}
		return false;
	}

	protected bool ProcessRightKey(Keys keyData)
	{
		int num = ColumnIndexToDisplayIndex(currentCellAddress.X);
		if (num < Columns.Count - 1)
		{
			if ((keyData & Keys.Control) == Keys.Control)
			{
				MoveCurrentCell(ColumnDisplayIndexToIndex(Columns.Count - 1), currentCellAddress.Y, select: true, (keyData & Keys.Control) == Keys.Control, (keyData & Keys.Shift) == Keys.Shift, scroll: true);
			}
			else
			{
				MoveCurrentCell(ColumnDisplayIndexToIndex(num + 1), currentCellAddress.Y, select: true, (keyData & Keys.Control) == Keys.Control, (keyData & Keys.Shift) == Keys.Shift, scroll: true);
			}
			return true;
		}
		return false;
	}

	protected bool ProcessSpaceKey(Keys keyData)
	{
		if ((keyData & Keys.Shift) == Keys.Shift)
		{
			if (selectionMode == DataGridViewSelectionMode.RowHeaderSelect)
			{
				SetSelectedRowCore(CurrentCellAddress.Y, selected: true);
				InvalidateRow(CurrentCellAddress.Y);
				return true;
			}
			if (selectionMode == DataGridViewSelectionMode.ColumnHeaderSelect)
			{
				SetSelectedColumnCore(CurrentCellAddress.X, selected: true);
				InvalidateColumn(CurrentCellAddress.X);
				return true;
			}
		}
		if (CurrentCell is DataGridViewButtonCell || CurrentCell is DataGridViewLinkCell || CurrentCell is DataGridViewCheckBoxCell)
		{
			DataGridViewCellEventArgs e = new DataGridViewCellEventArgs(CurrentCell.ColumnIndex, CurrentCell.RowIndex);
			OnCellClick(e);
			OnCellContentClick(e);
			if (CurrentCell is DataGridViewButtonCell)
			{
				(CurrentCell as DataGridViewButtonCell).OnClickInternal(e);
			}
			if (CurrentCell is DataGridViewCheckBoxCell)
			{
				(CurrentCell as DataGridViewCheckBoxCell).OnClickInternal(e);
			}
			return true;
		}
		return false;
	}

	protected bool ProcessTabKey(Keys keyData)
	{
		FindForm()?.ActivateFocusCues();
		int num = ColumnIndexToDisplayIndex(currentCellAddress.X);
		if ((keyData & Keys.Shift) == Keys.Shift)
		{
			if (num > 0)
			{
				MoveCurrentCell(ColumnDisplayIndexToIndex(num - 1), currentCellAddress.Y, select: true, (keyData & Keys.Control) == Keys.Control, isShift: false, scroll: true);
				return true;
			}
			if (currentCellAddress.Y > 0)
			{
				MoveCurrentCell(ColumnDisplayIndexToIndex(Columns.Count - 1), currentCellAddress.Y - 1, select: true, isControl: false, isShift: false, scroll: true);
				return true;
			}
		}
		else
		{
			if (num < Columns.Count - 1)
			{
				MoveCurrentCell(ColumnDisplayIndexToIndex(num + 1), currentCellAddress.Y, select: true, (keyData & Keys.Control) == Keys.Control, isShift: false, scroll: true);
				return true;
			}
			if (currentCellAddress.Y < Rows.Count - 1)
			{
				MoveCurrentCell(ColumnDisplayIndexToIndex(0), currentCellAddress.Y + 1, select: true, isControl: false, isShift: false, scroll: true);
				return true;
			}
		}
		return false;
	}

	protected bool ProcessUpKey(Keys keyData)
	{
		int y = CurrentCellAddress.Y;
		if (y > 0)
		{
			if ((keyData & Keys.Control) == Keys.Control)
			{
				MoveCurrentCell(CurrentCellAddress.X, 0, select: true, (keyData & Keys.Control) == Keys.Control, (keyData & Keys.Shift) == Keys.Shift, scroll: true);
			}
			else
			{
				MoveCurrentCell(CurrentCellAddress.X, y - 1, select: true, (keyData & Keys.Control) == Keys.Control, (keyData & Keys.Shift) == Keys.Shift, scroll: true);
			}
			return true;
		}
		return false;
	}

	protected bool ProcessZeroKey(Keys keyData)
	{
		if ((keyData & Keys.Control) == Keys.Control && CurrentCell.EditType != null)
		{
			CurrentCell.Value = DBNull.Value;
			InvalidateCell(CurrentCell);
			return true;
		}
		return false;
	}

	protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
	{
		base.SetBoundsCore(x, y, width, height, specified);
	}

	[System.MonoTODO("Does not use validateCurrentCell")]
	protected virtual bool SetCurrentCellAddressCore(int columnIndex, int rowIndex, bool setAnchorCellAddress, bool validateCurrentCell, bool throughMouseClick)
	{
		if ((columnIndex < 0 || columnIndex > Columns.Count - 1) && rowIndex != -1)
		{
			throw new ArgumentOutOfRangeException("columnIndex");
		}
		if ((rowIndex < 0 || rowIndex > Rows.Count - 1) && columnIndex != -1)
		{
			throw new ArgumentOutOfRangeException("rowIndex");
		}
		DataGridViewCell dataGridViewCell = ((columnIndex != -1 || rowIndex != -1) ? Rows.SharedRow(rowIndex).Cells[columnIndex] : null);
		if (dataGridViewCell != null && !dataGridViewCell.Visible)
		{
			throw new InvalidOperationException("cell is not visible");
		}
		if (currentCell != null)
		{
			if (setAnchorCellAddress)
			{
				anchor_cell.X = currentCell.ColumnIndex;
				anchor_cell.Y = currentCell.RowIndex;
			}
			currentCellAddress.X = currentCell.ColumnIndex;
			currentCellAddress.Y = currentCell.RowIndex;
		}
		if (dataGridViewCell != currentCell)
		{
			if (currentCell != null)
			{
				if (currentCell.IsInEditMode)
				{
					if (!EndEdit())
					{
						return false;
					}
					if (currentCell.RowIndex == NewRowIndex && new_row_editing)
					{
						CancelEdit();
					}
				}
				else if (new_row_editing && currentCell.RowIndex == NewRowIndex)
				{
					CancelEdit();
				}
				OnCellLeave(new DataGridViewCellEventArgs(currentCell.ColumnIndex, currentCell.RowIndex));
				OnRowLeave(new DataGridViewCellEventArgs(currentCell.ColumnIndex, currentCell.RowIndex));
			}
			currentCell = dataGridViewCell;
			if (setAnchorCellAddress)
			{
				anchor_cell = new Point(columnIndex, rowIndex);
			}
			currentCellAddress = new Point(columnIndex, rowIndex);
			if (dataGridViewCell != null)
			{
				UpdateBindingPosition(dataGridViewCell.RowIndex);
				OnRowEnter(new DataGridViewCellEventArgs(dataGridViewCell.ColumnIndex, dataGridViewCell.RowIndex));
				OnCellEnter(new DataGridViewCellEventArgs(dataGridViewCell.ColumnIndex, dataGridViewCell.RowIndex));
			}
			OnCurrentCellChanged(EventArgs.Empty);
			if (dataGridViewCell != null)
			{
				if (AllowUserToAddRows && dataGridViewCell.RowIndex == NewRowIndex && !is_binding && !new_row_editing)
				{
					OnUserAddedRow(new DataGridViewRowEventArgs(Rows[NewRowIndex]));
				}
				else if (editMode == DataGridViewEditMode.EditOnEnter)
				{
					BeginEdit(selectAll: true);
				}
			}
		}
		else if ((dataGridViewCell != null) & throughMouseClick)
		{
			BeginEdit(selectAll: true);
		}
		return true;
	}

	protected virtual void SetSelectedCellCore(int columnIndex, int rowIndex, bool selected)
	{
		rows[rowIndex].Cells[columnIndex].Selected = selected;
		OnSelectionChanged(EventArgs.Empty);
	}

	internal void SetSelectedColumnCoreInternal(int columnIndex, bool selected)
	{
		SetSelectedColumnCore(columnIndex, selected);
	}

	protected virtual void SetSelectedColumnCore(int columnIndex, bool selected)
	{
		if (selectionMode == DataGridViewSelectionMode.ColumnHeaderSelect || selectionMode == DataGridViewSelectionMode.FullColumnSelect)
		{
			DataGridViewColumn dataGridViewColumn = columns[columnIndex];
			dataGridViewColumn.SelectedInternal = selected;
			if (selected_columns == null)
			{
				selected_columns = new DataGridViewSelectedColumnCollection();
			}
			bool flag = false;
			if (!selected && selected_columns.Contains(dataGridViewColumn))
			{
				selected_columns.InternalRemove(dataGridViewColumn);
				flag = true;
			}
			else if (selected && !selected_columns.Contains(dataGridViewColumn))
			{
				selected_columns.InternalAdd(dataGridViewColumn);
				flag = true;
			}
			if (flag)
			{
				OnSelectionChanged(EventArgs.Empty);
			}
			Invalidate();
		}
	}

	internal void SetSelectedRowCoreInternal(int rowIndex, bool selected)
	{
		if (rowIndex >= 0 && rowIndex < Rows.Count)
		{
			SetSelectedRowCore(rowIndex, selected);
		}
	}

	protected virtual void SetSelectedRowCore(int rowIndex, bool selected)
	{
		DataGridViewRow dataGridViewRow = rows[rowIndex];
		dataGridViewRow.SelectedInternal = selected;
		if (selected_rows == null)
		{
			selected_rows = new DataGridViewSelectedRowCollection(this);
		}
		bool flag = false;
		if (!selected && selected_rows.Contains(dataGridViewRow))
		{
			selected_rows.InternalRemove(dataGridViewRow);
			flag = true;
		}
		else if (selected && !selected_rows.Contains(dataGridViewRow))
		{
			selected_rows.InternalAdd(dataGridViewRow);
			flag = true;
		}
		if (flag)
		{
			OnSelectionChanged(EventArgs.Empty);
		}
		Invalidate();
	}

	protected override void WndProc(ref Message m)
	{
		base.WndProc(ref m);
	}

	internal void InternalOnCellClick(DataGridViewCellEventArgs e)
	{
		OnCellClick(e);
	}

	internal void InternalOnCellContentClick(DataGridViewCellEventArgs e)
	{
		OnCellContentClick(e);
	}

	internal void InternalOnCellContentDoubleClick(DataGridViewCellEventArgs e)
	{
		OnCellContentDoubleClick(e);
	}

	internal void InternalOnCellValueChanged(DataGridViewCellEventArgs e)
	{
		OnCellValueChanged(e);
	}

	internal void InternalOnDataError(DataGridViewDataErrorEventArgs e)
	{
		OnDataError(displayErrorDialogIfNoHandler: false, e);
	}

	internal void InternalOnMouseWheel(MouseEventArgs e)
	{
		OnMouseWheel(e);
	}

	internal void OnHScrollBarScroll(object sender, ScrollEventArgs e)
	{
		int num = Columns.Count - DisplayedColumnCount(includePartialColumns: false);
		horizontalScrollingOffset = e.NewValue;
		int num2 = 0;
		for (int i = 0; i < Columns.Count; i++)
		{
			DataGridViewColumn dataGridViewColumn = Columns[i];
			if (dataGridViewColumn.Index >= num)
			{
				first_col_index = num;
				Invalidate();
				OnScroll(e);
			}
			else if (e.NewValue < num2 + dataGridViewColumn.Width)
			{
				if (first_col_index != i)
				{
					first_col_index = i;
					Invalidate();
					OnScroll(e);
				}
				break;
			}
			num2 += dataGridViewColumn.Width;
		}
	}

	internal void OnVScrollBarScroll(object sender, ScrollEventArgs e)
	{
		verticalScrollingOffset = e.NewValue;
		if (Rows.Count == 0)
		{
			return;
		}
		int num = 0;
		int num2 = Rows.Count - DisplayedRowCount(includePartialRow: false);
		for (int i = 0; i < Rows.Count; i++)
		{
			DataGridViewRow dataGridViewRow = Rows[i];
			if (!dataGridViewRow.Visible)
			{
				continue;
			}
			if (dataGridViewRow.Index >= num2)
			{
				first_row_index = num2;
				Invalidate();
				OnScroll(e);
			}
			else if (e.NewValue < num + dataGridViewRow.Height)
			{
				if (first_row_index != i)
				{
					first_row_index = i;
					Invalidate();
					OnScroll(e);
				}
				return;
			}
			num += dataGridViewRow.Height;
		}
		first_row_index = num2;
		Invalidate();
		OnScroll(e);
	}

	internal void RaiseCellStyleChanged(DataGridViewCellEventArgs e)
	{
		OnCellStyleChanged(e);
	}

	internal void OnColumnCollectionChanged(object sender, CollectionChangeEventArgs e)
	{
		switch (e.Action)
		{
		case CollectionChangeAction.Add:
			OnColumnAddedInternal(new DataGridViewColumnEventArgs(e.Element as DataGridViewColumn));
			break;
		case CollectionChangeAction.Remove:
			OnColumnPostRemovedInternal(new DataGridViewColumnEventArgs(e.Element as DataGridViewColumn));
			break;
		case CollectionChangeAction.Refresh:
			hover_cell = null;
			MoveCurrentCell(-1, -1, select: true, isControl: false, isShift: false, scroll: true);
			break;
		}
	}

	internal void AutoResizeColumnsInternal()
	{
		for (int i = 0; i < Columns.Count; i++)
		{
			AutoResizeColumnInternal(i, Columns[i].InheritedAutoSizeMode);
		}
		AutoFillColumnsInternal();
	}

	internal void AutoFillColumnsInternal()
	{
		float num = 0f;
		int num2 = 0;
		int num3 = base.ClientSize.Width - (verticalScrollBar.VisibleInternal ? verticalScrollBar.Width : 0);
		if (RowHeadersVisible)
		{
			num3 -= RowHeadersWidth;
		}
		num3 -= BorderWidth * 2;
		int[] array = new int[Columns.Count];
		int[] array2 = new int[Columns.Count];
		bool flag = false;
		for (int i = 0; i < Columns.Count; i++)
		{
			DataGridViewColumn dataGridViewColumn = Columns[i];
			if (dataGridViewColumn.Visible)
			{
				switch (dataGridViewColumn.InheritedAutoSizeMode)
				{
				case DataGridViewAutoSizeColumnMode.Fill:
					num2++;
					num += dataGridViewColumn.FillWeight;
					break;
				case DataGridViewAutoSizeColumnMode.NotSet:
				case DataGridViewAutoSizeColumnMode.None:
				case DataGridViewAutoSizeColumnMode.AllCellsExceptHeader:
				case DataGridViewAutoSizeColumnMode.AllCells:
				case DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader:
				case DataGridViewAutoSizeColumnMode.DisplayedCells:
					num3 -= Columns[i].Width;
					break;
				}
			}
		}
		num3 = Math.Max(0, num3);
		do
		{
			flag = false;
			for (int j = 0; j < columns.Count; j++)
			{
				DataGridViewColumn dataGridViewColumn2 = Columns[j];
				if (dataGridViewColumn2.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill && dataGridViewColumn2.Visible && array[j] == 0)
				{
					int num4 = ((num != 0f) ? ((int)Math.Round((float)num3 * (dataGridViewColumn2.FillWeight / num), 0)) : 0);
					if (num4 < 0)
					{
						num4 = 0;
					}
					if (num4 < dataGridViewColumn2.MinimumWidth)
					{
						num4 = (array[j] = dataGridViewColumn2.MinimumWidth);
						flag = true;
						num3 -= num4;
						num -= dataGridViewColumn2.FillWeight;
					}
					array2[j] = num4;
				}
			}
		}
		while (flag);
		for (int k = 0; k < columns.Count; k++)
		{
			if (Columns[k].InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill && Columns[k].Visible)
			{
				Columns[k].Width = array2[k];
			}
		}
	}

	internal void AutoResizeColumnInternal(int columnIndex, DataGridViewAutoSizeColumnMode mode)
	{
		int num = 0;
		DataGridViewColumn dataGridViewColumn = Columns[columnIndex];
		switch (mode)
		{
		case DataGridViewAutoSizeColumnMode.Fill:
			return;
		case DataGridViewAutoSizeColumnMode.AllCellsExceptHeader:
		case DataGridViewAutoSizeColumnMode.AllCells:
		case DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader:
		case DataGridViewAutoSizeColumnMode.DisplayedCells:
			num = Math.Max(CalculateColumnCellWidth(columnIndex, dataGridViewColumn.InheritedAutoSizeMode), dataGridViewColumn.HeaderCell.ContentBounds.Width);
			break;
		case DataGridViewAutoSizeColumnMode.ColumnHeader:
			num = dataGridViewColumn.HeaderCell.ContentBounds.Width;
			break;
		default:
			num = dataGridViewColumn.Width;
			break;
		}
		if (num < 0)
		{
			num = 0;
		}
		if (num < dataGridViewColumn.MinimumWidth)
		{
			num = dataGridViewColumn.MinimumWidth;
		}
		dataGridViewColumn.Width = num;
	}

	internal int CalculateColumnCellWidth(int index, DataGridViewAutoSizeColumnMode mode)
	{
		int num = 0;
		int num2 = Rows.Count;
		int num3 = 0;
		if (mode == DataGridViewAutoSizeColumnMode.DisplayedCells || mode == DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader)
		{
			num = first_row_index;
			num2 = DisplayedRowCount(includePartialRow: true);
		}
		for (int i = num; i < num2; i++)
		{
			if (Rows[i].Visible)
			{
				int width = Rows[i].Cells[index].PreferredSize.Width;
				num3 = Math.Max(num3, width);
			}
		}
		return num3;
	}

	private Rectangle GetHeaderCellBounds(DataGridViewHeaderCell cell)
	{
		Rectangle result = new Rectangle(base.ClientRectangle.Location, cell.Size);
		if (cell is DataGridViewColumnHeaderCell)
		{
			if (RowHeadersVisible)
			{
				result.X += RowHeadersWidth;
			}
			List<DataGridViewColumn> columnDisplayIndexSortedArrayList = columns.ColumnDisplayIndexSortedArrayList;
			for (int i = first_col_index; i < columnDisplayIndexSortedArrayList.Count; i++)
			{
				DataGridViewColumn dataGridViewColumn = columnDisplayIndexSortedArrayList[i];
				if (dataGridViewColumn.Index == cell.ColumnIndex)
				{
					break;
				}
				result.X += dataGridViewColumn.Width;
			}
		}
		else
		{
			if (ColumnHeadersVisible)
			{
				result.Y += ColumnHeadersHeight;
			}
			for (int j = first_row_index; j < Rows.Count; j++)
			{
				DataGridViewRow rowInternal = GetRowInternal(j);
				if (rowInternal.HeaderCell == cell)
				{
					break;
				}
				result.Y += rowInternal.Height;
			}
		}
		return result;
	}

	private void PrepareEditingRow(bool cell_changed, bool column_changed)
	{
		if (new_row_editing)
		{
			return;
		}
		bool flag = false;
		flag = ColumnCount > 0 && AllowUserToAddRows;
		if (!flag)
		{
			RemoveEditingRow();
		}
		else if (flag)
		{
			if (editing_row != null && (cell_changed | column_changed))
			{
				RemoveEditingRow();
			}
			if (editing_row == null)
			{
				editing_row = RowTemplateFull;
				Rows.AddInternal(editing_row, sharable: false);
			}
		}
	}

	internal void RemoveEditingRow()
	{
		if (editing_row != null)
		{
			if (Rows.Contains(editing_row))
			{
				Rows.RemoveInternal(editing_row);
			}
			editing_row = null;
		}
	}

	private void AddBoundRow(object element)
	{
		if (ColumnCount != 0)
		{
			DataGridViewRow rowTemplateFull = RowTemplateFull;
			rows.AddInternal(rowTemplateFull, sharable: false);
		}
	}

	private bool IsColumnAlreadyBound(string name)
	{
		foreach (DataGridViewColumn column in Columns)
		{
			if (string.Compare(column.DataPropertyName, name, ignoreCase: true) == 0)
			{
				return true;
			}
		}
		return false;
	}

	private DataGridViewColumn CreateColumnByType(Type type)
	{
		if (type == typeof(bool))
		{
			return new DataGridViewCheckBoxColumn();
		}
		if (typeof(Bitmap).IsAssignableFrom(type))
		{
			return new DataGridViewImageColumn();
		}
		return new DataGridViewTextBoxColumn();
	}

	private void ClearBinding()
	{
		if (IsCurrentCellInEditMode && !EndEdit())
		{
			CancelEdit();
		}
		MoveCurrentCell(-1, -1, select: false, isControl: false, isShift: false, scroll: true);
		if (DataManager != null)
		{
			DataManager.ListChanged -= OnListChanged;
			DataManager.PositionChanged -= OnListPositionChanged;
			columns.ClearAutoGeneratedColumns();
			rows.Clear();
			RemoveEditingRow();
		}
	}

	private void ResetRows()
	{
		rows.Clear();
		RemoveEditingRow();
		if (DataManager != null)
		{
			foreach (object item in DataManager.List)
			{
				AddBoundRow(item);
			}
		}
		PrepareEditingRow(cell_changed: false, column_changed: true);
		OnListPositionChanged(this, EventArgs.Empty);
	}

	private void DoBinding()
	{
		if (dataSource != null && DataManager != null)
		{
			if (autoGenerateColumns)
			{
				is_autogenerating_columns = true;
				foreach (PropertyDescriptor itemProperty in DataManager.GetItemProperties())
				{
					if (!typeof(ICollection).IsAssignableFrom(itemProperty.PropertyType) && itemProperty.IsBrowsable && !IsColumnAlreadyBound(itemProperty.Name))
					{
						DataGridViewColumn dataGridViewColumn = CreateColumnByType(itemProperty.PropertyType);
						dataGridViewColumn.Name = itemProperty.DisplayName;
						dataGridViewColumn.DataPropertyName = itemProperty.Name;
						dataGridViewColumn.ReadOnly = !DataManager.AllowEdit || itemProperty.IsReadOnly;
						dataGridViewColumn.ValueType = itemProperty.PropertyType;
						dataGridViewColumn.AutoGenerated = true;
						columns.Add(dataGridViewColumn);
					}
				}
				is_autogenerating_columns = false;
			}
			foreach (DataGridViewColumn column in columns)
			{
				column.DataColumnIndex = FindDataColumnIndex(column);
			}
			foreach (object item in DataManager.List)
			{
				AddBoundRow(item);
			}
			DataManager.ListChanged += OnListChanged;
			DataManager.PositionChanged += OnListPositionChanged;
			OnDataBindingComplete(new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset));
			OnListPositionChanged(this, EventArgs.Empty);
		}
		else if (Rows.Count > 0 && Columns.Count > 0)
		{
			MoveCurrentCell(0, 0, select: true, isControl: false, isShift: false, scroll: false);
		}
		PrepareEditingRow(cell_changed: false, column_changed: true);
	}

	private void MoveCurrentCell(int x, int y, bool select, bool isControl, bool isShift, bool scroll)
	{
		if (x == -1 || y == -1)
		{
			x = (y = -1);
		}
		else
		{
			if (x < 0 || x > Columns.Count - 1)
			{
				throw new ArgumentOutOfRangeException("x");
			}
			if (y < 0 || y > Rows.Count - 1)
			{
				throw new ArgumentOutOfRangeException("y");
			}
			if (!Rows[y].Visible)
			{
				for (int i = y; i < Rows.Count; i++)
				{
					if (Rows[i].Visible)
					{
						y = i;
						break;
					}
				}
			}
			if (!Columns[x].Visible)
			{
				for (int j = x; j < Columns.Count; j++)
				{
					if (Columns[j].Visible)
					{
						x = j;
						break;
					}
				}
			}
			if (!Rows[y].Visible || !Columns[x].Visible)
			{
				x = (y = -1);
			}
		}
		if (!SetCurrentCellAddressCore(x, y, setAnchorCellAddress: true, validateCurrentCell: false, throughMouseClick: false))
		{
			ClearSelection();
			return;
		}
		if (x == -1 && y == -1)
		{
			ClearSelection();
			return;
		}
		bool selected = Rows.SharedRow(CurrentCellAddress.Y).Selected;
		bool selected2 = Columns[CurrentCellAddress.X].Selected;
		DataGridViewSelectionMode dataGridViewSelectionMode = selectionMode;
		if (dataGridViewSelectionMode == DataGridViewSelectionMode.RowHeaderSelect && (x == -1 || (selected && CurrentCellAddress.X == x)))
		{
			dataGridViewSelectionMode = DataGridViewSelectionMode.FullRowSelect;
		}
		else if (dataGridViewSelectionMode == DataGridViewSelectionMode.RowHeaderSelect)
		{
			dataGridViewSelectionMode = DataGridViewSelectionMode.CellSelect;
		}
		if (dataGridViewSelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect && (y == -1 || (selected2 && CurrentCellAddress.Y == y)))
		{
			dataGridViewSelectionMode = DataGridViewSelectionMode.FullColumnSelect;
		}
		else if (dataGridViewSelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect)
		{
			dataGridViewSelectionMode = DataGridViewSelectionMode.CellSelect;
		}
		if (scroll)
		{
			int num = ColumnIndexToDisplayIndex(x);
			bool flag = false;
			int num2 = DisplayedColumnCount(includePartialColumns: false);
			int num3 = 0;
			if (num < first_col_index)
			{
				RefreshScrollBars();
				flag = true;
				if (num == 0)
				{
					num3 = horizontalScrollBar.Value;
				}
				else
				{
					if (first_col_index >= ColumnCount)
					{
						first_col_index = ColumnCount - 1;
					}
					for (int k = num; k < first_col_index; k++)
					{
						num3 += Columns[ColumnDisplayIndexToIndex(k)].Width;
					}
				}
				horizontalScrollBar.SafeValueSet(horizontalScrollBar.Value - num3);
				OnHScrollBarScroll(this, new ScrollEventArgs(ScrollEventType.ThumbPosition, horizontalScrollBar.Value, ScrollOrientation.HorizontalScroll));
			}
			else if (num > first_col_index + num2 - 1 && num != 0)
			{
				RefreshScrollBars();
				flag = true;
				if (num == Columns.Count - 1)
				{
					num3 = horizontalScrollBar.Maximum - horizontalScrollBar.Value;
				}
				else
				{
					for (int l = first_col_index + num2 - 1; l < num && l != -1; l++)
					{
						num3 += Columns[ColumnDisplayIndexToIndex(l)].Width;
					}
				}
				horizontalScrollBar.SafeValueSet(horizontalScrollBar.Value + num3);
				OnHScrollBarScroll(this, new ScrollEventArgs(ScrollEventType.ThumbPosition, horizontalScrollBar.Value, ScrollOrientation.HorizontalScroll));
			}
			int num4 = y;
			int num5 = DisplayedRowCount(includePartialRow: false);
			int num6 = 0;
			if (num4 < first_row_index)
			{
				if (!flag)
				{
					RefreshScrollBars();
				}
				if (num4 == 0)
				{
					num6 = verticalScrollBar.Value;
				}
				else
				{
					if (first_row_index >= RowCount)
					{
						first_row_index = RowCount - 1;
					}
					for (int m = num4; m < first_row_index; m++)
					{
						num6 += GetRowInternal(m).Height;
					}
				}
				verticalScrollBar.SafeValueSet(verticalScrollBar.Value - num6);
				OnVScrollBarScroll(this, new ScrollEventArgs(ScrollEventType.ThumbPosition, verticalScrollBar.Value, ScrollOrientation.VerticalScroll));
			}
			else if (num4 > first_row_index + num5 - 1 && num4 != 0)
			{
				if (!flag)
				{
					RefreshScrollBars();
				}
				if (num4 == Rows.Count - 1)
				{
					num6 = verticalScrollBar.Maximum - verticalScrollBar.Value;
				}
				else
				{
					for (int n = first_row_index + num5 - 1; n < num4; n++)
					{
						num6 += GetRowInternal(n).Height;
					}
				}
				verticalScrollBar.SafeValueSet(verticalScrollBar.Value + num6);
				OnVScrollBarScroll(this, new ScrollEventArgs(ScrollEventType.ThumbPosition, verticalScrollBar.Value, ScrollOrientation.VerticalScroll));
			}
		}
		if (select)
		{
			if (!isShift)
			{
				ClearSelection();
			}
			switch (dataGridViewSelectionMode)
			{
			case DataGridViewSelectionMode.CellSelect:
				SetSelectedCellCore(x, y, selected: true);
				break;
			case DataGridViewSelectionMode.FullRowSelect:
				SetSelectedRowCore(y, selected: true);
				break;
			case DataGridViewSelectionMode.FullColumnSelect:
				SetSelectedColumnCore(x, selected: true);
				break;
			}
			Invalidate();
		}
	}

	private int ColumnIndexToDisplayIndex(int index)
	{
		if (index == -1)
		{
			return index;
		}
		return Columns[index].DisplayIndex;
	}

	private int ColumnDisplayIndexToIndex(int index)
	{
		return Columns.ColumnDisplayIndexSortedArrayList[index].Index;
	}

	private void OnListChanged(object sender, ListChangedEventArgs args)
	{
		switch (args.ListChangedType)
		{
		case ListChangedType.ItemAdded:
			AddBoundRow(DataManager[args.NewIndex]);
			break;
		case ListChangedType.ItemDeleted:
			Rows.RemoveAtInternal(args.NewIndex);
			break;
		default:
			ResetRows();
			break;
		case ListChangedType.ItemChanged:
			break;
		}
		Invalidate();
	}

	private void OnListPositionChanged(object sender, EventArgs args)
	{
		if (Rows.Count > 0 && Columns.Count > 0 && DataManager.Position != -1)
		{
			MoveCurrentCell((currentCell != null) ? currentCell.ColumnIndex : 0, DataManager.Position, select: true, isControl: false, isShift: false, scroll: true);
		}
		else
		{
			MoveCurrentCell(-1, -1, select: true, isControl: false, isShift: false, scroll: true);
		}
	}

	private void ReBind()
	{
		if (!is_binding)
		{
			SuspendLayout();
			is_binding = true;
			ClearBinding();
			DoBinding();
			is_binding = false;
			ResumeLayout(performLayout: true);
			Invalidate();
		}
	}

	private bool MouseOverColumnResize(int col, int mousex)
	{
		if (!allowUserToResizeColumns)
		{
			return false;
		}
		Rectangle cellDisplayRectangle = GetCellDisplayRectangle(col, 0, cutOverflow: false);
		if (mousex >= cellDisplayRectangle.Right - 4 && mousex <= cellDisplayRectangle.Right)
		{
			return true;
		}
		return false;
	}

	private bool MouseOverRowResize(int row, int mousey)
	{
		if (!allowUserToResizeRows)
		{
			return false;
		}
		Rectangle cellDisplayRectangle = GetCellDisplayRectangle(0, row, cutOverflow: false);
		if (mousey >= cellDisplayRectangle.Bottom - 4 && mousey <= cellDisplayRectangle.Bottom)
		{
			return true;
		}
		return false;
	}

	private void DrawVerticalResizeLine(int x)
	{
		Rectangle rect = new Rectangle(x, base.Bounds.Y + 3 + (ColumnHeadersVisible ? ColumnHeadersHeight : 0), 1, base.Bounds.Height - 3 - (ColumnHeadersVisible ? ColumnHeadersHeight : 0));
		XplatUI.DrawReversibleRectangle(base.Handle, rect, 2);
	}

	private void DrawHorizontalResizeLine(int y)
	{
		Rectangle rect = new Rectangle(base.Bounds.X + 3 + (RowHeadersVisible ? RowHeadersWidth : 0), y, base.Bounds.Width - 3 + (RowHeadersVisible ? RowHeadersWidth : 0), 1);
		XplatUI.DrawReversibleRectangle(base.Handle, rect, 2);
	}

	private void MouseEnteredErrorIcon(DataGridViewCell item)
	{
		tooltip_currently_showing = item;
		ToolTipTimer.Start();
	}

	private void MouseLeftErrorIcon(DataGridViewCell item)
	{
		ToolTipTimer.Stop();
		ToolTipWindow.Hide(this);
		tooltip_currently_showing = null;
	}

	private void ToolTipTimer_Tick(object o, EventArgs args)
	{
		string errorText = tooltip_currently_showing.ErrorText;
		if (!string.IsNullOrEmpty(errorText))
		{
			ToolTipWindow.Present(this, errorText);
		}
		ToolTipTimer.Stop();
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
	protected bool ProcessF3Key(Keys keyData)
	{
		Unity.ThrowStub.ThrowNotSupportedException();
		return default;
	}
}
