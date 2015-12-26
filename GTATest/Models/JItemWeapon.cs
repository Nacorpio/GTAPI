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
        /// Gets the hash of this <see cref="JItemWeapon"/>.
        /// </summary>
        [JsonProperty("hash")]
        public WeaponHash Hash { get; }
    }
}
