using System;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Isto.Core.Screenshot;

public static class ScreenshotUtil
{
	private static readonly int DEBUG_SCALED_RESOLUTION = 1;

	private static readonly string SCREENSHOT_PREFIX = "Screenshot_";

	private static readonly string DEBUG_SCREENSHOT_PREFIX = "IstoDebugScreenshot_";

	private static readonly string SCREENSHOT_FILE_TYPE = ".png";

	private static ScreenshotFile _latestScreenshotFile;

	public static ScreenshotFile TakeRuntimeScreenshot(string folderPath = null, string fileName = null, int scaledResolution = 1, bool isLogging = false)
	{
		if (folderPath == null)
		{
			folderPath = FilePathConstants.DEFUALT_USER_SCREENSHOTS_FOLDER_PATH;
		}
		TryCreateScreenshotDirectory(folderPath);
		if (fileName == null)
		{
			fileName = SCREENSHOT_PREFIX + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + SCREENSHOT_FILE_TYPE;
		}
		return TakeScreenshot(folderPath, fileName, scaledResolution, isLogging);
	}

	public static ScreenshotFile TakeDebugScreenshot()
	{
		TryCreateScreenshotDirectory(FilePathConstants.DEBUG_SCREENSHOTS_FOLDER_PATH);
		string fileName = DEBUG_SCREENSHOT_PREFIX + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss", CultureInfo.InvariantCulture) + SCREENSHOT_FILE_TYPE;
		return TakeScreenshot(FilePathConstants.DEBUG_SCREENSHOTS_FOLDER_PATH, fileName, DEBUG_SCALED_RESOLUTION, isLogging: true);
	}

	public static ScreenshotFile GetLatestDebugScreenshot()
	{
		TryCreateScreenshotDirectory(FilePathConstants.DEBUG_SCREENSHOTS_FOLDER_PATH);
		FileInfo[] files = new DirectoryInfo(FilePathConstants.DEBUG_SCREENSHOTS_FOLDER_PATH).GetFiles();
		if (files.Length == 0)
		{
			_latestScreenshotFile = new ScreenshotFile();
		}
		else
		{
			_latestScreenshotFile = new ScreenshotFile(files.OrderByDescending((FileInfo o) => o.CreationTime).FirstOrDefault()?.FullName);
		}
		return _latestScreenshotFile;
	}

	public static void ClearDebugScreenshots()
	{
		if (!Directory.Exists(FilePathConstants.DEBUG_SCREENSHOTS_FOLDER_PATH))
		{
			return;
		}
		FileInfo[] files = new DirectoryInfo(FilePathConstants.DEBUG_SCREENSHOTS_FOLDER_PATH).GetFiles();
		foreach (FileInfo fileInfo in files)
		{
			if (Path.GetFileName(fileInfo.FullName) != Path.GetFileName(_latestScreenshotFile.FilePath))
			{
				fileInfo.Delete();
			}
		}
	}

	private static ScreenshotFile TakeScreenshot(string folderPath, string fileName, int scaledResolution, bool isLogging)
	{
		string text = Path.Combine(folderPath, fileName);
		ScreenCapture.CaptureScreenshot(text, scaledResolution);
		_latestScreenshotFile = new ScreenshotFile(text);
		if (isLogging)
		{
			Debug.Log("Screen Capture taken. Filepath: " + text);
		}
		return _latestScreenshotFile;
	}

	private static void TryCreateScreenshotDirectory(string directoryPath)
	{
		if (!Directory.Exists(directoryPath))
		{
			try
			{
				Directory.CreateDirectory(directoryPath);
			}
			catch (PathTooLongException ex)
			{
				Debug.LogError("Error occured when trying to create a the directory " + directoryPath + ". Exception: " + ex.Message + "\n" + ex.InnerException?.Message);
			}
			catch (UnauthorizedAccessException ex2)
			{
				Debug.LogError("Error occured when trying to create a the directory " + directoryPath + ". Exception: " + ex2.Message + "\n" + ex2.InnerException?.Message);
			}
			catch (IOException ex3)
			{
				Debug.LogError("Error occured when trying to create a the directory " + directoryPath + ". Exception: " + ex3.Message + "\n" + ex3.InnerException?.Message);
			}
			catch (Exception ex4)
			{
				Debug.LogError("Error occured when trying to create a the directory " + directoryPath + ". Exception: " + ex4.Message + "\n" + ex4.InnerException?.Message);
			}
		}
	}
}
