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
public class CT_FileTypeAssociation : INotifyPropertyChanged
{
	private string displayNameField;

	private string logoField;

	private string infoTipField;

	private CT_FileTypeAssociationEditFlags editFlagsField;

	private CT_FTASupportedFileTypesFileType[] supportedFileTypesField;

	private string nameField;

	private string executableField;

	public string DisplayName
	{
		get
		{
			return displayNameField;
		}
		set
		{
			displayNameField = value;
			RaisePropertyChanged("DisplayName");
		}
	}

	public string Logo
	{
		get
		{
			return logoField;
		}
		set
		{
			logoField = value;
			RaisePropertyChanged("Logo");
		}
	}

	public string InfoTip
	{
		get
		{
			return infoTipField;
		}
		set
		{
			infoTipField = value;
			RaisePropertyChanged("InfoTip");
		}
	}

	public CT_FileTypeAssociationEditFlags EditFlags
	{
		get
		{
			return editFlagsField;
		}
		set
		{
			editFlagsField = value;
			RaisePropertyChanged("EditFlags");
		}
	}

	[XmlArrayItem("FileType", IsNullable = false)]
	public CT_FTASupportedFileTypesFileType[] SupportedFileTypes
	{
		get
		{
			return supportedFileTypesField;
		}
		set
		{
			supportedFileTypesField = value;
			RaisePropertyChanged("SupportedFileTypes");
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

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
