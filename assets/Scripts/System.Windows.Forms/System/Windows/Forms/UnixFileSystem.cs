using System.Collections;
using System.IO;
using System.Xml;

namespace System.Windows.Forms;

internal class UnixFileSystem : FileSystem
{
	private MasterMount masterMount = new MasterMount();

	private FSEntry desktopFSEntry;

	private FSEntry recentlyusedFSEntry;

	private FSEntry personalFSEntry;

	private FSEntry mycomputerpersonalFSEntry;

	private FSEntry mycomputerFSEntry;

	private FSEntry mynetworkFSEntry;

	private string personal_folder;

	private string recently_used_path;

	private string full_kde_recent_document_dir;

	public UnixFileSystem()
	{
		personal_folder = ThemeEngine.Current.Places(UIIcon.PlacesPersonal);
		recently_used_path = Path.Combine(personal_folder, ".recently-used");
		full_kde_recent_document_dir = personal_folder + "/.kde/share/apps/RecentDocuments";
		desktopFSEntry = new FSEntry();
		desktopFSEntry.Attributes = FileAttributes.Directory;
		desktopFSEntry.FullName = MWFVFS.DesktopPrefix;
		desktopFSEntry.Name = Locale.GetText("Desktop");
		desktopFSEntry.RealName = ThemeEngine.Current.Places(UIIcon.PlacesDesktop);
		desktopFSEntry.FileType = FSEntry.FSEntryType.Directory;
		desktopFSEntry.IconIndex = MimeIconEngine.GetIconIndexForMimeType("desktop/desktop");
		desktopFSEntry.LastAccessTime = DateTime.Now;
		recentlyusedFSEntry = new FSEntry();
		recentlyusedFSEntry.Attributes = FileAttributes.Directory;
		recentlyusedFSEntry.FullName = MWFVFS.RecentlyUsedPrefix;
		recentlyusedFSEntry.Name = Locale.GetText("Recently Used");
		recentlyusedFSEntry.FileType = FSEntry.FSEntryType.Directory;
		recentlyusedFSEntry.IconIndex = MimeIconEngine.GetIconIndexForMimeType("recently/recently");
		recentlyusedFSEntry.LastAccessTime = DateTime.Now;
		personalFSEntry = new FSEntry();
		personalFSEntry.Attributes = FileAttributes.Directory;
		personalFSEntry.FullName = MWFVFS.PersonalPrefix;
		personalFSEntry.Name = Locale.GetText("Personal");
		personalFSEntry.MainTopNode = GetDesktopFSEntry();
		personalFSEntry.RealName = ThemeEngine.Current.Places(UIIcon.PlacesPersonal);
		personalFSEntry.FileType = FSEntry.FSEntryType.Directory;
		personalFSEntry.IconIndex = MimeIconEngine.GetIconIndexForMimeType("directory/home");
		personalFSEntry.LastAccessTime = DateTime.Now;
		mycomputerpersonalFSEntry = new FSEntry();
		mycomputerpersonalFSEntry.Attributes = FileAttributes.Directory;
		mycomputerpersonalFSEntry.FullName = MWFVFS.MyComputerPersonalPrefix;
		mycomputerpersonalFSEntry.Name = Locale.GetText("Personal");
		mycomputerpersonalFSEntry.MainTopNode = GetMyComputerFSEntry();
		mycomputerpersonalFSEntry.RealName = ThemeEngine.Current.Places(UIIcon.PlacesPersonal);
		mycomputerpersonalFSEntry.FileType = FSEntry.FSEntryType.Directory;
		mycomputerpersonalFSEntry.IconIndex = MimeIconEngine.GetIconIndexForMimeType("directory/home");
		mycomputerpersonalFSEntry.LastAccessTime = DateTime.Now;
		mycomputerFSEntry = new FSEntry();
		mycomputerFSEntry.Attributes = FileAttributes.Directory;
		mycomputerFSEntry.FullName = MWFVFS.MyComputerPrefix;
		mycomputerFSEntry.Name = Locale.GetText("My Computer");
		mycomputerFSEntry.MainTopNode = GetDesktopFSEntry();
		mycomputerFSEntry.FileType = FSEntry.FSEntryType.Directory;
		mycomputerFSEntry.IconIndex = MimeIconEngine.GetIconIndexForMimeType("workplace/workplace");
		mycomputerFSEntry.LastAccessTime = DateTime.Now;
		mynetworkFSEntry = new FSEntry();
		mynetworkFSEntry.Attributes = FileAttributes.Directory;
		mynetworkFSEntry.FullName = MWFVFS.MyNetworkPrefix;
		mynetworkFSEntry.Name = Locale.GetText("My Network");
		mynetworkFSEntry.MainTopNode = GetDesktopFSEntry();
		mynetworkFSEntry.FileType = FSEntry.FSEntryType.Directory;
		mynetworkFSEntry.IconIndex = MimeIconEngine.GetIconIndexForMimeType("network/network");
		mynetworkFSEntry.LastAccessTime = DateTime.Now;
	}

	public override void WriteRecentlyUsedFiles(string fileToAdd)
	{
		if (File.Exists(recently_used_path) && new FileInfo(recently_used_path).Length > 0)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(recently_used_path);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("RecentFiles");
			if (xmlNode == null)
			{
				return;
			}
			XmlElement xmlElement = xmlDocument.CreateElement("RecentItem");
			XmlElement xmlElement2 = xmlDocument.CreateElement("URI");
			UriBuilder uriBuilder = new UriBuilder();
			uriBuilder.Path = fileToAdd;
			uriBuilder.Host = null;
			uriBuilder.Scheme = "file";
			XmlText newChild = xmlDocument.CreateTextNode(uriBuilder.ToString());
			xmlElement2.AppendChild(newChild);
			xmlElement.AppendChild(xmlElement2);
			xmlElement2 = xmlDocument.CreateElement("Mime-Type");
			newChild = xmlDocument.CreateTextNode(Mime.GetMimeTypeForFile(fileToAdd));
			xmlElement2.AppendChild(newChild);
			xmlElement.AppendChild(xmlElement2);
			xmlElement2 = xmlDocument.CreateElement("Timestamp");
			newChild = xmlDocument.CreateTextNode(((long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString());
			xmlElement2.AppendChild(newChild);
			xmlElement.AppendChild(xmlElement2);
			xmlElement2 = xmlDocument.CreateElement("Groups");
			xmlElement.AppendChild(xmlElement2);
			foreach (XmlNode childNode in xmlNode.ChildNodes)
			{
				XmlNode xmlNode3 = childNode.SelectSingleNode("URI");
				if (xmlNode3 != null)
				{
					XmlNode firstChild = xmlNode3.FirstChild;
					if (firstChild is XmlText && uriBuilder.ToString() == ((XmlText)firstChild).Data)
					{
						xmlNode.RemoveChild(childNode);
						break;
					}
				}
			}
			xmlNode.PrependChild(xmlElement);
			if (xmlNode.ChildNodes.Count > 10)
			{
				while (xmlNode.ChildNodes.Count > 10)
				{
					xmlNode.RemoveChild(xmlNode.LastChild);
				}
			}
			try
			{
				xmlDocument.Save(recently_used_path);
				return;
			}
			catch (Exception)
			{
				return;
			}
		}
		XmlDocument xmlDocument2 = new XmlDocument();
		xmlDocument2.AppendChild(xmlDocument2.CreateXmlDeclaration("1.0", string.Empty, string.Empty));
		XmlElement xmlElement3 = xmlDocument2.CreateElement("RecentFiles");
		XmlElement xmlElement4 = xmlDocument2.CreateElement("RecentItem");
		XmlElement xmlElement5 = xmlDocument2.CreateElement("URI");
		UriBuilder uriBuilder2 = new UriBuilder();
		uriBuilder2.Path = fileToAdd;
		uriBuilder2.Host = null;
		uriBuilder2.Scheme = "file";
		XmlText newChild2 = xmlDocument2.CreateTextNode(uriBuilder2.ToString());
		xmlElement5.AppendChild(newChild2);
		xmlElement4.AppendChild(xmlElement5);
		xmlElement5 = xmlDocument2.CreateElement("Mime-Type");
		newChild2 = xmlDocument2.CreateTextNode(Mime.GetMimeTypeForFile(fileToAdd));
		xmlElement5.AppendChild(newChild2);
		xmlElement4.AppendChild(xmlElement5);
		xmlElement5 = xmlDocument2.CreateElement("Timestamp");
		newChild2 = xmlDocument2.CreateTextNode(((long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString());
		xmlElement5.AppendChild(newChild2);
		xmlElement4.AppendChild(xmlElement5);
		xmlElement5 = xmlDocument2.CreateElement("Groups");
		xmlElement4.AppendChild(xmlElement5);
		xmlElement3.AppendChild(xmlElement4);
		xmlDocument2.AppendChild(xmlElement3);
		try
		{
			xmlDocument2.Save(recently_used_path);
		}
		catch (Exception)
		{
		}
	}

	public override ArrayList GetRecentlyUsedFiles()
	{
		ArrayList arrayList = new ArrayList();
		if (File.Exists(recently_used_path))
		{
			try
			{
				XmlTextReader xmlTextReader = new XmlTextReader(recently_used_path);
				while (xmlTextReader.Read())
				{
					if (xmlTextReader.NodeType != XmlNodeType.Element || !(xmlTextReader.Name.ToUpper() == "URI"))
					{
						continue;
					}
					xmlTextReader.Read();
					Uri uri = new Uri(xmlTextReader.Value);
					if (!arrayList.Contains(uri.LocalPath) && File.Exists(uri.LocalPath))
					{
						FSEntry fileFSEntry = GetFileFSEntry(new FileInfo(uri.LocalPath));
						if (fileFSEntry != null)
						{
							arrayList.Add(fileFSEntry);
						}
					}
				}
				xmlTextReader.Close();
			}
			catch (Exception)
			{
			}
		}
		if (Directory.Exists(full_kde_recent_document_dir))
		{
			string[] files = Directory.GetFiles(full_kde_recent_document_dir, "*.desktop");
			for (int i = 0; i < files.Length; i++)
			{
				StreamReader streamReader = new StreamReader(files[i]);
				for (string text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
				{
					text = text.Trim();
					if (text.StartsWith("URL="))
					{
						text = text.Replace("URL=", string.Empty);
						text = text.Replace("$HOME", personal_folder);
						Uri uri2 = new Uri(text);
						if (!arrayList.Contains(uri2.LocalPath) && File.Exists(uri2.LocalPath))
						{
							FSEntry fileFSEntry2 = GetFileFSEntry(new FileInfo(uri2.LocalPath));
							if (fileFSEntry2 != null)
							{
								arrayList.Add(fileFSEntry2);
							}
						}
						break;
					}
				}
				streamReader.Close();
			}
		}
		return arrayList;
	}

	public override ArrayList GetMyComputerContent()
	{
		ArrayList arrayList = new ArrayList();
		if (masterMount.ProcMountAvailable)
		{
			masterMount.GetMounts();
			foreach (MasterMount.Mount block_device in masterMount.Block_devices)
			{
				FSEntry fSEntry = new FSEntry();
				fSEntry.FileType = FSEntry.FSEntryType.Device;
				fSEntry.FullName = block_device.mount_point;
				fSEntry.Name = "HDD (" + block_device.fsType.ToString() + ", " + block_device.device_short + ")";
				fSEntry.FsType = block_device.fsType;
				fSEntry.DeviceShort = block_device.device_short;
				fSEntry.IconIndex = MimeIconEngine.GetIconIndexForMimeType("harddisk/harddisk");
				fSEntry.Attributes = FileAttributes.Directory;
				fSEntry.MainTopNode = GetMyComputerFSEntry();
				arrayList.Add(fSEntry);
				if (!MWFVFS.MyComputerDevicesPrefix.Contains(fSEntry.FullName + "://"))
				{
					MWFVFS.MyComputerDevicesPrefix.Add(fSEntry.FullName + "://", fSEntry);
				}
			}
			foreach (MasterMount.Mount removable_device in masterMount.Removable_devices)
			{
				FSEntry fSEntry2 = new FSEntry();
				fSEntry2.FileType = FSEntry.FSEntryType.RemovableDevice;
				fSEntry2.FullName = removable_device.mount_point;
				int num;
				object obj;
				if (removable_device.fsType != MasterMount.FsTypes.usbfs)
				{
					num = 1;
					if (num != 0)
					{
						obj = "DVD/CD-Rom";
						goto IL_019d;
					}
				}
				else
				{
					num = 0;
				}
				obj = "USB";
				goto IL_019d;
				IL_019d:
				string text = (string)obj;
				string mime_type = ((num != 0) ? "cdrom/cdrom" : "removable/removable");
				fSEntry2.Name = text + " (" + removable_device.device_short + ")";
				fSEntry2.IconIndex = MimeIconEngine.GetIconIndexForMimeType(mime_type);
				fSEntry2.FsType = removable_device.fsType;
				fSEntry2.DeviceShort = removable_device.device_short;
				fSEntry2.Attributes = FileAttributes.Directory;
				fSEntry2.MainTopNode = GetMyComputerFSEntry();
				arrayList.Add(fSEntry2);
				string key = fSEntry2.FullName + "://";
				if (!MWFVFS.MyComputerDevicesPrefix.Contains(key))
				{
					MWFVFS.MyComputerDevicesPrefix.Add(key, fSEntry2);
				}
			}
		}
		else
		{
			DriveInfo[] drives = DriveInfo.GetDrives();
			foreach (DriveInfo driveInfo in drives)
			{
				if (driveInfo.DriveType == DriveType.Removable || driveInfo.DriveType == DriveType.CDRom || driveInfo.DriveType == DriveType.Fixed)
				{
					FSEntry fSEntry3 = new FSEntry();
					fSEntry3.FullName = driveInfo.Name;
					fSEntry3.DeviceShort = driveInfo.Name;
					fSEntry3.Attributes = FileAttributes.Directory;
					fSEntry3.MainTopNode = GetMyComputerFSEntry();
					if (string.IsNullOrEmpty(driveInfo.VolumeLabel) || driveInfo.VolumeLabel == driveInfo.Name)
					{
						fSEntry3.Name = driveInfo.Name;
					}
					else
					{
						fSEntry3.Name = driveInfo.VolumeLabel + " (" + fSEntry3.Name + ")";
					}
					if (driveInfo.DriveType == DriveType.Removable)
					{
						fSEntry3.FileType = FSEntry.FSEntryType.RemovableDevice;
						fSEntry3.IconIndex = MimeIconEngine.GetIconIndexForMimeType("removable/removable");
					}
					else if (driveInfo.DriveType == DriveType.CDRom)
					{
						fSEntry3.FileType = FSEntry.FSEntryType.RemovableDevice;
						fSEntry3.IconIndex = MimeIconEngine.GetIconIndexForMimeType("cdrom/cdrom");
					}
					else
					{
						fSEntry3.FileType = FSEntry.FSEntryType.Device;
						fSEntry3.IconIndex = MimeIconEngine.GetIconIndexForMimeType("harddisk/harddisk");
					}
					arrayList.Add(fSEntry3);
					string key2 = fSEntry3.FullName + "://";
					if (!MWFVFS.MyComputerDevicesPrefix.Contains(key2))
					{
						MWFVFS.MyComputerDevicesPrefix.Add(key2, fSEntry3);
					}
				}
			}
		}
		arrayList.Add(GetMyComputerPersonalFSEntry());
		return arrayList;
	}

	public override ArrayList GetMyNetworkContent()
	{
		ArrayList arrayList = new ArrayList();
		foreach (MasterMount.Mount network_device in masterMount.Network_devices)
		{
			FSEntry fSEntry = new FSEntry();
			fSEntry.FileType = FSEntry.FSEntryType.Network;
			fSEntry.FullName = network_device.mount_point;
			fSEntry.FsType = network_device.fsType;
			fSEntry.DeviceShort = network_device.device_short;
			fSEntry.Name = "Network (" + network_device.fsType.ToString() + ", " + network_device.device_short + ")";
			switch (network_device.fsType)
			{
			case MasterMount.FsTypes.nfs:
				fSEntry.IconIndex = MimeIconEngine.GetIconIndexForMimeType("nfs/nfs");
				break;
			case MasterMount.FsTypes.smbfs:
				fSEntry.IconIndex = MimeIconEngine.GetIconIndexForMimeType("smb/smb");
				break;
			case MasterMount.FsTypes.ncpfs:
				fSEntry.IconIndex = MimeIconEngine.GetIconIndexForMimeType("network/network");
				break;
			case MasterMount.FsTypes.cifs:
				fSEntry.IconIndex = MimeIconEngine.GetIconIndexForMimeType("network/network");
				break;
			}
			fSEntry.Attributes = FileAttributes.Directory;
			fSEntry.MainTopNode = GetMyNetworkFSEntry();
			arrayList.Add(fSEntry);
		}
		return arrayList;
	}

	protected override FSEntry GetDesktopFSEntry()
	{
		return desktopFSEntry;
	}

	protected override FSEntry GetRecentlyUsedFSEntry()
	{
		return recentlyusedFSEntry;
	}

	protected override FSEntry GetPersonalFSEntry()
	{
		return personalFSEntry;
	}

	protected override FSEntry GetMyComputerPersonalFSEntry()
	{
		return mycomputerpersonalFSEntry;
	}

	protected override FSEntry GetMyComputerFSEntry()
	{
		return mycomputerFSEntry;
	}

	protected override FSEntry GetMyNetworkFSEntry()
	{
		return mynetworkFSEntry;
	}
}
