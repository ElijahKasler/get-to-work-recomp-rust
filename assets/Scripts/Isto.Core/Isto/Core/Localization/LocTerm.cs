using TMPro;
using Zenject;

namespace Isto.Core.Localization;

public abstract class LocTerm
{
	public enum LocalizationType
	{
		NonLocalized = 0,
		Localized = 1
	}

	public class Factory : PlaceholderFactory<LocalizationType, string, LocTerm>
	{
	}

	protected readonly string _key;

	[Inject]
	private ILocalizationProvider _localization;

	protected LocTerm(string locKey)
	{
		_key = locKey;
	}

	public string GetKey()
	{
		return _key;
	}

	public virtual string Localize()
	{
		return _localization.GetLocalizedText(_key);
	}

	public void LocalizeInto(TextMeshProUGUI tmpUGUI)
	{
		if (tmpUGUI != null)
		{
			tmpUGUI.text = Localize();
		}
	}

	public override bool Equals(object otherObject)
	{
		if (otherObject == null || GetType() != otherObject.GetType())
		{
			return false;
		}
		LocTerm locTerm = (LocTerm)otherObject;
		return _key.Equals(locTerm._key);
	}

	public override int GetHashCode()
	{
		if (_key == null)
		{
			return 0;
		}
		return _key.GetHashCode();
	}
}
