using System;

namespace JetBrains.Annotations;

[Flags]
internal enum ImplicitUseTargetFlags
{
	Default = 1,
	Itself = Default,
	Members = 2,
	WithMembers = Default | Members
}
