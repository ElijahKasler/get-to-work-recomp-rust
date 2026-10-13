using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using Unity;

namespace System.Windows.Forms;

[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
[LookupBindingProperties]
public class CheckedListBox : ListBox
{
	public new class ObjectCollection : ListBox.ObjectCollection
	{
		private CheckedListBox owner;

		public ObjectCollection(CheckedListBox owner)
			: base(owner)
		{
			this.owner = owner;
		}

		public int Add(object item, bool isChecked)
		{
			return Add(item, isChecked ? CheckState.Checked : CheckState.Unchecked);
		}

		public int Add(object item, CheckState check)
		{
			int num = Add(item);
			ItemCheckEventArgs e = new ItemCheckEventArgs(num, check, CheckState.Unchecked);
			if (check == CheckState.Checked)
			{
				owner.OnItemCheck(e);
			}
			if (e.NewValue != CheckState.Unchecked)
			{
				owner.check_states[item] = e.NewValue;
			}
			owner.UpdateCollections();
			return num;
		}

		public override void Clear()
		{
			owner.check_states.Clear();
			base.Clear();
		}

		internal override void UpdateSelection(int removed_index)
		{
			owner.check_states.Remove(this[removed_index]);
			base.UpdateSelection(removed_index);
		}
	}

	public class CheckedIndexCollection : IList, ICollection, IEnumerable
	{
		private CheckedListBox owner;

		private ArrayList indices;

		public int Count => indices.Count;

		public bool IsReadOnly => true;

		bool ICollection.IsSynchronized => false;

		bool IList.IsFixedSize => true;

		object ICollection.SyncRoot => this;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int this[int index]
		{
			get
			{
				if (index < 0 || index >= Count)
				{
					throw new ArgumentOutOfRangeException("Index of out range");
				}
				return (int)indices[index];
			}
		}

		object IList.this[int index]
		{
			get
			{
				return indices[index];
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		internal CheckedIndexCollection(CheckedListBox owner)
		{
			indices = new ArrayList();
			base._002Ector();
			this.owner = owner;
		}

		public bool Contains(int index)
		{
			return indices.Contains(index);
		}

		public void CopyTo(Array dest, int index)
		{
			indices.CopyTo(dest, index);
		}

		public IEnumerator GetEnumerator()
		{
			return indices.GetEnumerator();
		}

		int IList.Add(object value)
		{
			throw new NotSupportedException();
		}

		void IList.Clear()
		{
			throw new NotSupportedException();
		}

		bool IList.Contains(object index)
		{
			return Contains((int)index);
		}

		int IList.IndexOf(object index)
		{
			return IndexOf((int)index);
		}

		void IList.Insert(int index, object value)
		{
			throw new NotSupportedException();
		}

		void IList.Remove(object value)
		{
			throw new NotSupportedException();
		}

		void IList.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		public int IndexOf(int index)
		{
			return indices.IndexOf(index);
		}

		internal void Refresh()
		{
			indices.Clear();
			for (int i = 0; i < owner.Items.Count; i++)
			{
				if (owner.check_states.Contains(owner.Items[i]))
				{
					indices.Add(i);
				}
			}
		}

		internal CheckedIndexCollection()
		{
			Unity.ThrowStub.ThrowNotSupportedException();
		}
	}

	public class CheckedItemCollection : IList, ICollection, IEnumerable
	{
		private CheckedListBox owner;

		private ArrayList list;

		public int Count => list.Count;

		public bool IsReadOnly => true;

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public object this[int index]
		{
			get
			{
				if (index < 0 || index >= Count)
				{
					throw new ArgumentOutOfRangeException("Index of out range");
				}
				return list[index];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		bool ICollection.IsSynchronized => true;

		object ICollection.SyncRoot => this;

		bool IList.IsFixedSize => true;

		internal CheckedItemCollection(CheckedListBox owner)
		{
			list = new ArrayList();
			base._002Ector();
			this.owner = owner;
		}

		public bool Contains(object item)
		{
			return list.Contains(item);
		}

		public void CopyTo(Array dest, int index)
		{
			list.CopyTo(dest, index);
		}

		int IList.Add(object value)
		{
			throw new NotSupportedException();
		}

		void IList.Clear()
		{
			throw new NotSupportedException();
		}

		void IList.Insert(int index, object value)
		{
			throw new NotSupportedException();
		}

		void IList.Remove(object value)
		{
			throw new NotSupportedException();
		}

		void IList.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		public int IndexOf(object item)
		{
			return list.IndexOf(item);
		}

		public IEnumerator GetEnumerator()
		{
			return list.GetEnumerator();
		}

		internal void Refresh()
		{
			list.Clear();
			for (int i = 0; i < owner.Items.Count; i++)
			{
				if (owner.check_states.Contains(owner.Items[i]))
				{
					list.Add(owner.Items[i]);
				}
			}
		}

		internal CheckedItemCollection()
		{
			Unity.ThrowStub.ThrowNotSupportedException();
		}
	}

	private CheckedIndexCollection checked_indices;

	private CheckedItemCollection checked_items;

	private Hashtable check_states = new Hashtable();

	private bool check_onclick;

	private bool three_dcheckboxes;

	private static object ItemCheckEvent = new object();

	private int last_clicked_index = -1;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public CheckedIndexCollection CheckedIndices => checked_indices;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public CheckedItemCollection CheckedItems => checked_items;

	[DefaultValue(false)]
	public bool CheckOnClick
	{
		get
		{
			return check_onclick;
		}
		set
		{
			check_onclick = value;
		}
	}

	protected override CreateParams CreateParams => base.CreateParams;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new object DataSource
	{
		get
		{
			return base.DataSource;
		}
		set
		{
			base.DataSource = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public new string DisplayMember
	{
		get
		{
			return base.DisplayMember;
		}
		set
		{
			base.DisplayMember = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public override DrawMode DrawMode
	{
		get
		{
			return DrawMode.Normal;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int ItemHeight
	{
		get
		{
			return base.ItemHeight;
		}
		set
		{
		}
	}

	[Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Localizable(true)]
	public new ObjectCollection Items => (ObjectCollection)base.Items;

	public override SelectionMode SelectionMode
	{
		get
		{
			return base.SelectionMode;
		}
		set
		{
			if (!Enum.IsDefined(typeof(SelectionMode), value))
			{
				throw new InvalidEnumArgumentException("value", (int)value, typeof(SelectionMode));
			}
			if (value == SelectionMode.MultiSimple || value == SelectionMode.MultiExtended)
			{
				throw new ArgumentException("Multi selection not supported on CheckedListBox");
			}
			base.SelectionMode = value;
		}
	}

	[DefaultValue(false)]
	public bool ThreeDCheckBoxes
	{
		get
		{
			return three_dcheckboxes;
		}
		set
		{
			if (three_dcheckboxes != value)
			{
				three_dcheckboxes = value;
				Refresh();
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new string ValueMember
	{
		get
		{
			return base.ValueMember;
		}
		set
		{
			base.ValueMember = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Padding Padding
	{
		get
		{
			return base.Padding;
		}
		set
		{
			base.Padding = value;
		}
	}

	[DefaultValue(false)]
	public bool UseCompatibleTextRendering
	{
		get
		{
			return use_compatible_text_rendering;
		}
		set
		{
			use_compatible_text_rendering = value;
		}
	}

	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public new event EventHandler Click
	{
		add
		{
			base.Click += value;
		}
		remove
		{
			base.Click -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler DataSourceChanged
	{
		add
		{
			base.DataSourceChanged += value;
		}
		remove
		{
			base.DataSourceChanged -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler DisplayMemberChanged
	{
		add
		{
			base.DisplayMemberChanged += value;
		}
		remove
		{
			base.DisplayMemberChanged -= value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public new event DrawItemEventHandler DrawItem
	{
		add
		{
			base.DrawItem += value;
		}
		remove
		{
			base.DrawItem -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event MeasureItemEventHandler MeasureItem
	{
		add
		{
			base.MeasureItem += value;
		}
		remove
		{
			base.MeasureItem -= value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public new event EventHandler ValueMemberChanged
	{
		add
		{
			base.ValueMemberChanged += value;
		}
		remove
		{
			base.ValueMemberChanged -= value;
		}
	}

	public event ItemCheckEventHandler ItemCheck
	{
		add
		{
			base.Events.AddHandler(ItemCheckEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ItemCheckEvent, value);
		}
	}

	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public new event MouseEventHandler MouseClick
	{
		add
		{
			base.MouseClick += value;
		}
		remove
		{
			base.MouseClick -= value;
		}
	}

	public CheckedListBox()
	{
		checked_indices = new CheckedIndexCollection(this);
		checked_items = new CheckedItemCollection(this);
		SetStyle(ControlStyles.ResizeRedraw, value: true);
	}

	protected override AccessibleObject CreateAccessibilityInstance()
	{
		return base.CreateAccessibilityInstance();
	}

	protected override ListBox.ObjectCollection CreateItemCollection()
	{
		return new ObjectCollection(this);
	}

	public bool GetItemChecked(int index)
	{
		return check_states.Contains(Items[index]);
	}

	public CheckState GetItemCheckState(int index)
	{
		if (index < 0 || index >= Items.Count)
		{
			throw new ArgumentOutOfRangeException("Index of out range");
		}
		object key = Items[index];
		if (check_states.Contains(key))
		{
			return (CheckState)check_states[key];
		}
		return CheckState.Unchecked;
	}

	protected override void OnBackColorChanged(EventArgs e)
	{
		base.OnBackColorChanged(e);
	}

	protected override void OnClick(EventArgs e)
	{
		base.OnClick(e);
	}

	protected override void OnDrawItem(DrawItemEventArgs e)
	{
		if (check_states.Contains(Items[e.Index]))
		{
			DrawItemState drawItemState = e.State | DrawItemState.Checked;
			if ((CheckState)check_states[Items[e.Index]] == CheckState.Indeterminate)
			{
				drawItemState |= DrawItemState.Inactive;
			}
			e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, drawItemState, e.ForeColor, e.BackColor);
		}
		ThemeEngine.Current.DrawCheckedListBoxItem(this, e);
	}

	protected override void OnFontChanged(EventArgs e)
	{
		base.OnFontChanged(e);
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
	}

	protected virtual void OnItemCheck(ItemCheckEventArgs ice)
	{
		((ItemCheckEventHandler)base.Events[ItemCheckEvent])?.Invoke(this, ice);
	}

	protected override void OnKeyPress(KeyPressEventArgs e)
	{
		base.OnKeyPress(e);
		if (e.KeyChar == ' ' && base.FocusedItem != -1)
		{
			SetItemChecked(base.FocusedItem, !GetItemChecked(base.FocusedItem));
		}
	}

	protected override void OnMeasureItem(MeasureItemEventArgs e)
	{
		base.OnMeasureItem(e);
	}

	protected override void OnSelectedIndexChanged(EventArgs e)
	{
		base.OnSelectedIndexChanged(e);
	}

	protected override void RefreshItems()
	{
		base.RefreshItems();
	}

	public void SetItemChecked(int index, bool value)
	{
		SetItemCheckState(index, value ? CheckState.Checked : CheckState.Unchecked);
	}

	public void SetItemCheckState(int index, CheckState value)
	{
		if (index < 0 || index >= Items.Count)
		{
			throw new ArgumentOutOfRangeException("Index of out range");
		}
		if (!Enum.IsDefined(typeof(CheckState), value))
		{
			throw new InvalidEnumArgumentException($"Enum argument value '{value}' is not valid for CheckState");
		}
		CheckState itemCheckState = GetItemCheckState(index);
		if (itemCheckState != value)
		{
			ItemCheckEventArgs e = new ItemCheckEventArgs(index, value, itemCheckState);
			OnItemCheck(e);
			switch (e.NewValue)
			{
			case CheckState.Checked:
			case CheckState.Indeterminate:
				check_states[Items[index]] = e.NewValue;
				break;
			case CheckState.Unchecked:
				check_states.Remove(Items[index]);
				break;
			}
			UpdateCollections();
			InvalidateCheckbox(index);
		}
	}

	protected override void WmReflectCommand(ref Message m)
	{
		base.WmReflectCommand(ref m);
	}

	protected override void WndProc(ref Message m)
	{
		base.WndProc(ref m);
	}

	internal override void OnItemClick(int index)
	{
		if ((CheckOnClick || last_clicked_index == index) && index > -1)
		{
			if (GetItemChecked(index))
			{
				SetItemCheckState(index, CheckState.Unchecked);
			}
			else
			{
				SetItemCheckState(index, CheckState.Checked);
			}
		}
		last_clicked_index = index;
		base.OnItemClick(index);
	}

	internal override void CollectionChanged()
	{
		base.CollectionChanged();
		UpdateCollections();
	}

	private void InvalidateCheckbox(int index)
	{
		Rectangle itemDisplayRectangle = GetItemDisplayRectangle(index, base.TopIndex);
		itemDisplayRectangle.X += 2;
		itemDisplayRectangle.Y += (itemDisplayRectangle.Height - 11) / 2;
		itemDisplayRectangle.Width = 11;
		itemDisplayRectangle.Height = 11;
		Invalidate(itemDisplayRectangle);
	}

	private void UpdateCollections()
	{
		CheckedItems.Refresh();
		CheckedIndices.Refresh();
	}
}
