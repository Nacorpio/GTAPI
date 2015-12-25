using GTA;
using Newtonsoft.Json;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="Model"/>.
    /// </summary>
    public struct JModel
    {
        /// <summary>
        /// Initializes an instance of the <see cref="JModel"/> structure.
        /// </summary>
        /// <param name="model">The model.</param>
        public JModel(Model model)
        {
            Hash = model.Hash;
        }

        /// <summary>
        /// Initializes an instance of the <see cref="JModel"/> structure.
        /// </summary>
        /// <param name="hash"></param>
        public JModel(int hash) : this(new Model(hash))
        {}

        /// <summary>
        /// Gets the hash of this <see cref="JModel"/>.
        /// </summary>
        [JsonProperty("hash")]
        public int Hash { get; }

        /// <summary>
        /// Converts the specified <see cref="Model"/> to a <see cref="JModel"/>.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static JModel ToJModel(Model model)
        {
            return new JModel(model);
        }

        /// <summary>
        /// Converts this <see cref="JModel"/> to a JSON-serialized string.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
