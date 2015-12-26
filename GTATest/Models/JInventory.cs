using System.Collections.Generic;
using System.Linq;
using GTATest.Storage;
using Newtonsoft.Json;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="Inventory"/>.
    /// </summary>
    public class JInventory : JsonModel<Inventory>
    {
        /// <summary>
        /// Initializes an instance of the <see cref="JInventory"/> class.
        /// </summary>
        /// <param name="inventory">The inventory.</param>
        public JInventory(Inventory inventory)
        {
            Name = inventory.Name;
            Items = inventory.Items.Select(item => new JItemStack(item));
        }

        /// <summary>
        /// Creates an instance of this <see cref="JsonModel{T}"/>.
        /// </summary>
        public override Inventory Create()
        {
            var inventory = new Inventory(Name);
            inventory.Items.AddRange(Items.Select(item => item.Create()));
            return inventory;
        }

        /// <summary>
        /// Gets the name of this <see cref="JInventory"/>.
        /// </summary>
        [JsonProperty("name", Order=0)]
        public string Name { get; }

        /// <summary>
        /// Gets the items of this <see cref="JInventory"/>.
        /// </summary>
        [JsonProperty("items", Order=1)]
        public IEnumerable<JItemStack> Items { get; }
    }
}
