using GTATest.Items;
using Newtonsoft.Json;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="Item"/>.
    /// </summary>
    public class JItem : JsonModel<Item>
    {
        /// <summary>
        /// Initializes an instance of the <see cref="JItem"/> structure.
        /// </summary>
        /// <param name="item">The item.</param>
        public JItem(Item item)
        {
            Id = item.Id;
            DisplayName = item.DisplayName;
            Name = item.Name;
            Summary = item.Summary;
            IsWeapon = item.IsWeapon;
            Model = new JModel(item.DropModel);
        }

        /// <summary>
        /// Creates an instance of this <see cref="JsonModel{T}"/>.
        /// </summary>
        public override Item Create()
        {
            return new Item(Id, Name);
        }

        /// <summary>
        /// Gets the unique identifier of this <see cref="JItem"/>.
        /// </summary>
        [JsonProperty("id", Order=0)]
        public int Id { get; }

        /// <summary>
        /// Gets the name of this <see cref="JItem"/>.
        /// </summary>
        [JsonProperty("name", Order=1)]
        public string Name { get; }

        /// <summary>
        /// Gets the display name of this <see cref="JItem"/>.
        /// </summary>
        [JsonProperty("displayName", Order=2)]
        public string DisplayName { get; }

        /// <summary>
        /// Gets the summary of this <see cref="JItem"/>.
        /// </summary>
        [JsonProperty("summary", Order=3)]
        public string Summary { get; }

        /// <summary>
        /// Gets whether this <see cref="JItem"/> is a weapon.
        /// </summary>
        [JsonProperty("isWeapon", Order=4)]
        public bool IsWeapon { get; }

        /// <summary>
        /// Gets the model that is shown when dropping this <see cref="JItem"/>.
        /// </summary>
        [JsonProperty("model", Order=5)]
        public JModel Model { get; }
    }
}
