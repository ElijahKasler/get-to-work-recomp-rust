using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.BugReportingTool;

[CreateAssetMenu(fileName = "IstoDevelopers-", menuName = "Isto/Core/New Bug Reporter Developer Names List")]
public class IstoDevelopers : ScriptableObject
{
	[Tooltip("Isto Inc. developers full name.")]
	[SerializeField]
	private List<string> _istoFullNames;

	public List<string> IstoFullNames => _istoFullNames;
}
