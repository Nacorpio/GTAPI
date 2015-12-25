using Newtonsoft.Json;

namespace GTATest.Models
{
    // ReSharper disable once InconsistentNaming
    public class JSerializable<T, U>
    {
        /// <summary>
        /// Initializes an instance of the JSerializable class.
        /// </summary>
        /// <param name="obj"></param>
        protected JSerializable(U obj)
        {}

        /// <summary>
        /// Converts this JSerializable to a JSON-serialized string.
        /// </summary>
        /// <returns></returns>
        /// <param name="formatting">The JSON formatting.</param>
        public string ToJson(Formatting formatting)
        {
            return JsonConvert.SerializeObject(this, formatting);
        }

        /// <summary>
        /// Converts the specified <see cref="U"/> to a <see cref="T"/>.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static JSerializable<T, U> ToObject(U obj)
        {
            return new JSerializable<T, U>(obj);
        }
    }
}
