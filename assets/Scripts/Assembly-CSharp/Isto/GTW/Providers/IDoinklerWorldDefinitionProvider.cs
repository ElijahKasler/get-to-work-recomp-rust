using Isto.GTW.Configuration;

namespace Isto.GTW.Providers;

public interface IDoinklerWorldDefinitionProvider
{
	GTWGameWorldDefinition Current { get; set; }
}
