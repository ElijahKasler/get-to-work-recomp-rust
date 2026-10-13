using System.Collections.Generic;

namespace Zenject.Internal;

public interface IDecoratorProvider
{
	List<object> GetAllInstances(IProvider provider, InjectContext context);
}
