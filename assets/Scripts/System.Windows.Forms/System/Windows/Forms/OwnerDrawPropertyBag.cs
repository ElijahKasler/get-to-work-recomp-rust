using System.Drawing;
using System.Runtime.Serialization;

namespace System.Windows.Forms;

[Serializable]
public class OwnerDrawPropertyBag : MarshalByRefObject, ISerializable
{
	private Color fore_color;

	private Color back_color;

	private Font font;

	public Color ForeColor
	{
		get
		{
			return fore_color;
		}
		set
		{
			fore_color = value;
		}
	}

	public Color BackColor
	{
		get
		{
			return back_color;
		}
		set
		{
			back_color = value;
		}
	}

	public Font Font
	{
		get
		{
			return font;
		}
		set
		{
			font = value;
		}
	}

	internal OwnerDrawPropertyBag()
	{
		fore_color = (back_color = Color.Empty);
	}

	private OwnerDrawPropertyBag(Color fore_color, Color back_color, Font font)
	{
		this.fore_color = fore_color;
		this.back_color = back_color;
		this.font = font;
	}

	protected OwnerDrawPropertyBag(SerializationInfo info, StreamingContext context)
	{
		foreach (SerializationEntry item in info)
		{
			switch (item.Name)
			{
			case "Font":
				font = (Font)item.Value;
				break;
			case "ForeColor":
				fore_color = (Color)item.Value;
				break;
			case "BackColor":
				back_color = (Color)item.Value;
				break;
			}
		}
	}

	public virtual bool IsEmpty()
	{
		if (font == null && fore_color.IsEmpty)
		{
			return back_color.IsEmpty;
		}
		return false;
	}

	void ISerializable.GetObjectData(SerializationInfo si, StreamingContext context)
	{
		si.AddValue("BackColor", BackColor);
		si.AddValue("ForeColor", ForeColor);
		si.AddValue("Font", Font);
	}

	public static OwnerDrawPropertyBag Copy(OwnerDrawPropertyBag value)
	{
		return new OwnerDrawPropertyBag(value.ForeColor, value.BackColor, value.Font);
	}
}
