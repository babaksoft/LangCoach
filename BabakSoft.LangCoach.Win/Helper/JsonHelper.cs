using System.Text.Json;
using BabakSoft.Platform.Common;

namespace BabakSoft.LangCoach.Helper
{
    public class JsonHelper
    {
        public static string From<T>(T item, bool useCamelCasing = true, bool indented = true)
        {
            Verify.ArgumentNotNull(item, nameof(item));

            var options = GetJsonOptions(useCamelCasing, indented);
            return JsonSerializer.Serialize(item, options);
        }

        public static T To<T>(string json, bool useCamelCasing = true, bool indented = true)
        {
            Verify.ArgumentNotNullOrWhitespace(json, nameof(json));

            var options = GetJsonOptions(useCamelCasing, indented);
            return (T)JsonSerializer.Deserialize(json, typeof(T), options);
        }

        private static JsonSerializerOptions GetJsonOptions(bool useCamelCasing, bool indented)
        {
            var options = new JsonSerializerOptions()
            {
                AllowTrailingCommas = true,
                IgnoreReadOnlyFields = true,
                WriteIndented = indented
            };

            if (useCamelCasing)
            {
                options.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            }

            return options;
        }
    }
}
