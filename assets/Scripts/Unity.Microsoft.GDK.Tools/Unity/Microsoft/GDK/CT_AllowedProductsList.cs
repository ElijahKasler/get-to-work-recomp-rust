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
public class CT_AllowedProductsList : INotifyPropertyChanged
{
	private string[] allowedProductField;

	[XmlElement("AllowedProduct")]
	public string[] AllowedProduct
	{
		get
		{
			return allowedProductField;
		}
		set
		{
			allowedProductField = value;
			RaisePropertyChanged("AllowedProduct");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
