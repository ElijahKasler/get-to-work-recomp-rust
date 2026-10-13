using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;

namespace Isto.Core.Localization;

public abstract class LocExpression
{
	protected List<LocTerm> _locTerms;

	public string Localize()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (LocTerm locTerm in _locTerms)
		{
			stringBuilder.Append(locTerm.Localize());
		}
		return stringBuilder.ToString();
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
		LocExpression obj = (LocExpression)otherObject;
		List<LocTerm> first = _locTerms ?? new List<LocTerm>();
		List<LocTerm> second = obj._locTerms ?? new List<LocTerm>();
		return first.SequenceEqual(second);
	}

	public override int GetHashCode()
	{
		if (_locTerms == null)
		{
			return 0;
		}
		int num = 17;
		foreach (LocTerm locTerm in _locTerms)
		{
			num *= 31 + (locTerm?.GetHashCode() ?? 0);
		}
		return num;
	}
}
