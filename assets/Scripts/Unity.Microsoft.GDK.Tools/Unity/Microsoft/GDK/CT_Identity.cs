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
public class CT_Identity : INotifyPropertyChanged
{
	private string nameField;

	private string publisherField;

	private string resourceIdField;

	private string versionField;

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
	public string Publisher
	{
		get
		{
			return publisherField;
		}
		set
		{
			publisherField = value;
			RaisePropertyChanged("Publisher");
		}
	}

	[XmlAttribute]
	public string ResourceId
	{
		get
		{
			return resourceIdField;
		}
		set
		{
			resourceIdField = value;
			RaisePropertyChanged("ResourceId");
		}
	}

	[XmlAttribute]
	public string Version
	{
		get
		{
			return versionField;
		}
		set
		{
			versionField = value;
			RaisePropertyChanged("Version");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
