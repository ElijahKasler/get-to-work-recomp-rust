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
public class CT_RepairActionList : INotifyPropertyChanged
{
	private CT_CustomInstallAction[] repairActionField;

	[XmlElement("RepairAction")]
	public CT_CustomInstallAction[] RepairAction
	{
		get
		{
			return repairActionField;
		}
		set
		{
			repairActionField = value;
			RaisePropertyChanged("RepairAction");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
