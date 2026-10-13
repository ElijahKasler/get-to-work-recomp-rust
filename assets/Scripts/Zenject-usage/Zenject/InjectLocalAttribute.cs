using System;
using Zenject.Internal;

namespace Zenject;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class InjectLocalAttribute : InjectAttributeBase
{
	[Preserve]
	public InjectLocalAttribute()
	{
		base.Source = InjectSources.Local;
	}
}
