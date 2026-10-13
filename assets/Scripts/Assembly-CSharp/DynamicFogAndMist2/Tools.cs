using UnityEngine;

namespace DynamicFogAndMist2;

public static class Tools
{
	public static Color ColorBlack = Color.black;

	public static void CheckCamera(ref Camera cam)
	{
		if (cam != null)
		{
			return;
		}
		cam = Camera.main;
		if (!(cam == null))
		{
			return;
		}
		Camera[] array = Misc.FindObjectsOfType<Camera>();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].isActiveAndEnabled && array[i].gameObject.activeInHierarchy)
			{
				cam = array[i];
				break;
			}
		}
	}

	public static DynamicFogManager CheckMainManager()
	{
		DynamicFogManager dynamicFogManager = Misc.FindObjectOfType<DynamicFogManager>();
		if (dynamicFogManager == null)
		{
			GameObject gameObject = new GameObject();
			dynamicFogManager = gameObject.AddComponent<DynamicFogManager>();
			gameObject.name = dynamicFogManager.managerName;
		}
		return dynamicFogManager;
	}

	public static void CheckManager<T>(ref T manager) where T : Component
	{
		if (!(manager == null))
		{
			return;
		}
		manager = Misc.FindObjectOfType<T>();
		if (manager == null)
		{
			DynamicFogManager dynamicFogManager = CheckMainManager();
			if (dynamicFogManager != null)
			{
				manager = Misc.FindObjectOfType<T>();
			}
			if (manager == null)
			{
				GameObject gameObject = new GameObject();
				gameObject.transform.SetParent(dynamicFogManager.transform, worldPositionStays: false);
				manager = gameObject.AddComponent<T>();
				gameObject.name = ((IDynamicFogManager)manager).managerName;
			}
		}
	}
}
