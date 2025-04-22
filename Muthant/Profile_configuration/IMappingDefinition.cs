using Muthant.Models;

namespace Muthant.Profile_configuration
{
    internal interface IMappingDefinition
    {
        Type SourceType { get; }
        Type DestinationType { get; }

        public List<MappingPropertyBuilder> GetMappings();
    }
}
