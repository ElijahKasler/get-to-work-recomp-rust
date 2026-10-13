using System.Collections.Generic;

namespace Isto.Core.Localization;

public class MultiTermLocExpression : LocExpression
{
	public List<LocTerm> GetTerms()
	{
		return _locTerms;
	}

	public MultiTermLocExpression(List<LocTerm> locTerms)
	{
		_locTerms = locTerms;
	}
}
