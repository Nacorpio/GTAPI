using GTA.Native;
using GTATest.Items;
using Newtonsoft.Json;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="ItemWeapon"/>.
    /// </summary>
    public class JItemWeapon : JItem
    {
        /// <summary>
        /// Initializes an instance of the <see cref="JItemWeapon"/> structure.
        /// </summary>
        /// <param name="item">The item.</param>
        public JItemWeapon(ItemWeapon item) : base(item)
        {
            Hash = item.Weapon;
        }

        /// <summary>
        /// Creates an instance of this <see cref="JsonModel{T}"/>.
        /// </summary>
        public override Item Create()
        {
            return new ItemWeapon(Hash, Id, Name);
        }

        /// <summary>
        /// Gets the hash of this <see cref="JItemWeapon"/>.
        /// </summary>
        [JsonProperty("hash")]
        public WeaponHash Hash { get; }
    }
}
