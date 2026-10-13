using System.ComponentModel;

namespace System.ServiceProcess;

[AttributeUsage(AttributeTargets.All)]
public class ServiceProcessDescriptionAttribute : DescriptionAttribute
{
	private string description;

	public override string Description => description;

	public ServiceProcessDescriptionAttribute(string description)
	{
		this.description = description;
	}
}
