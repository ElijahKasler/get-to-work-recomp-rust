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
public class CT_ExecutableList : INotifyPropertyChanged
{
	private CT_ExecutableListExecutable[] executableField;

	[XmlElement("Executable")]
	public CT_ExecutableListExecutable[] Executable
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
