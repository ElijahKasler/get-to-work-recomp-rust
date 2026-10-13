using System.Collections;
using System.Drawing;
using System.IO;

namespace System.Windows.Forms;

internal class FSEntry : IDisposable
{
	public enum FSEntryType
	{
		Desktop = 0,
		RecentlyUsed = 1,
		MyComputer = 2,
		File = 3,
		Directory = 4,
		Device = 5,
		RemovableDevice = 6,
		Network = 7
	}

	private MasterMount.FsTypes fsType;

	private string device_short;

	private string fullName;

	private string name;

	private string realName;

	private FileAttributes attributes = FileAttributes.Normal;

	private long fileSize;

	private FSEntryType fileType;

	private DateTime lastAccessTime;

	private FSEntry mainTopNode;

	private int iconIndex;

	private string parent;

	private bool fMustDisposeImage;

	public MasterMount.FsTypes FsType
	{
		get
		{
			return fsType;
		}
		set
		{
			fsType = value;
		}
	}

	public string DeviceShort
	{
		get
		{
			return device_short;
		}
		set
		{
			device_short = value;
		}
	}

	public string FullName
	{
		get
		{
			return fullName;
		}
		set
		{
			fullName = value;
		}
	}

	public string Name
	{
		get
		{
			return name;
		}
		set
		{
			name = value;
		}
	}

	public string RealName
	{
		get
		{
			return realName;
		}
		set
		{
			realName = value;
		}
	}

	public FileAttributes Attributes
	{
		get
		{
			return attributes;
		}
		set
		{
			attributes = value;
		}
	}

	public long FileSize
	{
		get
		{
			return fileSize;
		}
		set
		{
			fileSize = value;
		}
	}

	public FSEntryType FileType
	{
		get
		{
			return fileType;
		}
		set
		{
			fileType = value;
		}
	}

	public DateTime LastAccessTime
	{
		get
		{
			return lastAccessTime;
		}
		set
		{
			lastAccessTime = value;
		}
	}

	public int IconIndex
	{
		get
		{
			return iconIndex;
		}
		set
		{
			iconIndex = value;
		}
	}

	public FSEntry MainTopNode
	{
		get
		{
			return mainTopNode;
		}
		set
		{
			mainTopNode = value;
		}
	}

	public string Parent
	{
		get
		{
			parent = GetParent();
			return parent;
		}
		set
		{
			parent = value;
		}
	}

	internal Image Image { get; set; }

	private string GetParent()
	{
		if (fullName == MWFVFS.PersonalPrefix)
		{
			return MWFVFS.DesktopPrefix;
		}
		if (fullName == MWFVFS.MyComputerPersonalPrefix)
		{
			return MWFVFS.MyComputerPrefix;
		}
		if (fullName == MWFVFS.MyComputerPrefix)
		{
			return MWFVFS.DesktopPrefix;
		}
		if (fullName == MWFVFS.MyNetworkPrefix)
		{
			return MWFVFS.DesktopPrefix;
		}
		if (fullName == MWFVFS.DesktopPrefix)
		{
			return null;
		}
		if (fullName == MWFVFS.RecentlyUsedPrefix)
		{
			return null;
		}
		foreach (DictionaryEntry item in MWFVFS.MyComputerDevicesPrefix)
		{
			FSEntry fSEntry = item.Value as FSEntry;
			if (fullName == fSEntry.FullName)
			{
				return fSEntry.MainTopNode.FullName;
			}
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(fullName).Parent;
		if (directoryInfo != null)
		{
			if (MWFVFS.MyComputerDevicesPrefix[directoryInfo.FullName + "://"] is FSEntry fSEntry2)
			{
				return fSEntry2.FullName;
			}
			if (mainTopNode != null)
			{
				if (directoryInfo.FullName == ThemeEngine.Current.Places(UIIcon.PlacesDesktop) && mainTopNode.FullName == MWFVFS.DesktopPrefix)
				{
					return mainTopNode.FullName;
				}
				if (directoryInfo.FullName == ThemeEngine.Current.Places(UIIcon.PlacesPersonal) && mainTopNode.FullName == MWFVFS.PersonalPrefix)
				{
					return mainTopNode.FullName;
				}
				if (directoryInfo.FullName == ThemeEngine.Current.Places(UIIcon.PlacesPersonal) && mainTopNode.FullName == MWFVFS.MyComputerPersonalPrefix)
				{
					return mainTopNode.FullName;
				}
			}
			return directoryInfo.FullName;
		}
		return null;
	}

	internal bool IsImageFile()
	{
		string extension = Path.GetExtension(FullName);
		if (string.IsNullOrEmpty(extension))
		{
			return false;
		}
		string text = extension.ToLowerInvariant();
		switch (text)
		{
		default:
			return text == ".tiff";
		case ".bmp":
		case ".gif":
		case ".jpg":
		case ".jpeg":
		case ".png":
		case ".tif":
			return true;
		}
	}

	internal void SetImage()
	{
		try
		{
			Image.GetThumbnailImageAbort callback = ThumbnailCallback;
			using Bitmap bitmap = new Bitmap(FullName);
			Image = bitmap.GetThumbnailImage(48, 48, callback, IntPtr.Zero);
			fMustDisposeImage = true;
		}
		catch (Exception)
		{
			Image = null;
		}
	}

	private bool ThumbnailCallback()
	{
		return false;
	}

	public void Dispose()
	{
		if (Image != null && fMustDisposeImage)
		{
			Image.Dispose();
			Image = null;
		}
	}
}
