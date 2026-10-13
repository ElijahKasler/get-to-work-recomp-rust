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
public class CT_SaveGameStorageNoCodePCRoot : INotifyPropertyChanged
{
	private ST_GameSaveNoCodePcRootRelativeLocation relativeToField;

	private string valueField;

	[XmlAttribute]
	public ST_GameSaveNoCodePcRootRelativeLocation RelativeTo
	{
		get
		{
			return relativeToField;
		}
		set
		{
			relativeToField = value;
			RaisePropertyChanged("RelativeTo");
		}
	}

	[XmlText]
	public string Value
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
