using UnityEngine;
using Zenject;

namespace Isto.Core.Localization;

public class LocTermFactory : IFactory<LocTerm.LocalizationType, string, LocTerm>, IFactory
{
	private DiContainer _container;

	[Inject]
	public void Inject(DiContainer container)
	{
		_container = container;
	}

	public LocTerm Create(LocTerm.LocalizationType locType, string key)
	{
		LocTerm locTerm = null;
		switch (locType)
		{
		case LocTerm.LocalizationType.NonLocalized:
			locTerm = new NonLocalizedString(key);
			break;
		case LocTerm.LocalizationType.Localized:
			locTerm = new IstoLocalizedString(key);
			break;
		default:
			Debug.LogError($"Unsupported type for {locType} within the CustomLocTermFactory.");
			break;
		}
		_container.Inject(locTerm);
		return locTerm;
	}
}
