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
public class CT_InstallActionList : INotifyPropertyChanged
{
	private CT_CustomInstallAction[] installActionField;

	[XmlElement("InstallAction")]
	public CT_CustomInstallAction[] InstallAction
	{
		get
		{
			return installActionField;
		}
		set
		{
			installActionField = value;
			RaisePropertyChanged("InstallAction");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
