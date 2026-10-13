using System.Collections.Concurrent;
using UnityEngine;

namespace Sisus.ComponentNames.EditorOnly;

[AddComponentMenu("")]
internal class NameContainer : MonoBehaviour
{
	private const string DontShowInMenu = "";

	internal static bool NowRenaming;

	internal static Component StartingToRename;

	private static readonly ConcurrentDictionary<Component, NameContainer> instances = new ConcurrentDictionary<Component, NameContainer>();

	[SerializeField]
	private string nameOverride = "";

	[SerializeField]
	private string tooltipOverride = "";

	[SerializeField]
	private Component target;
}
