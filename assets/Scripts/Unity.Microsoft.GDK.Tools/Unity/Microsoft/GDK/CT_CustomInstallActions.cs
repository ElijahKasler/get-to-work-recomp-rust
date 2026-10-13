using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Unity.Microsoft.GDK;

[Serializable]
[GeneratedCode("xsd", "4.8.3928.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class CT_CustomInstallActions : INotifyPropertyChanged
{
	private string folderField;

	private CT_InstallActionList installActionListField;

	private CT_RepairActionList repairActionListField;

	private CT_UninstallActionList uninstallActionListField;

	public string Folder
	{
		get
		{
			return folderField;
		}
		set
		{
			folderField = value;
			RaisePropertyChanged("Folder");
		}
	}

	public CT_InstallActionList InstallActionList
	{
		get
		{
			return installActionListField;
		}
		set
		{
			installActionListField = value;
			RaisePropertyChanged("InstallActionList");
		}
	}

	public CT_RepairActionList RepairActionList
	{
		get
		{
			return repairActionListField;
		}
		set
		{
			repairActionListField = value;
			RaisePropertyChanged("RepairActionList");
		}
	}

	public CT_UninstallActionList UninstallActionList
	{
		get
		{
			return uninstallActionListField;
		}
		set
		{
			uninstallActionListField = value;
			RaisePropertyChanged("UninstallActionList");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
