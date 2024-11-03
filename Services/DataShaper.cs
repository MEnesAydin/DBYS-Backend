using System.Dynamic;
using System.Reflection;

namespace Services
{
    public static class DataShaper
    {
        // public PropertyInfo[] Properties { get; set; }
        // public DataShaper()
        // {
        //     Properties = typeof(T)
        //         .GetProperties(BindingFlags.Public | BindingFlags.Instance);
        // }
        public static IEnumerable<ExpandoObject> ShapeData(IEnumerable<object> entities, string? fieldsString,
            Type objectType)
        {
            var requiredFields = GetRequiredProperties(fieldsString, objectType);
            return FetchData(entities, requiredFields);
        }

        public static ExpandoObject ShapeData(object entity, string? fieldsString, Type objectType)
        {
            var requiredProperties = GetRequiredProperties(fieldsString, objectType);
            return FetchDataForEntity(entity, requiredProperties);
        }

        private static IEnumerable<PropertyInfo> GetRequiredProperties(string? fieldsString, Type objectType)
        {
            var requiredFields = new List<PropertyInfo>();

            var properties = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if (!string.IsNullOrWhiteSpace(fieldsString))
            {
                var fields = fieldsString.Split(',',
                    StringSplitOptions.RemoveEmptyEntries);

                foreach (var field in fields)
                {
                    var property = properties
                        .FirstOrDefault(pi => pi.Name.Equals(field.Trim(),
                            StringComparison.InvariantCultureIgnoreCase));
                    if (property is null)
                        continue;
                    requiredFields.Add(property);
                }
            }
            else
            {
                requiredFields = properties.ToList();
            }

            return requiredFields;
        }

        private static ExpandoObject FetchDataForEntity(object entity,
            IEnumerable<PropertyInfo> requiredProperties)
        {
            var shapedObject = new ExpandoObject();

            foreach (var property in requiredProperties)
            {
                var objectPropertyValue = property.GetValue(entity);
                shapedObject.TryAdd(property.Name, objectPropertyValue);
            }

            return shapedObject;
        }

        private static IEnumerable<ExpandoObject> FetchData(IEnumerable<object> entities,
            IEnumerable<PropertyInfo> requiredProperties)
        {
            var shapedData = new List<ExpandoObject>();
            var requiredPropertiesArray = requiredProperties.ToArray();
            foreach (var entity in entities)
            {
                var shapedObject = FetchDataForEntity(entity, requiredPropertiesArray);
                shapedData.Add(shapedObject);
            }

            return shapedData;
        }
    }
}