﻿using GTATest.Items;
using Newtonsoft.Json;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="Item"/>.
    /// </summary>
    public class JItem : JSerializable<JItem, Item>
    {
        /// <summary>
        /// Initializes an instance of the <see cref="JItem"/> structure.
        /// </summary>
        /// <param name="item">The item.</param>
        public JItem(Item item) : base(item)
        {
            Id = item.Id;
            DisplayName = item.DisplayName;
            Name = item.Name;
            Summary = item.Summary;
            IsWeapon = item.IsWeapon;
            Model = (JModel) JModel.ToObject(item.DropModel);
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
    }
}
