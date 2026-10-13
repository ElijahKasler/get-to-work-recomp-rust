using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ModestTree.Util;

public static class UnityUtil
{
	public static IEnumerable<Scene> AllScenes
	{
		get
		{
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				yield return SceneManager.GetSceneAt(i);
			}
		}
	}

	public static IEnumerable<Scene> AllLoadedScenes => AllScenes.Where((Scene scene) => scene.isLoaded);

	public static bool IsAltKeyDown
	{
		get
		{
			if (!Input.GetKey(KeyCode.LeftAlt))
			{
				return Input.GetKey(KeyCode.RightAlt);
			}
			return true;
		}
	}

	public static bool IsControlKeyDown
	{
		get
		{
			if (!Input.GetKey(KeyCode.LeftControl))
			{
				return Input.GetKey(KeyCode.RightControl);
			}
			return true;
		}
	}

	public static bool IsShiftKeyDown
	{
		get
		{
			if (!Input.GetKey(KeyCode.LeftShift))
			{
				return Input.GetKey(KeyCode.RightShift);
			}
			return true;
		}
	}

	public static bool WasShiftKeyJustPressed
	{
		get
		{
			if (!Input.GetKeyDown(KeyCode.LeftShift))
			{
				return Input.GetKeyDown(KeyCode.RightShift);
			}
			return true;
		}
	}

	public static bool WasAltKeyJustPressed
	{
		get
		{
			if (!Input.GetKeyDown(KeyCode.LeftAlt))
			{
				return Input.GetKeyDown(KeyCode.RightAlt);
			}
			return true;
		}
	}

	public static int GetDepthLevel(Transform transform)
	{
		if (transform == null)
		{
			return 0;
		}
		return 1 + GetDepthLevel(transform.parent);
	}

	public static GameObject GetRootParentOrSelf(GameObject gameObject)
	{
		return (from x in GetParentsAndSelf(gameObject.transform)
			select x.gameObject).LastOrDefault();
	}

	public static IEnumerable<Transform> GetParents(Transform transform)
	{
		if (transform == null)
		{
			yield break;
		}
		foreach (Transform item in GetParentsAndSelf(transform.parent))
		{
			yield return item;
		}
	}

	public static IEnumerable<Transform> GetParentsAndSelf(Transform transform)
	{
		if (transform == null)
		{
			yield break;
		}
		yield return transform;
		foreach (Transform item in GetParentsAndSelf(transform.parent))
		{
			yield return item;
		}
	}

	public static IEnumerable<Component> GetComponentsInChildrenTopDown(GameObject gameObject, bool includeInactive)
	{
		return from x in gameObject.GetComponentsInChildren<Component>(includeInactive)
			orderby (!(x == null)) ? GetDepthLevel(x.transform) : int.MinValue
			select x;
	}

	public static IEnumerable<Component> GetComponentsInChildrenBottomUp(GameObject gameObject, bool includeInactive)
	{
		return from x in gameObject.GetComponentsInChildren<Component>(includeInactive)
			orderby (!(x == null)) ? GetDepthLevel(x.transform) : int.MinValue descending
			select x;
	}

	public static IEnumerable<GameObject> GetDirectChildrenAndSelf(GameObject obj)
	{
		yield return obj;
		foreach (Transform item in obj.transform)
		{
			yield return item.gameObject;
		}
	}

	public static IEnumerable<GameObject> GetDirectChildren(GameObject obj)
	{
		foreach (Transform item in obj.transform)
		{
			yield return item.gameObject;
		}
	}

	public static IEnumerable<GameObject> GetAllGameObjects()
	{
		return from x in Object.FindObjectsOfType<Transform>()
			select x.gameObject;
	}

	public static List<GameObject> GetAllRootGameObjects()
	{
		return (from x in GetAllGameObjects()
			where x.transform.parent == null
			select x).ToList();
	}
}
