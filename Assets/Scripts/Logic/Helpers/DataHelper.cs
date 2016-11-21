using System;
using System.Collections.Generic;

namespace Assets.Scripts.Logic.Helpers
{
    public static class DataHelper
    {
        public static T CreateModelFromData<T>(IDictionary<string, object> data) where T : new()
        {
            T model = default(T);

            if ((data != null) && (data.Count > 0))
            {
                model = new T();

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

            return model;
        }

        public static ToType ConvertModelToModel<FromType, ToType>(FromType fromModel) where ToType : new()
        {
            ToType toModel = default(ToType);

            if (fromModel != null)
            {
                toModel = new ToType();

                var toModelProperties = toModel.GetType().GetProperties();
                var fromModelProperties = fromModel.GetType().GetProperties();
                foreach (var toProperty in toModelProperties)
                {
                    foreach(var fromProperty in fromModelProperties)
                    {
                        if (toProperty.Name == fromProperty.Name)
                        {
                            toProperty.SetValue(toModel, fromProperty.GetValue(fromModel, null), null);
                        }
                    }
                }
            }

            return toModel;
        }
    }
}
