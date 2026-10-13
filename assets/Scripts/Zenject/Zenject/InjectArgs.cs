using System.Collections.Generic;

namespace Zenject;

public class InjectArgs
{
	public List<TypeValuePair> ExtraArgs;

	public InjectContext Context;

	public object ConcreteIdentifier;
}
