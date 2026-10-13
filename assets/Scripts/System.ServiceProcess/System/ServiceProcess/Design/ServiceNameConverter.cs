using System.ComponentModel;
using System.Globalization;

namespace System.ServiceProcess.Design;

internal class ServiceNameConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		if (sourceType == typeof(string))
		{
			return true;
		}
		return CanConvertFrom(sourceType);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value is string)
		{
			return (string)value;
		}
		return base.ConvertFrom(context, culture, value);
	}
}
