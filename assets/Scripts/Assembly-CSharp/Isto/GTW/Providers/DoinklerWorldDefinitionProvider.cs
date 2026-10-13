using Isto.GTW.Configuration;

namespace Isto.GTW.Providers;

public class DoinklerWorldDefinitionProvider : IDoinklerWorldDefinitionProvider
{
	public GTWGameWorldDefinition Current { get; set; }
}
