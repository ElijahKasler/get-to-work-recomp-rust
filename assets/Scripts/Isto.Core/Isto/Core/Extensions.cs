using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using Isto.Core.Automation;
using Isto.Core.Items;
using Isto.Core.Localization;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Isto.Core;

public static class Extensions
{
	public static Vector3 GetSnappedPosition(this Vector3 position, float n)
	{
		float x = Mathf.Round(position.x / n) * n;
		float y = Mathf.Round(position.y / n) * n;
		float z = Mathf.Round(position.z / n) * n;
		return new Vector3(x, y, z);
	}

	public static Vector3 FlipAlongX(this Vector3 target)
	{
		target.x *= -1f;
		return target;
	}

	public static bool EqualsXZ(this Vector3 self, Vector3 other)
	{
		if (self.x.Approx(other.x))
		{
			return self.z.Approx(other.z);
		}
		return false;
	}

	public static float DistanceXZ(this Vector3 self, Vector3 other)
	{
		return Mathf.Sqrt(Mathf.Pow(self.x - other.x, 2f) + Mathf.Pow(self.z - other.z, 2f));
	}

	public static bool Approx(this float a, float b, float epsilon = 0.0001f)
	{
		return Mathf.Abs(a - b) < epsilon;
	}

	public static bool Approx(this double a, double b, double epsilon = 9.999999747378752E-05)
	{
		return Math.Abs(a - b) < epsilon;
	}

	public static bool Contains(this LayerMask mask, int layer)
	{
		return (int)mask == ((int)mask | (1 << layer));
	}

	public static bool IsInLayerMask(this LayerMask mask, int layer)
	{
		return (int)mask == ((int)mask | (1 << layer));
	}

	public static void SetChildLayers(this GameObject gameObject, int layer)
	{
		Collider[] componentsInChildren = gameObject.GetComponentsInChildren<Collider>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].gameObject.layer = layer;
		}
		gameObject.layer = layer;
	}

	public static void SetColliderState(this GameObject gameObject, bool enabled)
	{
		Collider component = gameObject.GetComponent<Collider>();
		if (component != null)
		{
			component.enabled = enabled;
		}
		Collider[] componentsInChildren = gameObject.GetComponentsInChildren<Collider>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].gameObject.layer != Layers.ITEM_OVERLAP)
			{
				componentsInChildren[i].enabled = enabled;
			}
		}
	}

	public static GameObject GetTopMostParent(this GameObject gameObject)
	{
		IItemTopmostParent itemTopmostParent = gameObject.GetComponentInParent<IItemTopmostParent>();
		if (itemTopmostParent == null)
		{
			itemTopmostParent = gameObject.GetComponent<IItemTopmostParent>();
		}
		return itemTopmostParent?.GetGameObject();
	}

	public static bool IsParentOf(this GameObject gameObject, GameObject child)
	{
		if (child == null)
		{
			return false;
		}
		Transform parent = child.transform.parent;
		while (parent != null)
		{
			if (parent.gameObject == gameObject)
			{
				return true;
			}
			parent = parent.parent;
		}
		return false;
	}

	public static void CompletePickupActions(this GameObject gameObject)
	{
		IActionOnPickup[] components = gameObject.GetComponents<IActionOnPickup>();
		for (int i = 0; i < components.Length; i++)
		{
			components[i].DoPickupAction();
		}
	}

	public static void CompleteActivateActions(this GameObject gameObject)
	{
		IActivatable[] components = gameObject.GetComponents<IActivatable>();
		for (int i = 0; i < components.Length; i++)
		{
			components[i].Activate();
		}
	}

	public static void UpdateOtherGridSpaceDisplays(this MonoBehaviour behaviour, AutomationGridSpace space)
	{
		IAutomationGridSpaceDisplay[] componentsInChildren = behaviour.GetComponentsInChildren<IAutomationGridSpaceDisplay>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i] as MonoBehaviour != behaviour)
			{
				componentsInChildren[i].SetGridSpace(space);
			}
		}
	}

	public static void WaitForConditionIfNeeded(this MonoBehaviour behaviour, Func<bool> condition, Action onCondition)
	{
		if (!condition())
		{
			behaviour.StartCoroutine(WaitForConditionThenAction(condition, onCondition));
		}
		else
		{
			onCondition();
		}
	}

	private static IEnumerator WaitForConditionThenAction(Func<bool> condition, Action onCondition)
	{
		while (!condition())
		{
			yield return new WaitForSeconds(0.2f);
		}
		onCondition();
	}

	public static void DelayedExecute(this MonoBehaviour behaviour, float delay, Action toExecute)
	{
		behaviour.StartCoroutine(DelayedExecuteCoroutine(delay, toExecute));
	}

	private static IEnumerator DelayedExecuteCoroutine(float delay, Action toExecute)
	{
		yield return new WaitForSeconds(delay);
		toExecute();
	}

	public static void ClearTriggers(this Animator anim, AnimatorControllerParameter[] parameters)
	{
		if (anim == null)
		{
			return;
		}
		for (int i = 0; i < anim.parameterCount; i++)
		{
			AnimatorControllerParameter animatorControllerParameter = parameters[i];
			if (animatorControllerParameter.type == AnimatorControllerParameterType.Trigger)
			{
				anim.ResetTrigger(animatorControllerParameter.nameHash);
			}
		}
	}

	public static void ClearTriggers(this Animator anim, HashSet<AnimatorControllerParameter> parameters)
	{
		if (anim == null)
		{
			return;
		}
		foreach (AnimatorControllerParameter parameter in parameters)
		{
			if (parameter.type == AnimatorControllerParameterType.Trigger)
			{
				anim.ResetTrigger(parameter.nameHash);
			}
		}
	}

	public static bool HasParameter(this Animator animator, string parameter, AnimatorControllerParameterType type, HashSet<AnimatorControllerParameter> parameters)
	{
		int num = Animator.StringToHash(parameter);
		foreach (AnimatorControllerParameter parameter2 in parameters)
		{
			if (parameter2.nameHash == num && parameter2.type == type)
			{
				return true;
			}
		}
		return false;
	}

	public static Vector3 RandomXZPointInBounds(this Bounds bounds)
	{
		float x = UnityEngine.Random.Range(bounds.min.x, bounds.max.x);
		float z = UnityEngine.Random.Range(bounds.min.z, bounds.max.z);
		return new Vector3(x, 0f, z);
	}

	public static void SetCanvasValues(this CanvasGroup group, float alpha, bool interactable, bool blockRaycast)
	{
		group.alpha = alpha;
		group.interactable = interactable;
		group.blocksRaycasts = blockRaycast;
	}

	public static string ToUpper(this LocalizedString locString)
	{
		return Loc.Get(locString).ToUpper();
	}

	public static int TryGetInt(this string source)
	{
		return int.Parse(source);
	}

	public static bool CaseInsensitiveContains(this string source, string word)
	{
		if (source.Contains(word))
		{
			return true;
		}
		return source.IndexOf(word, StringComparison.CurrentCultureIgnoreCase) >= 0;
	}

	public static bool IsEqualWithNullsAsEmpty(this string self, string other)
	{
		if (string.IsNullOrEmpty(self) && string.IsNullOrEmpty(other))
		{
			return true;
		}
		if (string.IsNullOrEmpty(self) && !string.IsNullOrEmpty(other))
		{
			return false;
		}
		return self.Equals(other);
	}

	public static bool IsMoving(this NavMeshAgent agent, float stoppingExtraBuffer = 0f)
	{
		if (!agent.isOnNavMesh)
		{
			return false;
		}
		if (agent.pathPending)
		{
			return true;
		}
		bool flag = !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance + stoppingExtraBuffer;
		bool flag2 = agent.velocity.sqrMagnitude > 0.02f;
		if (!flag && agent.velocity.magnitude < 0.01f && agent.desiredVelocity.magnitude < 0.01f)
		{
			return false;
		}
		return !flag | flag2;
	}

	public static bool IsNullOrDestroyed(this object obj)
	{
		if (obj != null)
		{
			if (obj is UnityEngine.Object)
			{
				return (UnityEngine.Object)obj == null;
			}
			return false;
		}
		return true;
	}

	public static Color WithAlpha(this Color inputColor, float alpha)
	{
		return new Color(inputColor.r, inputColor.g, inputColor.b, alpha);
	}

	public static bool IsEquivalentTo(this Resolution a, Resolution b)
	{
		if (a.width == b.width && a.height == b.height)
		{
			return a.refreshRate.Approx(b.refreshRate);
		}
		return false;
	}

	private static bool Approx(this int a, int b, int tolerance = 1)
	{
		return Math.Abs(b - a) <= tolerance;
	}

	public static bool SequenceEqualOrNull<T>(this List<T> self, List<T> other)
	{
		if (self == null && other != null)
		{
			return false;
		}
		if (self != null && other == null)
		{
			return false;
		}
		if (self.Count != other.Count)
		{
			return false;
		}
		return self.SequenceEqual(other);
	}

	public static bool ArrayEqualOrNull<T>(this T[] self, T[] other)
	{
		if (self == null && other != null)
		{
			return false;
		}
		if (self != null && other == null)
		{
			return false;
		}
		if (self.Length != other.Length)
		{
			return false;
		}
		return Enumerable.SequenceEqual(self, other);
	}

	public static void Refresh(this GridLayoutGroup gridLayoutGroup)
	{
		gridLayoutGroup.enabled = true;
		gridLayoutGroup.StartCoroutine(RefreshGridLayoutGroupCoroutine(gridLayoutGroup));
	}

	private static IEnumerator RefreshGridLayoutGroupCoroutine(GridLayoutGroup gridLayoutGroup)
	{
		yield return null;
		gridLayoutGroup.enabled = false;
	}

	public static void SetGridLayoutCentered(this GridLayoutGroup gridLayoutGroup)
	{
		gridLayoutGroup.enabled = true;
		gridLayoutGroup.childAlignment = TextAnchor.UpperCenter;
		gridLayoutGroup.StartCoroutine(RefreshGridLayoutGroupCoroutine(gridLayoutGroup));
	}

	public static void SetGridLayoutLeftAligned(this GridLayoutGroup gridLayoutGroup)
	{
		gridLayoutGroup.enabled = true;
		gridLayoutGroup.childAlignment = TextAnchor.UpperLeft;
		gridLayoutGroup.StartCoroutine(RefreshGridLayoutGroupCoroutine(gridLayoutGroup));
	}

	public static bool ContainsExactly(this string[] a, string[] b)
	{
		if (a == null || b == null)
		{
			return false;
		}
		if (a.Length == b.Length)
		{
			return a.Except(b).Count() == 0;
		}
		return false;
	}

	public static bool ContainsExactly<T>(this ICollection<T> a, T[] b)
	{
		if (a == null || b == null)
		{
			return false;
		}
		if (a.Count == b.Length)
		{
			return a.Except(b).Count() == 0;
		}
		return false;
	}

	public static string ToFullString(this string[] self)
	{
		if (self == null)
		{
			return "(null)";
		}
		return "[ " + string.Join(", ", self) + " ]";
	}

	public static string ToFullString<T>(this ICollection<T> self)
	{
		if (self == null)
		{
			return "(null)";
		}
		return "[ " + string.Join(", ", self) + " ]";
	}
}
