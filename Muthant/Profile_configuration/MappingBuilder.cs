using Muthant.Models;
using mystiqueMapper.Translators;
using System.Linq.Expressions;


namespace Muthant.Profile_configuration
{
    public class MappingBuilder<TSource, TDestiny> : IMappingDefinition
    {
        public readonly List<MappingPropertyBuilder> _mappings = new();

        public Type SourceType => typeof(TSource);

        public Type DestinationType => typeof(TDestiny);

        public PropertyMappingBuilder<TSource, TDestiny, TProperty> From<TProperty>(Expression<Func<TSource, TProperty>> sourceExpr)
        {
            var MappingProp = new MappingPropertyBuilder();
            MappingProp.SourceProperty = Translator.Translate(sourceExpr.Body);

            _mappings.Add(MappingProp);

            return new PropertyMappingBuilder<TSource, TDestiny, TProperty>(this, sourceExpr);
        }
        List<MappingPropertyBuilder> IMappingDefinition.GetMappings() => _mappings;

    }
}
