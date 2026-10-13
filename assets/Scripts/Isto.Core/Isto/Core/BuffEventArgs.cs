using System;
using Isto.Core.Items;

namespace Isto.Core;

public class BuffEventArgs : EventArgs
{
	public BuffEffect buffEffect;

	public BuffEventArgs(BuffEffect buffEffect)
	{
		this.buffEffect = buffEffect;
	}
}
