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
public class CT_UninstallActionList : INotifyPropertyChanged
{
	private CT_CustomInstallAction[] uninstallActionField;

	[XmlElement("UninstallAction")]
	public CT_CustomInstallAction[] UninstallAction
	{
		get
		{
			return uninstallActionField;
		}
		set
		{
			uninstallActionField = value;
			RaisePropertyChanged("UninstallAction");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
