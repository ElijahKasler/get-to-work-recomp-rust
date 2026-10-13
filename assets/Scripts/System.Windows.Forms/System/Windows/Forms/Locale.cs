using System.Reflection;
using System.Resources;

namespace System.Windows.Forms;

internal static class Locale
{
	private static ResourceManager rm;

	public static ResourceManager ResourceManager => rm;

	static Locale()
	{
		rm = new ResourceManager("System.Windows.Forms", Assembly.GetExecutingAssembly());
	}

	public static string GetText(string msg)
	{
		string text = ResourceManager.GetString(msg);
		if (text != null)
		{
			return text;
		}
		return msg;
	}

	public static string GetText(string msg, params object[] args)
	{
		return string.Format(GetText(msg), args);
	}
}
