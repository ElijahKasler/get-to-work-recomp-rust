using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace System.Windows.Forms;

public class KeysConverter : TypeConverter, IComparer
{
	private static Dictionary<string, Keys> key_names;

	static KeysConverter()
	{
		key_names = new Dictionary<string, Keys>(15);
		key_names.Add("Ctrl", Keys.Control);
		key_names.Add("Del", Keys.Delete);
		key_names.Add("Enter", Keys.Return);
		key_names.Add("PgDn", Keys.PageDown);
		key_names.Add("PgUp", Keys.PageUp);
		key_names.Add("0", Keys.D0);
		key_names.Add("1", Keys.D1);
		key_names.Add("2", Keys.D2);
		key_names.Add("3", Keys.D3);
		key_names.Add("4", Keys.D4);
		key_names.Add("5", Keys.D5);
		key_names.Add("6", Keys.D6);
		key_names.Add("7", Keys.D7);
		key_names.Add("8", Keys.D8);
		key_names.Add("9", Keys.D9);
	}

	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		if (sourceType == typeof(string))
		{
			return true;
		}
		return false;
	}

	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (destinationType == typeof(Enum[]))
		{
			return true;
		}
		return base.CanConvertTo(context, destinationType);
	}

	public int Compare(object a, object b)
	{
		if (a is string && b is string)
		{
			return string.Compare((string)a, (string)b);
		}
		return string.Compare(a.ToString(), b.ToString());
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value is string)
		{
			string[] array = ((string)value).Split(new char[1] { '+' });
			Keys keys = Keys.None;
			Keys value2;
			if (array.Length > 1)
			{
				for (int i = 0; i < array.Length - 1; i++)
				{
					keys = ((!key_names.TryGetValue(array[i], out value2)) ? (keys | (Keys)Enum.Parse(typeof(Keys), array[i], ignoreCase: true)) : (keys | value2));
				}
			}
			keys = ((!key_names.TryGetValue(array[^1], out value2)) ? (keys | (Keys)Enum.Parse(typeof(Keys), array[^1], ignoreCase: true)) : (keys | value2));
			return keys;
		}
		return base.ConvertFrom(context, culture, value);
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (destinationType == typeof(string))
		{
			StringBuilder stringBuilder = new StringBuilder();
			Keys keys = (Keys)value;
			if ((keys & Keys.Control) != Keys.None)
			{
				stringBuilder.Append("Ctrl+");
			}
			if ((keys & Keys.Alt) != Keys.None)
			{
				stringBuilder.Append("Alt+");
			}
			if ((keys & Keys.Shift) != Keys.None)
			{
				stringBuilder.Append("Shift+");
			}
			stringBuilder.Append(Enum.GetName(typeof(Keys), keys & Keys.KeyCode));
			return stringBuilder.ToString();
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
	{
		return new StandardValuesCollection(new Keys[33]
		{
			Keys.D0,
			Keys.D1,
			Keys.D2,
			Keys.D3,
			Keys.D4,
			Keys.D5,
			Keys.D6,
			Keys.D7,
			Keys.D8,
			Keys.D9,
			Keys.Alt,
			Keys.Back,
			Keys.Control,
			Keys.Delete,
			Keys.End,
			Keys.Return,
			Keys.F1,
			Keys.F10,
			Keys.F11,
			Keys.F12,
			Keys.F2,
			Keys.F3,
			Keys.F4,
			Keys.F5,
			Keys.F6,
			Keys.F7,
			Keys.F8,
			Keys.F9,
			Keys.Home,
			Keys.Insert,
			Keys.PageDown,
			Keys.PageUp,
			Keys.Shift
		});
	}

	public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
	{
		return false;
	}

	public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
	{
		return true;
	}
}
