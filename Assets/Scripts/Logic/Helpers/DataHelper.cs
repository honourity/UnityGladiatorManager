using System;
using System.Collections.Generic;

namespace Assets.Scripts.Logic.Helpers
{
    public static class DataHelper
    {
        public static void MapDataToModel<T>(T model, IDictionary<string, object> data)
        {
            var properties = model.GetType().GetProperties();

            foreach (System.Reflection.PropertyInfo property in properties)
            {
                if (data.ContainsKey(property.Name))
                {
                    Type t = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                    object safeValue = (data[property.Name] == null) ? null : Convert.ChangeType(data[property.Name], t);

                    property.SetValue(model, safeValue, null);
                }
            }
        }
    }
}
