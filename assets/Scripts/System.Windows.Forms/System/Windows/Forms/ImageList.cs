using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Globalization;
using Unity;

namespace System.Windows.Forms;

[TypeConverter(typeof(ImageListConverter))]
[ToolboxItemFilter("System.Windows.Forms")]
[DesignerSerializer("System.Windows.Forms.Design.ImageListCodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[Designer("System.Windows.Forms.Design.ImageListDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[DefaultProperty("Images")]
public sealed class ImageList : Component
{
	[Editor("System.Windows.Forms.Design.ImageCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public sealed class ImageCollection : IList, ICollection, IEnumerable
	{
		private static class IndexedColorDepths
		{
			internal static readonly ColorPalette Palette4Bit;

			internal static readonly ColorPalette Palette8Bit;

			private static readonly int[] squares;

			static IndexedColorDepths()
			{
				Bitmap bitmap = new Bitmap(1, 1, PixelFormat.Format4bppIndexed);
				Palette4Bit = bitmap.Palette;
				bitmap.Dispose();
				Bitmap bitmap2 = new Bitmap(1, 1, PixelFormat.Format8bppIndexed);
				Palette8Bit = bitmap2.Palette;
				bitmap2.Dispose();
				squares = new int[511];
				for (int i = 0; i < 256; i++)
				{
					squares[255 + i] = (squares[255 - i] = i * i);
				}
			}

			internal static int GetNearestColor(Color[] palette, int color)
			{
				int num = palette.Length;
				for (int i = 0; i < num; i++)
				{
					if (palette[i].ToArgb() == color)
					{
						return color;
					}
				}
				int num2 = (color >>> 16) & 0xFF;
				int num3 = (color >>> 8) & 0xFF;
				int num4 = color & 0xFF;
				int result = -16777216;
				int num5 = int.MaxValue;
				for (int i = 0; i < num; i++)
				{
					int num6;
					if ((num6 = squares[255 + palette[i].R - num2] + squares[255 + palette[i].G - num3] + squares[255 + palette[i].B - num4]) < num5)
					{
						result = palette[i].ToArgb();
						num5 = num6;
					}
				}
				return result;
			}
		}

		[Flags]
		private enum ItemFlags
		{
			None = 0,
			UseTransparentColor = 1,
			ImageStrip = 2
		}

		private sealed class ImageListItem
		{
			internal readonly object Image;

			internal readonly ItemFlags Flags;

			internal readonly Color TransparentColor;

			internal readonly int ImageCount = 1;

			internal ImageListItem(Icon value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				Image = (Icon)value.Clone();
			}

			internal ImageListItem(Image value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (!(value is Bitmap))
				{
					throw new ArgumentException("Image must be a Bitmap.");
				}
				Image = value;
			}

			internal ImageListItem(Image value, Color transparentColor)
				: this(value)
			{
				Flags = ItemFlags.UseTransparentColor;
				TransparentColor = transparentColor;
			}

			internal ImageListItem(Image value, int imageCount)
				: this(value)
			{
				Flags = ItemFlags.ImageStrip;
				ImageCount = imageCount;
			}
		}

		private const int AlphaMask = -16777216;

		private ColorDepth colorDepth;

		private Size imageSize;

		private Color transparentColor;

		private ArrayList list;

		private ArrayList keys;

		private int count;

		private bool handleCreated;

		private int lastKeyIndex;

		private readonly ImageList owner;

		internal ColorDepth ColorDepth
		{
			get
			{
				return colorDepth;
			}
			set
			{
				if (!Enum.IsDefined(typeof(ColorDepth), value))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(ColorDepth));
				}
				if (colorDepth != value)
				{
					colorDepth = value;
					RecreateHandle();
				}
			}
		}

		internal IntPtr Handle
		{
			get
			{
				CreateHandle();
				return (IntPtr)(-1);
			}
		}

		internal bool HandleCreated => handleCreated;

		internal Size ImageSize
		{
			get
			{
				return imageSize;
			}
			set
			{
				if (value.Width < 1 || value.Width > 256 || value.Height < 1 || value.Height > 256)
				{
					throw new ArgumentException("ImageSize.Width and Height must be between 1 and 256", "value");
				}
				if (imageSize != value)
				{
					imageSize = value;
					RecreateHandle();
				}
			}
		}

		internal ImageListStreamer ImageStream
		{
			get
			{
				if (!Empty)
				{
					return new ImageListStreamer(this);
				}
				return null;
			}
			set
			{
				Image[] images;
				if (value == null)
				{
					if (handleCreated)
					{
						DestroyHandle();
					}
					else
					{
						Clear();
					}
				}
				else if ((images = value.Images) != null)
				{
					list = new ArrayList(images.Length);
					count = 0;
					handleCreated = true;
					keys = new ArrayList(images.Length);
					for (int i = 0; i < images.Length; i++)
					{
						list.Add((Image)images[i].Clone());
						keys.Add(null);
					}
					if (Enum.IsDefined(typeof(ColorDepth), value.ColorDepth))
					{
						colorDepth = value.ColorDepth;
					}
					imageSize = value.ImageSize;
					owner.OnRecreateHandle();
				}
			}
		}

		internal Color TransparentColor
		{
			get
			{
				return transparentColor;
			}
			set
			{
				transparentColor = value;
			}
		}

		[Browsable(false)]
		public int Count
		{
			get
			{
				if (!handleCreated)
				{
					return count;
				}
				return list.Count;
			}
		}

		public bool Empty => Count == 0;

		public bool IsReadOnly => false;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Image this[int index]
		{
			get
			{
				return (Image)GetImage(index).Clone();
			}
			set
			{
				if (index < 0 || index >= Count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (!(value is Bitmap))
				{
					throw new ArgumentException("Image must be a Bitmap.");
				}
				Image value2 = CreateImage(value, transparentColor);
				CreateHandle();
				list[index] = value2;
			}
		}

		public Image this[string key]
		{
			get
			{
				int index;
				if ((index = IndexOfKey(key)) != -1)
				{
					return this[index];
				}
				return null;
			}
		}

		public StringCollection Keys
		{
			get
			{
				StringCollection stringCollection = new StringCollection();
				for (int i = 0; i < keys.Count; i++)
				{
					string text;
					stringCollection.Add(((text = (string)keys[i]) == null || text.Length == 0) ? string.Empty : text);
				}
				return stringCollection;
			}
		}

		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				if (!(value is Image))
				{
					throw new ArgumentException("value");
				}
				this[index] = (Image)value;
			}
		}

		bool IList.IsFixedSize => false;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		internal event EventHandler Changed;

		internal ImageCollection(ImageList owner)
		{
			colorDepth = ColorDepth.Depth8Bit;
			imageSize = DefaultImageSize;
			transparentColor = DefaultTransparentColor;
			list = new ArrayList();
			keys = new ArrayList();
			lastKeyIndex = -1;
			base._002Ector();
			this.owner = owner;
		}

		private static bool CompareKeys(string key1, string key2)
		{
			if (key1 == null || key2 == null || key1.Length != key2.Length)
			{
				return false;
			}
			return string.Compare(key1, key2, ignoreCase: true, CultureInfo.InvariantCulture) == 0;
		}

		private int AddItem(string key, ImageListItem item)
		{
			int result;
			if (handleCreated)
			{
				result = AddItemInternal(item);
			}
			else
			{
				result = list.Add(item);
				count += item.ImageCount;
			}
			if ((item.Flags & ItemFlags.ImageStrip) == 0)
			{
				keys.Add(key);
			}
			else
			{
				for (int i = 0; i < item.ImageCount; i++)
				{
					keys.Add(null);
				}
			}
			return result;
		}

		private int AddItemInternal(ImageListItem item)
		{
			if (Changed != null)
			{
				Changed(this, EventArgs.Empty);
			}
			if (item.Image is Icon)
			{
				int width;
				int height;
				Bitmap bitmap = new Bitmap(width = imageSize.Width, height = imageSize.Height, PixelFormat.Format32bppArgb);
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.DrawIcon((Icon)item.Image, new Rectangle(0, 0, width, height));
				graphics.Dispose();
				ReduceColorDepth(bitmap);
				return list.Add(bitmap);
			}
			if ((item.Flags & ItemFlags.ImageStrip) == 0)
			{
				return list.Add(CreateImage((Image)item.Image, ((item.Flags & ItemFlags.UseTransparentColor) == 0) ? transparentColor : item.TransparentColor));
			}
			int width2;
			Image image;
			int width3;
			if ((width2 = (image = (Image)item.Image).Width) == 0 || width2 % (width3 = imageSize.Width) != 0)
			{
				throw new ArgumentException("Width of image strip must be a positive multiple of ImageSize.Width.", "value");
			}
			int height2;
			if (image.Height != (height2 = imageSize.Height))
			{
				throw new ArgumentException("Height of image strip must be equal to ImageSize.Height.", "value");
			}
			Rectangle destRect = new Rectangle(0, 0, width3, height2);
			ImageAttributes imageAttributes;
			if (transparentColor.A == 0)
			{
				imageAttributes = null;
			}
			else
			{
				imageAttributes = new ImageAttributes();
				imageAttributes.SetColorKey(transparentColor, transparentColor);
			}
			int result = list.Count;
			for (int i = 0; i < width2; i += width3)
			{
				Bitmap bitmap2 = new Bitmap(width3, height2, PixelFormat.Format32bppArgb);
				Graphics graphics2 = Graphics.FromImage(bitmap2);
				graphics2.DrawImage(image, destRect, i, 0, width3, height2, GraphicsUnit.Pixel, imageAttributes);
				graphics2.Dispose();
				ReduceColorDepth(bitmap2);
				list.Add(bitmap2);
			}
			imageAttributes?.Dispose();
			return result;
		}

		private void CreateHandle()
		{
			if (!handleCreated)
			{
				ArrayList arrayList = list;
				list = new ArrayList(count);
				count = 0;
				handleCreated = true;
				for (int i = 0; i < arrayList.Count; i++)
				{
					AddItemInternal((ImageListItem)arrayList[i]);
				}
			}
		}

		private Image CreateImage(Image value, Color transparentColor)
		{
			ImageAttributes imageAttributes;
			if (transparentColor.A == 0)
			{
				imageAttributes = null;
			}
			else
			{
				imageAttributes = new ImageAttributes();
				imageAttributes.SetColorKey(transparentColor, transparentColor);
			}
			int width;
			int height;
			Bitmap bitmap = new Bitmap(width = imageSize.Width, height = imageSize.Height, PixelFormat.Format32bppArgb);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.DrawImage(value, new Rectangle(0, 0, width, height), 0, 0, value.Width, value.Height, GraphicsUnit.Pixel, imageAttributes);
			}
			imageAttributes?.Dispose();
			ReduceColorDepth(bitmap);
			return bitmap;
		}

		private void RecreateHandle()
		{
			if (handleCreated)
			{
				DestroyHandle();
				handleCreated = true;
				owner.OnRecreateHandle();
			}
		}

		private unsafe void ReduceColorDepth(Bitmap bitmap)
		{
			if (colorDepth >= ColorDepth.Depth32Bit)
			{
				return;
			}
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
			try
			{
				byte* ptr = (byte*)(void*)bitmapData.Scan0;
				int height = bitmapData.Height;
				int num = bitmapData.Width << 2;
				int stride = bitmapData.Stride;
				if (colorDepth < ColorDepth.Depth16Bit)
				{
					Color[] entries = ((colorDepth < ColorDepth.Depth8Bit) ? IndexedColorDepths.Palette4Bit : IndexedColorDepths.Palette8Bit).Entries;
					for (int i = 0; i < height; i++)
					{
						byte* ptr2 = ptr + num;
						for (byte* ptr3 = ptr; ptr3 < ptr2; ptr3 += 4)
						{
							int num2;
							*(int*)ptr3 = ((((num2 = *(int*)ptr3) & -16777216) != 0) ? IndexedColorDepths.GetNearestColor(entries, num2 | -16777216) : 0);
						}
						ptr += stride;
					}
					return;
				}
				if (colorDepth < ColorDepth.Depth24Bit)
				{
					for (int i = 0; i < height; i++)
					{
						byte* ptr2 = ptr + num;
						for (byte* ptr3 = ptr; ptr3 < ptr2; ptr3 += 4)
						{
							int num2;
							*(int*)ptr3 = ((((num2 = *(int*)ptr3) & -16777216) != 0) ? ((num2 & 0xF8F8F8) | -16777216) : 0);
						}
						ptr += stride;
					}
					return;
				}
				for (int i = 0; i < height; i++)
				{
					byte* ptr2 = ptr + num;
					for (byte* ptr3 = ptr; ptr3 < ptr2; ptr3 += 4)
					{
						int num2;
						*(int*)ptr3 = ((((num2 = *(int*)ptr3) & -16777216) != 0) ? (num2 | -16777216) : 0);
					}
					ptr += stride;
				}
			}
			finally
			{
				bitmap.UnlockBits(bitmapData);
			}
		}

		internal void DestroyHandle()
		{
			if (handleCreated)
			{
				list = new ArrayList();
				count = 0;
				handleCreated = false;
				keys = new ArrayList();
			}
		}

		internal Image GetImage(int index)
		{
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			CreateHandle();
			return (Image)list[index];
		}

		internal Image[] ToArray()
		{
			CreateHandle();
			Image[] array = new Image[list.Count];
			list.CopyTo(array);
			return array;
		}

		public void Add(Icon value)
		{
			Add(null, value);
		}

		public void Add(Image value)
		{
			Add(null, value);
		}

		public int Add(Image value, Color transparentColor)
		{
			return AddItem(null, new ImageListItem(value, transparentColor));
		}

		public void Add(string key, Icon icon)
		{
			AddItem(key, new ImageListItem(icon));
		}

		public void Add(string key, Image image)
		{
			AddItem(key, new ImageListItem(image));
		}

		public void AddRange(Image[] images)
		{
			if (images == null)
			{
				throw new ArgumentNullException("images");
			}
			for (int i = 0; i < images.Length; i++)
			{
				Add(images[i]);
			}
		}

		public int AddStrip(Image value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			int width;
			int width2;
			if ((width = value.Width) == 0 || width % (width2 = imageSize.Width) != 0)
			{
				throw new ArgumentException("Width of image strip must be a positive multiple of ImageSize.Width.", "value");
			}
			if (value.Height != imageSize.Height)
			{
				throw new ArgumentException("Height of image strip must be equal to ImageSize.Height.", "value");
			}
			return AddItem(null, new ImageListItem(value, width / width2));
		}

		public void Clear()
		{
			list.Clear();
			if (!handleCreated)
			{
				count = 0;
			}
			keys.Clear();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Contains(Image image)
		{
			throw new NotSupportedException();
		}

		public bool ContainsKey(string key)
		{
			return IndexOfKey(key) != -1;
		}

		public IEnumerator GetEnumerator()
		{
			Image[] array = new Image[Count];
			if (array.Length != 0)
			{
				CreateHandle();
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = (Image)((Image)list[i]).Clone();
				}
			}
			return array.GetEnumerator();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int IndexOf(Image image)
		{
			throw new NotSupportedException();
		}

		public int IndexOfKey(string key)
		{
			if (key != null && key.Length != 0)
			{
				if (lastKeyIndex >= 0 && lastKeyIndex < Count && CompareKeys((string)keys[lastKeyIndex], key))
				{
					return lastKeyIndex;
				}
				for (int i = 0; i < Count; i++)
				{
					if (CompareKeys((string)keys[i], key))
					{
						return lastKeyIndex = i;
					}
				}
			}
			return lastKeyIndex = -1;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Remove(Image image)
		{
			throw new NotSupportedException();
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			CreateHandle();
			list.RemoveAt(index);
			keys.RemoveAt(index);
			if (Changed != null)
			{
				Changed(this, EventArgs.Empty);
			}
		}

		public void RemoveByKey(string key)
		{
			int index;
			if ((index = IndexOfKey(key)) != -1)
			{
				RemoveAt(index);
			}
		}

		public void SetKeyName(int index, string name)
		{
			if (index < 0 || index >= Count)
			{
				throw new IndexOutOfRangeException();
			}
			keys[index] = name;
		}

		int IList.Add(object value)
		{
			if (!(value is Image))
			{
				throw new ArgumentException("value");
			}
			int result = Count;
			Add((Image)value);
			return result;
		}

		bool IList.Contains(object image)
		{
			if (!(image is Image))
			{
				return false;
			}
			return Contains((Image)image);
		}

		int IList.IndexOf(object image)
		{
			if (!(image is Image))
			{
				return -1;
			}
			return IndexOf((Image)image);
		}

		void IList.Insert(int index, object value)
		{
			throw new NotSupportedException();
		}

		void IList.Remove(object image)
		{
			if (image is Image)
			{
				Remove((Image)image);
			}
		}

		void ICollection.CopyTo(Array dest, int index)
		{
			for (int i = 0; i < Count; i++)
			{
				dest.SetValue(this[i], index++);
			}
		}

		internal ImageCollection()
		{
			Unity.ThrowStub.ThrowNotSupportedException();
		}
	}

	private const ColorDepth DefaultColorDepth = ColorDepth.Depth8Bit;

	private static readonly Size DefaultImageSize = new Size(16, 16);

	private static readonly Color DefaultTransparentColor = Color.Transparent;

	private object tag;

	private readonly ImageCollection images;

	private static object RecreateHandleEvent = new object();

	public ColorDepth ColorDepth
	{
		get
		{
			return images.ColorDepth;
		}
		set
		{
			images.ColorDepth = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	public IntPtr Handle => images.Handle;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool HandleCreated => images.HandleCreated;

	[MergableProperty(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DefaultValue(null)]
	public ImageCollection Images => images;

	[Localizable(true)]
	public Size ImageSize
	{
		get
		{
			return images.ImageSize;
		}
		set
		{
			images.ImageSize = value;
		}
	}

	[DefaultValue(null)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	public ImageListStreamer ImageStream
	{
		get
		{
			return images.ImageStream;
		}
		set
		{
			images.ImageStream = value;
		}
	}

	[Bindable(true)]
	[DefaultValue(null)]
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

	public Color TransparentColor
	{
		get
		{
			return images.TransparentColor;
		}
		set
		{
			images.TransparentColor = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	public event EventHandler RecreateHandle
	{
		add
		{
			base.Events.AddHandler(RecreateHandleEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(RecreateHandleEvent, value);
		}
	}

	public ImageList()
	{
		images = new ImageCollection(this);
	}

	public ImageList(IContainer container)
		: this()
	{
		container.Add(this);
	}

	private void OnRecreateHandle()
	{
		((EventHandler)base.Events[RecreateHandleEvent])?.Invoke(this, EventArgs.Empty);
	}

	internal bool ShouldSerializeTransparentColor()
	{
		return TransparentColor != Color.LightGray;
	}

	internal bool ShouldSerializeColorDepth()
	{
		return images.Empty;
	}

	internal bool ShouldSerializeImageSize()
	{
		return images.Empty;
	}

	internal void ResetColorDepth()
	{
		ColorDepth = ColorDepth.Depth8Bit;
	}

	internal void ResetImageSize()
	{
		ImageSize = DefaultImageSize;
	}

	internal void ResetTransparentColor()
	{
		TransparentColor = Color.LightGray;
	}

	public void Draw(Graphics g, Point pt, int index)
	{
		Draw(g, pt.X, pt.Y, index);
	}

	public void Draw(Graphics g, int x, int y, int index)
	{
		g.DrawImage(images.GetImage(index), x, y);
	}

	public void Draw(Graphics g, int x, int y, int width, int height, int index)
	{
		g.DrawImage(images.GetImage(index), x, y, width, height);
	}

	public override string ToString()
	{
		return base.ToString() + " Images.Count: " + images.Count + ", ImageSize: " + ImageSize.ToString();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			images.DestroyHandle();
		}
		base.Dispose(disposing);
	}
}
