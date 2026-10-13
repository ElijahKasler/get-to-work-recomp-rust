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
public class CT_SaveGameStorage : INotifyPropertyChanged
{
	private CT_SaveGameStorageNoCodePCRoot noCodePCRootField;

	private string sCIDField;

	private string maxUserQuotaField;

	public CT_SaveGameStorageNoCodePCRoot NoCodePCRoot
	{
		get
		{
			return noCodePCRootField;
		}
		set
		{
			noCodePCRootField = value;
			RaisePropertyChanged("NoCodePCRoot");
		}
	}

	public string SCID
	{
		get
		{
			return sCIDField;
		}
		set
		{
			sCIDField = value;
			RaisePropertyChanged("SCID");
		}
	}

	[XmlElement(DataType = "integer")]
	public string MaxUserQuota
	{
		get
		{
			return maxUserQuotaField;
		}
		set
		{
			maxUserQuotaField = value;
			RaisePropertyChanged("MaxUserQuota");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
