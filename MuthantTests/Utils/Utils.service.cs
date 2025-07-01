using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MystiqueMapperTests.Utils
{
    internal static class UtilsService
    {
        internal static bool CompareObjects(object destiny, object origin)
        {
            foreach (var prop in destiny.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var valueDestiny = prop.GetValue(destiny);

                var originProp = origin.GetType().GetProperty(prop.Name);
                if(originProp is not null) 
                    if (!object.Equals(valueDestiny, originProp.GetValue(origin)))
                        return false;
            }

            return true;
        }
    }
}
