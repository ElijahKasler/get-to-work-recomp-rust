using System;
using UnityEngine;

namespace Isto.Core.Localization;

[Serializable]
public class LocKey
{
	public string locString;

	[HideInInspector]
	public bool showSearchField;

	[HideInInspector]
	public bool showSuggestions;

	[HideInInspector]
	public string searchText = "";

	public IstoLocalizedString GetLocalizedLocTerm()
	{
		return new IstoLocalizedString(locString);
	}

	public NonLocalizedString GetNonLocalizedString()
	{
		return new NonLocalizedString(locString);
	}
}
