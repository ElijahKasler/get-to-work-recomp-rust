using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.Serialization;
using System.Text;

namespace System.Windows.Forms;

[Serializable]
[TypeConverter(typeof(TreeNodeConverter))]
[DefaultProperty("Text")]
public class TreeNode : MarshalByRefObject, ICloneable, ISerializable
{
	private TreeView tree_view;

	internal TreeNode parent;

	private string text;

	private int image_index = -1;

	private int selected_image_index = -1;

	private ContextMenu context_menu;

	private ContextMenuStrip context_menu_strip;

	private string image_key = string.Empty;

	private string selected_image_key = string.Empty;

	private int state_image_index = -1;

	private string state_image_key = string.Empty;

	private string tool_tip_text = string.Empty;

	internal TreeNodeCollection nodes;

	internal TreeViewAction check_reason;

	internal int visible_order;

	internal int width = -1;

	internal bool is_expanded;

	private bool check;

	internal OwnerDrawPropertyBag prop_bag;

	private object tag;

	internal IntPtr handle;

	private string name = string.Empty;

	public Color BackColor
	{
		get
		{
			if (prop_bag != null)
			{
				return prop_bag.BackColor;
			}
			return Color.Empty;
		}
		set
		{
			if (prop_bag == null)
			{
				prop_bag = new OwnerDrawPropertyBag();
			}
			prop_bag.BackColor = value;
			TreeView?.UpdateNode(this);
		}
	}

	[Browsable(false)]
	public Rectangle Bounds
	{
		get
		{
			if (TreeView == null)
			{
				return Rectangle.Empty;
			}
			int x = GetX();
			int y = GetY();
			if (width == -1)
			{
				width = TreeView.GetNodeWidth(this);
			}
			return new Rectangle(x, y, width, TreeView.ActualItemHeight);
		}
	}

	internal int IndentLevel
	{
		get
		{
			TreeNode treeNode = this;
			int num = 0;
			while (treeNode.Parent != null)
			{
				treeNode = treeNode.Parent;
				num++;
			}
			return num;
		}
	}

	[DefaultValue(false)]
	public bool Checked
	{
		get
		{
			return check;
		}
		set
		{
			if (check == value)
			{
				return;
			}
			TreeViewCancelEventArgs e = new TreeViewCancelEventArgs(this, cancel: false, check_reason);
			if (TreeView != null)
			{
				TreeView.OnBeforeCheck(e);
			}
			if (!e.Cancel)
			{
				check = value;
				if (TreeView != null)
				{
					TreeView.OnAfterCheck(new TreeViewEventArgs(this, check_reason));
				}
				if (TreeView != null)
				{
					TreeView.UpdateNode(this);
				}
			}
			check_reason = TreeViewAction.Unknown;
		}
	}

	[DefaultValue(null)]
	public virtual ContextMenu ContextMenu
	{
		get
		{
			return context_menu;
		}
		set
		{
			context_menu = value;
		}
	}

	[DefaultValue(null)]
	public virtual ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return context_menu_strip;
		}
		set
		{
			context_menu_strip = value;
		}
	}

	[Browsable(false)]
	public TreeNode FirstNode
	{
		get
		{
			if (nodes.Count > 0)
			{
				return nodes[0];
			}
			return null;
		}
	}

	public Color ForeColor
	{
		get
		{
			if (prop_bag != null)
			{
				return prop_bag.ForeColor;
			}
			if (TreeView != null)
			{
				return TreeView.ForeColor;
			}
			return Color.Empty;
		}
		set
		{
			if (prop_bag == null)
			{
				prop_bag = new OwnerDrawPropertyBag();
			}
			prop_bag.ForeColor = value;
			TreeView?.UpdateNode(this);
		}
	}

	[Browsable(false)]
	public string FullPath
	{
		get
		{
			if (TreeView == null)
			{
				throw new InvalidOperationException("No TreeView associated");
			}
			StringBuilder stringBuilder = new StringBuilder();
			BuildFullPath(stringBuilder);
			return stringBuilder.ToString();
		}
	}

	[DefaultValue(-1)]
	[RelatedImageList("TreeView.ImageList")]
	[TypeConverter(typeof(TreeViewImageIndexConverter))]
	[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[Localizable(true)]
	[RefreshProperties(RefreshProperties.Repaint)]
	public int ImageIndex
	{
		get
		{
			return image_index;
		}
		set
		{
			if (image_index != value)
			{
				image_index = value;
				image_key = string.Empty;
				TreeView?.UpdateNode(this);
			}
		}
	}

	[Localizable(true)]
	[DefaultValue("")]
	[RelatedImageList("TreeView.ImageList")]
	[TypeConverter(typeof(TreeViewImageKeyConverter))]
	[RefreshProperties(RefreshProperties.Repaint)]
	[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public string ImageKey
	{
		get
		{
			return image_key;
		}
		set
		{
			if (!(image_key == value))
			{
				image_key = value;
				image_index = -1;
				TreeView?.UpdateNode(this);
			}
		}
	}

	[Browsable(false)]
	public bool IsEditing
	{
		get
		{
			TreeView treeView = TreeView;
			if (treeView == null)
			{
				return false;
			}
			return treeView.edit_node == this;
		}
	}

	[Browsable(false)]
	public bool IsExpanded
	{
		get
		{
			TreeView treeView = TreeView;
			if (treeView != null && treeView.IsHandleCreated)
			{
				bool flag = false;
				foreach (TreeNode node in TreeView.Nodes)
				{
					if (node.Nodes.Count > 0)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
			return is_expanded;
		}
	}

	[Browsable(false)]
	public bool IsSelected
	{
		get
		{
			if (TreeView == null || !TreeView.IsHandleCreated)
			{
				return false;
			}
			return TreeView.SelectedNode == this;
		}
	}

	[Browsable(false)]
	public bool IsVisible
	{
		get
		{
			if (TreeView == null || !TreeView.IsHandleCreated || !TreeView.Visible)
			{
				return false;
			}
			if (visible_order <= TreeView.skipped_nodes || visible_order - TreeView.skipped_nodes > TreeView.VisibleCount)
			{
				return false;
			}
			return ArePreviousNodesExpanded;
		}
	}

	[Browsable(false)]
	public TreeNode LastNode
	{
		get
		{
			if (nodes != null && nodes.Count != 0)
			{
				return nodes[nodes.Count - 1];
			}
			return null;
		}
	}

	[Browsable(false)]
	public int Level => IndentLevel;

	public string Name
	{
		get
		{
			return name;
		}
		set
		{
			name = ((value == null) ? string.Empty : value);
		}
	}

	[Browsable(false)]
	public TreeNode NextNode
	{
		get
		{
			if (parent == null)
			{
				return null;
			}
			int index = Index;
			if (parent.Nodes.Count > index + 1)
			{
				return parent.Nodes[index + 1];
			}
			return null;
		}
	}

	[Browsable(false)]
	public TreeNode NextVisibleNode
	{
		get
		{
			OpenTreeNodeEnumerator openTreeNodeEnumerator = new OpenTreeNodeEnumerator(this);
			openTreeNodeEnumerator.MoveNext();
			if (!openTreeNodeEnumerator.MoveNext())
			{
				return null;
			}
			TreeNode currentNode = openTreeNodeEnumerator.CurrentNode;
			if (!currentNode.IsInClippingRect)
			{
				return null;
			}
			return currentNode;
		}
	}

	[Localizable(true)]
	[DefaultValue(null)]
	public Font NodeFont
	{
		get
		{
			if (prop_bag != null)
			{
				return prop_bag.Font;
			}
			if (TreeView != null)
			{
				return TreeView.Font;
			}
			return null;
		}
		set
		{
			if (prop_bag == null)
			{
				prop_bag = new OwnerDrawPropertyBag();
			}
			prop_bag.Font = value;
			Invalidate();
		}
	}

	[Browsable(false)]
	[ListBindable(false)]
	public TreeNodeCollection Nodes
	{
		get
		{
			if (nodes == null)
			{
				nodes = new TreeNodeCollection(this);
			}
			return nodes;
		}
	}

	[Browsable(false)]
	public TreeNode Parent
	{
		get
		{
			TreeView treeView = TreeView;
			if (treeView != null && treeView.root_node == parent)
			{
				return null;
			}
			return parent;
		}
	}

	[Browsable(false)]
	public TreeNode PrevNode
	{
		get
		{
			if (parent == null)
			{
				return null;
			}
			int index = Index;
			if (index <= 0 || index > parent.Nodes.Count)
			{
				return null;
			}
			return parent.Nodes[index - 1];
		}
	}

	[Browsable(false)]
	public TreeNode PrevVisibleNode
	{
		get
		{
			OpenTreeNodeEnumerator openTreeNodeEnumerator = new OpenTreeNodeEnumerator(this);
			openTreeNodeEnumerator.MovePrevious();
			if (!openTreeNodeEnumerator.MovePrevious())
			{
				return null;
			}
			TreeNode currentNode = openTreeNodeEnumerator.CurrentNode;
			if (!currentNode.IsInClippingRect)
			{
				return null;
			}
			return currentNode;
		}
	}

	[DefaultValue(-1)]
	[RelatedImageList("TreeView.ImageList")]
	[TypeConverter(typeof(TreeViewImageIndexConverter))]
	[RefreshProperties(RefreshProperties.Repaint)]
	[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[Localizable(true)]
	public int SelectedImageIndex
	{
		get
		{
			return selected_image_index;
		}
		set
		{
			selected_image_index = value;
		}
	}

	[RefreshProperties(RefreshProperties.Repaint)]
	[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[TypeConverter(typeof(TreeViewImageKeyConverter))]
	[Localizable(true)]
	[DefaultValue("")]
	[RelatedImageList("TreeView.ImageList")]
	public string SelectedImageKey
	{
		get
		{
			return selected_image_key;
		}
		set
		{
			selected_image_key = value;
		}
	}

	[Localizable(true)]
	[DefaultValue(-1)]
	[RelatedImageList("TreeView.StateImageList")]
	[TypeConverter(typeof(NoneExcludedImageIndexConverter))]
	[RefreshProperties(RefreshProperties.Repaint)]
	[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public int StateImageIndex
	{
		get
		{
			return state_image_index;
		}
		set
		{
			if (state_image_index != value)
			{
				state_image_index = value;
				state_image_key = string.Empty;
				Invalidate();
			}
		}
	}

	[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[RefreshProperties(RefreshProperties.Repaint)]
	[RelatedImageList("TreeView.StateImageList")]
	[TypeConverter(typeof(ImageKeyConverter))]
	[Localizable(true)]
	[DefaultValue("")]
	public string StateImageKey
	{
		get
		{
			return state_image_key;
		}
		set
		{
			if (state_image_key != value)
			{
				state_image_key = value;
				state_image_index = -1;
				Invalidate();
			}
		}
	}

	[DefaultValue(null)]
	[Bindable(true)]
	[Localizable(false)]
	[TypeConverter(typeof(StringConverter))]
	public object Tag
	{
		get
		{
			return tag;
		}
		set
		{
			tag = value;
		}
	}

	[Localizable(true)]
	public string Text
	{
		get
		{
			if (text == null)
			{
				return string.Empty;
			}
			return text;
		}
		set
		{
			if (!(text == value))
			{
				text = value;
				Invalidate();
				TreeView?.OnUIANodeTextChanged(new TreeViewEventArgs(this));
			}
		}
	}

	[DefaultValue("")]
	[Localizable(false)]
	public string ToolTipText
	{
		get
		{
			return tool_tip_text;
		}
		set
		{
			tool_tip_text = value;
		}
	}

	[Browsable(false)]
	public TreeView TreeView
	{
		get
		{
			if (tree_view != null)
			{
				return tree_view;
			}
			TreeNode treeNode = parent;
			while (treeNode != null && treeNode.TreeView == null)
			{
				treeNode = treeNode.parent;
			}
			return treeNode?.TreeView;
		}
	}

	[Browsable(false)]
	public IntPtr Handle
	{
		get
		{
			if (handle == IntPtr.Zero && TreeView != null)
			{
				handle = TreeView.CreateNodeHandle();
			}
			return handle;
		}
	}

	internal bool ArePreviousNodesExpanded
	{
		get
		{
			for (TreeNode treeNode = Parent; treeNode != null; treeNode = treeNode.Parent)
			{
				if (!treeNode.is_expanded)
				{
					return false;
				}
			}
			return true;
		}
	}

	internal bool IsRoot
	{
		get
		{
			TreeView treeView = TreeView;
			if (treeView == null)
			{
				return false;
			}
			if (treeView.root_node == this)
			{
				return true;
			}
			return false;
		}
	}

	public int Index
	{
		get
		{
			if (parent == null)
			{
				return 0;
			}
			return parent.Nodes.IndexOf(this);
		}
	}

	internal bool NeedsWidth => width == -1;

	private bool IsInClippingRect
	{
		get
		{
			if (TreeView == null)
			{
				return false;
			}
			Rectangle bounds = Bounds;
			if (bounds.Y < 0 && bounds.Y > TreeView.ClientRectangle.Height)
			{
				return false;
			}
			return true;
		}
	}

	internal Image StateImage
	{
		get
		{
			if (TreeView != null)
			{
				if (TreeView.StateImageList == null)
				{
					return null;
				}
				if (state_image_index >= 0)
				{
					return TreeView.StateImageList.Images[state_image_index];
				}
				if (state_image_key != string.Empty)
				{
					return TreeView.StateImageList.Images[state_image_key];
				}
			}
			return null;
		}
	}

	internal int Image
	{
		get
		{
			if (TreeView == null || TreeView.ImageList == null)
			{
				return -1;
			}
			if (IsSelected)
			{
				if (selected_image_index >= 0)
				{
					return selected_image_index;
				}
				if (!string.IsNullOrEmpty(selected_image_key))
				{
					return TreeView.ImageList.Images.IndexOfKey(selected_image_key);
				}
				if (!string.IsNullOrEmpty(TreeView.SelectedImageKey))
				{
					return TreeView.ImageList.Images.IndexOfKey(TreeView.SelectedImageKey);
				}
				if (selected_image_index == -1 && TreeView.SelectedImageIndex >= 0)
				{
					return TreeView.SelectedImageIndex;
				}
			}
			else
			{
				if (image_index >= 0)
				{
					return image_index;
				}
				if (!string.IsNullOrEmpty(image_key))
				{
					return TreeView.ImageList.Images.IndexOfKey(image_key);
				}
				if (!string.IsNullOrEmpty(TreeView.ImageKey))
				{
					return TreeView.ImageList.Images.IndexOfKey(TreeView.ImageKey);
				}
				if (image_index == -1 && TreeView.ImageIndex >= 0)
				{
					return TreeView.ImageIndex;
				}
			}
			return -1;
		}
	}

	internal TreeNode(TreeView tree_view)
		: this()
	{
		this.tree_view = tree_view;
		is_expanded = true;
	}

	protected TreeNode(SerializationInfo serializationInfo, StreamingContext context)
		: this()
	{
		SerializationInfoEnumerator enumerator = serializationInfo.GetEnumerator();
		int num = 0;
		while (enumerator.MoveNext())
		{
			SerializationEntry current = enumerator.Current;
			switch (current.Name)
			{
			case "Text":
				Text = (string)current.Value;
				break;
			case "PropBag":
				prop_bag = (OwnerDrawPropertyBag)current.Value;
				break;
			case "ImageIndex":
				image_index = (int)current.Value;
				break;
			case "SelectedImageIndex":
				selected_image_index = (int)current.Value;
				break;
			case "Tag":
				tag = current.Value;
				break;
			case "IsChecked":
				check = (bool)current.Value;
				break;
			case "ChildCount":
				num = (int)current.Value;
				break;
			}
		}
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				TreeNode node = (TreeNode)serializationInfo.GetValue("children" + i, typeof(TreeNode));
				Nodes.Add(node);
			}
		}
	}

	public TreeNode()
	{
		nodes = new TreeNodeCollection(this);
	}

	public TreeNode(string text)
		: this()
	{
		Text = text;
	}

	public TreeNode(string text, TreeNode[] children)
		: this(text)
	{
		Nodes.AddRange(children);
	}

	public TreeNode(string text, int imageIndex, int selectedImageIndex)
		: this(text)
	{
		image_index = imageIndex;
		selected_image_index = selectedImageIndex;
	}

	public TreeNode(string text, int imageIndex, int selectedImageIndex, TreeNode[] children)
		: this(text, imageIndex, selectedImageIndex)
	{
		Nodes.AddRange(children);
	}

	public virtual object Clone()
	{
		TreeNode treeNode = (TreeNode)Activator.CreateInstance(GetType());
		treeNode.name = name;
		treeNode.text = text;
		treeNode.image_key = image_key;
		treeNode.image_index = image_index;
		treeNode.selected_image_index = selected_image_index;
		treeNode.selected_image_key = selected_image_key;
		treeNode.state_image_index = state_image_index;
		treeNode.state_image_key = state_image_key;
		treeNode.tag = tag;
		treeNode.check = check;
		treeNode.tool_tip_text = tool_tip_text;
		treeNode.context_menu = context_menu;
		treeNode.context_menu_strip = context_menu_strip;
		if (nodes != null)
		{
			foreach (TreeNode node in nodes)
			{
				treeNode.nodes.Add((TreeNode)node.Clone());
			}
		}
		if (prop_bag != null)
		{
			treeNode.prop_bag = OwnerDrawPropertyBag.Copy(prop_bag);
		}
		return treeNode;
	}

	void ISerializable.GetObjectData(SerializationInfo si, StreamingContext context)
	{
		si.AddValue("Text", Text);
		si.AddValue("prop_bag", prop_bag, typeof(OwnerDrawPropertyBag));
		si.AddValue("ImageIndex", ImageIndex);
		si.AddValue("SelectedImageIndex", SelectedImageIndex);
		si.AddValue("Tag", Tag);
		si.AddValue("Checked", Checked);
		si.AddValue("NumberOfChildren", Nodes.Count);
		for (int i = 0; i < Nodes.Count; i++)
		{
			si.AddValue("Child-" + i, Nodes[i], typeof(TreeNode));
		}
	}

	protected virtual void Deserialize(SerializationInfo serializationInfo, StreamingContext context)
	{
		Text = serializationInfo.GetString("Text");
		prop_bag = (OwnerDrawPropertyBag)serializationInfo.GetValue("prop_bag", typeof(OwnerDrawPropertyBag));
		ImageIndex = serializationInfo.GetInt32("ImageIndex");
		SelectedImageIndex = serializationInfo.GetInt32("SelectedImageIndex");
		Tag = serializationInfo.GetValue("Tag", typeof(object));
		Checked = serializationInfo.GetBoolean("Checked");
		int @int = serializationInfo.GetInt32("NumberOfChildren");
		for (int i = 0; i < @int; i++)
		{
			Nodes.Add((TreeNode)serializationInfo.GetValue("Child-" + i, typeof(TreeNode)));
		}
	}

	protected virtual void Serialize(SerializationInfo si, StreamingContext context)
	{
		si.AddValue("Text", Text);
		si.AddValue("prop_bag", prop_bag, typeof(OwnerDrawPropertyBag));
		si.AddValue("ImageIndex", ImageIndex);
		si.AddValue("SelectedImageIndex", SelectedImageIndex);
		si.AddValue("Tag", Tag);
		si.AddValue("Checked", Checked);
		si.AddValue("NumberOfChildren", Nodes.Count);
		for (int i = 0; i < Nodes.Count; i++)
		{
			si.AddValue("Child-" + i, Nodes[i], typeof(TreeNode));
		}
	}

	internal int GetY()
	{
		if (TreeView == null)
		{
			return 0;
		}
		return (visible_order - 1) * TreeView.ActualItemHeight - TreeView.skipped_nodes * TreeView.ActualItemHeight;
	}

	internal int GetX()
	{
		if (TreeView == null)
		{
			return 0;
		}
		int indentLevel = IndentLevel;
		int num = (TreeView.ShowRootLines ? 1 : 0);
		int num2 = (TreeView.CheckBoxes ? 19 : 0);
		if (!TreeView.CheckBoxes && StateImage != null)
		{
			num2 = 19;
		}
		int num3 = ((TreeView.ImageList != null) ? (TreeView.ImageList.ImageSize.Width + 3) : 0);
		return (indentLevel + num) * TreeView.Indent + num2 + num3 - TreeView.hbar_offset;
	}

	internal int GetLinesX()
	{
		int num = (TreeView.ShowRootLines ? 1 : 0);
		return (IndentLevel + num) * TreeView.Indent - TreeView.hbar_offset;
	}

	internal int GetImageX()
	{
		return GetLinesX() + ((TreeView.CheckBoxes || StateImage != null) ? 19 : 0);
	}

	public static TreeNode FromHandle(TreeView tree, IntPtr handle)
	{
		if (handle == IntPtr.Zero)
		{
			return null;
		}
		return tree.NodeFromHandle(handle);
	}

	public void BeginEdit()
	{
		TreeView?.BeginEdit(this);
	}

	public void Collapse()
	{
		CollapseInternal(byInternal: false);
	}

	public void Collapse(bool ignoreChildren)
	{
		if (ignoreChildren)
		{
			Collapse();
		}
		else
		{
			CollapseRecursive(this);
		}
	}

	public void EndEdit(bool cancel)
	{
		TreeView treeView = TreeView;
		if (!cancel && treeView != null)
		{
			treeView.EndEdit(this);
		}
		else if (cancel)
		{
			treeView?.CancelEdit(this);
		}
	}

	public void Expand()
	{
		Expand(byInternal: false);
	}

	public void ExpandAll()
	{
		ExpandRecursive(this);
		if (TreeView != null)
		{
			TreeView.UpdateNode(TreeView.root_node);
		}
	}

	public void EnsureVisible()
	{
		if (TreeView != null)
		{
			if (Parent != null)
			{
				ExpandParentRecursive(Parent);
			}
			Rectangle bounds = Bounds;
			if (bounds.Y < 0)
			{
				TreeView.SetTop(this);
			}
			else if (bounds.Bottom > TreeView.ViewportRectangle.Bottom)
			{
				TreeView.SetBottom(this);
			}
		}
	}

	public int GetNodeCount(bool includeSubTrees)
	{
		if (!includeSubTrees)
		{
			return Nodes.Count;
		}
		int count = 0;
		GetNodeCountRecursive(this, ref count);
		return count;
	}

	public void Remove()
	{
		if (parent != null)
		{
			int index = Index;
			parent.Nodes.RemoveAt(index);
		}
	}

	public void Toggle()
	{
		if (is_expanded)
		{
			Collapse();
		}
		else
		{
			Expand();
		}
	}

	public override string ToString()
	{
		return "TreeNode: " + Text;
	}

	private bool BuildFullPath(StringBuilder path)
	{
		if (parent == null)
		{
			return false;
		}
		if (parent.BuildFullPath(path))
		{
			path.Append(TreeView.PathSeparator);
		}
		path.Append(text);
		return true;
	}

	private void Expand(bool byInternal)
	{
		if (is_expanded || nodes.Count < 1)
		{
			is_expanded = true;
			return;
		}
		bool flag = false;
		TreeView treeView = TreeView;
		if (treeView != null)
		{
			TreeViewCancelEventArgs e = new TreeViewCancelEventArgs(this, cancel: false, TreeViewAction.Expand);
			treeView.OnBeforeExpand(e);
			flag = e.Cancel;
		}
		if (flag)
		{
			return;
		}
		is_expanded = true;
		int count_to_next = CountToNext();
		if (treeView != null)
		{
			treeView.OnAfterExpand(new TreeViewEventArgs(this));
			treeView.RecalculateVisibleOrder(this);
			treeView.UpdateScrollBars(force: false);
			if (visible_order < treeView.skipped_nodes + treeView.VisibleCount + 1 && ArePreviousNodesExpanded)
			{
				treeView.ExpandBelow(this, count_to_next);
			}
		}
	}

	private void CollapseInternal(bool byInternal)
	{
		if (!is_expanded || nodes.Count < 1 || IsRoot)
		{
			return;
		}
		bool flag = false;
		TreeView treeView = TreeView;
		if (treeView != null)
		{
			TreeViewCancelEventArgs e = new TreeViewCancelEventArgs(this, cancel: false, TreeViewAction.Collapse);
			treeView.OnBeforeCollapse(e);
			flag = e.Cancel;
		}
		if (flag)
		{
			return;
		}
		int count_to_next = CountToNext();
		is_expanded = false;
		if (treeView != null)
		{
			treeView.OnAfterCollapse(new TreeViewEventArgs(this));
			bool visible = treeView.hbar.Visible;
			bool visible2 = treeView.vbar.Visible;
			treeView.RecalculateVisibleOrder(this);
			treeView.UpdateScrollBars(force: false);
			if (visible_order < treeView.skipped_nodes + treeView.VisibleCount + 1 && ArePreviousNodesExpanded)
			{
				treeView.CollapseBelow(this, count_to_next);
			}
			if (!byInternal && HasFocusInChildren())
			{
				treeView.SelectedNode = this;
			}
			if ((visible & !treeView.hbar.Visible) || (visible2 & !treeView.vbar.Visible))
			{
				treeView.Invalidate();
			}
		}
	}

	private int CountToNext()
	{
		bool flag = is_expanded;
		is_expanded = false;
		OpenTreeNodeEnumerator openTreeNodeEnumerator = new OpenTreeNodeEnumerator(this);
		TreeNode treeNode = null;
		if (openTreeNodeEnumerator.MoveNext() && openTreeNodeEnumerator.MoveNext())
		{
			treeNode = openTreeNodeEnumerator.CurrentNode;
		}
		is_expanded = flag;
		openTreeNodeEnumerator.Reset();
		openTreeNodeEnumerator.MoveNext();
		int num = 0;
		while (openTreeNodeEnumerator.MoveNext() && openTreeNodeEnumerator.CurrentNode != treeNode)
		{
			num++;
		}
		return num;
	}

	private bool HasFocusInChildren()
	{
		if (TreeView == null)
		{
			return false;
		}
		foreach (TreeNode node in nodes)
		{
			if (node == TreeView.SelectedNode)
			{
				return true;
			}
			if (node.HasFocusInChildren())
			{
				return true;
			}
		}
		return false;
	}

	private void ExpandRecursive(TreeNode node)
	{
		node.Expand(byInternal: true);
		foreach (TreeNode node2 in node.Nodes)
		{
			ExpandRecursive(node2);
		}
	}

	private void ExpandParentRecursive(TreeNode node)
	{
		node.Expand(byInternal: true);
		if (node.Parent != null)
		{
			ExpandParentRecursive(node.Parent);
		}
	}

	internal void CollapseAll()
	{
		CollapseRecursive(this);
	}

	internal void CollapseAllUncheck()
	{
		CollapseUncheckRecursive(this);
	}

	private void CollapseRecursive(TreeNode node)
	{
		node.Collapse();
		foreach (TreeNode node2 in node.Nodes)
		{
			CollapseRecursive(node2);
		}
	}

	private void CollapseUncheckRecursive(TreeNode node)
	{
		node.Collapse();
		node.Checked = false;
		foreach (TreeNode node2 in node.Nodes)
		{
			CollapseUncheckRecursive(node2);
		}
	}

	internal void SetNodes(TreeNodeCollection nodes)
	{
		this.nodes = nodes;
	}

	private void GetNodeCountRecursive(TreeNode node, ref int count)
	{
		count += node.Nodes.Count;
		foreach (TreeNode node2 in node.Nodes)
		{
			GetNodeCountRecursive(node2, ref count);
		}
	}

	internal void Invalidate()
	{
		width = -1;
		TreeView?.UpdateNode(this);
	}

	internal void InvalidateWidth()
	{
		width = -1;
	}

	internal void SetWidth(int width)
	{
		this.width = width;
	}

	internal void SetParent(TreeNode parent)
	{
		this.parent = parent;
	}
}
