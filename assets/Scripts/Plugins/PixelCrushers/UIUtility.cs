using UnityEngine;
using UnityEngine.EventSystems;

namespace PixelCrushers;

public static class UIUtility
{
	public static void RequireEventSystem()
	{
		if (Object.FindObjectOfType<EventSystem>() == null)
		{
			StandaloneInputModule component = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule)).GetComponent<StandaloneInputModule>();
			if (component != null)
			{
				component.forceModuleActive = true;
			}
		}
	}

	public static int GetAnimatorNameHash(AnimatorStateInfo animatorStateInfo)
	{
		return animatorStateInfo.fullPathHash;
	}
}
