using System;
using Zenject.Internal;

namespace Zenject;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class InjectOptionalAttribute : InjectAttributeBase
{
	[Preserve]
	public InjectOptionalAttribute()
	{
		base.Optional = true;
	}
}
