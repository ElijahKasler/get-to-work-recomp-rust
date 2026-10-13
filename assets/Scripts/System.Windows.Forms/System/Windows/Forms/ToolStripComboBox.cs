using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace System.Windows.Forms;

[ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.MenuStrip | ToolStripItemDesignerAvailability.ContextMenuStrip)]
[DefaultProperty("Items")]
public class ToolStripComboBox : ToolStripControlHost
{
	private class ToolStripComboBoxControl : ComboBox
	{
		public ToolStripComboBoxControl()
		{
			border_style = BorderStyle.None;
			base.FlatStyle = FlatStyle.Popup;
		}
	}

	private static object DropDownEvent = new object();

	private static object DropDownClosedEvent = new object();

	private static object DropDownStyleChangedEvent = new object();

	private static object SelectedIndexChangedEvent = new object();

	private static object TextUpdateEvent = new object();

	[Browsable(true)]
	[Localizable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public AutoCompleteStringCollection AutoCompleteCustomSource
	{
		get
		{
			return ComboBox.AutoCompleteCustomSource;
		}
		set
		{
			ComboBox.AutoCompleteCustomSource = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(AutoCompleteMode.None)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public AutoCompleteMode AutoCompleteMode
	{
		get
		{
			return ComboBox.AutoCompleteMode;
		}
		set
		{
			ComboBox.AutoCompleteMode = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(AutoCompleteSource.None)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public AutoCompleteSource AutoCompleteSource
	{
		get
		{
			return ComboBox.AutoCompleteSource;
		}
		set
		{
			ComboBox.AutoCompleteSource = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public override Image BackgroundImage
	{
		get
		{
			return base.BackgroundImage;
		}
		set
		{
			base.BackgroundImage = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ComboBox ComboBox => (ComboBox)base.Control;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(true)]
	[DefaultValue(106)]
	public int DropDownHeight
	{
		get
		{
			return ComboBox.DropDownHeight;
		}
		set
		{
			ComboBox.DropDownHeight = value;
		}
	}

	[DefaultValue(ComboBoxStyle.DropDown)]
	[RefreshProperties(RefreshProperties.Repaint)]
	public ComboBoxStyle DropDownStyle
	{
		get
		{
			return ComboBox.DropDownStyle;
		}
		set
		{
			ComboBox.DropDownStyle = value;
		}
	}

	public int DropDownWidth
	{
		get
		{
			return ComboBox.DropDownWidth;
		}
		set
		{
			ComboBox.DropDownWidth = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool DroppedDown
	{
		get
		{
			return ComboBox.DroppedDown;
		}
		set
		{
			ComboBox.DroppedDown = value;
		}
	}

	[Localizable(true)]
	[DefaultValue(FlatStyle.Popup)]
	public FlatStyle FlatStyle
	{
		get
		{
			return ComboBox.FlatStyle;
		}
		set
		{
			ComboBox.FlatStyle = value;
		}
	}

	[Localizable(true)]
	[DefaultValue(true)]
	public bool IntegralHeight
	{
		get
		{
			return ComboBox.IntegralHeight;
		}
		set
		{
			ComboBox.IntegralHeight = value;
		}
	}

	[Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[Localizable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public ComboBox.ObjectCollection Items => ComboBox.Items;

	[Localizable(true)]
	[DefaultValue(8)]
	public int MaxDropDownItems
	{
		get
		{
			return ComboBox.MaxDropDownItems;
		}
		set
		{
			ComboBox.MaxDropDownItems = value;
		}
	}

	[Localizable(true)]
	[DefaultValue(0)]
	public int MaxLength
	{
		get
		{
			return ComboBox.MaxLength;
		}
		set
		{
			ComboBox.MaxLength = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectedIndex
	{
		get
		{
			return ComboBox.SelectedIndex;
		}
		set
		{
			ComboBox.SelectedIndex = value;
			if (ComboBox.SelectedIndex >= 0)
			{
				Text = Items[value].ToString();
			}
		}
	}

	[Bindable(true)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public object SelectedItem
	{
		get
		{
			return ComboBox.SelectedItem;
		}
		set
		{
			ComboBox.SelectedItem = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string SelectedText
	{
		get
		{
			return ComboBox.SelectedText;
		}
		set
		{
			ComboBox.SelectedText = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionLength
	{
		get
		{
			return ComboBox.SelectionLength;
		}
		set
		{
			ComboBox.SelectionLength = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionStart
	{
		get
		{
			return ComboBox.SelectionStart;
		}
		set
		{
			ComboBox.SelectionStart = value;
		}
	}

	[DefaultValue(false)]
	public bool Sorted
	{
		get
		{
			return ComboBox.Sorted;
		}
		set
		{
			ComboBox.Sorted = value;
		}
	}

	protected internal override Padding DefaultMargin => new Padding(1, 0, 1, 0);

	protected override Size DefaultSize => new Size(100, 22);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler DoubleClick
	{
		add
		{
			base.DoubleClick += value;
		}
		remove
		{
			base.DoubleClick -= value;
		}
	}

	public event EventHandler DropDown
	{
		add
		{
			base.Events.AddHandler(DropDownEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(DropDownEvent, value);
		}
	}

	public event EventHandler DropDownClosed
	{
		add
		{
			base.Events.AddHandler(DropDownClosedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(DropDownClosedEvent, value);
		}
	}

	public event EventHandler DropDownStyleChanged
	{
		add
		{
			base.Events.AddHandler(DropDownStyleChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(DropDownStyleChangedEvent, value);
		}
	}

	public event EventHandler SelectedIndexChanged
	{
		add
		{
			base.Events.AddHandler(SelectedIndexChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(SelectedIndexChangedEvent, value);
		}
	}

	public event EventHandler TextUpdate
	{
		add
		{
			base.Events.AddHandler(TextUpdateEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(TextUpdateEvent, value);
		}
	}

	public ToolStripComboBox()
		: base(new ToolStripComboBoxControl())
	{
		Size = new Size(121, 21);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public ToolStripComboBox(Control c)
		: base(c)
	{
		throw new NotSupportedException();
	}

	public ToolStripComboBox(string name)
		: this()
	{
		base.Name = name;
	}

	public void BeginUpdate()
	{
		ComboBox.BeginUpdate();
	}

	public void EndUpdate()
	{
		ComboBox.EndUpdate();
	}

	public int FindString(string s)
	{
		return ComboBox.FindString(s);
	}

	public int FindString(string s, int startIndex)
	{
		return ComboBox.FindString(s, startIndex);
	}

	public int FindStringExact(string s)
	{
		return ComboBox.FindStringExact(s);
	}

	public int FindStringExact(string s, int startIndex)
	{
		return ComboBox.FindStringExact(s, startIndex);
	}

	public int GetItemHeight(int index)
	{
		return ComboBox.GetItemHeight(index);
	}

	public override Size GetPreferredSize(Size constrainingSize)
	{
		return base.GetPreferredSize(constrainingSize);
	}

	public void Select(int start, int length)
	{
		ComboBox.Select(start, length);
	}

	public void SelectAll()
	{
		ComboBox.SelectAll();
	}

	public override string ToString()
	{
		return ComboBox.ToString();
	}

	protected virtual void OnDropDown(EventArgs e)
	{
		((EventHandler)base.Events[DropDownEvent])?.Invoke(this, e);
	}

	protected virtual void OnDropDownClosed(EventArgs e)
	{
		((EventHandler)base.Events[DropDownClosedEvent])?.Invoke(this, e);
	}

	protected virtual void OnDropDownStyleChanged(EventArgs e)
	{
		((EventHandler)base.Events[DropDownStyleChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnSelectedIndexChanged(EventArgs e)
	{
		((EventHandler)base.Events[SelectedIndexChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnSelectionChangeCommitted(EventArgs e)
	{
	}

	protected override void OnSubscribeControlEvents(Control control)
	{
		base.OnSubscribeControlEvents(control);
		ComboBox.DropDown += HandleDropDown;
		ComboBox.DropDownClosed += HandleDropDownClosed;
		ComboBox.DropDownStyleChanged += HandleDropDownStyleChanged;
		ComboBox.SelectedIndexChanged += HandleSelectedIndexChanged;
		ComboBox.TextChanged += HandleTextChanged;
		ComboBox.TextUpdate += HandleTextUpdate;
	}

	protected virtual void OnTextUpdate(EventArgs e)
	{
		((EventHandler)base.Events[TextUpdateEvent])?.Invoke(this, e);
	}

	protected override void OnUnsubscribeControlEvents(Control control)
	{
		base.OnUnsubscribeControlEvents(control);
	}

	private void HandleDropDown(object sender, EventArgs e)
	{
		OnDropDown(e);
	}

	private void HandleDropDownClosed(object sender, EventArgs e)
	{
		OnDropDownClosed(e);
	}

	private void HandleDropDownStyleChanged(object sender, EventArgs e)
	{
		OnDropDownStyleChanged(e);
	}

	private void HandleSelectedIndexChanged(object sender, EventArgs e)
	{
		OnSelectedIndexChanged(e);
	}

	private void HandleTextChanged(object sender, EventArgs e)
	{
		OnTextChanged(e);
	}

	private void HandleTextUpdate(object sender, EventArgs e)
	{
		OnTextUpdate(e);
	}
}
