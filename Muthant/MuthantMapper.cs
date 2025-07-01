using Muthant.Profile_configuration;
using System.Collections;

namespace Muthant;

public class MuthantMapper
{
    private Profile _profile;

    public MuthantMapper(Profile profile)
    {
        _profile = profile;
    }

    public virtual TDestiny Transmute<TDestiny>(object origin)
    {
        var type = typeof(TDestiny);
        object destiny;

        if (type.IsInterface && type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
        {
            Type itemType = type.GetGenericArguments()[0];
            Type listType = typeof(List<>).MakeGenericType(itemType);
            destiny = Activator.CreateInstance(listType);
        }
        else
            destiny = Activator.CreateInstance(type);

        if (destiny.GetType().IsGenericType && destiny.GetType().GetGenericTypeDefinition() == typeof(List<>))
        {
            var destinyList = (IList)destiny;
            var destinyType = destiny.GetType().GetGenericArguments()[0];

            foreach (var item in (IEnumerable)origin)
            {
                var model = Transmute(destinyType, item);
                destinyList.Add(model);
            }

            return (TDestiny)destinyList;
        }
        else
        {
            foreach (var destinyProp in destiny.GetType().GetProperties())
            {
                var config = _profile
                    .GetMappings()
                    .ToList()
                    .Find(map => map.SourceType == origin.GetType() && map.DestinationType == destiny.GetType());

                var propertyName = "";
                if (config is null) propertyName = destinyProp.Name;

                else
                {
                    var mapper = config
                        .GetMappings()
                        .Find(map => map.DestinationProperty == destinyProp.Name);

                    if (mapper is not null)
                        propertyName = mapper.SourceProperty.ToString();
                }

                var originProp = origin.GetType().GetProperty(propertyName);
                
                if (originProp is not null)
                    destinyProp.SetValue(destiny, originProp.GetValue(origin, null));
            }
        }

        return (TDestiny)destiny;
    }

    private object Transmute(Type destiny, object origin)
    {
        object destinyInstance = Activator.CreateInstance(destiny);

        foreach (var destinyProp in destiny.GetProperties())
        {
            var originProp = origin.GetType().GetProperty(destinyProp.Name);
            if (originProp is not null)
                destinyProp.SetValue(destinyInstance, originProp.GetValue(origin, null));
        }

        return destinyInstance;
    }
}

