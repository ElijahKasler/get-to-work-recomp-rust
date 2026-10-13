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
public class CT_ProtocolList : INotifyPropertyChanged
{
	private CT_Protocol[] protocolField;

	[XmlElement("Protocol")]
	public CT_Protocol[] Protocol
	{
		get
		{
			return protocolField;
		}
		set
		{
			protocolField = value;
			RaisePropertyChanged("Protocol");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
