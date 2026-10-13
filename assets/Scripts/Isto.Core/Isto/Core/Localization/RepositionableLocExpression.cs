using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Localization;

public class RepositionableLocExpression : LocExpression
{
	private LocTerm _main;

	private LocTerm _positionable;

	private LocTerm _separator;

	private LocTermAffixPositionEnum _affixPositionLocation;

	public RepositionableLocExpression(LocTerm main, LocTerm positionable, LocTerm separator, LocTermAffixPositionEnum affixPositionLocation)
	{
		_main = main;
		_positionable = positionable;
		_separator = separator;
		_affixPositionLocation = affixPositionLocation;
		UpdateLocTerms();
	}

	private void UpdateLocTerms()
	{
		_locTerms = new List<LocTerm>();
		if (_affixPositionLocation == LocTermAffixPositionEnum.PREFIX)
		{
			_locTerms.Add(_positionable);
			_locTerms.Add(_separator);
			_locTerms.Add(_main);
		}
		else if (_affixPositionLocation == LocTermAffixPositionEnum.SUFFIX)
		{
			_locTerms.Add(_main);
			_locTerms.Add(_separator);
			_locTerms.Add(_positionable);
		}
		else if (_affixPositionLocation == LocTermAffixPositionEnum.DEFAULT)
		{
			Debug.LogError("The Affix position of DEFAULT does not have a concrete position. A different implementation of LocExpression is recommended for this usage.");
		}
		else
		{
			Debug.LogError($"Unknown location for affixed term {_affixPositionLocation}. Make sure that this " + "location has been implemented or handled correctly.");
		}
	}
}
