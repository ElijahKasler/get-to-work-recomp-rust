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
public class CT_DependencyList : INotifyPropertyChanged
{
	private CT_DependencyListKnownDependency[] knownDependencyField;

	private CT_DependencyListDependency[] dependencyField;

	[XmlElement("KnownDependency")]
	public CT_DependencyListKnownDependency[] KnownDependency
	{
		get
		{
			return knownDependencyField;
		}
		set
		{
			knownDependencyField = value;
			RaisePropertyChanged("KnownDependency");
		}
	}

	[XmlElement("Dependency")]
	public CT_DependencyListDependency[] Dependency
	{
		get
		{
			return dependencyField;
		}
		set
		{
			dependencyField = value;
			RaisePropertyChanged("Dependency");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
