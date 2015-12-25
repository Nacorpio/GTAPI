using System.Collections.Generic;
using System.Linq;
using GTATest.Storage;
using Newtonsoft.Json;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="Inventory"/>.
    /// </summary>
    public struct JInventory
    {
        /// <summary>
        /// Initializes an instance of the <see cref="JInventory"/> structure.
        /// </summary>
        /// <param name="inventory">The inventory.</param>
        public JInventory(Inventory inventory)
        {
            Name = inventory.Name;
            Items = inventory.Items.Select(JItemStack.ToJItemStack);
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

        /// <summary>
        /// Converts the specified <see cref="Inventory"/> to a <see cref="JInventory"/>.
        /// </summary>
        /// <param name="inventory">The inventory.</param>
        /// <returns></returns>
        public static JInventory ToJInventory(Inventory inventory)
        {
            return new JInventory(inventory);
        }

        /// <summary>
        /// Converts this <see cref="JInventory"/> to a JSON-serialized string.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
