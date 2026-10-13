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
public class CT_DesktopRegistration : INotifyPropertyChanged
{
	private ST_ProcessorArchitecture[] processorArchitectureField;

	private CT_DesktopRegistrationMainPackageDependency[] mainPackageDependencyField;

	private CT_DependencyList[] dependencyListField;

	private CT_CustomInstallActions[] customInstallActionsField;

	private CT_DesktopRegistrationModFolder[] modFolderField;

	private bool[] disableRegistryWriteVirtualizationField;

	private bool[] disableFilesystemWriteVirtualizationField;

	private bool[] enableWritesToPackageRootField;

	private CT_DesktopRegistrationMultiplayerProtocol[] multiplayerProtocolField;

	private CT_FileTypeAssociation[] fileTypeAssociationField;

	[XmlElement("ProcessorArchitecture")]
	public ST_ProcessorArchitecture[] ProcessorArchitecture
	{
		get
		{
			return processorArchitectureField;
		}
		set
		{
			processorArchitectureField = value;
			RaisePropertyChanged("ProcessorArchitecture");
		}
	}

	[XmlElement("MainPackageDependency")]
	public CT_DesktopRegistrationMainPackageDependency[] MainPackageDependency
	{
		get
		{
			return mainPackageDependencyField;
		}
		set
		{
			mainPackageDependencyField = value;
			RaisePropertyChanged("MainPackageDependency");
		}
	}

	[XmlElement("DependencyList")]
	public CT_DependencyList[] DependencyList
	{
		get
		{
			return dependencyListField;
		}
		set
		{
			dependencyListField = value;
			RaisePropertyChanged("DependencyList");
		}
	}

	[XmlElement("CustomInstallActions")]
	public CT_CustomInstallActions[] CustomInstallActions
	{
		get
		{
			return customInstallActionsField;
		}
		set
		{
			customInstallActionsField = value;
			RaisePropertyChanged("CustomInstallActions");
		}
	}

	[XmlElement("ModFolder")]
	public CT_DesktopRegistrationModFolder[] ModFolder
	{
		get
		{
			return modFolderField;
		}
		set
		{
			modFolderField = value;
			RaisePropertyChanged("ModFolder");
		}
	}

	[XmlElement("DisableRegistryWriteVirtualization")]
	public bool[] DisableRegistryWriteVirtualization
	{
		get
		{
			return disableRegistryWriteVirtualizationField;
		}
		set
		{
			disableRegistryWriteVirtualizationField = value;
			RaisePropertyChanged("DisableRegistryWriteVirtualization");
		}
	}

	[XmlElement("DisableFilesystemWriteVirtualization")]
	public bool[] DisableFilesystemWriteVirtualization
	{
		get
		{
			return disableFilesystemWriteVirtualizationField;
		}
		set
		{
			disableFilesystemWriteVirtualizationField = value;
			RaisePropertyChanged("DisableFilesystemWriteVirtualization");
		}
	}

	[XmlElement("EnableWritesToPackageRoot")]
	public bool[] EnableWritesToPackageRoot
	{
		get
		{
			return enableWritesToPackageRootField;
		}
		set
		{
			enableWritesToPackageRootField = value;
			RaisePropertyChanged("EnableWritesToPackageRoot");
		}
	}

	[XmlElement("MultiplayerProtocol")]
	public CT_DesktopRegistrationMultiplayerProtocol[] MultiplayerProtocol
	{
		get
		{
			return multiplayerProtocolField;
		}
		set
		{
			multiplayerProtocolField = value;
			RaisePropertyChanged("MultiplayerProtocol");
		}
	}

	[XmlElement("FileTypeAssociation")]
	public CT_FileTypeAssociation[] FileTypeAssociation
	{
		get
		{
			return fileTypeAssociationField;
		}
		set
		{
			fileTypeAssociationField = value;
			RaisePropertyChanged("FileTypeAssociation");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
