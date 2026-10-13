using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Isto.Core.Data;
using UnityEngine;
using UnityEngine.Networking;

namespace Isto.Core.BugReportingTool;

public class JiraConnection
{
	private JiraUser _currentJiraUser;

	private Dictionary<string, string> _mimeTypeMap;

	private static readonly string MAIN_URL = "https://istoinc.atlassian.net/";

	private static readonly string SUBMISSION_URL = "rest/api/2/issue";

	private static readonly string EMPTY_JSON_STRING = "{}";

	private static readonly string BASIC_AUTHENTICATION_PREFIX = "Basic ";

	public event EventHandler<string> SubmissionResult;

	public JiraConnection(JiraUser jiraUser)
	{
		_currentJiraUser = jiraUser;
		SetupMimeTypeDictionary();
	}

	private void SetupMimeTypeDictionary()
	{
		_mimeTypeMap = new Dictionary<string, string>
		{
			{ ".png", "image/png" },
			{ ".txt", "text/plain" },
			{ ".log", "text/plain" },
			{ ".zip", "application/zip" }
		};
	}

	public IEnumerator ProcessRequest(JiraBugData jiraBugData)
	{
		string uri = MAIN_URL + SUBMISSION_URL;
		string s = JsonUtility.ToJson(JiraBugTypeConverter.JiraBugDataToJiraJsonContainer(jiraBugData, _currentJiraUser));
		using UnityWebRequest request = UnityWebRequest.Get(uri);
		string authenticationString = GetAuthenticationString(_currentJiraUser.Email, _currentJiraUser.JiraApiToken);
		request.method = "POST";
		request.SetRequestHeader("Content-Type", "application/json");
		request.SetRequestHeader("Accept", "application/json");
		request.SetRequestHeader("AUTHORIZATION", authenticationString);
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		request.uploadHandler = new UploadHandlerRaw(bytes);
		yield return request.SendWebRequest();
		DownloadHandler downloadHandler = request.downloadHandler;
		if (request.result != UnityWebRequest.Result.Success)
		{
			string text = $"Unity Web Request Failed. Reason: {request.result}";
			SubmissionResult?.Invoke(this, text);
			Debug.LogError(text);
			yield break;
		}
		if (downloadHandler.text == EMPTY_JSON_STRING || string.IsNullOrEmpty(downloadHandler.text))
		{
			string text2 = "The web request has returned an empty response.";
			SubmissionResult?.Invoke(this, text2);
			Debug.LogError(text2);
			yield break;
		}
		JiraJsonResult jiraJsonResult = JsonUtility.FromJson<JiraJsonResult>(downloadHandler.text);
		string issueNumber = jiraJsonResult.key;
		Debug.Log("Unity Web Request Succeeded! Issue number " + issueNumber + " created.");
		SubmissionResult?.Invoke(this, "Success!");
		yield return UploadFileToJiraIssue(issueNumber, jiraBugData.ImageFilePath);
		yield return AttachPlayerLog(issueNumber);
	}

	private IEnumerator AttachPlayerLog(string issueNumber)
	{
		string filePath = Path.Combine(Application.persistentDataPath, "Player.log");
		yield return UploadFileToJiraIssue(issueNumber, filePath);
	}

	private IEnumerator UploadFileToJiraIssue(string issueNumber, string filePath)
	{
		string text = MAIN_URL + SUBMISSION_URL;
		string fileName = Path.GetFileName(filePath);
		string mimeTypeFromFile = GetMimeTypeFromFile(filePath);
		byte[] contents = File.ReadAllBytes(filePath);
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddBinaryData("file", contents, fileName, mimeTypeFromFile);
		UnityWebRequest webRequest = UnityWebRequest.Post(text + "/" + issueNumber + "/attachments", wWWForm);
		webRequest.method = "POST";
		webRequest.SetRequestHeader("X-Atlassian-Token", "no-check");
		string authenticationString = GetAuthenticationString(_currentJiraUser.Email, _currentJiraUser.JiraApiToken);
		webRequest.SetRequestHeader("AUTHORIZATION", authenticationString);
		yield return webRequest.SendWebRequest();
		if (webRequest.result != UnityWebRequest.Result.Success)
		{
			Debug.LogError($"Unity Web Request Failed. Reason: {webRequest.result}");
		}
		else if (webRequest.downloadHandler.text == "{}" || string.IsNullOrEmpty(webRequest.downloadHandler.text))
		{
			Debug.LogError("The web request has returned and empty response.");
		}
		else
		{
			Debug.Log("Unity Web Request Succeeded! File " + filePath + " successfully attached.");
		}
	}

	private string GetMimeTypeFromFile(string filePath)
	{
		string extension = Path.GetExtension(filePath);
		if (!_mimeTypeMap.TryGetValue(extension, out var value))
		{
			Debug.LogError("MimeType could not be found for extension " + extension + ". Please ensure that it has been added to the dictionary.");
		}
		return value;
	}

	private string GetAuthenticationString(string username, string password)
	{
		string s = username.Trim() + ":" + password.Trim();
		string text = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(s));
		return BASIC_AUTHENTICATION_PREFIX + text;
	}
}
