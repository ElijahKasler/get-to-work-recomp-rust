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
public class CT_CustomInstallAction : INotifyPropertyChanged
{
	private string fileField;

	private string nameField;

	private string argumentsField;

	[XmlAttribute]
	public string File
	{
		get
		{
			return fileField;
		}
		set
		{
			fileField = value;
			RaisePropertyChanged("File");
		}
	}

	[XmlAttribute]
	public string Name
	{
		get
		{
			return nameField;
		}
		set
		{
			nameField = value;
			RaisePropertyChanged("Name");
		}
	}

	[XmlAttribute]
	public string Arguments
	{
		get
		{
			return argumentsField;
		}
		set
		{
			argumentsField = value;
			RaisePropertyChanged("Arguments");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
