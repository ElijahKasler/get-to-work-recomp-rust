using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Threading;

namespace System.Windows.Forms;

internal class MWFVFS
{
	public delegate void UpdateDelegate(ArrayList folders, ArrayList files);

	internal class WorkerThread
	{
		private FileSystem fileSystem;

		private StringCollection the_filters;

		private UpdateDelegate updateDelegate;

		private Control calling_control;

		private readonly object lockobject = new object();

		private bool stopped;

		public WorkerThread(FileSystem fileSystem, StringCollection the_filters, UpdateDelegate updateDelegate, Control calling_control)
		{
			this.fileSystem = fileSystem;
			this.the_filters = the_filters;
			this.updateDelegate = updateDelegate;
			this.calling_control = calling_control;
		}

		public void GetFolderContentThread()
		{
			fileSystem.GetFolderContent(the_filters, out var directories_out, out var files_out);
			if (stopped || updateDelegate == null)
			{
				return;
			}
			lock (this)
			{
				object[] args = new object[2] { directories_out, files_out };
				calling_control.BeginInvoke(updateDelegate, args);
			}
		}

		public void Stop()
		{
			lock (lockobject)
			{
				stopped = true;
			}
		}
	}

	private FileSystem fileSystem;

	public static readonly string DesktopPrefix = "Desktop://";

	public static readonly string PersonalPrefix = "Personal://";

	public static readonly string MyComputerPrefix = "MyComputer://";

	public static readonly string RecentlyUsedPrefix = "RecentlyUsed://";

	public static readonly string MyNetworkPrefix = "MyNetwork://";

	public static readonly string MyComputerPersonalPrefix = "MyComputerPersonal://";

	public static Hashtable MyComputerDevicesPrefix = new Hashtable();

	private UpdateDelegate updateDelegate;

	private Control calling_control;

	private ThreadStart get_folder_content_thread_start;

	private Thread worker;

	private WorkerThread workerThread;

	private StringCollection the_filters;

	public MWFVFS()
	{
		if (XplatUI.RunningOnUnix)
		{
			fileSystem = new UnixFileSystem();
		}
		else
		{
			fileSystem = new WinFileSystem();
		}
	}

	public FSEntry ChangeDirectory(string folder)
	{
		return fileSystem.ChangeDirectory(folder);
	}

	public void GetFolderContent()
	{
		GetFolderContent(null);
	}

	public void GetFolderContent(StringCollection filters)
	{
		the_filters = filters;
		if (workerThread != null)
		{
			workerThread.Stop();
			workerThread = null;
		}
		calling_control.CreateControl();
		workerThread = new WorkerThread(fileSystem, the_filters, updateDelegate, calling_control);
		get_folder_content_thread_start = workerThread.GetFolderContentThread;
		worker = new Thread(get_folder_content_thread_start);
		worker.IsBackground = true;
		worker.Start();
	}

	public ArrayList GetFoldersOnly()
	{
		return fileSystem.GetFoldersOnly();
	}

	public void WriteRecentlyUsedFiles(string filename)
	{
		fileSystem.WriteRecentlyUsedFiles(filename);
	}

	public ArrayList GetRecentlyUsedFiles()
	{
		return fileSystem.GetRecentlyUsedFiles();
	}

	public ArrayList GetMyComputerContent()
	{
		return fileSystem.GetMyComputerContent();
	}

	public ArrayList GetMyNetworkContent()
	{
		return fileSystem.GetMyNetworkContent();
	}

	public bool CreateFolder(string new_folder)
	{
		try
		{
			if (Directory.Exists(new_folder))
			{
				MessageBox.Show(Locale.GetText("Folder \"{0}\" already exists.", new_folder), Locale.GetText("Error Creating Folder"), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			Directory.CreateDirectory(new_folder);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, Locale.GetText("Error Creating Folder"), MessageBoxButtons.OK, MessageBoxIcon.Error);
			return false;
		}
		return true;
	}

	public bool MoveFolder(string sourceDirName, string destDirName)
	{
		try
		{
			if (Directory.Exists(destDirName))
			{
				MessageBox.Show(Locale.GetText("Cannot rename \"{0}\": Folder \"{1}\" already exists. Specify a different folder name.", Path.GetFileName(sourceDirName), Path.GetFileName(destDirName)), Locale.GetText("Error Renaming Folder"), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			Directory.Move(sourceDirName, destDirName);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, Locale.GetText("Error Renaming Folder"), MessageBoxButtons.OK, MessageBoxIcon.Error);
			return false;
		}
		return true;
	}

	public bool MoveFile(string sourceFileName, string destFileName)
	{
		try
		{
			if (File.Exists(destFileName))
			{
				MessageBox.Show(Locale.GetText("Cannot rename \"{0}\": File \"{1}\" already exists. Specify a different file name.", Path.GetFileName(sourceFileName), Path.GetFileName(destFileName)), Locale.GetText("Error Renaming File"), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			File.Move(sourceFileName, destFileName);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, Locale.GetText("Error Renaming File"), MessageBoxButtons.OK, MessageBoxIcon.Error);
			return false;
		}
		return true;
	}

	public string GetParent()
	{
		return fileSystem.GetParent();
	}

	public void RegisterUpdateDelegate(UpdateDelegate updateDelegate, Control control)
	{
		this.updateDelegate = updateDelegate;
		calling_control = control;
	}
}
