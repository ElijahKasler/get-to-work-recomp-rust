using System.Diagnostics;
using JetBrains.Annotations;
using UnityEngine;

namespace Sisus.ComponentNames;

public static class ComponentExtensions
{
	public static string GetName([NotNull] this Component component)
	{
		return component.GetType().Name;
	}

	[Conditional("UNITY_EDITOR")]
	public static void SetName([NotNull] this Component component, string name)
	{
	}

	[Conditional("UNITY_EDITOR")]
	public static void SetName([NotNull] this Component component, string name, bool classNameSuffix)
	{
	}

	[Conditional("UNITY_EDITOR")]
	public static void SetName([NotNull] this Component component, string name, [CanBeNull] string suffix)
	{
	}

	[Conditional("UNITY_EDITOR")]
	public static void SetName([NotNull] this Component component, GUIContent nameAndTooltip)
	{
	}

	[Conditional("UNITY_EDITOR")]
	public static void SetName([NotNull] this Component component, GUIContent nameAndTooltip, bool classNameSuffix)
	{
	}

	[Conditional("UNITY_EDITOR")]
	public static void SetName([NotNull] this Component component, string name, bool classNameSuffix, string tooltip)
	{
	}

	[Conditional("UNITY_EDITOR")]
	public static void SetName([NotNull] this Component component, string name, [CanBeNull] string suffix, string tooltip)
	{
	}
}
