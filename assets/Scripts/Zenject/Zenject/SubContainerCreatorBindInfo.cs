using System;

namespace Zenject;

public class SubContainerCreatorBindInfo
{
	public string DefaultParentName { get; set; }

	public bool CreateKernel { get; set; }

	public Type KernelType { get; set; }
}
