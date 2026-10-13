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
public class CT_FileTypeAssociationEditFlags : INotifyPropertyChanged
{
	private bool openIsSafeField;

	private bool openIsSafeFieldSpecified;

	private bool alwaysUnsafeField;

	private bool alwaysUnsafeFieldSpecified;

	[XmlAttribute]
	public bool OpenIsSafe
	{
		get
		{
			return openIsSafeField;
		}
		set
		{
			openIsSafeField = value;
			RaisePropertyChanged("OpenIsSafe");
		}
	}

	[XmlIgnore]
	public bool OpenIsSafeSpecified
	{
		get
		{
			return openIsSafeFieldSpecified;
		}
		set
		{
			openIsSafeFieldSpecified = value;
			RaisePropertyChanged("OpenIsSafeSpecified");
		}
	}

	[XmlAttribute]
	public bool AlwaysUnsafe
	{
		get
		{
			return alwaysUnsafeField;
		}
		set
		{
			alwaysUnsafeField = value;
			RaisePropertyChanged("AlwaysUnsafe");
		}
	}

	[XmlIgnore]
	public bool AlwaysUnsafeSpecified
	{
		get
		{
			return alwaysUnsafeFieldSpecified;
		}
		set
		{
			alwaysUnsafeFieldSpecified = value;
			RaisePropertyChanged("AlwaysUnsafeSpecified");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
