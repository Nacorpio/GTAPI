using GTA;
using Newtonsoft.Json;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="Model"/>.
    /// </summary>
    public class JModel : JsonModel<Model>
    {
        /// <summary>
        /// Initializes an instance of the <see cref="JModel"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public JModel(Model model)
        {
            Hash = model.Hash;
        }

        /// <summary>
        /// Creates an instance of this <see cref="JsonModel{T}"/>.
        /// </summary>
        public override Model Create()
        {
            return new Model(Hash);
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
    }
}
