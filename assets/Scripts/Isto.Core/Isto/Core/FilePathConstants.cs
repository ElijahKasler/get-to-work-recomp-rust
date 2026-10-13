using System.IO;
using UnityEngine;

namespace Isto.Core;

public static class FilePathConstants
{
	private static readonly string DEBUG_FOLDER_NAME = "Debug";

	private static readonly string JIRA_FOLDER_NAME = "JiraBug";

	private static readonly string SCREENSHOTS_FOLDER_NAME = "Screenshots";

	private static readonly string JIRA_DEBUG_FILE_NAME = "JiraDebug.istoreport";

	public static readonly string DEBUG_JIRA_FOLDER_PATH = Path.Combine(Application.persistentDataPath, DEBUG_FOLDER_NAME, JIRA_FOLDER_NAME);

	public static readonly string DEBUG_SCREENSHOTS_FOLDER_PATH = Path.Combine(Application.persistentDataPath, DEBUG_FOLDER_NAME, SCREENSHOTS_FOLDER_NAME);

	public static readonly string DEFUALT_USER_SCREENSHOTS_FOLDER_PATH = Path.Combine(Application.persistentDataPath, SCREENSHOTS_FOLDER_NAME);

	public static readonly string JIRA_DEBUG_FILE_FULL_PATH = Path.Combine(DEBUG_JIRA_FOLDER_PATH, JIRA_DEBUG_FILE_NAME);
}
