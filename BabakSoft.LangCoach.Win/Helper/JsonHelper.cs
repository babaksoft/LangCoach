using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using BabakSoft.Platform.Common;

namespace BabakSoft.LangCoach.Helper
{
    /// <summary>
    /// Provides basic serialization to/from JavaScript Object Notation (JSON) format
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        /// Serializes given object to JSON text
        /// </summary>
        /// <typeparam name="T">Type of object to serialize</typeparam>
        /// <param name="item">Object to serialize</param>
        /// <param name="webSafe">
        /// Indicates if special characters need to be escaped to improve Web security
        /// </param>
        /// <param name="camelCase">Indicates if camel-case naming is required</param>
        /// <param name="indented">Indicates if pretty printing is required for output</param>
        /// <returns>Given object encoded as JSON string</returns>
        public static string From<T>(
            T item, bool webSafe = true, bool camelCase = true, bool indented = true)
        {
            Verify.ArgumentNotNull(item, nameof(item));

            var options = GetJsonOptions(webSafe, camelCase, indented);
            return JsonSerializer.Serialize(item, options);
        }

        /// <summary>
        /// Deserializes the specified object type from given JSON text
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize from JSON</typeparam>
        /// <param name="json">JSON text that must be deserialized</param>
        /// <param name="webSafe">
        /// Indicates if special characters need to be escaped to improve Web security
        /// </param>
        /// <param name="camelCase">Indicates if camel-case naming is required</param>
        /// <param name="indented">Indicates if pretty printing is required for output</param>
        /// <returns>An object of the specified type deserialized from JSON</returns>
        public static T To<T>(
            string json, bool webSafe = true, bool camelCase = true, bool indented = true)
        {
            Verify.ArgumentNotNullOrWhitespace(json, nameof(json));

            var options = GetJsonOptions(webSafe, camelCase, indented);
            return (T)JsonSerializer.Deserialize(json, typeof(T), options);
        }

        private static JsonSerializerOptions GetJsonOptions(
            bool webSafe, bool camelCase, bool indented)
        {
            var encoder = webSafe
                ? JavaScriptEncoder.Create(UnicodeRanges.All)
                : JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            var options = new JsonSerializerOptions()
            {
                Encoder = encoder,
                AllowTrailingCommas = true,
                IgnoreReadOnlyFields = true,
                WriteIndented = indented
            };

            if (camelCase)
            {
                options.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            }

            return options;
        }
    }
}
