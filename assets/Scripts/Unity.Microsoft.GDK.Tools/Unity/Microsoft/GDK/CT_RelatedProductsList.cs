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
public class CT_RelatedProductsList : INotifyPropertyChanged
{
	private string[] relatedProductField;

	[XmlElement("RelatedProduct")]
	public string[] RelatedProduct
	{
		get
		{
			return relatedProductField;
		}
		set
		{
			relatedProductField = value;
			RaisePropertyChanged("RelatedProduct");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
