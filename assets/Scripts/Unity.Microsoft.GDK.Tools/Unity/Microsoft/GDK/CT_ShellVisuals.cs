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
public class CT_ShellVisuals : INotifyPropertyChanged
{
	private string defaultDisplayNameField;

	private string publisherDisplayNameField;

	private string storeLogoField;

	private string square150x150LogoField;

	private string square44x44LogoField;

	private string square480x480LogoField;

	private string descriptionField;

	private ST_ForegroundText foregroundTextField;

	private bool foregroundTextFieldSpecified;

	private string backgroundColorField;

	private string splashScreenImageField;

	[XmlAttribute]
	public string DefaultDisplayName
	{
		get
		{
			return defaultDisplayNameField;
		}
		set
		{
			defaultDisplayNameField = value;
			RaisePropertyChanged("DefaultDisplayName");
		}
	}

	[XmlAttribute]
	public string PublisherDisplayName
	{
		get
		{
			return publisherDisplayNameField;
		}
		set
		{
			publisherDisplayNameField = value;
			RaisePropertyChanged("PublisherDisplayName");
		}
	}

	[XmlAttribute]
	public string StoreLogo
	{
		get
		{
			return storeLogoField;
		}
		set
		{
			storeLogoField = value;
			RaisePropertyChanged("StoreLogo");
		}
	}

	[XmlAttribute]
	public string Square150x150Logo
	{
		get
		{
			return square150x150LogoField;
		}
		set
		{
			square150x150LogoField = value;
			RaisePropertyChanged("Square150x150Logo");
		}
	}

	[XmlAttribute]
	public string Square44x44Logo
	{
		get
		{
			return square44x44LogoField;
		}
		set
		{
			square44x44LogoField = value;
			RaisePropertyChanged("Square44x44Logo");
		}
	}

	[XmlAttribute]
	public string Square480x480Logo
	{
		get
		{
			return square480x480LogoField;
		}
		set
		{
			square480x480LogoField = value;
			RaisePropertyChanged("Square480x480Logo");
		}
	}

	[XmlAttribute]
	public string Description
	{
		get
		{
			return descriptionField;
		}
		set
		{
			descriptionField = value;
			RaisePropertyChanged("Description");
		}
	}

	[XmlAttribute]
	public ST_ForegroundText ForegroundText
	{
		get
		{
			return foregroundTextField;
		}
		set
		{
			foregroundTextField = value;
			RaisePropertyChanged("ForegroundText");
		}
	}

	[XmlIgnore]
	public bool ForegroundTextSpecified
	{
		get
		{
			return foregroundTextFieldSpecified;
		}
		set
		{
			foregroundTextFieldSpecified = value;
			RaisePropertyChanged("ForegroundTextSpecified");
		}
	}

	[XmlAttribute]
	public string BackgroundColor
	{
		get
		{
			return backgroundColorField;
		}
		set
		{
			backgroundColorField = value;
			RaisePropertyChanged("BackgroundColor");
		}
	}

	[XmlAttribute]
	public string SplashScreenImage
	{
		get
		{
			return splashScreenImageField;
		}
		set
		{
			splashScreenImageField = value;
			RaisePropertyChanged("SplashScreenImage");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
