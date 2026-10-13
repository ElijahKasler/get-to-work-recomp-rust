using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using ModestTree.Util;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Zenject.Internal;

public class ZenUtilInternal
{
	private static GameObject disabledIndestructibleGameObject;

	public static bool IsNull(object obj)
	{
		return obj?.Equals(null) ?? true;
	}

	public static bool AreFunctionsEqual(Delegate left, Delegate right)
	{
		if (left.Target == right.Target)
		{
			return left.Method() == right.Method();
		}
		return false;
	}

	public static int GetInheritanceDelta(Type derived, Type parent)
	{
		Assert.That(derived.DerivesFromOrEqual(parent));
		if (parent.IsInterface())
		{
			return 1;
		}
		if (derived == parent)
		{
			return 0;
		}
		int num = 1;
		Type type = derived;
		while ((type = type.BaseType()) != parent)
		{
			num++;
		}
		return num;
	}

	public static IEnumerable<SceneContext> GetAllSceneContexts()
	{
		foreach (Scene allLoadedScene in UnityUtil.AllLoadedScenes)
		{
			List<SceneContext> list = allLoadedScene.GetRootGameObjects().SelectMany((GameObject root) => root.GetComponentsInChildren<SceneContext>()).ToList();
			if (!list.IsEmpty())
			{
				Assert.That(list.Count == 1, "Found multiple scene contexts in scene '{0}'", allLoadedScene.name);
				yield return list[0];
			}
		}
	}

	public static void AddStateMachineBehaviourAutoInjectersInScene(Scene scene)
	{
		foreach (GameObject rootGameObject in GetRootGameObjects(scene))
		{
			if (rootGameObject != null)
			{
				AddStateMachineBehaviourAutoInjectersUnderGameObject(rootGameObject);
			}
		}
	}

	public static void AddStateMachineBehaviourAutoInjectersUnderGameObject(GameObject root)
	{
		Animator[] componentsInChildren = root.GetComponentsInChildren<Animator>(includeInactive: true);
		foreach (Animator animator in componentsInChildren)
		{
			if (animator.gameObject.GetComponent<ZenjectStateMachineBehaviourAutoInjecter>() == null)
			{
				animator.gameObject.AddComponent<ZenjectStateMachineBehaviourAutoInjecter>();
			}
		}
	}

	public static void GetInjectableMonoBehavioursInScene(Scene scene, List<MonoBehaviour> monoBehaviours)
	{
		foreach (GameObject rootGameObject in GetRootGameObjects(scene))
		{
			if (rootGameObject != null)
			{
				GetInjectableMonoBehavioursUnderGameObject(rootGameObject, monoBehaviours);
			}
		}
	}

	public static void GetInjectableMonoBehavioursUnderGameObject(GameObject gameObject, List<MonoBehaviour> injectableComponents)
	{
		if (gameObject == null)
		{
			return;
		}
		MonoBehaviour[] components = gameObject.GetComponents<MonoBehaviour>();
		foreach (MonoBehaviour monoBehaviour in components)
		{
			if (monoBehaviour != null && monoBehaviour.GetType().DerivesFromOrEqual<GameObjectContext>())
			{
				injectableComponents.Add(monoBehaviour);
				return;
			}
		}
		for (int j = 0; j < gameObject.transform.childCount; j++)
		{
			Transform child = gameObject.transform.GetChild(j);
			if (child != null)
			{
				GetInjectableMonoBehavioursUnderGameObject(child.gameObject, injectableComponents);
			}
		}
		foreach (MonoBehaviour monoBehaviour2 in components)
		{
			if (monoBehaviour2 != null && IsInjectableMonoBehaviourType(monoBehaviour2.GetType()))
			{
				injectableComponents.Add(monoBehaviour2);
			}
		}
	}

	public static bool IsInjectableMonoBehaviourType(Type type)
	{
		if (type != null && !type.DerivesFrom<MonoInstaller>())
		{
			if (type.Namespace != null)
			{
				return !type.Namespace.StartsWith("UnityEngine.", StringComparison.Ordinal);
			}
			return true;
		}
		return false;
	}

	public static IEnumerable<GameObject> GetRootGameObjects(Scene scene)
	{
		return from x in scene.GetRootGameObjects()
			where x.GetComponent<ProjectContext>() == null
			select x;
	}

	public static Transform GetOrCreateInactivePrefabParent()
	{
		if (disabledIndestructibleGameObject == null || (!Application.isPlaying && disabledIndestructibleGameObject.scene != SceneManager.GetActiveScene()))
		{
			GameObject gameObject = new GameObject("ZenUtilInternal_PrefabParent");
			gameObject.hideFlags = HideFlags.HideAndDontSave;
			gameObject.SetActive(value: false);
			if (Application.isPlaying)
			{
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
			}
			disabledIndestructibleGameObject = gameObject;
		}
		return disabledIndestructibleGameObject.transform;
	}
}
