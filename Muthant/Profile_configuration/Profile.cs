using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muthant.Profile_configuration
{
    public class Profile
    {
        private readonly List<IMappingDefinition> _mappings = new();

        public MappingBuilder<TSource, TDestiny> CreateMutation<TSource, TDestiny>()
        {
            var builder = new MappingBuilder<TSource, TDestiny>();
            _mappings.Add(builder);
            return builder;
        }

        internal IEnumerable<IMappingDefinition> GetMappings() => _mappings;
    }
}
