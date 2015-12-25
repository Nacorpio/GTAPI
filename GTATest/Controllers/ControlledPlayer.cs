﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GTA;
using GTA.Native;
using GTATest.Models;
using GTATest.Storage;
using Newtonsoft.Json;

namespace GTATest.Controllers
{
    /// <summary>
    /// Represents a <see cref="Player"/> that can be controlled in an advanced way.
    /// </summary>
    public class ControlledPlayer : ControlledPed, ISaveable
    {
        public delegate void ControlledPlayerEventHandler(object sender, EventArgs e);

        public event ControlledPlayerEventHandler Climbing, Aiming, RidingTrain;

        /// <summary>
        /// Initializes an instance of the <see cref="ControlledPlayer"/> class.
        /// </summary>
        public ControlledPlayer() : base(Game.Player.Character)
        {
            TrackEvents = true;

            Inventory = new Inventory("PlayerInventory") {
                Owner = Game.Player.Character
            };

            Game.Player.Character.Weapons.RemoveAll();
            SpawnWeapons.ToList().ForEach(weapon => Inventory.Add(weapon.Key, weapon.Value));

            Save();
        }

        /// <summary>
        /// Saves this ISaveable as a JSON file at the specified path.
        /// </summary>
        public void Save()
        {
            Directory.CreateDirectory("GTAPI");
            File.WriteAllText(@"GTAPI\player.json", ToModel().ToJson());
        }

        /// <summary>
        /// Gets the weapons that this <see cref="ControlledPlayer"/> spawns with.
        /// </summary>
        public Dictionary<WeaponHash, int> SpawnWeapons { get; } = new Dictionary<WeaponHash, int> {
            {WeaponHash.Flashlight, 0},
            {WeaponHash.Knife, 0},
            {WeaponHash.Pistol, 100}
        };

        /// <summary>
        /// Gets the inventory of this <see cref="ControlledPlayer"/>.
        /// </summary>
        public Inventory Inventory { get; }

        /// <summary>
        /// Updates the frame of this <see cref="ControlledPlayer"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public override void OnTick(object sender, EventArgs e)
        {
            base.OnTick(sender, e);

            if (!TrackEvents)
                return;

            var player = Game.Player;

            if (player.IsClimbing) {
                Climbing?.Invoke(sender, e);
            }

            if (player.IsAiming) {
                Aiming?.Invoke(sender, e);
            }

            if (player.IsRidingTrain) {
                RidingTrain?.Invoke(sender, e);
            }
        }

        /// <summary>
        /// Converts this <see cref="ControlledPlayer"/> to a serializable JSON model.
        /// </summary>
        /// <returns></returns>
        public JPlayer ToModel()
        {
            return new JPlayer(this);
        }
    }
}