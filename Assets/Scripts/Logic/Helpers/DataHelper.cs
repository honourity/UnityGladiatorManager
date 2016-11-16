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
                if (data.ContainsKey(property.Name.ToLower()))
                {
                    property.SetValue(model, Convert.ChangeType(data[property.Name], property.PropertyType), null);
                }
            }
        }
    }
}
