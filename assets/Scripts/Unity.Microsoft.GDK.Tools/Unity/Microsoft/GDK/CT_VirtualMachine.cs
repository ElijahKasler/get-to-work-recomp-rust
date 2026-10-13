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
public class CT_VirtualMachine : INotifyPropertyChanged
{
	private ST_MemoryConfig xboxOneXTitleMemoryField;

	private bool xboxOneXTitleMemoryFieldSpecified;

	private ST_MemoryConfig xboxAnacondaTitleMemoryField;

	private bool xboxAnacondaTitleMemoryFieldSpecified;

	private bool sMTEnabledField;

	private bool sMTEnabledFieldSpecified;

	private bool requiresEraShimField;

	private bool requiresEraShimFieldSpecified;

	private ST_ConsoleGeneration xboxCompatibilityField;

	private bool xboxCompatibilityFieldSpecified;

	private ST_ConsoleGeneration dlcCompatibilityField;

	private bool dlcCompatibilityFieldSpecified;

	private ST_MemoryConfig xboxLockhartTitleMemoryField;

	private bool xboxLockhartTitleMemoryFieldSpecified;

	public ST_MemoryConfig XboxOneXTitleMemory
	{
		get
		{
			return xboxOneXTitleMemoryField;
		}
		set
		{
			xboxOneXTitleMemoryField = value;
			RaisePropertyChanged("XboxOneXTitleMemory");
		}
	}

	[XmlIgnore]
	public bool XboxOneXTitleMemorySpecified
	{
		get
		{
			return xboxOneXTitleMemoryFieldSpecified;
		}
		set
		{
			xboxOneXTitleMemoryFieldSpecified = value;
			RaisePropertyChanged("XboxOneXTitleMemorySpecified");
		}
	}

	public ST_MemoryConfig XboxAnacondaTitleMemory
	{
		get
		{
			return xboxAnacondaTitleMemoryField;
		}
		set
		{
			xboxAnacondaTitleMemoryField = value;
			RaisePropertyChanged("XboxAnacondaTitleMemory");
		}
	}

	[XmlIgnore]
	public bool XboxAnacondaTitleMemorySpecified
	{
		get
		{
			return xboxAnacondaTitleMemoryFieldSpecified;
		}
		set
		{
			xboxAnacondaTitleMemoryFieldSpecified = value;
			RaisePropertyChanged("XboxAnacondaTitleMemorySpecified");
		}
	}

	public bool SMTEnabled
	{
		get
		{
			return sMTEnabledField;
		}
		set
		{
			sMTEnabledField = value;
			RaisePropertyChanged("SMTEnabled");
		}
	}

	[XmlIgnore]
	public bool SMTEnabledSpecified
	{
		get
		{
			return sMTEnabledFieldSpecified;
		}
		set
		{
			sMTEnabledFieldSpecified = value;
			RaisePropertyChanged("SMTEnabledSpecified");
		}
	}

	public bool RequiresEraShim
	{
		get
		{
			return requiresEraShimField;
		}
		set
		{
			requiresEraShimField = value;
			RaisePropertyChanged("RequiresEraShim");
		}
	}

	[XmlIgnore]
	public bool RequiresEraShimSpecified
	{
		get
		{
			return requiresEraShimFieldSpecified;
		}
		set
		{
			requiresEraShimFieldSpecified = value;
			RaisePropertyChanged("RequiresEraShimSpecified");
		}
	}

	public ST_ConsoleGeneration XboxCompatibility
	{
		get
		{
			return xboxCompatibilityField;
		}
		set
		{
			xboxCompatibilityField = value;
			RaisePropertyChanged("XboxCompatibility");
		}
	}

	[XmlIgnore]
	public bool XboxCompatibilitySpecified
	{
		get
		{
			return xboxCompatibilityFieldSpecified;
		}
		set
		{
			xboxCompatibilityFieldSpecified = value;
			RaisePropertyChanged("XboxCompatibilitySpecified");
		}
	}

	public ST_ConsoleGeneration DlcCompatibility
	{
		get
		{
			return dlcCompatibilityField;
		}
		set
		{
			dlcCompatibilityField = value;
			RaisePropertyChanged("DlcCompatibility");
		}
	}

	[XmlIgnore]
	public bool DlcCompatibilitySpecified
	{
		get
		{
			return dlcCompatibilityFieldSpecified;
		}
		set
		{
			dlcCompatibilityFieldSpecified = value;
			RaisePropertyChanged("DlcCompatibilitySpecified");
		}
	}

	public ST_MemoryConfig XboxLockhartTitleMemory
	{
		get
		{
			return xboxLockhartTitleMemoryField;
		}
		set
		{
			xboxLockhartTitleMemoryField = value;
			RaisePropertyChanged("XboxLockhartTitleMemory");
		}
	}

	[XmlIgnore]
	public bool XboxLockhartTitleMemorySpecified
	{
		get
		{
			return xboxLockhartTitleMemoryFieldSpecified;
		}
		set
		{
			xboxLockhartTitleMemoryFieldSpecified = value;
			RaisePropertyChanged("XboxLockhartTitleMemorySpecified");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
