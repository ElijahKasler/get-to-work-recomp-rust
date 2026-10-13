using System.Collections.Generic;
using System.Reflection;

namespace Zenject;

public class PostInjectableInfo
{
	private readonly MethodInfo _methodInfo;

	private readonly List<InjectableInfo> _injectableInfo;

	public MethodInfo MethodInfo => _methodInfo;

	public IEnumerable<InjectableInfo> InjectableInfo => _injectableInfo;

	public PostInjectableInfo(MethodInfo methodInfo, List<InjectableInfo> injectableInfo)
	{
		_methodInfo = methodInfo;
		_injectableInfo = injectableInfo;
	}
}
