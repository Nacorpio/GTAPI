using System.Collections.Generic;
using System.Linq;
using GTATest.Storage;
using Newtonsoft.Json;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="Inventory"/>.
    /// </summary>
    public class JInventory : JSerializable<JInventory, Inventory>
    {
        /// <summary>
        /// Initializes an instance of the <see cref="JInventory"/> class.
        /// </summary>
        /// <param name="inventory">The inventory.</param>
        public JInventory(Inventory inventory) : base(inventory)
        {
            Name = inventory.Name;
            Items = inventory.Items.Select(item => (JItemStack) JItemStack.ToObject(item));
        }

        /// <summary>
        /// Gets the name of this <see cref="JInventory"/>.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Gets the items of this <see cref="JInventory"/>.
        /// </summary>
        [JsonProperty("items")]
        public IEnumerable<JItemStack> Items { get; }
    }
}
