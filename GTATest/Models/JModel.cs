using GTA;
using Newtonsoft.Json;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="Model"/>.
    /// </summary>
    public class JModel : JSerializable<JModel, Model>
    {
        /// <summary>
        /// Initializes an instance of the <see cref="JModel"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public JModel(Model model) : base(model)
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
    }
}
