using System.Collections.Specialized;

namespace System.Configuration.Install;

public class InstallContext
{
	private StringDictionary parameters;

	private string log_file;

	private bool log;

	public StringDictionary Parameters => parameters;

	public InstallContext()
	{
		log_file = null;
		log = false;
		parameters = ParseCommandLine(new string[0]);
	}

	public InstallContext(string logFilePath, string[] commandLine)
	{
		log_file = logFilePath;
		parameters = ParseCommandLine(commandLine);
		log = IsParameterTrue("LogtoConsole");
	}

	public bool IsParameterTrue(string paramName)
	{
		return parameters[paramName] == "true";
	}

	public void LogMessage(string message)
	{
		if (log)
		{
			Console.WriteLine(message);
		}
	}

	protected static StringDictionary ParseCommandLine(string[] args)
	{
		StringDictionary stringDictionary = new StringDictionary();
		foreach (string text in args)
		{
			int num = text.IndexOf("=");
			if (num == -1)
			{
				stringDictionary[text] = "true";
				continue;
			}
			string key = text.Substring(0, num);
			string text2 = text.Substring(num + 1).ToLower();
			switch (text2)
			{
			case "yes":
			case "true":
			case "1":
				text2 = "true";
				break;
			}
			stringDictionary[key] = text2;
		}
		return stringDictionary;
	}
}
