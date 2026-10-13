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
[XmlRoot(Namespace = "", IsNullable = false)]
public class Game : INotifyPropertyChanged
{
	private CT_Identity identityField;

	private CT_ShellVisuals shellVisualsField;

	private CT_ResourcesResource[] resourcesField;

	private CT_ExecutableList executableListField;

	private string gameOsVersionField;

	private CT_MediaCapture mediaCaptureField;

	private string storeIdField;

	private ST_DeviceFamily targetDeviceFamilyForDLCField;

	private bool targetDeviceFamilyForDLCFieldSpecified;

	private CT_AllowedProductsList allowedProductsField;

	private CT_RelatedProductsList relatedProductsField;

	private CT_PersistentLocalStorage persistentLocalStorageField;

	private CT_VirtualMachine virtualMachineField;

	private bool mSAFullTrustField;

	private bool mSAFullTrustFieldSpecified;

	private string mSAAppIdField;

	private string titleIdField;

	private bool requiresXboxLiveField;

	private bool requiresXboxLiveFieldSpecified;

	private CT_ExtendedAttributeList extendedAttributeListField;

	private CT_DesktopRegistration desktopRegistrationField;

	private CT_DevelopmentOnly developmentOnlyField;

	private bool advancedUserModelField;

	private CT_SaveGameStorage saveGameStorageField;

	private CT_ProtocolList protocolListField;

	private string franchiseGameHubIdField;

	private string associatedFranchiseGameHubIdField;

	private string configVersionField;

	public CT_Identity Identity
	{
		get
		{
			return identityField;
		}
		set
		{
			identityField = value;
			RaisePropertyChanged("Identity");
		}
	}

	public CT_ShellVisuals ShellVisuals
	{
		get
		{
			return shellVisualsField;
		}
		set
		{
			shellVisualsField = value;
			RaisePropertyChanged("ShellVisuals");
		}
	}

	[XmlArrayItem("Resource", IsNullable = false)]
	public CT_ResourcesResource[] Resources
	{
		get
		{
			return resourcesField;
		}
		set
		{
			resourcesField = value;
			RaisePropertyChanged("Resources");
		}
	}

	public CT_ExecutableList ExecutableList
	{
		get
		{
			return executableListField;
		}
		set
		{
			executableListField = value;
			RaisePropertyChanged("ExecutableList");
		}
	}

	public string GameOsVersion
	{
		get
		{
			return gameOsVersionField;
		}
		set
		{
			gameOsVersionField = value;
			RaisePropertyChanged("GameOsVersion");
		}
	}

	public CT_MediaCapture MediaCapture
	{
		get
		{
			return mediaCaptureField;
		}
		set
		{
			mediaCaptureField = value;
			RaisePropertyChanged("MediaCapture");
		}
	}

	public string StoreId
	{
		get
		{
			return storeIdField;
		}
		set
		{
			storeIdField = value;
			RaisePropertyChanged("StoreId");
		}
	}

	public ST_DeviceFamily TargetDeviceFamilyForDLC
	{
		get
		{
			return targetDeviceFamilyForDLCField;
		}
		set
		{
			targetDeviceFamilyForDLCField = value;
			RaisePropertyChanged("TargetDeviceFamilyForDLC");
		}
	}

	[XmlIgnore]
	public bool TargetDeviceFamilyForDLCSpecified
	{
		get
		{
			return targetDeviceFamilyForDLCFieldSpecified;
		}
		set
		{
			targetDeviceFamilyForDLCFieldSpecified = value;
			RaisePropertyChanged("TargetDeviceFamilyForDLCSpecified");
		}
	}

	public CT_AllowedProductsList AllowedProducts
	{
		get
		{
			return allowedProductsField;
		}
		set
		{
			allowedProductsField = value;
			RaisePropertyChanged("AllowedProducts");
		}
	}

	public CT_RelatedProductsList RelatedProducts
	{
		get
		{
			return relatedProductsField;
		}
		set
		{
			relatedProductsField = value;
			RaisePropertyChanged("RelatedProducts");
		}
	}

	public CT_PersistentLocalStorage PersistentLocalStorage
	{
		get
		{
			return persistentLocalStorageField;
		}
		set
		{
			persistentLocalStorageField = value;
			RaisePropertyChanged("PersistentLocalStorage");
		}
	}

	public CT_VirtualMachine VirtualMachine
	{
		get
		{
			return virtualMachineField;
		}
		set
		{
			virtualMachineField = value;
			RaisePropertyChanged("VirtualMachine");
		}
	}

	public bool MSAFullTrust
	{
		get
		{
			return mSAFullTrustField;
		}
		set
		{
			mSAFullTrustField = value;
			RaisePropertyChanged("MSAFullTrust");
		}
	}

	[XmlIgnore]
	public bool MSAFullTrustSpecified
	{
		get
		{
			return mSAFullTrustFieldSpecified;
		}
		set
		{
			mSAFullTrustFieldSpecified = value;
			RaisePropertyChanged("MSAFullTrustSpecified");
		}
	}

	public string MSAAppId
	{
		get
		{
			return mSAAppIdField;
		}
		set
		{
			mSAAppIdField = value;
			RaisePropertyChanged("MSAAppId");
		}
	}

	public string TitleId
	{
		get
		{
			return titleIdField;
		}
		set
		{
			titleIdField = value;
			RaisePropertyChanged("TitleId");
		}
	}

	public bool RequiresXboxLive
	{
		get
		{
			return requiresXboxLiveField;
		}
		set
		{
			requiresXboxLiveField = value;
			RaisePropertyChanged("RequiresXboxLive");
		}
	}

	[XmlIgnore]
	public bool RequiresXboxLiveSpecified
	{
		get
		{
			return requiresXboxLiveFieldSpecified;
		}
		set
		{
			requiresXboxLiveFieldSpecified = value;
			RaisePropertyChanged("RequiresXboxLiveSpecified");
		}
	}

	public CT_ExtendedAttributeList ExtendedAttributeList
	{
		get
		{
			return extendedAttributeListField;
		}
		set
		{
			extendedAttributeListField = value;
			RaisePropertyChanged("ExtendedAttributeList");
		}
	}

	public CT_DesktopRegistration DesktopRegistration
	{
		get
		{
			return desktopRegistrationField;
		}
		set
		{
			desktopRegistrationField = value;
			RaisePropertyChanged("DesktopRegistration");
		}
	}

	public CT_DevelopmentOnly DevelopmentOnly
	{
		get
		{
			return developmentOnlyField;
		}
		set
		{
			developmentOnlyField = value;
			RaisePropertyChanged("DevelopmentOnly");
		}
	}

	[DefaultValue(true)]
	public bool AdvancedUserModel
	{
		get
		{
			return advancedUserModelField;
		}
		set
		{
			advancedUserModelField = value;
			RaisePropertyChanged("AdvancedUserModel");
		}
	}

	public CT_SaveGameStorage SaveGameStorage
	{
		get
		{
			return saveGameStorageField;
		}
		set
		{
			saveGameStorageField = value;
			RaisePropertyChanged("SaveGameStorage");
		}
	}

	public CT_ProtocolList ProtocolList
	{
		get
		{
			return protocolListField;
		}
		set
		{
			protocolListField = value;
			RaisePropertyChanged("ProtocolList");
		}
	}

	public string FranchiseGameHubId
	{
		get
		{
			return franchiseGameHubIdField;
		}
		set
		{
			franchiseGameHubIdField = value;
			RaisePropertyChanged("FranchiseGameHubId");
		}
	}

	public string AssociatedFranchiseGameHubId
	{
		get
		{
			return associatedFranchiseGameHubIdField;
		}
		set
		{
			associatedFranchiseGameHubIdField = value;
			RaisePropertyChanged("AssociatedFranchiseGameHubId");
		}
	}

	[XmlAttribute(DataType = "integer")]
	public string configVersion
	{
		get
		{
			return configVersionField;
		}
		set
		{
			configVersionField = value;
			RaisePropertyChanged("configVersion");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	public Game()
	{
		advancedUserModelField = true;
	}

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
