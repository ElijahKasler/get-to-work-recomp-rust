using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace System.Windows.Forms;

public class Help
{
	private Help()
	{
	}

	public static void ShowHelp(Control parent, string url)
	{
		ShowHelp(parent, url, null);
	}

	public static void ShowHelp(Control parent, string url, HelpNavigator navigator)
	{
		ShowHelp(parent, url, navigator, null);
	}

	[System.MonoTODO("Stub, does nothing")]
	public static void ShowHelp(Control parent, string url, HelpNavigator command, object parameter)
	{
	}

	public static void ShowHelp(Control parent, string url, string keyword)
	{
		ShowHelpTopic(url, keyword);
	}

	public static void ShowHelpIndex(Control parent, string url)
	{
		ShowHelp(parent, url, HelpNavigator.Index, null);
	}

	[System.MonoTODO("Stub, does nothing")]
	public static void ShowPopup(Control parent, string caption, Point location)
	{
	}

	private static void ShowHelpTopic(string helpFile, string helpTopic)
	{
		if (helpFile == null)
		{
			throw new ArgumentNullException();
		}
		if (helpFile == string.Empty)
		{
			throw new ArgumentException();
		}
		helpFile = helpFile.Replace("\\", Path.DirectorySeparatorChar.ToString());
		string text = Environment.GetEnvironmentVariable("MONO_HELP_VIEWER") ?? "chmsee";
		string arguments = $"\"{helpFile}\"";
		if (!string.IsNullOrEmpty(helpTopic))
		{
			if (!helpTopic.StartsWith("/"))
			{
				helpTopic = "/" + helpTopic;
			}
			helpTopic = helpTopic.TrimEnd(' ');
			arguments = $"\"{helpFile}::{helpTopic}\"";
		}
		try
		{
			RunNonblockingProcess(text, arguments);
		}
		catch (Exception ex)
		{
			string text2 = $"The help viewer could not load. Maybe you don't have {text} installed or haven't set MONO_HELP_VIEWER. The specific error message was: {ex.Message}";
			Console.Error.WriteLine(text2);
			MessageBox.Show(text2);
		}
	}

	private static void RunNonblockingProcess(string command, string arguments)
	{
		using Process process = new Process();
		process.StartInfo.FileName = command;
		process.StartInfo.Arguments = arguments;
		process.StartInfo.UseShellExecute = false;
		process.Start();
	}
}
