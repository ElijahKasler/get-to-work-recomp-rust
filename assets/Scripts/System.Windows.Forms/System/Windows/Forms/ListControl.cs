using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace System.Windows.Forms;

[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
[LookupBindingProperties("DataSource", "DisplayMember", "ValueMember", "SelectedValue")]
public abstract class ListControl : Control
{
	private object data_source;

	private BindingMemberInfo value_member;

	private string display_member;

	private CurrencyManager data_manager;

	private BindingContext last_binding_context;

	private IFormatProvider format_info;

	private string format_string = string.Empty;

	private bool formatting_enabled;

	private static object DataSourceChangedEvent = new object();

	private static object DisplayMemberChangedEvent = new object();

	private static object FormatEvent = new object();

	private static object FormatInfoChangedEvent = new object();

	private static object FormatStringChangedEvent = new object();

	private static object FormattingEnabledChangedEvent = new object();

	private static object SelectedValueChangedEvent = new object();

	private static object ValueMemberChangedEvent = new object();

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[Browsable(false)]
	public IFormatProvider FormatInfo
	{
		get
		{
			return format_info;
		}
		set
		{
			if (format_info != value)
			{
				format_info = value;
				RefreshItems();
				OnFormatInfoChanged(EventArgs.Empty);
			}
		}
	}

	[Editor("System.Windows.Forms.Design.FormatStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[MergableProperty(false)]
	[DefaultValue("")]
	public string FormatString
	{
		get
		{
			return format_string;
		}
		set
		{
			if (format_string != value)
			{
				format_string = value;
				RefreshItems();
				OnFormatStringChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(false)]
	public bool FormattingEnabled
	{
		get
		{
			return formatting_enabled;
		}
		set
		{
			if (formatting_enabled != value)
			{
				formatting_enabled = value;
				RefreshItems();
				OnFormattingEnabledChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(null)]
	[MWFCategory("Data")]
	[AttributeProvider(typeof(IListSource))]
	[RefreshProperties(RefreshProperties.Repaint)]
	public object DataSource
	{
		get
		{
			return data_source;
		}
		set
		{
			if (data_source != value)
			{
				if (value == null)
				{
					display_member = string.Empty;
				}
				else if (!(value is IList) && !(value is IListSource))
				{
					throw new Exception("Complex DataBinding accepts as a data source either an IList or an IListSource");
				}
				data_source = value;
				ConnectToDataSource();
				OnDataSourceChanged(EventArgs.Empty);
			}
		}
	}

	[TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[DefaultValue("")]
	[Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[MWFCategory("Data")]
	public string DisplayMember
	{
		get
		{
			return display_member;
		}
		set
		{
			if (value == null)
			{
				value = string.Empty;
			}
			if (!(display_member == value))
			{
				display_member = value;
				ConnectToDataSource();
				OnDisplayMemberChanged(EventArgs.Empty);
			}
		}
	}

	public abstract int SelectedIndex { get; set; }

	[Browsable(false)]
	[Bindable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DefaultValue(null)]
	public object SelectedValue
	{
		get
		{
			if (data_manager == null || SelectedIndex == -1)
			{
				return null;
			}
			object item = data_manager[SelectedIndex];
			return FilterItemOnProperty(item, ValueMember);
		}
		set
		{
			if (data_manager == null)
			{
				return;
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			PropertyDescriptor propertyDescriptor = data_manager.GetItemProperties().Find(ValueMember, ignoreCase: true);
			for (int i = 0; i < data_manager.Count; i++)
			{
				if (value.Equals(propertyDescriptor.GetValue(data_manager[i])))
				{
					SelectedIndex = i;
					return;
				}
			}
			SelectedIndex = -1;
		}
	}

	[MWFCategory("Data")]
	[DefaultValue("")]
	[Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public string ValueMember
	{
		get
		{
			return value_member.BindingMember;
		}
		set
		{
			BindingMemberInfo bindingMemberInfo = new BindingMemberInfo(value);
			if (!value_member.Equals(bindingMemberInfo))
			{
				value_member = bindingMemberInfo;
				if (display_member == string.Empty)
				{
					DisplayMember = value_member.BindingMember;
				}
				ConnectToDataSource();
				OnValueMemberChanged(EventArgs.Empty);
			}
		}
	}

	protected virtual bool AllowSelection => true;

	internal override bool ScaleChildrenInternal => false;

	protected CurrencyManager DataManager => data_manager;

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

	public event EventHandler DisplayMemberChanged
	{
		add
		{
			base.Events.AddHandler(DisplayMemberChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(DisplayMemberChangedEvent, value);
		}
	}

	public event ListControlConvertEventHandler Format
	{
		add
		{
			base.Events.AddHandler(FormatEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(FormatEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	public event EventHandler FormatInfoChanged
	{
		add
		{
			base.Events.AddHandler(FormatInfoChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(FormatInfoChangedEvent, value);
		}
	}

	public event EventHandler FormatStringChanged
	{
		add
		{
			base.Events.AddHandler(FormatStringChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(FormatStringChangedEvent, value);
		}
	}

	public event EventHandler FormattingEnabledChanged
	{
		add
		{
			base.Events.AddHandler(FormattingEnabledChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(FormattingEnabledChangedEvent, value);
		}
	}

	public event EventHandler SelectedValueChanged
	{
		add
		{
			base.Events.AddHandler(SelectedValueChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(SelectedValueChangedEvent, value);
		}
	}

	public event EventHandler ValueMemberChanged
	{
		add
		{
			base.Events.AddHandler(ValueMemberChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ValueMemberChangedEvent, value);
		}
	}

	protected ListControl()
	{
		value_member = new BindingMemberInfo(string.Empty);
		display_member = string.Empty;
		SetStyle(ControlStyles.UserPaint | ControlStyles.StandardClick | ControlStyles.UseTextForAccessibility, value: false);
	}

	protected object FilterItemOnProperty(object item)
	{
		return FilterItemOnProperty(item, string.Empty);
	}

	protected object FilterItemOnProperty(object item, string field)
	{
		if (item == null)
		{
			return null;
		}
		if (field == null || field == string.Empty)
		{
			return item;
		}
		PropertyDescriptor propertyDescriptor = null;
		propertyDescriptor = ((data_manager == null) ? TypeDescriptor.GetProperties(item).Find(field, ignoreCase: true) : data_manager.GetItemProperties().Find(field, ignoreCase: true));
		if (propertyDescriptor == null)
		{
			return item;
		}
		return propertyDescriptor.GetValue(item);
	}

	public string GetItemText(object item)
	{
		object obj = FilterItemOnProperty(item, DisplayMember);
		if (obj == null)
		{
			obj = item;
		}
		string text = obj.ToString();
		if (FormattingEnabled)
		{
			ListControlConvertEventArgs e = new ListControlConvertEventArgs(obj, typeof(string), item);
			OnFormat(e);
			if (e.Value.ToString() != text)
			{
				return e.Value.ToString();
			}
			if (obj is IFormattable)
			{
				return ((IFormattable)obj).ToString(string.IsNullOrEmpty(FormatString) ? null : FormatString, FormatInfo);
			}
		}
		return text;
	}

	protected override bool IsInputKey(Keys keyData)
	{
		if ((uint)(keyData - 16) <= 1u || (uint)(keyData - 32) <= 8u)
		{
			return true;
		}
		return false;
	}

	protected override void OnBindingContextChanged(EventArgs e)
	{
		base.OnBindingContextChanged(e);
		if (last_binding_context == BindingContext)
		{
			return;
		}
		last_binding_context = BindingContext;
		ConnectToDataSource();
		if (DataManager != null)
		{
			SetItemsCore(DataManager.List);
			if (AllowSelection)
			{
				SelectedIndex = DataManager.Position;
			}
		}
	}

	protected virtual void OnDataSourceChanged(EventArgs e)
	{
		((EventHandler)base.Events[DataSourceChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnDisplayMemberChanged(EventArgs e)
	{
		((EventHandler)base.Events[DisplayMemberChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnFormat(ListControlConvertEventArgs e)
	{
		((ListControlConvertEventHandler)base.Events[FormatEvent])?.Invoke(this, e);
	}

	protected virtual void OnFormatInfoChanged(EventArgs e)
	{
		((EventHandler)base.Events[FormatInfoChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnFormatStringChanged(EventArgs e)
	{
		((EventHandler)base.Events[FormatStringChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnFormattingEnabledChanged(EventArgs e)
	{
		((EventHandler)base.Events[FormattingEnabledChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnSelectedIndexChanged(EventArgs e)
	{
		if (data_manager != null && data_manager.Position != SelectedIndex)
		{
			data_manager.Position = SelectedIndex;
		}
	}

	protected virtual void OnSelectedValueChanged(EventArgs e)
	{
		((EventHandler)base.Events[SelectedValueChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnValueMemberChanged(EventArgs e)
	{
		((EventHandler)base.Events[ValueMemberChangedEvent])?.Invoke(this, e);
	}

	protected abstract void RefreshItem(int index);

	protected virtual void RefreshItems()
	{
	}

	protected virtual void SetItemCore(int index, object value)
	{
	}

	protected abstract void SetItemsCore(IList items);

	internal void BindDataItems()
	{
		IList itemsCore;
		if (data_manager == null)
		{
			IList list = new object[0];
			itemsCore = list;
		}
		else
		{
			itemsCore = data_manager.List;
		}
		SetItemsCore(itemsCore);
	}

	private void ConnectToDataSource()
	{
		if (BindingContext == null)
		{
			return;
		}
		CurrencyManager currencyManager = null;
		if (data_source != null)
		{
			currencyManager = (CurrencyManager)BindingContext[data_source];
		}
		if (currencyManager != data_manager)
		{
			if (data_manager != null)
			{
				data_manager.PositionChanged -= OnPositionChanged;
				data_manager.ItemChanged -= OnItemChanged;
			}
			if (currencyManager != null)
			{
				currencyManager.PositionChanged += OnPositionChanged;
				currencyManager.ItemChanged += OnItemChanged;
			}
			data_manager = currencyManager;
		}
	}

	private void OnItemChanged(object sender, ItemChangedEventArgs e)
	{
		if (e.Index == -1)
		{
			SetItemsCore(data_manager.List);
		}
		else
		{
			RefreshItem(e.Index);
		}
		if (AllowSelection && SelectedIndex == -1 && data_manager.Count == 1)
		{
			SelectedIndex = data_manager.Position;
		}
	}

	private void OnPositionChanged(object sender, EventArgs e)
	{
		if (AllowSelection && data_manager.Count > 1)
		{
			SelectedIndex = data_manager.Position;
		}
	}
}
