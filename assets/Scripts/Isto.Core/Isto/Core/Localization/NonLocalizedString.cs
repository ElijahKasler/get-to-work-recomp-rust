namespace Isto.Core.Localization;

public class NonLocalizedString : LocTerm
{
	public NonLocalizedString(string locKey)
		: base(locKey)
	{
	}

	public override string Localize()
	{
		return _key;
	}

	public string GetNonLocalizedString()
	{
		return _key;
	}
}
