using mystiqueMapper.Translators;
using System.Linq.Expressions;


namespace Muthant.Profile_configuration
{
    public class PropertyMappingBuilder<TSource, TDestiny, TProperty>
    {
        private readonly MappingBuilder<TSource, TDestiny> _parent;
        private readonly Expression<Func<TSource, TProperty>> _sourceExpr;

        public PropertyMappingBuilder(MappingBuilder<TSource, TDestiny> parent, Expression<Func<TSource, TProperty>> sourceExpr)
        {
            _parent = parent;
            _sourceExpr = sourceExpr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="destExpr"></param>
        /// <returns></returns>
        public MappingBuilder<TSource, TDestiny> To(Expression<Func<TDestiny, TProperty>> destExpr)
        {
            _parent._mappings.Last().DestinationProperty = Translator.Translate(destExpr.Body);

            return _parent;
        }
    }
}
