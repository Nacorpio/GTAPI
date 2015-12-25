using System.Collections.Generic;
using GTA.Native;
using GTATest.Controllers;
using Newtonsoft.Json;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="ControlledPlayer"/>.
    /// </summary>
    public struct JPlayer
    {
        /// <summary>
        /// Initializes an instance of the JPlayer structure.
        /// </summary>
        /// <param name="player">The player.</param>
        public JPlayer(ControlledPlayer player)
        {
            Alertness = player.Alertness;
            TrackInteractions = player.TrackInteractions;
            SpawnWeapons = player.SpawnWeapons;
            Inventory = JInventory.ToJInventory(player.Inventory);
        }

        /// <summary>
        /// Gets the weapons that this JPlayer spawns with.
        /// </summary>
        [JsonProperty("spawnWeapons")]
        public Dictionary<WeaponHash, int> SpawnWeapons { get; } 

        /// <summary>
        /// Gets the alertness of this JPlayer.
        /// </summary>
        [JsonProperty("alertness")]
        public float Alertness { get; }

        /// <summary>
        /// Gets whether to track interactions.
        /// </summary>
        [JsonProperty("trackInteractions")]
        public bool TrackInteractions { get; }

        /// <summary>
        /// Gets the inventory of this JPlayer.
        /// </summary>
        [JsonProperty("inventory")]
        public JInventory Inventory { get; }

        /// <summary>
        /// Converts the specified <see cref="ControlledPlayer"/> to a <see cref="JPlayer"/>.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns></returns>
        public static JPlayer ToJPlayer(ControlledPlayer player)
        {
            return new JPlayer(player);
        }

        /// <summary>
        /// Converts this <see cref="JPlayer"/> to a JSON-serialized string.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
