using GTATest.Items;
using Newtonsoft.Json;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="Item"/>.
    /// </summary>
    public struct JItem
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
            Model = JModel.ToJModel(item.DropModel);
        }

        /// <summary>
        /// Gets the unique identifier of this <see cref="JItem"/>.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; }

        /// <summary>
        /// Gets the display name of this <see cref="JItem"/>.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; }

        /// <summary>
        /// Gets the name of this <see cref="JItem"/>.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Gets the summary of this <see cref="JItem"/>.
        /// </summary>
        [JsonProperty("summary")]
        public string Summary { get; }

        /// <summary>
        /// Gets whether this <see cref="JItem"/> is a weapon.
        /// </summary>
        [JsonProperty("isWeapon")]
        public bool IsWeapon { get; }

        /// <summary>
        /// Gets the model that is shown when dropping this <see cref="JItem"/>.
        /// </summary>
        [JsonProperty("model")]
        public JModel Model { get; }

        /// <summary>
        /// Converts the specified <see cref="Item"/> to a <see cref="JItem"/>.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public static JItem ToJItem(Item item)
        {
            return new JItem(item);
        }

        /// <summary>
        /// Converts this <see cref="JItem"/> to a JSON-serialized string.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
