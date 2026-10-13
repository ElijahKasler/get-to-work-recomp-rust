using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Unity.Microsoft.GDK;

[Serializable]
[GeneratedCode("xsd", "4.8.3928.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class CT_DevelopmentOnly : INotifyPropertyChanged
{
	private string contentIdOverrideField;

	private string eKBIDOverrideField;

	private CT_DebugNetworkPortList debugNetworkPortListField;

	public string ContentIdOverride
	{
		get
		{
			return contentIdOverrideField;
		}
		set
		{
			contentIdOverrideField = value;
			RaisePropertyChanged("ContentIdOverride");
		}
	}

	public string EKBIDOverride
	{
		get
		{
			return eKBIDOverrideField;
		}
		set
		{
			eKBIDOverrideField = value;
			RaisePropertyChanged("EKBIDOverride");
		}
	}

	public CT_DebugNetworkPortList DebugNetworkPortList
	{
		get
		{
			return debugNetworkPortListField;
		}
		set
		{
			debugNetworkPortListField = value;
			RaisePropertyChanged("DebugNetworkPortList");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
