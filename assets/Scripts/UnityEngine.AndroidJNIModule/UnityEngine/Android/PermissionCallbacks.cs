using System;

namespace UnityEngine.Android;

public class PermissionCallbacks : AndroidJavaProxy
{
	private enum Result
	{
		Dismissed = 0,
		Granted = 1,
		Denied = 2,
		DeniedDontAskAgain = 3
	}

	public event Action<string> PermissionGranted;

	public event Action<string> PermissionDenied;

	[Obsolete("Unreliable. Query ShouldShowRequestPermissionRationale and use PermissionDenied event.", false)]
	public event Action<string> PermissionDeniedAndDontAskAgain;

	public event Action<string> PermissionRequestDismissed;

	public PermissionCallbacks()
		: base("com.unity3d.player.IPermissionRequestCallbacks")
	{
	}

	public override IntPtr Invoke(string methodName, IntPtr javaArgs)
	{
		if (methodName == "onPermissionResult")
		{
			onPermissionResult(javaArgs);
			return IntPtr.Zero;
		}
		return base.Invoke(methodName, javaArgs);
	}

	private void onPermissionResult(IntPtr javaArgs)
	{
		IntPtr objectArrayElement = AndroidJNISafe.GetObjectArrayElement(javaArgs, 0);
		int[] array = AndroidJNISafe.FromIntArray(AndroidJNISafe.GetObjectArrayElement(javaArgs, 1));
		for (int i = 0; i < array.Length; i++)
		{
			string stringChars = AndroidJNISafe.GetStringChars(AndroidJNISafe.GetObjectArrayElement(objectArrayElement, i));
			switch ((Result)array[i])
			{
			case Result.Dismissed:
				if (PermissionRequestDismissed == null)
				{
					break;
				}
				PermissionRequestDismissed(stringChars);
				continue;
			case Result.Granted:
				PermissionGranted?.Invoke(stringChars);
				continue;
			case Result.DeniedDontAskAgain:
				if (PermissionDeniedAndDontAskAgain == null)
				{
					break;
				}
				PermissionDeniedAndDontAskAgain(stringChars);
				continue;
			case Result.Denied:
				break;
			default:
				continue;
			}
			PermissionDenied?.Invoke(stringChars);
		}
	}
}
