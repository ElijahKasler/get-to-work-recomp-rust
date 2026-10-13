using System.IO;
using UnityEngine;

namespace Isto.Core.Screenshot;

public class ScreenshotFile
{
	private static readonly float PIXELS_PER_UNIT = 100f;

	private string _filePath;

	public string FilePath => _filePath;

	public ScreenshotFile()
	{
		_filePath = "";
	}

	public ScreenshotFile(string filePath)
	{
		_filePath = filePath;
	}

	public Sprite GetScreenshotAsSprite()
	{
		Texture2D texture2D = RetrieveTextureFromFile();
		Vector2 pivot = new Vector2(0.5f, 0.5f);
		Rect rect = new Rect(0f, 0f, texture2D.width, texture2D.height);
		return Sprite.Create(texture2D, rect, pivot, PIXELS_PER_UNIT);
	}

	private Texture2D RetrieveTextureFromFile()
	{
		byte[] data = File.ReadAllBytes(_filePath);
		Texture2D texture2D = new Texture2D(2, 2);
		texture2D.LoadImage(data);
		return texture2D;
	}
}
