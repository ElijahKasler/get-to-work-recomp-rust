using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms.Layout;
using Unity;

namespace System.Windows.Forms;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[DefaultProperty("Text")]
[DefaultEvent("Click")]
[DesignerSerializer("System.Windows.Forms.Design.ControlCodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[ToolboxItemFilter("System.Windows.Forms")]
[Designer("System.Windows.Forms.Design.ControlDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.IDesigner")]
public class Control : Component, ISynchronizeInvoke, IWin32Window, IBindableComponent, IComponent, IDisposable, IDropTarget, IArrangedElement, IArrangedContainer
{
	internal class ControlNativeWindow : NativeWindow
	{
		private Control owner;

		public Control Owner => owner;

		public ControlNativeWindow(Control control)
		{
			owner = control;
		}

		protected override void OnHandleChange()
		{
			owner.WindowTarget.OnHandleChange(owner.Handle);
		}

		internal static Control ControlFromHandle(IntPtr hWnd)
		{
			return ((ControlNativeWindow)NativeWindow.FromHandle(hWnd))?.owner;
		}

		internal static Control ControlFromChildHandle(IntPtr handle)
		{
			while (handle != IntPtr.Zero)
			{
				ControlNativeWindow controlNativeWindow = (ControlNativeWindow)NativeWindow.FromHandle(handle);
				if (controlNativeWindow != null)
				{
					return controlNativeWindow.owner;
				}
				handle = XplatUI.GetParent(handle, with_owner: false);
			}
			return null;
		}

		protected override void WndProc(ref Message m)
		{
			owner.WindowTarget.OnMessage(ref m);
		}
	}

	private class ControlWindowTarget : IWindowTarget
	{
		private Control control;

		public ControlWindowTarget(Control control)
		{
			this.control = control;
		}

		public void OnHandleChange(IntPtr newHandle)
		{
		}

		public void OnMessage(ref Message m)
		{
			control.WndProc(ref m);
		}
	}

	[ComVisible(true)]
	public class ControlAccessibleObject : AccessibleObject
	{
		private IntPtr handle;

		public override string DefaultAction => base.DefaultAction;

		public override string Description => base.Description;

		public IntPtr Handle
		{
			get
			{
				return handle;
			}
			set
			{
			}
		}

		public override string Help => base.Help;

		public override string KeyboardShortcut => base.KeyboardShortcut;

		public override string Name
		{
			get
			{
				return base.Name;
			}
			set
			{
				base.Name = value;
			}
		}

		public Control Owner => owner;

		public override AccessibleObject Parent => base.Parent;

		public override AccessibleRole Role => base.Role;

		public ControlAccessibleObject(Control ownerControl)
			: base(ownerControl)
		{
			if (ownerControl == null)
			{
				throw new ArgumentNullException("owner");
			}
			handle = ownerControl.Handle;
		}

		public override int GetHelpTopic(out string fileName)
		{
			return base.GetHelpTopic(out fileName);
		}

		[System.MonoTODO("Stub, does nothing")]
		public void NotifyClients(AccessibleEvents accEvent)
		{
		}

		[System.MonoTODO("Stub, does nothing")]
		public void NotifyClients(AccessibleEvents accEvent, int childID)
		{
		}

		[System.MonoTODO("Stub, does nothing")]
		public void NotifyClients(AccessibleEvents accEvent, int objectID, int childID)
		{
		}

		public override string ToString()
		{
			return "ControlAccessibleObject: Owner = " + owner.ToString() + ", Text: " + owner.text;
		}

		public override bool RaiseLiveRegionChanged()
		{
			Unity.ThrowStub.ThrowNotSupportedException();
			return default;
		}
	}

	private class DoubleBuffer : IDisposable
	{
		public Region InvalidRegion;

		private Stack real_graphics;

		private object back_buffer;

		private Control parent;

		private bool pending_disposal;

		public DoubleBuffer(Control parent)
		{
			this.parent = parent;
			real_graphics = new Stack();
			int num = parent.Width;
			int num2 = parent.Height;
			if (num < 1)
			{
				num = 1;
			}
			if (num2 < 1)
			{
				num2 = 1;
			}
			XplatUI.CreateOffscreenDrawable(parent.Handle, num, num2, out back_buffer);
			Invalidate();
		}

		public void Blit(PaintEventArgs pe)
		{
			Graphics offscreenGraphics = XplatUI.GetOffscreenGraphics(back_buffer);
			XplatUI.BlitFromOffscreen(parent.Handle, pe.Graphics, back_buffer, offscreenGraphics, pe.ClipRectangle);
			offscreenGraphics.Dispose();
		}

		public void Start(PaintEventArgs pe)
		{
			real_graphics.Push(pe.SetGraphics(XplatUI.GetOffscreenGraphics(back_buffer)));
		}

		public void End(PaintEventArgs pe)
		{
			Graphics graphics = pe.SetGraphics((Graphics)real_graphics.Pop());
			graphics.Flush();
			if (pending_disposal)
			{
				Dispose();
			}
			else
			{
				XplatUI.BlitFromOffscreen(parent.Handle, pe.Graphics, back_buffer, graphics, pe.ClipRectangle);
				InvalidRegion.Exclude(pe.ClipRectangle);
			}
			graphics.Dispose();
		}

		public void Invalidate()
		{
			if (InvalidRegion != null)
			{
				InvalidRegion.Dispose();
			}
			InvalidRegion = new Region(parent.ClientRectangle);
		}

		public void Dispose()
		{
			if (real_graphics.Count > 0)
			{
				pending_disposal = true;
				return;
			}
			XplatUI.DestroyOffscreenDrawable(back_buffer);
			if (InvalidRegion != null)
			{
				InvalidRegion.Dispose();
			}
			InvalidRegion = null;
			back_buffer = null;
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			Dispose();
		}

		~DoubleBuffer()
		{
			Dispose();
		}
	}

	[ComVisible(false)]
	[ListBindable(false)]
	public class ControlCollection : ArrangedElementCollection, IList, ICollection, IEnumerable, ICloneable
	{
		internal class ControlCollectionEnumerator : IEnumerator
		{
			private ArrayList list;

			private int position = -1;

			public object Current
			{
				get
				{
					try
					{
						return list[position];
					}
					catch (IndexOutOfRangeException)
					{
						throw new InvalidOperationException();
					}
				}
			}

			public ControlCollectionEnumerator(ArrayList collection)
			{
				list = collection;
			}

			public bool MoveNext()
			{
				position++;
				return position < list.Count;
			}

			public void Reset()
			{
				position = -1;
			}
		}

		private ArrayList impl_list;

		private Control[] all_controls;

		private Control owner;

		public Control Owner => owner;

		public virtual Control this[string key]
		{
			get
			{
				int num = IndexOfKey(key);
				if (num >= 0)
				{
					return this[num];
				}
				return null;
			}
		}

		public new virtual Control this[int index]
		{
			get
			{
				if (index < 0 || index >= list.Count)
				{
					throw new ArgumentOutOfRangeException("index", index, "ControlCollection does not have that many controls");
				}
				return (Control)list[index];
			}
		}

		internal ArrayList ImplicitControls => impl_list;

		public ControlCollection(Control owner)
		{
			this.owner = owner;
		}

		public virtual void Add(Control value)
		{
			if (value == null)
			{
				return;
			}
			Form form = value as Form;
			Form form2 = owner as Form;
			bool flag = owner is MdiClient || (form2?.IsMdiContainer ?? false);
			bool topLevel = value.GetTopLevel();
			bool flag2 = form?.IsMdiChild ?? false;
			if (topLevel && !(flag & flag2))
			{
				throw new ArgumentException("Cannot add a top level control to a control.", "value");
			}
			if (flag2 && form.MdiParent != null && form.MdiParent != owner && form.MdiParent != owner.Parent)
			{
				throw new ArgumentException("Form cannot be added to the Controls collection that has a valid MDI parent.", "value");
			}
			if (Contains(value))
			{
				owner.PerformLayout();
				return;
			}
			if (value.tab_index == -1)
			{
				int num = 0;
				int count = owner.child_controls.Count;
				for (int i = 0; i < count; i++)
				{
					int tab_index = owner.child_controls[i].tab_index;
					if (tab_index >= num)
					{
						num = tab_index + 1;
					}
				}
				value.tab_index = num;
			}
			if (value.parent != null)
			{
				value.parent.Controls.Remove(value);
			}
			all_controls = null;
			list.Add(value);
			owner.SuspendLayout();
			value.ChangeParent(owner);
			value.InitLayout();
			owner.ResumeLayout(performLayout: false);
			if (owner.Visible)
			{
				owner.UpdateChildrenZOrder();
			}
			owner.PerformLayout(value, "Parent");
			owner.OnControlAdded(new ControlEventArgs(value));
		}

		internal void AddToList(Control c)
		{
			all_controls = null;
			list.Add(c);
		}

		internal virtual void AddImplicit(Control control)
		{
			if (impl_list == null)
			{
				impl_list = new ArrayList();
			}
			if (AllContains(control))
			{
				owner.PerformLayout();
				return;
			}
			if (control.parent != null)
			{
				control.parent.Controls.Remove(control);
			}
			all_controls = null;
			impl_list.Add(control);
			owner.SuspendLayout();
			control.ChangeParent(owner);
			control.InitLayout();
			owner.ResumeLayout(performLayout: false);
			if (owner.Visible)
			{
				owner.UpdateChildrenZOrder();
			}
			if (control.VisibleInternal)
			{
				owner.PerformLayout(control, "Parent");
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual void AddRange(Control[] controls)
		{
			if (controls == null)
			{
				throw new ArgumentNullException("controls");
			}
			owner.SuspendLayout();
			try
			{
				for (int i = 0; i < controls.Length; i++)
				{
					Add(controls[i]);
				}
			}
			finally
			{
				owner.ResumeLayout();
			}
		}

		internal virtual void AddRangeImplicit(Control[] controls)
		{
			if (controls == null)
			{
				throw new ArgumentNullException("controls");
			}
			owner.SuspendLayout();
			try
			{
				for (int i = 0; i < controls.Length; i++)
				{
					AddImplicit(controls[i]);
				}
			}
			finally
			{
				owner.ResumeLayout(performLayout: false);
			}
		}

		public new virtual void Clear()
		{
			all_controls = null;
			while (list.Count > 0)
			{
				Remove((Control)list[list.Count - 1]);
			}
		}

		internal void DisposeChildrenAndSilentClearContainer()
		{
			Control[] allControls = GetAllControls();
			for (int i = 0; i < allControls.Length; i++)
			{
				allControls[i].parent = null;
				allControls[i].Dispose();
			}
			all_controls = null;
			ClearImplicit();
			base.Clear();
		}

		internal virtual void ClearImplicit()
		{
			if (impl_list != null)
			{
				all_controls = null;
				impl_list.Clear();
			}
		}

		public bool Contains(Control control)
		{
			return list.Contains(control);
		}

		internal bool ImplicitContains(Control value)
		{
			if (impl_list == null)
			{
				return false;
			}
			return impl_list.Contains(value);
		}

		internal bool AllContains(Control value)
		{
			if (!Contains(value))
			{
				return ImplicitContains(value);
			}
			return true;
		}

		public virtual bool ContainsKey(string key)
		{
			return IndexOfKey(key) >= 0;
		}

		public Control[] Find(string key, bool searchAllChildren)
		{
			if (string.IsNullOrEmpty(key))
			{
				throw new ArgumentNullException("key");
			}
			ArrayList arrayList = new ArrayList();
			foreach (Control item in list)
			{
				if (item.Name.Equals(key, StringComparison.CurrentCultureIgnoreCase))
				{
					arrayList.Add(item);
				}
				if (searchAllChildren)
				{
					arrayList.AddRange(item.Controls.Find(key, searchAllChildren: true));
				}
			}
			return (Control[])arrayList.ToArray(typeof(Control));
		}

		public int GetChildIndex(Control child)
		{
			return GetChildIndex(child, throwException: false);
		}

		public virtual int GetChildIndex(Control child, bool throwException)
		{
			int num = list.IndexOf(child);
			if ((num == -1) & throwException)
			{
				throw new ArgumentException("Not a child control", "child");
			}
			return num;
		}

		public override IEnumerator GetEnumerator()
		{
			return new ControlCollectionEnumerator(list);
		}

		internal IEnumerator GetAllEnumerator()
		{
			return GetAllControls().GetEnumerator();
		}

		internal Control[] GetAllControls()
		{
			if (all_controls != null)
			{
				return all_controls;
			}
			if (impl_list == null)
			{
				all_controls = (Control[])list.ToArray(typeof(Control));
				return all_controls;
			}
			all_controls = new Control[list.Count + impl_list.Count];
			impl_list.CopyTo(all_controls);
			list.CopyTo(all_controls, impl_list.Count);
			return all_controls;
		}

		public int IndexOf(Control control)
		{
			return list.IndexOf(control);
		}

		public virtual int IndexOfKey(string key)
		{
			if (string.IsNullOrEmpty(key))
			{
				return -1;
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (((Control)list[i]).Name.Equals(key, StringComparison.CurrentCultureIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public virtual void Remove(Control value)
		{
			if (value != null && list.Contains(value))
			{
				all_controls = null;
				list.Remove(value);
				value.ChangeParent(null);
				owner.UpdateChildrenZOrder();
				owner.PerformLayout(value, "Parent");
				owner.OnControlRemoved(new ControlEventArgs(value));
				owner.InternalGetContainerControl()?.ChildControlRemoved(value);
			}
		}

		internal virtual void RemoveImplicit(Control control)
		{
			if (impl_list != null)
			{
				all_controls = null;
				impl_list.Remove(control);
				owner.PerformLayout(control, "Parent");
				owner.OnControlRemoved(new ControlEventArgs(control));
			}
			control.ChangeParent(null);
			owner.UpdateChildrenZOrder();
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= list.Count)
			{
				throw new ArgumentOutOfRangeException("index", index, "ControlCollection does not have that many controls");
			}
			Remove((Control)list[index]);
		}

		public virtual void RemoveByKey(string key)
		{
			int num = IndexOfKey(key);
			if (num >= 0)
			{
				RemoveAt(num);
			}
		}

		public virtual void SetChildIndex(Control child, int newIndex)
		{
			if (child == null)
			{
				throw new ArgumentNullException("child");
			}
			int num = list.IndexOf(child);
			if (num == -1)
			{
				throw new ArgumentException("Not a child control", "child");
			}
			if (num != newIndex)
			{
				all_controls = null;
				list.RemoveAt(num);
				if (newIndex > list.Count)
				{
					list.Add(child);
				}
				else
				{
					list.Insert(newIndex, child);
				}
				child.UpdateZOrder();
				owner.PerformLayout();
			}
		}

		int IList.Add(object control)
		{
			if (!(control is Control))
			{
				throw new ArgumentException("Object of type Control required", "control");
			}
			if (control == null)
			{
				throw new ArgumentException("control", "Cannot add null controls");
			}
			Add((Control)control);
			return IndexOf((Control)control);
		}

		void IList.Remove(object control)
		{
			if (!(control is Control))
			{
				throw new ArgumentException("Object of type Control required", "control");
			}
			Remove((Control)control);
		}

		object ICloneable.Clone()
		{
			return new ControlCollection(owner)
			{
				list = (ArrayList)list.Clone()
			};
		}
	}

	private delegate void RemoveDelegate(object c);

	internal Rectangle bounds;

	private Rectangle explicit_bounds;

	private bool explicit_bounds_valid;

	internal object creator_thread;

	internal ControlNativeWindow window;

	private IWindowTarget window_target;

	private string name;

	private bool is_created;

	internal bool has_focus;

	internal bool is_visible;

	internal bool is_entered;

	internal bool is_enabled;

	private bool is_accessible;

	private bool is_captured;

	internal bool is_toplevel;

	private bool is_recreating;

	private bool causes_validation;

	private bool is_focusing;

	private int tab_index;

	private bool tab_stop;

	private bool is_disposed;

	private bool is_disposing;

	private Size client_size;

	private Rectangle client_rect;

	private ControlStyles control_style;

	private ImeMode ime_mode;

	private object control_tag;

	internal int mouse_clicks;

	private Cursor cursor;

	internal bool allow_drop;

	private Region clip_region;

	internal Color foreground_color;

	internal Color background_color;

	private Image background_image;

	internal Font font;

	private string text;

	internal BorderStyle border_style;

	private bool show_keyboard_cues;

	internal bool show_focus_cues;

	internal bool force_double_buffer;

	internal int layout_suspended;

	private bool layout_pending;

	private LayoutEventArgs layout_pending_event_args;

	private bool layout_pending_after_resume;

	private bool layout_dirty;

	internal AnchorStyles anchor_style;

	internal DockStyle dock_style;

	private int dist_right;

	private int dist_bottom;

	internal bool can_cache_preferred_size;

	internal Size cached_preferred_size;

	private ControlCollection child_controls;

	private Control parent;

	private BindingContext binding_context;

	private RightToLeft right_to_left;

	private ContextMenu context_menu;

	internal bool use_compatible_text_rendering;

	private bool use_wait_cursor;

	private string accessible_name;

	private string accessible_description;

	private string accessible_default_action;

	private AccessibleRole accessible_role = AccessibleRole.Default;

	private AccessibleObject accessibility_object;

	private DoubleBuffer backbuffer;

	private ControlBindingsCollection data_bindings;

	private static bool verify_thread_handle;

	private Padding padding;

	private ImageLayout backgroundimage_layout;

	private Size maximum_size;

	private Size minimum_size;

	private Padding margin;

	private ContextMenuStrip context_menu_strip;

	private Point auto_scroll_offset;

	private AutoSizeMode auto_size_mode;

	private bool suppressing_key_press;

	private MenuTracker active_tracker;

	private bool auto_size;

	private static object AutoSizeChangedEvent = new object();

	private static object BackColorChangedEvent = new object();

	private static object BackgroundImageChangedEvent = new object();

	private static object BackgroundImageLayoutChangedEvent = new object();

	private static object BindingContextChangedEvent = new object();

	private static object CausesValidationChangedEvent = new object();

	private static object ChangeUICuesEvent = new object();

	private static object ClickEvent = new object();

	private static object ClientSizeChangedEvent = new object();

	private static object ContextMenuChangedEvent = new object();

	private static object ContextMenuStripChangedEvent = new object();

	private static object ControlAddedEvent = new object();

	private static object ControlRemovedEvent = new object();

	private static object CursorChangedEvent = new object();

	private static object DockChangedEvent = new object();

	private static object DoubleClickEvent = new object();

	private static object DragDropEvent = new object();

	private static object DragEnterEvent = new object();

	private static object DragLeaveEvent = new object();

	private static object DragOverEvent = new object();

	private static object EnabledChangedEvent = new object();

	private static object EnterEvent = new object();

	private static object FontChangedEvent = new object();

	private static object ForeColorChangedEvent = new object();

	private static object GiveFeedbackEvent = new object();

	private static object GotFocusEvent = new object();

	private static object HandleCreatedEvent = new object();

	private static object HandleDestroyedEvent = new object();

	private static object HelpRequestedEvent = new object();

	private static object ImeModeChangedEvent = new object();

	private static object InvalidatedEvent = new object();

	private static object KeyDownEvent = new object();

	private static object KeyPressEvent = new object();

	private static object KeyUpEvent = new object();

	private static object LayoutEvent = new object();

	private static object LeaveEvent = new object();

	private static object LocationChangedEvent = new object();

	private static object LostFocusEvent = new object();

	private static object MarginChangedEvent = new object();

	private static object MouseCaptureChangedEvent = new object();

	private static object MouseClickEvent = new object();

	private static object MouseDoubleClickEvent = new object();

	private static object MouseDownEvent = new object();

	private static object MouseEnterEvent = new object();

	private static object MouseHoverEvent = new object();

	private static object MouseLeaveEvent = new object();

	private static object MouseMoveEvent = new object();

	private static object MouseUpEvent = new object();

	private static object MouseWheelEvent = new object();

	private static object MoveEvent = new object();

	private static object PaddingChangedEvent = new object();

	private static object PaintEvent = new object();

	private static object ParentChangedEvent = new object();

	private static object PreviewKeyDownEvent = new object();

	private static object QueryAccessibilityHelpEvent = new object();

	private static object QueryContinueDragEvent = new object();

	private static object RegionChangedEvent = new object();

	private static object ResizeEvent = new object();

	private static object RightToLeftChangedEvent = new object();

	private static object SizeChangedEvent = new object();

	private static object StyleChangedEvent = new object();

	private static object SystemColorsChangedEvent = new object();

	private static object TabIndexChangedEvent = new object();

	private static object TabStopChangedEvent = new object();

	private static object TextChangedEvent = new object();

	private static object ValidatedEvent = new object();

	private static object ValidatingEvent = new object();

	private static object VisibleChangedEvent = new object();

	internal Rectangle PaddingClientRectangle => new Rectangle(ClientRectangle.Left + padding.Left, ClientRectangle.Top + padding.Top, ClientRectangle.Width - padding.Horizontal, ClientRectangle.Height - padding.Vertical);

	internal MenuTracker ActiveTracker
	{
		get
		{
			return active_tracker;
		}
		set
		{
			if (value != active_tracker)
			{
				Capture = value != null;
				active_tracker = value;
			}
		}
	}

	internal bool InternalSelected
	{
		get
		{
			IContainerControl containerControl = GetContainerControl();
			if (containerControl != null && containerControl.ActiveControl == this)
			{
				return true;
			}
			return false;
		}
	}

	internal bool InternalContainsFocus
	{
		get
		{
			IntPtr focus = XplatUI.GetFocus();
			if (IsHandleCreated)
			{
				if (focus == Handle)
				{
					return true;
				}
				Control[] allControls = child_controls.GetAllControls();
				for (int i = 0; i < allControls.Length; i++)
				{
					if (allControls[i].InternalContainsFocus)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	bool IArrangedElement.AutoSize => auto_size;

	bool IArrangedElement.Visible => is_visible;

	int IArrangedElement.DistanceRight
	{
		get
		{
			return dist_right;
		}
		set
		{
			dist_right = value;
		}
	}

	int IArrangedElement.DistanceBottom
	{
		get
		{
			return dist_bottom;
		}
		set
		{
			dist_bottom = value;
		}
	}

	internal bool Entered => is_entered;

	internal bool VisibleInternal => is_visible;

	internal BorderStyle InternalBorderStyle
	{
		get
		{
			return border_style;
		}
		set
		{
			if (!Enum.IsDefined(typeof(BorderStyle), value))
			{
				throw new InvalidEnumArgumentException($"Enum argument value '{value}' is not valid for BorderStyle");
			}
			if (border_style != value)
			{
				border_style = value;
				if (IsHandleCreated)
				{
					XplatUI.SetBorderStyle(window.Handle, (FormBorderStyle)border_style);
					RecreateHandle();
					Refresh();
				}
				else
				{
					client_size = ClientSizeFromSize(bounds.Size);
				}
			}
		}
	}

	internal Size InternalClientSize
	{
		set
		{
			client_size = value;
		}
	}

	internal virtual bool ActivateOnShow => true;

	internal Rectangle ExplicitBounds
	{
		get
		{
			return explicit_bounds;
		}
		set
		{
			explicit_bounds = value;
		}
	}

	Rectangle IArrangedElement.ExplicitBounds => explicit_bounds;

	internal bool ValidationFailed
	{
		get
		{
			return InternalGetContainerControl()?.validation_failed ?? false;
		}
		set
		{
			ContainerControl containerControl = InternalGetContainerControl();
			if (containerControl != null)
			{
				containerControl.validation_failed = value;
			}
		}
	}

	internal bool IsRecreating => is_recreating;

	internal Graphics DeviceContext => Hwnd.GraphicsContext;

	private bool UseDoubleBuffering
	{
		get
		{
			if (!ThemeEngine.Current.DoubleBufferingSupported)
			{
				return false;
			}
			if (force_double_buffer)
			{
				return true;
			}
			if (DoubleBuffered)
			{
				return true;
			}
			return (control_style & ControlStyles.DoubleBuffer) != 0;
		}
	}

	public static Color DefaultBackColor => ThemeEngine.Current.DefaultControlBackColor;

	public static Font DefaultFont => ThemeEngine.Current.DefaultFont;

	public static Color DefaultForeColor => ThemeEngine.Current.DefaultControlForeColor;

	public static Keys ModifierKeys => XplatUI.State.ModifierKeys;

	public static MouseButtons MouseButtons => XplatUI.State.MouseButtons;

	public static Point MousePosition => Cursor.Position;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[System.MonoTODO("Stub, value is not used")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static bool CheckForIllegalCrossThreadCalls
	{
		get
		{
			return verify_thread_handle;
		}
		set
		{
			verify_thread_handle = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public AccessibleObject AccessibilityObject
	{
		get
		{
			if (accessibility_object == null)
			{
				accessibility_object = CreateAccessibilityInstance();
			}
			return accessibility_object;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	public string AccessibleDefaultActionDescription
	{
		get
		{
			return accessible_default_action;
		}
		set
		{
			accessible_default_action = value;
		}
	}

	[Localizable(true)]
	[MWFCategory("Accessibility")]
	[DefaultValue(null)]
	public string AccessibleDescription
	{
		get
		{
			return accessible_description;
		}
		set
		{
			accessible_description = value;
		}
	}

	[Localizable(true)]
	[DefaultValue(null)]
	[MWFCategory("Accessibility")]
	public string AccessibleName
	{
		get
		{
			return accessible_name;
		}
		set
		{
			accessible_name = value;
		}
	}

	[MWFDescription("Role of the control")]
	[MWFCategory("Accessibility")]
	[DefaultValue(AccessibleRole.Default)]
	public AccessibleRole AccessibleRole
	{
		get
		{
			return accessible_role;
		}
		set
		{
			accessible_role = value;
		}
	}

	[MWFCategory("Behavior")]
	[DefaultValue(false)]
	public virtual bool AllowDrop
	{
		get
		{
			return allow_drop;
		}
		set
		{
			if (allow_drop != value)
			{
				allow_drop = value;
				if (IsHandleCreated)
				{
					UpdateStyles();
					XplatUI.SetAllowDrop(Handle, value);
				}
			}
		}
	}

	[RefreshProperties(RefreshProperties.Repaint)]
	[MWFCategory("Layout")]
	[Localizable(true)]
	[DefaultValue(AnchorStyles.Top | AnchorStyles.Left)]
	public virtual AnchorStyles Anchor
	{
		get
		{
			return anchor_style;
		}
		set
		{
			if (anchor_style != value)
			{
				anchor_style = value;
				dock_style = DockStyle.None;
				if (parent != null)
				{
					parent.LayoutEngine.InitLayout(this, BoundsSpecified.All);
					parent.PerformLayout(this, "Anchor");
				}
			}
		}
	}

	[Browsable(false)]
	[DefaultValue(typeof(Point), "0, 0")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public virtual Point AutoScrollOffset
	{
		get
		{
			return auto_scroll_offset;
		}
		set
		{
			auto_scroll_offset = value;
		}
	}

	[DefaultValue(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[RefreshProperties(RefreshProperties.All)]
	[Localizable(true)]
	public virtual bool AutoSize
	{
		get
		{
			return auto_size;
		}
		set
		{
			if (auto_size != value)
			{
				auto_size = value;
				if (!value)
				{
					Size = explicit_bounds.Size;
				}
				else if (Parent != null)
				{
					Parent.LayoutEngine.InitLayout(this, BoundsSpecified.Size);
					Parent.PerformLayout(this, "AutoSize");
				}
				OnAutoSizeChanged(EventArgs.Empty);
			}
		}
	}

	[AmbientValue("{Width=0, Height=0}")]
	[MWFCategory("Layout")]
	public virtual Size MaximumSize
	{
		get
		{
			return maximum_size;
		}
		set
		{
			if (maximum_size != value)
			{
				maximum_size = value;
				Size = ApplySizeConstraints(Size);
				if (parent != null)
				{
					parent.PerformLayout(this, "MinimumSize");
				}
			}
		}
	}

	[MWFCategory("Layout")]
	public virtual Size MinimumSize
	{
		get
		{
			return minimum_size;
		}
		set
		{
			if (minimum_size != value)
			{
				minimum_size = value;
				Size = ApplySizeConstraints(Size);
				if (parent != null)
				{
					parent.PerformLayout(this, "MaximumSize");
				}
			}
		}
	}

	[DispId(-501)]
	[MWFCategory("Appearance")]
	public virtual Color BackColor
	{
		get
		{
			if (background_color.IsEmpty)
			{
				if (parent != null)
				{
					Color backColor = parent.BackColor;
					if (backColor.A == byte.MaxValue || GetStyle(ControlStyles.SupportsTransparentBackColor))
					{
						return backColor;
					}
				}
				return DefaultBackColor;
			}
			return background_color;
		}
		set
		{
			if (!value.IsEmpty && value.A != byte.MaxValue && !GetStyle(ControlStyles.SupportsTransparentBackColor))
			{
				throw new ArgumentException("Transparent background colors are not supported on this control");
			}
			if (background_color != value)
			{
				background_color = value;
				SetChildColor(this);
				OnBackColorChanged(EventArgs.Empty);
				Invalidate();
			}
		}
	}

	[MWFCategory("Appearance")]
	[DefaultValue(null)]
	[Localizable(true)]
	public virtual Image BackgroundImage
	{
		get
		{
			return background_image;
		}
		set
		{
			if (background_image != value)
			{
				background_image = value;
				OnBackgroundImageChanged(EventArgs.Empty);
				Invalidate();
			}
		}
	}

	[DefaultValue(ImageLayout.Tile)]
	[Localizable(true)]
	[MWFCategory("Appearance")]
	public virtual ImageLayout BackgroundImageLayout
	{
		get
		{
			return backgroundimage_layout;
		}
		set
		{
			if (Array.IndexOf(Enum.GetValues(typeof(ImageLayout)), value) == -1)
			{
				throw new InvalidEnumArgumentException("value", (int)value, typeof(ImageLayout));
			}
			if (value != backgroundimage_layout)
			{
				backgroundimage_layout = value;
				Invalidate();
				OnBackgroundImageLayoutChanged(EventArgs.Empty);
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual BindingContext BindingContext
	{
		get
		{
			if (binding_context != null)
			{
				return binding_context;
			}
			if (Parent == null)
			{
				return null;
			}
			binding_context = Parent.BindingContext;
			return binding_context;
		}
		set
		{
			if (binding_context != value)
			{
				binding_context = value;
				OnBindingContextChanged(EventArgs.Empty);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int Bottom => bounds.Bottom;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public Rectangle Bounds
	{
		get
		{
			return bounds;
		}
		set
		{
			SetBounds(value.Left, value.Top, value.Width, value.Height, BoundsSpecified.All);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool CanFocus
	{
		get
		{
			if (IsHandleCreated && Visible && Enabled)
			{
				return true;
			}
			return false;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public bool CanSelect
	{
		get
		{
			if (!GetStyle(ControlStyles.Selectable))
			{
				return false;
			}
			if (!is_visible || !is_enabled)
			{
				return false;
			}
			for (Control control = this; control != null; control = control.parent)
			{
				if (!control.is_visible || !control.is_enabled)
				{
					return false;
				}
			}
			return true;
		}
	}

	internal virtual bool InternalCapture
	{
		get
		{
			return Capture;
		}
		set
		{
			Capture = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Capture
	{
		get
		{
			return is_captured;
		}
		set
		{
			if (value == is_captured)
			{
				return;
			}
			if (value)
			{
				is_captured = true;
				XplatUI.GrabWindow(Handle, IntPtr.Zero);
				return;
			}
			if (IsHandleCreated)
			{
				XplatUI.UngrabWindow(Handle);
			}
			is_captured = false;
		}
	}

	[MWFCategory("Focus")]
	[DefaultValue(true)]
	public bool CausesValidation
	{
		get
		{
			return causes_validation;
		}
		set
		{
			if (causes_validation != value)
			{
				causes_validation = value;
				OnCausesValidationChanged(EventArgs.Empty);
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public Rectangle ClientRectangle
	{
		get
		{
			client_rect.Width = client_size.Width;
			client_rect.Height = client_size.Height;
			return client_rect;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public Size ClientSize
	{
		get
		{
			return client_size;
		}
		set
		{
			SetClientSizeCore(value.Width, value.Height);
			OnClientSizeChanged(EventArgs.Empty);
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Description("ControlCompanyNameDescr")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string CompanyName => "Mono Project, Novell, Inc.";

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ContainsFocus
	{
		get
		{
			IntPtr focus = XplatUI.GetFocus();
			if (IsHandleCreated)
			{
				if (focus == Handle)
				{
					return true;
				}
				for (int i = 0; i < child_controls.Count; i++)
				{
					if (child_controls[i].ContainsFocus)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	[DefaultValue(null)]
	[Browsable(false)]
	[MWFCategory("Behavior")]
	public virtual ContextMenu ContextMenu
	{
		get
		{
			return ContextMenuInternal;
		}
		set
		{
			ContextMenuInternal = value;
		}
	}

	internal virtual ContextMenu ContextMenuInternal
	{
		get
		{
			return context_menu;
		}
		set
		{
			if (context_menu != value)
			{
				context_menu = value;
				OnContextMenuChanged(EventArgs.Empty);
			}
		}
	}

	[MWFCategory("Behavior")]
	[DefaultValue(null)]
	public virtual ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return context_menu_strip;
		}
		set
		{
			if (context_menu_strip != value)
			{
				context_menu_strip = value;
				if (value != null)
				{
					value.AssociatedControl = this;
				}
				OnContextMenuStripChanged(EventArgs.Empty);
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	public ControlCollection Controls => child_controls;

	ArrangedElementCollection IArrangedContainer.Controls => child_controls;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Created
	{
		get
		{
			if (!is_disposed)
			{
				return is_created;
			}
			return false;
		}
	}

	[AmbientValue(null)]
	[MWFCategory("Appearance")]
	public virtual Cursor Cursor
	{
		get
		{
			if (use_wait_cursor)
			{
				return Cursors.WaitCursor;
			}
			if (cursor != null)
			{
				return cursor;
			}
			if (parent != null)
			{
				return parent.Cursor;
			}
			return Cursors.Default;
		}
		set
		{
			if (!(cursor == value))
			{
				cursor = value;
				UpdateCursor();
				OnCursorChanged(EventArgs.Empty);
			}
		}
	}

	[RefreshProperties(RefreshProperties.All)]
	[ParenthesizePropertyName(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[MWFCategory("Data")]
	public ControlBindingsCollection DataBindings
	{
		get
		{
			if (data_bindings == null)
			{
				data_bindings = new ControlBindingsCollection(this);
			}
			return data_bindings;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Rectangle DisplayRectangle => ClientRectangle;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public bool Disposing => is_disposing;

	[MWFCategory("Layout")]
	[DefaultValue(DockStyle.None)]
	[RefreshProperties(RefreshProperties.Repaint)]
	[Localizable(true)]
	public virtual DockStyle Dock
	{
		get
		{
			return dock_style;
		}
		set
		{
			if (dock_style != value)
			{
				if (!Enum.IsDefined(typeof(DockStyle), value))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(DockStyle));
				}
				dock_style = value;
				anchor_style = AnchorStyles.Top | AnchorStyles.Left;
				if (!explicit_bounds_valid)
				{
					explicit_bounds = bounds;
					explicit_bounds_valid = true;
				}
				bounds = explicit_bounds;
				if (parent != null)
				{
					parent.LayoutEngine.InitLayout(this, BoundsSpecified.All);
					parent.PerformLayout(this, "Dock");
				}
				else if (Controls.Count > 0)
				{
					PerformLayout();
				}
				OnDockChanged(EventArgs.Empty);
			}
		}
	}

	protected virtual bool DoubleBuffered
	{
		get
		{
			return (control_style & ControlStyles.OptimizedDoubleBuffer) != 0;
		}
		set
		{
			if (value != DoubleBuffered)
			{
				if (value)
				{
					SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
				}
				else
				{
					SetStyle(ControlStyles.OptimizedDoubleBuffer, value: false);
				}
			}
		}
	}

	[DispId(-514)]
	[Localizable(true)]
	[MWFCategory("Behavior")]
	public bool Enabled
	{
		get
		{
			if (!is_enabled)
			{
				return false;
			}
			if (parent != null)
			{
				return parent.Enabled;
			}
			return true;
		}
		set
		{
			if (is_enabled != value)
			{
				bool num = is_enabled;
				is_enabled = value;
				if (!value)
				{
					UpdateCursor();
				}
				if (num != value && !value && has_focus)
				{
					SelectNextControl(this, forward: true, tabStopOnly: true, nested: true, wrap: true);
				}
				OnEnabledChanged(EventArgs.Empty);
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual bool Focused => has_focus;

	[Localizable(true)]
	[MWFCategory("Appearance")]
	[DispId(-512)]
	[AmbientValue(null)]
	public virtual Font Font
	{
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Drawing.Font, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		get
		{
			if (this.font != null)
			{
				return this.font;
			}
			if (parent != null)
			{
				Font font = parent.Font;
				if (font != null)
				{
					return font;
				}
			}
			return DefaultFont;
		}
		[param: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Drawing.Font, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		set
		{
			if (font == null || font != value)
			{
				font = value;
				Invalidate();
				OnFontChanged(EventArgs.Empty);
			}
		}
	}

	[MWFCategory("Appearance")]
	[DispId(-513)]
	public virtual Color ForeColor
	{
		get
		{
			if (foreground_color.IsEmpty)
			{
				if (parent != null)
				{
					return parent.ForeColor;
				}
				return DefaultForeColor;
			}
			return foreground_color;
		}
		set
		{
			if (foreground_color != value)
			{
				foreground_color = value;
				Invalidate();
				OnForeColorChanged(EventArgs.Empty);
			}
		}
	}

	[DispId(-515)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IntPtr Handle
	{
		get
		{
			if (verify_thread_handle && InvokeRequired)
			{
				throw new InvalidOperationException("Cross-thread access of handle detected. Handle access only valid on thread that created the control");
			}
			if (!IsHandleCreated)
			{
				CreateHandle();
			}
			return window.Handle;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool HasChildren
	{
		get
		{
			if (child_controls.Count > 0)
			{
				return true;
			}
			return false;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(false)]
	public int Height
	{
		get
		{
			return bounds.Height;
		}
		set
		{
			SetBounds(bounds.X, bounds.Y, bounds.Width, value, BoundsSpecified.Height);
		}
	}

	[AmbientValue(ImeMode.Inherit)]
	[Localizable(true)]
	[MWFCategory("Behavior")]
	public ImeMode ImeMode
	{
		get
		{
			if (ime_mode == ImeMode.Inherit)
			{
				if (parent != null)
				{
					return parent.ImeMode;
				}
				return ImeMode.NoControl;
			}
			return ime_mode;
		}
		set
		{
			if (ime_mode != value)
			{
				ime_mode = value;
				OnImeModeChanged(EventArgs.Empty);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool InvokeRequired
	{
		get
		{
			if (creator_thread != null && creator_thread != Thread.CurrentThread)
			{
				return true;
			}
			return false;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsAccessible
	{
		get
		{
			return is_accessible;
		}
		set
		{
			is_accessible = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsDisposed => is_disposed;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public bool IsHandleCreated
	{
		get
		{
			if (window == null || window.Handle == IntPtr.Zero)
			{
				return false;
			}
			return true;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[System.MonoNotSupported("RTL is not supported")]
	[Browsable(false)]
	public bool IsMirrored => false;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	public virtual LayoutEngine LayoutEngine => DefaultLayout.Instance;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public int Left
	{
		get
		{
			return bounds.Left;
		}
		set
		{
			SetBounds(value, bounds.Y, bounds.Width, bounds.Height, BoundsSpecified.X);
		}
	}

	[MWFCategory("Layout")]
	[Localizable(true)]
	public Point Location
	{
		get
		{
			return bounds.Location;
		}
		set
		{
			SetBounds(value.X, value.Y, bounds.Width, bounds.Height, BoundsSpecified.Location);
		}
	}

	[Localizable(true)]
	[MWFCategory("Layout")]
	public Padding Margin
	{
		get
		{
			return margin;
		}
		set
		{
			if (margin != value)
			{
				margin = value;
				if (Parent != null)
				{
					Parent.PerformLayout(this, "Margin");
				}
				OnMarginChanged(EventArgs.Empty);
			}
		}
	}

	[Browsable(false)]
	public string Name
	{
		get
		{
			return name;
		}
		set
		{
			name = value;
		}
	}

	[Localizable(true)]
	[MWFCategory("Layout")]
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
				OnPaddingChanged(EventArgs.Empty);
				if (AutoSize && Parent != null)
				{
					parent.PerformLayout(this, "Padding");
				}
				else
				{
					PerformLayout(this, "Padding");
				}
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Control Parent
	{
		get
		{
			return parent;
		}
		set
		{
			if (value == this)
			{
				throw new ArgumentException("A circular control reference has been made. A control cannot be owned or parented to itself.");
			}
			if (parent != value)
			{
				if (value == null)
				{
					parent.Controls.Remove(this);
					parent = null;
				}
				else
				{
					value.Controls.Add(this);
				}
			}
		}
	}

	IArrangedContainer IArrangedElement.Parent => parent;

	[Browsable(false)]
	public Size PreferredSize => GetPreferredSize(Size.Empty);

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public string ProductName
	{
		get
		{
			Type typeFromHandle = typeof(AssemblyProductAttribute);
			object[] customAttributes = GetType().Module.Assembly.GetCustomAttributes(typeFromHandle, inherit: false);
			AssemblyProductAttribute assemblyProductAttribute = null;
			if (customAttributes != null && customAttributes.Length != 0)
			{
				assemblyProductAttribute = (AssemblyProductAttribute)customAttributes[0];
			}
			if (assemblyProductAttribute == null)
			{
				return GetType().Namespace;
			}
			return assemblyProductAttribute.Product;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public string ProductVersion
	{
		get
		{
			Type typeFromHandle = typeof(AssemblyVersionAttribute);
			object[] customAttributes = GetType().Module.Assembly.GetCustomAttributes(typeFromHandle, inherit: false);
			if (customAttributes == null || customAttributes.Length < 1)
			{
				return "1.0.0.0";
			}
			return ((AssemblyVersionAttribute)customAttributes[0]).Version;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool RecreatingHandle => is_recreating;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Region Region
	{
		get
		{
			return clip_region;
		}
		set
		{
			if (clip_region != value)
			{
				if (IsHandleCreated)
				{
					XplatUI.SetClipRegion(Handle, value);
				}
				clip_region = value;
				OnRegionChanged(EventArgs.Empty);
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	public int Right => bounds.Right;

	[AmbientValue(RightToLeft.Inherit)]
	[Localizable(true)]
	[MWFCategory("Appearance")]
	public virtual RightToLeft RightToLeft
	{
		get
		{
			if (right_to_left == RightToLeft.Inherit)
			{
				if (parent != null)
				{
					return parent.RightToLeft;
				}
				return RightToLeft.No;
			}
			return right_to_left;
		}
		set
		{
			if (value != right_to_left)
			{
				right_to_left = value;
				OnRightToLeftChanged(EventArgs.Empty);
				PerformLayout();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public override ISite Site
	{
		get
		{
			return base.Site;
		}
		set
		{
			base.Site = value;
			if (value != null)
			{
				AmbientProperties ambientProperties = (AmbientProperties)value.GetService(typeof(AmbientProperties));
				if (ambientProperties != null)
				{
					BackColor = ambientProperties.BackColor;
					ForeColor = ambientProperties.ForeColor;
					Cursor = ambientProperties.Cursor;
					Font = ambientProperties.Font;
				}
			}
		}
	}

	[MWFCategory("Layout")]
	[Localizable(true)]
	public Size Size
	{
		get
		{
			return new Size(Width, Height);
		}
		set
		{
			SetBounds(bounds.X, bounds.Y, value.Width, value.Height, BoundsSpecified.Size);
		}
	}

	[Localizable(true)]
	[MWFCategory("Behavior")]
	[MergableProperty(false)]
	public int TabIndex
	{
		get
		{
			if (tab_index != -1)
			{
				return tab_index;
			}
			return 0;
		}
		set
		{
			if (tab_index != value)
			{
				tab_index = value;
				OnTabIndexChanged(EventArgs.Empty);
			}
		}
	}

	[MWFCategory("Behavior")]
	[DefaultValue(true)]
	[DispId(-516)]
	public bool TabStop
	{
		get
		{
			return tab_stop;
		}
		set
		{
			if (tab_stop != value)
			{
				tab_stop = value;
				OnTabStopChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(null)]
	[TypeConverter(typeof(StringConverter))]
	[Bindable(true)]
	[Localizable(false)]
	[MWFCategory("Data")]
	public object Tag
	{
		get
		{
			return control_tag;
		}
		set
		{
			control_tag = value;
		}
	}

	[DispId(-517)]
	[MWFCategory("Appearance")]
	[Bindable(true)]
	[Localizable(true)]
	public virtual string Text
	{
		get
		{
			return text;
		}
		set
		{
			if (value == null)
			{
				value = string.Empty;
			}
			if (text != value)
			{
				text = value;
				UpdateWindowText();
				OnTextChanged(EventArgs.Empty);
				if (AutoSize && Parent != null && !(this is Label))
				{
					Parent.PerformLayout(this, "Text");
				}
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public int Top
	{
		get
		{
			return bounds.Top;
		}
		set
		{
			SetBounds(bounds.X, value, bounds.Width, bounds.Height, BoundsSpecified.Y);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Control TopLevelControl
	{
		get
		{
			Control control = this;
			while (control != null && !control.GetTopLevel())
			{
				control = control.parent;
			}
			return control;
		}
	}

	[DefaultValue(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[MWFCategory("Appearance")]
	[Browsable(true)]
	public bool UseWaitCursor
	{
		get
		{
			return use_wait_cursor;
		}
		set
		{
			if (use_wait_cursor != value)
			{
				use_wait_cursor = value;
				UpdateCursor();
				OnCursorChanged(EventArgs.Empty);
			}
		}
	}

	[MWFCategory("Behavior")]
	[Localizable(true)]
	public bool Visible
	{
		get
		{
			if (!is_visible)
			{
				return false;
			}
			if (parent != null)
			{
				return parent.Visible;
			}
			return true;
		}
		set
		{
			if (is_visible != value)
			{
				SetVisibleCore(value);
				if (parent != null)
				{
					parent.PerformLayout(this, "Visible");
				}
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public int Width
	{
		get
		{
			return bounds.Width;
		}
		set
		{
			SetBounds(bounds.X, bounds.Y, value, bounds.Height, BoundsSpecified.Width);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public IWindowTarget WindowTarget
	{
		get
		{
			return window_target;
		}
		set
		{
			window_target = value;
		}
	}

	protected virtual bool CanEnableIme => false;

	protected override bool CanRaiseEvents => true;

	protected virtual CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = new CreateParams();
			try
			{
				createParams.Caption = Text;
			}
			catch
			{
				createParams.Caption = text;
			}
			try
			{
				createParams.X = Left;
			}
			catch
			{
				createParams.X = bounds.X;
			}
			try
			{
				createParams.Y = Top;
			}
			catch
			{
				createParams.Y = bounds.Y;
			}
			try
			{
				createParams.Width = Width;
			}
			catch
			{
				createParams.Width = bounds.Width;
			}
			try
			{
				createParams.Height = Height;
			}
			catch
			{
				createParams.Height = bounds.Height;
			}
			createParams.ClassName = XplatUI.GetDefaultClassName(GetType());
			createParams.ClassStyle = 40;
			createParams.ExStyle = 0;
			createParams.Param = 0;
			if (allow_drop)
			{
				createParams.ExStyle |= 16;
			}
			if (parent != null && parent.IsHandleCreated)
			{
				createParams.Parent = parent.Handle;
			}
			createParams.Style = 1174405120;
			if (is_visible)
			{
				createParams.Style |= 268435456;
			}
			if (!is_enabled)
			{
				createParams.Style |= 134217728;
			}
			switch (border_style)
			{
			case BorderStyle.FixedSingle:
				createParams.Style |= 8388608;
				break;
			case BorderStyle.Fixed3D:
				createParams.ExStyle |= 512;
				break;
			}
			createParams.control = this;
			return createParams;
		}
	}

	protected virtual Cursor DefaultCursor => Cursors.Default;

	protected virtual ImeMode DefaultImeMode => ImeMode.Inherit;

	protected virtual Padding DefaultMargin => new Padding(3);

	protected virtual Size DefaultMaximumSize => default;

	protected virtual Size DefaultMinimumSize => default;

	protected virtual Padding DefaultPadding => default;

	protected virtual Size DefaultSize => new Size(0, 0);

	protected int FontHeight
	{
		get
		{
			return Font.Height;
		}
		set
		{
		}
	}

	[Obsolete]
	protected bool RenderRightToLeft => right_to_left == RightToLeft.Yes;

	protected bool ResizeRedraw
	{
		get
		{
			return GetStyle(ControlStyles.ResizeRedraw);
		}
		set
		{
			SetStyle(ControlStyles.ResizeRedraw, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual bool ScaleChildren => ScaleChildrenInternal;

	internal virtual bool ScaleChildrenInternal => true;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected internal virtual bool ShowFocusCues
	{
		get
		{
			if (this is Form)
			{
				return show_focus_cues;
			}
			if (parent == null)
			{
				return false;
			}
			return FindForm()?.show_focus_cues ?? false;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected internal virtual bool ShowKeyboardCues => ShowKeyboardCuesInternal;

	internal bool ShowKeyboardCuesInternal
	{
		get
		{
			if (SystemInformation.MenuAccessKeysUnderlined || base.DesignMode)
			{
				return true;
			}
			return show_keyboard_cues;
		}
	}

	protected SolidBrush BackColorBrush => ThemeEngine.Current.ResPool.GetSolidBrush(BackColor);

	public int DeviceDpi
	{
		get
		{
			Unity.ThrowStub.ThrowNotSupportedException();
			return default;
		}
	}

	protected virtual ImeMode ImeModeBase
	{
		get
		{
			Unity.ThrowStub.ThrowNotSupportedException();
			return default;
		}
		set
		{
			Unity.ThrowStub.ThrowNotSupportedException();
		}
	}

	protected static ImeMode PropagatingImeMode
	{
		get
		{
			Unity.ThrowStub.ThrowNotSupportedException();
			return default;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public event EventHandler AutoSizeChanged
	{
		add
		{
			base.Events.AddHandler(AutoSizeChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(AutoSizeChangedEvent, value);
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

	public event EventHandler BackgroundImageChanged
	{
		add
		{
			base.Events.AddHandler(BackgroundImageChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(BackgroundImageChangedEvent, value);
		}
	}

	public event EventHandler BackgroundImageLayoutChanged
	{
		add
		{
			base.Events.AddHandler(BackgroundImageLayoutChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(BackgroundImageLayoutChangedEvent, value);
		}
	}

	public event EventHandler BindingContextChanged
	{
		add
		{
			base.Events.AddHandler(BindingContextChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(BindingContextChangedEvent, value);
		}
	}

	public event EventHandler CausesValidationChanged
	{
		add
		{
			base.Events.AddHandler(CausesValidationChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CausesValidationChangedEvent, value);
		}
	}

	public event UICuesEventHandler ChangeUICues
	{
		add
		{
			base.Events.AddHandler(ChangeUICuesEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ChangeUICuesEvent, value);
		}
	}

	public event EventHandler Click
	{
		add
		{
			base.Events.AddHandler(ClickEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ClickEvent, value);
		}
	}

	public event EventHandler ClientSizeChanged
	{
		add
		{
			base.Events.AddHandler(ClientSizeChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ClientSizeChangedEvent, value);
		}
	}

	[Browsable(false)]
	public event EventHandler ContextMenuChanged
	{
		add
		{
			base.Events.AddHandler(ContextMenuChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ContextMenuChangedEvent, value);
		}
	}

	public event EventHandler ContextMenuStripChanged
	{
		add
		{
			base.Events.AddHandler(ContextMenuStripChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ContextMenuStripChangedEvent, value);
		}
	}

	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public event ControlEventHandler ControlAdded
	{
		add
		{
			base.Events.AddHandler(ControlAddedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ControlAddedEvent, value);
		}
	}

	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public event ControlEventHandler ControlRemoved
	{
		add
		{
			base.Events.AddHandler(ControlRemovedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ControlRemovedEvent, value);
		}
	}

	[MWFCategory("PropertyChanged")]
	[MWFDescription("Fired when the cursor for the control has been changed")]
	public event EventHandler CursorChanged
	{
		add
		{
			base.Events.AddHandler(CursorChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CursorChangedEvent, value);
		}
	}

	public event EventHandler DockChanged
	{
		add
		{
			base.Events.AddHandler(DockChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(DockChangedEvent, value);
		}
	}

	public event EventHandler DoubleClick
	{
		add
		{
			base.Events.AddHandler(DoubleClickEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(DoubleClickEvent, value);
		}
	}

	public event DragEventHandler DragDrop
	{
		add
		{
			base.Events.AddHandler(DragDropEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(DragDropEvent, value);
		}
	}

	public event DragEventHandler DragEnter
	{
		add
		{
			base.Events.AddHandler(DragEnterEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(DragEnterEvent, value);
		}
	}

	public event EventHandler DragLeave
	{
		add
		{
			base.Events.AddHandler(DragLeaveEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(DragLeaveEvent, value);
		}
	}

	public event DragEventHandler DragOver
	{
		add
		{
			base.Events.AddHandler(DragOverEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(DragOverEvent, value);
		}
	}

	public event EventHandler EnabledChanged
	{
		add
		{
			base.Events.AddHandler(EnabledChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(EnabledChangedEvent, value);
		}
	}

	public event EventHandler Enter
	{
		add
		{
			base.Events.AddHandler(EnterEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(EnterEvent, value);
		}
	}

	public event EventHandler FontChanged
	{
		add
		{
			base.Events.AddHandler(FontChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(FontChangedEvent, value);
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

	public event GiveFeedbackEventHandler GiveFeedback
	{
		add
		{
			base.Events.AddHandler(GiveFeedbackEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(GiveFeedbackEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	public event EventHandler GotFocus
	{
		add
		{
			base.Events.AddHandler(GotFocusEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(GotFocusEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	public event EventHandler HandleCreated
	{
		add
		{
			base.Events.AddHandler(HandleCreatedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(HandleCreatedEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	public event EventHandler HandleDestroyed
	{
		add
		{
			base.Events.AddHandler(HandleDestroyedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(HandleDestroyedEvent, value);
		}
	}

	public event HelpEventHandler HelpRequested
	{
		add
		{
			base.Events.AddHandler(HelpRequestedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(HelpRequestedEvent, value);
		}
	}

	public event EventHandler ImeModeChanged
	{
		add
		{
			base.Events.AddHandler(ImeModeChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ImeModeChangedEvent, value);
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public event InvalidateEventHandler Invalidated
	{
		add
		{
			base.Events.AddHandler(InvalidatedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(InvalidatedEvent, value);
		}
	}

	public event KeyEventHandler KeyDown
	{
		add
		{
			base.Events.AddHandler(KeyDownEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(KeyDownEvent, value);
		}
	}

	public event KeyPressEventHandler KeyPress
	{
		add
		{
			base.Events.AddHandler(KeyPressEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(KeyPressEvent, value);
		}
	}

	public event KeyEventHandler KeyUp
	{
		add
		{
			base.Events.AddHandler(KeyUpEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(KeyUpEvent, value);
		}
	}

	public event LayoutEventHandler Layout
	{
		add
		{
			base.Events.AddHandler(LayoutEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(LayoutEvent, value);
		}
	}

	public event EventHandler Leave
	{
		add
		{
			base.Events.AddHandler(LeaveEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(LeaveEvent, value);
		}
	}

	public event EventHandler LocationChanged
	{
		add
		{
			base.Events.AddHandler(LocationChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(LocationChangedEvent, value);
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public event EventHandler LostFocus
	{
		add
		{
			base.Events.AddHandler(LostFocusEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(LostFocusEvent, value);
		}
	}

	public event EventHandler MarginChanged
	{
		add
		{
			base.Events.AddHandler(MarginChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(MarginChangedEvent, value);
		}
	}

	public event EventHandler MouseCaptureChanged
	{
		add
		{
			base.Events.AddHandler(MouseCaptureChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(MouseCaptureChangedEvent, value);
		}
	}

	public event MouseEventHandler MouseClick
	{
		add
		{
			base.Events.AddHandler(MouseClickEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(MouseClickEvent, value);
		}
	}

	public event MouseEventHandler MouseDoubleClick
	{
		add
		{
			base.Events.AddHandler(MouseDoubleClickEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(MouseDoubleClickEvent, value);
		}
	}

	public event MouseEventHandler MouseDown
	{
		add
		{
			base.Events.AddHandler(MouseDownEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(MouseDownEvent, value);
		}
	}

	public event EventHandler MouseEnter
	{
		add
		{
			base.Events.AddHandler(MouseEnterEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(MouseEnterEvent, value);
		}
	}

	public event EventHandler MouseHover
	{
		add
		{
			base.Events.AddHandler(MouseHoverEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(MouseHoverEvent, value);
		}
	}

	public event EventHandler MouseLeave
	{
		add
		{
			base.Events.AddHandler(MouseLeaveEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(MouseLeaveEvent, value);
		}
	}

	public event MouseEventHandler MouseMove
	{
		add
		{
			base.Events.AddHandler(MouseMoveEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(MouseMoveEvent, value);
		}
	}

	public event MouseEventHandler MouseUp
	{
		add
		{
			base.Events.AddHandler(MouseUpEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(MouseUpEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	public event MouseEventHandler MouseWheel
	{
		add
		{
			base.Events.AddHandler(MouseWheelEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(MouseWheelEvent, value);
		}
	}

	public event EventHandler Move
	{
		add
		{
			base.Events.AddHandler(MoveEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(MoveEvent, value);
		}
	}

	public event EventHandler PaddingChanged
	{
		add
		{
			base.Events.AddHandler(PaddingChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(PaddingChangedEvent, value);
		}
	}

	public event PaintEventHandler Paint
	{
		add
		{
			base.Events.AddHandler(PaintEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(PaintEvent, value);
		}
	}

	public event EventHandler ParentChanged
	{
		add
		{
			base.Events.AddHandler(ParentChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ParentChangedEvent, value);
		}
	}

	public event PreviewKeyDownEventHandler PreviewKeyDown
	{
		add
		{
			base.Events.AddHandler(PreviewKeyDownEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(PreviewKeyDownEvent, value);
		}
	}

	public event QueryAccessibilityHelpEventHandler QueryAccessibilityHelp
	{
		add
		{
			base.Events.AddHandler(QueryAccessibilityHelpEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(QueryAccessibilityHelpEvent, value);
		}
	}

	public event QueryContinueDragEventHandler QueryContinueDrag
	{
		add
		{
			base.Events.AddHandler(QueryContinueDragEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(QueryContinueDragEvent, value);
		}
	}

	public event EventHandler RegionChanged
	{
		add
		{
			base.Events.AddHandler(RegionChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RegionChangedEvent, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public event EventHandler Resize
	{
		add
		{
			base.Events.AddHandler(ResizeEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ResizeEvent, value);
		}
	}

	public event EventHandler RightToLeftChanged
	{
		add
		{
			base.Events.AddHandler(RightToLeftChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RightToLeftChangedEvent, value);
		}
	}

	public event EventHandler SizeChanged
	{
		add
		{
			base.Events.AddHandler(SizeChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(SizeChangedEvent, value);
		}
	}

	public event EventHandler StyleChanged
	{
		add
		{
			base.Events.AddHandler(StyleChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(StyleChangedEvent, value);
		}
	}

	public event EventHandler SystemColorsChanged
	{
		add
		{
			base.Events.AddHandler(SystemColorsChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(SystemColorsChangedEvent, value);
		}
	}

	public event EventHandler TabIndexChanged
	{
		add
		{
			base.Events.AddHandler(TabIndexChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(TabIndexChangedEvent, value);
		}
	}

	public event EventHandler TabStopChanged
	{
		add
		{
			base.Events.AddHandler(TabStopChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(TabStopChangedEvent, value);
		}
	}

	public event EventHandler TextChanged
	{
		add
		{
			base.Events.AddHandler(TextChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(TextChangedEvent, value);
		}
	}

	public event EventHandler Validated
	{
		add
		{
			base.Events.AddHandler(ValidatedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ValidatedEvent, value);
		}
	}

	public event CancelEventHandler Validating
	{
		add
		{
			base.Events.AddHandler(ValidatingEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ValidatingEvent, value);
		}
	}

	public event EventHandler VisibleChanged
	{
		add
		{
			base.Events.AddHandler(VisibleChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(VisibleChangedEvent, value);
		}
	}

	public event EventHandler DpiChangedAfterParent
	{
		add
		{
			Unity.ThrowStub.ThrowNotSupportedException();
		}
		remove
		{
			Unity.ThrowStub.ThrowNotSupportedException();
		}
	}

	public event EventHandler DpiChangedBeforeParent
	{
		add
		{
			Unity.ThrowStub.ThrowNotSupportedException();
		}
		remove
		{
			Unity.ThrowStub.ThrowNotSupportedException();
		}
	}

	public Control()
	{
		if (WindowsFormsSynchronizationContext.AutoInstall && !(SynchronizationContext.Current is WindowsFormsSynchronizationContext))
		{
			SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
		}
		anchor_style = AnchorStyles.Top | AnchorStyles.Left;
		is_created = false;
		is_visible = true;
		is_captured = false;
		is_disposed = false;
		is_enabled = true;
		is_entered = false;
		layout_pending = false;
		is_toplevel = false;
		causes_validation = true;
		has_focus = false;
		layout_suspended = 0;
		mouse_clicks = 1;
		tab_index = -1;
		cursor = null;
		right_to_left = RightToLeft.Inherit;
		border_style = BorderStyle.None;
		background_color = Color.Empty;
		dist_right = 0;
		dist_bottom = 0;
		tab_stop = true;
		ime_mode = ImeMode.Inherit;
		use_compatible_text_rendering = true;
		show_keyboard_cues = false;
		show_focus_cues = SystemInformation.MenuAccessKeysUnderlined;
		use_wait_cursor = false;
		backgroundimage_layout = ImageLayout.Tile;
		use_compatible_text_rendering = Application.use_compatible_text_rendering;
		padding = DefaultPadding;
		maximum_size = default;
		minimum_size = default;
		margin = DefaultMargin;
		auto_size_mode = AutoSizeMode.GrowOnly;
		control_style = ControlStyles.UserPaint | ControlStyles.StandardClick | ControlStyles.Selectable | ControlStyles.StandardDoubleClick | ControlStyles.AllPaintingInWmPaint;
		control_style |= ControlStyles.UseTextForAccessibility;
		parent = null;
		background_image = null;
		text = string.Empty;
		name = string.Empty;
		window_target = new ControlWindowTarget(this);
		window = new ControlNativeWindow(this);
		child_controls = CreateControlsInstance();
		bounds.Size = DefaultSize;
		client_size = ClientSizeFromSize(bounds.Size);
		client_rect = new Rectangle(Point.Empty, client_size);
		explicit_bounds = bounds;
		explicit_bounds_valid = false;
		cached_preferred_size = Size.Empty;
	}

	public Control(Control parent, string text)
		: this()
	{
		Text = text;
		Parent = parent;
	}

	public Control(Control parent, string text, int left, int top, int width, int height)
		: this()
	{
		Parent = parent;
		SetBounds(left, top, width, height, BoundsSpecified.All);
		Text = text;
	}

	public Control(string text)
		: this()
	{
		Text = text;
	}

	public Control(string text, int left, int top, int width, int height)
		: this()
	{
		SetBounds(left, top, width, height, BoundsSpecified.All);
		Text = text;
	}

	protected override void Dispose(bool disposing)
	{
		if (!is_disposed & disposing)
		{
			is_disposing = true;
			Capture = false;
			SuspendLayout();
			DisposeBackBuffer();
			if (InvokeRequired)
			{
				if (Application.MessageLoop && IsHandleCreated)
				{
					BeginInvokeInternal(new MethodInvoker(DestroyHandle), null);
				}
			}
			else
			{
				DestroyHandle();
			}
			if (parent != null)
			{
				parent.Controls.Remove(this);
			}
			child_controls.DisposeChildrenAndSilentClearContainer();
			ResumeLayout(performLayout: false);
			is_disposing = false;
		}
		is_disposed = true;
		base.Dispose(disposing);
	}

	void IDropTarget.OnDragDrop(DragEventArgs drgEvent)
	{
		OnDragDrop(drgEvent);
	}

	void IDropTarget.OnDragEnter(DragEventArgs drgEvent)
	{
		OnDragEnter(drgEvent);
	}

	void IDropTarget.OnDragLeave(EventArgs e)
	{
		OnDragLeave(e);
	}

	void IDropTarget.OnDragOver(DragEventArgs drgEvent)
	{
		OnDragOver(drgEvent);
	}

	internal IAsyncResult BeginInvokeInternal(Delegate method, object[] args)
	{
		return BeginInvokeInternal(method, args, FindControlToInvokeOn());
	}

	internal IAsyncResult BeginInvokeInternal(Delegate method, object[] args, Control control)
	{
		AsyncMethodResult result = new AsyncMethodResult();
		AsyncMethodData asyncMethodData = new AsyncMethodData();
		asyncMethodData.Handle = control.GetInvokableHandle();
		asyncMethodData.Method = method;
		asyncMethodData.Args = args;
		asyncMethodData.Result = result;
		if (!ExecutionContext.IsFlowSuppressed())
		{
			asyncMethodData.Context = ExecutionContext.Capture();
		}
		XplatUI.SendAsyncMethod(asyncMethodData);
		return result;
	}

	private IntPtr GetInvokableHandle()
	{
		if (!IsHandleCreated)
		{
			CreateHandle();
		}
		return window.Handle;
	}

	internal void PointToClient(ref int x, ref int y)
	{
		XplatUI.ScreenToClient(Handle, ref x, ref y);
	}

	internal void PointToScreen(ref int x, ref int y)
	{
		XplatUI.ClientToScreen(Handle, ref x, ref y);
	}

	internal virtual int OverrideHeight(int height)
	{
		return height;
	}

	private void ProcessActiveTracker(ref Message m)
	{
		bool flag = m.Msg == 514 || m.Msg == 517;
		MouseButtons mouseButtons = FromParamToMouseButtons(m.WParam.ToInt32());
		if (flag)
		{
			switch ((Msg)m.Msg)
			{
			case Msg.WM_LBUTTONUP:
				mouseButtons |= MouseButtons.Left;
				break;
			case Msg.WM_RBUTTONUP:
				mouseButtons |= MouseButtons.Right;
				break;
			}
		}
		MouseEventArgs args = new MouseEventArgs(mouseButtons, mouse_clicks, MousePosition.X, MousePosition.Y, 0);
		if (flag)
		{
			active_tracker.OnMouseUp(args);
			mouse_clicks = 1;
		}
		else if (!active_tracker.OnMouseDown(args))
		{
			Control realChildAtPoint = GetRealChildAtPoint(Cursor.Position);
			if (realChildAtPoint != null && realChildAtPoint.Visible && realChildAtPoint.Enabled)
			{
				Point point = realChildAtPoint.PointToClient(Cursor.Position);
				XplatUI.SendMessage(realChildAtPoint.Handle, (Msg)m.Msg, m.WParam, MakeParam(point.X, point.Y));
			}
		}
	}

	private Control FindControlToInvokeOn()
	{
		Control control = this;
		while (!control.IsHandleCreated)
		{
			control = control.parent;
			if (control == null)
			{
				break;
			}
		}
		if (control == null || !control.IsHandleCreated)
		{
			throw new InvalidOperationException("Cannot call Invoke or BeginInvoke on a control until the window handle is created");
		}
		return control;
	}

	private void InvalidateBackBuffer()
	{
		if (backbuffer != null)
		{
			backbuffer.Invalidate();
		}
	}

	private DoubleBuffer GetBackBuffer()
	{
		if (backbuffer == null)
		{
			backbuffer = new DoubleBuffer(this);
		}
		return backbuffer;
	}

	private void DisposeBackBuffer()
	{
		if (backbuffer != null)
		{
			backbuffer.Dispose();
			backbuffer = null;
		}
	}

	internal static void SetChildColor(Control parent)
	{
		for (int i = 0; i < parent.child_controls.Count; i++)
		{
			Control control = parent.child_controls[i];
			if (control.child_controls.Count > 0)
			{
				SetChildColor(control);
			}
		}
	}

	internal bool Select(Control control)
	{
		if (control == null)
		{
			return false;
		}
		IContainerControl containerControl = GetContainerControl();
		if (containerControl != null && (Control)containerControl != control)
		{
			containerControl.ActiveControl = control;
			if (containerControl.ActiveControl == control && !control.has_focus && control.IsHandleCreated)
			{
				XplatUI.SetFocus(control.window.Handle);
			}
		}
		else if (control.IsHandleCreated)
		{
			XplatUI.SetFocus(control.window.Handle);
		}
		return true;
	}

	internal virtual void DoDefaultAction()
	{
	}

	internal static IntPtr MakeParam(int low, int high)
	{
		return new IntPtr((high << 16) | (low & 0xFFFF));
	}

	internal static int LowOrder(int param)
	{
		return (short)(param & 0xFFFF);
	}

	internal static int HighOrder(long param)
	{
		return (short)(param >> 16);
	}

	internal virtual void PaintControlBackground(PaintEventArgs pevent)
	{
		bool flag = (CreateParams.Style & 0x800) != 0;
		if (((BackColor.A != byte.MaxValue && GetStyle(ControlStyles.SupportsTransparentBackColor)) | flag) && parent != null)
		{
			PaintEventArgs e = new PaintEventArgs(pevent.Graphics, new Rectangle(pevent.ClipRectangle.X + Left, pevent.ClipRectangle.Y + Top, pevent.ClipRectangle.Width, pevent.ClipRectangle.Height));
			GraphicsState gstate = e.Graphics.Save();
			e.Graphics.TranslateTransform(-Left, -Top);
			parent.OnPaintBackground(e);
			e.Graphics.Restore(gstate);
			gstate = e.Graphics.Save();
			e.Graphics.TranslateTransform(-Left, -Top);
			parent.OnPaint(e);
			e.Graphics.Restore(gstate);
			e.SetGraphics(null);
		}
		if (clip_region != null && XplatUI.UserClipWontExposeParent && parent != null)
		{
			Hwnd hwnd = Hwnd.ObjectFromHandle(Handle);
			if (hwnd != null)
			{
				PaintEventArgs e2 = new PaintEventArgs(pevent.Graphics, new Rectangle(pevent.ClipRectangle.X + Left, pevent.ClipRectangle.Y + Top, pevent.ClipRectangle.Width, pevent.ClipRectangle.Height));
				Region region = new Region();
				region.MakeEmpty();
				region.Union(ClientRectangle);
				Rectangle[] clipRectangles = hwnd.ClipRectangles;
				foreach (Rectangle rect in clipRectangles)
				{
					region.Union(rect);
				}
				GraphicsState gstate2 = e2.Graphics.Save();
				e2.Graphics.Clip = region;
				e2.Graphics.TranslateTransform(-Left, -Top);
				parent.OnPaintBackground(e2);
				e2.Graphics.Restore(gstate2);
				gstate2 = e2.Graphics.Save();
				e2.Graphics.Clip = region;
				e2.Graphics.TranslateTransform(-Left, -Top);
				parent.OnPaint(e2);
				e2.Graphics.Restore(gstate2);
				e2.SetGraphics(null);
				region.Intersect(clip_region);
				pevent.Graphics.Clip = region;
			}
		}
		if (background_image == null)
		{
			if (!flag)
			{
				Rectangle clipRectangle = pevent.ClipRectangle;
				pevent.Graphics.FillRectangle(BackColorBrush, clipRectangle);
			}
		}
		else
		{
			DrawBackgroundImage(pevent.Graphics);
		}
	}

	private void DrawBackgroundImage(Graphics g)
	{
		Rectangle rect = default;
		g.FillRectangle(BackColorBrush, ClientRectangle);
		switch (backgroundimage_layout)
		{
		default:
			return;
		case ImageLayout.Tile:
		{
			using TextureBrush brush = new TextureBrush(background_image, WrapMode.Tile);
			g.FillRectangle(brush, ClientRectangle);
			return;
		}
		case ImageLayout.Center:
			rect.Location = new Point(ClientSize.Width / 2 - background_image.Width / 2, ClientSize.Height / 2 - background_image.Height / 2);
			rect.Size = background_image.Size;
			break;
		case ImageLayout.None:
			rect.Location = Point.Empty;
			rect.Size = background_image.Size;
			break;
		case ImageLayout.Stretch:
			rect = ClientRectangle;
			break;
		case ImageLayout.Zoom:
			rect = ClientRectangle;
			if ((float)background_image.Width / (float)background_image.Height < (float)rect.Width / (float)rect.Height)
			{
				rect.Width = (int)((float)background_image.Width * ((float)rect.Height / (float)background_image.Height));
				rect.X = (ClientRectangle.Width - rect.Width) / 2;
			}
			else
			{
				rect.Height = (int)((float)background_image.Height * ((float)rect.Width / (float)background_image.Width));
				rect.Y = (ClientRectangle.Height - rect.Height) / 2;
			}
			break;
		}
		g.DrawImage(background_image, rect);
	}

	internal virtual void DndEnter(DragEventArgs e)
	{
		try
		{
			OnDragEnter(e);
		}
		catch
		{
		}
	}

	internal virtual void DndOver(DragEventArgs e)
	{
		try
		{
			OnDragOver(e);
		}
		catch
		{
		}
	}

	internal virtual void DndDrop(DragEventArgs e)
	{
		try
		{
			OnDragDrop(e);
		}
		catch (Exception value)
		{
			Console.Error.WriteLine("MWF: Exception while dropping:");
			Console.Error.WriteLine(value);
		}
	}

	internal virtual void DndLeave(EventArgs e)
	{
		try
		{
			OnDragLeave(e);
		}
		catch
		{
		}
	}

	internal virtual void DndFeedback(GiveFeedbackEventArgs e)
	{
		try
		{
			OnGiveFeedback(e);
		}
		catch
		{
		}
	}

	internal virtual void DndContinueDrag(QueryContinueDragEventArgs e)
	{
		try
		{
			OnQueryContinueDrag(e);
		}
		catch
		{
		}
	}

	internal static MouseButtons FromParamToMouseButtons(long param)
	{
		MouseButtons mouseButtons = MouseButtons.None;
		if ((param & 1) != 0L)
		{
			mouseButtons |= MouseButtons.Left;
		}
		if ((param & 0x10) != 0L)
		{
			mouseButtons |= MouseButtons.Middle;
		}
		if ((param & 2) != 0L)
		{
			mouseButtons |= MouseButtons.Right;
		}
		return mouseButtons;
	}

	internal virtual void FireEnter()
	{
		OnEnter(EventArgs.Empty);
	}

	internal virtual void FireLeave()
	{
		OnLeave(EventArgs.Empty);
	}

	internal virtual void FireValidating(CancelEventArgs ce)
	{
		OnValidating(ce);
	}

	internal virtual void FireValidated()
	{
		OnValidated(EventArgs.Empty);
	}

	internal virtual bool ProcessControlMnemonic(char charCode)
	{
		return ProcessMnemonic(charCode);
	}

	private static Control FindFlatForward(Control container, Control start)
	{
		Control control = null;
		int count = container.child_controls.Count;
		bool flag = false;
		int num = start?.tab_index ?? (-1);
		for (int i = 0; i < count; i++)
		{
			if (start == container.child_controls[i])
			{
				flag = true;
			}
			else if ((control == null || control.tab_index > container.child_controls[i].tab_index) && (container.child_controls[i].tab_index > num || (flag && container.child_controls[i].tab_index == num)))
			{
				control = container.child_controls[i];
			}
		}
		return control;
	}

	private static Control FindControlForward(Control container, Control start)
	{
		Control control = null;
		if (start == null)
		{
			return FindFlatForward(container, start);
		}
		if (start.child_controls != null && start.child_controls.Count > 0 && (start == container || !(start is IContainerControl) || !start.GetStyle(ControlStyles.ContainerControl)))
		{
			return FindControlForward(start, null);
		}
		while (start != container)
		{
			control = FindFlatForward(start.parent, start);
			if (control != null)
			{
				return control;
			}
			start = start.parent;
		}
		return null;
	}

	private static Control FindFlatBackward(Control container, Control start)
	{
		Control control = null;
		int count = container.child_controls.Count;
		bool flag = false;
		int num = start?.tab_index ?? int.MaxValue;
		for (int num2 = count - 1; num2 >= 0; num2--)
		{
			if (start == container.child_controls[num2])
			{
				flag = true;
			}
			else if ((control == null || control.tab_index < container.child_controls[num2].tab_index) && (container.child_controls[num2].tab_index < num || (flag && container.child_controls[num2].tab_index == num)))
			{
				control = container.child_controls[num2];
			}
		}
		return control;
	}

	private static Control FindControlBackward(Control container, Control start)
	{
		Control control = null;
		if (start == null)
		{
			control = FindFlatBackward(container, start);
		}
		else if (start != container && start.parent != null)
		{
			control = FindFlatBackward(start.parent, start);
			if (control == null)
			{
				if (start.parent != container)
				{
					return start.parent;
				}
				return null;
			}
		}
		if (control == null || start.parent == null)
		{
			control = start;
		}
		while (control != null && (control == container || ((!(control is IContainerControl) || !control.GetStyle(ControlStyles.ContainerControl)) && control.child_controls != null && control.child_controls.Count > 0)))
		{
			control = FindFlatBackward(control, null);
		}
		return control;
	}

	internal virtual void HandleClick(int clicks, MouseEventArgs me)
	{
		bool style = GetStyle(ControlStyles.StandardClick);
		bool style2 = GetStyle(ControlStyles.StandardDoubleClick);
		if ((clicks > 1) & style & style2)
		{
			OnDoubleClick(me);
			OnMouseDoubleClick(me);
		}
		else if (((clicks == 1) & style) && !ValidationFailed)
		{
			OnClick(me);
			OnMouseClick(me);
		}
	}

	internal void CaptureWithConfine(Control ConfineWindow)
	{
		if (IsHandleCreated && !is_captured)
		{
			is_captured = true;
			XplatUI.GrabWindow(window.Handle, ConfineWindow.Handle);
		}
	}

	private void CheckDataBindings()
	{
		if (data_bindings == null)
		{
			return;
		}
		foreach (Binding data_binding in data_bindings)
		{
			data_binding.Check();
		}
	}

	internal static bool IsChild(IntPtr hWndParent, IntPtr hWnd)
	{
		IntPtr intPtr = XplatUI.GetParent(hWnd, with_owner: true);
		while (intPtr != IntPtr.Zero)
		{
			if (intPtr == hWndParent)
			{
				return true;
			}
			intPtr = XplatUI.GetParent(intPtr, with_owner: true);
		}
		return false;
	}

	private void ChangeParent(Control new_parent)
	{
		bool enabled = Enabled;
		bool visible = Visible;
		Font font = Font;
		Color foreColor = ForeColor;
		Color backColor = BackColor;
		RightToLeft rightToLeft = RightToLeft;
		parent = new_parent;
		if (this is Form form)
		{
			form.ChangingParent(new_parent);
		}
		else if (IsHandleCreated)
		{
			IntPtr hParent = IntPtr.Zero;
			if (new_parent != null && new_parent.IsHandleCreated)
			{
				hParent = new_parent.Handle;
			}
			XplatUI.SetParent(Handle, hParent);
		}
		OnParentChanged(EventArgs.Empty);
		if (!Disposing)
		{
			if (enabled != Enabled)
			{
				OnEnabledChanged(EventArgs.Empty);
			}
			bool flag = Visible && (GetTopLevel() || parent != null);
			if (visible != flag)
			{
				OnVisibleChanged(EventArgs.Empty);
			}
			if (font != Font)
			{
				OnFontChanged(EventArgs.Empty);
			}
			if (foreColor != ForeColor)
			{
				OnForeColorChanged(EventArgs.Empty);
			}
			if (backColor != BackColor)
			{
				OnBackColorChanged(EventArgs.Empty);
			}
			if (rightToLeft != RightToLeft)
			{
				OnRightToLeftChanged(EventArgs.Empty);
			}
			if (new_parent != null && new_parent.Created && is_visible && !Created)
			{
				CreateControl();
			}
			if (binding_context == null && Created)
			{
				OnBindingContextChanged(EventArgs.Empty);
			}
			new_parent?.LayoutEngine.InitLayout(this, BoundsSpecified.All);
		}
	}

	internal Size InternalSizeFromClientSize(Size clientSize)
	{
		Rectangle ClientRect = new Rectangle(0, 0, clientSize.Width, clientSize.Height);
		CreateParams createParams = CreateParams;
		if (XplatUI.CalculateWindowRect(ref ClientRect, createParams, null, out var WindowRect))
		{
			return new Size(WindowRect.Width, WindowRect.Height);
		}
		return Size.Empty;
	}

	internal Size ClientSizeFromSize(Size size)
	{
		Size size2 = InternalSizeFromClientSize(size);
		if (size2 == Size.Empty)
		{
			return Size.Empty;
		}
		return new Size(size.Width - (size2.Width - size.Width), size.Height - (size2.Height - size.Height));
	}

	internal CreateParams GetCreateParams()
	{
		return CreateParams;
	}

	internal virtual Size GetPreferredSizeCore(Size proposedSize)
	{
		return explicit_bounds.Size;
	}

	private Cursor GetAvailableCursor()
	{
		if (Cursor != null && Enabled)
		{
			return Cursor;
		}
		if (Parent != null)
		{
			return Parent.GetAvailableCursor();
		}
		return Cursors.Default;
	}

	private void UpdateCursor()
	{
		if (!IsHandleCreated)
		{
			return;
		}
		if (!Enabled)
		{
			XplatUI.SetCursor(window.Handle, GetAvailableCursor().handle);
			return;
		}
		Point pt = PointToClient(Cursor.Position);
		if (bounds.Contains(pt) || Capture)
		{
			if (cursor != null || use_wait_cursor)
			{
				XplatUI.SetCursor(window.Handle, Cursor.handle);
			}
			else
			{
				XplatUI.SetCursor(window.Handle, GetAvailableCursor().handle);
			}
		}
	}

	internal void OnSizeInitializedOrChanged()
	{
		if (this is Form { WindowManager: not null } form)
		{
			ThemeEngine.Current.ManagedWindowOnSizeInitializedOrChanged(form);
		}
	}

	internal bool ShouldSerializeMaximumSize()
	{
		return MaximumSize != DefaultMaximumSize;
	}

	internal bool ShouldSerializeMinimumSize()
	{
		return MinimumSize != DefaultMinimumSize;
	}

	internal bool ShouldSerializeBackColor()
	{
		return BackColor != DefaultBackColor;
	}

	internal bool ShouldSerializeCursor()
	{
		return Cursor != Cursors.Default;
	}

	public void DrawToBitmap(Bitmap bitmap, Rectangle targetBounds)
	{
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.IntersectClip(targetBounds);
		graphics.TranslateTransform(targetBounds.X, targetBounds.Y);
		graphics.IntersectClip(new Rectangle(Point.Empty, Size));
		using (PaintEventArgs e = new PaintEventArgs(graphics, new Rectangle(Point.Empty, targetBounds.Size)))
		{
			if (!GetStyle(ControlStyles.Opaque))
			{
				OnPaintBackground(e);
			}
			OnPaintBackgroundInternal(e);
			OnPaintInternal(e);
			if (!e.Handled)
			{
				OnPaint(e);
			}
		}
		for (int i = 0; i < child_controls.Count; i++)
		{
			Rectangle clientRectangle = child_controls[i].ClientRectangle;
			Bitmap bitmap2 = new Bitmap(clientRectangle.Width, clientRectangle.Height);
			child_controls[i].DrawToBitmap(bitmap2, clientRectangle);
			graphics.DrawImage(bitmap2, new Rectangle(child_controls[i].Location, child_controls[i].Size));
		}
	}

	internal bool ShouldSerializeEnabled()
	{
		return !Enabled;
	}

	internal bool ShouldSerializeFont()
	{
		return !Font.Equals(DefaultFont);
	}

	internal bool ShouldSerializeForeColor()
	{
		return ForeColor != DefaultForeColor;
	}

	internal bool ShouldSerializeImeMode()
	{
		return ImeMode != ImeMode.NoControl;
	}

	internal bool ShouldSerializeLocation()
	{
		return Location != new Point(0, 0);
	}

	internal bool ShouldSerializeMargin()
	{
		return Margin != DefaultMargin;
	}

	internal bool ShouldSerializePadding()
	{
		return Padding != DefaultPadding;
	}

	internal bool ShouldSerializeRightToLeft()
	{
		return RightToLeft != RightToLeft.No;
	}

	internal bool ShouldSerializeSite()
	{
		return false;
	}

	internal virtual bool ShouldSerializeSize()
	{
		return Size != DefaultSize;
	}

	internal virtual void UpdateWindowText()
	{
		if (IsHandleCreated)
		{
			XplatUI.Text(Handle, text);
		}
	}

	internal bool ShouldSerializeVisible()
	{
		return !Visible;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static Control FromChildHandle(IntPtr handle)
	{
		return ControlNativeWindow.ControlFromChildHandle(handle);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static Control FromHandle(IntPtr handle)
	{
		return ControlNativeWindow.ControlFromHandle(handle);
	}

	[System.MonoTODO("Only implemented for Win32, others always return false")]
	public static bool IsKeyLocked(Keys keyVal)
	{
		if (keyVal == Keys.CapsLock || (uint)(keyVal - 144) <= 1u)
		{
			return XplatUI.IsKeyLocked((VirtualKeys)keyVal);
		}
		throw new NotSupportedException("keyVal must be CapsLock, NumLock, or ScrollLock");
	}

	public static bool IsMnemonic(char charCode, string text)
	{
		int num = text.IndexOf('&');
		if (num != -1 && num + 1 < text.Length && text[num + 1] != '&' && char.ToUpper(charCode) == char.ToUpper(text.ToCharArray(num + 1, 1)[0]))
		{
			return true;
		}
		return false;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected static bool ReflectMessage(IntPtr hWnd, ref Message m)
	{
		Control control = FromHandle(hWnd);
		if (control != null)
		{
			control.WndProc(ref m);
			return true;
		}
		return false;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public IAsyncResult BeginInvoke(Delegate method)
	{
		object[] args = null;
		if (method is EventHandler)
		{
			args = new object[2]
			{
				this,
				EventArgs.Empty
			};
		}
		return BeginInvokeInternal(method, args);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public IAsyncResult BeginInvoke(Delegate method, params object[] args)
	{
		return BeginInvokeInternal(method, args);
	}

	public void BringToFront()
	{
		if (parent != null)
		{
			parent.child_controls.SetChildIndex(this, 0);
		}
		else if (IsHandleCreated)
		{
			XplatUI.SetZOrder(Handle, IntPtr.Zero, Top: false, Bottom: false);
		}
	}

	public bool Contains(Control ctl)
	{
		while (ctl != null)
		{
			ctl = ctl.Parent;
			if (ctl == this)
			{
				return true;
			}
		}
		return false;
	}

	public void CreateControl()
	{
		if (is_created || is_disposing || !is_visible || (parent != null && !parent.Created))
		{
			return;
		}
		if (!IsHandleCreated)
		{
			CreateHandle();
		}
		if (is_created)
		{
			return;
		}
		is_created = true;
		Control[] allControls = Controls.GetAllControls();
		foreach (Control control in allControls)
		{
			if (!control.Created && !control.IsDisposed)
			{
				control.CreateControl();
			}
		}
		OnCreateControl();
	}

	public Graphics CreateGraphics()
	{
		if (!IsHandleCreated)
		{
			CreateHandle();
		}
		return Graphics.FromHwnd(window.Handle);
	}

	public DragDropEffects DoDragDrop(object data, DragDropEffects allowedEffects)
	{
		DragDropEffects dragDropEffects = DragDropEffects.None;
		if (IsHandleCreated)
		{
			dragDropEffects = XplatUI.StartDrag(Handle, data, allowedEffects);
		}
		OnDragDropEnd(dragDropEffects);
		return dragDropEffects;
	}

	internal virtual void OnDragDropEnd(DragDropEffects effects)
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public object EndInvoke(IAsyncResult asyncResult)
	{
		return ((AsyncMethodResult)asyncResult).EndInvoke();
	}

	internal Control FindRootParent()
	{
		Control control = this;
		while (control.Parent != null)
		{
			control = control.Parent;
		}
		return control;
	}

	public Form FindForm()
	{
		for (Control control = this; control != null; control = control.Parent)
		{
			if (control is Form)
			{
				return (Form)control;
			}
		}
		return null;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public bool Focus()
	{
		return FocusInternal(skip_check: false);
	}

	internal virtual bool FocusInternal(bool skip_check)
	{
		if (skip_check || (CanFocus && IsHandleCreated && !has_focus && !is_focusing))
		{
			is_focusing = true;
			Select(this);
			is_focusing = false;
		}
		return has_focus;
	}

	internal Control GetRealChildAtPoint(Point pt)
	{
		if (!IsHandleCreated)
		{
			CreateHandle();
		}
		Control[] allControls = child_controls.GetAllControls();
		foreach (Control control in allControls)
		{
			if (control.Bounds.Contains(PointToClient(pt)))
			{
				Control realChildAtPoint = control.GetRealChildAtPoint(pt);
				if (realChildAtPoint == null)
				{
					return control;
				}
				return realChildAtPoint;
			}
		}
		return null;
	}

	public Control GetChildAtPoint(Point pt)
	{
		return GetChildAtPoint(pt, GetChildAtPointSkip.None);
	}

	public Control GetChildAtPoint(Point pt, GetChildAtPointSkip skipValue)
	{
		if (!IsHandleCreated)
		{
			CreateHandle();
		}
		foreach (Control control in Controls)
		{
			if (((skipValue & GetChildAtPointSkip.Disabled) != GetChildAtPointSkip.Disabled || control.Enabled) && ((skipValue & GetChildAtPointSkip.Invisible) != GetChildAtPointSkip.Invisible || control.Visible) && ((skipValue & GetChildAtPointSkip.Transparent) != GetChildAtPointSkip.Transparent || control.BackColor.A != 0) && control.Bounds.Contains(pt))
			{
				return control;
			}
		}
		return null;
	}

	public IContainerControl GetContainerControl()
	{
		for (Control control = this; control != null; control = control.parent)
		{
			if (control is IContainerControl && (control.control_style & ControlStyles.ContainerControl) != 0)
			{
				return (IContainerControl)control;
			}
		}
		return null;
	}

	internal ContainerControl InternalGetContainerControl()
	{
		for (Control control = this; control != null; control = control.parent)
		{
			if (control is ContainerControl && (control.control_style & ControlStyles.ContainerControl) != 0)
			{
				return control as ContainerControl;
			}
		}
		return null;
	}

	public Control GetNextControl(Control ctl, bool forward)
	{
		if (!Contains(ctl))
		{
			ctl = this;
		}
		ctl = ((!forward) ? FindControlBackward(this, ctl) : FindControlForward(this, ctl));
		if (ctl != this)
		{
			return ctl;
		}
		return null;
	}

	private Size ApplySizeConstraints(Size proposedSize)
	{
		if (maximum_size.Width != 0 && proposedSize.Width > maximum_size.Width)
		{
			proposedSize.Width = maximum_size.Width;
		}
		if (maximum_size.Height != 0 && proposedSize.Height > maximum_size.Height)
		{
			proposedSize.Height = maximum_size.Height;
		}
		if (proposedSize.Width < minimum_size.Width)
		{
			proposedSize.Width = minimum_size.Width;
		}
		if (proposedSize.Height < minimum_size.Height)
		{
			proposedSize.Height = minimum_size.Height;
		}
		return proposedSize;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public virtual Size GetPreferredSize(Size proposedSize)
	{
		if (can_cache_preferred_size && proposedSize == Size.Empty && !cached_preferred_size.IsEmpty)
		{
			return cached_preferred_size;
		}
		proposedSize = ApplySizeConstraints(proposedSize);
		Size result = ApplySizeConstraints(GetPreferredSizeCore(proposedSize));
		if (can_cache_preferred_size && proposedSize == Size.Empty)
		{
			cached_preferred_size = result;
		}
		return result;
	}

	public void Hide()
	{
		Visible = false;
	}

	public void Invalidate()
	{
		Invalidate(ClientRectangle, invalidateChildren: false);
	}

	public void Invalidate(bool invalidateChildren)
	{
		Invalidate(ClientRectangle, invalidateChildren);
	}

	public void Invalidate(Rectangle rc)
	{
		Invalidate(rc, invalidateChildren: false);
	}

	public void Invalidate(Rectangle rc, bool invalidateChildren)
	{
		if (!IsHandleCreated)
		{
			return;
		}
		if (rc.IsEmpty)
		{
			rc = ClientRectangle;
		}
		if (rc.Width > 0 && rc.Height > 0)
		{
			NotifyInvalidate(rc);
			XplatUI.Invalidate(Handle, rc, clear: false);
			if (invalidateChildren)
			{
				Control[] allControls = child_controls.GetAllControls();
				for (int i = 0; i < allControls.Length; i++)
				{
					allControls[i].Invalidate();
				}
			}
			else
			{
				foreach (Control control in Controls)
				{
					if (control.BackColor.A != byte.MaxValue)
					{
						control.Invalidate();
					}
				}
			}
		}
		OnInvalidated(new InvalidateEventArgs(rc));
	}

	public void Invalidate(Region region)
	{
		Invalidate(region, invalidateChildren: false);
	}

	public void Invalidate(Region region, bool invalidateChildren)
	{
		using Graphics g = CreateGraphics();
		RectangleF rectangleF = region.GetBounds(g);
		Invalidate(new Rectangle((int)rectangleF.X, (int)rectangleF.Y, (int)rectangleF.Width, (int)rectangleF.Height), invalidateChildren);
	}

	public object Invoke(Delegate method)
	{
		object[] args = null;
		if (method is EventHandler)
		{
			args = new object[2]
			{
				this,
				EventArgs.Empty
			};
		}
		return Invoke(method, args);
	}

	public object Invoke(Delegate method, params object[] args)
	{
		Control control = FindControlToInvokeOn();
		if (!InvokeRequired)
		{
			return method.DynamicInvoke(args);
		}
		IAsyncResult asyncResult = BeginInvokeInternal(method, args, control);
		return EndInvoke(asyncResult);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public void PerformLayout()
	{
		PerformLayout(null, null);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public void PerformLayout(Control affectedControl, string affectedProperty)
	{
		cached_preferred_size = Size.Empty;
		if (affectedControl != null)
		{
			affectedControl.cached_preferred_size = Size.Empty;
		}
		PerformLayout((IComponent)affectedControl, affectedProperty);
	}

	internal void PerformLayout(IComponent affectedComponent, string affectedProperty)
	{
		LayoutEventArgs levent = new LayoutEventArgs(affectedComponent, affectedProperty);
		if (layout_suspended > 0)
		{
			if (layout_pending_event_args == null || layout_pending_after_resume)
			{
				layout_pending_event_args = levent;
			}
			layout_pending = true;
			layout_pending_after_resume = false;
			return;
		}
		layout_pending = false;
		layout_suspended++;
		try
		{
			OnLayout(levent);
		}
		finally
		{
			layout_suspended--;
			layout_dirty = false;
			if (parent != null && parent.layout_dirty)
			{
				parent.PerformLayout(this, "PreferredSize");
			}
		}
	}

	void IArrangedContainer.PerformLayout(IArrangedElement affectedElement, string affectedProperty)
	{
		PerformLayout(affectedElement, affectedProperty);
	}

	public Point PointToClient(Point p)
	{
		int x = p.X;
		int y = p.Y;
		XplatUI.ScreenToClient(Handle, ref x, ref y);
		return new Point(x, y);
	}

	public Point PointToScreen(Point p)
	{
		int x = p.X;
		int y = p.Y;
		XplatUI.ClientToScreen(Handle, ref x, ref y);
		return new Point(x, y);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public PreProcessControlState PreProcessControlMessage(ref Message msg)
	{
		return PreProcessControlMessageInternal(ref msg);
	}

	internal PreProcessControlState PreProcessControlMessageInternal(ref Message msg)
	{
		switch ((Msg)msg.Msg)
		{
		case Msg.WM_KEYDOWN:
		case Msg.WM_SYSKEYDOWN:
		{
			PreviewKeyDownEventArgs e = new PreviewKeyDownEventArgs((Keys)(msg.WParam.ToInt32() | (int)XplatUI.State.ModifierKeys));
			OnPreviewKeyDown(e);
			if (e.IsInputKey)
			{
				return PreProcessControlState.MessageNeeded;
			}
			if (PreProcessMessage(ref msg))
			{
				return PreProcessControlState.MessageProcessed;
			}
			if (IsInputKey((Keys)(msg.WParam.ToInt32() | (int)XplatUI.State.ModifierKeys)))
			{
				return PreProcessControlState.MessageNeeded;
			}
			break;
		}
		case Msg.WM_CHAR:
		case Msg.WM_SYSCHAR:
			if (PreProcessMessage(ref msg))
			{
				return PreProcessControlState.MessageProcessed;
			}
			if (IsInputChar((char)(int)msg.WParam))
			{
				return PreProcessControlState.MessageNeeded;
			}
			break;
		}
		return PreProcessControlState.MessageNotNeeded;
	}

	public virtual bool PreProcessMessage(ref Message msg)
	{
		return InternalPreProcessMessage(ref msg);
	}

	internal virtual bool InternalPreProcessMessage(ref Message msg)
	{
		if (msg.Msg == 256 || msg.Msg == 260)
		{
			Keys keyData = (Keys)(msg.WParam.ToInt32() | (int)XplatUI.State.ModifierKeys);
			if (!ProcessCmdKey(ref msg, keyData))
			{
				if (IsInputKey(keyData))
				{
					return false;
				}
				return ProcessDialogKey(keyData);
			}
			return true;
		}
		if (msg.Msg == 258)
		{
			if (IsInputChar((char)(int)msg.WParam))
			{
				return false;
			}
			return ProcessDialogChar((char)(int)msg.WParam);
		}
		if (msg.Msg == 262)
		{
			if (ProcessDialogChar((char)(int)msg.WParam))
			{
				return true;
			}
			return ToolStripManager.ProcessMenuKey(ref msg);
		}
		return false;
	}

	public Rectangle RectangleToClient(Rectangle r)
	{
		return new Rectangle(PointToClient(r.Location), r.Size);
	}

	public Rectangle RectangleToScreen(Rectangle r)
	{
		return new Rectangle(PointToScreen(r.Location), r.Size);
	}

	public virtual void Refresh()
	{
		if (IsHandleCreated && Visible)
		{
			Invalidate(invalidateChildren: true);
			Update();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual void ResetBackColor()
	{
		BackColor = Color.Empty;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void ResetBindings()
	{
		if (data_bindings != null)
		{
			data_bindings.Clear();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual void ResetCursor()
	{
		Cursor = null;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual void ResetFont()
	{
		font = null;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual void ResetForeColor()
	{
		foreground_color = Color.Empty;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void ResetImeMode()
	{
		ime_mode = DefaultImeMode;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual void ResetRightToLeft()
	{
		right_to_left = RightToLeft.Inherit;
	}

	public virtual void ResetText()
	{
		Text = string.Empty;
	}

	public void ResumeLayout()
	{
		ResumeLayout(performLayout: true);
	}

	public void ResumeLayout(bool performLayout)
	{
		if (layout_suspended > 0)
		{
			layout_suspended--;
		}
		layout_pending_after_resume = true;
		if (layout_suspended != 0)
		{
			return;
		}
		if (this is ContainerControl)
		{
			(this as ContainerControl).PerformDelayedAutoScale();
		}
		if (performLayout)
		{
			if (layout_pending)
			{
				LayoutEventArgs e = layout_pending_event_args;
				layout_pending_event_args = null;
				if (e != null)
				{
					PerformLayout(e.AffectedControl, e.AffectedProperty);
				}
				else
				{
					PerformLayout();
				}
			}
			return;
		}
		layout_pending_event_args = null;
		foreach (Control control in Controls)
		{
			LayoutEngine.InitLayout(control, BoundsSpecified.All);
		}
	}

	[Obsolete]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void Scale(float ratio)
	{
		ScaleCore(ratio, ratio);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete]
	public void Scale(float dx, float dy)
	{
		ScaleCore(dx, dy);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public void Scale(SizeF factor)
	{
		BoundsSpecified boundsSpecified = BoundsSpecified.All;
		SuspendLayout();
		if (this is ContainerControl)
		{
			if ((this as ContainerControl).IsAutoScaling)
			{
				boundsSpecified = BoundsSpecified.Size;
			}
			else if (IsContainerAutoScaling(Parent))
			{
				boundsSpecified = BoundsSpecified.Location;
			}
		}
		ScaleControl(factor, boundsSpecified);
		if (boundsSpecified != BoundsSpecified.Location && ScaleChildren)
		{
			Control[] allControls = Controls.GetAllControls();
			foreach (Control control in allControls)
			{
				control.Scale(factor);
				if (control is ContainerControl)
				{
					ContainerControl containerControl = control as ContainerControl;
					if (containerControl.AutoScaleMode == AutoScaleMode.Inherit && IsContainerAutoScaling(this))
					{
						containerControl.PerformAutoScale(called_by_scale: true);
					}
				}
			}
		}
		ResumeLayout();
	}

	internal ContainerControl FindContainer(Control c)
	{
		while (c != null && !(c is ContainerControl))
		{
			c = c.Parent;
		}
		return c as ContainerControl;
	}

	private bool IsContainerAutoScaling(Control c)
	{
		return FindContainer(c)?.IsAutoScaling ?? false;
	}

	public void Select()
	{
		Select(directed: false, forward: false);
	}

	public bool SelectNextControl(Control ctl, bool forward, bool tabStopOnly, bool nested, bool wrap)
	{
		if (!Contains(ctl) || (!nested && ctl.parent != this))
		{
			ctl = null;
		}
		Control control = ctl;
		do
		{
			control = GetNextControl(control, forward);
			if (control == null)
			{
				if (!wrap)
				{
					break;
				}
				wrap = false;
			}
			else if (control.CanSelect && ((control.parent == this) | nested) && (control.tab_stop || !tabStopOnly))
			{
				control.Select(directed: true, forward: true);
				return true;
			}
		}
		while (control != ctl);
		return false;
	}

	public void SendToBack()
	{
		if (parent != null)
		{
			parent.child_controls.SetChildIndex(this, parent.child_controls.Count);
		}
	}

	public void SetBounds(int x, int y, int width, int height)
	{
		SetBounds(x, y, width, height, BoundsSpecified.All);
	}

	public void SetBounds(int x, int y, int width, int height, BoundsSpecified specified)
	{
		if ((specified & BoundsSpecified.X) == 0)
		{
			x = Left;
		}
		if ((specified & BoundsSpecified.Y) == 0)
		{
			y = Top;
		}
		if ((specified & BoundsSpecified.Width) == 0)
		{
			width = Width;
		}
		if ((specified & BoundsSpecified.Height) == 0)
		{
			height = Height;
		}
		bool flag = bounds.X != x || bounds.Y != y || bounds.Width != width || bounds.Height != height;
		SetBoundsCore(x, y, width, height, specified);
		if ((parent != null) & flag)
		{
			parent.PerformLayout(this, "Bounds");
		}
	}

	void IArrangedElement.SetBounds(int x, int y, int width, int height, BoundsSpecified specified)
	{
		SetBoundsCore(x, y, width, height, specified);
	}

	public void Show()
	{
		Visible = true;
	}

	public void SuspendLayout()
	{
		layout_suspended++;
	}

	public void Update()
	{
		if (IsHandleCreated)
		{
			XplatUI.UpdateWindow(window.Handle);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected void AccessibilityNotifyClients(AccessibleEvents accEvent, int childID)
	{
		if (accessibility_object != null && accessibility_object is ControlAccessibleObject)
		{
			((ControlAccessibleObject)accessibility_object).NotifyClients(accEvent, childID);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected void AccessibilityNotifyClients(AccessibleEvents accEvent, int objectID, int childID)
	{
		if (accessibility_object != null && accessibility_object is ControlAccessibleObject)
		{
			((ControlAccessibleObject)accessibility_object).NotifyClients(accEvent, objectID, childID);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual AccessibleObject CreateAccessibilityInstance()
	{
		CreateControl();
		return new ControlAccessibleObject(this);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual ControlCollection CreateControlsInstance()
	{
		return new ControlCollection(this);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void CreateHandle()
	{
		if (IsDisposed)
		{
			throw new ObjectDisposedException(GetType().FullName);
		}
		if (IsHandleCreated && !is_recreating)
		{
			return;
		}
		CreateParams createParams = CreateParams;
		window.CreateHandle(createParams);
		if (window.Handle != IntPtr.Zero)
		{
			creator_thread = Thread.CurrentThread;
			XplatUI.EnableWindow(window.Handle, is_enabled);
			if (clip_region != null)
			{
				XplatUI.SetClipRegion(window.Handle, clip_region);
			}
			if (parent != null && parent.IsHandleCreated)
			{
				XplatUI.SetParent(window.Handle, parent.Handle);
			}
			UpdateStyles();
			XplatUI.SetAllowDrop(window.Handle, allow_drop);
			if ((CreateParams.Style & 0x40000000) != 0)
			{
				XplatUI.SetBorderStyle(window.Handle, (FormBorderStyle)border_style);
			}
			Rectangle rectangle = explicit_bounds;
			UpdateBounds();
			explicit_bounds = rectangle;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void DefWndProc(ref Message m)
	{
		window.DefWndProc(ref m);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void DestroyHandle()
	{
		if (IsHandleCreated && window != null)
		{
			window.DestroyHandle();
		}
	}

	protected virtual AccessibleObject GetAccessibilityObjectById(int objectId)
	{
		return null;
	}

	protected internal AutoSizeMode GetAutoSizeMode()
	{
		return auto_size_mode;
	}

	AutoSizeMode IArrangedElement.GetAutoSizeMode()
	{
		return GetAutoSizeMode();
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual Rectangle GetScaledBounds(Rectangle bounds, SizeF factor, BoundsSpecified specified)
	{
		if (!is_toplevel)
		{
			if ((specified & BoundsSpecified.X) == BoundsSpecified.X)
			{
				bounds.X = (int)Math.Round((float)bounds.X * factor.Width);
			}
			if ((specified & BoundsSpecified.Y) == BoundsSpecified.Y)
			{
				bounds.Y = (int)Math.Round((float)bounds.Y * factor.Height);
			}
		}
		if ((specified & BoundsSpecified.Width) == BoundsSpecified.Width && !GetStyle(ControlStyles.FixedWidth))
		{
			int num = ((this is ComboBox) ? (ThemeEngine.Current.Border3DSize.Width * 2) : (this.bounds.Width - client_size.Width));
			bounds.Width = (int)Math.Round((float)(bounds.Width - num) * factor.Width + (float)num);
		}
		if ((specified & BoundsSpecified.Height) == BoundsSpecified.Height && !GetStyle(ControlStyles.FixedHeight))
		{
			int num2 = ((this is ComboBox) ? (ThemeEngine.Current.Border3DSize.Height * 2) : (this.bounds.Height - client_size.Height));
			bounds.Height = (int)Math.Round((float)(bounds.Height - num2) * factor.Height + (float)num2);
		}
		return bounds;
	}

	private Rectangle GetScaledBoundsOld(Rectangle bounds, SizeF factor, BoundsSpecified specified)
	{
		RectangleF rectangleF = new RectangleF(bounds.Location, bounds.Size);
		if (!is_toplevel)
		{
			if ((specified & BoundsSpecified.X) == BoundsSpecified.X)
			{
				rectangleF.X *= factor.Width;
			}
			if ((specified & BoundsSpecified.Y) == BoundsSpecified.Y)
			{
				rectangleF.Y *= factor.Height;
			}
		}
		if ((specified & BoundsSpecified.Width) == BoundsSpecified.Width && !GetStyle(ControlStyles.FixedWidth))
		{
			int num = ((this is Form) ? (this.bounds.Width - client_size.Width) : 0);
			rectangleF.Width = (rectangleF.Width - (float)num) * factor.Width + (float)num;
		}
		if ((specified & BoundsSpecified.Height) == BoundsSpecified.Height && !GetStyle(ControlStyles.FixedHeight))
		{
			int num2 = ((this is Form) ? (this.bounds.Height - client_size.Height) : 0);
			rectangleF.Height = (rectangleF.Height - (float)num2) * factor.Height + (float)num2;
		}
		bounds.X = (int)Math.Round(rectangleF.X);
		bounds.Y = (int)Math.Round(rectangleF.Y);
		bounds.Width = (int)Math.Round(rectangleF.Right) - bounds.X;
		bounds.Height = (int)Math.Round(rectangleF.Bottom) - bounds.Y;
		return bounds;
	}

	protected internal bool GetStyle(ControlStyles flag)
	{
		return (control_style & flag) != 0;
	}

	protected bool GetTopLevel()
	{
		return is_toplevel;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void InitLayout()
	{
		LayoutEngine.InitLayout(this, BoundsSpecified.All);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected void InvokeGotFocus(Control toInvoke, EventArgs e)
	{
		toInvoke.OnGotFocus(e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected void InvokeLostFocus(Control toInvoke, EventArgs e)
	{
		toInvoke.OnLostFocus(e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected void InvokeOnClick(Control toInvoke, EventArgs e)
	{
		toInvoke.OnClick(e);
	}

	protected void InvokePaint(Control c, PaintEventArgs e)
	{
		c.OnPaint(e);
	}

	protected void InvokePaintBackground(Control c, PaintEventArgs e)
	{
		c.OnPaintBackground(e);
	}

	protected virtual bool IsInputChar(char charCode)
	{
		if (!IsHandleCreated)
		{
			CreateHandle();
		}
		return IsInputCharInternal(charCode);
	}

	internal virtual bool IsInputCharInternal(char charCode)
	{
		return false;
	}

	protected virtual bool IsInputKey(Keys keyData)
	{
		return false;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void NotifyInvalidate(Rectangle invalidatedArea)
	{
	}

	protected virtual bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		if (context_menu != null && context_menu.ProcessCmdKey(ref msg, keyData))
		{
			return true;
		}
		if (parent != null)
		{
			return parent.ProcessCmdKey(ref msg, keyData);
		}
		return false;
	}

	protected virtual bool ProcessDialogChar(char charCode)
	{
		if (parent != null)
		{
			return parent.ProcessDialogChar(charCode);
		}
		return false;
	}

	protected virtual bool ProcessDialogKey(Keys keyData)
	{
		if (parent != null)
		{
			return parent.ProcessDialogKey(keyData);
		}
		return false;
	}

	protected virtual bool ProcessKeyEventArgs(ref Message m)
	{
		switch (m.Msg)
		{
		case 256:
		case 260:
		{
			KeyEventArgs e2 = new KeyEventArgs((Keys)(m.WParam.ToInt32() | (int)XplatUI.State.ModifierKeys));
			OnKeyDown(e2);
			suppressing_key_press = e2.SuppressKeyPress;
			return e2.Handled;
		}
		case 257:
		case 261:
		{
			KeyEventArgs e2 = new KeyEventArgs((Keys)(m.WParam.ToInt32() | (int)XplatUI.State.ModifierKeys));
			OnKeyUp(e2);
			return e2.Handled;
		}
		case 258:
		case 262:
		{
			if (suppressing_key_press)
			{
				return true;
			}
			KeyPressEventArgs e = new KeyPressEventArgs((char)(int)m.WParam);
			OnKeyPress(e);
			m.WParam = (IntPtr)e.KeyChar;
			return e.Handled;
		}
		default:
			return false;
		}
	}

	protected internal virtual bool ProcessKeyMessage(ref Message m)
	{
		if (parent != null && parent.ProcessKeyPreview(ref m))
		{
			return true;
		}
		return ProcessKeyEventArgs(ref m);
	}

	protected virtual bool ProcessKeyPreview(ref Message m)
	{
		if (parent != null)
		{
			return parent.ProcessKeyPreview(ref m);
		}
		return false;
	}

	protected virtual bool ProcessMnemonic(char charCode)
	{
		return false;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected void RaiseDragEvent(object key, DragEventArgs e)
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected void RaiseKeyEvent(object key, KeyEventArgs e)
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected void RaiseMouseEvent(object key, MouseEventArgs e)
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected void RaisePaintEvent(object key, PaintEventArgs e)
	{
	}

	private void SetIsRecreating()
	{
		is_recreating = true;
		Control[] allControls = Controls.GetAllControls();
		for (int i = 0; i < allControls.Length; i++)
		{
			allControls[i].SetIsRecreating();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected void RecreateHandle()
	{
		if (!IsHandleCreated)
		{
			return;
		}
		SetIsRecreating();
		if (IsHandleCreated)
		{
			DestroyHandle();
			return;
		}
		if (!is_created)
		{
			CreateControl();
		}
		else
		{
			CreateHandle();
		}
		is_recreating = false;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected void ResetMouseEventArgs()
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected ContentAlignment RtlTranslateAlignment(ContentAlignment align)
	{
		if (right_to_left == RightToLeft.No)
		{
			return align;
		}
		return align switch
		{
			ContentAlignment.TopLeft => ContentAlignment.TopRight, 
			ContentAlignment.TopRight => ContentAlignment.TopLeft, 
			ContentAlignment.MiddleLeft => ContentAlignment.MiddleRight, 
			ContentAlignment.MiddleRight => ContentAlignment.MiddleLeft, 
			ContentAlignment.BottomLeft => ContentAlignment.BottomRight, 
			ContentAlignment.BottomRight => ContentAlignment.BottomLeft, 
			_ => align, 
		};
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected HorizontalAlignment RtlTranslateAlignment(HorizontalAlignment align)
	{
		if (right_to_left != RightToLeft.No)
		{
			switch (align)
			{
			case HorizontalAlignment.Center:
				break;
			case HorizontalAlignment.Left:
				return HorizontalAlignment.Right;
			default:
				return HorizontalAlignment.Left;
			}
		}
		return align;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected LeftRightAlignment RtlTranslateAlignment(LeftRightAlignment align)
	{
		if (right_to_left == RightToLeft.No)
		{
			return align;
		}
		if (align == LeftRightAlignment.Left)
		{
			return LeftRightAlignment.Right;
		}
		return LeftRightAlignment.Left;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected ContentAlignment RtlTranslateContent(ContentAlignment align)
	{
		return RtlTranslateAlignment(align);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected HorizontalAlignment RtlTranslateHorizontal(HorizontalAlignment align)
	{
		return RtlTranslateAlignment(align);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected LeftRightAlignment RtlTranslateLeftRight(LeftRightAlignment align)
	{
		return RtlTranslateAlignment(align);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void ScaleControl(SizeF factor, BoundsSpecified specified)
	{
		Rectangle scaledBounds = GetScaledBounds(bounds, factor, specified);
		SetBounds(scaledBounds.X, scaledBounds.Y, scaledBounds.Width, scaledBounds.Height, specified);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	protected virtual void ScaleCore(float dx, float dy)
	{
		Rectangle scaledBoundsOld = GetScaledBoundsOld(bounds, new SizeF(dx, dy), BoundsSpecified.All);
		SuspendLayout();
		SetBounds(scaledBoundsOld.X, scaledBoundsOld.Y, scaledBoundsOld.Width, scaledBoundsOld.Height, BoundsSpecified.All);
		if (ScaleChildrenInternal)
		{
			Control[] allControls = Controls.GetAllControls();
			for (int i = 0; i < allControls.Length; i++)
			{
				allControls[i].Scale(dx, dy);
			}
		}
		ResumeLayout();
	}

	protected virtual void Select(bool directed, bool forward)
	{
		IContainerControl containerControl = GetContainerControl();
		if (containerControl != null && (Control)containerControl != this)
		{
			containerControl.ActiveControl = this;
		}
	}

	protected void SetAutoSizeMode(AutoSizeMode mode)
	{
		if (auto_size_mode != mode)
		{
			auto_size_mode = mode;
			cached_preferred_size = Size.Empty;
			if (parent != null)
			{
				parent.LayoutEngine.InitLayout(this, BoundsSpecified.Size);
				PerformLayout(this, "AutoSizeMode");
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
	{
		height = OverrideHeight(height);
		Rectangle rectangle = new Rectangle(x, y, width, height);
		if ((specified & BoundsSpecified.X) == BoundsSpecified.X)
		{
			explicit_bounds.X = rectangle.X;
		}
		if ((specified & BoundsSpecified.Y) == BoundsSpecified.Y)
		{
			explicit_bounds.Y = rectangle.Y;
		}
		if ((specified & BoundsSpecified.Width) == BoundsSpecified.Width)
		{
			explicit_bounds.Width = rectangle.Width;
		}
		if ((specified & BoundsSpecified.Height) == BoundsSpecified.Height)
		{
			explicit_bounds.Height = rectangle.Height;
		}
		if (specified != BoundsSpecified.None)
		{
			explicit_bounds_valid = true;
		}
		if (!rectangle.Equals(bounds))
		{
			if (parent != null)
			{
				parent.SuspendLayout();
			}
			rectangle.Size = ApplySizeConstraints(rectangle.Size);
			if (IsHandleCreated)
			{
				XplatUI.SetWindowPos(Handle, x, y, rectangle.Width, rectangle.Height);
			}
			else
			{
				UpdateBounds(x, y, rectangle.Width, rectangle.Height);
			}
			if (parent != null)
			{
				parent.cached_preferred_size = Size.Empty;
				parent.LayoutEngine.InitLayout(this, specified);
				parent.ResumeLayout();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void SetClientSizeCore(int x, int y)
	{
		Size size = InternalSizeFromClientSize(new Size(x, y));
		if (size != Size.Empty)
		{
			SetBounds(bounds.X, bounds.Y, size.Width, size.Height, BoundsSpecified.Size);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected internal void SetStyle(ControlStyles flag, bool value)
	{
		if (value)
		{
			control_style |= flag;
		}
		else
		{
			control_style &= ~flag;
		}
	}

	protected void SetTopLevel(bool value)
	{
		if (GetTopLevel() != value && parent != null)
		{
			throw new ArgumentException("Cannot change toplevel style of a parented control.");
		}
		if (this is Form)
		{
			if (IsHandleCreated && value != Visible)
			{
				Visible = value;
			}
		}
		else if (!IsHandleCreated)
		{
			CreateHandle();
		}
		is_toplevel = value;
	}

	protected virtual void SetVisibleCore(bool value)
	{
		if (value == is_visible)
		{
			return;
		}
		is_visible = value;
		if (is_visible && (GetTopLevel() || (parent != null && parent.Created)) && (window.Handle == IntPtr.Zero || !is_created))
		{
			CreateControl();
			if (!(this is Form))
			{
				UpdateZOrder();
			}
		}
		if (IsHandleCreated)
		{
			XplatUI.SetVisible(Handle, is_visible, activate: true);
			if (!is_visible)
			{
				if (parent != null && parent.IsHandleCreated)
				{
					if (InternalContainsFocus)
					{
						parent.SelectNextControl(this, forward: true, tabStopOnly: true, nested: true, wrap: true);
					}
					parent.Invalidate(bounds);
					parent.Update();
				}
				else
				{
					Refresh();
				}
			}
			else if (is_visible && this is Form)
			{
				if ((this as Form).WindowState != FormWindowState.Normal)
				{
					OnVisibleChanged(EventArgs.Empty);
				}
				else
				{
					XplatUI.SetWindowPos(window.Handle, bounds.X, bounds.Y, bounds.Width, bounds.Height);
				}
			}
			else if (parent != null)
			{
				parent.UpdateZOrderOfChild(this);
			}
		}
		cached_preferred_size = Size.Empty;
		if (parent != null)
		{
			parent.cached_preferred_size = Size.Empty;
		}
		if (!(this is Form))
		{
			OnVisibleChanged(EventArgs.Empty);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual Size SizeFromClientSize(Size clientSize)
	{
		return InternalSizeFromClientSize(clientSize);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected void UpdateBounds()
	{
		if (IsHandleCreated)
		{
			XplatUI.GetWindowPos(Handle, this is Form, out var x, out var y, out var width, out var height, out var client_width, out var client_height);
			UpdateBounds(x, y, width, height, client_width, client_height);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected void UpdateBounds(int x, int y, int width, int height)
	{
		Rectangle ClientRect = new Rectangle(0, 0, 0, 0);
		CreateParams createParams = CreateParams;
		XplatUI.CalculateWindowRect(ref ClientRect, createParams, createParams.menu, out ClientRect);
		UpdateBounds(x, y, width, height, width - (ClientRect.Right - ClientRect.Left), height - (ClientRect.Bottom - ClientRect.Top));
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected void UpdateBounds(int x, int y, int width, int height, int clientWidth, int clientHeight)
	{
		bool flag = false;
		bool flag2 = false;
		if (bounds.X != x || bounds.Y != y)
		{
			flag = true;
		}
		if (Bounds.Width != width || Bounds.Height != height)
		{
			flag2 = true;
		}
		bounds.X = x;
		bounds.Y = y;
		bounds.Width = width;
		bounds.Height = height;
		client_size.Width = clientWidth;
		client_size.Height = clientHeight;
		if (flag)
		{
			OnLocationChanged(EventArgs.Empty);
			if (!background_color.IsEmpty && background_color.A < byte.MaxValue)
			{
				Invalidate();
			}
		}
		if (flag2)
		{
			OnSizeInitializedOrChanged();
			OnSizeChanged(EventArgs.Empty);
			OnClientSizeChanged(EventArgs.Empty);
			cached_preferred_size = Size.Empty;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected void UpdateStyles()
	{
		if (IsHandleCreated)
		{
			XplatUI.SetWindowStyle(window.Handle, CreateParams);
			OnStyleChanged(EventArgs.Empty);
		}
	}

	private void UpdateZOrderOfChild(Control child)
	{
		if (!IsHandleCreated || !child.IsHandleCreated || child.parent != this)
		{
			return;
		}
		Control[] allControls = child_controls.GetAllControls();
		int num = Array.IndexOf(allControls, child);
		while (num > 0 && (!allControls[num - 1].IsHandleCreated || !allControls[num - 1].VisibleInternal))
		{
			num--;
		}
		if (num > 0)
		{
			XplatUI.SetZOrder(child.Handle, allControls[num - 1].Handle, Top: false, Bottom: false);
			return;
		}
		IntPtr intPtr = AfterTopMostControl();
		if (intPtr != IntPtr.Zero && intPtr != child.Handle)
		{
			XplatUI.SetZOrder(child.Handle, intPtr, Top: false, Bottom: false);
		}
		else
		{
			XplatUI.SetZOrder(child.Handle, IntPtr.Zero, Top: true, Bottom: false);
		}
	}

	internal virtual IntPtr AfterTopMostControl()
	{
		return IntPtr.Zero;
	}

	internal void UpdateChildrenZOrder()
	{
		if (!IsHandleCreated)
		{
			return;
		}
		Control[] array;
		if (child_controls.ImplicitControls == null)
		{
			array = new Control[child_controls.Count];
			child_controls.CopyTo(array, 0);
		}
		else
		{
			array = new Control[child_controls.Count + child_controls.ImplicitControls.Count];
			child_controls.CopyTo(array, 0);
			child_controls.ImplicitControls.CopyTo(array, child_controls.Count);
		}
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].IsHandleCreated && array[i].VisibleInternal)
			{
				arrayList.Add(array[i]);
			}
		}
		for (int j = 1; j < arrayList.Count; j++)
		{
			Control control = (Control)arrayList[j - 1];
			XplatUI.SetZOrder(((Control)arrayList[j]).Handle, control.Handle, Top: false, Bottom: false);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected void UpdateZOrder()
	{
		if (parent != null)
		{
			parent.UpdateZOrderOfChild(this);
		}
	}

	protected virtual void WndProc(ref Message m)
	{
		if ((control_style & ControlStyles.EnableNotifyMessage) != 0)
		{
			OnNotifyMessage(m);
		}
		switch ((Msg)m.Msg)
		{
		case Msg.WM_DESTROY:
			WmDestroy(ref m);
			break;
		case Msg.WM_WINDOWPOSCHANGED:
			WmWindowPosChanged(ref m);
			break;
		case Msg.WM_PAINT:
			WmPaint(ref m);
			break;
		case Msg.WM_ERASEBKGND:
			WmEraseBackground(ref m);
			break;
		case Msg.WM_LBUTTONUP:
			WmLButtonUp(ref m);
			break;
		case Msg.WM_LBUTTONDOWN:
			WmLButtonDown(ref m);
			break;
		case Msg.WM_LBUTTONDBLCLK:
			WmLButtonDblClick(ref m);
			break;
		case Msg.WM_MBUTTONUP:
			WmMButtonUp(ref m);
			break;
		case Msg.WM_MBUTTONDOWN:
			WmMButtonDown(ref m);
			break;
		case Msg.WM_MBUTTONDBLCLK:
			WmMButtonDblClick(ref m);
			break;
		case Msg.WM_RBUTTONUP:
			WmRButtonUp(ref m);
			break;
		case Msg.WM_RBUTTONDOWN:
			WmRButtonDown(ref m);
			break;
		case Msg.WM_RBUTTONDBLCLK:
			WmRButtonDblClick(ref m);
			break;
		case Msg.WM_CONTEXTMENU:
			WmContextMenu(ref m);
			break;
		case Msg.WM_MOUSEWHEEL:
			WmMouseWheel(ref m);
			break;
		case Msg.WM_MOUSEMOVE:
			WmMouseMove(ref m);
			break;
		case Msg.WM_SHOWWINDOW:
			WmShowWindow(ref m);
			break;
		case Msg.WM_CREATE:
			WmCreate(ref m);
			break;
		case Msg.WM_MOUSE_ENTER:
			WmMouseEnter(ref m);
			break;
		case Msg.WM_MOUSELEAVE:
			WmMouseLeave(ref m);
			break;
		case Msg.WM_MOUSEHOVER:
			WmMouseHover(ref m);
			break;
		case Msg.WM_SYSKEYUP:
			WmSysKeyUp(ref m);
			break;
		case Msg.WM_KEYDOWN:
		case Msg.WM_KEYUP:
		case Msg.WM_CHAR:
		case Msg.WM_SYSKEYDOWN:
		case Msg.WM_SYSCHAR:
			WmKeys(ref m);
			break;
		case Msg.WM_HELP:
			WmHelp(ref m);
			break;
		case Msg.WM_KILLFOCUS:
			WmKillFocus(ref m);
			break;
		case Msg.WM_SETFOCUS:
			WmSetFocus(ref m);
			break;
		case Msg.WM_SYSCOLORCHANGE:
			WmSysColorChange(ref m);
			break;
		case Msg.WM_SETCURSOR:
			WmSetCursor(ref m);
			break;
		case Msg.WM_CAPTURECHANGED:
			WmCaptureChanged(ref m);
			break;
		case Msg.WM_CHANGEUISTATE:
			WmChangeUIState(ref m);
			break;
		case Msg.WM_UPDATEUISTATE:
			WmUpdateUIState(ref m);
			break;
		default:
			DefWndProc(ref m);
			break;
		}
	}

	private void WmDestroy(ref Message m)
	{
		OnHandleDestroyed(EventArgs.Empty);
		XplatUI.SetAllowDrop(window.Handle, value: false);
		window.InvalidateHandle();
		is_created = false;
		if (is_recreating)
		{
			CreateHandle();
			is_recreating = false;
		}
		if (is_disposing)
		{
			is_visible = false;
		}
	}

	private void WmWindowPosChanged(ref Message m)
	{
		UpdateBounds();
		if (Visible && GetStyle(ControlStyles.ResizeRedraw))
		{
			Invalidate();
		}
	}

	private void WmPaint(ref Message m)
	{
		IntPtr handle = Handle;
		PaintEventArgs e = XplatUI.PaintEventStart(ref m, handle, client: true);
		if (e == null)
		{
			return;
		}
		try
		{
			DoubleBuffer doubleBuffer = null;
			if (UseDoubleBuffering)
			{
				doubleBuffer = GetBackBuffer();
				doubleBuffer.Start(e);
			}
			if (GetStyle(ControlStyles.OptimizedDoubleBuffer))
			{
				e.Graphics.SetClip(Rectangle.Intersect(e.ClipRectangle, ClientRectangle));
			}
			if (!GetStyle(ControlStyles.Opaque))
			{
				OnPaintBackground(e);
			}
			OnPaintBackgroundInternal(e);
			OnPaintInternal(e);
			if (!e.Handled)
			{
				OnPaint(e);
			}
			doubleBuffer?.End(e);
		}
		finally
		{
			XplatUI.PaintEventEnd(ref m, handle, client: true, e);
		}
	}

	private void WmEraseBackground(ref Message m)
	{
		m.Result = (IntPtr)1;
	}

	private void WmLButtonUp(ref Message m)
	{
		if (XplatUI.IsEnabled(Handle) && active_tracker != null)
		{
			ProcessActiveTracker(ref m);
			return;
		}
		MouseEventArgs e = new MouseEventArgs(FromParamToMouseButtons(m.WParam.ToInt32()) | MouseButtons.Left, mouse_clicks, LowOrder(m.LParam.ToInt32()), HighOrder(m.LParam.ToInt32()), 0);
		HandleClick(mouse_clicks, e);
		OnMouseUp(e);
		if (InternalCapture)
		{
			InternalCapture = false;
		}
		if (mouse_clicks > 1)
		{
			mouse_clicks = 1;
		}
	}

	private void WmLButtonDown(ref Message m)
	{
		if (XplatUI.IsEnabled(Handle) && active_tracker != null)
		{
			ProcessActiveTracker(ref m);
			return;
		}
		ValidationFailed = false;
		if (CanSelect)
		{
			Select(directed: true, forward: true);
		}
		if (!ValidationFailed)
		{
			InternalCapture = true;
			OnMouseDown(new MouseEventArgs(FromParamToMouseButtons(m.WParam.ToInt32()), mouse_clicks, LowOrder(m.LParam.ToInt32()), HighOrder(m.LParam.ToInt32()), 0));
		}
	}

	private void WmLButtonDblClick(ref Message m)
	{
		InternalCapture = true;
		mouse_clicks++;
		OnMouseDown(new MouseEventArgs(FromParamToMouseButtons(m.WParam.ToInt32()), mouse_clicks, LowOrder(m.LParam.ToInt32()), HighOrder(m.LParam.ToInt32()), 0));
	}

	private void WmMButtonUp(ref Message m)
	{
		if (XplatUI.IsEnabled(Handle) && active_tracker != null)
		{
			ProcessActiveTracker(ref m);
			return;
		}
		MouseEventArgs e = new MouseEventArgs(FromParamToMouseButtons(m.WParam.ToInt32()) | MouseButtons.Middle, mouse_clicks, LowOrder(m.LParam.ToInt32()), HighOrder(m.LParam.ToInt32()), 0);
		HandleClick(mouse_clicks, e);
		OnMouseUp(e);
		if (InternalCapture)
		{
			InternalCapture = false;
		}
		if (mouse_clicks > 1)
		{
			mouse_clicks = 1;
		}
	}

	private void WmMButtonDown(ref Message m)
	{
		if (XplatUI.IsEnabled(Handle) && active_tracker != null)
		{
			ProcessActiveTracker(ref m);
			return;
		}
		InternalCapture = true;
		OnMouseDown(new MouseEventArgs(FromParamToMouseButtons(m.WParam.ToInt32()), mouse_clicks, LowOrder(m.LParam.ToInt32()), HighOrder(m.LParam.ToInt32()), 0));
	}

	private void WmMButtonDblClick(ref Message m)
	{
		InternalCapture = true;
		mouse_clicks++;
		OnMouseDown(new MouseEventArgs(FromParamToMouseButtons(m.WParam.ToInt32()), mouse_clicks, LowOrder(m.LParam.ToInt32()), HighOrder(m.LParam.ToInt32()), 0));
	}

	private void WmRButtonUp(ref Message m)
	{
		if (XplatUI.IsEnabled(Handle) && active_tracker != null)
		{
			ProcessActiveTracker(ref m);
			return;
		}
		Point p = new Point(LowOrder(m.LParam.ToInt32()), HighOrder(m.LParam.ToInt32()));
		p = PointToScreen(p);
		MouseEventArgs e = new MouseEventArgs(FromParamToMouseButtons(m.WParam.ToInt32()) | MouseButtons.Right, mouse_clicks, LowOrder(m.LParam.ToInt32()), HighOrder(m.LParam.ToInt32()), 0);
		HandleClick(mouse_clicks, e);
		XplatUI.SendMessage(m.HWnd, Msg.WM_CONTEXTMENU, m.HWnd, (IntPtr)(p.X + (p.Y << 16)));
		OnMouseUp(e);
		if (InternalCapture)
		{
			InternalCapture = false;
		}
		if (mouse_clicks > 1)
		{
			mouse_clicks = 1;
		}
	}

	private void WmRButtonDown(ref Message m)
	{
		if (XplatUI.IsEnabled(Handle) && active_tracker != null)
		{
			ProcessActiveTracker(ref m);
			return;
		}
		InternalCapture = true;
		OnMouseDown(new MouseEventArgs(FromParamToMouseButtons(m.WParam.ToInt32()), mouse_clicks, LowOrder(m.LParam.ToInt32()), HighOrder(m.LParam.ToInt32()), 0));
	}

	private void WmRButtonDblClick(ref Message m)
	{
		InternalCapture = true;
		mouse_clicks++;
		OnMouseDown(new MouseEventArgs(FromParamToMouseButtons(m.WParam.ToInt32()), mouse_clicks, LowOrder(m.LParam.ToInt32()), HighOrder(m.LParam.ToInt32()), 0));
	}

	private void WmContextMenu(ref Message m)
	{
		if (context_menu != null)
		{
			Point p = new Point(LowOrder(m.LParam.ToInt32()), HighOrder(m.LParam.ToInt32()));
			if (p.X == -1 || p.Y == -1)
			{
				p.X = Width / 2 + Left;
				p.Y = Height / 2 + Top;
				p = PointToScreen(p);
			}
			context_menu.Show(this, PointToClient(p));
		}
		else if (context_menu == null && context_menu_strip != null)
		{
			Point p2 = new Point(LowOrder(m.LParam.ToInt32()), HighOrder(m.LParam.ToInt32()));
			if (p2.X == -1 || p2.Y == -1)
			{
				p2.X = Width / 2 + Left;
				p2.Y = Height / 2 + Top;
				p2 = PointToScreen(p2);
			}
			context_menu_strip.Show(this, PointToClient(p2));
		}
		else
		{
			DefWndProc(ref m);
		}
	}

	private void WmCreate(ref Message m)
	{
		OnHandleCreated(EventArgs.Empty);
	}

	private void WmMouseWheel(ref Message m)
	{
		DefWndProc(ref m);
		OnMouseWheel(new MouseEventArgs(FromParamToMouseButtons((long)m.WParam), mouse_clicks, LowOrder(m.LParam.ToInt32()), HighOrder(m.LParam.ToInt32()), HighOrder((long)m.WParam)));
	}

	private void WmMouseMove(ref Message m)
	{
		if (XplatUI.IsEnabled(Handle) && active_tracker != null)
		{
			MouseEventArgs args = new MouseEventArgs(FromParamToMouseButtons(m.WParam.ToInt32()), mouse_clicks, MousePosition.X, MousePosition.Y, 0);
			active_tracker.OnMotion(args);
		}
		else
		{
			OnMouseMove(new MouseEventArgs(FromParamToMouseButtons(m.WParam.ToInt32()), mouse_clicks, LowOrder(m.LParam.ToInt32()), HighOrder(m.LParam.ToInt32()), 0));
		}
	}

	private void WmMouseEnter(ref Message m)
	{
		if (!is_entered)
		{
			is_entered = true;
			OnMouseEnter(EventArgs.Empty);
		}
	}

	private void WmMouseLeave(ref Message m)
	{
		is_entered = false;
		OnMouseLeave(EventArgs.Empty);
	}

	private void WmMouseHover(ref Message m)
	{
		OnMouseHover(EventArgs.Empty);
	}

	private void WmShowWindow(ref Message m)
	{
		if (IsDisposed)
		{
			return;
		}
		Form form = this as Form;
		if (m.WParam.ToInt32() != 0)
		{
			if (m.LParam.ToInt32() == 0)
			{
				CreateControl();
				Control[] allControls = child_controls.GetAllControls();
				for (int i = 0; i < allControls.Length; i++)
				{
					if (allControls[i].is_visible && allControls[i].IsHandleCreated && XplatUI.GetParent(allControls[i].Handle, with_owner: false) != window.Handle)
					{
						XplatUI.SetParent(allControls[i].Handle, window.Handle);
					}
				}
				UpdateChildrenZOrder();
			}
		}
		else if (parent != null && Focused)
		{
			Control control = (Control)parent.GetContainerControl();
			if (control != null && (form == null || !form.IsMdiChild))
			{
				control.SelectNextControl(this, forward: true, tabStopOnly: true, nested: true, wrap: true);
			}
		}
		if (form != null)
		{
			form.waiting_showwindow = false;
		}
		if (form != null)
		{
			if (!IsRecreating && (form.IsMdiChild || form.WindowState == FormWindowState.Normal))
			{
				OnVisibleChanged(EventArgs.Empty);
			}
		}
		else if (is_toplevel)
		{
			OnVisibleChanged(EventArgs.Empty);
		}
	}

	private void WmSysKeyUp(ref Message m)
	{
		if (ProcessKeyMessage(ref m))
		{
			m.Result = IntPtr.Zero;
			return;
		}
		if ((m.WParam.ToInt32() & 0xFFFF) == 18)
		{
			Form form = FindForm();
			if (form != null && form.ActiveMenu != null)
			{
				form.ActiveMenu.ProcessCmdKey(ref m, (Keys)m.WParam.ToInt32());
			}
			else if (ToolStripManager.ProcessMenuKey(ref m))
			{
				return;
			}
		}
		DefWndProc(ref m);
	}

	private void WmKeys(ref Message m)
	{
		if (ProcessKeyMessage(ref m))
		{
			m.Result = IntPtr.Zero;
		}
		else
		{
			DefWndProc(ref m);
		}
	}

	private void WmHelp(ref Message m)
	{
		Point mousePos;
		if (m.LParam != IntPtr.Zero)
		{
			HELPINFO hELPINFO = default;
			hELPINFO = (HELPINFO)Marshal.PtrToStructure(m.LParam, typeof(HELPINFO));
			mousePos = new Point(hELPINFO.MousePos.x, hELPINFO.MousePos.y);
		}
		else
		{
			mousePos = MousePosition;
		}
		OnHelpRequested(new HelpEventArgs(mousePos));
		m.Result = (IntPtr)1;
	}

	private void WmKillFocus(ref Message m)
	{
		has_focus = false;
		OnLostFocus(EventArgs.Empty);
	}

	private void WmSetFocus(ref Message m)
	{
		if (!has_focus)
		{
			has_focus = true;
			OnGotFocus(EventArgs.Empty);
		}
	}

	private void WmSysColorChange(ref Message m)
	{
		ThemeEngine.Current.ResetDefaults();
		OnSystemColorsChanged(EventArgs.Empty);
	}

	private void WmSetCursor(ref Message m)
	{
		if ((cursor == null && !use_wait_cursor) || (m.LParam.ToInt32() & 0xFFFF) != 1)
		{
			DefWndProc(ref m);
			return;
		}
		XplatUI.SetCursor(window.Handle, Cursor.handle);
		m.Result = (IntPtr)1;
	}

	private void WmCaptureChanged(ref Message m)
	{
		is_captured = false;
		OnMouseCaptureChanged(EventArgs.Empty);
		m.Result = (IntPtr)0;
	}

	private void WmChangeUIState(ref Message m)
	{
		foreach (Control control in Controls)
		{
			XplatUI.SendMessage(control.Handle, Msg.WM_UPDATEUISTATE, m.WParam, m.LParam);
		}
	}

	private void WmUpdateUIState(ref Message m)
	{
		int num = LowOrder(m.WParam.ToInt32());
		int num2 = HighOrder(m.WParam.ToInt32());
		if (num != 3)
		{
			UICues uICues = UICues.None;
			if ((num2 & 2) != 0 && num == 2 != show_keyboard_cues)
			{
				uICues |= UICues.ChangeKeyboard;
				show_keyboard_cues = num == 2;
			}
			if ((num2 & 1) != 0 && num == 2 != show_focus_cues)
			{
				uICues |= UICues.ChangeFocus;
				show_focus_cues = num == 2;
			}
			if ((uICues & UICues.Changed) != UICues.None)
			{
				OnChangeUICues(new UICuesEventArgs(uICues));
				Invalidate();
			}
		}
	}

	protected virtual void OnAutoSizeChanged(EventArgs e)
	{
		((EventHandler)base.Events[AutoSizeChangedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnBackColorChanged(EventArgs e)
	{
		((EventHandler)base.Events[BackColorChangedEvent])?.Invoke(this, e);
		for (int i = 0; i < child_controls.Count; i++)
		{
			child_controls[i].OnParentBackColorChanged(e);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnBackgroundImageChanged(EventArgs e)
	{
		((EventHandler)base.Events[BackgroundImageChangedEvent])?.Invoke(this, e);
		for (int i = 0; i < child_controls.Count; i++)
		{
			child_controls[i].OnParentBackgroundImageChanged(e);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnBackgroundImageLayoutChanged(EventArgs e)
	{
		((EventHandler)base.Events[BackgroundImageLayoutChangedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnBindingContextChanged(EventArgs e)
	{
		CheckDataBindings();
		((EventHandler)base.Events[BindingContextChangedEvent])?.Invoke(this, e);
		for (int i = 0; i < child_controls.Count; i++)
		{
			child_controls[i].OnParentBindingContextChanged(e);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnCausesValidationChanged(EventArgs e)
	{
		((EventHandler)base.Events[CausesValidationChangedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnChangeUICues(UICuesEventArgs e)
	{
		((UICuesEventHandler)base.Events[ChangeUICuesEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnClick(EventArgs e)
	{
		((EventHandler)base.Events[ClickEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnClientSizeChanged(EventArgs e)
	{
		((EventHandler)base.Events[ClientSizeChangedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnContextMenuChanged(EventArgs e)
	{
		((EventHandler)base.Events[ContextMenuChangedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnContextMenuStripChanged(EventArgs e)
	{
		((EventHandler)base.Events[ContextMenuStripChangedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnControlAdded(ControlEventArgs e)
	{
		((ControlEventHandler)base.Events[ControlAddedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnControlRemoved(ControlEventArgs e)
	{
		((ControlEventHandler)base.Events[ControlRemovedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnCreateControl()
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnCursorChanged(EventArgs e)
	{
		((EventHandler)base.Events[CursorChangedEvent])?.Invoke(this, e);
		for (int i = 0; i < child_controls.Count; i++)
		{
			child_controls[i].OnParentCursorChanged(e);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnDockChanged(EventArgs e)
	{
		((EventHandler)base.Events[DockChangedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnDoubleClick(EventArgs e)
	{
		((EventHandler)base.Events[DoubleClickEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnDragDrop(DragEventArgs drgevent)
	{
		((DragEventHandler)base.Events[DragDropEvent])?.Invoke(this, drgevent);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnDragEnter(DragEventArgs drgevent)
	{
		((DragEventHandler)base.Events[DragEnterEvent])?.Invoke(this, drgevent);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnDragLeave(EventArgs e)
	{
		((EventHandler)base.Events[DragLeaveEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnDragOver(DragEventArgs drgevent)
	{
		((DragEventHandler)base.Events[DragOverEvent])?.Invoke(this, drgevent);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnEnabledChanged(EventArgs e)
	{
		if (IsHandleCreated)
		{
			if (this is Form)
			{
				if (((Form)this).context == null)
				{
					XplatUI.EnableWindow(window.Handle, Enabled);
				}
			}
			else
			{
				XplatUI.EnableWindow(window.Handle, Enabled);
			}
			Refresh();
		}
		((EventHandler)base.Events[EnabledChangedEvent])?.Invoke(this, e);
		Control[] allControls = Controls.GetAllControls();
		for (int i = 0; i < allControls.Length; i++)
		{
			allControls[i].OnParentEnabledChanged(e);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnEnter(EventArgs e)
	{
		((EventHandler)base.Events[EnterEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnFontChanged(EventArgs e)
	{
		((EventHandler)base.Events[FontChangedEvent])?.Invoke(this, e);
		SuspendLayout();
		for (int i = 0; i < child_controls.Count; i++)
		{
			child_controls[i].OnParentFontChanged(e);
		}
		ResumeLayout(performLayout: false);
		PerformLayout(this, "Font");
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnForeColorChanged(EventArgs e)
	{
		((EventHandler)base.Events[ForeColorChangedEvent])?.Invoke(this, e);
		for (int i = 0; i < child_controls.Count; i++)
		{
			child_controls[i].OnParentForeColorChanged(e);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
	{
		((GiveFeedbackEventHandler)base.Events[GiveFeedbackEvent])?.Invoke(this, gfbevent);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnGotFocus(EventArgs e)
	{
		((EventHandler)base.Events[GotFocusEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnHandleCreated(EventArgs e)
	{
		((EventHandler)base.Events[HandleCreatedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnHandleDestroyed(EventArgs e)
	{
		((EventHandler)base.Events[HandleDestroyedEvent])?.Invoke(this, e);
	}

	internal void RaiseHelpRequested(HelpEventArgs hevent)
	{
		OnHelpRequested(hevent);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnHelpRequested(HelpEventArgs hevent)
	{
		((HelpEventHandler)base.Events[HelpRequestedEvent])?.Invoke(this, hevent);
	}

	protected virtual void OnImeModeChanged(EventArgs e)
	{
		((EventHandler)base.Events[ImeModeChangedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnInvalidated(InvalidateEventArgs e)
	{
		if (UseDoubleBuffering)
		{
			if (e.InvalidRect == ClientRectangle)
			{
				InvalidateBackBuffer();
			}
			else if (backbuffer != null)
			{
				Rectangle rect = Rectangle.Inflate(e.InvalidRect, 1, 1);
				backbuffer.InvalidRegion.Union(rect);
			}
		}
		((InvalidateEventHandler)base.Events[InvalidatedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnKeyDown(KeyEventArgs e)
	{
		((KeyEventHandler)base.Events[KeyDownEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnKeyPress(KeyPressEventArgs e)
	{
		((KeyPressEventHandler)base.Events[KeyPressEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnKeyUp(KeyEventArgs e)
	{
		((KeyEventHandler)base.Events[KeyUpEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnLayout(LayoutEventArgs levent)
	{
		((LayoutEventHandler)base.Events[LayoutEvent])?.Invoke(this, levent);
		_ = Size;
		bool flag = LayoutEngine.Layout(this, levent);
		if ((parent != null) & flag)
		{
			parent.layout_dirty = true;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnLeave(EventArgs e)
	{
		((EventHandler)base.Events[LeaveEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnLocationChanged(EventArgs e)
	{
		OnMove(e);
		((EventHandler)base.Events[LocationChangedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnLostFocus(EventArgs e)
	{
		((EventHandler)base.Events[LostFocusEvent])?.Invoke(this, e);
	}

	protected virtual void OnMarginChanged(EventArgs e)
	{
		((EventHandler)base.Events[MarginChangedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnMouseCaptureChanged(EventArgs e)
	{
		((EventHandler)base.Events[MouseCaptureChangedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnMouseClick(MouseEventArgs e)
	{
		((MouseEventHandler)base.Events[MouseClickEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnMouseDoubleClick(MouseEventArgs e)
	{
		((MouseEventHandler)base.Events[MouseDoubleClickEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnMouseDown(MouseEventArgs e)
	{
		((MouseEventHandler)base.Events[MouseDownEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnMouseEnter(EventArgs e)
	{
		((EventHandler)base.Events[MouseEnterEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnMouseHover(EventArgs e)
	{
		((EventHandler)base.Events[MouseHoverEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnMouseLeave(EventArgs e)
	{
		((EventHandler)base.Events[MouseLeaveEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnMouseMove(MouseEventArgs e)
	{
		((MouseEventHandler)base.Events[MouseMoveEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnMouseUp(MouseEventArgs e)
	{
		((MouseEventHandler)base.Events[MouseUpEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnMouseWheel(MouseEventArgs e)
	{
		((MouseEventHandler)base.Events[MouseWheelEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnMove(EventArgs e)
	{
		((EventHandler)base.Events[MoveEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnNotifyMessage(Message m)
	{
	}

	protected virtual void OnPaddingChanged(EventArgs e)
	{
		((EventHandler)base.Events[PaddingChangedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnPaint(PaintEventArgs e)
	{
		((PaintEventHandler)base.Events[PaintEvent])?.Invoke(this, e);
	}

	internal virtual void OnPaintBackgroundInternal(PaintEventArgs e)
	{
	}

	internal virtual void OnPaintInternal(PaintEventArgs e)
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnPaintBackground(PaintEventArgs pevent)
	{
		PaintControlBackground(pevent);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnParentBackColorChanged(EventArgs e)
	{
		if (background_color.IsEmpty && background_image == null)
		{
			Invalidate();
			OnBackColorChanged(e);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnParentBackgroundImageChanged(EventArgs e)
	{
		Invalidate();
		OnBackgroundImageChanged(e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnParentBindingContextChanged(EventArgs e)
	{
		if (binding_context == null && Parent != null)
		{
			binding_context = Parent.binding_context;
			OnBindingContextChanged(e);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnParentChanged(EventArgs e)
	{
		((EventHandler)base.Events[ParentChangedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnParentCursorChanged(EventArgs e)
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnParentEnabledChanged(EventArgs e)
	{
		if (is_enabled)
		{
			OnEnabledChanged(e);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnParentFontChanged(EventArgs e)
	{
		if (font == null)
		{
			Invalidate();
			OnFontChanged(e);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnParentForeColorChanged(EventArgs e)
	{
		if (foreground_color.IsEmpty)
		{
			Invalidate();
			OnForeColorChanged(e);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnParentRightToLeftChanged(EventArgs e)
	{
		if (right_to_left == RightToLeft.Inherit)
		{
			Invalidate();
			OnRightToLeftChanged(e);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnParentVisibleChanged(EventArgs e)
	{
		if (is_visible)
		{
			OnVisibleChanged(e);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnQueryContinueDrag(QueryContinueDragEventArgs qcdevent)
	{
		((QueryContinueDragEventHandler)base.Events[QueryContinueDragEvent])?.Invoke(this, qcdevent);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
	{
		((PreviewKeyDownEventHandler)base.Events[PreviewKeyDownEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnPrint(PaintEventArgs e)
	{
		((PaintEventHandler)base.Events[PaintEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnRegionChanged(EventArgs e)
	{
		((EventHandler)base.Events[RegionChangedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnResize(EventArgs e)
	{
		OnResizeInternal(e);
	}

	internal virtual void OnResizeInternal(EventArgs e)
	{
		PerformLayout(this, "Bounds");
		((EventHandler)base.Events[ResizeEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnRightToLeftChanged(EventArgs e)
	{
		((EventHandler)base.Events[RightToLeftChangedEvent])?.Invoke(this, e);
		for (int i = 0; i < child_controls.Count; i++)
		{
			child_controls[i].OnParentRightToLeftChanged(e);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnSizeChanged(EventArgs e)
	{
		DisposeBackBuffer();
		OnResize(e);
		((EventHandler)base.Events[SizeChangedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnStyleChanged(EventArgs e)
	{
		((EventHandler)base.Events[StyleChangedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnSystemColorsChanged(EventArgs e)
	{
		((EventHandler)base.Events[SystemColorsChangedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnTabIndexChanged(EventArgs e)
	{
		((EventHandler)base.Events[TabIndexChangedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnTabStopChanged(EventArgs e)
	{
		((EventHandler)base.Events[TabStopChangedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnTextChanged(EventArgs e)
	{
		cached_preferred_size = Size.Empty;
		((EventHandler)base.Events[TextChangedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnValidated(EventArgs e)
	{
		((EventHandler)base.Events[ValidatedEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnValidating(CancelEventArgs e)
	{
		((CancelEventHandler)base.Events[ValidatingEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnVisibleChanged(EventArgs e)
	{
		if (parent != null && Visible)
		{
			CreateControl();
		}
		((EventHandler)base.Events[VisibleChangedEvent])?.Invoke(this, e);
		Control[] allControls = Controls.GetAllControls();
		foreach (Control control in allControls)
		{
			if (control.Visible)
			{
				control.OnParentVisibleChanged(e);
			}
		}
	}

	public Size LogicalToDeviceUnits(Size value)
	{
		Unity.ThrowStub.ThrowNotSupportedException();
		return default;
	}

	public int LogicalToDeviceUnits(int value)
	{
		Unity.ThrowStub.ThrowNotSupportedException();
		return default;
	}

	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	protected virtual void OnDpiChangedAfterParent(EventArgs e)
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}

	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	protected virtual void OnDpiChangedBeforeParent(EventArgs e)
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}

	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void RescaleConstantsForDpi(int deviceDpiOld, int deviceDpiNew)
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}

	public void ScaleBitmapLogicalToDevice(ref Bitmap logicalBitmap)
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}
}
