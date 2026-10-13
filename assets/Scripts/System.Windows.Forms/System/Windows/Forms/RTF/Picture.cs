using System.Drawing;
using System.IO;

namespace System.Windows.Forms.RTF;

internal class Picture
{
	private Minor image_type;

	private Image image;

	private MemoryStream data;

	private float width = -1f;

	private float height = -1f;

	private static readonly float dpix;

	public Minor ImageType
	{
		get
		{
			return image_type;
		}
		set
		{
			image_type = value;
		}
	}

	public MemoryStream Data
	{
		get
		{
			if (data == null)
			{
				data = new MemoryStream();
			}
			return data;
		}
	}

	public float Width
	{
		get
		{
			float num = width;
			if (num < 0f)
			{
				if (image == null)
				{
					image = ToImage();
				}
				num = image.Width;
			}
			return num;
		}
	}

	public float Height
	{
		get
		{
			float num = height;
			if (num < 0f)
			{
				if (image == null)
				{
					image = ToImage();
				}
				num = image.Height;
			}
			return num;
		}
	}

	public SizeF Size => new SizeF(Width, Height);

	static Picture()
	{
		dpix = TextRenderer.GetDpi().Width;
	}

	public void SetWidthFromTwips(int twips)
	{
		width = (int)((float)twips / 1440f * dpix + 0.5f);
	}

	public void SetHeightFromTwips(int twips)
	{
		height = (int)((float)twips / 1440f * dpix + 0.5f);
	}

	public bool IsValid()
	{
		if (data == null)
		{
			return false;
		}
		Minor minor = image_type;
		if ((uint)(minor - 466) > 1u && (uint)(minor - 470) > 1u)
		{
			return false;
		}
		return true;
	}

	public void DrawImage(Graphics dc, float x, float y, bool selected)
	{
		if (image == null)
		{
			image = ToImage();
		}
		dc.DrawImage(image, x, y, Width, Height);
	}

	public Image ToImage()
	{
		data.Position = 0L;
		return Image.FromStream(data);
	}
}
