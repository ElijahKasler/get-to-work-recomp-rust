using System.Collections.Generic;
using System.Linq;

namespace Isto.Core.Localization;

public class SingleTermLocExpression : LocExpression
{
	public LocTerm GetTerm()
	{
		return _locTerms.FirstOrDefault();
	}

	public SingleTermLocExpression(LocTerm locTerm)
	{
		_locTerms = new List<LocTerm> { locTerm };
	}
}
