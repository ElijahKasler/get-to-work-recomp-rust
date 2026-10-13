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
public class CT_PersistentLocalStorage : INotifyPropertyChanged
{
	private string sizeMBField;

	private string growableToMBField;

	private bool shareableField;

	private bool shareableFieldSpecified;

	[XmlElement(DataType = "integer")]
	public string SizeMB
	{
		get
		{
			return sizeMBField;
		}
		set
		{
			sizeMBField = value;
			RaisePropertyChanged("SizeMB");
		}
	}

	[XmlElement(DataType = "integer")]
	public string GrowableToMB
	{
		get
		{
			return growableToMBField;
		}
		set
		{
			growableToMBField = value;
			RaisePropertyChanged("GrowableToMB");
		}
	}

	public bool Shareable
	{
		get
		{
			return shareableField;
		}
		set
		{
			shareableField = value;
			RaisePropertyChanged("Shareable");
		}
	}

	[XmlIgnore]
	public bool ShareableSpecified
	{
		get
		{
			return shareableFieldSpecified;
		}
		set
		{
			shareableFieldSpecified = value;
			RaisePropertyChanged("ShareableSpecified");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
