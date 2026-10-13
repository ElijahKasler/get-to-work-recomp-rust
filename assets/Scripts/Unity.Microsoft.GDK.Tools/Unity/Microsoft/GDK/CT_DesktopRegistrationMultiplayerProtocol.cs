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
[XmlType(AnonymousType = true)]
public class CT_DesktopRegistrationMultiplayerProtocol : INotifyPropertyChanged
{
	private string executableField;

	private bool valueField;

	[XmlAttribute]
	public string Executable
	{
		get
		{
			return executableField;
		}
		set
		{
			executableField = value;
			RaisePropertyChanged("Executable");
		}
	}

	[XmlText]
	public bool Value
	{
		get
		{
			return valueField;
		}
		set
		{
			valueField = value;
			RaisePropertyChanged("Value");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
