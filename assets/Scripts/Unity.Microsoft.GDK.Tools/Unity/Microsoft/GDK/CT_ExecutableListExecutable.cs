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
public class CT_ExecutableListExecutable : INotifyPropertyChanged
{
	private string nameField;

	private ST_DeviceFamily targetDeviceFamilyField;

	private bool targetDeviceFamilyFieldSpecified;

	private string idField;

	private bool isDevOnlyField;

	private bool isDevOnlyFieldSpecified;

	private string overrideDisplayNameField;

	private string overrideLogoField;

	private string overrideSquare480x480LogoField;

	private string overrideSquare44x44LogoField;

	private string overrideSplashScreenImageField;

	private string aliasField;

	[XmlAttribute]
	public string Name
	{
		get
		{
			return nameField;
		}
		set
		{
			nameField = value;
			RaisePropertyChanged("Name");
		}
	}

	[XmlAttribute]
	public ST_DeviceFamily TargetDeviceFamily
	{
		get
		{
			return targetDeviceFamilyField;
		}
		set
		{
			targetDeviceFamilyField = value;
			RaisePropertyChanged("TargetDeviceFamily");
		}
	}

	[XmlIgnore]
	public bool TargetDeviceFamilySpecified
	{
		get
		{
			return targetDeviceFamilyFieldSpecified;
		}
		set
		{
			targetDeviceFamilyFieldSpecified = value;
			RaisePropertyChanged("TargetDeviceFamilySpecified");
		}
	}

	[XmlAttribute]
	public string Id
	{
		get
		{
			return idField;
		}
		set
		{
			idField = value;
			RaisePropertyChanged("Id");
		}
	}

	[XmlAttribute]
	public bool IsDevOnly
	{
		get
		{
			return isDevOnlyField;
		}
		set
		{
			isDevOnlyField = value;
			RaisePropertyChanged("IsDevOnly");
		}
	}

	[XmlIgnore]
	public bool IsDevOnlySpecified
	{
		get
		{
			return isDevOnlyFieldSpecified;
		}
		set
		{
			isDevOnlyFieldSpecified = value;
			RaisePropertyChanged("IsDevOnlySpecified");
		}
	}

	[XmlAttribute]
	public string OverrideDisplayName
	{
		get
		{
			return overrideDisplayNameField;
		}
		set
		{
			overrideDisplayNameField = value;
			RaisePropertyChanged("OverrideDisplayName");
		}
	}

	[XmlAttribute]
	public string OverrideLogo
	{
		get
		{
			return overrideLogoField;
		}
		set
		{
			overrideLogoField = value;
			RaisePropertyChanged("OverrideLogo");
		}
	}

	[XmlAttribute]
	public string OverrideSquare480x480Logo
	{
		get
		{
			return overrideSquare480x480LogoField;
		}
		set
		{
			overrideSquare480x480LogoField = value;
			RaisePropertyChanged("OverrideSquare480x480Logo");
		}
	}

	[XmlAttribute]
	public string OverrideSquare44x44Logo
	{
		get
		{
			return overrideSquare44x44LogoField;
		}
		set
		{
			overrideSquare44x44LogoField = value;
			RaisePropertyChanged("OverrideSquare44x44Logo");
		}
	}

	[XmlAttribute]
	public string OverrideSplashScreenImage
	{
		get
		{
			return overrideSplashScreenImageField;
		}
		set
		{
			overrideSplashScreenImageField = value;
			RaisePropertyChanged("OverrideSplashScreenImage");
		}
	}

	[XmlAttribute]
	public string Alias
	{
		get
		{
			return aliasField;
		}
		set
		{
			aliasField = value;
			RaisePropertyChanged("Alias");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
