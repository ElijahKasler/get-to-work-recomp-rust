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
public class CT_MediaCapture : INotifyPropertyChanged
{
	private bool gameDVRSystemComponentField;

	private bool gameDVRSystemComponentFieldSpecified;

	private bool blockBroadcastField;

	private bool blockBroadcastFieldSpecified;

	private bool blockGameDVRField;

	private bool blockGameDVRFieldSpecified;

	public bool GameDVRSystemComponent
	{
		get
		{
			return gameDVRSystemComponentField;
		}
		set
		{
			gameDVRSystemComponentField = value;
			RaisePropertyChanged("GameDVRSystemComponent");
		}
	}

	[XmlIgnore]
	public bool GameDVRSystemComponentSpecified
	{
		get
		{
			return gameDVRSystemComponentFieldSpecified;
		}
		set
		{
			gameDVRSystemComponentFieldSpecified = value;
			RaisePropertyChanged("GameDVRSystemComponentSpecified");
		}
	}

	public bool BlockBroadcast
	{
		get
		{
			return blockBroadcastField;
		}
		set
		{
			blockBroadcastField = value;
			RaisePropertyChanged("BlockBroadcast");
		}
	}

	[XmlIgnore]
	public bool BlockBroadcastSpecified
	{
		get
		{
			return blockBroadcastFieldSpecified;
		}
		set
		{
			blockBroadcastFieldSpecified = value;
			RaisePropertyChanged("BlockBroadcastSpecified");
		}
	}

	public bool BlockGameDVR
	{
		get
		{
			return blockGameDVRField;
		}
		set
		{
			blockGameDVRField = value;
			RaisePropertyChanged("BlockGameDVR");
		}
	}

	[XmlIgnore]
	public bool BlockGameDVRSpecified
	{
		get
		{
			return blockGameDVRFieldSpecified;
		}
		set
		{
			blockGameDVRFieldSpecified = value;
			RaisePropertyChanged("BlockGameDVRSpecified");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
