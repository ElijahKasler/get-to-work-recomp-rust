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
public class CT_DebugNetworkPortList : INotifyPropertyChanged
{
	private string[] debugNetworkPortField;

	[XmlElement("DebugNetworkPort")]
	public string[] DebugNetworkPort
	{
		get
		{
			return debugNetworkPortField;
		}
		set
		{
			debugNetworkPortField = value;
			RaisePropertyChanged("DebugNetworkPort");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
