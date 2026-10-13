using System;
using System.Collections.Generic;

namespace Zenject;

public interface IProvider
{
	bool TypeVariesBasedOnMemberType { get; }

	bool IsCached { get; }

	Type GetInstanceType(InjectContext context);

	List<object> GetAllInstancesWithInjectSplit(InjectContext context, List<TypeValuePair> args, out Action injectAction);
}
