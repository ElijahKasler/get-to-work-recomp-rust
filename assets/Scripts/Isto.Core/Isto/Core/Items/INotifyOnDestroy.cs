using System;

namespace Isto.Core.Items;

public interface INotifyOnDestroy
{
	event EventHandler Destroyed;
}
