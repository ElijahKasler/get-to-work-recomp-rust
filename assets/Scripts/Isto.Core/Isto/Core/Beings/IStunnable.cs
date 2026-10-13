using System;

namespace Isto.Core.Beings;

public interface IStunnable
{
	float StunPercent { get; }

	event EventHandler<HealthEventArgs> Stunned;

	event EventHandler<HealthEventArgs> StunReset;
}
