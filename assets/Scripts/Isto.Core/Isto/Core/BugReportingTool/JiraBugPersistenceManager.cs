using System;
using System.IO;
using Isto.Core.Data;
using UnityEngine;

namespace Isto.Core.BugReportingTool;

public class JiraBugPersistenceManager
{
	public void SaveJiraBugData(JiraBugData jiraBugData)
	{
		SaveJiraBugDataPlatformPC(jiraBugData);
	}

	public JiraBugData LoadJiraBugData()
	{
		return LoadJiraBugDataPlatformPC();
	}

	public void ClearJiraBugData()
	{
		ClearJiraBugDataPlatformPC();
	}

	private void SaveJiraBugDataPlatformPC(JiraBugData jiraBugData)
	{
		string jIRA_DEBUG_FILE_FULL_PATH = FilePathConstants.JIRA_DEBUG_FILE_FULL_PATH;
		Debug.Log("Full Path: " + jIRA_DEBUG_FILE_FULL_PATH);
		try
		{
			if (!Directory.Exists(FilePathConstants.DEBUG_JIRA_FOLDER_PATH))
			{
				Directory.CreateDirectory(FilePathConstants.DEBUG_JIRA_FOLDER_PATH);
			}
			string value = JsonUtility.ToJson(jiraBugData, prettyPrint: true);
			using FileStream stream = new FileStream(jIRA_DEBUG_FILE_FULL_PATH, FileMode.Create);
			using StreamWriter streamWriter = new StreamWriter(stream);
			streamWriter.Write(value);
		}
		catch (PathTooLongException ex)
		{
			Debug.LogError("Error occured when trying to save the Jira bug to file " + jIRA_DEBUG_FILE_FULL_PATH + ". Exception: " + ex.Message + "\n" + ex.InnerException?.Message);
		}
		catch (UnauthorizedAccessException ex2)
		{
			Debug.LogError("Error occured when trying to save the Jira bug to file " + jIRA_DEBUG_FILE_FULL_PATH + ". Exception: " + ex2.Message + "\n" + ex2.InnerException?.Message);
		}
		catch (IOException ex3)
		{
			Debug.LogError("Error occured when trying to save the Jira bug to file " + jIRA_DEBUG_FILE_FULL_PATH + ". Exception: " + ex3.Message + "\n" + ex3.InnerException?.Message);
		}
		catch (Exception ex4)
		{
			Debug.LogError("Error occured when trying to save the Jira bug to file " + jIRA_DEBUG_FILE_FULL_PATH + ". Exception: " + ex4.Message + "\n" + ex4.InnerException?.Message);
		}
	}

	private JiraBugData LoadJiraBugDataPlatformPC()
	{
		string jIRA_DEBUG_FILE_FULL_PATH = FilePathConstants.JIRA_DEBUG_FILE_FULL_PATH;
		JiraBugData result = new JiraBugData();
		if (File.Exists(jIRA_DEBUG_FILE_FULL_PATH))
		{
			try
			{
				string json;
				using (FileStream stream = new FileStream(jIRA_DEBUG_FILE_FULL_PATH, FileMode.Open))
				{
					using StreamReader streamReader = new StreamReader(stream);
					json = streamReader.ReadToEnd();
				}
				result = JsonUtility.FromJson<JiraBugData>(json);
			}
			catch (OutOfMemoryException ex)
			{
				Debug.LogError("Error occured when trying to load the Jira bug from file " + jIRA_DEBUG_FILE_FULL_PATH + ". Exception: " + ex.Message + "\n" + ex.InnerException?.Message);
			}
			catch (IOException ex2)
			{
				Debug.LogError("Error occured when trying to load the Jira bug from file " + jIRA_DEBUG_FILE_FULL_PATH + ". Exception: " + ex2.Message + "\n" + ex2.InnerException?.Message);
			}
			catch (Exception ex3)
			{
				Debug.LogError("Error occured when trying to load the Jira bug from file " + jIRA_DEBUG_FILE_FULL_PATH + ". Exception: " + ex3.Message + "\n" + ex3.InnerException?.Message);
			}
		}
		return result;
	}

	private static void ClearJiraBugDataPlatformPC()
	{
		string jIRA_DEBUG_FILE_FULL_PATH = FilePathConstants.JIRA_DEBUG_FILE_FULL_PATH;
		if (File.Exists(jIRA_DEBUG_FILE_FULL_PATH))
		{
			File.Delete(jIRA_DEBUG_FILE_FULL_PATH);
		}
	}
}
