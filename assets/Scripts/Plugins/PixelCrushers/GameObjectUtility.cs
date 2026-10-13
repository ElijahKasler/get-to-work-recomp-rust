using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelCrushers;

public static class GameObjectUtility
{
	public static bool IsPrefab(GameObject go)
	{
		if (go == null)
		{
			return false;
		}
		if (go.activeInHierarchy)
		{
			return false;
		}
		if (go.transform.parent != null && go.transform.parent.gameObject.activeSelf)
		{
			return false;
		}
		GameObject[] array = Object.FindObjectsOfType<GameObject>();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == go)
			{
				return false;
			}
		}
		return true;
	}

	public static GameObject GameObjectHardFind(string goName)
	{
		GameObject gameObject = GameObject.Find(goName);
		if (gameObject != null)
		{
			return gameObject;
		}
		GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
		for (int i = 0; i < rootGameObjects.Length; i++)
		{
			gameObject = GameObjectSearchHierarchy(rootGameObjects[i].transform, goName, string.Empty);
			if (gameObject != null)
			{
				return gameObject;
			}
		}
		return null;
	}

	public static GameObject GameObjectHardFind(string goName, string tag)
	{
		GameObject gameObject = null;
		GameObject[] array = GameObject.FindGameObjectsWithTag(tag);
		foreach (GameObject gameObject2 in array)
		{
			if (string.Equals(gameObject2.name, goName))
			{
				return gameObject2;
			}
		}
		GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
		for (int j = 0; j < rootGameObjects.Length; j++)
		{
			gameObject = GameObjectSearchHierarchy(rootGameObjects[j].transform, goName, tag);
			if (gameObject != null)
			{
				return gameObject;
			}
		}
		return null;
	}

	private static GameObject GameObjectSearchHierarchy(Transform t, string goName, string tag)
	{
		if (t == null)
		{
			return null;
		}
		if (string.Equals(t.name, goName) && (string.IsNullOrEmpty(tag) || string.Equals(t.tag, tag)))
		{
			return t.gameObject;
		}
		foreach (Transform item in t)
		{
			GameObject gameObject = GameObjectSearchHierarchy(item, goName, tag);
			if (gameObject != null)
			{
				return gameObject;
			}
		}
		return null;
	}

	public static T GetComponentAnywhere<T>(GameObject gameObject) where T : Component
	{
		if (!gameObject)
		{
			return null;
		}
		T componentInChildren = gameObject.GetComponentInChildren<T>();
		if ((bool)componentInChildren)
		{
			return componentInChildren;
		}
		Transform parent = gameObject.transform.parent;
		int num = 0;
		while (!componentInChildren && (bool)parent && num < 256)
		{
			componentInChildren = parent.GetComponentInChildren<T>();
			parent = parent.parent;
		}
		return componentInChildren;
	}

	public static float GetGameObjectHeight(GameObject gameObject)
	{
		CharacterController component = gameObject.GetComponent<CharacterController>();
		if (component != null)
		{
			return component.height;
		}
		CapsuleCollider component2 = gameObject.GetComponent<CapsuleCollider>();
		if (component2 != null)
		{
			return component2.height;
		}
		BoxCollider component3 = gameObject.GetComponent<BoxCollider>();
		if (component3 != null)
		{
			return component3.center.y + component3.size.y;
		}
		SphereCollider component4 = gameObject.GetComponent<SphereCollider>();
		if (component4 != null)
		{
			return component4.center.y + component4.radius;
		}
		return 0f;
	}
}
