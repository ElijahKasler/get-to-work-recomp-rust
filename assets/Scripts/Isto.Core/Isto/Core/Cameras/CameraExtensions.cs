using UnityEngine;

namespace Isto.Core.Cameras;

public static class CameraExtensions
{
	public static readonly int DEFAULT_SAVE_FILE_SCREENSHOT_WIDTH = 1920;

	public static readonly int DEFAULT_SAVE_FILE_SCREENSHOT_HEIGHT = 1080;

	public static readonly int DEFAULT_SAVE_FILE_SCREENSHOT_DEPTH = 16;

	public static Texture2D GetScreenCapture(this Camera screenCapCamera)
	{
		bool flag = false;
		if (screenCapCamera.targetTexture == null)
		{
			screenCapCamera.targetTexture = new RenderTexture(DEFAULT_SAVE_FILE_SCREENSHOT_WIDTH, DEFAULT_SAVE_FILE_SCREENSHOT_HEIGHT, DEFAULT_SAVE_FILE_SCREENSHOT_DEPTH);
			flag = true;
		}
		RenderTexture active = RenderTexture.active;
		RenderTexture renderTexture = (RenderTexture.active = screenCapCamera.targetTexture);
		screenCapCamera.Render();
		Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height);
		texture2D.ReadPixels(new Rect(0f, 0f, renderTexture.width, renderTexture.height), 0, 0);
		texture2D.Apply();
		RenderTexture.active = active;
		if (flag)
		{
			screenCapCamera.targetTexture = null;
		}
		return texture2D;
	}
}
