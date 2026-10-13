using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Unity.Microsoft.GDK;

[Serializable]
[GeneratedCode("xsd", "4.8.3928.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class CT_ExtendedAttributeList : INotifyPropertyChanged
{
	private CT_ExtendedAttributeListExtendedAttribute[] extendedAttributeField;

	[XmlElement("ExtendedAttribute")]
	public CT_ExtendedAttributeListExtendedAttribute[] ExtendedAttribute
	{
		get
		{
			return extendedAttributeField;
		}
		set
		{
			extendedAttributeField = value;
			RaisePropertyChanged("ExtendedAttribute");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
